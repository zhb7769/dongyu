using System;
using System.Data;
using System.Web.UI;
using NetWise.DataAccess;

public partial class EnIndex : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        HengTuo.PageValidation.Sqlzy(this);
        if (!IsPostBack)
        {
            BindAbout();
            BindProductClass();
            BindBase();
        }
    }

    /// <summary>
    /// Bind About Dongyu
    /// </summary>
    private void BindAbout()
    {
        NetWise.DataAccess.Article dal = new NetWise.DataAccess.Article();
        NetWise.Entity.Article model = dal.GetModelByClassID(1);
        if (model != null)
        {
            ltAboutSummary.Text = model.EN_Summary;
            ltAboutContent.Text = model.EN_Content;
            if (!string.IsNullOrEmpty(model.Pic_Url))
            {
                imgAbout.ImageUrl = "/uploadfiles/article/" + model.Pic_Url;
            }
        }
    }

    /// <summary>
    /// Bind Product Categories
    /// </summary>
    private void BindProductClass()
    {
        NetWise.DataAccess.ProductClass dal = new NetWise.DataAccess.ProductClass();
        DataSet ds = dal.GetList(0, "ParentId='0'", "Sort asc");
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            rptProductClass.DataSource = ds;
            rptProductClass.DataBind();
        }
    }

    /// <summary>
    /// Bind Production Base
    /// </summary>
    private void BindBase()
    {
        NetWise.DataAccess.Article dal = new NetWise.DataAccess.Article();
        DataSet ds = dal.GetList(0, " and ArticleClassId=10", "Sort asc");
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            rptBase.DataSource = ds;
            rptBase.DataBind();
        }
    }

    protected string GetLogo(string title)
    {
        if (title.Contains("东诚"))
            return "../images/logo_dc.png";
        if (title.Contains("东锋"))
            return "../images/logo_df.png";

        return "../images/logo2.png";
    }
}
