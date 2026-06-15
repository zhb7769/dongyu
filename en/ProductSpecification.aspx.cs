using System;
using System.Data;
using System.Web.UI;
using NetWise.DataAccess;

public partial class EnProductSpecification : System.Web.UI.Page
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
            ltSpec.Text = classModel.EN_Spec;
        }
    }
}
