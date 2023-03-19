

var treestore = new Ext.data.TreeStore({
		autoload : true,
		proxy : {
			type : 'ajax',
			url : 'user/getVechecileTree.action',
			filterParam : 'simNo'
		},
		remoteFilter : true,
		model : 'TreeData',
		root : {
			text : '目录树',
			id : 'root',
			expanded : false
		}
	});

var departmentStore = createBasicDataStore({
		queryID : "selectDepList"
	});
var depCombo = Ext.create('Ext.form.field.ComboBox', {
		//fieldLabel: 'Select a single state',
		displayField : 'name',
		valueField : 'code',
		width : 80,
		//labelWidth: 130,
		store : departmentStore,
		queryMode : 'remote',
		hidden : true,
		listeners : {
			select : function (combo, store, index) {}
		},
		typeAhead : true
	});
var seachField = new Ext.form.TextField({
		id : "txt_name",
		fieldLabel : "姓名"
	});

searchField = Ext.create('Ext.ux.form.SearchField', {
		width : 100,
		store : treestore,
		emptyText : '请输入..'
	});

// Simple ComboBox using the data store
var searchOptionCombo = Ext.create('Ext.form.field.ComboBox', {
		//fieldLabel: 'Select a single state',
		displayField : 'name',
		valueField : 'code',
		width : 80,
		//labelWidth: 130,
		store : store,
		queryMode : 'local',
		listeners : {
			select : function (combo, store, index) {
				if (combo.value == "department") {
					depCombo.hidden = false;
					seachField.hidden = true;
				} else {
					depCombo.hidden = true;
					seachField.hidden = false;
				}
			}
		},
		typeAhead : true
	});

var mytree = Ext.create('Ext.tree.Panel', {
		title : '目录树',
		renderTo : Ext.getBody(),
		width : 200,
		collapsible : true,
		split : true,
		//store: dataStore,
		store : treestore,
		rootVisible : false,
		useArrows : true,
		tbar : [{
				text : '刷新',
				iconCls : 'nav',
				handler : function () {
					treestore.filterBy(function (record) {
						return record.get('nodeId') == 3;
					});
					var record = mytree.getRootNode().findChild('nodeId', '3', true);
					if (record) {
						//alert(record.getPath());
						record.bubble(function (node) {
							node.expand()
						});
						mytree.getSelectionModel().select(record);
						record.fireEvent('click', record);
					}

					if (mytree.getSelectionModel().hasSelection()) {

						var selectedNode = mytree.getSelectionModel().getSelection();
						//alert(selectedNode[0].data.text + ' was selected');
					} else {
						//Ext.MessageBox.alert('No node selected!');
					}
				}
			}, searchOptionCombo, searchOptionCombo, searchField],
		listeners : {
			'itemclick' : function (view, re) {
				var vehicleId = re.data.nodeId;
				var url = '<%=ApplicationPath%>/vehicle/refreshRealData.action';
				ajaxRequest(url, {
					vehicleId : vehicleId
				}, false, function (result) {
					if (result.success == false)
						return;
					var rd = result.data; //GPS实时数据
					var vehicleInfo = {
						id : rd.ID,
						text : rd.plateNo,
						vehicleId : rd.ID,
						rLat : rd.latitude,
						rLng : rd.longitude,
						tLat : rd.latitude,
						tLng : rd.longitude,
						status : rd.status,
						color : rd.plateColor,
						validate : rd.valid,
						direction : rd.direction,
						angleInt : rd.direction,
						statusInt : 0,
						speed : rd.velocity,
						warnTypeId : 0,
						online : rd.online
					};
					getMapHandler().centerMarkerOverlays([vehicleInfo]);
					/**
					getMapHandler().createMarkerOverlayPointMode(vehicleInfo, function(vehicleId, opts){
					alert(opts);
					});*/
				});
				/**
				mainTabs.add({
				xtype: 'panel',
				title: re.data.text,
				html : 'Content for tab ' + re.text,
				closable: true
				});
				 */
			}
		}
	});

var selectVehicleIds = "";
mytree.on('checkchange', function (node, checked) {
	//alert(node.data.text);
	selectVehicleIds = "";
	//var mydate = new Date();
	//alert(mydate.toLocaleString());
	//checkAllChildNode(node, checked);
	node.cascadeBy(function (child) {
		child.set("checked", checked);
	});

	//var mydate1 = new Date();
	//alert(mydate1.toLocaleString());
	//得到所有选中的车辆，组成要监控的车辆列表，发送到后台
	var nodes = mytree.getChecked();
	if (nodes && nodes.length) {
		for (var i = 0; i < nodes.length; i++) {
			var node = nodes[i];
			if (node.data.leaf) {
				selectVehicleIds += node.data.nodeId + ",";
				//alert(node.data.text);
			}
		}
		ajaxRequest("<%=ApplicationPath%>/vehicle/registerVehicles.action", {
			registerVehicleIds : selectVehicleIds
		});
	}

	//var mydate2 = new Date();
	//alert(mydate2.toLocaleString());
}, mytree);

function checkAllChildNode(node, checked) {
	// node.expand();
	node.checked = checked;
	if (node.data.leaf)
		return;
	node.eachChild(function (child) {
		//child.set('checked', checked);
		child.checked = checked;
		//child.fireEvent('checkchange', child, checked);
		if (child.data.leaf == false)
			checkAllChildNode(child, checked);
	});
}

// 增加右键点击事件
mytree.on('itemcontextmenu', function (view, record, item, index, event) {
	//alert(record)
	//treePanelCurrentNode = record;
	event.preventDefault();
	if (record.get('leaf')) {
		rightClickMenu.showAt(event.getXY());
	}
	event.stopEvent();
}, mytree);
