<%@ include file="/common/taglibs.jsp"%>

<%@ page language="java" pageEncoding="UTF-8"%>
<%
   String ApplicationPath = request.getContextPath() ;
   String jsPath = ApplicationPath+"/js";
   String imgPath =  ApplicationPath+"/image";
   String mapPath = ApplicationPath+"/map";
   String hisRoute = request.getParameter("hisRoute");
%>
<script>
//全局的javascript配置
	var globalConfig = {webPath:"<%=ApplicationPath%>"}
</script>
<html>
<head>

<meta http-equiv="Expires" content="0" />  
<meta http-equiv="Cache-Control" content="no-cache, no-store" /> 
<meta http-equiv="Pragma" content="no-cache" />
<meta http-equiv="X-UA-Compatible" content="IE=8" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link rel="stylesheet" href="toolkit.css" type="text/css" />
<link rel="stylesheet" href="<%=ApplicationPath%>/css/FormTable.css" type="text/css" />
<script type="text/javascript" src="js/public/util.js"></script>    
<script type="text/javascript" src="<%=jsPath%>/jquery/jquery1.8.min.js"></script>
<!--<script type="text/javascript" src="<%=jsPath%>/linebuffer.js"></script>-->
<script type="text/javascript" src="<%=mapPath%>/js/public/placeList.js"></script>
<script type="text/javascript" src="<%=mapPath%>/js/public/component/CityLocation.js"></script>
<%@ include file="/common/taglibs.jsp"%>
<!-- 

<script type="text/javascript" src="<%=mapPath%>/js/adapter/smart-earth-adapter.js?v=1"></script>
<script type="text/javascript" src="<%=mapPath%>/js/public/component/toolbar.js"></script>
<script type="text/javascript" src="<%=mapPath%>/js/public/component/smart-earth/tools.js"></script>
<script type="text/javascript" src="http://engine.gis.cttic.cn/engine?v=2.0&ser=SE_JSAPI2&uid=jlsygj"></script> 
<script type="text/javascript" src="http://app.smartearth.cn/lib?service=true&ser=SE_JSAPI2&uid=jlsygj"></script>
-->
<script type="text/javascript" src="http://a.map.icttic.cn:81/SE_JSAPI?v=tr&uid=${systemConfig.smartKey}"></script>
<script type="text/javascript" src="http://a.map.icttic.cn:81/SE_JSLIB?service=true&uid=${systemConfig.smartKey}"></script> 


<script type="text/javascript" src="<%=mapPath%>/SmartMapHandler.js?v=8"></script>
<script type="text/javascript" src="<%=ApplicationPath%>/js/InfoWindow.js"></script>

    <link rel="stylesheet" href="css/gh-buttons.css">

<title></title>
<style type="text/css"> 
<!--
body {
	margin-left: 0px;
	margin-top: 0px;
	margin-right: 0px;
	margin-bottom: 0px;
	overflow: hidden;
}
-->

.datatable
{
	font-size:12px;
	display:hidden;
}
.button
{
	display:none;
}

.td_realdata
{
	color:blue;
}

#mapDiv1 {
   padding:10px;
   padding-bottom:60px;   /* Height of the footer */
}

#footer1 {
   position:absolute;
   bottom:0;
   width:100%;
   height:60px;   /* Height of the footer */
   background:#6cf;
}
</style>
</head>
<body onload="init();">

