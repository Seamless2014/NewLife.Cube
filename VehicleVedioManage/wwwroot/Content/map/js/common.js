function Map() {
	var struct = function (key, value) {
		this.key = key;
		this.value = value;
	};
	var put = function (key, value) {
		for (var i = 0; i < this.arr.length; i++) {
			if (this.arr[i].key === key) {
				this.arr[i].value = value;
				return;
			}
		}
		this.arr[this.arr.length] = new struct(key, value);
	};
	var get = function (key) {
		for (var i = 0; i < this.arr.length; i++) {
			if (this.arr[i].key == key) {
				return this.arr[i].value;
			}
		}
		return null;
	};
	var remove = function (key) {
		var v;
		for (var i = 0; i < this.arr.length; i++) {
			v = this.arr.pop();
			if (v.key === key) {
				continue;
			}
			this.arr.unshift(v);
		}
	};
	var size = function () {
		return this.arr.length;
	};
	var isEmpty = function () {
		return this.arr.length <= 0;
	};
	var clear = function () {
		for(var i=0;i<this.arr.length;i++)
		{
			this.arr[i] = null;
		}
		this.arr.length = 0;
	};
	this.arr = new Array();
	this.get = get;
	this.put = put;
	this.remove = remove;
	this.size = size;
	this.isEmpty = isEmpty;
	this.clear = clear;
	this.toArray = function()
	{	
		var array = new Array();
		for (var i = 0; i < this.arr.length; i++) {
			array[i] = this.arr[i].value;
		}
		return array;
	};
	this.toKeyArray = function()
	{	
		var array = new Array();
		for (var i = 0; i < this.arr.length; i++) {
			array[i] = this.arr[i].key;
		}
		return array;
	};
}

function List() {
	this.arr = new Array();
	var struct = function (value) {
		this.value = value;
	};
	var add = function (value) {
		for (var i = 0; i < this.arr.length; i++) {
			if (this.arr[i].value === value) {
				return;
			}
		}
		this.arr[this.arr.length] = new struct(value);
	};
	var get = function (i) {
		if (i < this.arr.length && i >= 0) {
			return this.arr[i].value;
		}
		return null;
	};
	var size = function () {
		return this.arr.length;
	};
	var isEmpty = function () {
		return this.arr.length <= 0;
	};
	var clear = function () {
		for(var i=0;i<this.arr.length;i++)
		{
			this.arr[i] = null;
		}
		this.arr.length = 0;
	};
	
	this.get = get;
	this.add = add;
	this.size = size;
	this.isEmpty = isEmpty;
	this.clear = clear;
}


/*



function isNumber(e) {   
	alert("isNumber");
    if (document.all) {   
        if ( ((event.keyCode > 47) && (event.keyCode < 58)) ||   
              (event.keyCode == 8) ) {   
            return true;   
        } else {   
            return false;   
        }   
    } else {   
        if ( ((e.which > 47) && (e.which < 58)) ||   
              (e.which == 8) ) {   
            return true;   
        } else {   
            return false;   
        }   
    }   
} 


function objectEval(text) {
	alert("objectEval");
	// eval() breaks when we use it to get an object using the { a:42, b:'x' }
	// syntax because it thinks that { and } surround a block and not an object
	// So we wrap it in an array and extract the first element to get around
	// this.
	// The regex = [start of line][whitespace]{[stuff]}[whitespace][end of line]
	text = text.replace(/\n/g, " ");
	text = text.replace(/\r/g, " ");
	if (text.match(/^\s*\{.*\}\s*$/)) {
		text = "[" + text + "][0]";
	}
	return eval(text);
}


function getThirdClients(obj) {
	alert("getThirdClients");
	var retInt;
	if (window != parent && location.search.substring(1).indexOf("ThirdClient=") != -1) {
		var clients = location.search.substring(1).substring(location.search.substring(1).indexOf("ThirdClient=") + 12).split("@");
		if (obj) {
			retInt = parseInt(clients[1]);
		} else {
			retInt = parseInt(clients[0]);
		}
	} else {
		if (obj) {
			retInt = document.body.clientHeight;
		} else {
			retInt = document.body.clientWidth;
		}
	}
	return retInt;
}


function courseToText(course)
{
	alert("courseToText");
	var ddd = parseInt(course)%360;
	var dPrompt;
	if(ddd==0)
	{
		dPrompt = "����";
	}
	else if(ddd<45)
	{
		dPrompt = "��ƫ��";
	}else if(ddd==45)
	{
		dPrompt = "����";
	}else if(ddd<90)
	{
		dPrompt = "��ƫ��";
	}else if(ddd==90)
	{
		dPrompt = "����";
	} else if(ddd<135)
	{
		dPrompt = "��ƫ��";
	} else if(ddd==135)
	{
		dPrompt = "����";
	} else if(ddd<180)
	{
		dPrompt = "��ƫ��";
	} else if(ddd==180)
	{
		dPrompt = "����";
	} else if(ddd<225)
	{
		dPrompt = "��ƫ��";
	} else if(ddd==225)
	{
		dPrompt = "����";
	} else if(ddd<270)
	{
		dPrompt = "��ƫ��";
	}else if(ddd==270)
	{
		dPrompt = "����";
	} 
	else if(ddd<315)
	{
		dPrompt = "��ƫ��";
	}
	else if(ddd==315)
	{
		dPrompt = "����";
	}
	else
	{
		dPrompt = "��ƫ��";
	}
	return dPrompt;
}
*/