
//终端命令下发结果查询类
TerminalCommand = {};

TerminalCommand.timerName = "timerForQuery";
TerminalCommand.times=60;//下发命令后，等待应答倒计时60秒
TerminalCommand.onSuccess=null;
TerminalCommand.commandButton = null;//下发命令的按钮
TerminalCommand.commandButtonText = "";
TerminalCommand.startQueryResult = function(commandId,url, onSuccess)
{ 
	if(!url)
		 url = globalConfig.webPath + "/TerminalCommand.mvc/getCommandResult"; //查询命令的执行情况
	if(!this.commandButton)
		this.commandButton = $('.sendjson');
	this.commandButtonText = this.commandButton.val();
	this.url = url;
	var me = this;
	this.times = 60;//获取查询结果的最大次数
	$(".commandMsg").html("");
	this.commandButton.attr("disabled","disabled");
	this.commandButton.val("等待终端返回结果("+this.times+" )");
	  //使用jquery.timer插件，进行定时调用，最多执行次数取决this.times的次数定义
	$('body').oneTime('500ms', this.timerName,function(){  
		 me.queryResult(commandId); //查询命令的返回结果
	});
	this.onSuccess = onSuccess;
}
//停止查询和倒计时
TerminalCommand.stopQuery = function()
{
	$('body').stopTime (this.timerName);
}

//查询命令执行结果
TerminalCommand.queryResult = function(commandId)
{	
    this.times--;
	var me = this;
	this.commandButton.val("等待终端执行("+this.times+" )");
	var params = {commandId:commandId};
	$.getJSON(this.url, params, 
			function(result){		
				  if(result.success == true)
				 {
					me.commandButton.val(me.commandButtonText);
					me.commandButton.attr("disabled",false); 
					$(".commandMsg").html(result.message);
					if(me.onSuccess)
					{
						me.onSuccess(result);
					}
				}else {
				   $(".commandMsg").html(result.message);
				   if(me.times == 1)
				   {
						 
						$(".commandMsg").html("命令执行超时，无应答,请重新操作");
					    me.commandButton.val(me.commandButtonText);
						me.commandButton.attr("disabled",false); 
					    $('body').stopTime ();  
				   }else if(result.message == "等待发送" && me.times <= 50)
					{
						$(".commandMsg").html("服务器没有下发,请重新操作");
						
					    me.commandButton.val(me.commandButtonText);
						me.commandButton.attr("disabled",false); 
					    $('body').stopTime ();  
					}
				   else{
					     //最多执行5次
						 $('body').oneTime('500ms', me.timerName,function(){  
								 me.queryResult(commandId); //查询命令的返回结果
						});
					}
					
				}
		  }
	  );
}