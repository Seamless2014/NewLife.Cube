namespace NewLife.Cube.ViewModels
{
    /// <summary>
    /// ZTree 节点
    /// </summary>
    public class ZTreeNode<T>
    {
        /// <summary>
        /// 节点
        /// </summary>
        public string ID { get; set; }  
        /// <summary>
        /// 父节点
        /// </summary>
        public string PID { get; set; }
        /// <summary>
        /// 节点名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 文本图标
        /// </summary>
        public string TextIcon {  get; set; }
        /// <summary>
        /// 图标颜色
        /// </summary>
        public string ColorIcon {  get; set; }
        /// <summary>
        /// 是否展开
        /// </summary>
        public bool Open {  get; set; }
        /// <summary>
        /// 是否多选
        /// </summary>
        public bool Checked { get; set; }
        /// <summary>
        /// 多选是否可用
        /// </summary>
        public bool CheckDisabled { get; set; }
        /// <summary>
        /// 是否点击
        /// </summary>
        public bool IsClick {  get; set; }
        /// <summary>
        /// Click事件操作
        /// </summary>
        public string Click { get; set; }      
        /// <summary>
        /// URL
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 是否父节点
        /// </summary>
        public bool IsParent { get; set; }
        /// <summary>
        /// 节点图标
        /// </summary>
        public string Icon {  get; set; }
        /// <summary>
        /// 关闭图标
        /// </summary>
        public string IconClose {  get; set; }
        /// <summary>
        /// 打开图标
        /// </summary>
        public string IconOpen {  get; set; }
        /// <summary>
        /// 图标皮肤
        /// </summary>
        public string IconSkin {  get; set; }
        /// <summary>
        /// 是否隐藏
        /// </summary>
        public bool IsHidden {  get; set; }
        /// <summary>
        /// 设置点击节点后在何处打开 url
        /// </summary>
        public string Target {  get; set; }
        /// <summary>
        /// 子节点
        /// </summary>
        public List<ZTreeNode<T>> Children { get; set; } = new List<ZTreeNode<T>>();
        /// <summary>
        /// 重载ToString
        /// </summary>
        /// <returns></returns>
        public override String ToString()
        { 
            base.ToString();
            return Name;
        }
    }
}
