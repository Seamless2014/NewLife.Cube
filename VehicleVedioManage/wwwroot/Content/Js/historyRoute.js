HistoryRoutePanel = {};
HistoryRoutePanel._isOver = true;//播放结束标志
HistoryRoutePanel._isPlay = false;//正在播放的状态
HistoryRoutePanel.timerId = null;//定时器ID
HistoryRoutePanel.playSpeed = 500;//播放速度,
HistoryRoutePanel._autoChangePage = true;//自动翻页播放
HistoryRoutePanel.totalNum = 0;//总记录数
HistoryRoutePanel.maxTimeSpan = 500;//最大播放间隔,每隔200ms，播放一次


HistoryRoutePanel.getRouteMapHandler = function()
{
	return this.routeMapHandler;
}

HistoryRoutePanel.setPlateNo = function(plateNo)
{
	//$("#routePlateNo").val(plateNo);
	$("#routePlateNo").textbox('setText',plateNo);
}

HistoryRoutePanel.isButtonDisabled = function(btnId)
{
	var opts = $("#"+btnId).linkbutton("options");
	return   true == opts.disabled;
}

HistoryRoutePanel.setButtonText = function(btnId,txt)
{
	$("#"+btnId+" .l-btn-text").html(txt);
}


HistoryRoutePanel.resetButton = function()
{
	HistoryRoutePanel.setButtonText("btnQueryHisData","查询");
	$("#btnQueryHisData").linkbutton('enable');
	$("#btnPlayRoute").linkbutton('disable');
	$("#btnPauseRoute").linkbutton('disable');
	$("#btnStopPlayRoute").linkbutton('disable');
}

