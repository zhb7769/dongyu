using System;
using System.Data;
using System.Text;
using System.Web.UI;
using NetWise.DataAccess;

public partial class EnProduct : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        HengTuo.PageValidation.Sqlzy(this);
        if (!IsPostBack)
        {
            BindCategory();
            BindData();
        }
    }

    private void BindCategory()
    {
        DataSet ds = new ProductClass().GetList(0, "ParentId='0'", "Sort ASC");
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            rptCategory.DataSource = ds;
            rptCategory.DataBind();
        }
    }

    private void BindData()
    {
        int classId = 0;
        string strId = Request.QueryString["id"];
        if (string.IsNullOrEmpty(strId) || !int.TryParse(strId, out classId))
        {
            DataSet dsFirst = new ProductClass().GetList(1, "ParentId='0'", "Sort ASC");
            if (dsFirst != null && dsFirst.Tables[0].Rows.Count > 0)
            {
                classId = Convert.ToInt32(dsFirst.Tables[0].Rows[0]["ID"]);
            }
            else
            {
                return;
            }
        }

        NetWise.Entity.ProductClass classModel = new ProductClass().GetModel(classId);
        if (classModel != null)
        {
            ltIntro.Text = classModel.EN_Intro;
            linkSpec.HRef = "ProductSpecification.aspx?id=" + classId;
            linkApp.HRef = "ProductApplication.aspx?id=" + classId;
        }

        BindImages(classId);
    }

    private void BindImages(int classId)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("SELECT t2.pro_img, t1.EN_Name FROM Product t1 ");
        strSql.Append("INNER JOIN pro_att_info t2 ON t1.P_Id = t2.pro_id ");
        strSql.Append("WHERE t1.ClassId IN (SELECT ID FROM f_ProductNum(@ClassId)) ");
        strSql.Append("ORDER BY t1.Sort ASC, t2.at_id ASC");

        System.Data.SqlClient.SqlParameter[] parameters = {
            new System.Data.SqlClient.SqlParameter("@ClassId", System.Data.SqlDbType.Int)
        };
        parameters[0].Value = classId;

        DataSet ds = NetWise.DBUtility.DbHelperSQL.Query(strSql.ToString(), parameters);
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            rptImages.DataSource = ds;
            rptImages.DataBind();
        }
    }
}
