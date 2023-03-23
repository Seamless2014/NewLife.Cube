
/**
 *
 */

TerminalCommandGrid = {};

TerminalCommandGrid.create = function()
{
	this.update = false;//
	
    var url = globalConfig.webPath+'/TerminalCommand.mvc/query';
	this.terminalGrid=	$("#terminalCommandGrid");	
    this.terminalGrid.datagrid({
                columns: [[
                    { title: '车牌号', field: 'plateNo', width: 60,minWidth:60 },
                    { title: 'Sim卡号', field: 'simNo', width: 80,minWidth:80 },
                    { title: '命令类型', field: 'cmdType', width: 100,minWidth:40 },
                    { title: '命令内容', field: 'cmdData', width: 250,minWidth:120 },
                    { title: '流水号', field: 'SN', width: 50,minWidth:50 },
                    { title: '执行结果', field: 'status', width: 90,minWidth:80 },
                    { title: '下发时间', field: 'createDate', width: 90,minWidth:40 },
                    { title: '执行时间', field: 'updateDate', width: 90,minWidth:40 }
                    ]],
				url: url,
				fit:true,
				method: 'POST',
				queryParams: { 'id': 2 },
				striped: true,
				fitColumns: true,
				singleSelect: true,
				rownumbers: true,
				pagination: true,
				nowrap: true,
				pageSize: 10,
				pageList: [10, 20, 50, 100, 150, 200],
				showFooter: true
            });
	 this.refreshInterval = 10;
	 this.timerName = "terminalCommandDataTimer";
	 var strInterval = this.refreshInterval + 's';
	 var me = this;
	 $('body').everyTime(strInterval, this.timerName,function(){
		//do something...
		//me.refresh();//更新模式
		//me.terminalGrid.datagrid('reload');  
	 });
	 
     return this.terminalGrid;
}


/**
* 定时发送ajax请求，更新表格,
* 如有表格中有对应的车辆就更新
* 如果没有该车辆，就增加一套
*/
TerminalCommandGrid.refresh = function()
{
	 this.terminalGrid.datagrid("load");
}
