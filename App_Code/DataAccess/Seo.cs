using NetWise.DBUtility;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
namespace NetWise.DataAccess
{
    /// <summary>
    /// 数据访问类:Seo
    /// </summary>
    public partial class Seo
    {
        public Seo()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Seo");
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
        public int Add(NetWise.Entity.Seo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Seo(");
            strSql.Append("CN_Title,EN_Title,CN_Keywords,EN_Keywords,CN_Description,EN_Description,Remark)");
            strSql.Append(" values (");
            strSql.Append("@CN_Title,@EN_Title,@CN_Keywords,@EN_Keywords,@CN_Description,@EN_Description,@Remark)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@CN_Title", SqlDbType.NVarChar,100),
                    new SqlParameter("@EN_Title", SqlDbType.NVarChar,100),
                    new SqlParameter("@CN_Keywords", SqlDbType.NVarChar,500),
                    new SqlParameter("@EN_Keywords", SqlDbType.NVarChar,500),
                    new SqlParameter("@CN_Description", SqlDbType.NText),
                    new SqlParameter("@EN_Description", SqlDbType.NText),
                    new SqlParameter("@Remark", SqlDbType.NText)};
            parameters[0].Value = model.CN_Title;
            parameters[1].Value = model.EN_Title;
            parameters[2].Value = model.CN_Keywords;
            parameters[3].Value = model.EN_Keywords;
            parameters[4].Value = model.CN_Description;
            parameters[5].Value = model.EN_Description;
            parameters[6].Value = model.Remark;

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
        public bool Update(NetWise.Entity.Seo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Seo set ");
            strSql.Append("CN_Title=@CN_Title,");
            strSql.Append("EN_Title=@EN_Title,");
            strSql.Append("CN_Keywords=@CN_Keywords,");
            strSql.Append("EN_Keywords=@EN_Keywords,");
            strSql.Append("CN_Description=@CN_Description,");
            strSql.Append("EN_Description=@EN_Description,");
            strSql.Append("Remark=@Remark");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@CN_Title", SqlDbType.NVarChar,100),
                    new SqlParameter("@EN_Title", SqlDbType.NVarChar,100),
                    new SqlParameter("@CN_Keywords", SqlDbType.NVarChar,500),
                    new SqlParameter("@EN_Keywords", SqlDbType.NVarChar,500),
                    new SqlParameter("@CN_Description", SqlDbType.NText),
                    new SqlParameter("@EN_Description", SqlDbType.NText),
                    new SqlParameter("@Remark", SqlDbType.NText),
                    new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.CN_Title;
            parameters[1].Value = model.EN_Title;
            parameters[2].Value = model.CN_Keywords;
            parameters[3].Value = model.EN_Keywords;
            parameters[4].Value = model.CN_Description;
            parameters[5].Value = model.EN_Description;
            parameters[6].Value = model.Remark;
            parameters[7].Value = model.ID;

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
            strSql.Append("delete from Seo ");
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
            strSql.Append("delete from Seo ");
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
        public NetWise.Entity.Seo GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,CN_Title,EN_Title,CN_Keywords,EN_Keywords,CN_Description,EN_Description,Remark from Seo ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int,4)
            };
            parameters[0].Value = ID;

            NetWise.Entity.Seo model = new NetWise.Entity.Seo();
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
        public NetWise.Entity.Seo DataRowToModel(DataRow row)
        {
            NetWise.Entity.Seo model = new NetWise.Entity.Seo();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["CN_Title"] != null)
                {
                    model.CN_Title = row["CN_Title"].ToString();
                }
                if (row["EN_Title"] != null)
                {
                    model.EN_Title = row["EN_Title"].ToString();
                }
                if (row["CN_Keywords"] != null)
                {
                    model.CN_Keywords = row["CN_Keywords"].ToString();
                }
                if (row["EN_Keywords"] != null)
                {
                    model.EN_Keywords = row["EN_Keywords"].ToString();
                }
                if (row["CN_Description"] != null)
                {
                    model.CN_Description = row["CN_Description"].ToString();
                }
                if (row["EN_Description"] != null)
                {
                    model.EN_Description = row["EN_Description"].ToString();
                }
                if (row["Remark"] != null)
                {
                    model.Remark = row["Remark"].ToString();
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
            strSql.Append("select ID,CN_Title,EN_Title,CN_Keywords,EN_Keywords,CN_Description,EN_Description,Remark ");
            strSql.Append(" FROM Seo ");
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
            strSql.Append(" ID,CN_Title,EN_Title,CN_Keywords,EN_Keywords,CN_Description,EN_Description,Remark ");
            strSql.Append(" FROM Seo ");
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
            strSql.Append("select count(1) FROM Seo ");
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
            strSql.Append(")AS Row, T.*  from Seo T ");
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
            parameters[0].Value = "Seo";
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
        /// <summary>
        /// 是否存在记录 获取ID的值
        /// </summary>
        /// <returns></returns> 
        public int GetScalar()
        {
            int id = 0;
            if (DbHelperSQL.Exists("select count(1) from Seo"))
            {
                object obj = DbHelperSQL.GetSingle("select ID from Seo");
                if (null != obj && Int32.TryParse(obj.ToString(), out id))
                {
                    return id;
                }
                else
                {
                    return id;
                }
            }
            else
            {
                return id;
            }
        }
        /// <summary>
        /// 根据类型检查是否存在记录 并获取ID的值
        /// </summary>
        /// <param name="type">类型（首页、关于我们、产品展示、新闻动态等）</param>
        /// <returns>ID</returns>
        public int GetScalar(string type)
        {
            int id = 0;
            if (DbHelperSQL.Exists("select count(1) from Seo where Remark='" + type + "'"))
            {
                object obj = DbHelperSQL.GetSingle("select ID from Seo Remark='" + type + "'");
                if (null != obj && Int32.TryParse(obj.ToString(), out id))
                {
                    return id;
                }
                else
                {
                    return id;
                }
            }
            else
            {
                return id;
            }
        }
        #endregion  ExtensionMethod
    }
}

