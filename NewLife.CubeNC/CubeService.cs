﻿using System.Reflection;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.WebEncoders;
using Microsoft.Net.Http.Headers;
using NewLife.Common;
using NewLife.Cube.Extensions;
using NewLife.Cube.Modules;
using NewLife.Cube.Services;
using NewLife.Cube.WebMiddleware;
using NewLife.IP;
using NewLife.Log;
using NewLife.Reflection;
using NewLife.Serialization;
using NewLife.Web;
using Stardust;
using Stardust.Registry;
using XCode.DataAccessLayer;

namespace NewLife.Cube;

/// <summary>魔方服务</summary>
public static class CubeService
{
    /// <summary>区域名集合</summary>
    public static String[] AreaNames { get; set; }

    #region 配置魔方
    /// <summary>添加魔方，放在AddControllersWithViews之后</summary>
    /// <param name="services"></param>
    /// <returns></returns>o
    public static IServiceCollection AddCube(this IServiceCollection services)
    {
        // 引入星尘
        if (!services.Any(e => e.ServiceType == typeof(StarFactory)))
        {
            var star = new StarFactory();
            services.AddSingleton(star);
            services.AddSingleton(P => star.Tracer);
            services.AddSingleton(P => star.Config);
            services.AddSingleton(p => star.Service);
        }

        // 检查是否延迟启动，可能是重启或更新
        var args = Environment.GetCommandLineArgs();
        if ("-delay".EqualIgnoreCase(args)) Thread.Sleep(3000);

        using var span = DefaultTracer.Instance?.NewSpan(nameof(AddCube));

        XTrace.WriteLine("{0} Start 配置魔方 {0}", new String('=', 32));
        Assembly.GetExecutingAssembly().WriteVersion();

        // 修正系统名，确保可运行
        var sys = SysConfig.Current;
        if (sys.Name == "NewLife.Cube.Views" || sys.DisplayName == "NewLife.Cube.Views")
        {
            sys.Name = "NewLife.Cube";
            sys.DisplayName = "魔方平台";
            sys.Save();
        }

        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

        // 连接字符串
        DAL.ConnStrs.TryAdd("Cube", "MapTo=Membership");

        // 配置Cookie策略
        services.ConfigureNonBreakingSameSiteCookies();
        //services.Configure<CookiePolicyOptions>(options =>
        //{
        //    // 此项为true需要用户授权才能记录cookie
        //    options.CheckConsentNeeded = context => false;
        //    options.MinimumSameSitePolicy = SameSiteMode.None;
        //});


        // 添加Session会话支持
        services.AddSession();

        // 身份验证
        services.AddAuthentication(options =>
        {
            options.DefaultScheme = "Cube";
            options.DefaultAuthenticateScheme = "Cube";
            options.DefaultChallengeScheme = "Cube";
            options.DefaultSignInScheme = "Cube";
        }).AddCookie("Cube", options =>
        {
            options.AccessDeniedPath = "/Admin/User/Login";
            options.LoginPath = "/Admin/User/Login";
            options.LogoutPath = "/Admin/User/Logout";
        });

        //// 注册魔方默认UI
        //services.AddCubeDefaultUI();

        // 配置跨域处理，允许所有来源
        // CORS，全称 Cross-Origin Resource Sharing （跨域资源共享），是一种允许当前域的资源能被其他域访问的机制
        var set = CubeSetting.Current;
        if (set.CorsOrigins == "*")
            services.AddCors(options => options.AddPolicy("cube_cors", builder => builder
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials()
            .SetIsOriginAllowed(hostname => true)));
        else if (!set.CorsOrigins.IsNullOrEmpty())
            services.AddCors(options => options.AddPolicy("cube_cors", builder => builder
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials()
            .WithOrigins(set.CorsOrigins)));

        services.Configure<MvcOptions>(opt =>
        {
            opt.ModelBinderProviders.Insert(0, new JsonModelBinderProvider());

            // 分页器绑定
            opt.ModelBinderProviders.Insert(0, new PagerModelBinderProvider());

            // 模型绑定
            opt.ModelBinderProviders.Insert(0, new EntityModelBinderProvider());
        });

        services.AddCustomApplicationParts();

        // 添加管理提供者
        services.AddManageProvider();

        // 防止汉字被自动编码
        services.Configure<WebEncoderOptions>(options =>
        {
            options.TextEncoderSettings = new TextEncoderSettings(UnicodeRanges.All);
        });

        // 配置视图引擎
        services.Configure<RazorViewEngineOptions>(o =>
        {
            o.ViewLocationExpanders.Add(new ThemeViewLocationExpander());
        });

        // 配置Json
        services.Configure<JsonOptions>(options =>
        {
#if NET7_0_OR_GREATER
            // 支持模型类中的DataMember特性
            options.JsonSerializerOptions.TypeInfoResolver = DataMemberResolver.Default;
#endif
            options.JsonSerializerOptions.Converters.Add(new TypeConverter());
            options.JsonSerializerOptions.Converters.Add(new LocalTimeConverter());
            // 支持中文编码
            options.JsonSerializerOptions.Encoder = JavaScriptEncoder.Create(UnicodeRanges.All);
        });

        // UI服务
        services.AddSingleton<UIService>();
        services.AddSingleton<PasswordService>();
        services.AddSingleton<UserService>();

        services.AddHostedService<JobService>();
        //services.AddHostedService<UserService>();

        // 注册IP地址库
        IpResolver.Register();

        // 插件
        var moduleManager = new ModuleManager();
        services.AddSingleton(moduleManager);
        var modules = moduleManager.LoadAll();
        if (modules.Count > 0)
        {
            XTrace.WriteLine("加载功能插件[{0}]个", modules.Count);
            foreach (var item in modules)
            {
                XTrace.WriteLine("加载插件：{0}", item.Key);
                item.Value.Add(services);
            }
        }

        XTrace.WriteLine("{0} End   配置魔方 {0}", new String('=', 32));

        return services;
    }

