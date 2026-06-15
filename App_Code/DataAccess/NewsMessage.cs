using NetWise.DBUtility;//Please add references
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
namespace NetWise.DataAccess
{
    /// <summary>
    /// 数据访问类:Message
    /// </summary>
    public partial class NewsMessage
    {
        public NewsMessage()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from NewsMessage");
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
        public int Add(NetWise.Entity.NewsMessage model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into NewsMessage(");
            strSql.Append("MTitle,MContent,MName,MSex,MCompany,MTel,MFax,MEmail,IsRead,CreateTime,Remark,P_ID,NEWSID)");
            strSql.Append(" values (");
            strSql.Append("@MTitle,@MContent,@MName,@MSex,@MCompany,@MTel,@MFax,@MEmail,@IsRead,@CreateTime,@Remark,@P_ID,@NEWSID)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@MTitle", SqlDbType.NVarChar,100),
                    new SqlParameter("@MContent", SqlDbType.NText),
                    new SqlParameter("@MName", SqlDbType.NVarChar,50),
                    new SqlParameter("@MSex", SqlDbType.NVarChar,50),
                    new SqlParameter("@MCompany", SqlDbType.NVarChar,300),
                    new SqlParameter("@MTel", SqlDbType.NVarChar,50),
                    new SqlParameter("@MFax", SqlDbType.NVarChar,50),
                    new SqlParameter("@MEmail", SqlDbType.NVarChar,50),
                    new SqlParameter("@IsRead", SqlDbType.Bit,1),
                    new SqlParameter("@CreateTime", SqlDbType.DateTime),
                    new SqlParameter("@Remark", SqlDbType.NText),
                    new SqlParameter("@P_ID",SqlDbType.Int,4),
                    new SqlParameter("@NEWSID",SqlDbType.Int,4)
            };

            parameters[0].Value = model.MTitle;
            parameters[1].Value = model.MContent;
            parameters[2].Value = model.MName;
            parameters[3].Value = model.MSex;
            parameters[4].Value = model.MCompany;
            parameters[5].Value = model.MTel;
            parameters[6].Value = model.MFax;
            parameters[7].Value = model.MEmail;
            parameters[8].Value = model.IsRead;
            parameters[9].Value = model.CreateTime;
            parameters[10].Value = model.Remark;
            parameters[11].Value = model.P_ID;
            parameters[12].Value = model.NEWSID;

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
        public bool Update(NetWise.Entity.NewsMessage model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update NewsMessage set ");
            strSql.Append("MTitle=@MTitle,");
            strSql.Append("MContent=@MContent,");
            strSql.Append("MName=@MName,");
            strSql.Append("MSex=@MSex,");
            strSql.Append("MCompany=@MCompany,");
            strSql.Append("MTel=@MTel,");
            strSql.Append("MFax=@MFax,");
            strSql.Append("MEmail=@MEmail,");
            strSql.Append("IsRead=@IsRead,");
            strSql.Append("CreateTime=@CreateTime,");
            strSql.Append("Remark=@Remark,");
            strSql.Append("NEWSID=@NEWSID,");
            strSql.Append("P_ID=@P_ID");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@MTitle", SqlDbType.NVarChar,100),
                    new SqlParameter("@MContent", SqlDbType.NText),
                    new SqlParameter("@MName", SqlDbType.NVarChar,50),
                    new SqlParameter("@MSex", SqlDbType.NVarChar,50),
                    new SqlParameter("@MCompany", SqlDbType.NVarChar,300),
                    new SqlParameter("@MTel", SqlDbType.NVarChar,50),
                    new SqlParameter("@MFax", SqlDbType.NVarChar,50),
                    new SqlParameter("@MEmail", SqlDbType.NVarChar,50),
                    new SqlParameter("@IsRead", SqlDbType.Bit,1),
                    new SqlParameter("@CreateTime", SqlDbType.DateTime),
                    new SqlParameter("@Remark", SqlDbType.NText),
                    new SqlParameter("@P_ID",SqlDbType.Int,4),
                    new SqlParameter("@NEWSID",SqlDbType.Int,4),
                    new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.MTitle;
            parameters[1].Value = model.MContent;
            parameters[2].Value = model.MName;
            parameters[3].Value = model.MSex;
            parameters[4].Value = model.MCompany;
            parameters[5].Value = model.MTel;
            parameters[6].Value = model.MFax;
            parameters[7].Value = model.MEmail;
            parameters[8].Value = model.IsRead;
            parameters[9].Value = model.CreateTime;
            parameters[10].Value = model.Remark;
            parameters[11].Value = model.P_ID;
            parameters[12].Value = model.NEWSID;
            parameters[13].Value = model.ID;

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
            strSql.Append("delete from NewsMessage ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int,4)
            };
            parameters[0].Value = ID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            return rows > 0;
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from NewsMessage ");
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
        public NetWise.Entity.NewsMessage GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,MTitle,MContent,MName,MSex,MCompany,MTel,MFax,MEmail,IsRead,CreateTime,Remark,P_ID,NEWSID from NewsMessage ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int,4)
            };
            parameters[0].Value = ID;

