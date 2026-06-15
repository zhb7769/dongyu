using NetWise.DBUtility;//Please add references
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
namespace NetWise.DataAccess
{
    /// <summary>
    /// 数据访问类:pro_att_info
    /// </summary>
    public partial class pro_att_info
    {
        public pro_att_info()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("at_id", "pro_att_info");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int at_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from pro_att_info");
            strSql.Append(" where at_id=@at_id ");
            SqlParameter[] parameters = {
                    new SqlParameter("@at_id", SqlDbType.Int,4)         };
            parameters[0].Value = at_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(NetWise.Entity.pro_att_info model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into pro_att_info(");
            strSql.Append("at_id,pro_id,pro_img,create_time)");
            strSql.Append(" values (");
            strSql.Append("@at_id,@pro_id,@pro_img,@create_time)");
            SqlParameter[] parameters = {
                    new SqlParameter("@at_id", SqlDbType.Int,4),
                    new SqlParameter("@pro_id", SqlDbType.Int,4),
                    new SqlParameter("@pro_img", SqlDbType.VarChar,200),
                    new SqlParameter("@create_time", SqlDbType.DateTime)};
            parameters[0].Value = model.at_id;
            parameters[1].Value = model.pro_id;
            parameters[2].Value = model.pro_img;
            parameters[3].Value = model.create_time;

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
        /// 更新一条数据
        /// </summary>
        public bool Update(NetWise.Entity.pro_att_info model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update pro_att_info set ");
            strSql.Append("pro_id=@pro_id,");
            strSql.Append("pro_img=@pro_img,");
            strSql.Append("create_time=@create_time");
            strSql.Append(" where at_id=@at_id ");
            SqlParameter[] parameters = {
                    new SqlParameter("@pro_id", SqlDbType.Int,4),
                    new SqlParameter("@pro_img", SqlDbType.VarChar,200),
                    new SqlParameter("@create_time", SqlDbType.DateTime),
                    new SqlParameter("@at_id", SqlDbType.Int,4)};
            parameters[0].Value = model.pro_id;
            parameters[1].Value = model.pro_img;
            parameters[2].Value = model.create_time;
            parameters[3].Value = model.at_id;

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
        public bool Delete(int at_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from pro_att_info ");
            strSql.Append(" where at_id=@at_id ");
            SqlParameter[] parameters = {
                    new SqlParameter("@at_id", SqlDbType.Int,4)         };
            parameters[0].Value = at_id;

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
        public bool DeleteList(string at_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from pro_att_info ");
            strSql.Append(" where at_id in (" + at_idlist + ")  ");
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
        public NetWise.Entity.pro_att_info GetModel(int at_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 at_id,pro_id,pro_img,create_time from pro_att_info ");
            strSql.Append(" where at_id=@at_id ");
            SqlParameter[] parameters = {
                    new SqlParameter("@at_id", SqlDbType.Int,4)         };
            parameters[0].Value = at_id;

            NetWise.Entity.pro_att_info model = new NetWise.Entity.pro_att_info();
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
        public NetWise.Entity.pro_att_info DataRowToModel(DataRow row)
        {
            NetWise.Entity.pro_att_info model = new NetWise.Entity.pro_att_info();
            if (row != null)
            {
                if (row["at_id"] != null && row["at_id"].ToString() != "")
                {
                    model.at_id = int.Parse(row["at_id"].ToString());
                }
                if (row["pro_id"] != null && row["pro_id"].ToString() != "")
                {
                    model.pro_id = int.Parse(row["pro_id"].ToString());
                }
                if (row["pro_img"] != null)
                {
                    model.pro_img = row["pro_img"].ToString();
                }
                if (row["create_time"] != null && row["create_time"].ToString() != "")
                {
                    model.create_time = DateTime.Parse(row["create_time"].ToString());
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
            strSql.Append("select at_id,pro_id,pro_img,create_time ");
            strSql.Append(" FROM pro_att_info ");
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
            strSql.Append(" at_id,pro_id,pro_img,create_time ");
            strSql.Append(" FROM pro_att_info ");
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
            strSql.Append("select count(1) FROM pro_att_info ");
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
                strSql.Append("order by T.at_id desc");
            }
            strSql.Append(")AS Row, T.*  from pro_att_info T ");
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
			parameters[0].Value = "pro_att_info";
			parameters[1].Value = "at_id";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}