    /// <summary>添加自定义应用部分，即添加外部引用的控制器、视图的Assembly，作为本应用的一部分</summary>
    /// <param name="services"></param>
    public static void AddCustomApplicationParts(this IServiceCollection services)
    {
        var manager = services.LastOrDefault(e => e.ServiceType == typeof(ApplicationPartManager))?.ImplementationInstance as ApplicationPartManager;
        manager ??= new ApplicationPartManager();

        var list = FindAllArea();

        foreach (var asm in list)
        {
            XTrace.WriteLine("注册区域视图程序集：{0}", asm.FullName);

            var factory = ApplicationPartFactory.GetApplicationPartFactory(asm);
            foreach (var part in factory.GetApplicationParts(asm))
            {
                if (!manager.ApplicationParts.Contains(part)) manager.ApplicationParts.Add(part);
            }
        }
    }

    /// <summary>遍历所有引用了AreaRegistrationBase的程序集</summary>
    /// <returns></returns>
    private static List<Assembly> FindAllArea()
    {
        var list = new List<Assembly>();
        var cs = typeof(ControllerBaseX).GetAllSubclasses().ToArray();
        foreach (var item in cs)
        {
            var asm = item.Assembly;
            if (!list.Contains(asm))
            {
                list.Add(asm);
            }
        }
        cs = typeof(RazorPage).GetAllSubclasses().ToArray();
        foreach (var item in cs)
        {
            var asm = item.Assembly;
            if (!list.Contains(asm))
            {
                list.Add(asm);
            }
        }

#if !NET6_0_OR_GREATER
        // 反射 *.Views.dll
        foreach (var item in ".".AsDirectory().GetFiles("*.Views.dll"))
        {
            var asm = Assembly.LoadFile(item.FullName);
            if (!list.Contains(asm) && !list.Any(e => e.FullName == asm.FullName))
            {
                list.Add(asm);
            }
        }

        // 反射 NewLife.Cube.*.dll
        foreach (var item in ".".AsDirectory().GetFiles("NewLife.Cube.*.dll"))
        {
            var asm = Assembly.LoadFile(item.FullName);
            if (!list.Contains(asm) && !list.Any(e => e.FullName == asm.FullName))
            {
                list.Add(asm);
            }
        }
#endif

        // 为了能够实现模板覆盖，程序集相互引用需要排序，父程序集在前
        list.Sort((x, y) =>
        {
            if (x == y) return 0;
            if (x != null && y == null) return 1;
            if (x == null && y != null) return -1;

            //return x.GetReferencedAssemblies().Any(e => e.FullName == y.FullName) ? 1 : -1;
            // 对程序集引用进行排序时，不能使用全名，当魔方更新而APP没有重新编译时，版本的不同将会导致全名不同，无法准确进行排序
            var yname = y.GetName().Name;
            return x.GetReferencedAssemblies().Any(e => e.Name == yname) ? 1 : -1;
        });

        return list;
    }
    #endregion

