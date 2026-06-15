using NetWise.DBUtility;
using System;
using System.Collections.Generic;//Please add references
using System.Data;
using System.Data.SqlClient;
using System.Text;
namespace NetWise.DataAccess
{
    /// <summary>
    /// 数据访问类:NewsClass
    /// </summary>
    public partial class NewsClass
    {
        public NewsClass()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from NewsClass");
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
        public int Add(NetWise.Entity.NewsClass model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into NewsClass(");
            strSql.Append("CN_Name,EN_Name,ParentId,Sort,CN_Url,EN_Url,Depth,IsShow,Remark)");
            strSql.Append(" values (");
            strSql.Append("@CN_Name,@EN_Name,@ParentId,@Sort,@CN_Url,@EN_Url,@Depth,@IsShow,@Remark)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@CN_Name", SqlDbType.NVarChar,50),
                    new SqlParameter("@EN_Name", SqlDbType.NVarChar,50),
                    new SqlParameter("@ParentId", SqlDbType.NVarChar,50),
                    new SqlParameter("@Sort", SqlDbType.Int,4),
                    new SqlParameter("@CN_Url", SqlDbType.NVarChar,200),
                    new SqlParameter("@EN_Url", SqlDbType.NVarChar,200),
                    new SqlParameter("@Depth", SqlDbType.Int,4),
                    new SqlParameter("@IsShow", SqlDbType.Bit,1),
                    new SqlParameter("@Remark", SqlDbType.NText)};
            parameters[0].Value = model.CN_Name;
            parameters[1].Value = model.EN_Name;
            parameters[2].Value = model.ParentId;
            parameters[3].Value = model.Sort;
            parameters[4].Value = model.CN_Url;
            parameters[5].Value = model.EN_Url;
            parameters[6].Value = model.Depth;
            parameters[7].Value = model.IsShow;
            parameters[8].Value = model.Remark;

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
        public bool Update(NetWise.Entity.NewsClass model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update NewsClass set ");
            strSql.Append("CN_Name=@CN_Name,");
            strSql.Append("EN_Name=@EN_Name,");
            strSql.Append("ParentId=@ParentId,");
            strSql.Append("Sort=@Sort,");
            strSql.Append("CN_Url=@CN_Url,");
            strSql.Append("EN_Url=@EN_Url,");
            strSql.Append("Depth=@Depth,");
            strSql.Append("IsShow=@IsShow,");
            strSql.Append("Remark=@Remark");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@CN_Name", SqlDbType.NVarChar,50),
                    new SqlParameter("@EN_Name", SqlDbType.NVarChar,50),
                    new SqlParameter("@ParentId", SqlDbType.NVarChar,50),
                    new SqlParameter("@Sort", SqlDbType.Int,4),
                    new SqlParameter("@CN_Url", SqlDbType.NVarChar,200),
                    new SqlParameter("@EN_Url", SqlDbType.NVarChar,200),
                    new SqlParameter("@Depth", SqlDbType.Int,4),
                    new SqlParameter("@IsShow", SqlDbType.Bit,1),
                    new SqlParameter("@Remark", SqlDbType.NText),
                    new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.CN_Name;
            parameters[1].Value = model.EN_Name;
            parameters[2].Value = model.ParentId;
            parameters[3].Value = model.Sort;
            parameters[4].Value = model.CN_Url;
            parameters[5].Value = model.EN_Url;
            parameters[6].Value = model.Depth;
            parameters[7].Value = model.IsShow;
            parameters[8].Value = model.Remark;
            parameters[9].Value = model.ID;

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
            strSql.Append("delete from NewsClass ");
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
            strSql.Append("delete from NewsClass ");
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
        public NetWise.Entity.NewsClass GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,CN_Name,EN_Name,ParentId,Sort,CN_Url,EN_Url,Depth,IsShow,Remark from NewsClass ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int,4)
            };
            parameters[0].Value = ID;

