

/**
 * 地图操作对象
 * @param handler
 * @param locale
 * @returns {MapOperationHandler}
 */
function MapOperationHandler(divObj, lat, lng, zoomLevel, _mapPath) {
	this.mapInit(divObj, lat, lng, zoomLevel, null);
	this.clickCount = 0;
	this.mapPath = _mapPath;
	this.imgPath = this.mapPath+"/images";
	this._color = "blue";
	this._bgcolor = "yellow";
	this._weight = 3;
	this._opacity = 0.5;

	this._window = window;
	//this = handler;
	this._defaultTrackNodeCount = 500;
	this._defaultTrackModeDistant = 2000; // unit(m)
	this._enableFunc = null;
	this._isStop = false;
	// this._currentMapType = currentMapType;
	this.startMarker = null;
	this._startMarkerClickHandler = null;
	this.courseMarker = null;
	this._courseMarkerClickHandler = null;
	this.endMarker = null;
	this._endMarkerClickHandler = null;
	this._preCourseMarker = null;
	this._currentMarkerIndex = 0;
	this._isPlay = false;
	this._defaultStartImg = "";
	this._defaultEndImg = "";
	this._defaultPlayZoom = 13;
	this._defaultLocationColor = "#333399";
	this._defaultLocationWeight = 3;
	this._defaultLocationOpacity = 1;
	if (typeof (Storage) != "undefined")
		this._storage = new Storage();
	this._gridSelectionModel = null;
	this._nCount = 0; //每次播放的计数器
	this._defaultPageSize = 100; //默认缺省的分页数
	this._pageCount = null; //总页数
	this._nCurrentPage = null; //当前页的行数
	this._nStartPage = 0; //起始页
	this._oCallBack = null;
	this._timeId = null;
	this._autoChangePage = false;
	this._preLat = null;
	this._preLng = null;
	//回放轨迹时默认标记
	this._defaultLocationImgUrl = this.imgPath+"/car_green.gif";
	//定位点名时默认标记
	this._defaultCenterPoint = this.imgPath+"/track/centerPoi.gif";
	this._preMarkerIcon = this.imgPath+"/location/pre_car.gif";
	this._preTrackerIcon = this.imgPath+"/location/pre_tracker.gif";
	this._isOver = true;
	this._placeAddress = "";
	this._currentDynamicMarker = null;
	this._preDynamicMarker = null;
	this._preMarkerType = null;
	if (typeof (LOCALE) != "undefined") {
		this._startIconImageUrl = this.imgPath+"/track/" + LOCALE + "/start.gif";
		this._endIconImageUrl = this.imgPath+"/track/" + LOCALE + "/end.gif";
	} else {
		this._startIconImageUrl = this.imgPath+"/track/zh_cn/start.gif";
		this._endIconImageUrl = this.imgPath+"/track/zh_cn/end.gif";
	}
	
	this._cousorImageUrl = this.imgPath+"/track/centerPoi.gif";
	
	this._eventImageUrl = this.imgPath+"/track/event.png";
	
	this._alarmImageUrl = this.imgPath+"/track/alarm.png";
	
	this._currentImageUrl = this.imgPath+"/track/point.png";
	this._preRecord = null;
	this._radius = 500; // (米)
	this.realDataMap = {};
	//限速点标记的map集合，便于删除线路的时候，同时删除线路上的限速点
	this.limitSpeedMarkerMap = {};
	//历史轨迹对象数组，便于一次性全部清除
	this.hisRouteArray = new Array();
}


MapOperationHandler.prototype.mapInit = function(divObj, lat, lng, zoomLevel, defaultCity) {
	try {
		
		// var LTMaps;
		if ((typeof (SE) != "undefined") && divObj != null) {
			this._divObj = document.getElementById(divObj);
			
			this._divObj.style.display = "block";
			this._oMap = new SE.Map(divObj);
			if ((lat == 0 || typeof(lat) != "number")&& (lng == 0 || typeof(lng) != "number")){
				lat = 38.29348;
				lng = 109.29054;
			}
			
			this._oMap.centerAndZoom(this.createPoint(lat, lng), zoomLevel);
			this._centerLat = lat;
			this._centerLng = lng;
			this._centerZoomLevel = zoomLevel;
			this._initCenterPoint = this.getCenter();
			this._oMap.enableHandleMouseScroll();
			this._currentCity = defaultCity || "北京市";
			
			this.initStandardControls();
			this._divObj.onclick = function(){
			}
			return 1;
		} else {
			return 0;
		}
	} catch (e) {
		return -1;
	}
};


MapOperationHandler.prototype.initStandardControls = function(opts){
	try{
		var map = this._oMap;
		
		//if (opts.boon){
			map.addControl(new SE.MapControl());
		//}
		/**
		if (opts.switchMap){
			var switchControl = new SE.MapTypeControl();
			map.addControl(switchControl);
			// map.removeMapType(SE.Traffic_MAP);
			switchControl.setRight(5);
		}*/
		
		//if (opts.scale){
			var scale = new SE.ScaleControl();
			scale.setLeft(20);
			scale.setBottom(30);
			map.addControl(scale);
		//}
		
		//if (opts.mouseScroll){
			map.handleMouseScroll(true);
		//}
		
		//if (opts.handleKeyboard){
			map.handleKeyboard();
		//}
		
	}catch(e){
	}
}