HistoryRoutePanel.init = function()
{
	var me = this;
	
	this.createhistoryRouteGrid();
	this._playButton = $("#btnPlayRoute");
	//  this._playButton.html("播放");
	$("#btnQueryHisData").click(function()
	{
		var plateNo = $("#routePlateNo").textbox("getText");
		if(plateNo== null || plateNo.length == 0)
		{
			$.messager.alert("提示","请输入有效车牌号!");
			return;
		}
		if(me.isButtonDisabled("btnQueryHisData"))
			return;
	   
		HistoryRoutePanel.queryHistoryRoute();
	});
	$("#btnPlayRoute").click(function()
	{
		if(me.isButtonDisabled("btnPlayRoute"))
			return;
		//this.routeMapHandler.drawLocationWithGrid(this);
		me.play();
	});
	$("#btnStopPlayRoute").click(function()
	{
		if(me.isButtonDisabled("btnStopPlayRoute"))
			return;
		me.stopPlay();
	});
	
	$("#btnPauseRoute").click(function()
	{
		if(me.isButtonDisabled("btnPauseRoute"))
			return;
		me.pause();
	});

	//excel导出
	$("#btnExportHisData").click(function()
	{
		me.exportExcel();
	});
	//播放速度滑块
	$('#playSpeedSlider').slider({
		value:1,showTip:true,
		tipFormatter: function(value){    
			//var speed = me.maxTimeSpan - parseInt(value);
			var descr = "慢";
			if(value > 60)
				descr = "快";
			else if(value > 40)
				descr = "中";
			return descr;    
		},
		onChange: function(value){
			me.playSpeed = me.maxTimeSpan * (100 - parseInt(value)) / 100;

		}
	})



	$("#cbDisplayHisData").click(function()
	{
		//判断是否已经打勾
		if($("#cbDisplayHisData").attr('checked')=="checked"){
	         $('#hisRouteLayout').layout('expand','south');
			 //var tab = $("#hisDataTab").tabs("getTab",0);
			 //var width = tab.width();
			 //var height = tab.height();
		    // me.hisDataGrid.datagrid('resize',{width:width-1,height:height-1,left:0,top:0});
		} else
		{
	         $('#hisRouteLayout').layout('collapse','south');
		}
	});
	$('#hisRouteLayout').layout('collapse','south');
	//this.createhistoryRouteGrid(gridId);
	//设置在线地图路径
	$("#routeMapFrame").attr("src", globalConfig.mapPath);

	
	//日期类型拉框触发事件，快捷的选择日期
		$('#selDateOption').combobox(
		{
			onChange :function(newValue,oldValue){ 
				var filterType = newValue;
	            var now = Utility.today();
				if(filterType == "1")
				{
					//当天
					var startTime = now + " 00:00:00";
					var endTime = now + " 23:59:00";
					$("#routeStartTime").datetimebox('setValue', startTime)  ;
					$("#routeEndTime").datetimebox('setValue', endTime);

				}else if(filterType == "2")
				{
					//昨天
					var now = new Date();
	                var date1 = new Date(now.getFullYear(),now.getMonth(),now.getDate());
					date1 = Utility.addDay(date1,-1);
					var yesterday = Utility.dateToString(date1, "yyyy-MM-dd");;
					var startTime = yesterday + " 00:00:00";
					var endTime = yesterday + " 23:59:00";
					$("#routeStartTime").datetimebox('setValue', startTime)  ;
					$("#routeEndTime").datetimebox('setValue', endTime);
				}else if(filterType == "3")
				{
					//前天
					var now = new Date();
	                var date1 = new Date(now.getFullYear(),now.getMonth(),now.getDate());
					date1 = Utility.addDay(date1,-2);
					var yesterday = Utility.dateToString(date1, "yyyy-MM-dd");
					var startTime = yesterday + " 00:00:00";
					var endTime = yesterday + " 23:59:00";
					$("#routeStartTime").datetimebox('setValue', startTime)  ;
					$("#routeEndTime").datetimebox('setValue', endTime);

				}else if(filterType == "4")
				{
					//最近一天
					var date1 = new Date();
					var endTime = Utility.dateToString(date1, "yyyy-MM-dd HH:mm:ss");
					
					date1 = Utility.addDay(date1,-1);
					var startTime = Utility.dateToString(date1, "yyyy-MM-dd HH:mm:ss");

					$("#routeStartTime").datetimebox('setValue', startTime)  ;
					$("#routeEndTime").datetimebox('setValue', endTime);
				}else if(filterType == "5")
				{
					//最近一天
					var date1 = new Date();
					var endTime = Utility.dateToString(date1, "yyyy-MM-dd HH:mm:ss");
					
					date1 = Utility.addDay(date1,-2);
					var startTime = Utility.dateToString(date1, "yyyy-MM-dd HH:mm:ss");

					$("#routeStartTime").datetimebox('setValue', startTime)  ;
					$("#routeEndTime").datetimebox('setValue', endTime);
				}
		    }
		});

	//当选择开始时间的时候，自动检测日期段天数只差，如果超过2天，则自动修改结束时间，
	//使其最大天数差保持为2.
	$("#routeStartTime").datetimebox({'onSelect': function(date)
	{
	   var strEndTime = $("#routeEndTime").datetimebox('getText');
	   startTime = date;
	   endTime = Utility.stringToDate(strEndTime);
	   if(isNaN( startTime.getTime() ) || isNaN(endTime.getTime() ) )
	   {
			$.messager.alert('提示','非法的日期格式'); 
	   }
	   var  iDays = Utility.getDay(startTime,endTime);  
	   if(iDays > 2 || iDays <= 0)
	   {
		   startTime = Utility.addDay(startTime,1);//加一天
		   var strEndTime = Utility.dateToString(startTime, "yyyy-MM-dd") + " 23:59:00";
		   $("#routeEndTime").datetimebox('setValue', strEndTime)  ;
	   }
		
	}})  ;
	//设置为当天
	var now = Utility.today();
	var startTime = now + " 00:00:00";
	var endTime = now + " 23:59:00";
	$("#routeStartTime").datetimebox('setValue', startTime)  ;
	$("#routeEndTime").datetimebox('setValue', endTime);
}
/**
 * 根据查询条件进行excel导出
 */
