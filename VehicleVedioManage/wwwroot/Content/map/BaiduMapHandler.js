
function BaiduMapHandler(_map,mapPath)
{
     this.map = _map;
	 this.gpsDataMap = {}; //保存当前的实时数据,以GpsRealData表的Id为主键

	 this.markerMap = {};//保存当前的实时marker,以GpsRealData表的Id为主键
	 this.areaMap = {};//保存当前的区域overlay和文本标注,已Enclosure围栏表的id为主键.
	 
	 this.showDepNameOnMap = false;//车辆标签文本中是否增加显示部门名称
	 //百度地图点聚合	 
	this.markerClusterer = new BMapLib.MarkerClusterer(this.map);
	 
	this.mapPath = mapPath;
	this._endIconImageUrl = this.mapPath +"/images/track/end.gif";//结束地点图标

	this.realDataMap = {};
	//轨迹中回放中的marker, 线等，便于批量清楚
	this.routeOverlays = new Array();
	
	this.directionOverlays = new Array();//存放历史轨迹中的剪头方向图标，便于隐藏或显示所有的剪头方向图标
	//限速点标记的map集合，便于删除线路的时候，同时删除线路上的限速点
	this.limitSpeedMarkerMap = {};

	this.showRouteBeforePlay = false; //历史轨迹回放前，先一次性画出完整轨迹，再回放.
	
	var zoom = this.map.getZoom();
	this.lastZoomValue = zoom;

	this.cityZoomValue = 12;//城市界下的zoom值

	this.provinceZoomValue = 8; //省界下的zoom值

}
/**
 * 将区域对象和对应的文本标注，保存在hash表中，便于调用和删除
 * @areaId, 围栏的主键Id
 */
BaiduMapHandler.prototype.cacheAreaOverlay = function(areaId, overlay, label)
{
	this.areaMap[areaId] = {overlay:overlay,label:label};
}
BaiduMapHandler.prototype.getAreaOverlay = function(areaId)
{
	return this.areaMap[areaId];
}

/**
 * 根据车速、方向、报警和上线状态来生成车辆地标
 */
BaiduMapHandler.prototype.getRecordImageUrl = function(direction, speed, online, alarm){
	if(!direction)
		direction = 0;
	var img = setAngleImage(direction);
	if(online)
	{
		if (typeof(alarm) != "undefined" && parseInt(alarm) != 0){
			return this.mapPath +"/images/alarm/" + img;
	    }else if(speed <= 1)
		{
		    return this.mapPath +"/images/direction/parking/" + img;

		}else			
			return this.mapPath +"/images/direction/" + img;

	}else
	{
		return this.mapPath +"/images/direction/off/" + img;
	}
	
}


/**
 * 根据坐标数组，一次性画出所有的轨迹
 */
BaiduMapHandler.prototype.drawHisRoute = function(records) {

    var length = records.length;
	var posArray = new Array();
	for(var m = 0; m < length; m++)
	{
	   var record = records[m];
	   var currentPos = new BMap.Point(record.longitude, record.latitude);
	   posArray.push(currentPos);

	   if(m == 0)
	   {
		   var iconPath = this.mapPath +"/images/track/start.gif";
		   var icon = this.createIcon(iconPath,39,25);
		   this.startMarker = this.addMarker(record.longitude, record.latitude,
						icon, record, false);
		   this.routeOverlays.push(this.startMarker);
		   
		   this._preLat = record.latitude;
		   this._preLng = record.longitude;
		   this._preRecord = record;

	   }else if(m == length - 1)
		{
		   var icon = this.createIcon(this._endIconImageUrl,39,25);
		   this.endMarker = this.addMarker(record.longitude, record.latitude,
						icon, record, false);
	       this.routeOverlays.push(this.endMarker);
		}
	}

	var line = this.createPolyline(posArray,"#ff3333",8,0.9);
	this.map.setViewport(posArray);
	//压入到轨迹层，便于一次性清除轨迹
	this.routeOverlays.push(line);

}


/**
 * 根据轨迹数据，画出轨迹线，轨迹点和移动的轨迹车图标. 这个方法适用于历史轨迹回放和单车实时轨迹监控两个功能方法
 * @record 轨迹数据
 * @displayInfoWindow 回放的时候，移动的小车是否一直显示信息窗口
 */