MapOperationHandler.prototype.mapOverlayInit = function() {
	if (typeof (MapOverlay) != "undefined")
		this._overlays = new MapOverlay(this, "vehicle");
};

MapOperationHandler.prototype.setDefaultTrackNodeCount = function(count) {
	this._defaultTrackNodeCount = count;
}

MapOperationHandler.prototype.latLngChange = function(value) {
	return value > 1000 ? (value / 100000) : value;
}

MapOperationHandler.prototype.pointToString = function(points, flag){
	if(points.lat && points.lng)
	{
		return this.latLngChange(points.getLng() ) + 
			"," + 
			this.latLngChange(points.getLat() )
	}
	var str = [];
	for (var i=0;i<points.length;i++){
		str.push(
			this.latLngChange(points[i].getLng() ) + 
			"," + 
			this.latLngChange(points[i].getLat() )
		);
	}
	if (flag){
		str.push(str[0]);
	}
	return str.join("#");
};

MapOperationHandler.prototype.getBoundsMiniMax = function(mapBounds) {
	var northEast = mapBounds.getNorthEast();
	var southWest = mapBounds.getSouthWest();
	
	return {
		xMin : this.latLngChange(southWest.getLng()),
		yMin : this.latLngChange(southWest.getLat()),
		xMax : this.latLngChange(northEast.getLng()),
		yMax : this.latLngChange(northEast.getLat())
	}
}

MapOperationHandler.prototype.getMap = function() {
	return this._oMap;
}


MapOperationHandler.prototype.bindClickEventHTML = function(opts) {
	if(window.parent && window.parent.renderTemplate)
		return window.parent.renderTemplate(opts);
	return "";
	
}

MapOperationHandler.prototype.removeInfoWindow = function(nodeObj) {
	if (nodeObj._markClickHandler != null) {
		GEvent.removeListener(nodeObj._markClickHandler);
		nodeObj._markClickHandler = null;
	}
}


MapOperationHandler.prototype.drawLine = function(points) {
	var line = this.createPolyline(points, this._defaultLocationColor,
			this._defaultLocationWeight, this._defaultLocationOpacity);
	this.addOverlay(line);
	return line;
};


MapOperationHandler.prototype.setCenter = function(lat, lng,zoomLevel)
{
	var point = this.createPoint(lat, lng);
	try {
		this._oMap.setCenterAtLngLat(point, zoomLevel || this.getZoom());
	}catch(e){
	}
}

MapOperationHandler.prototype.centerLatLons = function(records) {
	var lat1, lon1, lat2, lon2;
	lat1 = null;
	lon1 = null;
	lat2 = null;
	lon2 = null;
	var latlon = "";
	for ( var i = 0; i < records.length; i++) {
		//找到精度和纬度
		if (parseFloat(records[i].tLat) > 0.1
				&& parseFloat(records[i].tLng) > 0.1) {

			latlon += records[i].tLat + "," + records[i].tLng + ";"
			if (lat1 == null) {
				lat1 = records[i].tLat;
				lat2 = records[i].tLat;
			} else {
				if (lat1 < records[i].tLat) {
					lat1 = records[i].tLat;
				}
				if (lat2 > records[i].tLat) {
					lat2 = records[i].tLat;
				}
			}
			if (lon1 == null) {
				lon1 = records[i].tLng;
				lon2 = records[i].tLng;
			} else {
				if (lon1 < records[i].tLng) {
					lon1 = records[i].tLng;
				}
				if (lon2 > records[i].tLng) {
					lon2 = records[i].tLng;
				}
			}
		}
	}
	if (lat1 != null) {
		
		var scale1 = this.computeScale(lat1, lon1, lat2, lon2);
		var lat = (lat1 + lat2) / 2;
		var lon = (lon1 + lon2) / 2;
		if (scale1 > 11) {
			scale1 = 11;
		}
		scale1 += 2;
		lat = lat +0.02;
		//alert(lat);
		this.setCenter(lat, lon, scale1);
	}
}

MapOperationHandler.prototype.createMarkerOverlays = function(records, flag, isOpenWindow) {
	for ( var i = 0; i < records.length; i++) {
		//this.createMarkerOverlay(records[i]);
		var currentLatLng = this.createPoint(records[i].rLat,
				records[i].rLng);
		this.createMarkerOverlayPointMode(records[i], flag, isOpenWindow);
		//this.createMarkerOverlay(records[i]);
	}
}
MapOperationHandler.prototype.centerMarkerOverlays = function(records, isOpenWindow) {
	//this.centerLatLons(records);
	if(records.length > 0)
		this.setCenter(records[0].rLat,
				records[0].rLng);
	this.createMarkerOverlays(records, null, isOpenWindow);

}
/**
 *将数据库记录，转换成地图所需要的数据格式
 */