HistoryRoutePanel.exportExcel = function()
{
	var routeForm = $('#routeForm');
	 var queryUrl =  globalConfig.webPath+'/Query.mvc/paginate';
	 this.routeMapHandler = this.getHisMapHandler();
	 //this.routeMapHandler.clearAllElement();
	 routeForm.form({
		url:queryUrl,
		onSubmit: function(){
			//进行表单验证
			//如果返回false阻止提交
			var isValid =   routeForm.form('validate'); 
			if(isValid)
			{
				var plateNo = $("#routePlateNo").textbox("getText");
				var startTime = $("#routeStartTime").datetimebox('getValue')  ;
				var endTime = $("#routeEndTime").datetimebox('getValue');
				var minSpeed = $("#minSpeed").val();
				var excelFileName="GPS历史轨迹";
				var queryParams = {queryId:"selectHisotryGpsInfos",
							fileName:excelFileName,
					plateNo:plateNo,startTime:startTime,endTime:endTime,minSpeed:minSpeed,valid:1};
			    var strParam = jQuery.param(queryParams);
				var url = globalConfig.webPath + "/Query.mvc/export?"+strParam;
						//openWindow(url, 300,300,"");
				window.open(url);
			}
			return false;
		},
		success:function(data){
			//alert(data)
			//me.hisDataGrid.datagrid("loadData",data);
		}
	});
	//提交表单
	$('#routeForm').submit();
}

/**
 * 历史轨迹数据分页表格
 */
HistoryRoutePanel.createhistoryRouteGrid = function()
{
	//if(this.hisDataGrid)
		//return;
	var queryParams = {};//{plateNo:"测A00003",startTime:"2014-09-29 1:1:1",endTime:"2014-09-29 23:1:1"};
	var queryUrl =  globalConfig.webPath+'/HistoryGpsInfo.mvc/paginate';
	var gridId = "hisDataGrid";
    this.hisDataGrid=	$("#"+gridId);	
    this.hisDataGrid.datagrid({
                columns: [[
                    { title: '车牌号', field: 'plateNo', width: 80,minWidth:80 },
                    { title: '所属车组', field: 'depName', width: 120,minWidth:80 },
                    { title: 'sim卡号', field: 'simNo', width: 120,minWidth:80 },
                    { title: '颜色', field: 'plateColor', width: 40,minWidth:40 },
                    { title: '时间', field: 'sendTime', width: 130,minWidth:120 },
                    { title: '位置', field: 'location', width: 240,minWidth:240 },
                    { title: '状态', field: 'status', width: 80,minWidth:80 },
                    { title: '速度', field: 'velocity', width: 40,minWidth:40 },
                    { title: '脉冲速度', field: 'recordVelocity', width: 40,minWidth:40 },
                    { title: '方向', field: 'directionDescr', width: 80,minWidth:80 },
                    { title: '里程', field: 'mileage', width: 60,minWidth:60 },
                    { title: '油量', field: 'gas', width: 60,minWidth:60 },
                    { title: '有效性', field: 'valid', width: 40,minWidth:40 },
                    { title: '海拔', field: 'altitude', width: 40,minWidth:40 },
                    { title: '经度', field: 'longitude', width: 90, isSort: false,minWidth:80 },
                    { title: '纬度', field: 'latitude', width: 90, isSort: false,minWidth:80 },
                    { title: '经度', field: 'orgLongitude', width: 0},
                    { title: '纬度', field: 'orgLatitude', width: 0 },
                    { title: '经度', field: 'gpsId', width: 0},
                    { title: '经度', field: 'orgLongitude', width: 0},
					{field:'memberName',title:'户主',width:0},
					{field:'vehicleType',title:'车型',width:0},
					{field:'industryType',title:'行业',width:0},
					{field:'driverId',title:'驾驶员ID',width:0},
					{field:'driverName',title:'驾驶员',width:0},
					{field:'alarmStateDescr',title:'报警',width:0},
					{field:'gpsId',title:'ID',width:0},
					{field:'alarmState',title:'报警ID',width:0}
                    ]],
                //height: 150,
				fit:true,
				url: queryUrl,
				method: 'POST',
				queryParams: queryParams,
				//idField: 'gpsId',
				striped: true,
				fitColumns: false,
				singleSelect: true,
				rownumbers: true,
				pagination: true,
				nowrap: true,
				pageSize: 50,
				pageList: [10, 20, 50, 100, 150, 200],
				showFooter: true,
				onBeforeLoad:function(param)
				{
					//在没有输入查询参数前，不查询
					if(param.plateNo)
					  return true;
				    else
					  return false;
				},onLoadSuccess:function(data)
				{
					
					if(data.rows && data.rows.length > 0)
					 {
					   HistoryRoutePanel.startPlayRoute(data); //开始画轨迹
					}else
					{
						 HistoryRoutePanel.resetButton();
						 $.messager.alert('提示','该时间段没有历史轨迹数据');
						 return;
					}
				}
            });
			
     return this.hisDataGrid;	
}