BaiduMapHandler.prototype.drawRoute = function(record, displayInfoWindow) {
				record = convertRecord(record);
				currentRecord = record;
				var courseLat =parseFloat(record.latitude);
				var courseLng = parseFloat(record.longitude);
 
				if (this.startMarker == null) {
					//画线
					if(this.showRouteBeforePlay == false)
					{
						var iconPath = this.mapPath +"/images/track/start.gif";
						var icon = this.createIcon(iconPath,39,25);
						this.startMarker = this.addMarker(record.longitude, record.latitude,
							icon, record, false);
						this.routeOverlays.push(this.startMarker);
					}
					
					this._preLat = record.latitude;
					this._preLng = record.longitude;
					this._preRecord = record;
					this.setCenter(record.latitude, record.longitude);
				} else {					
					// 这一次循环的时间
					var time = record.sendTime;					
					//var imageUrl = this.getRecordImageUrl(record.direction, record.velocity, true, record.alarm);
					var imageUrl = this.mapPath +"/images/arrow.png";
		            var currentPos = new BMap.Point(record.longitude, record.latitude);						
					if (this.courseMarker == null) {

						var icon = this.createIcon(imageUrl,32);
					   //var pt = currentPos;
					   //var myIcon = new BMap.Icon(iconPath, new BMap.Size(16,16));
					   var marker = new BMap.Marker(currentPos,{icon:icon});  // 创建标注
					   this.map.addOverlay(marker);              // 将标注添加到地图中   
						var me = this;
						this.courseMarker = marker;
						//this.courseMarker.removeEventListener("click");
						this.courseMarker.addEventListener("click", this.openDetailHtmlWindow);		
						if(displayInfoWindow == true)
						{
							var htmlContent = window.parent.renderTemplate(record);	
							var markerInfoWindow = new BMap.InfoWindow(htmlContent);
							this.courseMarker.openInfoWindow(markerInfoWindow);
						}
						
					    this.routeOverlays.push(this.courseMarker);
					} else {						
						this.courseMarker.setPosition(currentPos );				
			            var newIcon = this.createIcon(imageUrl, 32);
			            this.courseMarker.setIcon(newIcon);//需要重新更新车辆图标，因为车辆的方向，报警状态可能有变化
						//this.courseMarker.removeEventListener("click");
						var me = this;
						var marker = this.courseMarker;
						if(displayInfoWindow == true)
						{
							var htmlContent = window.parent.renderTemplate(record);	
							var markerInfoWindow = new BMap.InfoWindow(htmlContent);
							this.courseMarker.openInfoWindow(markerInfoWindow);
						}
						
					}
					this.courseMarker.setRotation(record.direction);
					if(this.hisCarLabel)
					{
			           this.map.removeOverlay(this.hisCarLabel);		
					}
					var descr = record.plateNo +",车速:"+record.velocity + "km/h,时间:"+record.sendTime;
		            this.hisCarLabel = this.createMarkerLabel(record.vehicleId, record.latitude, record.longitude, descr,32);
					if (this.isInMapBound(record.longitude, record.latitude) == false) {
							this.setCenter(record.latitude, record.longitude);
					}

					// 绘制前一点的图标
					var currentMarker;
					
		            var prePos = new BMap.Point(this._preLng, this._preLat);
					var distance = this.map.getDistance(prePos, currentPos);
					if(distance > 0)
					{
						if(this._preLng > 0 && this._preLat > 0)
						{
						    var tempImageUrl = this.mapPath +"/images/track/direction.png";	
							if(record.alarmState > 0 || parseInt(record.alarm) > 0)
							{
								//有报警
							    tempImageUrl = this.mapPath +"/images/track/alarm.png";	
							}else if(record.velocity == 0)
							{
							    tempImageUrl = this.mapPath +"/images/track/parking.jpg";	
							}
							var icon = this.createIcon(tempImageUrl);
							var directionMarker = this.addMarker(record.longitude, record.latitude,
								 icon, record, false);
					        directionMarker.setRotation(record.direction);
							//压入到轨迹层，便于一次性清除轨迹
							this.routeOverlays.push(directionMarker);
							this.directionOverlays.push(directionMarker);
							
	                        var zoom = this.map.getZoom();
	                        var isHide = zoom <= 14;
							if(isHide)
								directionMarker.hide();
						
						//画线
						//if(this.showRouteBeforePlay == false)
						//{	
						    var line = this.createPolyline([prePos,
							currentPos],"#0080c0",2,1);
						   //压入到轨迹层，便于一次性清除轨迹
					       this.routeOverlays.push(line);
						//}
						}
					    this._preLat = record.latitude;
					    this._preLng = record.longitude;
					    this._preRecord = record;
					}
				}
}

