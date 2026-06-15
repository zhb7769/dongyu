using System;
using System.Data;
using System.Web.UI;
using NetWise.DataAccess;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindNavProduct();
        }
    }

    private void BindNavProduct()
    {
        DataSet ds = new ProductClass().GetList(0, "ParentId='0'", "Sort ASC");
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            rptNavProduct.DataSource = ds;
            rptNavProduct.DataBind();
        }
    }
}
