using NetWise.DBUtility;//Please add references
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
namespace NetWise.DataAccess
{
    /// <summary>
    /// 数据访问类:ProductRegister
    /// </summary>
    public partial class ProductRegister
    {
        public ProductRegister()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("ID", "ProductRegister");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ProductRegister");
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
        public int Add(NetWise.Entity.ProductRegister model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ProductRegister(");
            strSql.Append("userName,EN_userName,Email,EN_country,serialNumber,EN_serialNumber,productType,EN_productType,PurchaseDate,c_id,channels_id,isReceive,V1,V2,V3,V4)");
            strSql.Append(" values (");
            strSql.Append("@userName,@EN_userName,@Email,@EN_country,@serialNumber,@EN_serialNumber,@productType,@EN_productType,@PurchaseDate,@c_id,@channels_id,@isReceive,@V1,@V2,@V3,@V4)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@userName", SqlDbType.VarChar,500),
                    new SqlParameter("@EN_userName", SqlDbType.VarChar,500),
                    new SqlParameter("@Email", SqlDbType.VarChar,500),
                    new SqlParameter("@EN_country", SqlDbType.VarChar,500),
                    new SqlParameter("@serialNumber", SqlDbType.VarChar,500),
                    new SqlParameter("@EN_serialNumber", SqlDbType.VarChar,500),
                    new SqlParameter("@productType", SqlDbType.VarChar,500),
                    new SqlParameter("@EN_productType", SqlDbType.VarChar,500),
                    new SqlParameter("@PurchaseDate", SqlDbType.DateTime),
                    new SqlParameter("@c_id", SqlDbType.Int,4),
                    new SqlParameter("@channels_id", SqlDbType.Int,4),
                    new SqlParameter("@isReceive", SqlDbType.Bit,1),
                    new SqlParameter("@V1", SqlDbType.VarChar,500),
                    new SqlParameter("@V2", SqlDbType.VarChar,500),
                    new SqlParameter("@V3", SqlDbType.VarChar,500),
                    new SqlParameter("@V4", SqlDbType.VarChar,500)};
            parameters[0].Value = model.userName;
            parameters[1].Value = model.EN_userName;
            parameters[2].Value = model.Email;
            parameters[3].Value = model.EN_country;
            parameters[4].Value = model.serialNumber;
            parameters[5].Value = model.EN_serialNumber;
            parameters[6].Value = model.productType;
            parameters[7].Value = model.EN_productType;
            parameters[8].Value = model.PurchaseDate;
            parameters[9].Value = model.c_id;
            parameters[10].Value = model.channels_id;
            parameters[11].Value = model.isReceive;
            parameters[12].Value = model.V1;
            parameters[13].Value = model.V2;
            parameters[14].Value = model.V3;
            parameters[15].Value = model.V4;

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
        public bool Update(NetWise.Entity.ProductRegister model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ProductRegister set ");
            strSql.Append("userName=@userName,");
            strSql.Append("EN_userName=@EN_userName,");
            strSql.Append("Email=@Email,");
            strSql.Append("EN_country=@EN_country,");
            strSql.Append("serialNumber=@serialNumber,");
            strSql.Append("EN_serialNumber=@EN_serialNumber,");
            strSql.Append("productType=@productType,");
            strSql.Append("EN_productType=@EN_productType,");
            strSql.Append("PurchaseDate=@PurchaseDate,");
            strSql.Append("c_id=@c_id,");
            strSql.Append("channels_id=@channels_id,");
            strSql.Append("isReceive=@isReceive,");
            strSql.Append("V1=@V1,");
            strSql.Append("V2=@V2,");
            strSql.Append("V3=@V3,");
            strSql.Append("V4=@V4");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@userName", SqlDbType.VarChar,500),
                    new SqlParameter("@EN_userName", SqlDbType.VarChar,500),
                    new SqlParameter("@Email", SqlDbType.VarChar,500),
                    new SqlParameter("@EN_country", SqlDbType.VarChar,500),
                    new SqlParameter("@serialNumber", SqlDbType.VarChar,500),
                    new SqlParameter("@EN_serialNumber", SqlDbType.VarChar,500),
                    new SqlParameter("@productType", SqlDbType.VarChar,500),
                    new SqlParameter("@EN_productType", SqlDbType.VarChar,500),
                    new SqlParameter("@PurchaseDate", SqlDbType.DateTime),
                    new SqlParameter("@c_id", SqlDbType.Int,4),
                    new SqlParameter("@channels_id", SqlDbType.Int,4),
                    new SqlParameter("@isReceive", SqlDbType.Bit,1),
                    new SqlParameter("@V1", SqlDbType.VarChar,500),
                    new SqlParameter("@V2", SqlDbType.VarChar,500),
                    new SqlParameter("@V3", SqlDbType.VarChar,500),
                    new SqlParameter("@V4", SqlDbType.VarChar,500),
                    new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.userName;
            parameters[1].Value = model.EN_userName;
            parameters[2].Value = model.Email;
            parameters[3].Value = model.EN_country;
            parameters[4].Value = model.serialNumber;
            parameters[5].Value = model.EN_serialNumber;
            parameters[6].Value = model.productType;
            parameters[7].Value = model.EN_productType;
            parameters[8].Value = model.PurchaseDate;
            parameters[9].Value = model.c_id;
            parameters[10].Value = model.channels_id;
            parameters[11].Value = model.isReceive;
            parameters[12].Value = model.V1;
            parameters[13].Value = model.V2;
            parameters[14].Value = model.V3;
            parameters[15].Value = model.V4;
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
            strSql.Append("delete from ProductRegister ");
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
            strSql.Append("delete from ProductRegister ");
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
        public NetWise.Entity.ProductRegister GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,userName,EN_userName,Email,EN_country,serialNumber,EN_serialNumber,productType,EN_productType,PurchaseDate,c_id,channels_id,isReceive,V1,V2,V3,V4 from ProductRegister ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int,4)
            };
            parameters[0].Value = ID;

