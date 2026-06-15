using NetWise.DBUtility;
using System;
using System.Collections.Generic;//Please add references
using System.Data;
using System.Data.SqlClient;
using System.Text;
namespace NetWise.DataAccess
{
    /// <summary>
    /// 数据访问类:Link
    /// </summary>
    public partial class Link
    {
        public Link()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Link");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int,4)
            };
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(NetWise.Entity.Link model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Link(");
            strSql.Append("LinkName,LinkName_en,LinkPic,LinkUrl,LinkType,Sort)");
            strSql.Append(" values (");
            strSql.Append("@LinkName,@LinkName_en,@LinkPic,@LinkUrl,@LinkType,@Sort)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@LinkName", SqlDbType.NVarChar,300),
                    new SqlParameter("@LinkName_en", SqlDbType.NVarChar,300),
                    new SqlParameter("@LinkPic", SqlDbType.NVarChar,300),
                    new SqlParameter("@LinkUrl", SqlDbType.NVarChar,300),
                    new SqlParameter("@LinkType", SqlDbType.Int,4),
                    new SqlParameter("@Sort", SqlDbType.Int,4)};
            parameters[0].Value = model.LinkName;
            parameters[1].Value = model.LinkName_en;
            parameters[2].Value = model.LinkPic;
            parameters[3].Value = model.LinkUrl;
            parameters[4].Value = model.LinkType;
            parameters[5].Value = model.Sort;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(NetWise.Entity.Link model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Link set ");
            strSql.Append("LinkName=@LinkName,");
            strSql.Append("LinkName_en=@LinkName_en,");
            strSql.Append("LinkPic=@LinkPic,");
            strSql.Append("LinkUrl=@LinkUrl,");
            strSql.Append("LinkType=@LinkType,");
            strSql.Append("Sort=@Sort");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@LinkName", SqlDbType.NVarChar,300),
                    new SqlParameter("@LinkName_en", SqlDbType.NVarChar,300),
                    new SqlParameter("@LinkPic", SqlDbType.NVarChar,300),
                    new SqlParameter("@LinkUrl", SqlDbType.NVarChar,300),
                    new SqlParameter("@LinkType", SqlDbType.Int,4),
                    new SqlParameter("@Sort", SqlDbType.Int,4),
                    new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.LinkName;
            parameters[1].Value = model.LinkName_en;
            parameters[2].Value = model.LinkPic;
            parameters[3].Value = model.LinkUrl;
            parameters[4].Value = model.LinkType;
            parameters[5].Value = model.Sort;
            parameters[6].Value = model.ID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 更新排序
        /// </summary>
        /// <param name="Sort"></param>
        /// <param name="ID"></param>
        /// <returns></returns>
        public bool UpdateLinkBySort(int Sort, int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Link set ");
            strSql.Append("Sort=@Sort");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@Sort", SqlDbType.Int,4),
                    new SqlParameter("@ID", SqlDbType.Int,4)
            };
            parameters[0].Value = Sort;
            parameters[1].Value = ID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Link ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int,4)
            };
            parameters[0].Value = ID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Link ");
            strSql.Append(" where ID in (" + IDlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public NetWise.Entity.Link GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,LinkName,LinkName_en,LinkPic,LinkUrl,LinkType,Sort from Link ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int,4)
            };
            parameters[0].Value = ID;

            NetWise.Entity.Link model = new NetWise.Entity.Link();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public NetWise.Entity.Link DataRowToModel(DataRow row)
        {
            NetWise.Entity.Link model = new NetWise.Entity.Link();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["LinkName"] != null)
                {
                    model.LinkName = row["LinkName"].ToString();
                }
                if (row["LinkName_en"] != null)
                {
                    model.LinkName_en = row["LinkName_en"].ToString();
                }
                if (row["LinkPic"] != null)
                {
                    model.LinkPic = row["LinkPic"].ToString();
                }
                if (row["LinkUrl"] != null)
                {
                    model.LinkUrl = row["LinkUrl"].ToString();
                }
                if (row["LinkType"] != null && row["LinkType"].ToString() != "")
                {
                    model.LinkType = int.Parse(row["LinkType"].ToString());
                }
                if (row["Sort"] != null && row["Sort"].ToString() != "")
                {
                    model.Sort = int.Parse(row["Sort"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,LinkName,LinkName_en,LinkPic,LinkUrl,LinkType,Sort ");
            strSql.Append(" FROM Link ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" ID,LinkName,LinkName_en,LinkPic,LinkUrl,LinkType,Sort ");
            strSql.Append(" FROM Link ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM Link ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.ID desc");
            }
            strSql.Append(")AS Row, T.*  from Link T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "Link";
            parameters[1].Value = "ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod

        public List<NetWise.Entity.Link> GetList()
        {
            List<NetWise.Entity.Link> list = new List<NetWise.Entity.Link>();

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,LinkName,LinkName_en,LinkPic,LinkUrl,LinkType,Sort ");
            strSql.Append(" from Link ");
            strSql.Append(" ORDER BY Sort ASC");
            DataSet ds = NetWise.DBUtility.DbHelperSQL.Query(strSql.ToString());
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    list.Add(DataRowToModel(ds.Tables[0].Rows[i]));
                }
            }

            return list;
        }
        #endregion  ExtensionMethod
    }
}


