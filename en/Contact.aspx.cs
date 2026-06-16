using System;
using System.Web.UI;
using NetWise.DataAccess;

public partial class EnContact : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        HengTuo.PageValidation.Sqlzy(this);
        if (!IsPostBack)
        {
            Bind();
        }
    }

    // Contact page dedicated article ID (ArticleClassId=8 "Contact Content", used only by this page)
    private const int ContactArticleId = 25;

    private void Bind()
    {
        NetWise.DataAccess.Article dal = new NetWise.DataAccess.Article();
        NetWise.Entity.Article model = dal.GetModel(ContactArticleId);
        if (model != null)
        {
            // Contact content (English)
            ltENContent.Text = model.EN_Content;
        }
    }
}
