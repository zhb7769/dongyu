using NetWise.DBUtility;//Please add references
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
namespace NetWise.DataAccess
{
    /// <summary>
    /// 数据访问类:AfterSalesService
    /// </summary>
    public partial class AfterSalesService
    {
        public AfterSalesService()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("ID", "AfterSalesService");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from AfterSalesService");
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
        public int Add(NetWise.Entity.AfterSalesService model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into AfterSalesService(");
            strSql.Append("channels_id,c_id,city,phoneNumber,orderNumber,productType,serialNumber,versionNumber,puchaseDate,productDescription,EN_phoneNumber,EN_orderNumber,EN_country,EN_city,EN_productType,EN_serialNumber,EN_versionNumber,EN_productDescription,address,EN_address,V1,V2,V3,V4)");
            strSql.Append(" values (");
            strSql.Append("@channels_id,@c_id,@city,@phoneNumber,@orderNumber,@productType,@serialNumber,@versionNumber,@puchaseDate,@productDescription,@EN_phoneNumber,@EN_orderNumber,@EN_country,@EN_city,@EN_productType,@EN_serialNumber,@EN_versionNumber,@EN_productDescription,@address,@EN_address,@V1,@V2,@V3,@V4)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@channels_id", SqlDbType.Int,4),
                    new SqlParameter("@c_id", SqlDbType.Int,4),
                    new SqlParameter("@city", SqlDbType.VarChar,500),
                    new SqlParameter("@phoneNumber", SqlDbType.VarChar,500),
                    new SqlParameter("@orderNumber", SqlDbType.VarChar,500),
                    new SqlParameter("@productType", SqlDbType.VarChar,500),
                    new SqlParameter("@serialNumber", SqlDbType.VarChar,500),
                    new SqlParameter("@versionNumber", SqlDbType.VarChar,500),
                    new SqlParameter("@puchaseDate", SqlDbType.DateTime),
                    new SqlParameter("@productDescription", SqlDbType.VarChar,5000),
                    new SqlParameter("@EN_phoneNumber", SqlDbType.VarChar,500),
                    new SqlParameter("@EN_orderNumber", SqlDbType.VarChar,500),
                    new SqlParameter("@EN_country", SqlDbType.VarChar,500),
                    new SqlParameter("@EN_city", SqlDbType.VarChar,500),
                    new SqlParameter("@EN_productType", SqlDbType.VarChar,500),
                    new SqlParameter("@EN_serialNumber", SqlDbType.VarChar,500),
                    new SqlParameter("@EN_versionNumber", SqlDbType.VarChar,500),
                    new SqlParameter("@EN_productDescription", SqlDbType.VarChar,5000),
                    new SqlParameter("@address", SqlDbType.VarChar,5000),
                    new SqlParameter("@EN_address", SqlDbType.VarChar,5000),
                    new SqlParameter("@V1", SqlDbType.VarChar,500),
                    new SqlParameter("@V2", SqlDbType.VarChar,500),
                    new SqlParameter("@V3", SqlDbType.VarChar,500),
                    new SqlParameter("@V4", SqlDbType.VarChar,500)};
            parameters[0].Value = model.channels_id;
            parameters[1].Value = model.c_id;
            parameters[2].Value = model.city;
            parameters[3].Value = model.phoneNumber;
            parameters[4].Value = model.orderNumber;
            parameters[5].Value = model.productType;
            parameters[6].Value = model.serialNumber;
            parameters[7].Value = model.versionNumber;
            parameters[8].Value = model.puchaseDate;
            parameters[9].Value = model.productDescription;
            parameters[10].Value = model.EN_phoneNumber;
            parameters[11].Value = model.EN_orderNumber;
            parameters[12].Value = model.EN_country;
            parameters[13].Value = model.EN_city;
            parameters[14].Value = model.EN_productType;
            parameters[15].Value = model.EN_serialNumber;
            parameters[16].Value = model.EN_versionNumber;
            parameters[17].Value = model.EN_productDescription;
            parameters[18].Value = model.address;
            parameters[19].Value = model.EN_address;
            parameters[20].Value = model.V1;
            parameters[21].Value = model.V2;
            parameters[22].Value = model.V3;
            parameters[23].Value = model.V4;

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
        public bool Update(NetWise.Entity.AfterSalesService model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update AfterSalesService set ");
            strSql.Append("channels_id=@channels_id,");
            strSql.Append("c_id=@c_id,");
            strSql.Append("city=@city,");
            strSql.Append("phoneNumber=@phoneNumber,");
            strSql.Append("orderNumber=@orderNumber,");
            strSql.Append("productType=@productType,");
            strSql.Append("serialNumber=@serialNumber,");
            strSql.Append("versionNumber=@versionNumber,");
            strSql.Append("puchaseDate=@puchaseDate,");
            strSql.Append("productDescription=@productDescription,");
            strSql.Append("EN_phoneNumber=@EN_phoneNumber,");
            strSql.Append("EN_orderNumber=@EN_orderNumber,");
            strSql.Append("EN_country=@EN_country,");
            strSql.Append("EN_city=@EN_city,");
            strSql.Append("EN_productType=@EN_productType,");
            strSql.Append("EN_serialNumber=@EN_serialNumber,");
            strSql.Append("EN_versionNumber=@EN_versionNumber,");
            strSql.Append("EN_productDescription=@EN_productDescription,");
            strSql.Append("address=@address,");
            strSql.Append("EN_address=@EN_address,");
            strSql.Append("V1=@V1,");
            strSql.Append("V2=@V2,");
            strSql.Append("V3=@V3,");
            strSql.Append("V4=@V4");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@channels_id", SqlDbType.Int,4),
                    new SqlParameter("@c_id", SqlDbType.Int,4),
                    new SqlParameter("@city", SqlDbType.VarChar,500),
                    new SqlParameter("@phoneNumber", SqlDbType.VarChar,500),
                    new SqlParameter("@orderNumber", SqlDbType.VarChar,500),
                    new SqlParameter("@productType", SqlDbType.VarChar,500),
                    new SqlParameter("@serialNumber", SqlDbType.VarChar,500),
                    new SqlParameter("@versionNumber", SqlDbType.VarChar,500),
                    new SqlParameter("@puchaseDate", SqlDbType.DateTime),
                    new SqlParameter("@productDescription", SqlDbType.VarChar,5000),
                    new SqlParameter("@EN_phoneNumber", SqlDbType.VarChar,500),
                    new SqlParameter("@EN_orderNumber", SqlDbType.VarChar,500),
                    new SqlParameter("@EN_country", SqlDbType.VarChar,500),
                    new SqlParameter("@EN_city", SqlDbType.VarChar,500),
                    new SqlParameter("@EN_productType", SqlDbType.VarChar,500),
                    new SqlParameter("@EN_serialNumber", SqlDbType.VarChar,500),
                    new SqlParameter("@EN_versionNumber", SqlDbType.VarChar,500),
                    new SqlParameter("@EN_productDescription", SqlDbType.VarChar,5000),
                    new SqlParameter("@address", SqlDbType.VarChar,5000),
                    new SqlParameter("@EN_address", SqlDbType.VarChar,5000),
                    new SqlParameter("@V1", SqlDbType.VarChar,500),
                    new SqlParameter("@V2", SqlDbType.VarChar,500),
                    new SqlParameter("@V3", SqlDbType.VarChar,500),
                    new SqlParameter("@V4", SqlDbType.VarChar,500),
                    new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.channels_id;
            parameters[1].Value = model.c_id;
            parameters[2].Value = model.city;
            parameters[3].Value = model.phoneNumber;
            parameters[4].Value = model.orderNumber;
            parameters[5].Value = model.productType;
            parameters[6].Value = model.serialNumber;
            parameters[7].Value = model.versionNumber;
            parameters[8].Value = model.puchaseDate;
            parameters[9].Value = model.productDescription;
            parameters[10].Value = model.EN_phoneNumber;
            parameters[11].Value = model.EN_orderNumber;
            parameters[12].Value = model.EN_country;
            parameters[13].Value = model.EN_city;
            parameters[14].Value = model.EN_productType;
            parameters[15].Value = model.EN_serialNumber;
            parameters[16].Value = model.EN_versionNumber;
            parameters[17].Value = model.EN_productDescription;
            parameters[18].Value = model.address;
            parameters[19].Value = model.EN_address;
            parameters[20].Value = model.V1;
            parameters[21].Value = model.V2;
            parameters[22].Value = model.V3;
            parameters[23].Value = model.V4;
            parameters[24].Value = model.ID;

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
            strSql.Append("delete from AfterSalesService ");
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
            strSql.Append("delete from AfterSalesService ");
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
        public NetWise.Entity.AfterSalesService GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,channels_id,c_id,city,phoneNumber,orderNumber,productType,serialNumber,versionNumber,puchaseDate,productDescription,EN_phoneNumber,EN_orderNumber,EN_country,EN_city,EN_productType,EN_serialNumber,EN_versionNumber,EN_productDescription,address,EN_address,V1,V2,V3,V4 from AfterSalesService ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int,4)
            };
            parameters[0].Value = ID;

