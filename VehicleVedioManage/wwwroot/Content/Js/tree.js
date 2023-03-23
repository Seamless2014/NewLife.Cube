/**
 * 主界面左侧的车辆树菜单
 * 根据json数据生成树
 */

VehicleTree = {}

VehicleTree.createTree = function(id, treeHeight,treeRightMenu)
{
	this.updateMap = {};
	this.filterParams = {updateNode:false,filter:false};//过滤条件
	 this.treeManagerRightMenu = treeRightMenu;
	 this.treeManager = $("#"+id);
	 this.load(false);
	 this.timerName = "refreshTreeTimer";
	 this.refreshInterval = 10;
	 var strInterval = this.refreshInterval + 's';
	 var me = this;
	 $('body').everyTime(strInterval, this.timerName,function(){
		//定时更新车辆节点的状态
		me.load(true);//更新模式
	 });
}


VehicleTree.updateTreeNode = function(data)
{
	var me = this;
	$.each(data, function (i, n) {
		var node = me.treeManager.tree('find', n.id);
		if (node){
			me.treeManager.tree('update', {
				target: node.target,
				text: n.text,
				iconCls:n.iconCls
			});
		}else
			me.updateMap[n.id] = n;
   });
}

VehicleTree.getSelected=function()
{
     var node = this.treeManager.tree('getSelected');
	 return node;
}

VehicleTree.getSelectedPlateNo=function()
{
	var node = this.getSelected();
	if(node != null && node.leaf == true)
		return node.text;
	return "";
}

VehicleTree.filter = function(params)
{
	this.filterParams = params;
	params.filter = true;
	this.load(false);
}

VehicleTree.clearFilter = function()
{
	this.filterParams = {filter:false};
	this.load(false);
}

VehicleTree.load = function(isUpdate)
{
	if(isUpdate == false)
		this.updateMap = {};
	var me = this;
	var treeManager = this.treeManager;
	var treeRightMenu = this.treeManagerRightMenu;
	var url = globalConfig.webPath+"/vehicleTree.mvc/getVehicleTree";
	//var params = {updateNode:update};
	this.filterParams.updateNode = isUpdate;
	var filter = this.filterParams.filter;
     $.ajax({
            type: "POST",
            url: url,
			data:this.filterParams,
			error:function(){
			   //alert("网络连接错误，无法读取数据!");
               //Utility.done();
			},
            success: function(data){
				var treeData = data.TreeData;
				if(isUpdate == false)
				{
					treeManager.tree({checkbox:true,lines:true,data:treeData,loadFilter:myLoadFilter, 
						onCheck:function(node,checked)
						{
							me.onCheck(node,checked);
						},
						onClick:function(node,checked)
						{
							me.onClick(node,checked);
						},
						onSelect:function(node)
						{
							me.onSelect(node);
						},
						onDblClick:function(node)
						{
							me.onDblClick(node);
						},
						onBeforeCheck :function(node){
				
							//me.treeManager.tree("expand",node.target);
						},
						onContextMenu: function(e,node){
							e.preventDefault();
							$(this).tree('select',node.target);
							//不是车辆节点，不弹出右键菜单
							if(node.id.indexOf("v") < 0)
								return;
							if(treeRightMenu)
							{
								treeRightMenu.menu('show',{
									left: e.pageX,
									top: e.pageY
								});
							}
					   }
					});

					if(filter == true)
					{
						//treeManager.tree('expandAll');//过滤模式下展开所有节点
					}else
					{
						treeManager.tree('expandAll');
					}
				}else
				{
					me.updateTreeNode(treeData);
				}

				var onlineInfo = data.onlineInfo;
				$("#spanTotal").html(onlineInfo.totalNum);
				$("#spanGpsOnline").html(onlineInfo.onlineNum);
				$("#spanGpsOffline").html(onlineInfo.offlineNum);
				$("#spanParking").html(onlineInfo.parkingNum);
				$("#spanOnlineRate").html(onlineInfo.onlineRate);
				//$("#spanOnlineUserNum").html(onlineInfo.onlineUserNum);
                //me.manager.setData(treeData);
            }
        });

}


/**
 tree的onclick事件
 */
VehicleTree.onClick = function(node,checked)
{
	//如果是叶子节点，表明点击的是车辆
		if(node.leaf)
		{
	        var strId = node.id;
			var vehicleId = strId.substring(1);
			var plateNo = node.text;
	        MyMap.showVehicleOnMap(vehicleId);
			HistoryRoutePanel.setPlateNo(plateNo);
			RealDataGrid.setPlateNo(plateNo,vehicleId);
		}
}

