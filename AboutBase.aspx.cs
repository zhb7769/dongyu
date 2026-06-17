using System;
using System.Data;
using System.Web.UI;
using NetWise.DataAccess;

public partial class AboutBase : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        HengTuo.PageValidation.Sqlzy(this);
        if (!IsPostBack)
        {
            BindTitle();
            BindBase();
        }
    }

    private void BindTitle()
    {
        NetWise.DataAccess.ArticleClass dal = new NetWise.DataAccess.ArticleClass();
        NetWise.Entity.ArticleClass model = dal.GetModel(2);
        if (model != null)
        {
            ltBanTitle.Text = model.CN_Name;
            ltTitle.Text = model.CN_Name;
        }
    }

    private void BindBase()
    {
        NetWise.DataAccess.Article dal = new NetWise.DataAccess.Article();
        DataSet ds = dal.GetList(0, " and ArticleClassId=2", "Sort asc");
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            rptBase.DataSource = ds;
            rptBase.DataBind();
        }
    }


    protected string GetLogo(string title)
    {
        if (title.Contains("东诚"))
            return "images/logo_dc.png";

        return "images/logo2.png";
    }
}