MapOperationHandler.prototype.convertRecord = function(rd)
{
	  var vehicleInfo = {id:rd.ID, text:rd.plateNo, vehicleId:rd.ID, rLat:rd.latitude,rLng:rd.longitude,
		  tLat:rd.latitude, tLng:rd.longitude,status:rd.status,color:rd.plateColor,validate:rd.valid,
		  direction:rd.direction,gas:rd.gas,depName:rd.depName,industry:rd.industry,simNo:rd.simNo,
		  vehicleType:rd.vehicleType,
							  angleInt:rd.direction, statusInt:0, speed:rd.velocity, warnTypeId:0, online:rd.online};
	  return vehicleInfo;
}



MapOperationHandler.prototype.clearMarkerOverlay = function(){
	this._overlays.hideAllOverlays();
}


MapOperationHandler.prototype.clearAllVehicle = function() {
	if (this._enableFunc != null) {
		this._enableFunc();
	}
	this._overlays.removeOverlays();
	this.drawStop();
	this.clearHisRoute();
}

MapOperationHandler.prototype.showMarkers = function(records,isOpenWindow) {
	
	for ( var i = 0; i < records.length; i++) {
		this.createMarkerOverlayPointMode(records[i], isOpenWindow);
		//this.createMarkerOverlay(records[i]);
	}

}


MapOperationHandler.prototype.changeMarkerImage = function(id, flag){
	var overlay = this._overlays.isExistOverlay(id), imageUrl;
	if (overlay){
		
		imageUrl = this.getImageUrl(
			"",
			overlay.opts.angleInt, 
			overlay.opts.statusInt, 
			overlay.opts.speed, 
			overlay.opts.warnTypeId, 
			flag
		);
		
		this.markerSetImage(overlay.overlay, imageUrl, 24, 24, 12, 12);
	}
}

/**
 * 根据GPS实时数据，动态生成车辆地标
 * angleInt GPS上传的方向,根据方向生成不同的车型
 * warnTypeId GPS上传的报警值
 * online  true false 是否上线
 */
MapOperationHandler.prototype.getImageUrl = function(header, angleInt, statusInt, speed, alarm, online){
	var img = header + setAngleImage(angleInt);
	if(online)
	{
		if (typeof(alarm) != "undefined" && parseInt(alarm) != 0){
			return this.imgPath+"/alarm/" + img;
	    }else if(speed <= 1)
		{
		    return this.imgPath+"/direction/parking/" + img;

		}else			
			return this.imgPath+"/direction/" + img;

	}else
	{
		return this.imgPath+"/direction/off/" + img;
	
    }
}


/**
 * 创建点的图标
 * tagetInfo  id 车辆ID .angleInt, targetInfo.statusInt, targetInfo.speed,
		targetInfo.warnTypeId, targetInfo.online
	isOpenWindow 是否直接打开信息窗口
 */
MapOperationHandler.prototype.createMarkerOverlayPointMode = function(targetInfo, callback, isOpenWindow) {
	var currentLatLng = this.createPoint(targetInfo.rLat,
			targetInfo.rLng);
	var overlay, imageUrl;
	var operatorObj = this;
	targetInfo.type = "point";
	imageUrl = this.getImageUrl("", targetInfo.angleInt, targetInfo.statusInt, targetInfo.speed,
		targetInfo.alarmState, targetInfo.online);
	
	
	if (!this._overlays.isExistOverlay(targetInfo.id)){
		var tempMarker = this.createMarker(
				currentLatLng, 
				imageUrl, 
				targetInfo.text,
				"",
				{x:24,y:6}
			);
		overlay = this._overlays.addOverlay(
			targetInfo.id, 
			tempMarker, 
			targetInfo,
			true,
			null,
			true
		);
	} else {
		overlay = this._overlays.updateOverlay(targetInfo.id, targetInfo);
		this.markerSetImage(overlay.overlay, imageUrl, 24, 24, 12, 12);
	}
	if (!overlay.display){
		this._overlays.showOverlay(targetInfo.id);
	}
	if (overlay.handler){
		this.removeListener(overlay.handler);
	}
	this.clickCount++;
	
	overlay.opts.clickIndex = this.clickCount;
	isOpenWindow = isOpenWindow ? isOpenWindow : false;
	
	overlay.handler = this.bindClickEvent(
		overlay.overlay, 
		overlay.opts,
		function(opts){
			return operatorObj.bindClickEventHTML(opts);
		}, 
		function() {
			if (callback){
				callback(targetInfo.vehicleId, overlay.opts.clickIndex);
			}
			//得到地址后，直接赋值给前面的HTML中的id
			operatorObj._handler.getAddress(overlay.opts.id, overlay.opts.rLat, overlay.opts.rLng);
		}, 
		isOpenWindow,200,150
	);
	return currentLatLng;
};