<div style="position:absolute;right:1px;top:1px;z-index:999">
<ul class="button-group">
    <li><a href="#" class="button" id="routePlanTool" title="路线导航"><img src="images/toolbar/nav.png" /></a></li>
    <li><a href="#" class="button" id="panelTool" title="拖动地图"><img src="images/toolbar/hand.gif" /></a></li>
    <li><a href="#" class="button" id="rectZoomoutTool" title="矩形缩小"><img src="images/toolbar/zoomout.gif" /></a></li>
    <li><a href="#" class="button" id="rectZoominTool" title="矩形放大"><img src="images/toolbar/zoomin.gif" /></a></li>
    <li><a href="#" class="button" id="measureTool" title="测距"><img src="images/toolbar/measure.png" /></a></li>
    <li><a href="#" class="button" id="rectQueryTool" title="矩形查车"><img src="images/toolbar/rectQuery.png" /></a></li>
    <li><a href="#" class="button" id="markerTool" title="标注"><img src="images/toolbar/marker.png" /></a></li>
    <li><a href="#" class="button" id="rectTool" title="矩形区域"><img src="images/toolbar/rect.png" /></a></li>
    <li><a href="#" class="button" id="circleTool" title="圆形区域"><img src="images/toolbar/circle.png" /></a></li>
    <li><a href="#" class="button" id="polygonTool" title="多边形区域"><img src="images/toolbar/polygon.png" /></a></li>
    <li><a href="#" class="button" id="polylineTool" title="线路"><img src="images/toolbar/polyline.png" /></a></li>
    <li><a href="#" class="button" id="keyPointTool" title="关键点"><img src="images/toolbar/keypoint.png" /></a></li>
	<li>
	<a href="#" class="button" id="limitSpeedTool" title="分段限速"><img src="images/toolbar/showAll.png" /></a></li>
	<li>
	<a href="#" class="button" id="saveTool" title="保存中心兴趣点"><img src="images/toolbar/point.png" /></a></li>
	<li>
	
	<a href="#" class="button" id="clearTool" title="清除所有"><img src="images/toolbar/clear.gif" /></a></li>
	
</ul>
</div>


<table class="datatable" >
     <tr>
        <td>车牌号:</td><td><span id="plateNo" class="td_realdata"></span></td>
        <td>Sim卡号:</td><td><span id="simNo" class="td_realdata"></span></td>
        <td>车牌颜色:</td><td><span id="plateColor" class="td_realdata"></span></td>
        <td>GPS时间:</td><td><span id="sendTime" class="td_realdata"></span></td>
        <td>车速:</td><td><span id="velocity" class="td_realdata"></span>km/h</td>
       
	</tr>
	<tr>
        <td>里程:</td><td><span id="mileage" class="td_realdata"></span>km</td>
        <td>油量:</td><td><span id="gas" class="td_realdata"></span>升</td>
		 <td>方向:</td><td><span id="directionDescr" class="td_realdata"></span></td>
        <td>海拔:</td><td><span id="altitude" class="td_realdata"></span></td>
        <td>脉冲速度:</td><td><span id="recorderVelocity" class="td_realdata">km/h</span></td>
	 </tr><tr>
	    <td>状态:</td><td colspan="5"><span id="status" class="td_realdata"></span></td>
	    <td>报警:</td><td colspan="5"><span id="alarmStateDescr" class="td_realdata"></span></td>
		<!--
        <td>经度:</td><td><span id="latitude" class="td_realdata"></span></td>
        <td>纬度:</td><td><span id="longitude" class="td_realdata"></span></td>
		-->
	 </tr>

</table>
<div id="mapDiv" style="width: 100%; height: 100%;;overflow: hidden;margin:0;"></div> 
<div  id="footer">

