/**
 * 高德地图
 */
function AMapHandler(_map,mapPath)
{
	 this.showDepNameOnMap = false;//车辆标签文本中是否增加显示部门名称
     this.map = _map;
	 this.gpsDataMap = {}; //保存当前的实时数据,以GpsRealData表的Id为主键

	 this.markerMap = {};//保存当前的实时marker,以GpsRealData表的Id为主键
	 this.areaMap = {};//保存当前的区域overlay和文本标注,已Enclosure围栏表的id为主键.
	 
	 
	this.mapPath = mapPath;
	this._endIconImageUrl = this.mapPath+"/images/track/end.gif";//结束地点图标

	this.vehicleIconType = "car";//分为图标分为车辆和图标两种类型
	this.realDataMap = {};
	//轨迹中回放中的marker, 线等，便于批量清楚
	this.routeOverlays = new Array();
	this.showRouteBeforePlay = false;
	this.labelOffset = new AMap.Pixel(-20, 33);
	this.showDepNameOnMap = true;
	this.markerClusterer = new AMap.MarkerClusterer(this.map, [],{gridSize:60});
	
	this.directionOverlays = new Array();//存放历史轨迹中的剪头方向图标，便于隐藏或显示所有的剪头方向图标
	this.cityZoomValue = 10;//城市界下的zoom值
	this.provinceZoomValue = 8; //省界下的zoom值

	var zoom = this.map.getZoom();
	this.lastZoomValue = zoom;
	this.colors = [
        '#000000',
        '#33ff00',
        '#0000ff'
    ];
	this.stokeColors = [
        'red',
        '#66ff66',
        '#33ccff'
    ];

	var me = this;
	AMapUI.load(['ui/misc/PointSimplifier', 'lib/$'], function(PointSimplifier, $) {

        if (!PointSimplifier.supportCanvas) {
            alert('当前环境不支持 Canvas！');
            return;
        }

       me.pointCollection = new PointSimplifier({
            map: map, //所属的地图实例 
			autoSetFitView:false,
            getHoverTitle: function(dataItem, idx) {
                var descr = me.getGpsDataDescr(dataItem);
				return descr;
            },
			getPosition: function(dataItem) {
				//返回数据项的经纬度，AMap.LngLat实例或者经纬度数组
				//return dataItem;				
                return [dataItem.longitude, dataItem.latitude];
            },
              //使用GroupStyleRender
            renderConstructor: PointSimplifier.Render.Canvas.GroupStyleRender,
            renderOptions: {
                //点的样式
                pointStyle: {
                    fillStyle: 'red',
                    width: 16,
                    height: 16
                },
                getGroupId: function(item, idx) {
					var groupId = 0;
					if(item.online )
					{
						 if(item.velocity > 0)
							 groupId = 1;
						 else
							 groupId = 2;
					}
                    return groupId;
                },
                groupStyleOptions: function(gid) {

                    var size = 16;

                    return {
                        pointStyle: {
                            //content: gid % 2 ? 'circle' : 'rect',
                            fillStyle: me.colors[gid],
                            width: size,
                            height: size
                        },
                        pointHardcoreStyle: {
                            width: size - 6,
                            height: size - 6,
							fillStyle:"black"
                        }
                    };
                }
			}
        });
		 me.pointCollection.on('pointClick', function(e, record) {
			var gpsData = record.data;
	        var currentPos = new AMap.LngLat(gpsData.longitude, gpsData.latitude);
            var markerInfoWindow = me.getGpsInfoWindow(gpsData.vehicleId);
		    markerInfoWindow.open(me.map, currentPos);
        });

		
	});


}
/**
 * 将区域对象和对应的文本标注，保存在hash表中，便于调用和删除
 * @enclosureId, 围栏的主键Id
 */
AMapHandler.prototype.cacheAreaOverlay = function(enclosureId, overlay, label)
{
	this.areaMap[enclosureId] = {overlay:overlay,label:label};
}
AMapHandler.prototype.getAreaOverlay = function(enclosureId)
{
	return this.areaMap[enclosureId];
}

