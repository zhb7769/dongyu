using NetWise.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
namespace NetWise.DataAccess
{
    /// <summary>
    /// 数据访问类:ProductClass
    /// </summary>
    public partial class ProductClass
    {
        public ProductClass()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("ID", "ProductClass");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ProductClass");
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
        public int Add(NetWise.Entity.ProductClass model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ProductClass(");
            strSql.Append("CN_Name,EN_Name,ParentId,Sort,C_Pic,B_Pic,CN_Url,EN_Url,Depth,IndexShow,CN_Intro,EN_Intro,CN_Spec,EN_Spec,CN_Application,EN_Application)");
            strSql.Append(" values (");
            strSql.Append("@CN_Name,@EN_Name,@ParentId,@Sort,@C_Pic,@B_Pic,@CN_Url,@EN_Url,@Depth,@IndexShow,@CN_Intro,@EN_Intro,@CN_Spec,@EN_Spec,@CN_Application,@EN_Application)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@CN_Name", SqlDbType.NVarChar,200),
                    new SqlParameter("@EN_Name", SqlDbType.NVarChar,200),
                    new SqlParameter("@ParentId", SqlDbType.NVarChar,50),
                    new SqlParameter("@Sort", SqlDbType.Int,4),
                    new SqlParameter("@C_Pic", SqlDbType.NVarChar,200),
                    new SqlParameter("@B_Pic", SqlDbType.NVarChar,200),
                    new SqlParameter("@CN_Url", SqlDbType.NVarChar,200),
                    new SqlParameter("@EN_Url", SqlDbType.NVarChar,200),
                    new SqlParameter("@Depth", SqlDbType.Int,4),
                    new SqlParameter("@IndexShow", SqlDbType.Bit,1),
                    new SqlParameter("@CN_Intro", SqlDbType.NText),
                    new SqlParameter("@EN_Intro", SqlDbType.NText),
                    new SqlParameter("@CN_Spec", SqlDbType.NText),
                    new SqlParameter("@EN_Spec", SqlDbType.NText),
                    new SqlParameter("@CN_Application", SqlDbType.NText),
                    new SqlParameter("@EN_Application", SqlDbType.NText)};
            parameters[0].Value = model.CN_Name;
            parameters[1].Value = model.EN_Name;
            parameters[2].Value = model.ParentId;
            parameters[3].Value = model.Sort;
            parameters[4].Value = model.C_Pic;
            parameters[5].Value = model.B_Pic;
            parameters[6].Value = model.CN_Url;
            parameters[7].Value = model.EN_Url;
            parameters[8].Value = model.Depth;
            parameters[9].Value = model.IndexShow;
            parameters[10].Value = model.CN_Intro;
            parameters[11].Value = model.EN_Intro;
            parameters[12].Value = model.CN_Spec;
            parameters[13].Value = model.EN_Spec;
            parameters[14].Value = model.CN_Application;
            parameters[15].Value = model.EN_Application;

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
        public bool Update(NetWise.Entity.ProductClass model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ProductClass set ");
            strSql.Append("CN_Name=@CN_Name,");
            strSql.Append("EN_Name=@EN_Name,");
            strSql.Append("ParentId=@ParentId,");
            strSql.Append("Sort=@Sort,");
            strSql.Append("C_Pic=@C_Pic,");
            strSql.Append("B_Pic=@B_Pic,");
            strSql.Append("CN_Url=@CN_Url,");
            strSql.Append("EN_Url=@EN_Url,");
            strSql.Append("Depth=@Depth,");
            strSql.Append("IndexShow=@IndexShow,");
            strSql.Append("CN_Intro=@CN_Intro,");
            strSql.Append("EN_Intro=@EN_Intro,");
            strSql.Append("CN_Spec=@CN_Spec,");
            strSql.Append("EN_Spec=@EN_Spec,");
            strSql.Append("CN_Application=@CN_Application,");
            strSql.Append("EN_Application=@EN_Application");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@CN_Name", SqlDbType.NVarChar,200),
                    new SqlParameter("@EN_Name", SqlDbType.NVarChar,200),
                    new SqlParameter("@ParentId", SqlDbType.NVarChar,50),
                    new SqlParameter("@Sort", SqlDbType.Int,4),
                    new SqlParameter("@C_Pic", SqlDbType.NVarChar,200),
                    new SqlParameter("@B_Pic", SqlDbType.NVarChar,200),
                    new SqlParameter("@CN_Url", SqlDbType.NVarChar,200),
                    new SqlParameter("@EN_Url", SqlDbType.NVarChar,200),
                    new SqlParameter("@Depth", SqlDbType.Int,4),
                    new SqlParameter("@IndexShow", SqlDbType.Bit,1),
                    new SqlParameter("@CN_Intro", SqlDbType.NText),
                    new SqlParameter("@EN_Intro", SqlDbType.NText),
                    new SqlParameter("@CN_Spec", SqlDbType.NText),
                    new SqlParameter("@EN_Spec", SqlDbType.NText),
                    new SqlParameter("@CN_Application", SqlDbType.NText),
                    new SqlParameter("@EN_Application", SqlDbType.NText),
                    new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.CN_Name;
            parameters[1].Value = model.EN_Name;
            parameters[2].Value = model.ParentId;
            parameters[3].Value = model.Sort;
            parameters[4].Value = model.C_Pic;
            parameters[5].Value = model.B_Pic;
            parameters[6].Value = model.CN_Url;
            parameters[7].Value = model.EN_Url;
            parameters[8].Value = model.Depth;
            parameters[9].Value = model.IndexShow;
            parameters[10].Value = model.CN_Intro;
            parameters[11].Value = model.EN_Intro;
            parameters[12].Value = model.CN_Spec;
            parameters[13].Value = model.EN_Spec;
            parameters[14].Value = model.CN_Application;
            parameters[15].Value = model.EN_Application;
            parameters[16].Value = model.ID;

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
            strSql.Append("delete from ProductClass ");
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
            strSql.Append("delete from ProductClass ");
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
        public NetWise.Entity.ProductClass GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,CN_Name,EN_Name,ParentId,Sort,C_Pic,B_Pic,CN_Url,EN_Url,Depth,IndexShow,CN_Intro,EN_Intro,CN_Spec,EN_Spec,CN_Application,EN_Application from ProductClass ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int,4)
            };
            parameters[0].Value = ID;

