/**
 *报警声音，调用media目录中的mp3
 *采用html5的audio标签，播放声音
 */
AlarmSound = {
	soundList : {},
	
	playAllow : true,

	enable:function(_allow)
	{
		  this.playAllow = _allow;
		  this.control();
	},	
	control : function(){
		if (AlarmSound.playAllow){
			AlarmSound.stop();
		}else{
			AlarmSound.play();
			AlarmSound.play();
		}
	},
	
	createComponent : function(id, src) {
		// AlarmSound.soundList[id] = div;
	},
	stop : function() {
		try{
			var audio = document.getElementById( "audioPlay" );
			if(audio != null)
			{
			   audio.pause();
               audio.currentTime = 0;
			}
		}catch(e){
			
			console.log("停止播放声音失败:"+ e);
		}
	},
	play:function()
    {		
		if(AlarmSound.playAllow == false)
			return;

		try{
		  var url = globalConfig.webPath + "/media/AlarmSound.mp3";
		  var borswer = window.navigator.userAgent.toLowerCase();
		  if ( borswer.indexOf( "ie" ) >= 0 )
		  {
			//IE内核浏览器
			var strEmbed = "<embed name='embedPlay' src='"+ url + "' autostart='true' hidden='true' loop='false'></embed>";
			if ( $( "body" ).find( "embed" ).length <= 0 )
			  $( "body" ).append( strEmbed );
			var embed = document.embedPlay;

			//浏览器不支持 audion，则使用 embed 播放
			embed.volume = 100;
			//embed.play();这个不需要
		  } else
		  {
			//非IE内核浏览器
			var strAudio = "<audio id='audioPlay' src='"+ url + "' hidden='true'>";
			if ( $( "body" ).find( "audio" ).length <= 0 )
			  $( "body" ).append( strAudio );
			var audio = document.getElementById( "audioPlay" );

			//浏览器支持 audion
			audio.play();
		  }
		}catch(e){
			
			console.log("停止播放声音失败:"+ e);
		}
    }
}