//设置历史轨迹播放的进度
HistoryRoutePanel.setProgress = function(value)
{
	$('#routeProgressbar').progressbar('setValue', value);
}

//查询历史轨迹
 HistoryRoutePanel.queryHistoryRoute = function()
 {
	var me = this;
	 var routeForm = $('#routeForm');
	 var isValid =   routeForm.form('validate'); 
	 if(isValid == false ||  me.validateDate() ==false)
			{
				return;
			}
	var queryUrl =  globalConfig.webPath+'/HistoryGpsInfo.mvc/List';
	 this.routeMapHandler = this.getHisMapHandler();
	 this.routeMapHandler.clearHisRoute();
	 var isChecked = $("#cbShowRouteBeforePlay").attr('checked');
	 me.routeMapHandler.showRouteBeforePlay=(isChecked=="checked");
     var plateNo = $("#routePlateNo").textbox('getText');
	 var startTime = $("#routeStartTime").datetimebox('getText');
	 var endTime = $("#routeEndTime").datetimebox('getText');
	 var minSpeed = $("#minSpeed").val();
	 var queryParams = {plateNo:plateNo,startTime:startTime,endTime:endTime,minSpeed:minSpeed,valid:"1"};
	 $.messager.progress({ 
					text: '正在加载历史轨迹数据' 
				});

     $("#hisMileage").html("");//清除里程显示
	 $.ajax({
            type: "POST",
            url: queryUrl,
			data:queryParams,
            success: function(data){
				$.messager.progress('close'); 
				var result=data;//eval("("+strReult+")");  
				if(result.success)
				{
					if(result.data && result.data.length > 0)
					{
					    var dataLen = result.data.length;
					    var startMileage= result.data[0].mileage;
					    var endMileage =result.data[dataLen - 1].mileage;
						var totalMileage = endMileage - startMileage;
						$("#hisMileage").html("行驶总里程:" + totalMileage.toFixed(1) + "公里");
					}
					//var data = {rows:result.data};
					me.hisDataGrid.datagrid("loadData", result.data);
					me.startPlayRoute(result.data);
				}else
				{
					me.resetButton();//重新恢复按钮可用性
					alert(result.message);
				}
			},
			error:function()
		    {
				me.resetButton();//重新恢复按钮可用性
			    $.messager.progress('close'); 
			}
	 });
 }

  HistoryRoutePanel.validateDate = function()
 {
	   var startTime = $("#routeStartTime").datetimebox('getText');
	   var endTime = $("#routeEndTime").datetimebox('getText');
	   startTime = Utility.stringToDate(startTime);
	   endTime = Utility.stringToDate(endTime);
	   if(isNaN( startTime.getTime() ) || isNaN(endTime.getTime() ) )
	   {
			$.messager.alert('提示','非法的日期格式'); 
	   }
	   var today = new Date();

	   var date1 = new Date(startTime.getFullYear(),startTime.getMonth(),startTime.getDate());
	   var date2 = new Date(endTime.getFullYear(),endTime.getMonth(),endTime.getDate());
		if(startTime > today)
		{
			$.messager.alert('提示','开始日期不能大于当前日期'); 
			return false;
		}
		if(startTime >= endTime)
		{
			$.messager.alert('提示','开始时间不能大于等于结束时间'); 
			return false;
		}

		var  iDays = Utility.getDay(date1,date2);  
		if(iDays > 2)
		{
			$.messager.alert('提示', '一次只能查询不超过两天的历史数据'); 
			return false;
		}
		return true;
 }

 //重新回到第一页播放
 HistoryRoutePanel.firstPage = function()
 {
	 this.hisDataGrid.datagrid("load");
 }

 HistoryRoutePanel.nextPage = function()
 {
	 //this.hisDataGrid.datagrid('getPager').pagination({pageNumer:2});
	 //$(".pagination-next")
	 //this.hisDataGrid.datagrid('reload');
	 var p = this.hisDataGrid.datagrid('getPager');
	 var p1 = p.find(".pagination-next");
	 p1.click();
	 //p.find(".pagination-next]").click();
	 //p.selectPage(
 }