VehicleTree.onSelect=function(node)
{
}
/**
 tree的双击事件
 */
VehicleTree.onDblClick = function(node)
{
	if(node.leaf == false)
	{
		if(node.state == "closed")
	      this.treeManager.tree("expand",node.target);
	    else
	      this.treeManager.tree("collapse",node.target);
	}
}

VehicleTree.getCheck = function(node)
{
	var s = "";
	var me = this;
	$.each(node.children1, function (i, n) {
		var strId = n.id;
		if(n.leaf && strId.indexOf("v")== 0)
		{
           s += strId.substring(1)+",";			
		}else if(n.children1 && n.children==null)
		{
			s+= me.getCheck(n);
		}
	});

	return s;
}

/**
 tree的oncheck事件
 */
VehicleTree.onCheck = function(node,checked)
{
	//var data = this.treeManager.tree('getData',node.target);
	
	//this.treeManager.tree("expand",node.target);
	//this.treeManager.tree("check",node.target);
	//获取用户选择的车辆节点，订阅到后台
	var nodes = this.treeManager.tree('getChecked');
    var s = '';
	var me = this;
    for (var i = 0; i < nodes.length; i++) {
		var n = nodes[i];
		var strId = nodes[i].id;
		if(strId.indexOf("v")== 0)
		{
            s += strId.substring(1)+",";
		}else if(n.children1 && n.children == null)
		{
			s+=me.getCheck(n);
		}
    }
	this.selectVehicleIds = s;
	RealDataGrid.selectVehicleIds = this.selectVehicleIds;
	this.register();
	if(nodes.length == 0)
	{
		RealDataGrid.clear();//如果什么也没选，就清除表格数据；
		MyMap.clearAllVehicle();//清除地图上的车辆地标
	}
	//this.onClick(node);
}
/**
 * 订阅要实时查看的车辆数据
 */
VehicleTree.register=function()
{
	var url = globalConfig.webPath+"/RealData.mvc/registerVehicles"
	var params = {registerVehicleIds:this.selectVehicleIds};
     $.ajax({
            type: "POST",
            url: url,
			data:params,
			error:function(){
			   //alert("网络连接错误，无法读取数据!");
               //Utility.done();
			},
            success: function(data){
				 //刷新实时表格数据
				 RealDataGrid.refresh(false);	
            }
        });
}

function myLoadFilter(data, parent){
			var state = $.data(this, 'tree');
			
		    function setData(){
		    	var serno = 1;
		        var todo = [];
		        for(var i=0; i<data.length; i++){
		            todo.push(data[i]);
		        }
		        while(todo.length){
		            var node = todo.shift();
		            if (node.id == undefined){
		            	node.id = '_node_' + (serno++);
		            }//实现延迟加载的关键  
                        //将children先缓存再置空  
                        //第一次渲染时就渲染不到children节点了  
		            if (node.children){
		                node.state = 'closed';
		                node.children1 = node.children;
		                node.children = undefined;
		                todo = todo.concat(node.children1);
		            }
		        }
		        state.tdata = data;
		    }
		    function find(id){
		    	var data = state.tdata;
		    	var cc = [data];
		    	while(cc.length){
		    		var c = cc.shift();
		    		for(var i=0; i<c.length; i++){
		    			var node = c[i];
		    			if (node.id == id){
		    				return node;
		    			} else if (node.children1){
		    				cc.push(node.children1);
		    			}
		    		}
		    	}
		    	return null;
		    }
		    
		    setData();
		    
		    var t = $(this);
		    var opts = t.tree('options');
		    opts.onBeforeExpand = function(node){
	    		var n = find(node.id);
	    		if (n.children && n.children.length){return}
		    	if (n.children1){					
	                $.each(n.children1, function (i, n) {
						var obj = VehicleTree.updateMap[n.id];
						if(obj)
						{
							n.text = obj.text;
							n.iconCls = obj.iconCls;
						}
						n.checked = node.checked;//继承父节点的状态
					});
		    		var filter = opts.loadFilter;
		    		opts.loadFilter = function(data){return data;};
		    		t.tree('append',{
		    			parent:node.target,
		    			data:n.children1
		    		});
		    		opts.loadFilter = filter;
		    		n.children = n.children1;
		    	}
		    };
			/**
			opts.onCheck = function(node)
			{

			}*/
			/**
			opts.onBeforeCheck = function(node){
				
	            t.tree("expandAll",node.target);
		    };*/

			return data;
		}
