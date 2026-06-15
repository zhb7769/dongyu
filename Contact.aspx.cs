using System;
using System.Web.UI;
using NetWise.DataAccess;

public partial class Contact : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        HengTuo.PageValidation.Sqlzy(this);
        if (!IsPostBack)
        {
            Bind();
        }
    }

    // 联系我们页面专用文章 ID（ArticleClassId=8「联系我们内容」，仅此页面使用）
    private const int ContactArticleId = 25;

    private void Bind()
    {
        NetWise.DataAccess.Article dal = new NetWise.DataAccess.Article();
        NetWise.Entity.Article model = dal.GetModel(ContactArticleId);
        if (model != null)
        {
            // 国内事业部（整块富文本）
            ltCNContent.Text = model.CN_Content;
            // 海外事业部（整块富文本）
            ltENContent.Text = model.EN_Content;
        }
    }
}
