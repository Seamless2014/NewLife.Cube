using NewLife.Cube.ViewModels;

namespace NewLife.Cube
{
    /// <summary>
    /// ZTree 帮助类
    /// </summary>
    public class ZTreeHelper
    {
        /// <summary>
        /// 泛型递归的树状数据结构
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="childClassesId"></param>
        /// <param name="allZTreeNodes"></param>
        /// <returns></returns>
        private static List<ZTreeNode<T>> GetChildTreeData<T>(List<string> childClassesId, List<ZTreeNode<T>> allZTreeNodes)
        {
            var childZTreeNode = new List<ZTreeNode<T>>();
            var childNodes = allZTreeNodes.Where(x=>x.ToBoolean()==true).ToList();
            if (childNodes != null && childNodes.Count > 0)
            {
                foreach (var x in childNodes)
                {
                    var ZTreeNode = new ZTreeNode<T>();
                    ZTreeNode.ID =x.ID ;
                    ZTreeNode.PID = x.PID;
                    ZTreeNode.Name = x.Name;
                    ZTreeNode.Open = x.Open;
                    ZTreeNode.CheckDisabled = x.CheckDisabled;
                    var rootClassItem = childNodes.FirstOrDefault(x => x.ID == ZTreeNode.ID);
                    if (rootClassItem != null)
                    {
                        ZTreeNode.Children = GetChildTreeData<T>(childClassesId, childNodes);
                        ZTreeNode.IsClick = x.Children.Count > 0 ? x.Children.Where(c => c.IsClick).Count() > 0 : childClassesId.Contains("");
                        ZTreeNode.IsParent = x.Children.Count > 0;
                    }
                    childZTreeNode.Add(ZTreeNode);
                }
            }
            return childZTreeNode;
        }
    }
}
