RealDataGrid = {};
RealDataGrid.selectVehicleIds="";//需要刷新的车辆id
//表格当前选中的实时数据的车辆Id及车牌号
RealDataGrid.selectedVehicleId = 0;
RealDataGrid.selectedPlateNo = '';
RealDataGrid.realDataList = [];//实时数据加载到内存中，进行内存分页
RealDataGrid.rowIndexMap = {};//根据实时数据ID,找到内存数组realDataList的索引
//RealDataGrid.realDataMap = {};//根据实时数据ID,找到内存数组realDataList的索引
RealDataGrid.update = false;
RealDataGrid.refreshInterval = 10;
RealDataGrid.gridId = "realDataGrid";

RealDataGrid.create = function (refreshInterval) {
    this.refreshInterval = refreshInterval || 10;//刷新间隔,确定定时器的间隔
    this.update = false;
    var treeUrl = globalConfig.webPath + "/vehicle/refreshRealData.action";
    //绑定数据列表 //align: 'left' 控制对齐方式
    this.realDataGrid = $("#realDataGrid");

    this.timerName = "realdataTimer";
    var strInterval = this.refreshInterval + 's';
    var me = this;
    $('body').everyTime(strInterval, this.timerName, function () {
        //do something...
        me.refresh(true);//更新模式
    });

    return this.realDataGrid;

}

//点击数据表格的行时，显示地图车辆
RealDataGrid.onClickRow = function(rowIndex, rowData)
{
	var plateNo = rowData.plateNo;
	var vehicleId = rowData.vehicleId;
	MyMap.showVehicleOnMap(vehicleId);
	RealDataGrid.selectedVehicleId = vehicleId;
	RealDataGrid.selectedPlateNo = plateNo;
	$("#realDataPlateNo").val(plateNo);
}
/**
 * 当用户点击车辆树的时候，设置车牌号和Id
 */
RealDataGrid.setPlateNo = function(plateNo, vehicleId)
{
	$("#realDataPlateNo").val(plateNo);
	this.selectedPlateNo = plateNo;
	this.selectedVehicleId = vehicleId;
}

//将上线状态转换成图标显示
function formatOnlineState(val,row){
	        
			if (val){
				var onlineImage = globalConfig.webPath+"/image/power_on.png";
				return '<img src="'+onlineImage + '" />';
			} else {
				var offlineImage = globalConfig.webPath+"/image/power_off.gif";
				return '<img src="'+offlineImage + '" />';
			}
		}
/**
 * 清除表格数据
 */
RealDataGrid.clear = function()
{	
	$("#"+ this.gridId ).empty();
	this.realDataList = [];
	this.rowIndexMap = {};
}

