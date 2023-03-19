
function BaiduMapHandler(_map)
{
     this.map = _map;
	 this.gpsDataMap = {}; //保存当前的实时数据,以GpsRealData表的Id为主键

	 this.markerMap = {};//保存当前的实时marker,以GpsRealData表的Id为主键
	 this.areaMap = {};//保存当前的区域overlay和文本标注,已Enclosure围栏表的id为主键.
	 
	 
	this._endIconImageUrl = "images/track/end.gif";//结束地点图标

	this.realDataMap = {};
	//轨迹中回放中的marker, 线等，便于批量清楚
	this.routeOverlays = new Array();
}
/**
 * 将区域对象和对应的文本标注，保存在hash表中，便于调用和删除
 * @enclosureId, 围栏的主键Id
 */
BaiduMapHandler.prototype.cacheAreaOverlay = function(enclosureId, overlay, label)
{
	this.areaMap[enclosureId] = {overlay:overlay,label:label};
}
BaiduMapHandler.prototype.getAreaOverlay = function(enclosureId)
{
	return this.areaMap[enclosureId];
}

/**
 * 根据车速、方向、报警和上线状态来生成车辆地标
 */
BaiduMapHandler.prototype.getRecordImageUrl = function(direction, speed, online, alarm){
	if(!direction)
		direction = 0;
	var img = setAngleImage(direction);
	if (typeof(alarm) != "undefined" && parseInt(alarm) != 0){
			return "images/alarm/" + img;
	}else{
			if (online){
				return "images/direction/" + img;
			}else{
				return "images/direction/off/" + img;
			}
		
	}
}
//**************************************************************带数据表格的轨迹绘制
BaiduMapHandler.prototype.drawRoute = function(record) {
				record = convertRecord(record);
				var courseLat =parseFloat(record.latitude);
				var courseLng = parseFloat(record.longitude);
 
				if (this.startMarker == null) {
					var iconPath = "images/track/start.gif";
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
					
					// var imageUrl = "images/direction/arrow-" + setAngleImage(record.get("angleInt"));
					
					var imageUrl = this.getRecordImageUrl(record.direction, record.speed, true, record.alarm);
					
		            var currentPos = new BMap.Point(record.longitude, record.latitude);
					if (this.courseMarker == null) {
						var icon = this.createIcon(imageUrl,32);
						this.courseMarker = this.addMarker(record.longitude, record.latitude,
							 icon, record, false);
						
					    this.routeOverlays.push(this.courseMarker);
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
						
						var tempImageUrl = "images/toolbar/point.png";	
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
	var icon = this.createIcon(this._endIconImageUrl,39,25);
	this.endMarker = this.addMarker(this.courseMarker.getPosition().lng, this.courseMarker.getPosition().lat, icon);
	this.routeOverlays.push(this.endMarker);
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
  * 根据id删除电子围栏
  */
BaiduMapHandler.prototype.removeMapArea = function(enclosureId)
{
      var area = this.areaMap[enclosureId];
	  if(area)
	{
		  this.map.removeOverlay(area.overlay);
		  this.map.removeOverlay(area.label);
	}else
	{
		//alert("该区域不存在，无法删除");
	}
}

BaiduMapHandler.prototype.setCenter = function(lat, lng,zoom)
{    
	if(!zoom)
		zoom = this.map.getZoom();
	this.map.centerAndZoom(new BMap.Point(lng, lat), zoom);
}
/**
 * 批量在地图上显示gps车辆地标
 * @gpsDataArray页面传送的gps数据，可以同时显示多个地标，所以是数组
 * @isOpenInfoWindow 是否打开信息窗口
 */
BaiduMapHandler.prototype.centerMarkerOverlays=function(gpsDataArray, isOpenInfoWindow,isCenter)
{
	 for (var i = 0; i < gpsDataArray.length; i++) {
		 var gpsData = gpsDataArray[i];
		 if(gpsData.longitude < 1 || gpsData.latitude < 1)
			 continue;
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
			 this.map.removeOverlay(oldRealDataMarker.marker);			
			 this.map.removeOverlay(oldRealDataMarker.label);		
		}
		
	     var iconPath = this.getRecordImageUrl(gpsData.direction, gpsData.speed, gpsData.online,gpsData.alarmState);
		 var icon = this.createIcon(iconPath, 32);
		// isOpenInfoWindow = false;
		 var marker = this.addRealDataMarker(gpsData.longitude, gpsData.latitude, icon, gpsData, isOpenInfoWindow);
		
		 var label = this.createMarkerLabel(gpsData.vehicleId, gpsData.latitude, gpsData.longitude, descr,32);
	     this.realDataMap[gpsData.vehicleId] = {marker:marker, label:label, gpsData:gpsData};
		
		 if(isCenter)
		    this.setCenter(gpsData.latitude, gpsData.longitude);
		 //this.addGoogleMarker(marker);
	}
}


BaiduMapHandler.prototype.getStartPOIData = function(keyword)
{
	this.keyword = keyword;
	
	this.startPOISearch.search(keyword);
}
BaiduMapHandler.prototype.getEndPOIData = function(keyword)
{
	this.keyword = keyword;
	
	this.endPOISearch.search(keyword);
}
/**
 * 初始化地点搜索输入框的autocomplete控件，以来jquery.autocomplete.js
 */
BaiduMapHandler.prototype.initAutoComplete =  function()
{
	var startPOI = $("#startPOI", window.parent.parent.document);
	startPOI.autocomplete('url', {
	    dataCallback:getStartPOIData,
		minChars: 0,
		max: 12,
		autoFill: false,
		mustMatch: false,
		matchContains: true,
		scrollHeight: 220,
		formatItem: function(data, i, total) {
			var name = data.title + ", " + data.address;
			return name;
		}
	});
	
	var me = this;
	var options = {
		onSearchComplete: function(results){
			// 判断状态是否正确
			if (local.getStatus() == BMAP_STATUS_SUCCESS){
				var poiList = [];
				for (var i = 0; i < results.getCurrentNumPois(); i ++){
					var poi = results.getPoi(i);
					var name = poi.title + ", " + results.getPoi(i).address;
					var code = i;
					poiList.push({result:name,value:i,data:poi});
				}
				startPOI.fillData(me.keyword,poiList);
			}
		}
	   };
	this.startPOISearch = new BMap.LocalSearch(map, options);

	
	var endPOI = $("#startPOI", window.parent.parent.document);
	endPOI.autocomplete('url', {
	    dataCallback:getEndPOIData,
		minChars: 0,
		max: 12,
		autoFill: false,
		mustMatch: false,
		matchContains: true,
		scrollHeight: 220,
		formatItem: function(data, i, total) {
			var name = data.title + ", " + data.address;
			return name;
		}
	});
	
	var me = this;
	var options = {
		onSearchComplete: function(results){
			// 判断状态是否正确
			if (local.getStatus() == BMAP_STATUS_SUCCESS){
				var poiList = [];
				for (var i = 0; i < results.getCurrentNumPois(); i ++){
					var poi = results.getPoi(i);
					var name = poi.title + ", " + results.getPoi(i).address;
					var code = i;
					poiList.push({result:name,value:i,data:poi});
				}
				endPOI.fillData(me.keyword,poiList);
			}
		}
	   };
	this.endPOISearch = new BMap.LocalSearch(map, options);
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


BaiduMapHandler.prototype.addRealDataMarker = function(lng, lat, icon, opt,isOpenInfoWindow)
{
   var pt = new BMap.Point(lng, lat);
   //var myIcon = new BMap.Icon(iconPath, new BMap.Size(16,16));
   var marker = new BMap.Marker(pt,{icon:icon});  // 创建标注
   this.map.addOverlay(marker);              // 将标注添加到地图中   
   if(opt)
	{
	   var vehicleId = opt.vehicleId;
       var me = this;
	   marker.addEventListener("click", function(){
			me.openInfoWindow(vehicleId);
			//me.openHtmlWindow(marker,htmlContent);
	       // var markerInfoWindow = new BMap.InfoWindow(htmlContent);
			//marker.openInfoWindow(markerInfoWindow);
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

BaiduMapHandler.prototype.createMarkerLabel=function(id, lat, lng, text, offsetY)
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
			 background:"#CCFFCC",
			 lineHeight : "20px",
			 fontFamily:"微软雅黑"
		 });
	map.addOverlay(label);
	return label;
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
		var vehicleDirectionImagUrl = "images/direction/"
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
			var directionImagUrl =  "images/toolbar/point.png";
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