    #region 使用魔方
    /// <summary>使用魔方，放在UseEndpoints之前，自动探测是否UseRouting</summary>
    /// <param name="app"></param>
    /// <param name="env"></param>
    /// <returns></returns>
    public static IApplicationBuilder UseCube(this IApplicationBuilder app, IWebHostEnvironment env)
    {
        var provider = app.ApplicationServices;
        using var span = DefaultTracer.Instance?.NewSpan(nameof(UseCube));

        XTrace.WriteLine("{0} Start 初始化魔方 {0}", new String('=', 32));

        // 调整魔方表名
        FixAppTableName();

        // 使用管理提供者
        app.UseManagerProvider();

        var set = CubeSetting.Current;

        // 使用Cube前添加自己的管道
        if (env != null)
        {
            // 使用自己的异常处理页，后续必须再次UseRouting
            if (!env.IsDevelopment())
                app.UseExceptionHandler("/CubeHome/Error");
        }

        // 设置X-Frame-Options
        app.Use(async (context, next) =>
        {
            if (!set.XFrameOptions.IsNullOrWhiteSpace())
            {
                context.Response.Headers[HeaderNames.XFrameOptions] = set.XFrameOptions;
            }

            await next();
        });

        if (!set.CorsOrigins.IsNullOrEmpty()) app.UseCors("cube_cors");

        // 配置静态Http上下文访问器
        app.UseStaticHttpContext();

        // 注册中间件
        //app.UseStaticFiles();
        app.UseCookiePolicy();
        app.UseSession();
        app.UseAuthentication();

        // 如果已引入追踪中间件，则这里不再引入
        TracerMiddleware.Tracer ??= DefaultTracer.Instance;
        if (TracerMiddleware.Tracer != null && !app.Properties.ContainsKey(nameof(TracerMiddleware)))
        {
            app.UseMiddleware<TracerMiddleware>();

            app.Properties[nameof(TracerMiddleware)] = typeof(TracerMiddleware);
        }

        app.UseMiddleware<RunTimeMiddleware>();
        app.UseMiddleware<TenantMiddleware>();

        if (env != null) app.UseCubeDefaultUI(env);

        // 设置默认路由。如果外部已经执行 UseRouting，则直接注册
        app.UseRouter(endpoints =>
        {
            XTrace.WriteLine("注册魔方区域路由");

            endpoints.MapControllerRoute(
                "CubeAreas",
                "{area}/{controller=Index}/{action=Index}/{id?}");
        });

        ManageProvider2.EndpointRoute = (IEndpointRouteBuilder)app.Properties["__EndpointRouteBuilder"];

        // 自动检查并添加菜单
        AreaBase.RegisterArea<Admin.AdminArea>();
        AreaBase.RegisterArea<Cube.CubeArea>();

        // 插件
        var moduleManager = provider.GetRequiredService<ModuleManager>();
        var modules = moduleManager.LoadAll();
        if (modules.Count > 0)
        {
            XTrace.WriteLine("启用功能插件[{0}]个", modules.Count);
            foreach (var item in modules)
            {
                XTrace.WriteLine("启用插件：{0}", item.Key);
                item.Value.Use(app, env);
            }
        }

        XTrace.WriteLine("{0} End   初始化魔方 {0}", new String('=', 32));

        Task.Run(() => ResolveStarWeb(provider));

        // 注册退出事件
        if (app is IHost web)
            NewLife.Model.Host.RegisterExit(() =>
            {
                XTrace.WriteLine("魔方优雅退出！");
                web.StopAsync().Wait();
            });

        return app;
    }

    private static void FixAppTableName()
    {
        try
        {
            var dal = DAL.Create("Cube");
            var tables = dal.Tables;
            if (tables != null && !tables.Any(e => e.TableName.EqualIgnoreCase("OAuthApp")))
            {
                XTrace.WriteLine("未发现OAuth应用新表 OAuthApp");

                // 验证表名和部分字段名，避免误改其它表
                var dt = tables.FirstOrDefault(e => e.TableName.EqualIgnoreCase("App"));
                if (dt != null && dt.Columns.Any(e => e.ColumnName.EqualIgnoreCase("RoleIds")))
                {
                    XTrace.WriteLine("发现OAuth应用旧表 App ，准备重命名");

                    var rs = dal.Execute($"Alter Table App Rename To OAuthApp");
                    XTrace.WriteLine("重命名结果：{0}", rs);
                }
            }
        }
        catch (Exception ex)
        {
            XTrace.WriteException(ex);
        }
    }

    /// <summary>使用魔方首页</summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public static IApplicationBuilder UseCubeHome(this IApplicationBuilder app)
    {
        app.UseRouter(endpoints =>
        {
            endpoints.MapControllerRoute(
                "Default",
                "{controller=CubeHome}/{action=Index}/{id?}"
                );
        });

        return app;
    }

    /// <summary>使用路由配置，用于注册路由映射</summary>
    /// <param name="app"></param>
    /// <param name="configure"></param>
    /// <returns></returns>
    public static IApplicationBuilder UseRouter(this IApplicationBuilder app, Action<IEndpointRouteBuilder> configure)
    {
        if (configure == null) throw new ArgumentNullException(nameof(configure));

        // 设置默认路由。如果外部已经执行 UseRouting，则直接注册
        if (app.Properties.TryGetValue("__EndpointRouteBuilder", out var value) && value is IEndpointRouteBuilder eps)
        {
            configure(eps);
        }
        else
        {
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                configure(endpoints);
            });
        }

        return app;
    }

    static async Task ResolveStarWeb(IServiceProvider provider)
    {
        // 消费StarWeb服务地址，如果未接入星尘，这里也没必要获取这个地址
        var registry = provider.GetService<IRegistry>();
        if (registry != null)
        {
            using var span = DefaultTracer.Instance?.NewSpan(nameof(ResolveStarWeb));
            try
            {
                var webs = await registry.ResolveAddressAsync("StarWeb");
                if (webs != null)
                {
                    XTrace.WriteLine("StarWeb: {0}", webs.Join());
                    //StarHelper.StarWeb = webs.FirstOrDefault();
                    if (webs.Length > 0)
                    {
                        // 保存到配置文件
                        var set = CubeSetting.Current;
                        set.StarWeb = webs[0];
                        set.Save();
                    }
                }
            }
            catch (Exception ex)
            {
                span?.SetError(ex, null);
                XTrace.WriteLine(ex.Message);
            }
        }
    }
    #endregion
}