MapOperationHandler.prototype.createPolylineById = function(string, id, clickCallback)
{
	var polyline =  this.createPolyline(this.stringToPoint(string));
	 SE.Event.bind(polyline,"mouseover",polyline,  function()
	{
		 this.setLineColor("red");  
	});  
	
    SE.Event.bind(polyline,"mouseout",polyline,  function()
	{this.setLineColor("blue");
	});  
	var map = this._oMap;
		SE.Event.addListener(polyline,"click", function(pt)
		{
			if(clickCallback)
			{
				pt = map.fromContainerPixelToLngLat(pt);
				clickCallback(id, pt);
			}
			// alert("fuck you");
		});  
    this._oMap.addOverLay(polyline);

	//return polyline;
    if(polyline)
		this._storage.addKey("ma_" + id, polyline); //保存在内存中，提供再次访问
}

MapOperationHandler.prototype.createMapAreaById = function(stringPoints, radius, id, areaType, clickCallback){

    var mapArea = null;
		var pt = this.stringToPoint(stringPoints);
	//alert(areaType);
	if(areaType == "circle")
	{
		pt = pt[0];
	    mapArea =  this.createCircle(pt.getLat(), pt.getLng(), radius);
	}
	else 	if(areaType == "rect")
	{
		var bounds=new SE.LngLatBounds([pt[3],pt[1]]);  
	    mapArea =  this.createRect(bounds);
	}
	else 	if(areaType == "polygon")
	{
		var pt1 = pt[0];
		var pt2 = pt[pt.length - 1];
		if(pt1.getLat() != pt2.getLat() && pt1.getLng() != pt2.getLng())
		{
		   pt.push(pt1);//首尾相接
		}
	    mapArea =  this.createPolygon(pt);
	}else
		return;

	 SE.Event.bind(mapArea,"mouseover",mapArea,  function()
	{
		 this.setLineColor("red");  
	});  
     SE.Event.bind(mapArea,"mouseout",mapArea,  function()
	{this.setLineColor("blue");
	});  
		SE.Event.addListener(mapArea,"click", function()
		{
			if(clickCallback)
				clickCallback(id);
			// alert("fuck you");
		});  
    this._oMap.addOverLay(mapArea);
	if(mapArea)
		this._storage.addKey("ma_" + id, mapArea); //保存在内存中，提供再次访问
}


MapOperationHandler.prototype.createPoint = function(lat, lng) {
	return new SE.LngLat(lng, lat);
	// return new LTPoint(113.04095, 22.56515);
};

MapOperationHandler.prototype.createMarker = function(point, icon, title) {
	// trace("createMarker");
	var marker =  new SE.Marker(
		point
	);
	marker.setIconImage(icon);  
	return marker;
};
MapOperationHandler.prototype.markerSetPosition = function(marker, lat, lng) {
	marker.setLngLat(this.createPoint(lat, lng));
};

MapOperationHandler.prototype.eventBind = function(obj, eventName, handle, flag) {
	return SE.Event.addListener(obj, eventName, handle);
};


MapOperationHandler.prototype.createIcon = function(width, height, anchorWidth, anchorHeight, imagePath) {
	return new SE.Icon(imagePath, new SE.Size(width, height), new SE.Point(anchorWidth, anchorHeight));
};

MapOperationHandler.prototype.createKeyPointMarkerById = function(id, lat, lng, title,
		icon, clickCallback) {
	var point = this.createPoint(lat, lng);
	//this.setCenter(point, this.getZoom());
	var keyMarker= this.createMarker(point, icon, title);
	this.addOverlay(keyMarker);
	this.markerSetPosition(keyMarker, lat, lng);
	this.eventBind(keyMarker, "click", function()
	{		
			if(clickCallback)
				clickCallback(id);
	}) ;
	
	if(keyMarker)
		this._storage.addKey("ma_" + id, keyMarker); //保存在内存中，提供再次访问
	return keyMarker;
};
//创建限速点的
MapOperationHandler.prototype.createLimitSpeedPointMarkerById = function(routeId,id, lat, lng, title,
		icon, clickCallback) {
	var point = this.createPoint(lat, lng);
	//this.setCenter(point, this.getZoom());
	var keyMarker= this.createMarker(point, icon, title);
	this.addOverlay(keyMarker);
	this.markerSetPosition(keyMarker, lat, lng);
	this.eventBind(keyMarker, "click", function()
	{		
			if(clickCallback)
				clickCallback(id);
	}) ;
	
	if(keyMarker)
	{
		var markerArray = this.limitSpeedMarkerMap[routeId];
		if(markerArray == null)
		{
			markerArray = new Array();
			this.limitSpeedMarkerMap[routeId] = markerArray;
		}
		this._storage.addKey("limit_" + id, keyMarker); //保存在内存中，提供再次访问
		markerArray.push(keyMarker);
	
		//var label = OperatorObj.createLabel("limita_"+id, lat, lng, title);
		//markerArray.push(label);
	}
	return keyMarker;
};

