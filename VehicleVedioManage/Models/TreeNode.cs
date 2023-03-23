using System.Collections;

namespace VehicleVedioManage.Models
{
    /// <summary>
    /// 树形节点
    /// </summary>
    [Serializable]
    public class TreeNode
    {
        /// <summary>
        /// 几点ID
        /// </summary>
        public String id { get; set; }
        /// <summary>
        /// 父节点
        /// </summary>
        public String pid { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public String text { get; set; }
        /// <summary>
        /// 是否选中
        /// </summary>
        public Boolean @checked { get; set; }
        /// <summary>
        /// 枝叶节点
        /// </summary>
        public Boolean leaf { get; set; }
        /// <summary>
        /// 图标
        /// </summary>
        public String iconCls { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public String state { get; set; }
        /// <summary>
        /// 属性
        /// </summary>
        public Hashtable attributes { get; set; }
        /// <summary>
        /// /子
        /// </summary>
        public List<TreeNode> children { get; set; }
        /// <summary>
        /// 构造函数
        /// </summary>
        public TreeNode()
        {
            @checked = false;
            attributes = new Hashtable();
            children = new List<TreeNode>();
            state = "closed";
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_id"></param>
        /// <param name="_text"></param>
        /// <param name="pid"></param>
        public TreeNode(String _id, String _text, String pid)
        {
            id = (_id);
            text = _text;
            leaf = false;
            iconCls = ("");
            this.pid = (pid);
            attributes = new Hashtable();
            children = new List<TreeNode>();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_id"></param>
        /// <param name="_text"></param>
        /// <param name="pid"></param>
        /// <param name="_iconCss"></param>
        public TreeNode(String _id, String _text, String pid, String _iconCss)
        {
            id = (_id);
            text = _text;
            leaf = false;
            iconCls = _iconCss;
            this.pid = (pid);
            attributes = new Hashtable();
            children = new List<TreeNode>();
        }

    }
}