HistoryRoutePanel.getCurPageData = function()
{
	return this.hisDataGrid.datagrid('getRows');
}

HistoryRoutePanel.getCurRowData = function()
{
	return this.hisDataGrid.datagrid('getSelected');
}

HistoryRoutePanel.isLastPage = function()
{
	var options = this.hisDataGrid.datagrid('getPager').data("pagination").options;  
	var pageSize = options.pageSize;
	var total = options.total;
	if(pageSize == 0 || total == 0)
		return true;
	var pageNum =  Math.ceil(total/ pageSize);
	return options.pageNumber == pageNum;
}

HistoryRoutePanel.selectRow = function(rowNo)
{
	this.hisDataGrid.datagrid('selectRow',rowNo);
}

HistoryRoutePanel.stopPlay = function()
{
	this._isOver = true;
	HistoryRoutePanel.resetButton();
	 
	$("#btnPlayRoute").linkbutton('enable');
	window.clearInterval(HistoryRoutePanel.timerId);
	this.timerId = null;
	this._isOver = true;
	this._intervalId = null;
	this.firstPlay = false;
	this._isPlay = false;
	this._nCount = 0;
	this._preLat = null;
	this._preLng = null;
	//this._playButton.html("播放");
	
    var mapHandler = this.routeMapHandler;
	if (mapHandler){
		mapHandler.drawStop();
	}
}

HistoryRoutePanel.play = function()
{
    if (!this._isPlay) {
	 this._isPlay = true;
	 this._isPause = false;
	   
	 $("#btnPauseRoute").linkbutton('enable');
	 $("#btnPlayRoute").linkbutton('disable');
	 
	 if (this._isOver == true) {
		 //重新播放时，清除掉原有的轨迹
		  this._isOver = false;
		this.firstPage();
		this.routeMapHandler.clearHisRoute(); //
		this.startPlayRoute(this.records);
		return;
	 }else
	 {
		 //从暂停处，开始播放
		 var me = this;
		 this.timerId = window.setInterval(function() {
						me.PlayWithoutGrid()
		 }, this.playSpeed);
	 }

   }

}

