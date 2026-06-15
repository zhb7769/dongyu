using NetWise.DBUtility;//Please add references
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
namespace NetWise.DataAccess
{
    /// <summary>
    /// 数据访问类:Contact
    /// </summary>
    public partial class Contact
    {
        public Contact()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Contact");
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
        public int Add(NetWise.Entity.Contact model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Contact(");
            strSql.Append("CN_Company,EN_Company,CN_Address,EN_Address,CN_CompanyTel,EN_CompanyTel,CN_Phone,EN_Phone,Fax,PostCode,Email,Website,QQ,SKYPE,CN_Content,EN_Content,CN_Person,EN_Person)");
            strSql.Append(" values (");
            strSql.Append("@CN_Company,@EN_Company,@CN_Address,@EN_Address,@CN_CompanyTel,@EN_CompanyTel,@CN_Phone,@EN_Phone,@Fax,@PostCode,@Email,@Website,@QQ,@SKYPE,@CN_Content,@EN_Content,@CN_Person,@EN_Person)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@CN_Company", SqlDbType.NVarChar,300),
                    new SqlParameter("@EN_Company", SqlDbType.NVarChar,300),
                    new SqlParameter("@CN_Address", SqlDbType.NVarChar,300),
                    new SqlParameter("@EN_Address", SqlDbType.NVarChar,300),
                    new SqlParameter("@CN_CompanyTel", SqlDbType.NVarChar,50),
                    new SqlParameter("@EN_CompanyTel", SqlDbType.NVarChar,50),
                    new SqlParameter("@CN_Phone", SqlDbType.NVarChar,50),
                    new SqlParameter("@EN_Phone", SqlDbType.NVarChar,50),
                    new SqlParameter("@Fax", SqlDbType.NVarChar,50),
                    new SqlParameter("@PostCode", SqlDbType.NVarChar,50),
                    new SqlParameter("@Email", SqlDbType.NVarChar,50),
                    new SqlParameter("@Website", SqlDbType.NVarChar,50),
                    new SqlParameter("@QQ", SqlDbType.NVarChar,50),
                    new SqlParameter("@SKYPE", SqlDbType.NVarChar,50),
                    new SqlParameter("@CN_Content", SqlDbType.NText),
                    new SqlParameter("@EN_Content", SqlDbType.NText),
                    new SqlParameter("@CN_Person", SqlDbType.NVarChar,50),
                    new SqlParameter("@EN_Person", SqlDbType.NVarChar,50) };
            parameters[0].Value = model.CN_Company;
            parameters[1].Value = model.EN_Company;
            parameters[2].Value = model.CN_Address;
            parameters[3].Value = model.EN_Address;
            parameters[4].Value = model.CN_CompanyTel;
            parameters[5].Value = model.EN_CompanyTel;
            parameters[6].Value = model.CN_Phone;
            parameters[7].Value = model.EN_Phone;
            parameters[8].Value = model.Fax;
            parameters[9].Value = model.PostCode;
            parameters[10].Value = model.Email;
            parameters[11].Value = model.Website;
            parameters[12].Value = model.QQ;
            parameters[13].Value = model.SKYPE;
            parameters[14].Value = model.CN_Content;
            parameters[15].Value = model.EN_Content;
            parameters[16].Value = model.CN_Person;
            parameters[17].Value = model.EN_Person;

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
        public bool Update(NetWise.Entity.Contact model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Contact set ");
            strSql.Append("CN_Company=@CN_Company,");
            strSql.Append("EN_Company=@EN_Company,");
            strSql.Append("CN_Address=@CN_Address,");
            strSql.Append("EN_Address=@EN_Address,");
            strSql.Append("CN_CompanyTel=@CN_CompanyTel,");
            strSql.Append("EN_CompanyTel=@EN_CompanyTel,");
            strSql.Append("CN_Phone=@CN_Phone,");
            strSql.Append("EN_Phone=@EN_Phone,");
            strSql.Append("Fax=@Fax,");
            strSql.Append("PostCode=@PostCode,");
            strSql.Append("Email=@Email,");
            strSql.Append("Website=@Website,");
            strSql.Append("QQ=@QQ,");
            strSql.Append("SKYPE=@SKYPE,");
            strSql.Append("CN_Content=@CN_Content,");
            strSql.Append("EN_Content=@EN_Content,");
            strSql.Append("CN_Person=@CN_Person,");
            strSql.Append("EN_Person=@EN_Person");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@CN_Company", SqlDbType.NVarChar,300),
                    new SqlParameter("@EN_Company", SqlDbType.NVarChar,300),
                    new SqlParameter("@CN_Address", SqlDbType.NVarChar,300),
                    new SqlParameter("@EN_Address", SqlDbType.NVarChar,300),
                    new SqlParameter("@CN_CompanyTel", SqlDbType.NVarChar,50),
                    new SqlParameter("@EN_CompanyTel", SqlDbType.NVarChar,50),
                    new SqlParameter("@CN_Phone", SqlDbType.NVarChar,50),
                    new SqlParameter("@EN_Phone", SqlDbType.NVarChar,50),
                    new SqlParameter("@Fax", SqlDbType.NVarChar,50),
                    new SqlParameter("@PostCode", SqlDbType.NVarChar,50),
                    new SqlParameter("@Email", SqlDbType.NVarChar,50),
                    new SqlParameter("@Website", SqlDbType.NVarChar,50),
                    new SqlParameter("@QQ", SqlDbType.NVarChar,50),
                    new SqlParameter("@SKYPE", SqlDbType.NVarChar,50),
                    new SqlParameter("@CN_Content", SqlDbType.NText),
                    new SqlParameter("@EN_Content", SqlDbType.NText),
                    new SqlParameter("@CN_Person", SqlDbType.NVarChar,50),
                    new SqlParameter("@EN_Person", SqlDbType.NVarChar,50),
                    new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.CN_Company;
            parameters[1].Value = model.EN_Company;
            parameters[2].Value = model.CN_Address;
            parameters[3].Value = model.EN_Address;
            parameters[4].Value = model.CN_CompanyTel;
            parameters[5].Value = model.EN_CompanyTel;
            parameters[6].Value = model.CN_Phone;
            parameters[7].Value = model.EN_Phone;
            parameters[8].Value = model.Fax;
            parameters[9].Value = model.PostCode;
            parameters[10].Value = model.Email;
            parameters[11].Value = model.Website;
            parameters[12].Value = model.QQ;
            parameters[13].Value = model.SKYPE;
            parameters[14].Value = model.CN_Content;
            parameters[15].Value = model.EN_Content;
            parameters[16].Value = model.CN_Person;
            parameters[17].Value = model.EN_Person;
            parameters[18].Value = model.ID;

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
            strSql.Append("delete from Contact ");
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
            strSql.Append("delete from Contact ");
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
        public NetWise.Entity.Contact GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,CN_Company,EN_Company,CN_Address,EN_Address,CN_CompanyTel,EN_CompanyTel,CN_Phone,EN_Phone,Fax,PostCode,Email,Website,QQ,SKYPE,CN_Content,EN_Content,CN_Person,EN_Person from Contact ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int,4)
            };
            parameters[0].Value = ID;

