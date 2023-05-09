(function () {
    window.ZtreeControl = function () {
        var treeObj;
        var _renderTree = function (obj, callback) {
            var msgIndex;
            if (obj.showLoading) {
                msgIndex = loading();
            }
            $.ajax({
                url: obj.url,
                type: obj.requestType,
                data: obj.searchParam,
                async: true,
                success: function (data) {
                    if (data.Code === 1) {
                        if (data.Data !== null && data.Data !== '' && data.Data.length > 0) {
                            treeObj = $.fn.zTree.init($("#" + obj.treeID), obj.setting, data.Data);
                        }
                        else {
                            treeObj = $.fn.zTree.init($("#" + obj.treeID), obj.setting, []);
                            $("#" + obj.treeID).html("<div style=\"color:#555;text-align:center;\">无数据</div>");
                        }
                        if (obj.showLoading) {
                            layer.close(msgIndex);
                        }
                    }
                    else {
                        treeObj = $.fn.zTree.init($("#" + obj.treeID), obj.setting, []);
                        $("#" + obj.treeID).html("<div style=\"color:#555;text-align:center;\">无数据</div>");
                        if (obj.showLoading) {
                            layer.close(msgIndex);
                        }
                        layer.msg(data.Msg);
                    }
                    if (obj.haveCallback) {
                        callback();
                    }
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    if (obj.showLoading) {
                        layer.close(msgIndex);
                    }
                    layer.msg('数据获取失败！');
                    // 状态码
                    console.log(XMLHttpRequest.status);
                    // 状态
                    console.log(XMLHttpRequest.readyState);
                    // 错误信息
                    console.log(textStatus);
                }
            });
        };

        var _getNodes = function () {
            return treeObj.getNodes();
        };

        var _getNodesByParam = function (key, value, parentNode) {
            return treeObj.getNodesByParam(key, value, parentNode);
        };

        var _selectNode = function (treeNode) {
            treeObj.selectNode(treeNode);
        };

        var _getSelectedNodes = function () {
            return treeObj.getSelectedNodes();
        };

        var _getChecked = function () {
            return treeObj.getCheckedNodes(true);
        };

        var _getCheckedNodeIDs = function () {
            return treeObj.getCheckedNodeIDs(true);
        };

        var _getCheckedLeafNodeIDs = function () {
            return treeObj.getCheckedLeafNodeIDs(true);
        };

        var _getOpenedIDs = function () {
            return treeObj.getOpenedNodeIDs();
        };

        var _expandAll = function () {
            treeObj.expandAll(true);
        };

        var _setAllSelectStatus = function (checked) {
            treeObj.checkAllNodes(checked)
        };

        var _reverseSelection = function () {
            var notCheckedLeafNodes = treeObj.getCheckedLeafNodes(false);
            treeObj.checkAllNodes(false);
            notCheckedLeafNodes.forEach(function (item) {
                treeObj.checkNode(item, true, true, true);
            });
        };

        return {
            tree: _renderTree,
            getNodes: _getNodes,
            getNodesByParam: _getNodesByParam,
            selectNode: _selectNode,
            getSelectedNodes: _getSelectedNodes,
            getChecked: _getChecked,
            getCheckedNodeIDs: _getCheckedNodeIDs,
            getCheckedLeafNodeIDs: _getCheckedLeafNodeIDs,
            getOpenedIDs: _getOpenedIDs,
            expandAll: _expandAll,
            setAllSelectStatus: _setAllSelectStatus,
            reverseSelection: _reverseSelection
        }
    }();
})(window);