using System;
using System.Data;
using System.Web.UI;
using NetWise.DataAccess;

public partial class Index : System.Web.UI.Page
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
    /// 绑定关于东宇
    /// </summary>
    private void BindAbout()
    {
        NetWise.DataAccess.Article dal = new NetWise.DataAccess.Article();
        NetWise.Entity.Article model = dal.GetModelByClassID(1);
        if (model != null)
        {
            ltAboutSummary.Text = model.CN_Summary;
            ltAboutContent.Text = model.CN_Content;
            if (!string.IsNullOrEmpty(model.Pic_Url))
            {
                imgAbout.ImageUrl = model.Pic_Url;
            }
        }
    }

    /// <summary>
    /// 绑定产品分类
    /// </summary>
    private void BindProductClass()
    {
        NetWise.DataAccess.ProductClass dal = new NetWise.DataAccess.ProductClass();
        DataSet ds = dal.GetList(0, "", "Sort asc");
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            rptProductClass.DataSource = ds;
            rptProductClass.DataBind();
        }
    }

    /// <summary>
    /// 绑定生产基地
    /// </summary>
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
}