            NetWise.Entity.Contact model = new NetWise.Entity.Contact();
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
        public NetWise.Entity.Contact DataRowToModel(DataRow row)
        {
            NetWise.Entity.Contact model = new NetWise.Entity.Contact();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["CN_Company"] != null)
                {
                    model.CN_Company = row["CN_Company"].ToString();
                }
                if (row["EN_Company"] != null)
                {
                    model.EN_Company = row["EN_Company"].ToString();
                }
                if (row["CN_Address"] != null)
                {
                    model.CN_Address = row["CN_Address"].ToString();
                }
                if (row["EN_Address"] != null)
                {
                    model.EN_Address = row["EN_Address"].ToString();
                }
                if (row["CN_CompanyTel"] != null)
                {
                    model.CN_CompanyTel = row["CN_CompanyTel"].ToString();
                }
                if (row["EN_CompanyTel"] != null)
                {
                    model.EN_CompanyTel = row["EN_CompanyTel"].ToString();
                }
                if (row["CN_Phone"] != null)
                {
                    model.CN_Phone = row["CN_Phone"].ToString();
                }
                if (row["EN_Phone"] != null)
                {
                    model.EN_Phone = row["EN_Phone"].ToString();
                }
                if (row["Fax"] != null)
                {
                    model.Fax = row["Fax"].ToString();
                }
                if (row["PostCode"] != null)
                {
                    model.PostCode = row["PostCode"].ToString();
                }
                if (row["Email"] != null)
                {
                    model.Email = row["Email"].ToString();
                }
                if (row["Website"] != null)
                {
                    model.Website = row["Website"].ToString();
                }
                if (row["QQ"] != null)
                {
                    model.QQ = row["QQ"].ToString();
                }
                if (row["SKYPE"] != null)
                {
                    model.SKYPE = row["SKYPE"].ToString();
                }
                if (row["CN_Content"] != null)
                {
                    model.CN_Content = row["CN_Content"].ToString();
                }
                if (row["EN_Content"] != null)
                {
                    model.EN_Content = row["EN_Content"].ToString();
                }
                if (row["CN_Person"] != null)
                {
                    model.CN_Person = row["CN_Person"].ToString();
                }
                if (row["EN_Person"] != null)
                {
                    model.EN_Person = row["EN_Person"].ToString();
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
            strSql.Append("select ID,CN_Company,EN_Company,CN_Address,EN_Address,CN_CompanyTel,EN_CompanyTel,CN_Phone,EN_Phone,Fax,PostCode,Email,Website,QQ,SKYPE,CN_Content,EN_Content,CN_Person,EN_Person ");
            strSql.Append(" FROM Contact ");
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
            strSql.Append(" ID,CN_Company,EN_Company,CN_Address,EN_Address,CN_CompanyTel,EN_CompanyTel,CN_Phone,EN_Phone,Fax,PostCode,Email,Website,QQ,SKYPE,CN_Content,EN_Content,CN_Person,EN_Person ");
            strSql.Append(" FROM Contact ");
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
            strSql.Append("select count(1) FROM Contact ");
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
            strSql.Append(")AS Row, T.*  from Contact T ");
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
            parameters[0].Value = "Contact";
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
            if (DbHelperSQL.Exists("select count(1) from Contact"))
            {
                object obj = DbHelperSQL.GetSingle("select ID from Contact");
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


