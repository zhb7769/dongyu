using System;
using System.Data;
using System.Web.UI;
using NetWise.DataAccess;

public partial class Equipment : System.Web.UI.Page
{
    private const int ProcessClassId = 7;
    private const int EquipClassId = 6;

    protected void Page_Load(object sender, EventArgs e)
    {
        HengTuo.PageValidation.Sqlzy(this);
        if (!IsPostBack)
        {
            BindProcess();
            BindEquipment();
        }
    }

    private void BindProcess()
    {
        NetWise.DataAccess.ArticleClass classDal = new NetWise.DataAccess.ArticleClass();
        NetWise.Entity.ArticleClass classModel = classDal.GetModel(ProcessClassId);
        if (classModel != null)
        {
            ltProcessTitle.Text = classModel.CN_Name;
        }

        NetWise.DataAccess.Article dal = new NetWise.DataAccess.Article();
        NetWise.Entity.Article model = dal.GetModelByClassID(ProcessClassId);
        if (model != null)
        {
            ltProcessContent.Text = model.CN_Content;
        }
    }

    private void BindEquipment()
    {
        NetWise.DataAccess.ArticleClass classDal = new NetWise.DataAccess.ArticleClass();
        NetWise.Entity.ArticleClass classModel = classDal.GetModel(EquipClassId);
        if (classModel != null)
        {
            ltEquipTitle.Text = classModel.CN_Name;
        }

        NetWise.DataAccess.Article dal = new NetWise.DataAccess.Article();
        DataSet ds = dal.GetList(0, " and ArticleClassId=" + EquipClassId, "Sort asc");
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            rptEquipment.DataSource = ds;
            rptEquipment.DataBind();
        }
    }
}