MapOperationHandler.prototype.createMapArea = function(id, data, title) {
	var records = [];
	this.removeMapArea("ma_" + id);
	var latLons = [];
	for ( var i = 0; i < data.length; i++) {
		latLons.push(this.createPoint(data[i].lat, data[i].lon));
		records.push({
			tLat : data[i].lat,
			tLng : data[i].lon
		});
	}
	this.centerLatLons(records);
	latLons.push(this.createPoint(data[0].lat, data[0].lon))
	var polyOptions = {
		geodesic : false
	};
	var polyline = this.createPolygon(latLons);
	this.addOverlay(polyline);
	this.getBestMap(latLons);
	var latLng = this.getCenterPointLatLng();
	this.addOverlay(this.createLabel(id, latLng[0],
			latLng[1], title, 0, 0));
	this._storage.addKey("ma_" + id, polyline);
}

/**
 * 设置地图中心点，触发回调，保存到服务器上
 */
MapOperationHandler.prototype.configCenterPoint = function(callback) {
	var center = this.getCenter();
	this._centerLat = center.lat;
	this._centerLng = center.lng;
	this._centerZoomLevel = this.getZoom();
	
	if (callback){
		callback(this._centerLat, this._centerLng, this._centerZoomLevel);
	}
};

MapOperationHandler.prototype.getZoom = function() {
	return this._oMap.getCurrentZoom();
};

MapOperationHandler.prototype.removeOverlay = function(overlay, flag) {
	this._oMap.removeOverLay(overlay, flag);
};
MapOperationHandler.prototype.getCenter = function(){
	return this._oMap.getCenterPoint();
}

MapOperationHandler.prototype.getCenterPointLatLng = function(){
	var point = this.getCenter();
	return [this.latLngFormatReserve(this.latLngChange(point.getLat())), 
	        this.latLngFormatReserve(this.latLngChange(point.getLng()))];
}
MapOperationHandler.prototype.createLabel = function(id, lat, Lng, title)
{
	var key = "areaLabel_" + id;
	var label = this._storage.isExistKey(key);
	if(label)
	{
		this.changeLabelText(label, title);
	}else
	{
		x = 0 - title.length;
		label = this.createTextLabel(id, lat, Lng, title, x, 0, 0);
		this.addOverlay(label);
		this._storage.addKey(key, label);
	}
	return label;
}

MapOperationHandler.prototype.removeMapArea = function(id) {
	//删除图元
	var mo = this._storage.isExistKey("ma_" + id);
	if (mo) {
		this.removeOverlay(mo);
		this._storage.removeKey("ma_" + id);
	}
	//删除文字标注
	var mo = this._storage.isExistKey("areaLabel_" + id);
	if (mo) {
		this.removeOverlay(mo);
		this._storage.removeKey("areaLabel_" + id);
	}

	var markerArray = this.limitSpeedMarkerMap[id];
	if(markerArray != null)
	{
		for(var m = 0; m < markerArray.length; m++)
		{
			var marker = markerArray[m];
			this.removeOverlay(marker);
		}
	}

}

/**
 * 删除指定层
 * @param {string} id 指定层id
 */
MapOperationHandler.prototype.removeMarker = function(id) {
	var overlay = this._overlays.getOverlay(id);
	if (overlay) {
		if (overlay.opts.type == "track") {
			for ( var i = 0; i < overlay.opts.targetInfos.length; i++) {
				if (overlay.opts.targetInfos[i]) {
					var marker = overlay.opts.targetInfos[i].marker;
					if (marker)
						this.removeOverlay(marker);
					var line = overlay.opts.lines[i];
					if (line)
						this.removeOverlay(line);
				}
			}
		}
		this._overlays.removeOverlay(id);
	}
};

//
MapOperationHandler.prototype.clearCorfirmMarker = function(markerObj,
		labelObj, groDelete) {
	if (markerObj != null) {
		this.removeOverlay(markerObj);
	}

	if (labelObj != null) {
		this.removeOverlay(labelObj);
	}
};

MapOperationHandler.prototype.createStartMarker = function(lat, lng, title,
		icon) {
	var point = this.createPoint(lat, lng);
	this.setCenter(lat,lng, this.getZoom());
	if (this.startMarker == null) {
		this.startMarker = this.createMarker(point, icon, title);
		this.addOverlay(this.startMarker);
	} else {
		this.markerSetPosition(this.startMarker, lat, lng);
	}
	return this.startMarker;
};




MapOperationHandler.prototype.drawStop = function() {
	this._currentMarkerIndex = 0;
	//this.startMarker = null;
	//this.courseMarker = null;
	this.firstPlay = false;
	this._isPlay = false;
	this._nCount = 0;
	this._preLat = null;
	this._preLng = null;
	if (this._enableFunc != null) {
		this._enableFunc();
	}
	this._isOver = true;
	this._isStop = false
}

