using System.Collections;

namespace VehicleVedioManage.Common
{
    /// <summary>
    /// 分页结果
    /// </summary>
    public class PaginateResult
    {
        /// <summary>
        /// 实际的行数
        /// </summary>
        public int iTotalRecords { get; set; }
        /// <summary>
        /// 过滤之后，实际的行数。
        /// </summary>
        public int iTotalDisplayRecords { get; set; }
        //来自客户端 sEcho 的没有变化的复制品，
        public String sEcho { get; set; }
        /// <summary>
        /// 可选，以逗号分隔的列名，
        /// </summary>
        public String sColumns { get; set; }
        /// <summary>
        /// 数组的数组，表格中的实际数据。　
        /// </summary>        
        public IList aaData { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public PaginateResult()
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="total"></param>
        /// <param name="result"></param>
        /// <param name="echo"></param>
        public PaginateResult(int total, IList result, String echo)
        {
            aaData = result;
            iTotalRecords = total;
            iTotalDisplayRecords = total;//result.size();
            sEcho = echo;
        }

    }
}