//**************************************************************带数据表格的轨迹绘制
BaiduMapHandler.prototype.drawRoute2 = function(record) {
				record = convertRecord(record);
				var courseLat =parseFloat(record.latitude);
				var courseLng = parseFloat(record.longitude);
 
				if (this.startMarker == null) {
					var iconPath = this.mapPath +"/images/track/start.gif";
					var icon = this.createIcon(iconPath,39,25);
					this.startMarker = this.addMarker(record.longitude, record.latitude,
						icon, record, false);
					this.routeOverlays.push(this.startMarker);
					
					this._preLat = record.latitude;
					this._preLng = record.longitude;
					this._preRecord = record;
				} else {					
					// 这一次循环的时间
					var time = record.sendTime;
					
					var imageUrl = this.getRecordImageUrl(record.direction, record.speed, true, record.alarm);
					
		            var currentPos = new BMap.Point(record.longitude, record.latitude);
					if (this.courseMarker == null) {
						var icon = this.createIcon(imageUrl,32);
						this.courseMarker = this.addMarker(record.longitude, record.latitude,
							 icon, record, false);
						
					    this.routeOverlays.push(this.courseMarker);
						this.setCenter(record.latitude, record.longitude);
					} else {						
						this.courseMarker.setPosition(currentPos );
						
					}
					if(this.hisCarLabel)
					{
			           this.map.removeOverlay(this.hisCarLabel);		
					}
					var descr = record.plateNo +",车速:"+record.velocity + "km/h,时间:"+record.sendTime;
		            this.hisCarLabel = this.createMarkerLabel(record.vehicleId, record.latitude, record.longitude, descr,32);
					if (this.isInMapBound(currentPos) == false) {
							this.setCenter(record.latitude, record.longitude);
					}

					// 绘制前一点的图标
					var currentMarker;
					
		            var prePos = new BMap.Point(this._preLng, this._preLat);
					var distance = this.map.getDistance(prePos, currentPos);
					if(distance > 20)
					{
						
						var tempImageUrl = this.mapPath +"/images/toolbar/point.png";	
						var icon = this.createIcon(tempImageUrl);
						var directionMarker = this.addMarker(record.longitude, record.latitude,
							 icon, record, false);
						//压入到轨迹层，便于一次性清除轨迹
					    this.routeOverlays.push(directionMarker);
						//画线
						var line = this.createPolyline([prePos,
							currentPos]);
					    this._preLat = record.latitude;
					    this._preLng = record.longitude;
					    this._preRecord = record;
						//压入到轨迹层，便于一次性清除轨迹
					    this.routeOverlays.push(line);
					}
					//if (this._nCount > 1) {
					//}

					
					
					
				}
}



/**
 * 停止轨迹播放
 */
BaiduMapHandler.prototype.drawStop = function() {
	if (this.courseMarker == null){
		return ;
	}
	//画线
	if(this.showRouteBeforePlay == false)
	{
	   var icon = this.createIcon(this._endIconImageUrl,39,25);
	   this.endMarker = this.addMarker(this.courseMarker.getPosition().lng, this.courseMarker.getPosition().lat, icon);
	   this.routeOverlays.push(this.endMarker);
	}
	//this.map.removeOverlay(this.courseMarker);
	this.startMarker = null;
	this.courseMarker = null;
}

/**
 * 清楚所有的元素
 */
BaiduMapHandler.prototype.clearAllElement = function() {
	if(this.hisCarLabel)
	{
		this.map.removeOverlay(this.hisCarLabel);		
	}
	this.startMarker = null;
	this.courseMarker = null;

	//清楚轨迹中的地标
     for(var m = 0; m < this.routeOverlays.length; m++)
	{
		 var overlay = this.routeOverlays[m];
		 this.map.removeOverlay(overlay);//清除地图marker
	}
	routeOverlays = [];//清空数组
}


/**
 * 清楚所有的车辆元素
 */
BaiduMapHandler.prototype.clearAllVehicle = function() {
	for(var m in this.realDataMap)
	{
		var rd = this.realDataMap[m];
		this.map.removeOverlay(rd.marker);		
		this.map.removeOverlay(rd.label);	
	}
	this.realDataMap = {};
	
	if(this.markerClusterer !=null )
	   this.markerClusterer.clearMarkers();
}

/**
 * 清除百度地图聚合
 */
BaiduMapHandler.prototype.clearMarkerCluster = function() {
	for(var m in this.realDataMap)
	{
		var rd = this.realDataMap[m];
		this.map.removeOverlay(rd.marker);		
		this.map.removeOverlay(rd.label);	
	}
	this.realDataMap = {};
	if(this.markerClusterer !=null )
	   this.markerClusterer.clearMarkers();
}

//清除历史轨迹中生成的地图对象
BaiduMapHandler.prototype.clearHisRoute = function() {
	if(this.hisCarLabel)
	{
		this.map.removeOverlay(this.hisCarLabel);		
	}
	this.startMarker = null;
	this.courseMarker = null;

	//清楚轨迹中的地标
     for(var m = 0; m < this.routeOverlays.length; m++)
	{
		 var overlay = this.routeOverlays[m];
		 this.map.removeOverlay(overlay);//清除地图marker
	}
	routeOverlays = [];//清空数组
}

/**
  * 根据id删除电子围栏
  */
BaiduMapHandler.prototype.removeMapArea = function(areaId)
{
      var area = this.areaMap[areaId];
	  if(area)
	{
		  this.map.removeOverlay(area.overlay);
		  this.map.removeOverlay(area.label);
	}
	var markerArray = this.limitSpeedMarkerMap[areaId];
	if(markerArray != null)
	{
		for(var m = 0; m < markerArray.length; m++)
		{
			var marker = markerArray[m];
			this.map.removeOverlay(marker);
		}
	}
}