MapOperationHandler.prototype.clearAllElement = function() {
	this.clearStorage();
	this.drawStop();
}
//清除历史轨迹
MapOperationHandler.prototype.clearHisRoute = function() {
	for(var m = 0; m < this.hisRouteArray.length; m++)
	{
		var marker = this.hisRouteArray[m];
		this.removeOverlay(marker);
	}
	this.drawStop();
	this.courseMarker = null;
	this.startMarker = null;
}
//越出地图边界
MapOperationHandler.prototype.beyondMapBound = function(lat, lng) {
	if(lat < 100000)
	{
	lat = lat * 100000;
	lng = lng *100000 ;
	}
	var mapBounds = this._oMap.getLngLatBounds();
	var northEast = mapBounds.getNorthEast();
	var southWest = mapBounds.getSouthWest();
	if ((lng > southWest.getLng() && lng < northEast.getLng()) && 
			(lat > southWest.getLat() && lat < northEast.getLat())) {
		return true;
	}
	return false;
};



MapOperationHandler.prototype.clearStorage = function() {
	if (this.startMarker != null)
		this.removeOverlay(this.startMarker);
	if (this.courseMarker != null){
		this.removeOverlay(this.courseMarker);
		this.courseMarker = null;
	}
	if (this.endMarker != null) this.removeOverlay(this.endMarker);
	var listHash = this._storage.listHash;
	for ( var key in listHash) {
		this.removeOverlay(listHash[key]);
		this._storage.removeKey(key);
	}
}


MapOperationHandler.prototype._drawPlayWithGrigEnd = function(){
	var that = this;
	if (this.courseMarker == null){
		return ;
	}
	
	this.endMarker = this.createMarker(this.courseMarker.getLngLat(), this
			.createIcon(39, 25, 17, 26, this._endIconImageUrl));
	
	this.endMarker.setIconImage(this._endIconImageUrl); 
	/**
	this.bindClickEvent(this.endMarker, this
			.markerDataBind(this._preRecord),
			this.bindClickEventHTML, this.drawGridCallback(this, this._preRecord.get("serial_number"),
				this._preRecord.get("vehicleId"),this._preRecord.get("rlat"), this._preRecord.get("rlng")), false, 300);
	**/
	this.bindClickEvent(this.endMarker, this
			.markerDataBind(this._preRecord),
			function(opts){
				return that.bindClickEventHTML(opts);
			}, this.drawGridCallback(this, this._preRecord.RowNum,
				this._preRecord.gpsId,this._preRecord.latitude, this._preRecord.longitude), false, 300);
	
	this.removeOverlay(this.courseMarker);
	this.addOverlay(this.endMarker);
	this._gridSelectionModel.clearSelections();
	this.drawStop();
}

MapOperationHandler.prototype.getImage = function(type, angleInt) {
	switch(type){
	case 0:
		return this.imgPath+"/direction/arrow-" + setAngleImage(angleInt);
	case 1:
		return this.imgPath+"/alarm/arrow-" + setAngleImage(angleInt);
	case 2:
		return this.imgPath+"/alarm/arrow-" + setAngleImage(angleInt);
	}
}


MapOperationHandler.prototype.getRecordImageUrl = function(record) {
	var direction = record.direction;
	var alarm = record.alarmState;
	var online = record.online;
	if(!direction)
		direction = 0;
	var img = setAngleImage(direction);
	if (typeof(alarm) != "undefined" && parseInt(alarm) != 0){
			return this.imgPath+"/alarm/" + img;
	}else{
			if (online){
				return this.imgPath+"/direction/" + img;
			}else{
				return this.imgPath+"/direction/off/" + img;
			}
		
	}
}

//**************************************************************带数据表格的轨迹绘制
MapOperationHandler.prototype.drawRoute = function(record) {
	// 当前计数器是否和当前页数相等
	
			if (record) {
				var courseLat =parseFloat(record.latitude);
				var courseLng = parseFloat(record.longitude);

				if (this.startMarker == null) {
					var latLng = this.createPoint(courseLat, courseLng);
					this.setCenter(courseLat, courseLng, this.getZoom());
					this.startMarker = this.createMarker(latLng,
							this._startIconImageUrl);
				    
				    this.startMarker.setIconImage(this._startIconImageUrl); 
					this.addOverlay(this.startMarker);
					
						var me = this;
					this.bindClickEvent(this.startMarker, record, function(opts){
								return me.bindClickEventHTML(opts);
							},null, false,300);

					this._preLat = courseLat;
					this._preLng = courseLng;
					this._preRecord = record;
					this.hisRouteArray.push(this.startMarker);
				} else {
					//如果当前标记点超过了范围，则将地图移至中心点
					try {
						if (!this.beyondMapBound(courseLat, courseLng)) {
							this.setCenter(
									courseLat, courseLng);
						}
					} catch (e) {

					}
					// 这一次循环的时间
					var time = record.sendTime;
					this.currentRecord = record;
										
					var vehicleImageUrl = this.getRecordImageUrl(record);
					
					var txt = "["+record.plateNo+"],车速:"+record.velocity + "km/h,时间:"+record.sendTime;
					var label = this.createLabel(record.vehicleId,courseLat, courseLng, txt, 12, 8, 100);
					label.setPoint(this.createPoint(courseLat, courseLng));

					//车辆地图图标或者代表车辆行驶方向的箭头图标
					if (this.courseMarker == null) {
						this.courseMarker = this
								.createMarker(this.createPoint(
										courseLat, courseLng),
												vehicleImageUrl);
				        //this.courseMarker.setIconImage(vehicleImageUrl); 
						this.addOverlay(this.courseMarker);
						var me = this;
						this.bindClickEvent(this.courseMarker, record, function(data){
							    var opts = me.currentRecord;
								return me.bindClickEventHTML(opts);
							},null, false,300);
							
					    this.hisRouteArray.push(this.courseMarker);
					    this.hisRouteArray.push(label);

					} else {
						this.markerSetPosition(this.courseMarker,
								courseLat, courseLng);
					}

					// 绘制前一点的图标
					var currentMarker;
					if (this._nCount > 1) {
						var tempImageUrl = this.imgPath+"/track/point.png";	
						if(this._preRecord.alarmState > 0)
						{
						   tempImageUrl = this.imgPath+"/track/alarm.png";	
						}

						currentMarker = this.createMarker(
							this.createPoint(
								this._preLat,
								this._preLng
							), 
							 tempImageUrl
						)
				        //currentMarker.setIconImage(tempImageUrl); 
					
						var me = this;
						this
								.bindClickEvent(currentMarker, this._preRecord,
										function(opts){
											return me.bindClickEventHTML(opts);
										}	, this.drawGridCallback(this, this._preRecord.RowNum,
												this._preRecord.gpsId, this._preLat, this._preLng),
										false, 300);
						this.addOverlay(currentMarker);						
					    this.hisRouteArray.push(currentMarker);
					}

					//画线
					var line = this.drawLine([
							this.createPoint(this._preLat,
									this._preLng),
							this.createPoint(courseLat, courseLng) ]);		
					    this.hisRouteArray.push(line);
					this._preLat = courseLat;
					this._preLng = courseLng;
					this._preRecord = record;
				}
			
		}
		this._nCount++;
	//} catch (e) {
	//	alert(e);
	//}
}

