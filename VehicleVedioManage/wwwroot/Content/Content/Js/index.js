
	var funcMap = {};
	if(funcList.length > 0)
	{
		//funcList = funcList[0].items;
		$.each(funcList, function (i, sm) {
			funcMap[sm.funcName]=sm;
		});
	}
	//判断用户是否有这个功能权限
	function isFuncAllowed(funcName)
	{
		return funcMap[funcName];
	}

	
	
    var isReady = false;
    $(document).ready(function () {
        //关闭AJAX相应的缓存
        $.ajaxSetup({ cache: false });
		
		$("#mapFrame").attr("src", mapPath);
        //创建实时数据表格
		RealDataGrid.create(gpsDataFieldConfigs);
		//创建主菜单
		MyMenu.createMainMenu(mainMenuData);
		//创建快捷菜单
		MyMenu.createShortCutMenu(shortCutMenu);
		//创建命令工具栏
		MyMenu.createCommandToolBar(commandToolMenu);
		//创建右键菜单
		var treeRightMenu = MyMenu.createRightMenu(rightMenuData);
		//创建车辆树
		var vehicelTreeId = "vehicleTree";
		var treeHeight = 300;
		//创建车辆树
		VehicleTree.createTree(vehicelTreeId,treeHeight,treeRightMenu);
		//创建报警表格
		AlarmGrid.create();
		if(isFuncAllowed("Jt809CommandGrid"))
		{
		   Jt809CommandGrid.create();
		}else
		{
			$('#realDataTab').tabs('close',"上级政府平台");
		}
		if(isFuncAllowed("AlarmToDoGrid"))
		{
		   AlarmToDoGrid.create();
		}else
		{
			$('#realDataTab').tabs('close',"报警督办");
		}

		if(isFuncAllowed("TerminalCommandGrid"))
		{
		    TerminalCommandGrid.create();
		}else
		{
			$('#realDataTab').tabs('close',"终端命令");
		}


		//车辆树过滤条件下拉框触发事件
		$('#filterType').combobox(
		{
			onChange :function(newValue,oldValue){ 
				var filterType = newValue;
				if(filterType == "all")
				{
					//$("#filterType").combobox('setValue','');
					$('#searchBox').searchbox('setValue', null);
					VehicleTree.clearFilter();//清除过滤条件，重新查询
					VehicleTree.load(false);
				}else if(filterType == "online")
				{
					 var params = {online:1};
			         VehicleTree.filter(params);
				}else if(filterType == "offline")
				{
					 var params = {online:0};
			         VehicleTree.filter(params);
				}
		    }
		});
		$('#filterType').combobox("setValue","plateNo");
		$("#LoginName").html(userInfo.roleName+':'+userInfo.name);
		isReady = true;
		//创建地图图元树
		MapTree.createTree();
		
		$("#spanLoginTime").html(userInfo.loginTime);
		$('#routePlanWindow').window('close');
	});
	

	 var index = 0;
		function addPanel(){
			index++;
			$('#mainTab').tabs('add',{
				title: 'Tab'+index,
				content: '<div style="padding:10px">Content'+index+'</div>',
				closable: true
			});
		}

	function onMainTabLoaded(p)
	{
		$.parser.parse(p);
		HistoryRoutePanel.init("hisDataGrid");
		
		var plateNo = VehicleTree.getSelectedPlateNo();
		HistoryRoutePanel.setPlateNo(plateNo);
	}
	
	function onMainTabClosed(title)
	{
	    if(title == '历史轨迹')
		{
		    HistoryRoutePanel.stopPlay();
		}
	}
	var tabId = 1;
	function addTab(title,href,icon){  
		var tt = $('#mainTab');  
		if (tt.tabs('exists', title)){//如果tab已经存在,则选中并刷新该tab          
			tt.tabs('select', title);  
			//refreshTab({tabTitle:title,url:href});  
			if(title == '历史轨迹')
			{
				var plateNo = VehicleTree.getSelectedPlateNo();
				HistoryRoutePanel.setPlateNo(plateNo);
			}
		} else {  
			if(title == '历史轨迹')
			{
				tt.tabs('add',{  
					title:title,  
					id:tabId,
					closable:true,  
					href:globalConfig.webPath+'/hisroute.html',
					//content:content,  
					iconCls:icon||'icon-default'  
				});  
				
					
			}else
			{
				if (href){  
					var content = '<iframe scrolling="auto" frameborder="0"  src="'+href+'" style="width:100%;height:100%;"></iframe>';  
				} else {  
					var content = '未实现';  
				}  
				tt.tabs('add',{  
					title:title,  
					id:tabId,
					closable:true,  
					content:content,  
					iconCls:icon||'icon-default'  
				});  
			}
		}  
    }  

	function refreshTab(cfg){  
		var refresh_tab = cfg.tabTitle?$('#mainTab').tabs('getTab',cfg.tabTitle):$('#mainTab').tabs('getSelected');  
		if(refresh_tab && refresh_tab.find('iframe').length > 0){  
			var _refresh_ifram = refresh_tab.find('iframe')[0];  
			var refresh_url = cfg.url?cfg.url:_refresh_ifram.src;  
			//_refresh_ifram.src = refresh_url;  
			_refresh_ifram.contentWindow.location.href=refresh_url;  
		}  
    } 

	function closeCommandWindow()
	{
		$('#commandWindow').window('close');
	}


	function openIFrameWindow(url, width, height,  title)
	{
		//$('#commandIframe')[0].src = "about:blank";
		//清空iframe的内容,避免缓存
		$('#commandIframe')[0].contentWindow.document.body.innerText = "";
		$('#commandIframe')[0].src=url;
					$('#commandWindow').dialog({    
						width:width,    
						height:height,    
						title:title,
			minimizable: false,
						modal:false   
					});  
		$('#commandWindow').window('open');
	}
	function openIFrameChildWindow(url, width, height,  title)
	{
		//$('#commandIframe')[0].src = "about:blank";
		//清空iframe的内容,避免缓存
		var childIframe = $('#childIframe');
		childIframe[0].contentWindow.document.body.innerText = "";
		childIframe[0].src=url;
	    $('#childWindow').dialog({    
						width:width,    
						height:height,    
						title:title,
			minimizable: false,
						modal:false   
					});  
		$('#childWindow').window('open');
	}


	/**
	 * 主窗口函数，主要是当子窗口的编辑窗口中数据保存后，
	 * 重新刷新Iframe子窗口中的页面中提供的refreshTable的刷新表格函数
	 */
	function refreshDataWindow()
	{ 
		var curTab = $('#mainTab').tabs('getSelected');
	    var tabId = curTab.id;
	    if(curTab && curTab.find('iframe').length > 0){  
			var iframeWindow = curTab.find('iframe')[0];  
			//调用子窗口的刷新表格函数 函数在表格分页js文件中,paginateUtil.js
			 if(iframeWindow && iframeWindow.contentWindow.refreshTable)
		          iframeWindow.contentWindow.refreshTable(); 

		}  

	}
 