/**
 * 根据车速、方向、报警和上线状态来生成车辆地标
 */
AMapHandler.prototype.getRecordImageUrl = function(direction, speed, online, alarm){
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
AMapHandler.prototype.drawHisRoute = function(records) {

    var length = records.length;
	var posArray = new Array();
	for(var m = 0; m < length; m++)
	{
	   var record = records[m];
	   var currentPos = new AMap.LngLat(record.longitude, record.latitude);
	   posArray.push(currentPos);

	   if(m == 0)
	   {
		   var iconPath = this.mapPath +"/images/track/start.gif";
		   var icon = this.createIcon(iconPath,39,25);
		   this.startMarker = this.addMarker(record.longitude, record.latitude,
						icon, record, false);
		   this.routeOverlays.push(this.startMarker);
	   }else if(m == length - 1)
		{
		   var icon = this.createIcon(this._endIconImageUrl,39,25);
		   this.endMarker = this.addMarker(record.longitude, record.latitude,
						icon, record, false);
	       this.routeOverlays.push(this.endMarker);
		}
	}

	var line = this.createPolyline(posArray);
	this.map.setFitView([line]);
	//压入到轨迹层，便于一次性清除轨迹
	this.routeOverlays.push(line);

}

var currentRecord = null;
AMapHandler.prototype.openDetailHtmlWindow = function(tag) {
	
          var htmlContent = window.parent.renderTemplate(currentRecord);	
		  
		var windowOptions = {content:htmlContent,isCustom:false,closeWhenClickMap:true, offset:new AMap.Pixel(12,-16)};
	      var markerInfoWindow = new AMap.InfoWindow(windowOptions);
		 // this.openInfoWindow(tag.target, htmlContent);
		 var marker = tag.target;
		  markerInfoWindow.open(marker.getMap(), marker.getPosition());
   
}

/**
 * 根据地图的zoom值，决定是否显示历史轨迹的方向图标
 */
AMapHandler.prototype.hideDirectionMarkerByZoom = function()
{
	var zoom = this.map.getZoom();
	var isHide = zoom <= 14;
	
	$.each(this.directionOverlays,function(i,overlay)
	{
			if(isHide)
			  overlay.hide();
			else
			  overlay.show();
	});
}


//**************************************************************带数据表格的轨迹绘制
AMapHandler.prototype.drawRoute = function(record, displayInfoWindow) {
				record = convertRecord(record);
				currentRecord = record;
				var courseLat =parseFloat(record.latitude);
				var courseLng = parseFloat(record.longitude);
				var time = record.sendTime;					
				//var imageUrl = this.getRecordImageUrl(record.direction, record.velocity, true, record.alarm);
					
				var imageUrl = this.mapPath +"/images/arrow.png";
				var descr = record.plateNo +",车速:"+record.velocity + "km/h,时间:"+record.sendTime;
		        var currentPos = new AMap.LngLat(record.longitude, record.latitude);	
 
				if (this.courseMarker == null) {
					//画线
					if(this.showRouteBeforePlay == false && this.startMarker == null)
					{
						var iconPath = this.mapPath +"/images/track/start.gif";
						var icon = this.createIcon(iconPath,39,25);
						this.startMarker = this.addMarker(record.longitude, record.latitude,
							icon, record, false);
						this.routeOverlays.push(this.startMarker);
					}

					var icon = this.createIcon(imageUrl,32);
					   //var pt = currentPos;
					   //var myIcon = new AMap.Icon(iconPath, new AMap.Size(16,16));
		            //var label = {content:descr, offset: this.labelOffset};
                    var marker = new AMap.Marker({map:map, position:currentPos, icon:icon});  // 创建标注
					   //var marker = new AMap.Marker(currentPos,{icon:icon});  // 创建标注
					   //this.map.addOverlay(marker);              // 将标注添加到地图中   
				    var me = this;
						this.courseMarker = marker;
						//this.courseMarker.removeEventListener("click");
						this.courseMarker.on("click", this.openDetailHtmlWindow);		
						if(displayInfoWindow == true)
						{
							var htmlContent = window.parent.renderTemplate(record);	
							this.openHtmlWindow(this.courseMarker, htmlContent);
						}
						
					    this.routeOverlays.push(this.courseMarker);

					
					this.courseMarker.setAngle(record.direction);
					this._preLat = record.latitude;
					this._preLng = record.longitude;
					this._preRecord = record;
					this.setCenter(record.latitude, record.longitude);
				} else {							
					this.courseMarker.setPosition(currentPos );		
					this.courseMarker.setAngle(record.direction);
					//this.courseMarker.setLabel({content:descr, offset:this.labelOffset} );				
			        var newIcon = this.createIcon(imageUrl, 32);
			        this.courseMarker.setIcon(newIcon);//需要重新更新车辆图标，因为车辆的方向，报警状态可能有变化
						//this.courseMarker.removeEventListener("click");
				    var me = this;
					var marker = this.courseMarker;
					if(displayInfoWindow == true)
						{
							var htmlContent = window.parent.renderTemplate(record);	
							this.openHtmlWindow(this.courseMarker, htmlContent);
						}
					
		            //this.hisCarLabel = this.createMarkerLabel(record.vehicleId, record.latitude, record.longitude, descr,32);
					if (this.isInMapBound(record.longitude, record.latitude) == false) {
							this.setCenter(record.latitude, record.longitude);
					}

					// 绘制前一点的图标
					var currentMarker;
					
		            var prePos = new AMap.LngLat(this._preLng, this._preLat);
					var distance = this.getDistance(prePos, currentPos);
					if(distance > 0)
					{						
						    var tempImageUrl = this.mapPath + "/images/track/direction.png";	
							if(record.alarmStateDescr && record.alarmStateDescr.length > 0)
							{
								//有报警
							    tempImageUrl = this.mapPath + "/images/track/alarm.png";	
							}else if(record.velocity == 0)
							{
							    tempImageUrl = this.mapPath + "/images/track/parking.jpg";	
							}
							var icon = this.createIcon(tempImageUrl);
							var directionMarker = this.addMarker(record.longitude, record.latitude,
								 icon, record, false);
					        directionMarker.setAngle(record.direction);
							//压入到轨迹层，便于一次性清除轨迹
							this.routeOverlays.push(directionMarker);
							this.directionOverlays.push(directionMarker);
							 var zoom = this.map.getZoom();
	                        var isHide = zoom <= 14;
							if(isHide)
								directionMarker.hide();

						//画线
						if(this.showRouteBeforePlay == false)
						{
						    var line = this.createPolyline([prePos,	currentPos]);
						   //压入到轨迹层，便于一次性清除轨迹
					       this.routeOverlays.push(line);
						}
					    this._preLat = record.latitude;
					    this._preLng = record.longitude;
					    this._preRecord = record;
					}
				}
}



/**
 * 停止轨迹播放
 */
AMapHandler.prototype.drawStop = function() {
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
	//this.removeOverlay(this.courseMarker);
	this.startMarker = null;
	this.courseMarker = null;
}
/**
 * 获得两点之间的距离，单位是米
 * lnglat1, lnglat2 是高德的LngLat类
 */
AMapHandler.prototype.getDistance = function(lnglat1, lnglat2)
{
	return lnglat1.distance(lnglat2);
}
/**
 * 清楚所有的元素
 */
AMapHandler.prototype.clearAllElement = function() {
	if(this.hisCarLabel)
	{
		this.removeOverlay(this.hisCarLabel);		
	}
	this.startMarker = null;
	this.courseMarker = null;

	//清楚轨迹中的地标
     for(var m = 0; m < this.routeOverlays.length; m++)
	{
		 var overlay = this.routeOverlays[m];
		 this.removeOverlay(overlay);//清除地图marker
	}
	this.routeOverlays = [];//清空数组
	this.directionOverlays = [];//清空数组
}

AMapHandler.prototype.removeOverlay = function(overlay)
{
	overlay.setMap();
}


//清除历史轨迹中生成的地图对象

//清除历史轨迹中生成的地图对象
AMapHandler.prototype.clearHisRoute = function() {
	if(this.hisCarLabel)
	{
		this.removeOverlay(this.hisCarLabel);		
	}
	this.startMarker = null;
	this.courseMarker = null;

	//清楚轨迹中的地标
     for(var m = 0; m < this.routeOverlays.length; m++)
	{
		 var overlay = this.routeOverlays[m];
		 this.removeOverlay(overlay);//清除地图marker
	}
	routeOverlays = [];//清空数组
}


/**
 * 清空车辆点
 */
AMapHandler.prototype.clearVehiclePoints = function()
{
	this.pointCollection.setData();
}

/**
 * 清楚所有的车辆元素
 */
AMapHandler.prototype.clearAllVehicle = function() {
	for(var m in this.realDataMap)
	{
		var rd = this.realDataMap[m];
		this.removeOverlay(rd.marker);		
		if(rd.label != null)
		this.removeOverlay(rd.label);	
	}
	this.realDataMap = {};
	this.map.clearInfoWindow();
	
	if(this.markerClusterer !=null )
	   this.markerClusterer.clearMarkers();
}

AMapHandler.prototype.addMarkers = function(gpsRealDataList,isCluster)
{	
	this.markerClusterer.clearMarkers();
	var me = this;
	var markers = [];
	var start = new Date();
	$.each(gpsRealDataList,function(index,v){  	     
		 if(v.longitude > 0 && v.latitude > 0)
		 {			 
		   if(isCluster || me.isInMapBound(v.longitude, v.latitude)){
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
        if(console)
	        console.log("地图聚合条数"+gpsRealDataList.length+"条数,耗时:"+ interval+"秒");
	}
}

//点聚合
AMapHandler.prototype.showAllVehicleAsPoints = function(realDataList)
{
	   this.clearVehiclePoints();

	    var runPoints = [];  // 添加海量点数据
	    var vehiclePoints = [];  // 添加海量点数据	
        for (var i = 0; i < realDataList.length; i++) {
            var d = realDataList[i];
			if(d.longitude > 0 && d.latitude > 0 /** &&  this.isInMapBound(d.longitude, d.latitude) */)
			{
				vehiclePoints.push(d);
				/**
				if(d.online == false)
				{
					vehiclePoints.push(new AMap.LngLat(d.longitude, d.latitude));
				}else
				{
					if(d.velocity > 0)
						runPoints.push(new AMap.LngLat(d.longitude, d.latitude));
					else
						parkingPoints.push(new  AMap.LngLat(d.longitude, d.latitude));

				}*/
			}
        }

		if(vehiclePoints.length > 0)
        this.pointCollection.setData(vehiclePoints);
		//if(parkingPoints.length > 0)
        //this.parkingPointCollection.setData(parkingPoints); 
		//if(runPoints.length > 0)
        //this.runPointCollection.setData(runPoints); 
	   
        //this.pointCollection.addEventListener('click', function (e) {
          //alert('单击点的坐标为：' + e.point.lng + ',' + e.point.lat);  // 监听点击事件
        // });


}


AMapHandler.prototype.showVehicleList = function(realDataList, changeViewPoint)
{
	var gpsRealDataList = [];
	for (var i = 0; i < realDataList.length; i++) {
        var d = realDataList[i];
		if(d.latitude > 0 && d.longitude > 0)
		{
			gpsRealDataList.push(d);
		}
	}
	var zoom = this.map.getZoom();
	console.log("当前zoom:"+ zoom + ",上次zoom:"+ this.lastZoomValue);
	//只有一个车
	if(gpsRealDataList.length == 1)
	{
		//如果只有一个车，直接局中显示
		var isCenter = changeViewPoint;
		var marker = this.centerMarkerOverlays(gpsRealDataList[0],false,isCenter, false);
		marker.show();
		return;
	}

	var me = this;
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
			 this.clearVehiclePoints();
			this.clearAllVehicle();
			this.addMarkers(gpsRealDataList,true);
		}
	}else if(zoom <= this.cityZoomValue)
	{
		if(this.lastZoomValue > this.provinceZoomValue && this.lastZoomValue <= this.cityZoomValue && !changeViewPoint)
		{
			//显示点没有变化，不需要动作
		}else
		{
			this.clearAllVehicle();
			this.showAllVehicleAsPoints(gpsRealDataList);
			//this.map.setZoom(zoom);
		}
	}else
	{
		//this.clearAllVehicle();
		this.addMarkers(gpsRealDataList, false);
		this.clearVehiclePoints();

		if(this.lastZoomValue > this.cityZoomValue && !changeViewPoint)
		{
			//显示点没有变化，不需要动作
		}else
		{			
			
			
		}

	}
	this.lastZoomValue = zoom;	

	if(changeViewPoint == true)
	{	
	    this.map.setFitView();
	}
	
}

/**
  * 根据id删除电子围栏
  */
AMapHandler.prototype.removeMapArea = function(enclosureId)
{
      var area = this.areaMap[enclosureId];
	  if(area)
	{
		this.removeOverlay(area.overlay);
		if(area.label != null)
		{
		  this.removeOverlay(area.label);
		}
	}else
	{
		//alert("该区域不存在，无法删除");
	}
}

AMapHandler.prototype.setCenter = function(lat, lng,zoom)
{    
	if(!zoom)
		zoom = this.map.getZoom();
	this.map.setZoomAndCenter(zoom,new AMap.LngLat(lng, lat));
}


AMapHandler.prototype.getGpsDataDescr = function(gpsData)
{
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
		return descr;
}
/**
 * 批量在地图上显示gps车辆地标
 * @gpsDataArray页面传送的gps数据，可以同时显示多个地标，所以是数组
 * @isOpenInfoWindow 是否打开信息窗口
 */
AMapHandler.prototype.centerMarkerOverlays=function(gpsData, isOpenInfoWindow,isCenter,isCluster)
{
		 if(gpsData.longitude == null || gpsData.longitude < 1 || gpsData.latitude < 1)
			 return null;
		 var oldRealDataMarker = this.realDataMap[gpsData.vehicleId];
		var descr = this.getGpsDataDescr(gpsData);
		var marker = null;
		 if(oldRealDataMarker != null)
		{
			 marker = oldRealDataMarker.marker;
			 var iconPath = this.getRecordImageUrl(gpsData.direction, gpsData.velocity,
				 gpsData.online,gpsData.alarmState);
			 var icon = this.createIcon(iconPath, 32);
			 marker.setIcon(icon);	
		     var currentPos = new AMap.LngLat(gpsData.longitude, gpsData.latitude);
			 //this.removeOverlay(oldRealDataMarker.marker);			
			 //this.removeOverlay(oldRealDataMarker.label);		
			 marker.setPosition(currentPos);
			 //oldRealDataMarker.label.setPosition(currentPos);
			 //oldRealDataMarker.label.setContent(descr);
			 marker.setLabel({content:descr, offset:this.labelOffset});
			 
			 oldRealDataMarker.gpsData = gpsData;
			  if(isOpenInfoWindow)
			 {
	               var htmlContent = window.parent.renderTemplate(gpsData);
					this.openHtmlWindow(marker, htmlContent);
			 }


		}else
		 {
		
	     var iconPath = this.getRecordImageUrl(gpsData.direction, gpsData.velocity, gpsData.online,gpsData.alarmState);
		 var icon = this.createIcon(iconPath, 32);
		// isOpenInfoWindow = false;
		 marker = this.addRealDataMarker(descr, gpsData.longitude, gpsData.latitude, icon, gpsData, isOpenInfoWindow,isCluster);
		
		 //var label = this.createMarkerLabel(gpsData.vehicleId, gpsData.latitude, gpsData.longitude, descr,32);
	     this.realDataMap[gpsData.vehicleId] = {marker:marker, gpsData:gpsData};
		
		 }
		 var label =  marker.getLabel();
	     var zoom = this.map.getZoom();
         if(isCenter)
		 {
			 zoom = zoom <= this.cityZoomValue ? (this.cityZoomValue +1) : zoom;
		     this.setCenter(gpsData.latitude, gpsData.longitude, zoom);

			 this.removeOverlay(marker);
			 this.map.add(marker);
		 }
		 
		  if(zoom <= this.cityZoomValue)
		 { 
			 if(label != null)
			 {
			     //label.setStyle({  display:"none" });
				 marker.setLabel(null);
			 }

			
			// marker.hide();
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
			     //label.setStyle({  display:"block" });
				 marker.setLabel({content:descr, offset:this.labelOffset});
			 }

		 }

		 return marker;
}


/**
 * 批量在地图上显示gps车辆地标
 * @gpsDataArray页面传送的gps数据，可以同时显示多个地标，所以是数组
 * @isOpenInfoWindow 是否打开信息窗口
 */
AMapHandler.prototype.showMarkers=function(gpsDataArray, isOpenInfoWindow)
{
	 for (var i = 0; i < gpsDataArray.length; i++) {
		 var gpsData = gpsDataArray[i];
		 if(gpsData.longitude != null || gpsData.longitude < 1 || gpsData.latitude < 1)
			 continue;

		 var currentPos = new AMap.LngLat(gpsData.longitude, gpsData.latitude);
		 //在地图边界外的不进行刷新
		 //if(this.isInMapBound(currentPos) == false)
			// continue;
		 var oldRealDataMarker = this.realDataMap[gpsData.vehicleId];
		  var descr = gpsData.plateNo+"["+ gpsData.depName+"]";
		  if(gpsData.online)
		{
		 if(gpsData.velocity == 0)
			 descr += "停车中";
		 else
			 descr += "车速:"+gpsData.velocity + "km/h";
		}else
			descr += "离线中";
		 if(oldRealDataMarker != null)
		{			 
			 var iconPath = this.getRecordImageUrl(gpsData.direction, gpsData.velocity,
				 gpsData.online,gpsData.alarmState);
			 var icon = this.createIcon(iconPath, 32);
			 oldRealDataMarker.marker.setIcon(icon);	
			 oldRealDataMarker.marker.setPosition(currentPos);
			 oldRealDataMarker.marker.setLabel({content:descr, offset:new AMap.Pixel(20, 20)});
			 oldRealDataMarker.gpsData = gpsData;
			 if(isOpenInfoWindow)
			 {
	               var htmlContent = window.parent.renderTemplate(gpsData);
					this.openInfoWindow(oldRealDataMarker.marker, htmlContent);
			 }

		}else
		 {
		
			 var iconPath = this.getRecordImageUrl(gpsData.direction, gpsData.velocity, gpsData.online,gpsData.alarmState);
			 var icon = this.createIcon(iconPath, 32);
			// isOpenInfoWindow = false;
			 var marker = this.addRealDataMarker(descr,gpsData.longitude, gpsData.latitude, icon, gpsData, isOpenInfoWindow);
			
			 //var label = this.createMarkerLabel(gpsData.vehicleId, gpsData.latitude, gpsData.longitude, descr,32);
			 this.realDataMap[gpsData.vehicleId] = {marker:marker, gpsData:gpsData};
			
		 //if(isCenter)
		    //this.setCenter(gpsData.latitude, gpsData.longitude);
		 }
		 //this.addGoogleMarker(marker);
	}
}

AMapHandler.prototype.planDriveRoute = function(startPOI, endPOI)
{
	var driving = new AMap.DrivingRoute(this.map, {renderOptions: {map: this.map, panel: "r-result", autoViewport: true}});
	driving.search(startPOI,  endPOI);

}

AMapHandler.prototype.createLocalSearch = function(onSearchResult)
{
	
}

AMapHandler.prototype.createVehicleMarker = function(bmPoint, bIcon, opt,isOpenInfoWindow)
{
   var marker = new AMap.Marker(bmPoint,{icon:bIcon});  // 创建标注
   //map.addOverlay(marker);              // 将标注添加到地图中   
   var htmlContent = window.parent.renderTemplate(opt);
   var markerInfoWindow = new AMap.InfoWindow(htmlContent);
   marker.on("click", function(){
        this.openInfoWindow(markerInfoWindow);
   });
   if(isOpenInfoWindow)
	{
        marker.openInfoWindow(markerInfoWindow);
	}
	return marker;
}



AMapHandler.prototype.createIcon = function(iconPath, width, height)
{
	//默认是16*16
	if(!width)
		width=16;
	if(!height)
		height = width;
	var iconOptions = {image:iconPath, size:new AMap.Size(width, height)};
	return new AMap.Icon(iconOptions);
}

AMapHandler.prototype.openInfoWindow = function(vehicleId)
{
	var realData = this.realDataMap[vehicleId];
	if(realData)
	{
		var opt = realData.gpsData;
		var htmlContent = window.parent.renderTemplate(opt);
		var windowOptions = {content:htmlContent,isCustom:true,closeWhenClickMap:true};
	    var markerInfoWindow = new AMap.InfoWindow(windowOptions);
		//realData.marker.openInfoWindow(markerInfoWindow);
		markerInfoWindow.open(this.map, realData.marker.getPostion());
	}
}

AMapHandler.prototype.openHtmlWindow = function(marker,htmlContent)
{
		var windowOptions = {content:htmlContent,isCustom:false,closeWhenClickMap:true, offset:new AMap.Pixel(12,-16)};
	  var markerInfoWindow = new AMap.InfoWindow(windowOptions);
	  //marker.openInfoWindow(markerInfoWindow);	  
	  markerInfoWindow.open(this.map, marker.getPosition());
}


AMapHandler.prototype.getGpsInfoWindow = function(vehicleId)
{
	var url = globalConfig.webPath + "/RealData.mvc/ViewRealData?vehicleId="+vehicleId;
	var htmlContent = '<div style="width:550px;height:200px;"><iframe scrolling="no" id="infoIframe" frameborder="0"  src="'+ url + '" style="width:100%;height:99%;"></iframe></div>';
	
		var windowOptions = {content:htmlContent,isCustom:false,closeWhenClickMap:true, offset:new AMap.Pixel(12,-16)};
	var markerInfoWindow = new AMap.InfoWindow(windowOptions);

	return markerInfoWindow;

}



AMapHandler.prototype.addMarker = function(lng, lat, icon, opt,isOpenInfoWindow)
{
   var pt = new AMap.LngLat(lng, lat);
   //var myIcon = new AMap.Icon(iconPath, new AMap.Size(16,16));
   //var marker = new AMap.Marker(pt,{icon:icon});  // 创建标注   
   //var label = {content:markerName, offset:new AMap.Pixel(0,0)};
   var sz = icon.getImageSize();
   var iconOffset = new AMap.Pixel(-1 * 7.5, -1 * 7.5);
   var marker = new AMap.Marker({map:this.map, position:pt, icon:icon, offset:iconOffset});  // 创建标注
   //this.map.addOverlay(marker);              // 将标注添加到地图中   
   if(opt)
	{
	   var vehicleId = opt.vehicleId;
       var me = this;
	   var htmlContent = window.parent.renderTemplate(opt);
	   marker.on("click", function(){
			//me.openInfoWindow(vehicleId);
			me.openHtmlWindow(marker,htmlContent);
	   });
	   if(isOpenInfoWindow)
	   {
			me.openHtmlWindow(marker,htmlContent);
	   }
	}
	return marker;
}

AMapHandler.prototype.addRealDataMarker = function(descr, lng, lat, icon, opt,isOpenInfoWindow,isCluster)
{
   var pt = new AMap.LngLat(lng, lat);
   //var options = {image:icon, size:new AMap.Size(48,48)};
   //var myIcon = new AMap.Icon(options);
  var label = {content:descr, offset:this.labelOffset};  
   var iconOffset = new AMap.Pixel(-1 * 16, -1 * 16);
  var marker = new AMap.Marker({position:pt, icon:icon, label:label,offset:iconOffset});  // 创建标注
   //this.map.addOverlay(marker);              // 将标注添加到地图中   
   //if(isCluster != true)
	   this.map.add(marker);
   if(opt)
	{
	   var vehicleId = opt.vehicleId;
       var me = this;
	   marker.on("click", function(){
			//me.openInfoWindow(vehicleId);
			//me.openHtmlWindow(marker,htmlContent);
	       var markerInfoWindow = me.getGpsInfoWindow(opt.vehicleId);
		   markerInfoWindow.open(me.map, marker.getPosition());
		   //me.openInfoWindow(marker, markerInfoWindow);
	   });
	   if(isOpenInfoWindow)
	   {
	       var htmlContent = window.parent.renderTemplate(opt);
	        //var markerInfoWindow = new AMap.InfoWindow(htmlContent);
			me.openHtmlWindow(marker, htmlContent);
	   }
	}
	return marker;
}


AMapHandler.prototype.createMarker = function(lng, lat, iconPath, opt,isOpenInfoWindow)
{
   var pt = new AMap.LngLat(lng, lat);
   var myIcon = this.createIcon(iconPath);
   var marker = new AMap.Marker(pt,{icon:myIcon});  // 创建标注
   //map.addOverlay(marker);              // 将标注添加到地图中   
   var htmlContent = window.parent.renderTemplate(opt);
   var markerInfoWindow = new AMap.InfoWindow(htmlContent);
   marker.on("click", function(){
        this.openInfoWindow(markerInfoWindow);
   });
   if(isOpenInfoWindow)
	{
        marker.openInfoWindow(markerInfoWindow);
	}
	return marker;
}
AMapHandler.prototype.createPolyline=function(points)
{
	 var options = {strokeColor:"blue", strokeWeight:3, strokeOpacity:0.5,map:map, path:points};
	 var polyline = new AMap.Polyline(options );
	 return polyline;
}
/**
 * 判断点是否在地图边界中
 */
AMapHandler.prototype.isInMapBound=function(bmPoint)
{
        var bounds = this.map.getBounds(); 
		return bounds.containsPoint(bmPoint);
}

AMapHandler.prototype.isInMapBound=function(lng,lat)
{
   var bmPoint = new AMap.LngLat(lng, lat);
        var bounds = this.map.getBounds(); 
		return bounds.contains(bmPoint);
}
/**
  * 创建标注
  */
AMapHandler.prototype.createLabel=function(id, lat, lng, text, offsetY)
{
	if(text == null|| text.length == 0)
		return;
	if(!offsetY)
		offsetY = -10;
	var offsetX = -10 * text.length / 2;
	//alert(offsetX);
   var point = new AMap.LngLat(lng, lat);
	var opts = {
	  position : point,    // 指定文本标注所在的地理位置
	  offset   : new AMap.Size(offsetX, 16)    //设置文本偏移量
	}
	
    var marker = new AMap.Marker({map:map, position:point, content:text});  // 创建标注
	/**
	var label = new AMap.Label(text, opts);  // 创建文本标注对象
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
	*/
	return marker;
}


/**
 * 根据地图的zoom值，决定是否显示历史轨迹的方向图标
 */
AMapHandler.prototype.hideDirectionMarkerByZoom = function () {
    var zoom = this.map.getZoom();
    var isHide = zoom <= 14;

    $.each(this.directionOverlays, function (i, overlay) {
        if (isHide)
            overlay.hide();
        else
            overlay.show();
    });
}

AMapHandler.prototype.createMarkerLabel=function(id, lat, lng, text, offsetY)
{
	if(!offsetY)
		offsetY = -10;
	var offsetX = -10 * text.length / 2;
	//alert(offsetX);
   var point = new AMap.LngLat(lng, lat);
	var opts = {
	  position : point,    // 指定文本标注所在的地理位置
	  offset   : new AMap.Size(offsetX, 16)    //设置文本偏移量
	}
	var label = new AMap.Label(text, opts);  // 创建文本标注对象
	label.setStyle({
			 color : "blue",
			 fontSize : "12px",
			 height : "20px",
			 border:0,
			 background:"#CCFFCC",
			 lineHeight : "20px",
			 fontFamily:"微软雅黑"
		 });
	//map.addOverlay(label);
	return label;
}