            NetWise.Entity.AfterSalesService model = new NetWise.Entity.AfterSalesService();
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
        public NetWise.Entity.AfterSalesService DataRowToModel(DataRow row)
        {
            NetWise.Entity.AfterSalesService model = new NetWise.Entity.AfterSalesService();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["channels_id"] != null && row["channels_id"].ToString() != "")
                {
                    model.channels_id = int.Parse(row["channels_id"].ToString());
                }
                if (row["c_id"] != null && row["c_id"].ToString() != "")
                {
                    model.c_id = int.Parse(row["c_id"].ToString());
                }
                if (row["city"] != null)
                {
                    model.city = row["city"].ToString();
                }
                if (row["phoneNumber"] != null)
                {
                    model.phoneNumber = row["phoneNumber"].ToString();
                }
                if (row["orderNumber"] != null)
                {
                    model.orderNumber = row["orderNumber"].ToString();
                }
                if (row["productType"] != null)
                {
                    model.productType = row["productType"].ToString();
                }
                if (row["serialNumber"] != null)
                {
                    model.serialNumber = row["serialNumber"].ToString();
                }
                if (row["versionNumber"] != null)
                {
                    model.versionNumber = row["versionNumber"].ToString();
                }
                if (row["puchaseDate"] != null && row["puchaseDate"].ToString() != "")
                {
                    model.puchaseDate = DateTime.Parse(row["puchaseDate"].ToString());
                }
                if (row["productDescription"] != null)
                {
                    model.productDescription = row["productDescription"].ToString();
                }
                if (row["EN_phoneNumber"] != null)
                {
                    model.EN_phoneNumber = row["EN_phoneNumber"].ToString();
                }
                if (row["EN_orderNumber"] != null)
                {
                    model.EN_orderNumber = row["EN_orderNumber"].ToString();
                }
                if (row["EN_country"] != null)
                {
                    model.EN_country = row["EN_country"].ToString();
                }
                if (row["EN_city"] != null)
                {
                    model.EN_city = row["EN_city"].ToString();
                }
                if (row["EN_productType"] != null)
                {
                    model.EN_productType = row["EN_productType"].ToString();
                }
                if (row["EN_serialNumber"] != null)
                {
                    model.EN_serialNumber = row["EN_serialNumber"].ToString();
                }
                if (row["EN_versionNumber"] != null)
                {
                    model.EN_versionNumber = row["EN_versionNumber"].ToString();
                }
                if (row["EN_productDescription"] != null)
                {
                    model.EN_productDescription = row["EN_productDescription"].ToString();
                }
                if (row["address"] != null)
                {
                    model.address = row["address"].ToString();
                }
                if (row["EN_address"] != null)
                {
                    model.EN_address = row["EN_address"].ToString();
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
            strSql.Append("select ID,channels_id,c_id,city,phoneNumber,orderNumber,productType,serialNumber,versionNumber,puchaseDate,productDescription,EN_phoneNumber,EN_orderNumber,EN_country,EN_city,EN_productType,EN_serialNumber,EN_versionNumber,EN_productDescription,address,EN_address,V1,V2,V3,V4 ");
            strSql.Append(" FROM AfterSalesService ");
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
            strSql.Append(" ID,channels_id,c_id,city,phoneNumber,orderNumber,productType,serialNumber,versionNumber,puchaseDate,productDescription,EN_phoneNumber,EN_orderNumber,EN_country,EN_city,EN_productType,EN_serialNumber,EN_versionNumber,EN_productDescription,address,EN_address,V1,V2,V3,V4 ");
            strSql.Append(" FROM AfterSalesService ");
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
            strSql.Append("select count(1) FROM AfterSalesService ");
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
            strSql.Append(")AS Row, T.*  from AfterSalesService T ");
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
			parameters[0].Value = "AfterSalesService";
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
            strSql.Append("FROM AfterSalesService ass JOIN PurchasingChannelsType pct ON ass.channels_id = pct.id");
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
                " from AfterSalesService ass JOIN PurchasingChannelsType pct ON ass.channels_id = pct.id ");
            strSql.Append(" where ass.ID=" + ID);
            return DbHelperSQL.Query(strSql.ToString());
        }


        #endregion  ExtensionMethod
    }
}