BaiduMapHandler.prototype.setCenter = function(lat, lng,zoom)
{    
	if(!zoom)
		zoom = this.map.getZoom();
	this.map.centerAndZoom(new BMap.Point(lng, lat), zoom);
}


BaiduMapHandler.prototype.addMarkers = function(gpsRealDataList,isCluster)
{	
	this.markerClusterer.clearMarkers();
	var me = this;
	var markers = [];
	var start = new Date();
	$.each(gpsRealDataList,function(index,v){  
	     if(isCluster || me.isInMapBound(v.longitude, v.latitude))
		 {			 
		    if(v.longitude > 60 && v.latitude > 20)
		   {
			 var marker = me.centerMarkerOverlays(v,false,false, isCluster);
			 if(marker != null && isCluster)
	            markers.push(marker);
		   }
		 }
	}); 
	if(isCluster && markers.length > 0)
	{
		me.markerClusterer.addMarkers(markers);
	    var end = new Date();
	    var interval = 0.001 * (end - start) ;
        //if(console)
	        //console.log("地图聚合条数"+gpsRealDataList.length+"条数,耗时:"+ interval+"秒");
	}
}

BaiduMapHandler.prototype.showVehicleList = function(gpsRealDataList, changeViewPoint,onlyUpdate)
{

	var zoom = this.map.getZoom();
	//console.log("当前zoom:"+ zoom + ",上次zoom:"+ this.lastZoomValue);
    var start1 = new Date();
	var me = this;
	if(changeViewPoint == true)
	{
		var points = [];  // 添加海量点数据
			for (var i = 0; i < gpsRealDataList.length; i++) {
				var d = gpsRealDataList[i];
				if(d.longitude > 60 && d.latitude > 20)
				    points.push(new BMap.Point(d.longitude, d.latitude));
			}
		this.map.setViewport(points);　		
	}
	
	//var rm = parent.RealDataGrid.realDataList;
	var zoom = this.map.getZoom();

	if(zoom <= this.provinceZoomValue)
	{
		if(this.lastZoomValue <= this.provinceZoomValue && !changeViewPoint)
		{
		    //聚合没有变化，不需要动作;
		}else
		{
			//加入聚合
			 //this.clearVehiclePoints();
			this.clearAllVehicle();
			this.addMarkers(gpsRealDataList,true);
		}
	}
	/** else if(zoom <= this.cityZoomValue)
	{
		if(this.lastZoomValue > this.provinceZoomValue && this.lastZoomValue <= this.cityZoomValue && !changeViewPoint)
		{
			//显示点没有变化，不需要动作
		}else
		{
			this.clearAllVehicle();
			this.showAllVehicleAsPoints(gpsRealDataList);
		}
	}*/else
	{
		if(onlyUpdate != true)
		   this.clearAllVehicle();
		this.addMarkers(gpsRealDataList, false);
		//this.clearVehiclePoints();

		if(this.lastZoomValue > this.cityZoomValue && !changeViewPoint)
		{
			//显示点没有变化，不需要动作
		}else
		{			
			
			
		}

	}
	this.lastZoomValue = zoom;
	
	var end1 = new Date();
	var interval1 = 0.001 * (end1 - start1) ;
	//if(console)
		//console.log("更新地图车辆地标"+gpsRealDataList.length+"条数,耗时:"+ interval1+"秒");
}

/**
 * 批量在地图上显示gps车辆地标
 * @gpsDataArray页面传送的gps数据，可以同时显示多个地标，所以是数组
 * @isOpenInfoWindow 是否打开信息窗口
 */
BaiduMapHandler.prototype.showMarkers=function(gpsDataArray, isOpenInfoWindow)
{
	 for (var i = 0; i < gpsDataArray.length; i++) {
		 var gpsData = gpsDataArray[i];
		 if(gpsData.longitude < 1 || gpsData.latitude < 1)
			 continue;

		 var currentPos = new BMap.Point(gpsData.longitude, gpsData.latitude);
		 //在地图边界外的不进行刷新
		 //if(this.isInMapBound(currentPos) == false)
			// continue;
		 var oldRealDataMarker = this.realDataMap[gpsData.vehicleId];
		  var descr = gpsData.plateNo+"["+ gpsData.depName+"]";
		  if(gpsData.online)
		{
		 if(gpsData.speed == 0)
			 descr += "停车中";
		 else
			 descr += "车速:"+gpsData.speed + "km/h";
		}else
			descr += "离线中";
		 if(oldRealDataMarker != null)
		{			 
			 //this.map.removeOverlay(oldRealDataMarker.marker);			
			 //this.map.removeOverlay(oldRealDataMarker.label);		
			 oldRealDataMarker.marker.setPosition(currentPos);	 
			 var iconPath = this.getRecordImageUrl(gpsData.direction, gpsData.speed,
				 gpsData.online,gpsData.alarmState);
			 var icon = this.createIcon(iconPath, 32);
			 oldRealDataMarker.marker.setIcon(icon);
			 //oldRealDataMarker.marker.getIcon().setImageUrl(iconPath);
			 oldRealDataMarker.label.setPosition(currentPos);
			 oldRealDataMarker.label.setContent(descr);
			 oldRealDataMarker.gpsData = gpsData;
		}else
		 {
		
			 var iconPath = this.getRecordImageUrl(gpsData.direction, gpsData.speed, gpsData.online,gpsData.alarmState);
			 var icon = this.createIcon(iconPath, 32);
			// isOpenInfoWindow = false;
			 var marker = this.addRealDataMarker(gpsData.longitude, gpsData.latitude, icon, gpsData, isOpenInfoWindow);
			
			 var label = this.createMarkerLabel(gpsData.vehicleId, gpsData.latitude, gpsData.longitude, descr,32);
			 this.realDataMap[gpsData.vehicleId] = {marker:marker, label:label, gpsData:gpsData};
			
		 //if(isCenter)
		    //this.setCenter(gpsData.latitude, gpsData.longitude);
		 }
		 //this.addGoogleMarker(marker);
	}
}