function openRoutePlanWindow()
{
   $('#routePlanWindow').window('open');
}
	/**
  * 打开围栏设置窗口,在地图中画围栏或者线路时调用，弹出窗口，录入参数，保存。
  */
  var enclosureWindow;
function openRouteWindow(url, width, height, title, closeCallback)
{
		$('#commandIframe')[0].contentWindow.document.body.innerText = "";
		$('#commandIframe')[0].src=url;
		enclosureWindow = $('#commandWindow').window({    
						width:width,    
						height:height,    
						title:title,
						modal:false,
						onClose:function()
						{ 
							if(closeCallback)
								closeCallback();
						}
		});  
		$('#commandWindow').window('open');
}

//创建围栏
function createExtendEnclosure(ec, strPoints)
{
    $.messager.show({titile:"提示",msg:"保存成功!",timeout:2000,showType:'fade'});
	var id = ec.EntityId;
	 if(id > 0 && strPoints.length > 0)
	{
		 var curTab = $('#mainTab').tabs('getSelected');
	     var tabId = curTab.id;
	     if(curTab && curTab.find('iframe').length > 0){  
			var iframeWindow = curTab.find('iframe')[0];  
			 if(iframeWindow && iframeWindow.contentWindow.createExtendEnclosure)
			{
				 iframeWindow.contentWindow.createExtendEnclosure(strPoints, ec.Radius, id, ec.EnclosureType,ec.Name,  ec.CenterLat, ec.CenterLng);
			}
		}
	}
	 closeEnclosureWindow();		
}


function createPolyline(ec, strPoints)
{
	var id = ec.EntityId;
	 if(id > 0)
	{
		  var curTab = $('#mainTab').tabs('getSelected');
	     var tabId = curTab.id;
	     if(curTab && curTab.find('iframe').length > 0){  
			var iframeWindow = curTab.find('iframe')[0];  
			 if(iframeWindow && iframeWindow.contentWindow.createExtendPolyline)
			{
				 iframeWindow.contentWindow.createExtendPolyline(strPoints, id, ec.Name, ec.CenterLat, ec.CenterLng);
			}
		}

	   //window.frames['tab_map-frame'].createExtendPolyline(strPoints, id, ec.name, ec.centerLat, ec.centerLng);
	}
	
	 closeEnclosureWindow();	
}