            NetWise.Entity.NewsMessage model = new NetWise.Entity.NewsMessage();
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
        public NetWise.Entity.NewsMessage DataRowToModel(DataRow row)
        {
            NetWise.Entity.NewsMessage model = new NetWise.Entity.NewsMessage();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["NEWSID"] != null && row["NEWSID"].ToString() != "")
                {
                    model.NEWSID = int.Parse(row["NEWSID"].ToString());
                }
                if (row["MTitle"] != null)
                {
                    model.MTitle = row["MTitle"].ToString();
                }
                if (row["MContent"] != null)
                {
                    model.MContent = row["MContent"].ToString();
                }
                if (row["MName"] != null)
                {
                    model.MName = row["MName"].ToString();
                }
                if (row["MSex"] != null)
                {
                    model.MSex = row["MSex"].ToString();
                }
                if (row["MCompany"] != null)
                {
                    model.MCompany = row["MCompany"].ToString();
                }
                if (row["MTel"] != null)
                {
                    model.MTel = row["MTel"].ToString();
                }
                if (row["MFax"] != null)
                {
                    model.MFax = row["MFax"].ToString();
                }
                if (row["MEmail"] != null)
                {
                    model.MEmail = row["MEmail"].ToString();
                }
                if (row["IsRead"] != null && row["IsRead"].ToString() != "")
                {
                    if ((row["IsRead"].ToString() == "1") || (row["IsRead"].ToString().ToLower() == "true"))
                    {
                        model.IsRead = true;
                    }
                    else
                    {
                        model.IsRead = false;
                    }
                }
                if (row["CreateTime"] != null && row["CreateTime"].ToString() != "")
                {
                    model.CreateTime = DateTime.Parse(row["CreateTime"].ToString());
                }
                if (row["Remark"] != null)
                {
                    model.Remark = row["Remark"].ToString();
                }
                if (row["P_ID"] != null && row["P_ID"].ToString() != "")
                {
                    model.P_ID = int.Parse(row["P_ID"].ToString());
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
            strSql.Append("select ID,MTitle,MContent,MName,MSex,MCompany,MTel,MFax,MEmail,IsRead,CreateTime,Remark,P_ID,NEWSID ");
            strSql.Append(" from NewsMessage ");
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
            strSql.Append(" ID,MTitle,MContent,MName,MSex,MCompany,MTel,MFax,MEmail,IsRead,CreateTime,Remark,P_ID,NEWSID ");
            strSql.Append(" from NewsMessage ");
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
            strSql.Append("select count(1) from NewsMessage ");
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
            strSql.Append(")AS Row, T.*  from NewsMessage T ");
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
            parameters[0].Value = "Message";
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
        public object GetNumberMessage()
        {
            string sql = "select count(*) from NewsMessage where IsRead=0";
            return DbHelperSQL.GetSingle(sql);
        }
        public bool UpdateMessageForIsRead(int ID)
        {
            string sql = "update NewsMessage set IsRead=1 where ID='" + ID + "'";
            int rows = DbHelperSQL.ExecuteSql(sql);
            return rows > 0;
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListAndNewsByPage(string strWhere, string orderby, int startIndex, int endIndex)
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
            strSql.Append(")AS Row, T.*,T2.EN_Title  from NewsMessage T JOIN News T2 ON T.NEWSID = T2.ID ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion  ExtensionMethod
    }
}

