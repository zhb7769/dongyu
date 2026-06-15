using NetWise.DBUtility;//Please add references
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
namespace NetWise.DataAccess
{
    /// <summary>
    /// 数据访问类:Article
    /// </summary>
    public partial class Article
    {
        public Article()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Article");
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
        public int Add(NetWise.Entity.Article model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Article(");
            strSql.Append("ArticleClassId,CN_Title,EN_Title,CN_KeyWords,EN_KeyWords,Pic_Url,CN_Summary,EN_Summary,CN_Content,EN_Content,Sort,CreateTime,Remark)");
            strSql.Append(" values (");
            strSql.Append("@ArticleClassId,@CN_Title,@EN_Title,@CN_KeyWords,@EN_KeyWords,@Pic_Url,@CN_Summary,@EN_Summary,@CN_Content,@EN_Content,@Sort,@CreateTime,@Remark)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@ArticleClassId", SqlDbType.Int,4),
                    new SqlParameter("@CN_Title", SqlDbType.NVarChar,50),
                    new SqlParameter("@EN_Title", SqlDbType.NVarChar,50),
                    new SqlParameter("@CN_KeyWords", SqlDbType.NVarChar,200),
                    new SqlParameter("@EN_KeyWords", SqlDbType.NVarChar,200),
                    new SqlParameter("@Pic_Url", SqlDbType.NVarChar,200),
                    new SqlParameter("@CN_Summary", SqlDbType.NVarChar,300),
                    new SqlParameter("@EN_Summary", SqlDbType.NVarChar,300),
                    new SqlParameter("@CN_Content", SqlDbType.NText),
                    new SqlParameter("@EN_Content", SqlDbType.NText),
                    new SqlParameter("@Sort", SqlDbType.Int,4),
                    new SqlParameter("@CreateTime", SqlDbType.DateTime),
                    new SqlParameter("@Remark", SqlDbType.NText)};
            parameters[0].Value = model.ArticleClassId;
            parameters[1].Value = model.CN_Title;
            parameters[2].Value = model.EN_Title;
            parameters[3].Value = model.CN_KeyWords;
            parameters[4].Value = model.EN_KeyWords;
            parameters[5].Value = model.Pic_Url;
            parameters[6].Value = model.CN_Summary;
            parameters[7].Value = model.EN_Summary;
            parameters[8].Value = model.CN_Content;
            parameters[9].Value = model.EN_Content;
            parameters[10].Value = model.Sort;
            parameters[11].Value = model.CreateTime;
            parameters[12].Value = model.Remark;

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
        public bool Update(NetWise.Entity.Article model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Article set ");
            strSql.Append("ArticleClassId=@ArticleClassId,");
            strSql.Append("CN_Title=@CN_Title,");
            strSql.Append("EN_Title=@EN_Title,");
            strSql.Append("CN_KeyWords=@CN_KeyWords,");
            strSql.Append("EN_KeyWords=@EN_KeyWords,");
            strSql.Append("Pic_Url=@Pic_Url,");
            strSql.Append("CN_Summary=@CN_Summary,");
            strSql.Append("EN_Summary=@EN_Summary,");
            strSql.Append("CN_Content=@CN_Content,");
            strSql.Append("EN_Content=@EN_Content,");
            strSql.Append("Sort=@Sort,");
            strSql.Append("CreateTime=@CreateTime,");
            strSql.Append("Remark=@Remark");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@ArticleClassId", SqlDbType.Int,4),
                    new SqlParameter("@CN_Title", SqlDbType.NVarChar,50),
                    new SqlParameter("@EN_Title", SqlDbType.NVarChar,50),
                    new SqlParameter("@CN_KeyWords", SqlDbType.NVarChar,200),
                    new SqlParameter("@EN_KeyWords", SqlDbType.NVarChar,200),
                    new SqlParameter("@Pic_Url", SqlDbType.NVarChar,200),
                    new SqlParameter("@CN_Summary", SqlDbType.NVarChar,300),
                    new SqlParameter("@EN_Summary", SqlDbType.NVarChar,300),
                    new SqlParameter("@CN_Content", SqlDbType.NText),
                    new SqlParameter("@EN_Content", SqlDbType.NText),
                    new SqlParameter("@Sort", SqlDbType.Int,4),
                    new SqlParameter("@CreateTime", SqlDbType.DateTime),
                    new SqlParameter("@Remark", SqlDbType.NText),
                    new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.ArticleClassId;
            parameters[1].Value = model.CN_Title;
            parameters[2].Value = model.EN_Title;
            parameters[3].Value = model.CN_KeyWords;
            parameters[4].Value = model.EN_KeyWords;
            parameters[5].Value = model.Pic_Url;
            parameters[6].Value = model.CN_Summary;
            parameters[7].Value = model.EN_Summary;
            parameters[8].Value = model.CN_Content;
            parameters[9].Value = model.EN_Content;
            parameters[10].Value = model.Sort;
            parameters[11].Value = model.CreateTime;
            parameters[12].Value = model.Remark;
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
            strSql.Append("delete from Article ");
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
            strSql.Append("delete from Article ");
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
        public NetWise.Entity.Article GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,ArticleClassId,CN_Title,EN_Title,CN_KeyWords,EN_KeyWords,Pic_Url,CN_Summary,EN_Summary,CN_Content,EN_Content,Sort,CreateTime,Remark from Article ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int,4)
            };
            parameters[0].Value = ID;

