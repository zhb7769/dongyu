using NetWise.DBUtility;//Please add references
using System;
using System.Data;
namespace NetWise.DataAccess
{
    /// <summary>
    ///Total 的摘要说明
    /// </summary>
    public class Total
    {
        public Total()
        { }
        #region 网站访问量 在线人数
        public int GetVisitsCount()
        {
            int ret = 0;
            string sql = "select * from Total";
            DataSet ds = DbHelperSQL.Query(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ret = Convert.ToInt32(ds.Tables[0].Rows[0]["VisitsCount"].ToString());
            }
            return ret;
        }
        /// <summary>
        /// 更新网站访问量
        /// </summary>
        /// <param name="VisitsCount">网站访问数量</param>
        /// <returns></returns>
        public int UpdateVisitsCount(int VisitsCount)
        {
            string sql = "update Total set VisitsCount=" + VisitsCount;
            return DbHelperSQL.ExecuteSql(sql);
        }
        #endregion
    }
}