HistoryRoutePanel.pause = function()
{
	 $("#btnPauseRoute").linkbutton('disable');
	 $("#btnPlayRoute").linkbutton('enable');
	 this._isPlay = false;
	 this._isPause = true;
	 if (this.timerId != null) {
	     window.clearInterval(this.timerId);
		 this.timerId = null;
	 }

}
//得到历史轨迹回放的地图对象，调用baidu.jsp中的地图对象
HistoryRoutePanel.getHisMapHandler = function()
{
	 var iframeDom = $("#routeMapFrame")[0];
	 return iframeDom.contentWindow.OperatorObj;
}

 HistoryRoutePanel.startPlayRoute = function(records)
 {
	if(this.routeMapHandler == null)
		 return;
	 this.records = records;
	 //播放车辆轨迹前，先一次性生成轨迹
	 if(this.routeMapHandler.showRouteBeforePlay==true)
	 {
	     this.routeMapHandler.drawHisRoute(records);
	 }
	 $("#btnQueryHisData").linkbutton('disable');
	 $("#btnStopPlayRoute").linkbutton('enable');
	 $("#btnPauseRoute").linkbutton('enable');
     HistoryRoutePanel.setButtonText("btnQueryHisData","正在回放..");
	 
	 //this.routeMapHandler.setGrid(this);
	 this.routeMapHandler._playButton = $("#btnPlayRoute");
	 

	// var playSpeed = $('#playSpeed').slider("getValue");//播放速度
	 //var maxTimeOut = 200;
	 //this._nTimeOut = (maxTimeOut - parseInt(playSpeed));
     //var total = options.total;  
	 var curPageData = this.getCurPageData();
	 var curPageSize = curPageData.length;
	 this.totalNum = records.length;
     this._nCurrentPageSize = curPageSize;
	 this._nCount = 0 ;
	 this._isOver = false;
	 this._isPause = false;
	 this.autoChangePage = (true);
	 var me = this;
	 if(this.timerId)
	 {
		 this.routeMapHandler.drawStop();
		 this._timerId = null;
	 }
	 //console.log("创建计时器:"+ routeMapHandler.timerId);
	 this.timerId = setInterval(
					function(){
						me.PlayWithoutGrid();
					},
					this.playSpeed);
			
	 
 }


 HistoryRoutePanel.convertRecord = function(rd)
 {
     // var vehicleInfo = {id:rd.ID, text:rd.plateNo, vehicleId:rd.ID, rLat:rd.latitude,rLng:rd.longitude, tLat:rd.latitude, tLng:rd.longitude,status:rd.status,color:rd.plateColor,validate:rd.valid,direction:rd.direction,
							//  angleInt:rd.direction, statusInt:0, speed:rd.velocity, warnTypeId:0, online:rd.online};
	 // return vehicleInfo;

 }


 HistoryRoutePanel.PlayWithoutGrid = function() {
	 if(this._isOver || this._isPause )
		 return;
	
		if (this.isLastPage() == true) {
			 this.stopPlay();//播放结束
			 return;
		}
		if (!this._isPlay)
			this._isPlay = true;
			//设置表格显示正在播放的行上
		//this._gridSelectionModel.select(this._nCount, true);
		this.selectRow(this._nCount);
			//var index = this._nCount + (this._nCurrentPage - 1) * this._defaultPageSize;
		var record = this.records[this._nCount];
		if (record) 
			{
				record.online = true;
				this.routeMapHandler.drawRoute(record);//画出历史轨迹
				if(this.totalNum > 0)
				{
					var progress = parseInt(100 * (record.RowNum / this.totalNum));
					this.setProgress(progress);
				}
			}
		
		this._nCount++;
}

 HistoryRoutePanel.PlayWithGrid = function() {
	 if(this.isOver)
		 return;
	
		if (this._nCount == this._nCurrentPageSize) {
			//当前页的记录已经播放完毕，需要翻页，继续播放
			if (this.isLastPage() == false) {
				if (this._autoChangePage) {
					this._nCount = 0;
					this._isPlay = false;
					if (this.timerId != null) {
						window.clearInterval(this.timerId);
						this.timerId = null;
					}
					this.nextPage();
				} else {
					//this._drawPlayWithGrigEnd();
				}
			} else {
				this.stopPlay();//播放结束
			}
		} else {

			if (!this._isPlay)
				this._isPlay = true;
			//设置表格显示正在播放的行上
			//this._gridSelectionModel.select(this._nCount, true);
			this.selectRow(this._nCount);
			//var index = this._nCount + (this._nCurrentPage - 1) * this._defaultPageSize;
			var record = this.getCurRowData();
			if (record) {
				record.online = true;
				this.routeMapHandler.drawRoute(record);//画出历史轨迹
				if(this.totalNum > 0)
				{
					var progress = parseInt(100 * (record.RowNum / this.totalNum));
					this.setProgress(progress);
				}
			}
		}
		this._nCount++;
}