MapOperationHandler.prototype.drawGridCallback = function(handler, id, vehicleId, lat, lng){
	return function() {
	}
}


/**
 * opts = {
 * 	 id       唯一标识
 *   text     名称
 *   lngLats  字符串经纬度
 *   show     是否显示在地图上
 *   type     矩形区域
 * }
 */
MapOperationHandler.prototype.createPolyline = function(points, color, weight, opacity) {
	//return this.createPolylineByString(opts.lngLats);
	//var string = opts.lngLats;
	//var points = this.stringToPoint(string);
	var polyline =  new SE.PolyLine(points, color || this._color, weight || this._weight, opacity || this._opacity);

	//var polyline =  this.createPolyline(this.stringToPoint(string));
	 SE.Event.bind(polyline,"mouseover",polyline,  function()
	{
		 this.setLineColor("red");  
	});  
            SE.Event.bind(polyline,"mouseout",polyline,  function()
	{this.setLineColor("blue");
	});  
		SE.Event.addListener(polyline,"click", function()
		{
			// alert("fuck you");
		});  
    this._oMap.addOverLay(polyline);

	return polyline;

}

MapOperationHandler.prototype.createPolygon = function(opts) {
	return this.createPolygonByString(opts.lngLats);
}

MapOperationHandler.prototype.createRect = function(bounds,color,bgcolor,weight,opacity){
	return new SE.Rect(bounds, color || this._color ,bgcolor || this._bgcolor ,weight || this._weight ,opacity || this._opacity);
}

MapOperationHandler.prototype.setDrawPolylineEndCallback = function(callback) {
	this.setDrawPolylineEndCallback(callback);
}

MapOperationHandler.prototype.setDrawRectEndCallback = function(callback) {
	this.setDrawRectEndCallback(callback);
}

MapOperationHandler.prototype.setDrawPolygonEndCallback = function(callback) {
	this.setDrawPolygonEndCallback(callback);
}

MapOperationHandler.prototype.setDrawPointEndCallback = function(callback) {
	this.setDrawPointEndCallback(callback);
}

MapOperationHandler.prototype.setMarkerMoveEndCallback = function(markerMoveEndCallback){
	this.markerMoveEndCallback = markerMoveEndCallback;
}

MapOperationHandler.prototype.setDragEndCallback = function(dragEndCallback){
	this.dragEndCallback = dragEndCallback;
}

MapOperationHandler.prototype.setConfigCenterPointCallback= function(callback){
	this.configCenterPointCallback = callback;
}

MapOperationHandler.prototype.stringToPoint = function(string){
	var points = new Array();
	var splits = string.split("#");
	for (var i=0;i<splits.length;i++){
		var lngLat = splits[i].split(",");
		if (lngLat != ""){
			points.push(this.createPoint(parseFloat(lngLat[1]), parseFloat(lngLat[0])));
		}
	}
	return points;
}

MapOperationHandler.prototype.createCircle = function(lat, lng, radius, opts){
	return new SE.Circle(this.createPoint(lat, lng), radius, opts || {});
}


MapOperationHandler.prototype.createTextLabel = function(id, lat, Lng, title, x, y, opacity) {
	var mapText = new SE.PointOverlay(this.createPoint(lat, Lng), [x || 0, y || 0]);
	mapText.setLabel(title || "");
	mapText.setOpacity(opacity || 100);
	return mapText;
};


