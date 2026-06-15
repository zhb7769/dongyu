using NetWise.DBUtility;//Please add references
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
namespace NetWise.DataAccess
{
    /// <summary>
    /// 数据访问类:Product
    /// </summary>
    public partial class Product
    {
        public Product()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int P_Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Product");
            strSql.Append(" where P_Id=@P_Id");
            SqlParameter[] parameters = {
                    new SqlParameter("@P_Id", SqlDbType.Int,4)
            };
            parameters[0].Value = P_Id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        public int GetMaxID()
        {
            return DbHelperSQL.GetMaxID("P_Id", "Product");
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(NetWise.Entity.Product model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Product(");
            strSql.Append("CN_Name,EN_Name,CN_Label,EN_Label,S_Img,M_Img,O_Img,L_Img,CN_Synopsis,EN_Synopsis,ClassId,IsPage,IsTop,CreateTime,Sort,Remark)");
            strSql.Append(" values (");
            strSql.Append("@CN_Name,@EN_Name,@CN_Label,@EN_Label,@S_Img,@M_Img,@O_Img,@L_Img,@CN_Synopsis,@EN_Synopsis,@ClassId,@IsPage,@IsTop,@CreateTime,@Sort,@Remark)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@CN_Name", SqlDbType.NVarChar,200),
                    new SqlParameter("@EN_Name", SqlDbType.NVarChar,200),
                    new SqlParameter("@CN_Label", SqlDbType.NVarChar,4000),
                    new SqlParameter("@EN_Label", SqlDbType.NVarChar,4000),
                    new SqlParameter("@S_Img", SqlDbType.NVarChar,500),
                    new SqlParameter("@M_Img", SqlDbType.NVarChar,500),
                    new SqlParameter("@O_Img", SqlDbType.NVarChar,500),
                    new SqlParameter("@L_Img", SqlDbType.NVarChar,300),
                    new SqlParameter("@CN_Synopsis", SqlDbType.NText),
                    new SqlParameter("@EN_Synopsis", SqlDbType.NText),
                    new SqlParameter("@ClassId", SqlDbType.Int,4),
                    new SqlParameter("@IsPage", SqlDbType.Bit,1),
                    new SqlParameter("@IsTop", SqlDbType.Bit,1),
                    new SqlParameter("@CreateTime", SqlDbType.DateTime),
                    new SqlParameter("@Sort", SqlDbType.Int,4),
                    new SqlParameter("@Remark", SqlDbType.NText)};
            parameters[0].Value = model.CN_Name;
            parameters[1].Value = model.EN_Name;
            parameters[2].Value = model.CN_Label;
            parameters[3].Value = model.EN_Label;
            parameters[4].Value = model.S_Img;
            parameters[5].Value = model.M_Img;
            parameters[6].Value = model.O_Img;
            parameters[7].Value = model.L_Img;
            parameters[8].Value = model.CN_Synopsis;
            parameters[9].Value = model.EN_Synopsis;
            parameters[10].Value = model.ClassId;
            parameters[11].Value = model.IsPage;
            parameters[12].Value = model.IsTop;
            parameters[13].Value = model.CreateTime;
            parameters[14].Value = model.Sort;
            parameters[15].Value = model.Remark;

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
        public bool Update(NetWise.Entity.Product model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Product set ");
            strSql.Append("CN_Name=@CN_Name,");
            strSql.Append("EN_Name=@EN_Name,");
            strSql.Append("CN_Label=@CN_Label,");
            strSql.Append("EN_Label=@EN_Label,");
            strSql.Append("S_Img=@S_Img,");
            strSql.Append("M_Img=@M_Img,");
            strSql.Append("O_Img=@O_Img,");
            strSql.Append("L_Img=@L_Img,");
            strSql.Append("CN_Synopsis=@CN_Synopsis,");
            strSql.Append("EN_Synopsis=@EN_Synopsis,");
            strSql.Append("ClassId=@ClassId,");
            strSql.Append("IsPage=@IsPage,");
            strSql.Append("IsTop=@IsTop,");
            strSql.Append("CreateTime=@CreateTime,");
            strSql.Append("Sort=@Sort,");
            strSql.Append("Remark=@Remark");
            strSql.Append(" where P_Id=@P_Id");
            SqlParameter[] parameters = {
                    new SqlParameter("@CN_Name", SqlDbType.NVarChar,200),
                    new SqlParameter("@EN_Name", SqlDbType.NVarChar,200),
                    new SqlParameter("@CN_Label", SqlDbType.NVarChar,4000),
                    new SqlParameter("@EN_Label", SqlDbType.NVarChar,4000),
                    new SqlParameter("@S_Img", SqlDbType.NVarChar,500),
                    new SqlParameter("@M_Img", SqlDbType.NVarChar,500),
                    new SqlParameter("@O_Img", SqlDbType.NVarChar,500),
                    new SqlParameter("@L_Img", SqlDbType.NVarChar,300),
                    new SqlParameter("@CN_Synopsis", SqlDbType.NText),
                    new SqlParameter("@EN_Synopsis", SqlDbType.NText),
                    new SqlParameter("@ClassId", SqlDbType.Int,4),
                    new SqlParameter("@IsPage", SqlDbType.Bit,1),
                    new SqlParameter("@IsTop", SqlDbType.Bit,1),
                    new SqlParameter("@CreateTime", SqlDbType.DateTime),
                    new SqlParameter("@Sort", SqlDbType.Int,4),
                    new SqlParameter("@Remark", SqlDbType.NText),
                    new SqlParameter("@P_Id", SqlDbType.Int,4)};
            parameters[0].Value = model.CN_Name;
            parameters[1].Value = model.EN_Name;
            parameters[2].Value = model.CN_Label;
            parameters[3].Value = model.EN_Label;
            parameters[4].Value = model.S_Img;
            parameters[5].Value = model.M_Img;
            parameters[6].Value = model.O_Img;
            parameters[7].Value = model.L_Img;
            parameters[8].Value = model.CN_Synopsis;
            parameters[9].Value = model.EN_Synopsis;
            parameters[10].Value = model.ClassId;
            parameters[11].Value = model.IsPage;
            parameters[12].Value = model.IsTop;
            parameters[13].Value = model.CreateTime;
            parameters[14].Value = model.Sort;
            parameters[15].Value = model.Remark;
            parameters[16].Value = model.P_Id;

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
        public bool Delete(int P_Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Product ");
            strSql.Append(" where P_Id=@P_Id");
            SqlParameter[] parameters = {
                    new SqlParameter("@P_Id", SqlDbType.Int,4)
            };
            parameters[0].Value = P_Id;

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
        public bool DeleteList(string P_Idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Product ");
            strSql.Append(" where P_Id in (" + P_Idlist + ")  ");
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
        public NetWise.Entity.Product GetModel(int P_Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 P_Id,CN_Name,EN_Name,CN_Label,EN_Label,S_Img,M_Img,O_Img,L_Img,CN_Synopsis,EN_Synopsis,ClassId,IsPage,IsTop,CreateTime,Sort,Remark from Product ");
            strSql.Append(" where P_Id=@P_Id");
            SqlParameter[] parameters = {
                    new SqlParameter("@P_Id", SqlDbType.Int,4)
            };
            parameters[0].Value = P_Id;

            NetWise.Entity.Product model = new NetWise.Entity.Product();
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
        public NetWise.Entity.Product DataRowToModel(DataRow row)
        {
            NetWise.Entity.Product model = new NetWise.Entity.Product();
            if (row != null)
            {
                if (row["P_Id"] != null && row["P_Id"].ToString() != "")
                {
                    model.P_Id = int.Parse(row["P_Id"].ToString());
                }
                if (row["CN_Name"] != null)
                {
                    model.CN_Name = row["CN_Name"].ToString();
                }
                if (row["EN_Name"] != null)
                {
                    model.EN_Name = row["EN_Name"].ToString();
                }
                if (row["CN_Label"] != null)
                {
                    model.CN_Label = row["CN_Label"].ToString();
                }
                if (row["EN_Label"] != null)
                {
                    model.EN_Label = row["EN_Label"].ToString();
                }
                if (row["S_Img"] != null)
                {
                    model.S_Img = row["S_Img"].ToString();
                }
                if (row["M_Img"] != null)
                {
                    model.M_Img = row["M_Img"].ToString();
                }
                if (row["O_Img"] != null)
                {
                    model.O_Img = row["O_Img"].ToString();
                }
                if (row["L_Img"] != null)
                {
                    model.L_Img = row["L_Img"].ToString();
                }
                if (row["CN_Synopsis"] != null)
                {
                    model.CN_Synopsis = row["CN_Synopsis"].ToString();
                }
                if (row["EN_Synopsis"] != null)
                {
                    model.EN_Synopsis = row["EN_Synopsis"].ToString();
                }
                if (row["ClassId"] != null && row["ClassId"].ToString() != "")
                {
                    model.ClassId = int.Parse(row["ClassId"].ToString());
                }
                if (row["IsPage"] != null && row["IsPage"].ToString() != "")
                {
                    if ((row["IsPage"].ToString() == "1") || (row["IsPage"].ToString().ToLower() == "true"))
                    {
                        model.IsPage = true;
                    }
                    else
                    {
                        model.IsPage = false;
                    }
                }
                if (row["IsTop"] != null && row["IsTop"].ToString() != "")
                {
                    if ((row["IsTop"].ToString() == "1") || (row["IsTop"].ToString().ToLower() == "true"))
                    {
                        model.IsTop = true;
                    }
                    else
                    {
                        model.IsTop = false;
                    }
                }
                if (row["CreateTime"] != null && row["CreateTime"].ToString() != "")
                {
                    model.CreateTime = DateTime.Parse(row["CreateTime"].ToString());
                }
                if (row["Sort"] != null && row["Sort"].ToString() != "")
                {
                    model.Sort = int.Parse(row["Sort"].ToString());
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
            strSql.Append("select P_Id,CN_Name,EN_Name,CN_Label,EN_Label,S_Img,M_Img,O_Img,L_Img,CN_Synopsis,EN_Synopsis,ClassId,IsPage,IsTop,CreateTime,Sort,Remark ");
            strSql.Append(" FROM Product ");
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
            strSql.Append(" P_Id,CN_Name,EN_Name,CN_Label,EN_Label,S_Img,M_Img,O_Img,L_Img,CN_Synopsis,EN_Synopsis,ClassId,IsPage,IsTop,CreateTime,Sort,Remark ");
            strSql.Append(" FROM Product ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where  0=0 " + strWhere);
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
            strSql.Append("select count(1) FROM Product ");
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
                strSql.Append("order by T.P_Id desc");
            }
            strSql.Append(")AS Row, T.*  from Product T ");
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
            parameters[0].Value = "Product";
            parameters[1].Value = "P_Id";
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
        public bool UpdateProductForSort(int Sort, int P_Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Product set ");
            strSql.Append("Sort=@Sort ");
            strSql.Append(" where P_Id=@P_Id");
            SqlParameter[] parameters = {
                 new SqlParameter("@Sort", SqlDbType.Int,4),
                 new SqlParameter("@P_Id", SqlDbType.Int,4)};
            parameters[0].Value = Sort;
            parameters[1].Value = P_Id;
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
        /// 根据类别ID递归查找该类及所有子类下的产品信息
        /// </summary>
        /// <param name="ClassId"></param>
        /// <returns></returns>
        public DataSet GetListByClassId(int ClassId)
        {
            //            string sql = @"WITH T AS
            //                           (  
            //                              SELECT ID , ParentId , CN_Name   
            //                              FROM ProductClass  WHERE ID = @ID  
            //                              UNION ALL  
            //                              SELECT A.ID , A.ParentId , A.CN_Name   
            //                              FROM ProductClass AS A JOIN T AS B ON A.ParentId = B.ID
            //                            )
            //                          SELECT * FROM Product AS p WHERE ClassId IN (SELECT T.ID FROM T ) ORDER BY p.CreateTime DESC";

            string sql = @"SELECT * FROM Product a,f_ProductNum(@ID) b WHERE a.ClassId = b.ID ";

            SqlParameter[] parameters = { new SqlParameter("@ID", ClassId) };
            return DbHelperSQL.Query(sql, parameters);

        }
        /// <summary>
        /// 根据类别ID和其他条件,递归查找该类及所有子类下的产品信息
        /// </summary>
        /// <param name="ClassId">类别ID</param>
        /// <param name="strWhere">其他条件</param>
        /// <returns></returns>
        public DataSet GetListByClassId(int ClassId, string strWhere)
        {
            StringBuilder strSQL = new StringBuilder();
            strSQL.Append("SELECT * FROM Product a,f_ProductNum(@ID) b WHERE a.ClassId = b.ID ");
            if (!string.IsNullOrEmpty(strWhere))
            {
                strSQL.Append(strWhere);
            }
            SqlParameter[] parameters = { new SqlParameter("@ID", ClassId) };
            return DbHelperSQL.Query(strSQL.ToString(), parameters);
        }


        #region 页面的访问次数

        public static int GetCN_ReadCount(int P_Id)
        {
            int ret = 0;
            string sql = "select CN_ReadCount from Product where P_Id = '" + P_Id + "'";
            object obj = NetWise.DBUtility.DbHelperSQL.GetSingle(sql);
            if (null != obj && "" != obj.ToString())
            {
                ret = Convert.ToInt32(obj);
            }
            return ret;
        }
        public static int UpdateCN_ReadCount(int CN_ReadCount, int P_Id)
        {
            string sql = "update Product set CN_ReadCount='" + CN_ReadCount + "' where P_Id= '" + P_Id + "'";
            return NetWise.DBUtility.DbHelperSQL.ExecuteSql(sql);
        }

        public static int GetEN_ReadCount(int P_Id)
        {
            int ret = 0;
            string sql = "select EN_ReadCount from Product where P_Id = '" + P_Id + "'";
            object obj = NetWise.DBUtility.DbHelperSQL.GetSingle(sql);
            if (null != obj && "" != obj.ToString())
            {
                ret = Convert.ToInt32(obj);
            }
            return ret;
        }
        public static int UpdateEN_ReadCount(int EN_ReadCount, int P_Id)
        {
            string sql = "update Product set EN_ReadCount='" + EN_ReadCount + "' where P_Id = '" + P_Id + "'";
            return NetWise.DBUtility.DbHelperSQL.ExecuteSql(sql);
        }

        #endregion
        #endregion  ExtensionMethod

        #region zhm
        /// <summary>
        /// 获得数据列表(图片表)
        /// </summary>
        public DataSet GetListJoinPic(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select t1.*," +
                          "(select top 1 pro_img from pro_att_info t2 where t1.P_Id=t2.pro_id order by at_id asc) pro_img " +
                          "from Product t1 ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }


        /// <summary>
        /// 获得数据列表(参数表)
        /// </summary>
        public DataSet GetListJoinPara(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select t1.*," +
                          "(select top 1 para_left,para_right,para_EN_right,para_EN_left from pro_para_info t2 where t1.P_Id=t2.pro_id order by at_id asc) pro_left,pro_right " +
                          "from Product t1 ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }


        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPageJoinPic(string strWhere, string orderby, int startIndex, int endIndex)
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
                strSql.Append("order by T.P_Id desc");
            }
            strSql.Append(")AS Row, T.*,(select top 1 pro_img from pro_att_info t2 where T.P_Id=t2.pro_id order by at_id asc) pro_img  from Product T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion

    }
}