            NetWise.Entity.ProductRegister model = new NetWise.Entity.ProductRegister();
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
        public NetWise.Entity.ProductRegister DataRowToModel(DataRow row)
        {
            NetWise.Entity.ProductRegister model = new NetWise.Entity.ProductRegister();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["userName"] != null)
                {
                    model.userName = row["userName"].ToString();
                }
                if (row["EN_userName"] != null)
                {
                    model.EN_userName = row["EN_userName"].ToString();
                }
                if (row["Email"] != null)
                {
                    model.Email = row["Email"].ToString();
                }
                if (row["EN_country"] != null)
                {
                    model.EN_country = row["EN_country"].ToString();
                }
                if (row["serialNumber"] != null)
                {
                    model.serialNumber = row["serialNumber"].ToString();
                }
                if (row["EN_serialNumber"] != null)
                {
                    model.EN_serialNumber = row["EN_serialNumber"].ToString();
                }
                if (row["productType"] != null)
                {
                    model.productType = row["productType"].ToString();
                }
                if (row["EN_productType"] != null)
                {
                    model.EN_productType = row["EN_productType"].ToString();
                }
                if (row["PurchaseDate"] != null && row["PurchaseDate"].ToString() != "")
                {
                    model.PurchaseDate = DateTime.Parse(row["PurchaseDate"].ToString());
                }
                if (row["c_id"] != null && row["c_id"].ToString() != "")
                {
                    model.c_id = int.Parse(row["c_id"].ToString());
                }
                if (row["channels_id"] != null && row["channels_id"].ToString() != "")
                {
                    model.channels_id = int.Parse(row["channels_id"].ToString());
                }
                if (row["isReceive"] != null && row["isReceive"].ToString() != "")
                {
                    if ((row["isReceive"].ToString() == "1") || (row["isReceive"].ToString().ToLower() == "true"))
                    {
                        model.isReceive = true;
                    }
                    else
                    {
                        model.isReceive = false;
                    }
                }
                if (row["V1"] != null)
                {
                    model.V1 = row["V1"].ToString();
                }
                if (row["V2"] != null)
                {
                    model.V2 = row["V2"].ToString();
                }
                if (row["V3"] != null)
                {
                    model.V3 = row["V3"].ToString();
                }
                if (row["V4"] != null)
                {
                    model.V4 = row["V4"].ToString();
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
            strSql.Append("select ID,userName,EN_userName,Email,EN_country,serialNumber,EN_serialNumber,productType,EN_productType,PurchaseDate,c_id,channels_id,isReceive,V1,V2,V3,V4 ");
            strSql.Append(" FROM ProductRegister ");
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
            strSql.Append(" ID,userName,EN_userName,Email,EN_country,serialNumber,EN_serialNumber,productType,EN_productType,PurchaseDate,c_id,channels_id,isReceive,V1,V2,V3,V4 ");
            strSql.Append(" FROM ProductRegister ");
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
            strSql.Append("select count(1) FROM ProductRegister ");
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
            strSql.Append(")AS Row, T.*  from ProductRegister T ");
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
			parameters[0].Value = "ProductRegister";
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
        /// 获得前几行数据(采购渠道,国家)
        /// </summary>
        public DataSet GetListJoinEx(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" ass.*,pct.name as pName,pct.EN_name pEname ");
            strSql.Append("FROM ProductRegister ass JOIN PurchasingChannelsType pct ON ass.channels_id = pct.id");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }


        /// <summary>
        /// 得到一个对象实体(采购渠道,国家)
        /// </summary>
        public DataSet GetModelEx(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ass.*,pct.name as pName,pct.EN_name pEname" +
                " from ProductRegister ass JOIN PurchasingChannelsType pct ON ass.channels_id = pct.id ");
            strSql.Append(" where ass.ID=" + ID);
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion  ExtensionMethod
    }
}