MapOperationHandler.prototype.createPolygon = function(points, color, bgcolor, weight, opacity) {
	return new SE.Polygon(points,
			color || this._color ,bgcolor || this._bgcolor ,weight || this._weight ,opacity || this._opacity);
};
MapOperationHandler.prototype.changeLabelText = function(label, text) {
	label.setLabel(text);
};

/**
 * open 直接打开信息窗口
 */
MapOperationHandler.prototype.bindClickEvent = function(marker, opts, htmlfn, handle, open, width, height) {
	var operatorObj = this;
	
	var handler = this.eventBind(marker, "click", function() {
		if (typeof(opts) == "object"){
			operatorObj.openInfoWindowHtml(marker, htmlfn(opts), handle, width, height);
		}else{
			operatorObj.openInfoWindowHtml(marker, opts, handle, width, height);
		}
	});
	if (open) {
		if (typeof(opts) == "object"){
			operatorObj.openInfoWindowHtml(marker, htmlfn(opts), handle, width, height);
		}else{
			operatorObj.openInfoWindowHtml(marker, opts, handle, width, height);
		}
	}
	return handler;
};

MapOperationHandler.prototype.getBestMap = function(points, flag){
	this._oMap.getBestMap(points);
	if (flag){
		this._oMap.getBestMap(points);
	}
	
	var zoomLevel = this.getZoom();
	if (zoomLevel - 1 > 0){
		this.setZoom(zoomLevel - 1);
	}else{
		this.setZoom(zoomLevel);
	}
	
	
}


MapOperationHandler.prototype.openInfoWindowHtml = function(marker, html, handle, width, height) {
	if (!handle) handle = function(){};
	if (marker.setInfoWinWidth){
		marker.setInfoWinWidth(width || 300);
		marker.setInfoWinHeight(height || 150);
		var openInfoWinHtml = marker.openInfoWinHtml("");
		openInfoWinHtml.setLabel(html);
	}else{
		if (marker.suit){
			if (this.publicInfoWindow){
				this.removeOverlay(this.publicInfoWindow);
				this.publicInfoWindow = null;
			}
			
			if (!this.publicInfoWindow){
				this.publicInfoWindow = this.createInfoWindowObj(
					this.getPointLat(marker.suit), 
					this.getPointLng(marker.suit), 
					"", 
					html
				)
				this.addOverlay(this.publicInfoWindow);
			}
		}
	}
	//handle();
};

MapOperationHandler.prototype.computeScale = function(lat1, lng1, lat2, lng2){
	var mapDistance = GetDistance(lat1, lng1, lat2, lng2)/10;
	var deflevel = 2;
	if(mapDistance>0 && mapDistance<=0.1)
	{
		deflevel = 2;
	}
	else if(mapDistance>0.1 && mapDistance<=0.2)
	{
		deflevel = 3;
	}
	else if(mapDistance>0.2 && mapDistance<=0.4)
	{
		deflevel = 4;
	}
	else if(mapDistance>0.4 && mapDistance<=1)
	{
		deflevel = 5;
	}
	else if(mapDistance>1 && mapDistance<=2)
	{
		deflevel = 6;
	}
	else if(mapDistance>2 && mapDistance<=4)
	{
		deflevel = 7;
	}
	else if(mapDistance>4 && mapDistance<=10)
	{
		deflevel = 8;
	}
	else if(mapDistance>10 && mapDistance<=20)
	{
		deflevel = 9;
	}
	else if(mapDistance>20 && mapDistance<=40)
	{
		deflevel = 10;
	}
	else if(mapDistance>40 && mapDistance<=100)
	{
		deflevel = 11;
	}
	else if(mapDistance>100 && mapDistance<=180)
	{
		deflevel = 12;
	}
	else if(mapDistance>180 && mapDistance<=400)
	{
		deflevel = 13;
	}
	else if(mapDistance>400 && mapDistance<=800)
	{
		deflevel = 13;
	}
	else if(mapDistance>800)
	{
		deflevel = 13;
	}
	return deflevel;
}


MapOperationHandler.prototype.addOverlay = function(overlay) {
	this._oMap.addOverLay(overlay);
};

MapOperationHandler.prototype.markerSetImage = function(marker, imageUrl, width, height, anchorWidth, anchorHeight) {
	if (typeof(anchorWidth) != "undefined"){
		marker.setIconImage(imageUrl, new SE.Size(width, height), new SE.Point(anchorWidth, anchorHeight));
		return;
	}
	
	
	if (typeof(width) != "undefined"){
		marker.setIconImage(imageUrl, new SE.Size(width, height));
		return;
	}
	
	
	
	marker.setIconImage(imageUrl);
};


MapOperationHandler.prototype.removeListener = function(handler) {
	return SE.Event.removeListener(handler);
};


MapOperationHandler.prototype.labelSetPosition = function(label, lat, lng) {
	label.setPoint(this.createPoint(lat, lng));
};