            NetWise.Entity.NewsClass model = new NetWise.Entity.NewsClass();
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
        public NetWise.Entity.NewsClass DataRowToModel(DataRow row)
        {
            NetWise.Entity.NewsClass model = new NetWise.Entity.NewsClass();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["CN_Name"] != null)
                {
                    model.CN_Name = row["CN_Name"].ToString();
                }
                if (row["EN_Name"] != null)
                {
                    model.EN_Name = row["EN_Name"].ToString();
                }
                if (row["ParentId"] != null)
                {
                    model.ParentId = row["ParentId"].ToString();
                }
                if (row["Sort"] != null && row["Sort"].ToString() != "")
                {
                    model.Sort = int.Parse(row["Sort"].ToString());
                }
                if (row["CN_Url"] != null)
                {
                    model.CN_Url = row["CN_Url"].ToString();
                }
                if (row["EN_Url"] != null)
                {
                    model.EN_Url = row["EN_Url"].ToString();
                }
                if (row["Depth"] != null && row["Depth"].ToString() != "")
                {
                    model.Depth = int.Parse(row["Depth"].ToString());
                }
                if (row["IsShow"] != null && row["IsShow"].ToString() != "")
                {
                    if ((row["IsShow"].ToString() == "1") || (row["IsShow"].ToString().ToLower() == "true"))
                    {
                        model.IsShow = true;
                    }
                    else
                    {
                        model.IsShow = false;
                    }
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
            strSql.Append("select ID,CN_Name,EN_Name,ParentId,Sort,CN_Url,EN_Url,Depth,IsShow,Remark ");
            strSql.Append(" FROM NewsClass ");
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
            strSql.Append(" ID,CN_Name,EN_Name,ParentId,Sort,CN_Url,EN_Url,Depth,IsShow,Remark ");
            strSql.Append(" FROM NewsClass ");
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
            strSql.Append("select count(1) FROM NewsClass ");
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
            strSql.Append(")AS Row, T.*  from NewsClass T ");
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
            parameters[0].Value = "NewsClass";
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
        /// 获得数据列表
        /// </summary>
        public List<NetWise.Entity.NewsClass> ListNewsClass(string strWhere)
        {
            List<NetWise.Entity.NewsClass> list = new List<NetWise.Entity.NewsClass>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,CN_Name,EN_Name,ParentId,Sort,CN_Url,EN_Url,Depth,IsShow,Remark ");
            strSql.Append(" FROM NewsClass ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    list.Add(DataRowToModel(ds.Tables[0].Rows[i]));
                }
            }
            return list;
        }

        /// <summary>
        /// 获得深度
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public object GetDepthByID(int ID)
        {
            string sql = "select Depth from NewsClass where ID=" + ID;
            return DbHelperSQL.GetSingle(sql);
        }
        /// <summary>
        /// 根据类别ID递归查找该类别及该类别下所有类别的新闻数
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public object GetNumByID(int ID)
        {
            //            string sql = @"WITH T AS
            //                           (  
            //                              SELECT ID , ParentId , CN_Name   
            //                              FROM NewsClass WHERE ID = @ID  
            //                              UNION ALL  
            //                              SELECT A.ID , A.ParentId , A.CN_Name   
            //                              FROM NewsClass AS A JOIN T AS B ON A.ParentId = B.ID
            //                            )
            //                            SELECT count(*) FROM News WHERE NewsClassId IN (SELECT T.ID FROM T )";

            string sql = @"SELECT count(*) FROM News a,f_NewsNum(@ID) b WHERE a.NewsClassId = b.re_id ";

            SqlParameter[] parameters = { new SqlParameter("@ID", ID) };
            return DbHelperSQL.GetSingle(sql, parameters);

        }

        public DataSet GetNewsClassSort()
        {
            string sql = @"select a.ID,a.parentid,(REPLICATE('　',b.re_level) +a.CN_Name) as CN_Name,a.EN_Name,a.Sort,a.Depth,a.IsShow 
                                  from NewsClass a,f_NewsClass(0) b where a.ID=b.re_id order by re_sort";
            return DbHelperSQL.Query(sql);
        }
        public DataSet GetNewsClassSort(int ID)
        {
            string sql = @"select a.ID,a.parentid,a.CN_Name,a.EN_Name,a.Sort,a.Depth,a.IsShow 
                                  from NewsClass a,f_NewsClass(" + ID + ") b where a.ID=b.re_id order by re_sort";
            return DbHelperSQL.Query(sql);
        }
        /// <summary>
        /// 根据类别ID推荐
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public bool UpdateShowByID(int ID)
        {
            string sql = "update NewsClass set IsShow=1 where ID='" + ID + "'";
            int rows = DbHelperSQL.ExecuteSql(sql);
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
        /// 获得有数量的数据列表
        /// </summary>
        /// <returns></returns>
        public DataSet GetListForNum()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,CN_Name,EN_Name,ParentId,Sort,CN_Url,EN_Url,Depth,IsShow,Remark,");
            strSql.Append("Num=(select count(*) from News where NewsClassId=nc.ID )");
            strSql.Append(" from NewsClass as nc ");
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion  ExtensionMethod
    }
}