/**
 * 批量在地图上显示gps车辆地标
 * @gpsDataArray页面传送的gps数据，可以同时显示多个地标，所以是数组
 * @isOpenInfoWindow 是否打开信息窗口
 */
BaiduMapHandler.prototype.centerMarkerOverlays=function(gpsData, isOpenInfoWindow,isCenter,isCluster)
{
	 var zoom = this.map.getZoom();
		 if(gpsData.longitude < 1 || gpsData.latitude < 1)
			 return null;
		 var oldRealDataMarker = this.realDataMap[gpsData.vehicleId];
		  var descr = gpsData.plateNo;
		 if(this.showDepNameOnMap)
		 {
			 descr += "["+ gpsData.depName+"]";
		 }
		  if(gpsData.online)
		{
			  if(gpsData.velocity == 0)
			     descr += "停车中";
		      else
			     descr += "车速:"+gpsData.velocity + "km/h";
		}else
			descr += "离线中";
		var marker = null;
		 if(oldRealDataMarker != null)
		{
			 marker = oldRealDataMarker.marker;
			 var iconPath = this.getRecordImageUrl(gpsData.direction, gpsData.velocity,
				 gpsData.online,gpsData.alarmState);
			 var icon = this.createIcon(iconPath, 32);
			 oldRealDataMarker.marker.setIcon(icon);	
		     var currentPos = new BMap.Point(gpsData.longitude, gpsData.latitude);
			 //this.map.removeOverlay(oldRealDataMarker.marker);			
			 //this.map.removeOverlay(oldRealDataMarker.label);		
			 oldRealDataMarker.marker.setPosition(currentPos);			 
			 var label =  marker.getLabel();
			 if(label == null && !isCluster)
			{
				 label = this.createMarkerLabel(gpsData.vehicleId, gpsData.latitude, gpsData.longitude, descr,80);
			     marker.setLabel(label);
				 oldRealDataMarker.label = label;
				 this.map.addOverlay(marker);
			 }
			 //label.setPosition(currentPos);
			 if(label != null)
			   label.setContent(descr);
			 oldRealDataMarker.gpsData = gpsData;
			  if(isOpenInfoWindow)
			 {
				 var platformAlarm = window.parent.AlarmGrid.alarmMap[gpsData.plateNo];
				 if(platformAlarm != null)
				 {					 
			        if(gpsData.alarmStateDescr  == "无")
				      gpsData.alarmStateDescr  = "";
				  if(gpsData.alarmStateDescr == null || gpsData.alarmStateDescr.indexOf(platformAlarm) < 0)
				     gpsData.alarmStateDescr = gpsData.alarmStateDescr + "  "+ platformAlarm;
				 }
	              var htmlContent = window.parent.renderTemplate(gpsData);
				  var markerInfoWindow = new BMap.InfoWindow(htmlContent);
				  oldRealDataMarker.marker.openInfoWindow(markerInfoWindow);
			 }


		}else
		 {
		
			 var iconPath = this.getRecordImageUrl(gpsData.direction, gpsData.velocity, gpsData.online,gpsData.alarmState);
			 var icon = this.createIcon(iconPath, 32);
			// isOpenInfoWindow = false;
			  marker = this.addRealDataMarker(gpsData.longitude, gpsData.latitude, icon, gpsData, isOpenInfoWindow, isCluster);
			 if(!isCluster)
			 {
			     var label = this.createMarkerLabel(gpsData.vehicleId, gpsData.latitude, gpsData.longitude, descr,80);
			     marker.setLabel(label);
			 }
			 this.realDataMap[gpsData.vehicleId] = {marker:marker, label:label, gpsData:gpsData};
		  
		 }

			var label =  marker.getLabel();
         if(isCenter)
		 {
			 zoom = zoom <= this.cityZoomValue ? (this.cityZoomValue +1) : zoom;
		     this.setCenter(gpsData.latitude, gpsData.longitude, zoom);
		 }
		 
		 if(zoom <= this.cityZoomValue)
		 { 
			 if(label != null)
			 {
			     label.setStyle({  display:"none" });
			 }

			
			 //marker.hide();
			 if(zoom <= this.provinceZoomValue)
			 {
				//marker.show();
				
			 }else
			 {
				 //marker.hide();
			
			 }
		 }else
		 {
		     marker.show();
			 if(label != null)
			 {
			     label.setStyle({  display:"block" });
			 }

		 }
		 
		 return marker;
}