function safeString(str)
{
	if(str == "undefined" || str == null || typeof(str) == "undefined" )
		return "";
  return  str;
}
/**
* 定时发送ajax请求，更新表格,
* 如有表格中有对应的车辆就更新
* 如果没有该车辆，就增加一套
*/
RealDataGrid.refresh = function(update)
{
	//update = false;
	if(!this.selectVehicleIds || this.selectVehicleIds.length == 0)
		return;
	if(update == false)
	{
		//jQuery('#'+this.gridId).showLoading(); 
		$("#realDataGridTips").show();
	}
	var me = this;
	var url = globalConfig.webPath+"/RealData.mvc/refreshRealData";
	var params = {update:update};	 
     $.ajax({
            type: "POST",
            url: url,
			data:params,
			error:function(){
			   //alert("网络连接错误，无法读取数据!");
               //Utility.done();
			},
            success: function(result){
				//var gridData = {Rows:data};
				var records = result.rows;
				if(records == null)
					return;
	            var start = new Date();
				if(update == false)
				{
					MyMap.clearAllVehicle();
				    MyMap.showVehicleListOnMap(records,true);
					$("#"+ me.gridId ).empty();
					me.rowIndexMap = {};
					//me.realDataMap = {};
					//第一次全部加载
					me.realDataList = records;//保存在内存中，进行分页
					var newRow = "";
					for(var m = 0; m < records.length; m++)
					{
						
						var r = records[m];
						me.rowIndexMap[r.vehicleId] = m;
						var trClass= m % 2 == 0 ? "" : "datagrid-row-odd";
						if(m == 0)
						{
						newRow += "<tr id=rd_"+m+"  class="+trClass+"><td style='width:20px'>" + (m+1) + "</td><td style='width:80px'>"+ r.plateNo + "</td><td style='width:120px'>"+ r.depName + "</td><td style='width:120px'>"
								 + r.simNo + "</td><td style='width:40px'>"+ r.plateColor + "</td><td style='width:40px'>"+ formatOnlineState(r.online) + "</td><td style='width:120px'>" 
								  + safeString(r.sendTime) + "</td><td style='width:240px'>"+ r.location + "</td><td style='width:80px'>"+ safeString(r.status) + "</td><td style='width:40px'>"
								  + safeString(r.velocity) + "</td><td  style='width:60px'>"+ safeString(r.recordVelocity) + "</td><td style='width:80px'>"+ safeString(r.directionDescr) + "</td><td  style='width:60px'>"
								  + safeString(r.todayMileage)+  "</td><td  style='width:60px'>"
								  + safeString(r.mileage) + "</td><td  style='width:60px'>"+ safeString(r.gas) + "</td><td style='width:40px'>"+ safeString(r.valid) + "</td><td style='width:40px'>"
								  + safeString(r.altitude) + "</td><td style='width:90px'>"+ safeString(r.longitude) + "</td><td style='width:90px'>"+ safeString(r.latitude) + "</td><td style='width:20px'>" 
								  + r.vehicleId + "</td></tr>";
						}else
						{
							newRow += "<tr id=rd_"+m+"  class="+trClass+"><td >" + (m+1) + "</td><td >"+ r.plateNo + "</td><td >"+ r.depName + "</td><td >"
								 + r.simNo + "</td><td >"+ r.plateColor + "</td><td >"+ formatOnlineState(r.online) + "</td><td '>" 
								  +safeString( r.sendTime) + "</td><td>"+ r.location + "</td><td >"+ safeString(r.status) + "</td><td >"
								  + safeString(r.velocity) + "</td><td  >"+ safeString(r.recordVelocity) + "</td><td >"+ safeString(r.directionDescr) + "</td><td  >"
								  + safeString(r.todayMileage ) + "</td><td  >"
								  + safeString(r.mileage )+ "</td><td  >"+ safeString(r.gas) + "</td><td >"+ safeString(r.valid) + "</td><td >"
								  + safeString(r.altitude) + "</td><td '>"+safeString( r.longitude) + "</td><td >"+ safeString(r.latitude) + "</td><td '>" 
								  + r.vehicleId + "</td></tr>";
						}
					}
				    $("#"+ me.gridId ).append(newRow);
					
		            $("#realDataGridTips").hide();
		            //jQuery('#'+me.gridId).hideLoading(); 
					$("#"+ me.gridId + " tr").hover(function () {  						    
							var selectedIndex = $(this).attr("class").indexOf("datagrid-row-selected");
							if(selectedIndex < 0)
						   {
								//$(this).css({ "background-color": "#87CEEB" });  
								$(this).addClass("datagrid-row-over");
								$(this).removeClass("datagrid-row-odd");
						   }
						},function () {  
							var selectedIndex = $(this).attr("class").indexOf("datagrid-row-selected");
							if(selectedIndex < 0)
						   {
								$(this).removeClass("datagrid-row-over");
								var $index = $(this).index();  
								if ($index % 2 == 0) {  
									//$(this).css("datagrid-row-over");  								
								   $(this).addClass("datagrid-row-odd");
								} else {  							
								   $(this).removeClass("datagrid-row-odd");
									//$(this).css({ "background-color": "#E4F5FF" });  
								}  
						   }
						}).click(function(){
							var s=$(this).attr("class");
							$("#"+ me.gridId + " tr").removeClass("datagrid-row-selected");
							var rowIndex = $(this).index(); 
							var rowData = me.realDataList[rowIndex];
							var plateNo = rowData.plateNo;
							var vehicleId = rowData.vehicleId;
							MyMap.showVehicleOnMap(vehicleId);
							RealDataGrid.selectedVehicleId = vehicleId;
							RealDataGrid.selectedPlateNo = plateNo;
							$("#realDataPlateNo").val(plateNo);
							if(s!=null&&s!='undefined'){
								var ofright = $(this).attr("class").indexOf("datagrid-row-selected");
								if(ofright>-1){
									$(this).removeClass("datagrid-row-selected");
								}else{
									$(this).addClass("datagrid-row-selected");
									$(this).removeClass("datagrid-row-odd");
								   $(this).removeClass("datagrid-row-over");
								}
							}else{
								$(this).addClass("datagrid-row-selected");
								$(this).removeClass("datagrid-row-odd");
								$(this).removeClass("datagrid-row-over");
							}
						});  

				}else
				{
					//没有要更新的实时数据
					if(records.length == 0)
						return;
					
					//第一次全部加载后，转入更新模式，即只从后台查询到有更新的实时数据，减少流量
					//var trList = $("#"+ me.gridId).children();

					for(var m = 0; m < records.length; m++)
					{
						var r = records[m];

						var index = me.rowIndexMap[r.vehicleId];
						if(index != null)
						{
						   me.realDataList[index] = r;//更新内存记录					   
							
						}

						//$("#"+ me.gridId + " tr:eq("+index + ") td:nth-child(1)").html("value");   
						//var trObj = $("#"+ me.gridId + " tr:eq("+index + ")");
						//var trObj = trList[index];
						//trObj = $(trObj);
						var tdList = $("#rd_"+index).children();
						var dataArray = [r.plateNo,r.depName,r.simNo ,r.plateColor ,formatOnlineState(r.online) ,r.sendTime, r.location,r.status,r.velocity,
							r.recordVelocity,r.directionDescr,r.todayMileage,r.mileage,r.gas,r.valid,r.altitude, r.longitude,r.latitude,r.vehicleId ];
						for(var k = 1; k < tdList.length; k++)
						{
						    var td = tdList[k];
						    td.innerHTML = dataArray[k-1];
						}
					}	
					var onlyUpdate = true;
					MyMap.showVehicleListOnMap(records,false,onlyUpdate);
				}
				/**
				var selectedRow = me.realDataGrid.datagrid("getSelected");
				if(selectedRow!=null && update )
				{
				   var plateNo = selectedRow.plateNo;
				   var index = me.realDataGrid.datagrid('getRowIndex',plateNo);
				   me.realDataGrid.datagrid('selectRow',index);
				}*/

				
				var end = new Date();
	            var interval = 0.001 * (end - start) ;

	            //if(console)
	               //console.log("载入"+records.length+"条数,耗时:"+ interval+"秒");

				


				/**
				if(data.success == false && data.message){
					alert("操作发生错误! 错误原因:"  + data.Message);

				}*/
              
                
            }
        });


}
//将上线状态转换成图标显示
function formatOnlineState(val,row){
	        
			if (val){
				var onlineImage = globalConfig.webPath+"/image/power_on.png";
				return '<img src="'+onlineImage + '" />';
			} else {
				var offlineImage = globalConfig.webPath+"/image/power_off.gif";
				return '<img src="'+offlineImage + '" />';
			}
		}
						
	 ;


