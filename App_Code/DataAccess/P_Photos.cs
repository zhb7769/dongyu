using NetWise.DBUtility;//Please add references
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
namespace NetWise.DataAccess
{
    /// <summary>
    /// 数据访问类:P_Photos
    /// </summary>
    public partial class P_Photos
    {
        public P_Photos()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("ID", "P_Photos");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from P_Photos");
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
        public int Add(NetWise.Entity.P_Photos model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into P_Photos(");
            strSql.Append("ProductId,CN_Title,EN_Title,S_Img,M_Img,O_Img,L_Img,Sort,CreateTime,Remark)");
            strSql.Append(" values (");
            strSql.Append("@ProductId,@CN_Title,@EN_Title,@S_Img,@M_Img,@O_Img,@L_Img,@Sort,@CreateTime,@Remark)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@ProductId", SqlDbType.Int,4),
                    new SqlParameter("@CN_Title", SqlDbType.NVarChar,200),
                    new SqlParameter("@EN_Title", SqlDbType.NVarChar,200),
                    new SqlParameter("@S_Img", SqlDbType.NVarChar,300),
                    new SqlParameter("@M_Img", SqlDbType.NVarChar,300),
                    new SqlParameter("@O_Img", SqlDbType.NVarChar,300),
                    new SqlParameter("@L_Img", SqlDbType.NVarChar,300),
                    new SqlParameter("@Sort", SqlDbType.Int,4),
                    new SqlParameter("@CreateTime", SqlDbType.DateTime),
                    new SqlParameter("@Remark", SqlDbType.NText)};
            parameters[0].Value = model.ProductId;
            parameters[1].Value = model.CN_Title;
            parameters[2].Value = model.EN_Title;
            parameters[3].Value = model.S_Img;
            parameters[4].Value = model.M_Img;
            parameters[5].Value = model.O_Img;
            parameters[6].Value = model.L_Img;
            parameters[7].Value = model.Sort;
            parameters[8].Value = model.CreateTime;
            parameters[9].Value = model.Remark;

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
        public bool Update(NetWise.Entity.P_Photos model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update P_Photos set ");
            strSql.Append("ProductId=@ProductId,");
            strSql.Append("CN_Title=@CN_Title,");
            strSql.Append("EN_Title=@EN_Title,");
            strSql.Append("S_Img=@S_Img,");
            strSql.Append("M_Img=@M_Img,");
            strSql.Append("O_Img=@O_Img,");
            strSql.Append("L_Img=@L_Img,");
            strSql.Append("Sort=@Sort,");
            strSql.Append("CreateTime=@CreateTime,");
            strSql.Append("Remark=@Remark");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@ProductId", SqlDbType.Int,4),
                    new SqlParameter("@CN_Title", SqlDbType.NVarChar,200),
                    new SqlParameter("@EN_Title", SqlDbType.NVarChar,200),
                    new SqlParameter("@S_Img", SqlDbType.NVarChar,300),
                    new SqlParameter("@M_Img", SqlDbType.NVarChar,300),
                    new SqlParameter("@O_Img", SqlDbType.NVarChar,300),
                    new SqlParameter("@L_Img", SqlDbType.NVarChar,300),
                    new SqlParameter("@Sort", SqlDbType.Int,4),
                    new SqlParameter("@CreateTime", SqlDbType.DateTime),
                    new SqlParameter("@Remark", SqlDbType.NText),
                    new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.ProductId;
            parameters[1].Value = model.CN_Title;
            parameters[2].Value = model.EN_Title;
            parameters[3].Value = model.S_Img;
            parameters[4].Value = model.M_Img;
            parameters[5].Value = model.O_Img;
            parameters[6].Value = model.L_Img;
            parameters[7].Value = model.Sort;
            parameters[8].Value = model.CreateTime;
            parameters[9].Value = model.Remark;
            parameters[10].Value = model.ID;

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
            strSql.Append("delete from P_Photos ");
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
            strSql.Append("delete from P_Photos ");
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
        public NetWise.Entity.P_Photos GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,ProductId,CN_Title,EN_Title,S_Img,M_Img,O_Img,L_Img,Sort,CreateTime,Remark from P_Photos ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int,4)
            };
            parameters[0].Value = ID;

            NetWise.Entity.P_Photos model = new NetWise.Entity.P_Photos();
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
        public NetWise.Entity.P_Photos DataRowToModel(DataRow row)
        {
            NetWise.Entity.P_Photos model = new NetWise.Entity.P_Photos();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["ProductId"] != null && row["ProductId"].ToString() != "")
                {
                    model.ProductId = int.Parse(row["ProductId"].ToString());
                }
                if (row["CN_Title"] != null)
                {
                    model.CN_Title = row["CN_Title"].ToString();
                }
                if (row["EN_Title"] != null)
                {
                    model.EN_Title = row["EN_Title"].ToString();
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
            strSql.Append("select ID,ProductId,CN_Title,EN_Title,S_Img,M_Img,O_Img,L_Img,Sort,CreateTime,Remark ");
            strSql.Append(" FROM P_Photos ");
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
            strSql.Append(" ID,ProductId,CN_Title,EN_Title,S_Img,M_Img,O_Img,L_Img,Sort,CreateTime,Remark ");
            strSql.Append(" FROM P_Photos ");
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
            strSql.Append("select count(1) FROM P_Photos ");
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
            strSql.Append(")AS Row, T.*  from P_Photos T ");
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
			parameters[0].Value = "P_Photos";
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
        public DataSet GetListByProductId(int ProductId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,ProductId,CN_Title,EN_Title,S_Img,M_Img,O_Img,L_Img,Sort,CreateTime,Remark ");
            strSql.Append(" from P_Photos where ProductId='" + ProductId + "'");
            return DbHelperSQL.Query(strSql.ToString());
        }

        public bool UpdateProductId(int ProductId)
        {
            string sql = "update P_Photos set ProductId ='" + ProductId + "' where ProductId =0";
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
        #endregion  ExtensionMethod
    }
}

