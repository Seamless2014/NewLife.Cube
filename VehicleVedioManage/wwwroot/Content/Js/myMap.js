MyMap = {}
/**
	 *在地图上显示指定车辆的GPS数据
	 */
MyMap.showVehicleOnMap = function (vehicleId, alarmDescr)
	{
		//调用ajax方法获得车辆的实时数据
		var url = globalConfig.webPath + '/RealData.mvc/refreshRealData';
		var me = this;
	    $.getJSON(url, {vehicleId:vehicleId}, function(result)
		 {
			 if(result.success == false )
			 return;
             var rd = result.data;//GPS实时数据
             if (alarmDescr && rd.alarmStateDescr.indexOf(alarmDescr) < 0) {
                 if (rd.alarmStateDescr == "无")
                     rd.alarmStateDescr = alarmDescr;
                 else
                     rd.alarmStateDescr += "," + alarmDescr;
             }

			 //mytree.fillGrid(rd);//填充到车辆树底部的车辆属性表格中
		     var vehicleInfo = me.convertRecord(rd);
		     var mapHandler = me.getMapHandler();
		     if(mapHandler == null)
			    return;
		     mapHandler.centerMarkerOverlays(vehicleInfo, true,true); //调用map/js/base.js的方法
							
		});
	}
/**
	 *在地图上显示指定车辆的GPS数据
	 */
MyMap.showVehicleAlarmOnMap = function(vehicleId, alarmDescr)
	{
		//调用ajax方法获得车辆的实时数据
		var url = globalConfig.webPath +  '/RealData.mvc/refreshRealData';
		var me = this;
	    $.getJSON(url, {vehicleId:vehicleId}, function(result)
		 {
			 if(result.success == false )
			 return;
			 var rd = result.data;//GPS实时数据
			 if(alarmDescr == null)
			 {
				 alarmDescr = ""+AlarmGrid.alarmMap[rd.plateNo];
			 }
			 if(rd.alarmStateDescr.indexOf(alarmDescr) <= 0)
			 {
				 if(rd.alarmStateDescr == "无")
					 rd.alarmStateDescr = alarmDescr;
				 else
				     rd.alarmStateDescr += ","+ alarmDescr;
			 }
			 //mytree.fillGrid(rd);//填充到车辆树底部的车辆属性表格中
		     var vehicleInfo = me.convertRecord(rd);
		     var mapHandler = me.getMapHandler();
		     if(mapHandler == null)
			    return;
		     mapHandler.centerMarkerOverlays(vehicleInfo, true,true); 
							
		});
	}


MyMap.createMarkerByGpsData = function(gpsdata)
{
	var vehicleInfo = this.convertRecord(gpsdata);
	var mapHandler = this.getMapHandler();
	mapHandler.showMarkers([vehicleInfo]);
	//this.getMapHandler().centerMarkerOverlays([vehicleInfo], false,false); 
}


MyMap.showVehicleListOnMap = function(gpsRealDataList,changeViewPoint,onlyUpdate)
{	
	var mapHandler = this.getMainMapHandler();
	//mapHandler.clearAllVehicle();
    mapHandler.showVehicleList(gpsRealDataList,changeViewPoint,onlyUpdate);

}


//清除地图的实时车辆地标
MyMap.clearAllVehicle = function()
{
	var mapHandler = this.getMapHandler();
	mapHandler.clearAllVehicle();
}


	//得到地图监控窗口中的地图对象
MyMap.getMapHandler = function()
	{
		var iframeWindow = $("#mapFrame")[0];  
		if(iframeWindow)
		    return iframeWindow.contentWindow.OperatorObj; //得到地图页面上的javascript 地图对象，便于主界面调用

		return null;
	}

MyMap.getMainMapHandler = function()
	{		
		var iframeWindow = $("#mapFrame")[0];  
		//var refresh_tab = $('#mainTab').tabs('getSelected');  
		//var title = refresh_tab.panel('options').title; 
		if(iframeWindow)
		    return iframeWindow.contentWindow.OperatorObj; //得到地图页面上的javascript 地图对象，便于主界面调用

		return null;
	}

function getStartPOIData(keyword)
{
	if(keyword.length < 2)
		return;

	MyMap.getMapHandler().keyword = keyword;
	
	MyMap.startPOISearch.search(keyword,{forceLocal:true});
}
function getEndPOIData(keyword)
{
	if(keyword.length < 4)
		return;
	MyMap.getMapHandler().keyword = keyword;
	
	MyMap.endPOISearch.search(keyword,{forceLocal:true});
}

/**
 * 初始化地点搜索输入框的autocomplete控件，以来jquery.autocomplete.js
 */
MyMap.initAutoComplete =  function()
{
	var me =this;
	var startPOI = $("#startPOI");
	startPOI.autocomplete('url', {
	    dataCallback:getStartPOIData,
		minChars: 2,
		max: 12,
		autoFill: false,
		mustMatch: false,
		matchContains: false,
		scrollHeight: 220,
		formatItem: function(data, i, total) {
			var name = data.title + ", " + data.address;
			return name;
		}
	}).result(function(event, data, formatted) {
		me.startPoint = data;
	});
	
	var endPOI = $("#endPOI", window.parent.parent.document);
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
	}).result(function(event, data, formatted) {
		me.endPoint = data;
	});
	
	this.startPOISearch = this.getMapHandler().createLocalSearch(function(term,data)
	{
		startPOI.fillData(term,data);
	});
	this.endPOISearch = this.getMapHandler().createLocalSearch(function(term,data)
	{
		endPOI.fillData(term,data);
	});

	$("#btnPlanRoute").click(function()
	{
		me.getMapHandler().planDriveRoute(me.startPoint, me.endPoint);

	});
}



MyMap.convertRecord = function(rd)
    {
	 rd.orgLatitude = parseFloat(rd.orgLatitude).toFixed(6);
	 rd.orgLongitude = parseFloat(rd.orgLongitude).toFixed(6);
	 rd.gas = parseFloat(rd.gas).toFixed(1);
	 rd.mileage = parseFloat(rd.mileage).toFixed(1);
	 rd.velocity = parseFloat(rd.velocity).toFixed(1);
	 rd.recordVelocity = parseFloat(rd.recordVelocity).toFixed(1);
      var vehicleInfo = {id:rd.vehicleId, text:rd.plateNo, vehicleId:rd.vehicleId, rLat:rd.latitude,rLng:rd.longitude, tLat:rd.latitude, tLng:rd.longitude,status:rd.status,color:rd.plateColor,validate:rd.valid,direction:rd.direction,
							  angleInt:rd.direction, statusInt:0, speed:rd.velocity, warnTypeId:0, online:rd.online};
	   
	 var merged = $.extend({}, rd, vehicleInfo);
	 return merged;

    }
