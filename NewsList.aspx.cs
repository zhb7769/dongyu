using System;
using System.Data;
using System.Web.UI;
using NetWise.DataAccess;

public partial class NewsList : System.Web.UI.Page
{
    private const int PageSize = 10;
    private const int NewsClassId = 1;

    protected void Page_Load(object sender, EventArgs e)
    {
        HengTuo.PageValidation.Sqlzy(this);
        Pager_Backstage1.RefreshData = Bind;
        if (!IsPostBack)
        {
            BindTitle();
            Pager_Backstage1.PageIndex = 1;
            Pager_Backstage1.iEindex = PageSize;
            Bind();
        }
    }

    private void BindTitle()
    {
        NetWise.DataAccess.NewsClass dal = new NetWise.DataAccess.NewsClass();
        NetWise.Entity.NewsClass model = dal.GetModel(NewsClassId);
        if (model != null)
        {
            ltBanTitle.Text = model.CN_Name;
            ltNavTitle.Text = model.CN_Name;
        }
    }

    private void Bind()
    {
        Pager_Backstage1.PageSize = PageSize;
        string strWhere = " NewsClassId=" + NewsClassId;
        NetWise.DataAccess.News dal = new NetWise.DataAccess.News();
        Pager_Backstage1.SetPageNum = dal.GetRecordCount(strWhere);
        rptNews.DataSource = dal.GetListByPage(strWhere, "IsTop desc,Sort asc,CreateTime desc", Pager_Backstage1.iSindex, Pager_Backstage1.iEindex);
        rptNews.DataBind();
    }
}
