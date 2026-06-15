using NetWise.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
namespace NetWise.DataAccess
{
    /// <summary>
    /// 数据访问类:LoginBanner
    /// </summary>
    public partial class LoginBanner
    {
        public LoginBanner()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int B_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from LoginBanner");
            strSql.Append(" where B_ID=@B_ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@B_ID", SqlDbType.Int,4)
            };
            parameters[0].Value = B_ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(NetWise.Entity.LoginBanner model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into LoginBanner(");
            strSql.Append("B_Title,B_Pic,B_Add,B_Style,B_Sort)");
            strSql.Append(" values (");
            strSql.Append("@B_Title,@B_Pic,@B_Add,@B_Style,@B_Sort)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@B_Title", SqlDbType.NVarChar,50),
                    new SqlParameter("@B_Pic", SqlDbType.NVarChar,300),
                    new SqlParameter("@B_Add", SqlDbType.NVarChar,300),
                    new SqlParameter("@B_Style", SqlDbType.NVarChar,300),
                    new SqlParameter("@B_Sort", SqlDbType.Int,4)};
            parameters[0].Value = model.B_Title;
            parameters[1].Value = model.B_Pic;
            parameters[2].Value = model.B_Add;
            parameters[3].Value = model.B_Style;
            parameters[4].Value = model.B_Sort;

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
        public bool Update(NetWise.Entity.LoginBanner model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update LoginBanner set ");
            strSql.Append("B_Title=@B_Title,");
            strSql.Append("B_Pic=@B_Pic,");
            strSql.Append("B_Add=@B_Add,");
            strSql.Append("B_Style=@B_Style,");
            strSql.Append("B_Sort=@B_Sort");
            strSql.Append(" where B_ID=@B_ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@B_Title", SqlDbType.NVarChar,50),
                    new SqlParameter("@B_Pic", SqlDbType.NVarChar,300),
                    new SqlParameter("@B_Add", SqlDbType.NVarChar,300),
                    new SqlParameter("@B_Style", SqlDbType.NVarChar,300),
                    new SqlParameter("@B_Sort", SqlDbType.Int,4),
                    new SqlParameter("@B_ID", SqlDbType.Int,4)};
            parameters[0].Value = model.B_Title;
            parameters[1].Value = model.B_Pic;
            parameters[2].Value = model.B_Add;
            parameters[3].Value = model.B_Style;
            parameters[4].Value = model.B_Sort;
            parameters[5].Value = model.B_ID;

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
        public bool Delete(int B_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from LoginBanner ");
            strSql.Append(" where B_ID=@B_ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@B_ID", SqlDbType.Int,4)
            };
            parameters[0].Value = B_ID;

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
        public bool DeleteList(string B_IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from LoginBanner ");
            strSql.Append(" where B_ID in (" + B_IDlist + ")  ");
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
        public NetWise.Entity.LoginBanner GetModel(int B_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 B_ID,B_Title,B_Pic,B_Add,B_Style,B_Sort from LoginBanner ");
            strSql.Append(" where B_ID=@B_ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@B_ID", SqlDbType.Int,4)
            };
            parameters[0].Value = B_ID;

            NetWise.Entity.LoginBanner model = new NetWise.Entity.LoginBanner();
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
        public NetWise.Entity.LoginBanner DataRowToModel(DataRow row)
        {
            NetWise.Entity.LoginBanner model = new NetWise.Entity.LoginBanner();
            if (row != null)
            {
                if (row["B_ID"] != null && row["B_ID"].ToString() != "")
                {
                    model.B_ID = int.Parse(row["B_ID"].ToString());
                }
                if (row["B_Title"] != null)
                {
                    model.B_Title = row["B_Title"].ToString();
                }
                if (row["B_Pic"] != null)
                {
                    model.B_Pic = row["B_Pic"].ToString();
                }
                if (row["B_Add"] != null)
                {
                    model.B_Add = row["B_Add"].ToString();
                }
                if (row["B_Style"] != null)
                {
                    model.B_Style = row["B_Style"].ToString();
                }
                if (row["B_Sort"] != null && row["B_Sort"].ToString() != "")
                {
                    model.B_Sort = int.Parse(row["B_Sort"].ToString());
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
            strSql.Append("select B_ID,B_Title,B_Pic,B_Add,B_Style,B_Sort ");
            strSql.Append(" FROM LoginBanner ");
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
            strSql.Append(" B_ID,B_Title,B_Pic,B_Add,B_Style,B_Sort ");
            strSql.Append(" FROM LoginBanner ");
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
            strSql.Append("select count(1) FROM LoginBanner ");
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
                strSql.Append("order by T.B_ID desc");
            }
            strSql.Append(")AS Row, T.*  from LoginBanner T ");
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
            parameters[0].Value = "LoginBanner";
            parameters[1].Value = "B_ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod
        /// <summary>
        /// 更新排序
        /// </summary>
        /// <param name="Sort"></param>
        /// <param name="ID"></param>
        /// <returns></returns>
        public bool UpdateLoginBannerBySort(int Sort, int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update LoginBanner set ");
            strSql.Append("B_Sort=@B_Sort");
            strSql.Append(" where B_ID=@B_ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@Sort", SqlDbType.Int,4),
                    new SqlParameter("@B_ID", SqlDbType.Int,4)
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

        public List<NetWise.Entity.LoginBanner> GetList()
        {
            List<NetWise.Entity.LoginBanner> list = new List<NetWise.Entity.LoginBanner>();

            StringBuilder builder = new StringBuilder();
            builder.Append("select B_ID,B_Title,B_Pic,B_Add,B_Style,B_Sort ");
            builder.Append(" from LoginBanner ");
            builder.Append(" ORDER BY B_Sort ASC");
            DataSet ds = NetWise.DBUtility.DbHelperSQL.Query(builder.ToString());
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