            NetWise.Entity.Article model = new NetWise.Entity.Article();
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
        public NetWise.Entity.Article DataRowToModel(DataRow row)
        {
            NetWise.Entity.Article model = new NetWise.Entity.Article();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["ArticleClassId"] != null && row["ArticleClassId"].ToString() != "")
                {
                    model.ArticleClassId = int.Parse(row["ArticleClassId"].ToString());
                }
                if (row["CN_Title"] != null)
                {
                    model.CN_Title = row["CN_Title"].ToString();
                }
                if (row["EN_Title"] != null)
                {
                    model.EN_Title = row["EN_Title"].ToString();
                }
                if (row["CN_KeyWords"] != null)
                {
                    model.CN_KeyWords = row["CN_KeyWords"].ToString();
                }
                if (row["EN_KeyWords"] != null)
                {
                    model.EN_KeyWords = row["EN_KeyWords"].ToString();
                }
                if (row["Pic_Url"] != null)
                {
                    model.Pic_Url = row["Pic_Url"].ToString();
                }
                if (row["CN_Summary"] != null)
                {
                    model.CN_Summary = row["CN_Summary"].ToString();
                }
                if (row["EN_Summary"] != null)
                {
                    model.EN_Summary = row["EN_Summary"].ToString();
                }
                if (row["CN_Content"] != null)
                {
                    model.CN_Content = row["CN_Content"].ToString();
                }
                if (row["EN_Content"] != null)
                {
                    model.EN_Content = row["EN_Content"].ToString();
                }
                if (row["Sort"] != null && row["Sort"].ToString() != "")
                {
                    model.Sort = int.Parse(row["Sort"].ToString());
                }
                if (row["CreateTime"] != null && row["CreateTime"].ToString() != "")
                {
                    model.CreateTime = DateTime.Parse(row["CreateTime"].ToString());
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
            strSql.Append("select ID,ArticleClassId,CN_Title,EN_Title,CN_KeyWords,EN_KeyWords,Pic_Url,CN_Summary,EN_Summary,CN_Content,EN_Content,Sort,CreateTime,Remark ");
            strSql.Append(" FROM Article ");
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
            strSql.Append(" ID,ArticleClassId,CN_Title,EN_Title,CN_KeyWords,EN_KeyWords,Pic_Url,CN_Summary,EN_Summary,CN_Content,EN_Content,Sort,CreateTime,Remark ");
            strSql.Append(" FROM Article ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where 0=0 " + strWhere);
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
            strSql.Append("select count(1) FROM Article ");
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
            strSql.Append(")AS Row, T.*  from Article T ");
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
            parameters[0].Value = "Article";
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
        /// 根据类别ID得到一个实体（像公司简介，联系我们之类的单片文章使用）
        /// </summary>
        /// <param name="classId">类别ID</param>
        /// <returns></returns>
        public NetWise.Entity.Article GetModelByClassID(int classId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,ArticleClassId,CN_Title,EN_Title,CN_KeyWords,EN_KeyWords,Pic_Url,CN_Summary,EN_Summary,CN_Content,EN_Content,Sort,CreateTime,Remark from Article ");
            strSql.Append(" where ArticleClassId=@classId");
            SqlParameter[] parameters = {
                    new SqlParameter("@classId", SqlDbType.Int,4)
            };
            parameters[0].Value = classId;

            NetWise.Entity.Article model = new NetWise.Entity.Article();
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
        #endregion  ExtensionMethod
    }
}