            NetWise.Entity.ProductClass model = new NetWise.Entity.ProductClass();
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
        public NetWise.Entity.ProductClass DataRowToModel(DataRow row)
        {
            Entity.ProductClass model = new NetWise.Entity.ProductClass();
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
                if (row["C_Pic"] != null)
                {
                    model.C_Pic = row["C_Pic"].ToString();
                }
                if (row["B_Pic"] != null)
                {
                    model.B_Pic = row["B_Pic"].ToString();
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
                if (row["IndexShow"] != null && row["IndexShow"].ToString() != "")
                {
                    if ((row["IndexShow"].ToString() == "1") || (row["IndexShow"].ToString().ToLower() == "true"))
                    {
                        model.IndexShow = true;
                    }
                    else
                    {
                        model.IndexShow = false;
                    }
                }
                if (row["CN_Intro"] != null)
                {
                    model.CN_Intro = row["CN_Intro"].ToString();
                }
                if (row["EN_Intro"] != null)
                {
                    model.EN_Intro = row["EN_Intro"].ToString();
                }
                if (row["CN_Spec"] != null)
                {
                    model.CN_Spec = row["CN_Spec"].ToString();
                }
                if (row["EN_Spec"] != null)
                {
                    model.EN_Spec = row["EN_Spec"].ToString();
                }
                if (row["CN_Application"] != null)
                {
                    model.CN_Application = row["CN_Application"].ToString();
                }
                if (row["EN_Application"] != null)
                {
                    model.EN_Application = row["EN_Application"].ToString();
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
            strSql.Append("select ID,CN_Name,EN_Name,ParentId,Sort,C_Pic,B_Pic,CN_Url,EN_Url,Depth,IndexShow,CN_Intro,EN_Intro,CN_Spec,EN_Spec,CN_Application,EN_Application ");
            strSql.Append(" FROM ProductClass ");
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
            strSql.Append(" ID,CN_Name,EN_Name,ParentId,Sort,C_Pic,B_Pic,CN_Url,EN_Url,Depth,IndexShow,CN_Intro,EN_Intro,CN_Spec,EN_Spec,CN_Application,EN_Application ");
            strSql.Append(" FROM ProductClass ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            if (string.Empty != filedOrder.Trim())
            {
                strSql.Append(" order by " + filedOrder);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM ProductClass ");
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
            strSql.Append(")AS Row, T.*  from ProductClass T ");
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
            parameters[0].Value = "ProductClass";
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
        /// 产品类别的泛型列表
        /// </summary>
        /// <returns></returns>
        public List<NetWise.Entity.ProductClass> GetList()
        {
            List<NetWise.Entity.ProductClass> list = new List<NetWise.Entity.ProductClass>();

            StringBuilder builder = new StringBuilder();
            builder.Append("select ID,CN_Name,EN_Name,ParentId,Sort,C_Pic,B_Pic,CN_Url,EN_Url,Depth,IndexShow,CN_Intro,EN_Intro,CN_Spec,EN_Spec,CN_Application,EN_Application ");
            builder.Append(" from ProductClass ");
            builder.Append(" ORDER BY Sort ASC");
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

        /// <summary>
        /// 获得有数量的数据列表
        /// </summary>
        /// <returns></returns>
        public DataSet GetListForNum()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,CN_Name,EN_Name,ParentId,Sort,C_Pic,B_Pic,CN_Url,EN_Url,Depth,IndexShow,CN_Intro,EN_Intro,CN_Spec,EN_Spec,CN_Application,EN_Application,");
            strSql.Append("Num=(select count(*) from Product where ClassId=pc.ID )");
            strSql.Append(" from ProductClass as pc ");
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 获得深度
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public object GetDepthByID(int ID)
        {
            string sql = "select Depth from ProductClass where ID=" + ID;
            return DbHelperSQL.GetSingle(sql);
        }
        /// <summary>
        /// 根据类别ID递归查找该类别及该类别下所有类别的产品数
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public object GetNumByID(int ID)
        {
            //            string sql = @"WITH T AS
            //                           (
            //                              SELECT ID , ParentId , CN_Name
            //                              FROM ProductClass  WHERE ID = @ID
            //                              UNION ALL
            //                              SELECT A.ID , A.ParentId , A.CN_Name
            //                              FROM ProductClass AS A JOIN T AS B ON A.ParentId = B.ID
            //                            )
            //                            SELECT count(*) FROM Product WHERE ClassId IN (SELECT T.ID FROM T ) ";

            string sql = @"SELECT count(*) FROM Product a,f_ProductNum(@ID) b WHERE a.ClassId = b.ID ";

            SqlParameter[] parameters = { new SqlParameter("@ID", ID) };
            return DbHelperSQL.GetSingle(sql, parameters);

        }
        /// <summary>
        /// 根据类别ID推荐
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public bool UpdateShowByID(int ID)
        {
            string sql = "update ProductClass set IndexShow=1 where ID='" + ID + "'";
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


        public DataSet GetProductClassSort(string CN_Url)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select a.ID,a.parentid,(REPLICATE('　',b.re_level) +a.CN_Name) as CN_Name,EN_Name,b.re_level,b.re_sort ,b.re_path,a.IndexShow,a.Sort");
            strSql.Append(" from ProductClass a,f_ProductClass(0) b where a.ID=b.re_id ");
            if (!string.IsNullOrEmpty(CN_Url))
            {
                strSql.Append(" and a.CN_Url='").Append(CN_Url).Append("' ");
            }
            strSql.Append(" order by re_sort");
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 所有分类（递归，排序）
        /// </summary>
        /// <param name="classId">类别ID</param>
        /// <returns></returns>
        public DataSet GetProductClassSort(int classId)
        {
            string sql = @"select a.ID,a.ParentId,a.CN_Name,a.EN_Name,b.re_level,b.re_sort ,b.re_path,a.IndexShow,a.Sort
                                  from ProductClass a,f_ProductClass('" + classId + "') b where a.ID=b.re_id order by re_sort";
            return DbHelperSQL.Query(sql);
        }

        public DataSet GetPclassName(int classId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT c.*, c.EN_Name +' > '+ b.EN_Name +' > '+ a.EN_Name PclassName FROM dbo.ProductClass a");
            strSql.Append(" JOIN dbo.ProductClass b ON a.ParentId = b.ID");
            strSql.Append(" JOIN dbo.ProductClass c ON b.ParentId = c.ID");
            strSql.AppendFormat(" WHERE a.id = {0}", classId);
            return DbHelperSQL.Query(strSql.ToString());
        }

        public DataSet GetPclassName02(int classId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT b.*, b.EN_Name +' > '+ a.EN_Name PclassName FROM dbo.ProductClass a");
            strSql.Append(" JOIN dbo.ProductClass b ON a.ParentId = b.ID");
            strSql.AppendFormat(" WHERE a.id = {0}", classId);
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion  ExtensionMethod
    }

}