BaiduMapHandler.prototype.planDriveRoute = function(startPOI, endPOI)
{
	var driving = new BMap.DrivingRoute(this.map, {renderOptions: {map: this.map, panel: "r-result", autoViewport: true}});
	driving.search(startPOI,  endPOI);

}

BaiduMapHandler.prototype.createLocalSearch = function(onSearchResult)
{
	var me = this;
	var options = {
		onSearchComplete: function(results){
			// 判断状态是否正确
			if (search.getStatus() == BMAP_STATUS_SUCCESS){
				var poiList = [];
				for (var i = 0; i < results.getCurrentNumPois(); i ++){
					var poi = results.getPoi(i);
					var name = poi.title + ", " + results.getPoi(i).address;
					var code = i;
					poiList.push({result:name,value:poi.address,data:poi});
				}
				onSearchResult(me.keyword,poiList);
			}
		}
	   };
	var search = new BMap.LocalSearch('大连市', options);
	return search;
}

BaiduMapHandler.prototype.createVehicleMarker = function(bmPoint, bIcon, opt,isOpenInfoWindow)
{
   var marker = new BMap.Marker(bmPoint,{icon:bIcon});  // 创建标注
   map.addOverlay(marker);              // 将标注添加到地图中   
   var htmlContent = window.parent.renderTemplate(opt);
   var markerInfoWindow = new BMap.InfoWindow(htmlContent);
   marker.addEventListener("click", function(){
        this.openInfoWindow(markerInfoWindow);
   });
   if(isOpenInfoWindow)
	{
        marker.openInfoWindow(markerInfoWindow);
	}
	return marker;
}

BaiduMapHandler.prototype.createLimitSpeedPointMarkerById = function(routeId,id, lat, lng, title,
		icon, clickCallback)
{
		 this.removeMapArea("seg_"+id);
	 var pt = new BMap.Point(lng, lat);
				//var icon = "images/track/point.png";
				var myIcon = new BMap.Icon(icon, new BMap.Size(15,15));
				var tempMarker = new BMap.Marker(pt,{icon:myIcon});  // 创建标注
				map.addOverlay(tempMarker);              // 将标注添加到地图中  

	  var markerArray = this.limitSpeedMarkerMap[routeId];
		if(markerArray == null)
		{
			markerArray = new Array();
			this.limitSpeedMarkerMap[routeId] = markerArray;
		}
		markerArray.push(tempMarker);
/**
				tempMarker.addEventListener("click", function(){
				   //弹出编辑窗口
				   var url = globalConfig.webPath + "/mapArea/viewLimitSpeedPoint.action?latitude="+lat+"&longitude="+ lng+"&routeId="+routeId+"&entityId="+id;			 
						 //parent.openRouteWindow(url, 690,280,"分段限速");
				    $.getJSON(url, params, function(result)
					{
						if(result.success)
						{

						}
					});
			    });

         */      
		var label = OperatorObj.createLabel(id, lat, lng, title);
		tempMarker.setLabel(label);
		this.cacheAreaOverlay("seg_"+id, tempMarker,label);
		return tempMarker;
}



BaiduMapHandler.prototype.createIcon = function(iconPath, width, height)
{
	//默认是16*16
	if(!width)
		width=16;
	if(!height)
		height = width;
	return new BMap.Icon(iconPath, new BMap.Size(width, height));
}

BaiduMapHandler.prototype.openInfoWindow = function(vehicleId)
{
	var realData = this.realDataMap[vehicleId];
	if(realData)
	{
		var opt = realData.gpsData;
		var plateformAlarm = window.parent.AlarmGrid.alarmMap[opt.plateNo];
		if(plateformAlarm != null)
		{
			if(opt.alarmStateDescr  == "无")
				opt.alarmStateDescr  = "";
			if(opt.alarmStateDescr == null || opt.alarmStateDescr.indexOf(plateformAlarm) < 0)
			{
		        opt.alarmStateDescr = opt.alarmStateDescr + " " + plateformAlarm;
			}
		}
		var htmlContent = window.parent.renderTemplate(opt);
	    var markerInfoWindow = new BMap.InfoWindow(htmlContent);
		realData.marker.openInfoWindow(markerInfoWindow);
	}
}

BaiduMapHandler.prototype.openHtmlWindow = function(marker,htmlContent)
{
	  var markerInfoWindow = new BMap.InfoWindow(htmlContent);
	  marker.openInfoWindow(markerInfoWindow);
}

