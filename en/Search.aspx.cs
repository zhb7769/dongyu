using System;
using System.Data;
using System.Web.UI;
using NetWise.DataAccess;

public partial class EnSearch : System.Web.UI.Page
{
    private const int PageSize = 10;

    protected void Page_Load(object sender, EventArgs e)
    {
        HengTuo.PageValidation.Sqlzy(this);
        Pager_Backstage1.RefreshData = Bind;
        if (!IsPostBack)
        {
            string keyword = Request.QueryString["keyword"];
            if (!string.IsNullOrEmpty(keyword))
            {
                txtKeyword.Text = keyword;
            }
            Pager_Backstage1.PageIndex = 1;
            Pager_Backstage1.iEindex = PageSize;
            Bind();
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Pager_Backstage1.PageIndex = 1;
        Pager_Backstage1.iEindex = PageSize;
        Bind();
    }

    private void Bind()
    {
        string keyword = txtKeyword.Text.Trim();
        if (string.IsNullOrEmpty(keyword))
        {
            rptResult.DataSource = null;
            rptResult.DataBind();
            return;
        }

        Pager_Backstage1.PageSize = PageSize;
        string strWhere = " ArticleClassId=4 AND (EN_Title LIKE '%" + keyword.Replace("'", "''") + "%' OR EN_Summary LIKE '%" + keyword.Replace("'", "''") + "%')";

        NetWise.DataAccess.Article dal = new NetWise.DataAccess.Article();
        Pager_Backstage1.SetPageNum = dal.GetRecordCount(strWhere);
        rptResult.DataSource = dal.GetListByPage(strWhere, "CreateTime desc", Pager_Backstage1.iSindex, Pager_Backstage1.iEindex);
        rptResult.DataBind();
    }
}
