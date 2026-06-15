using NetWise.DBUtility;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
namespace NetWise.DataAccess
{
    /// <summary>
    /// 数据访问类:Download
    /// </summary>
    public partial class Download
    {
        public Download()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Download");
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
        public int Add(NetWise.Entity.Download model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Download(");
            strSql.Append("CN_Title,EN_Title,CN_Summary,EN_Summary,Download_Url,CN_Content,EN_Content,CreateTime,Sort,ClassId,Remark)");
            strSql.Append(" values (");
            strSql.Append("@CN_Title,@EN_Title,@CN_Summary,@EN_Summary,@Download_Url,@CN_Content,@EN_Content,@CreateTime,@Sort,@ClassId,@Remark)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@CN_Title", SqlDbType.NVarChar,50),
                    new SqlParameter("@EN_Title", SqlDbType.NVarChar,50),
                    new SqlParameter("@CN_Summary", SqlDbType.NVarChar,300),
                    new SqlParameter("@EN_Summary", SqlDbType.NVarChar,300),
                    new SqlParameter("@Download_Url", SqlDbType.NVarChar,50),
                    new SqlParameter("@CN_Content", SqlDbType.NText),
                    new SqlParameter("@EN_Content", SqlDbType.NText),
                    new SqlParameter("@CreateTime", SqlDbType.DateTime),
                    new SqlParameter("@Sort", SqlDbType.Int,4),
                    new SqlParameter("@ClassId", SqlDbType.Int,4),
                    new SqlParameter("@Remark", SqlDbType.NText)};
            parameters[0].Value = model.CN_Title;
            parameters[1].Value = model.EN_Title;
            parameters[2].Value = model.CN_Summary;
            parameters[3].Value = model.EN_Summary;
            parameters[4].Value = model.Download_Url;
            parameters[5].Value = model.CN_Content;
            parameters[6].Value = model.EN_Content;
            parameters[7].Value = model.CreateTime;
            parameters[8].Value = model.Sort;
            parameters[9].Value = model.ClassId;
            parameters[10].Value = model.Remark;

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
        public bool Update(NetWise.Entity.Download model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Download set ");
            strSql.Append("CN_Title=@CN_Title,");
            strSql.Append("EN_Title=@EN_Title,");
            strSql.Append("CN_Summary=@CN_Summary,");
            strSql.Append("EN_Summary=@EN_Summary,");
            strSql.Append("Download_Url=@Download_Url,");
            strSql.Append("CN_Content=@CN_Content,");
            strSql.Append("EN_Content=@EN_Content,");
            strSql.Append("CreateTime=@CreateTime,");
            strSql.Append("Sort=@Sort,");
            strSql.Append("ClassId=@ClassId,");
            strSql.Append("Remark=@Remark");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@CN_Title", SqlDbType.NVarChar,50),
                    new SqlParameter("@EN_Title", SqlDbType.NVarChar,50),
                    new SqlParameter("@CN_Summary", SqlDbType.NVarChar,300),
                    new SqlParameter("@EN_Summary", SqlDbType.NVarChar,300),
                    new SqlParameter("@Download_Url", SqlDbType.NVarChar,50),
                    new SqlParameter("@CN_Content", SqlDbType.NText),
                    new SqlParameter("@EN_Content", SqlDbType.NText),
                    new SqlParameter("@CreateTime", SqlDbType.DateTime),
                    new SqlParameter("@Sort", SqlDbType.Int,4),
                    new SqlParameter("@ClassId", SqlDbType.Int,4),
                    new SqlParameter("@Remark", SqlDbType.NText),
                    new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.CN_Title;
            parameters[1].Value = model.EN_Title;
            parameters[2].Value = model.CN_Summary;
            parameters[3].Value = model.EN_Summary;
            parameters[4].Value = model.Download_Url;
            parameters[5].Value = model.CN_Content;
            parameters[6].Value = model.EN_Content;
            parameters[7].Value = model.CreateTime;
            parameters[8].Value = model.Sort;
            parameters[9].Value = model.ClassId;
            parameters[10].Value = model.Remark;
            parameters[11].Value = model.ID;

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
            strSql.Append("delete from Download ");
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
            strSql.Append("delete from Download ");
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
        public NetWise.Entity.Download GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,CN_Title,EN_Title,CN_Summary,EN_Summary,Download_Url,CN_Content,EN_Content,CreateTime,Sort,ClassId,Remark from Download ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int,4)
            };
            parameters[0].Value = ID;

            NetWise.Entity.Download model = new NetWise.Entity.Download();
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
        public NetWise.Entity.Download DataRowToModel(DataRow row)
        {
            NetWise.Entity.Download model = new NetWise.Entity.Download();
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
                if (row["CN_Summary"] != null)
                {
                    model.CN_Summary = row["CN_Summary"].ToString();
                }
                if (row["EN_Summary"] != null)
                {
                    model.EN_Summary = row["EN_Summary"].ToString();
                }
                if (row["Download_Url"] != null)
                {
                    model.Download_Url = row["Download_Url"].ToString();
                }
                if (row["CN_Content"] != null)
                {
                    model.CN_Content = row["CN_Content"].ToString();
                }
                if (row["EN_Content"] != null)
                {
                    model.EN_Content = row["EN_Content"].ToString();
                }
                if (row["CreateTime"] != null && row["CreateTime"].ToString() != "")
                {
                    model.CreateTime = DateTime.Parse(row["CreateTime"].ToString());
                }
                if (row["Sort"] != null && row["Sort"].ToString() != "")
                {
                    model.Sort = int.Parse(row["Sort"].ToString());
                }
                if (row["ClassId"] != null && row["ClassId"].ToString() != "")
                {
                    model.ClassId = int.Parse(row["ClassId"].ToString());
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
            strSql.Append("select ID,CN_Title,EN_Title,CN_Summary,EN_Summary,Download_Url,CN_Content,EN_Content,CreateTime,Sort,ClassId,Remark ");
            strSql.Append(" FROM Download ");
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
            strSql.Append(" ID,CN_Title,EN_Title,CN_Summary,EN_Summary,Download_Url,CN_Content,EN_Content,CreateTime,Sort,ClassId,Remark ");
            strSql.Append(" FROM Download ");
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
            strSql.Append("select count(1) FROM Download ");
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
            strSql.Append(")AS Row, T.*  from Download T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion  BasicMethod
        #region  ExtensionMethod
        /// <summary>
        /// 更新排序
        /// </summary>
        /// <param name="Sort"></param>
        /// <param name="ID"></param>
        /// <returns></returns>
        public bool UpdateDownloadBySort(int Sort, int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Download set ");
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
        #endregion  ExtensionMethod
    }
}