BaiduMapHandler.prototype.getGpsInfoWindow = function(vehicleId)
{
	var url = globalConfig.webPath + "/RealData.mvc/ViewRealData?vehicleId="+vehicleId;
	var html = '<div style="width:550px;height:200px;"><iframe scrolling="no" id="infoIframe" frameborder="0"  src="'+ url + '" style="width:100%;height:99%;"></iframe></div>';
	var markerInfoWindow = new BMap.InfoWindow(html);

	return markerInfoWindow;

}


BaiduMapHandler.prototype.addMarker = function(lng, lat, icon, opt,isOpenInfoWindow)
{
   var pt = new BMap.Point(lng, lat);
   //var myIcon = new BMap.Icon(iconPath, new BMap.Size(16,16));
   var marker = new BMap.Marker(pt,{icon:icon});  // 创建标注
   this.map.addOverlay(marker);              // 将标注添加到地图中   
   if(opt)
	{
	   var vehicleId = opt.vehicleId;
       var me = this;
	   var htmlContent = window.parent.renderTemplate(opt);
	   marker.addEventListener("click", function(){
			//me.openInfoWindow(vehicleId);
			//me.openHtmlWindow(marker,htmlContent);
	        var markerInfoWindow = new BMap.InfoWindow(htmlContent);
			marker.openInfoWindow(markerInfoWindow);
	   });
	   if(isOpenInfoWindow)
	   {
	        var markerInfoWindow = new BMap.InfoWindow(htmlContent);
			marker.openInfoWindow(markerInfoWindow);
	   }
	}
	return marker;
}


BaiduMapHandler.prototype.addRealDataMarker = function(lng, lat, icon, opt,isOpenInfoWindow,isCluster)
{
   var pt = new BMap.Point(lng, lat);
   //var myIcon = new BMap.Icon(iconPath, new BMap.Size(16,16));
   var marker = new BMap.Marker(pt,{icon:icon});  // 创建标注
   if(isCluster != true)
      this.map.addOverlay(marker);              // 将标注添加到地图中   
   if(opt)
	{
	   var vehicleId = opt.vehicleId;
       var me = this;
	   marker.addEventListener("click", function(){
			//me.openInfoWindow(vehicleId);
			//me.openHtmlWindow(marker,htmlContent);
	       //var markerInfoWindow = me.getGpsInfoWindow(opt.vehicleId);
		   //marker.openInfoWindow(markerInfoWindow);
		   me.openInfoWindow(vehicleId);
	   });
	   if(isOpenInfoWindow)
	   {
	       var htmlContent = window.parent.renderTemplate(opt);
	        var markerInfoWindow = new BMap.InfoWindow(htmlContent);
			marker.openInfoWindow(markerInfoWindow);
	   }
	}
	return marker;
}


BaiduMapHandler.prototype.createMarker = function(lng, lat, iconPath, opt,isOpenInfoWindow)
{
   var pt = new BMap.Point(lng, lat);
   var myIcon = this.createIcon(iconPath);
   var marker = new BMap.Marker(pt,{icon:myIcon});  // 创建标注
   //map.addOverlay(marker);              // 将标注添加到地图中   
   var htmlContent = window.parent.renderTemplate(opt);
   var markerInfoWindow = new BMap.InfoWindow(htmlContent);
   marker.addEventListener("click", function(){
        this.openInfoWindow(markerInfoWindow);
   });
   if(isOpenInfoWindow)
	{
        marker.openInfoWindow(markerInfoWindow);
	}
	return marker;
}
BaiduMapHandler.prototype.createPolyline=function(points)
{
        var polyline = new BMap.Polyline(points, 
			{strokeColor:"blue", strokeWeight:2, strokeOpacity:0.5});
        this.map.addOverlay(polyline);
		return polyline;
}
/**
 * 判断点是否在地图边界中
 */
BaiduMapHandler.prototype.isInMapBound=function(bmPoint)
{
        var bounds = this.map.getBounds(); 
		return bounds.containsPoint(bmPoint);
}


BaiduMapHandler.prototype.isInMapBound=function(lng,lat)
{
   var bmPoint = new BMap.Point(lng, lat);
        var bounds = this.map.getBounds(); 
		return bounds.containsPoint(bmPoint);
}

/**
  * 创建标注
  */
BaiduMapHandler.prototype.createLabel=function(id, lat, lng, text, offsetY)
{
	if(!offsetY)
		offsetY = -10;
	var offsetX = -10 * text.length / 2;
	//alert(offsetX);
   var point = new BMap.Point(lng, lat);
	var opts = {
	  position : point,    // 指定文本标注所在的地理位置
	  offset   : new BMap.Size(offsetX, 16)    //设置文本偏移量
	}
	var label = new BMap.Label(text, opts);  // 创建文本标注对象
	label.setStyle({
			 color : "blue",
			 fontSize : "12px",
			 height : "20px",
			 border:0,
			 background:"transparent",
			 lineHeight : "20px",
			 fontFamily:"微软雅黑"
		 });
	map.addOverlay(label);
	return label;
}
String.prototype.width = function(font) {  
        var f = font || '12px 微软雅黑',  
        o = $('<div>' + this + '</div>')  
            .css({'position': 'absolute', 'float': 'left', 'white-space': 'nowrap', 'visibility': 'hidden', 'font': f})  
            .appendTo($('body')),  
        w = o.width();  
  
        o.remove();  
        return w;  
    }  