</div>
<%
	    String vehicleId = request.getParameter("vehicleId");
		String tracking = request.getParameter("tracking");
		if(vehicleId == null)
		    vehicleId= "";
	%>


	<script type="text/javascript">
	var vehicleId = "<%=vehicleId%>";
    var hisRoute = "<%=hisRoute%>";//定时顶点轨迹查询
	if(vehicleId.length > 0)
	{
		$(".datatable").show();
	}else
		$(".datatable").hide();
	    
    //加载用户的围栏
	function loadMapAreas()
	{
		var params = {};
		 $.getJSON( "<%=ApplicationPath%>/map/mapAreaList.action", params, 
						function(result){		
			                if(result.success)
						 {
								
								var data = result.data;
								var areas = data.areas;//地图区域、线路和标注点
								var limitSpeedPoints = data.limitSpeedPoints;//分段限速点
								//逐一创建围栏
								$.each(areas, function(i, item){
									if(item.areaType == "route" )
									{									

										createExtendPolyline(item.points, item.entityId, item.name, item.centerLat, item.centerLng);
									}
									else if(item.areaType == "marker")
									{
										createExtendMarker(item.centerLat, item.centerLng, item.raidus,  item.entityId, item.name,item.icon);
									}else if(item.keyPoint == 1)
									{
										createExtendKeyPoint(item.centerLat, item.centerLng, item.raidus,  item.entityId, item.name);
									}else
									{
	                                    createExtendMapArea(item.points, item.radius, item.entityId, item.areaType, item.name, item.centerLat, item.centerLng);
									}
									if(item.centerLat > 0 && item.centerLng >0)
									{
										//创建标签
										//OperatorObj.createLabel(item.entityId, item.centerLat, item.centerLng, item.name);
									}
								});
							//创建限速点
								$.each(limitSpeedPoints, function(i, seg){
									  createLimitSpeedPoint(seg.routeId,seg.entityId,seg.name,
						 seg.latitude1,seg.longitude1);

									});

						 }
		               }
				);


	}
	
	var OperatorObj,map;
	var enId = 0;
	function createExtendPolyline(strPoints, id,name, centerLat, centerLng)
	{
	    OperatorObj.removeMapArea(id);
	    if(strPoints)
				strPoints = strPoints.replace(/;/g,"#");  //替换字符串中的;为#，转换为地图所需要的格式
		else
			return; //没有节点，直接返回，无法画线路
		
		var polyline = OperatorObj.createPolylineById(strPoints, id, function(id,pt)
		{
			if(OperatorObj.toolId == "keyPointTool")
			{
				onDrawKeyPoint(pt);//点击线路时，如果选择的是关键点，则会在线路上画出关键点
			}
			else if(OperatorObj.toolId == "limitSpeedTool")
			{
                //如果选择的是分段限速点，则会在线路上画出分段限速点
				var lat = pt.lat > 1000 ? (pt.lat / 100000) : pt.lat;
				var lng = pt.lng > 1000 ? (pt.lng / 100000) : pt.lng;
				var url = globalConfig.webPath + "/map/saveLimitSpeedPoint.action?latitude1="+ lat+"&longitude1="+ lng+"&routeId="+id;		
				var params = {}
				$.getJSON(url, params,function(result)
				{
					if(result.success)
					{
						var seg = result.data;
					   createLimitSpeedPoint(seg.routeId,seg.entityId,seg.name,
						 seg.latitude1,seg.longitude1);
					}else
					{
						alert("创建失败,发生错误:"+result.message);
						//关闭窗口时的回调函数
						//OperatorObj.removeOverlay(tempMarker); //关闭窗口时，擦掉画图的图元
					}
				});

				return;
			}else
			{

			 var url = globalConfig.webPath + "/map/viewRoute.action?EntityID="+ id;
			 // InfoWindow.open(url, 680, 490);
			 parent.openRouteWindow(url, 720,490,"路线编辑");
			}
		});
		
		var label = OperatorObj.createLabel(id, centerLat, centerLng, name);
		

	}

	/**
	 * 根据数据库记录,创建关键点,绑定点击事件，点击时，打开窗口，显示关键点信息
	 */
	function createExtendKeyPoint(lat, lng, radius, id, keyPointName)
	{
	    OperatorObj.removeMapArea(id);
		var icon = "images/track/keyPoint48.png";
		var mapArea = OperatorObj.createKeyPointMarkerById(id,  lat, lng, keyPointName, icon, function(id)
		{
			//关键点点击事件
			 var url = globalConfig.webPath + "/map/viewKeyPoint.action?EntityID="+ id;
			 // InfoWindow.open(url, 680, 490);
			 parent.openRouteWindow(url, 650,390,"关键点区域设置");
		});
		var label = OperatorObj.createLabel(id, lat, lng, keyPointName);
		
	}

	/**
	 * 创建限速点
	 * routeId:线路id
	 * id:限速点主键id
	 * ptName：限速点名称
	 */
	function createLimitSpeedPoint(routeId, id, ptName, lat,lng)
	{
	    OperatorObj.removeMapArea("seg_"+id);
		var icon = "images/track/point.png";
		var mapArea = OperatorObj.createLimitSpeedPointMarkerById(routeId,id,  lat, lng, ptName, icon, function(id)
		{
				   //弹出编辑窗口
		     //var url = globalConfig.webPath + "/map/viewLimitSpeedPoint.action?latitude="+lat+"&longitude="+ lng+"&routeId="+routeId+"&EntityID="+id;			 
						// parent.openRouteWindow(url, 690,280,"分段限速");
		});         // 将标注添加到地图中  
               
		//OperatorObj.cacheAreaOverlay("seg_"+id, tempMarker,label);
		//return tempMarker;

	}

		/**
	 * 根据数据库记录,创建地图标注,绑定点击事件，点击时，打开窗口，显示标注点信息
	 */
	function createExtendMarker(lat, lng, radius, id, name,iconName)
	{
	    OperatorObj.removeMapArea(id);
		var icon = "MapIcon/"+iconName;
		var mapArea = OperatorObj.createKeyPointMarkerById(id,  lat, lng, name, icon, function(id)
		{
			//点击地图标注后，弹出编辑窗口
			 var url = globalConfig.webPath + "/map/viewMarker.action?EntityID="+ id;
			parent.openRouteWindow(url, 660,290,"地标设置");
		});
		var label = OperatorObj.createLabel(id, lat, lng, name);
		
	}




	function createExtendMapArea(strPoints, radius, id, areaType,name,centerLat, centerLng)
	{		
	    OperatorObj.removeMapArea(id);
			if(strPoints)
				strPoints = strPoints.replace(/;/g,"#");  //替换字符串中的;为#，转换为地图所需要的格式
			//alert(strPoints);
		var mapArea = OperatorObj.createMapAreaById(strPoints, radius, id,  areaType, function(id)
		{
			 var url = globalConfig.webPath + "/map/viewArea.action?EntityID="+ id;
			 // InfoWindow.open(url, 680, 490);
			 parent.openRouteWindow(url, 720,405,"区域设置");
		});	
		
		var label = OperatorObj.createLabel(id, centerLat, centerLng, name);

	}

		var mapCenterLat;
		var mapCenterLng;
		var mapZoom;
    //设置地图中心
	function onConfigCenter(centerLat,  centerLng, zoom)
	{
		if(centerLat == mapCenterLat && centerLng == mapCenterLng && zoom == mapZoom)
		{
				return;//已经设置过了
		}
		mapCenterLat = centerLat;
		mapCenterLng = centerLng;
		mapZoom = zoom;

		centerLat = centerLat / 100000;
		centerLng = centerLng / 100000;
		var postData = {lat:centerLat, lng:centerLng, zoom:zoom};
		var url =globalConfig.webPath +  "/user/setMapCenter.action";
		$.getJSON(url, postData, function(result){
				 alert(result.message);
		});
	}

	function onDrawCircle(c)
	{
		var points = c.getCenter();  
		var radius = c.getRadius();
		var strPoints = OperatorObj.pointToString(points, true);
		//如果是历史轨迹页面，则区域工具栏画图后，将进行区域内的历史轨迹的查询
		if(hisRoute == "true")
					{
						//按定时定位车辆查询
						//var startTime = parent.HistoryRoutePanel.getStartTime();
						//var endTime = parent.HistoryRoutePanel.getEndTime();
						//矩形查询车辆
						 var url = globalConfig.webPath + "/vehicle/viewVehicleInAreaAndTime.action?areaType=circle&strRoutePoints="+ strPoints+"&radius="+ radius;	
						  parent.openRouteWindow(url, 720,390,"定时定位车辆查询", function()
							{
								   OperatorObj.removeOverlay(c); //关闭窗口时，擦掉画图的图元
							});
						  
						  return;
					}

		 var url = globalConfig.webPath + "/map/viewArea.action?areaType=circle&strRoutePoints="+ strPoints+"&radius="+radius;			 
			 parent.openRouteWindow(url, 720,390,"圆形区域编辑", function()
			{
				   reset();
				   OperatorObj.removeOverlay(c); //关闭窗口时，擦掉画图的图元
			});
	}

	/**
	 * 画多边形触发
	 */
	function onDrawPolygon(points,length, polygonObj)
	{
		var strPoints = OperatorObj.pointToString(points, true);
		if(strPoints)
				strPoints = strPoints.replace(/#/g,";");  //替换字符串中的#为;，防止URL post参数被截断
		//如果是历史轨迹页面，则区域工具栏画图后，将进行区域内的历史轨迹的查询
		if(hisRoute == "true")
		{
			//按定时定位车辆查询
			//var startTime = Utility.;
			//var endTime = parent.HistoryRoutePanel.getEndTime();
						//矩形查询车辆
			var url = globalConfig.webPath + "/vehicle/viewVehicleInAreaAndTime.action?areaType=polygon&strRoutePoints="+ strPoints;	
			parent.openRouteWindow(url, 720,390,"定时定位车辆查询", function()
				{
								   OperatorObj.removeOverlay(polygonObj); //关闭窗口时，擦掉画图的图元
				});
						  
			return;
		}
			//console.log(strPoints);
			 var url = globalConfig.webPath + "/map/viewArea.action?areaType=polygon&strRoutePoints="+ strPoints;			 
			 parent.openRouteWindow(url, 720,390,"多边形区域编辑", function()
			{
				 //关闭窗口时的回调函数
				   OperatorObj.removeOverlay(polygonObj); //关闭窗口时，擦掉画图的图元
				   reset();
			});

	}

	function onDrawPolyline(points,length, polyline)
	{
		var strPoints = OperatorObj.pointToString(points, false);
		if(strPoints)
				strPoints = strPoints.replace(/#/g,";");  //替换字符串中的#为;，防止URL post参数被截断
			 var url = globalConfig.webPath + "/map/viewRoute.action?strRoutePoints="+ strPoints;
			 parent.openRouteWindow(url, 720,490,"路线编辑" ,function()
			{
				   OperatorObj.removeOverlay(polyline); //关闭窗口时，擦掉画图的图元
				   reset();
			});

	}

	//关键点画图事件
	function onDrawKeyPoint(point)
	{
		var strPoints = OperatorObj.pointToString(point, true);
			 var url = globalConfig.webPath + "/map/viewKeyPoint.action?areaType=circle&strRoutePoints="+ strPoints+"&radius="+100;			 
			 parent.openRouteWindow(url, 660,390,"关键点编辑", function()
			{
				   reset();
				   //OperatorObj.removeOverlay(circleObj); //关闭窗口时，擦掉画图的图元
			});

	}

	function onDrawMarker(point)
	{
		var strPoints = OperatorObj.pointToString(point, true);
		 //标注
						 var url = globalConfig.webPath + "/map/viewMarker.action?areaType=marker&strRoutePoints="+ strPoints+"&radius="+100;			 
						 parent.openRouteWindow(url, 670,290,"标注点编辑", function()
						{
							 reset();
							   //map.removeOverlay(e.overlay); //关闭窗口时，擦掉画图的图元
						});
	}



	   /**  
        * 绘制矩形电子围栏 
        */  
        function onDrawRectArea(bounds,rectObj){     
            var xy = OperatorObj.getBoundsMiniMax(bounds);
			var Xmin = xy.xMin;
			var Ymin = xy.yMin;
			var Xmax = xy.xMax;
			var Ymax = xy.yMax;
			var points = [
							OperatorObj.createPoint(Ymax , Xmin ), 
							OperatorObj.createPoint(Ymax , Xmax ), 
							OperatorObj.createPoint(Ymin , Xmax ), 
							OperatorObj.createPoint(Ymin , Xmin )
						]
			var strPoints = OperatorObj.pointToString(points, true);
			if(strPoints)
				strPoints = strPoints.replace(/#/g,";");  //替换字符串中的#为;，防止URL post参数被截断
			//如果是历史轨迹页面，则区域工具栏画图后，将进行区域内的历史轨迹的查询
		if(hisRoute == "true")
		{
			//按定时定位车辆查询
			//var startTime = parent.HistoryRoutePanel.getStartTime();
			//var endTime = parent.HistoryRoutePanel.getEndTime();
						//矩形查询车辆
			var url = globalConfig.webPath + "/vehicle/viewVehicleInAreaAndTime.action?areaType=rect&strRoutePoints="+ strPoints;	
			parent.openRouteWindow(url, 720,390,"定时定位车辆查询", function()
				{
								   OperatorObj.removeOverlay(rectObj); //关闭窗口时，擦掉画图的图元
				});
						  
			return;
		}

			//console.log(strPoints);
			 var url = globalConfig.webPath + "/map/viewArea.action?areaType=rect&strRoutePoints="+ strPoints;			 
			 parent.openRouteWindow(url, 720,390,"多边形区域编辑", function()
			{
				 //关闭窗口时的回调函数
				   OperatorObj.removeOverlay(rectObj); //关闭窗口时，擦掉画图的图元
				   reset();
			});

        }   

	   /**  
        * 绘制矩形查车  
        */  
        function onDrawRectQuery(bounds,rectObj){     
            var xy = OperatorObj.getBoundsMiniMax(bounds);
			var Xmin = xy.xMin;
			var Ymin = xy.yMin;
			var Xmax = xy.xMax;
			var Ymax = xy.yMax;
			var points = [
							OperatorObj.createPoint(Ymax , Xmin ), 
							OperatorObj.createPoint(Ymax , Xmax ), 
							OperatorObj.createPoint(Ymin , Xmax ), 
							OperatorObj.createPoint(Ymin , Xmin )
						]
			var strPoints = OperatorObj.pointToString(points, true);
			if(strPoints)
				strPoints = strPoints.replace(/#/g,";");  //替换字符串中的#为;，防止URL post参数被截断
			//console.log(strPoints + ",bounds:"+ bounds);
			 var url = globalConfig.webPath + "/vehicle/viewVehicleInArea.action?areaType=rect&strRoutePoints="+ strPoints;			 
			 parent.openRouteWindow(url, 720,420,"区域查车", function()
			{
				 //关闭窗口时的回调函数
				 reset();
				   OperatorObj.removeOverlay(rectObj); //关闭窗口时，擦掉画图的图元
			});

        }   

	function reset()
	{
		if(OperatorObj.tool != null)
				OperatorObj.tool.close();
	}
	function init(){
			/**
		 * mapTool工具栏
		 */
		var mapToolMenu = ${MapToolMenu}; //将session中的菜单数据的java集合对象转换成json菜单对象
		for(var m in mapToolMenu)
		{
			var mapTool = mapToolMenu[m];
			$("#"+mapTool.funcName).show(); //根据权限显示工具栏
		}

		var args = {};
		var tools = null;
        var userInfo = ${onlineUserInfo};//用户设置的地图中心
	    OperatorObj = new MapOperationHandler("mapDiv", userInfo.mapCenterLat, userInfo.mapCenterLng, userInfo.mapLevel);
	    OperatorObj.mapOverlayInit();
		OperatorObj.setDefaultTrackNodeCount(100);
		  	if (document.addEventListener) {
				document.addEventListener('DOMMouseScroll', mousewheel, false);
			}

			document.onmousewheel = mousewheel;

		$("#rectZoomoutTool").click(function(){
			reset();
			OperatorObj.toolId = this.id;
			OperatorObj.tool = new SE.ZoomInTool(OperatorObj.getMap(), {zoomAdd:-1});
			OperatorObj.tool.open();
		});

		$("#rectZoominTool").click(function(){
			reset();
			OperatorObj.toolId = this.id;
			OperatorObj.tool = new SE.ZoomInTool(OperatorObj.getMap());
			OperatorObj.tool.open();
		});
			//拖动地图
		$("#panelTool").click(function(){
			reset();
			OperatorObj.toolId = this.id;
			if(OperatorObj.tool)
				OperatorObj.tool.close();
		});

		$("#measureTool").click(function(){
			OperatorObj.toolId = this.id;
			reset();
			OperatorObj.tool = new SE.PolyLineTool(OperatorObj.getMap()); 
			OperatorObj.tool.open();
		});

		
		$("#rectQueryTool").click(function(){
			reset();
			OperatorObj.toolId = this.id;
			OperatorObj.tool = new SE.RectTool(OperatorObj.getMap());     
            SE.Event.bind(OperatorObj.tool,"draw",OperatorObj.getMap(),onDrawRectQuery);  
			OperatorObj.tool.open();

		});
		$("#rectTool").click(function(){	
			reset();
			OperatorObj.tool = new SE.RectTool(OperatorObj.getMap());  
			OperatorObj.toolId = this.id;
            SE.Event.bind(OperatorObj.tool,"draw",OperatorObj.getMap(),onDrawRectArea);  
			OperatorObj.tool.open();
		});
		
		$("#polylineTool").click(function(){
			reset();
			OperatorObj.toolId = this.id; 
			OperatorObj.tool = new SE.PolyLineTool(OperatorObj.getMap(),{showLabel : false});
            SE.Event.bind(OperatorObj.tool,"draw",OperatorObj.getMap(),onDrawPolyline);  
			OperatorObj.tool.open();
		});

		$("#polygonTool").click(function(){
			reset();
			OperatorObj.toolId = this.id; 
			OperatorObj.tool = new SE.PolygonTool(OperatorObj.getMap(),{showLabel : false});
            SE.Event.bind(OperatorObj.tool,"draw",OperatorObj.getMap(),onDrawPolygon);  
			OperatorObj.tool.open();
		});

		$("#circleTool").click(function(){
			reset();
			OperatorObj.toolId = this.id; 
			OperatorObj.tool = new SE.CircleTool(OperatorObj.getMap());
            SE.Event.bind(OperatorObj.tool,"drawend",OperatorObj.getMap(),onDrawCircle);  
			OperatorObj.tool.open();
		});
		//地图标注
		$("#markerTool").click(function(){
			reset();
			OperatorObj.toolId = this.id; 
			OperatorObj.tool = new SE.MarkTool(OperatorObj.getMap());
            SE.Event.bind(OperatorObj.tool,"mouseup",OperatorObj.getMap(),onDrawMarker);  
			OperatorObj.tool.open();
		});
		//地图标注
		$("#limitSpeedTool").click(function(){
			reset();
			OperatorObj.mapTool = this.id;
			OperatorObj.toolId = this.id; 
		});

		//关键点标注
		$("#keyPointTool").click(function(){
			reset();
			OperatorObj.toolId = this.id; 
		});

		
		//保存地图兴趣点
		$("#saveTool").click(function(){
			OperatorObj.configCenterPoint(onConfigCenter);
		});
		$("#clearTool").click(function(){
			OperatorObj.clearAllVehicle();
		});


		loadMapAreas(); //加载电子围栏到地图上
		
			if(vehicleId.length >0)
			{
				refreshRealData();//开始显示
		         setInterval("refreshRealData()", 10000);
			}
	}
	
    var realDataMap = {};
	//获取实时数据
	function refreshRealData()
	{
	     $.ajax({
				 url: '<%=ApplicationPath%>/vehicle/refreshRealData.action',
					 type: 'POST',					
					 data: {vehicleId: vehicleId},
					 datatype: "json",
				 	 timeout: 45000,//超时时间45秒
					 success: function(msg){
						 if(msg.success)
						 {
							 var newRd = msg.data;
							 var oldRd = realDataMap[newRd.ID];
							 refreshGrid(newRd); //填充表格数据
							 if(oldRd )
							 {
								 if((oldRd.latitude == newRd.latitude
								   && oldRd.longitude == newRd.longitude) || oldRd.sendTime == newRd.sendTime)
								 return;
							 }
							 realDataMap[newRd.ID] = newRd;
							 var gpsData = convertRecord(msg.data);
							 OperatorObj.drawRoute(gpsData);
						 }
					 },
				 	error: function()
				 	{
				 		//alert("网络错误!");
				 	}
		});

	}

	function refreshGrid(rd)
	{
		$(".td_realdata").each(function()
		{
			  var id = $(this).attr("id");
			  var data = rd[id];
			  $(this).html(data);
		});

	}

	function convertRecord(rd)
	 {
		  var vehicleInfo = {id:rd.ID, text:rd.plateNo, vehicleId:rd.ID, rLat:rd.latitude,rLng:rd.longitude, tLat:rd.latitude, tLng:rd.longitude,status:rd.status,color:rd.plateColor,validate:rd.valid,direction:rd.direction,gpsTime:('2014-'+rd.sendTime),
								  angleInt:rd.direction, statusInt:0, speed:rd.velocity, warnTypeId:0, online:rd.online};

	 rd.orgLatitude = parseFloat(rd.orgLatitude).toFixed(6);
	 rd.orgLongitude = parseFloat(rd.orgLongitude).toFixed(6);
	 rd.gas = parseFloat(rd.gas).toFixed(1);
	 rd.mileage = parseFloat(rd.mileage).toFixed(1);
		  vehicleInfo = $.extend(rd, vehicleInfo);
		  return vehicleInfo;

	 }
  	
  	function mousewheel(event) {
		event = event || window.event;
		var flag = ((event.ctrlKey || event.CONTROL_MASK) && (event.wheelDelta || event.detail))
		if (typeof (flag) != "undefined" && flag != null) {
			if (document.all) {
				event.returnValue = false;
			} else {
				event.preventDefault();
			}
		}
	}
  </script>

</body>
</html>