function createKeyPoint(ec, strPoints)
{
	var id = ec.EntityId;
	 if(id > 0)
	{
         var curTab = $('#mainTab').tabs('getSelected');
	     var tabId = curTab.id;
	     if(curTab && curTab.find('iframe').length > 0){  
			var iframeWindow = curTab.find('iframe')[0];  
			 if(iframeWindow && iframeWindow.contentWindow.createExtendKeyPoint)
			{
	           iframeWindow.contentWindow.createExtendKeyPoint(ec.CenterLat, ec.CenterLng, ec.Raidus,  id, ec.Name);
			}
		 }
	}
	
	 closeEnclosureWindow();		
}
/**
 * 创建地标
 */
function createMarker(ec, strPoints)
{
	var id = ec.EntityId;
	 if(id > 0)
	{  var curTab = $('#mainTab').tabs('getSelected');
	     var tabId = curTab.id;
	     if(curTab && curTab.find('iframe').length > 0){  
			var iframeWindow = curTab.find('iframe')[0];  
			 if(iframeWindow && iframeWindow.contentWindow.createExtendKeyPoint)
			{
	            iframeWindow.contentWindow.createExtendMarker(ec.CenterLat, ec.CenterLng, ec.Radius,  id, ec.Name);
			}
		 }
	}
	
	 closeEnclosureWindow();		
}


//关闭区域设置窗口
function closeEnclosureWindow()
{
	 if(enclosureWindow)
			 enclosureWindow.window('close');
}

	
function renderTemplate(opt)
{	
	if(globalConfig.mapType != "baidu")
		return renderTemplate2(opt);
	if(opt.latitude)
	{
		var strLatitude = ""+opt.latitude;
		strLatitude = strLatitude.substring(0,9);
		opt.latitude = strLatitude;//opt.latitude.toFixed(6); 
	}
	if(opt.longitude)
	{
		var strLongitude = ""+opt.longitude;
		strLongitude = strLongitude.substring(0,9);
		opt.longitude = strLongitude;//opt.longitude.toFixed(6); 
	}
	if(opt.altitude)
	{
		var strAltitude = ""+opt.altitude;
		strAltitude = strAltitude.substring(0,6);
		opt.altitude = strAltitude;	
	}
	//调用模板引擎，将json数据填充到模板中，转成html
    var d = $("#infoWindowTemplateOutput").bindTemplate(
    {
        source : opt
      , template : $("#infoWindowTemplate")
    });  
	var html = d.html();// d.prop("outerHTML");//appendTo("#templateContent");
	// var html =$("#templateContent").html();
	return html;   
}


function renderTemplate2(opt)
{

	if(opt.latitude)
	{
		var strLatitude = ""+opt.latitude;
		strLatitude = strLatitude.substring(0,9);
		opt.latitude = strLatitude;//opt.latitude.toFixed(6); 
	}
	if(opt.longitude)
	{
		var strLongitude = ""+opt.longitude;
		strLongitude = strLongitude.substring(0,9);
		opt.longitude = strLongitude;//opt.longitude.toFixed(6); 
	}
	if(opt.altitude)
	{
		var strAltitude = ""+opt.altitude.toFixed(2);
		opt.altitude = strAltitude;	
	}
	 var d = $("#infoWindowTemplateOutput").bindTemplate(
    {
        source : opt
      , template : $("#infoWindowTemplate2")
    });  
		var html = d.html();
	 //var html = $("#realDataTemplate2").tmpl(opt).html();
	 //var html =$("#templateContent").html();
	return html;   
}

     //过滤树
     function doSearchTree(value){
		 var filterType =  $("#filterType").combobox('getValue');

		 if(filterType == "all")
		 {
			 $.messager.alert('提示','请选择过滤类型');
			 
		 }else
		 {
			 if(value == null || value.length == "")
			 {
				 $.messager.alert('提示','请输入过滤条件');
			 }
			 var params = {};
			 params[filterType] = value;
			 VehicleTree.filter(params);
		 }
            //alert('You input: ' + value);
     }

	 function hideRealDataTab()
	 {
		 $('#centerLayout').layout('collapse','south');
	 }

	
	 function onTabSelect(title)
	 {
		 //var pp = $('#realDataTab').tabs('options');
		 //alert(pp.height);
		 //var width =  $('#realDataTab').tabs('width');
		 //alert(width);
	 }

    //当历史轨迹标签调整尺寸时，调整标签页中的表格的高度和宽度
	 function onRouteTabResize(width, height)
	 {
		 if(isReady == false)
			 return;
		 //alert(width+','+height);
		 //$("#hisDataGrid").datagrid('resize',{width:width-10,height:height-2,left:2,top:2});

	 }

	 /**
	  * 当用户点击打开修改密码的按钮时，弹出修改密码的窗口
	  */
	 function openUpdatePasswordWindow()
	 {
		 InfoWindow.open(globalConfig.webPath + '/User.mvc/UpdatePassword?input=true',500,360,"修改用户密码");
	 }