var textWidthMap = {};
BaiduMapHandler.prototype.createMarkerLabel=function(id, lat, lng, text, offsetY)
{
	if(!offsetY)
		offsetY = -20;
	//var offsetX = -10 * text.length / 2;
   //
   var len = text.length;
   var textWidth = textWidthMap[len] ;
   if(textWidth== null)
   {
	   textWidth = text.width();
	   textWidthMap[len] = textWidth;
	   //console.log("text width:"+ text.width());
   }else
	{
	   //console.log("缓存命中,text width:"+ textWidth);
	}

   var offsetX = -1 * textWidth / 2 + 8+2;
	//alert(offsetX);
   var point = new BMap.Point(lng, lat);
	var opts = {
	  position : point,    // 指定文本标注所在的地理位置
	  offset   : new BMap.Size(offsetX, 32)    //设置文本偏移量
	}
	var label = new BMap.Label(text, opts);  // 创建文本标注对象
	label.setStyle({
			 color : "blue",
			 fontSize : "12px",
			 height : "20px",
			 border:0,
			 background:"rgba(0, 0, 0, 0)",
			 lineHeight : "20px",
			 fontFamily:"微软雅黑"
		 });
	//map.addOverlay(label);
	return label;
}
/**
 * 根据地图的zoom值，决定是否显示历史轨迹的方向图标
 */
BaiduMapHandler.prototype.hideDirectionMarkerByZoom = function () {
    var zoom = this.map.getZoom();
    var isHide = zoom <= 14;

    $.each(this.directionOverlays, function (i, overlay) {
        if (overlay instanceof BMap.Marker) {
            if (isHide)
                overlay.hide();
            else
                overlay.show();
        }
    });
}
/**
 *单独监控的时候，不断的刷新最新的位置图标
 */
BaiduMapHandler.prototype.createMarkerOverlayTrackMode = function(
		targetInfo) {
	//try {
		var currentPos = new BMap.Point(targetInfo.rLng,targetInfo.rLat);
		//过滤无效的日期时间
		//if (parseInt(targetInfo.gpsTime.split(" ")[0].split("-")[0]) < this._defaultYearFilter)
			//return;
		var operatorObj = this;
		// 创建标记
		var vehicleDirectionImagUrl = this.mapPath+"/images/direction/"
								+ setAngleImage(targetInfo.angleInt);        
		//var currentGpsTimeMill = parseDate(targetInfo.gpsTime).getTime();

		// 绑定标记
		// this._handler.bindClickEvent(targetInfo.marker, targetInfo, this.bindClickEventHTML);
		/**
		this._handler.bindClickEvent(targetInfo.marker, targetInfo, function(opts){
			return that.bindClickEventHTML(opts);
		},function() {
			operatorObj._handler.getAddress(targetInfo.id, targetInfo.rLat, targetInfo.rLng);
		});
		*/	
		var gpsDataId = targetInfo.plateNo;
		var marker = this.markerMap[gpsDataId];
		var gpsData = this.gpsDataMap[gpsDataId];
		if (!marker) {
            var vehicleIcon = new BMap.Icon(vehicleDirectionImagUrl, new BMap.Size(32,32));
			marker = this.createVehicleMarker(currentPos,
				vehicleIcon, targetInfo,false);

			this.markerMap[gpsDataId] = marker;
			this.setCenter(targetInfo.rLat,targetInfo.rLng,16);
			this.markerMap[gpsDataId] = marker;
		} else {
			marker.setPosition(currentPos);//更新车辆的当前位置
			var directionImagUrl =  this.mapPath+"/images/toolbar/point.png";
			var icon = this.createIcon(directionImagUrl);
			var directionMarker = this.addMarker(gpsData.rLng,gpsData.rLat,
				icon, gpsData,false);
			var prePos = new BMap.Point(gpsData.rLng,gpsData.rLat);
			var distance = this.map.getDistance(prePos, currentPos);
			var points = new Array();
			points[0] = prePos;
			points[1] = currentPos;
		    this.createPolyline(points);
				/**
				if(distance < 20)
				{
					operatorObj._handler
					.removeOverlay(preTargetInfo.marker); //清楚掉前面的marker,避免密集显示图标
					//return;
				}else
				{
			        preTargetInfo.marker.setIconImage(this._currentImageUrl); 
				}*/
		}
		if (this.isInMapBound(currentPos) == false) {
				this.setCenter(targetInfo.rLat,targetInfo.rLng);
		}
		 this.gpsDataMap[gpsDataId] = targetInfo;
	//} catch (e) {
		
	//}
}
