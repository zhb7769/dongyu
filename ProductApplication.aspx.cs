using System;
using System.Data;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using NetWise.DataAccess;

public partial class ProductApplication : System.Web.UI.Page
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
            ltApplication.Text = classModel.CN_Application;
        }

        DataSet dsSub = new ProductClass().GetList(0, "ParentId='" + classId + "'", "Sort ASC");
        if (dsSub != null && dsSub.Tables[0].Rows.Count > 0)
        {
            rptSubCategory.DataSource = dsSub;
            rptSubCategory.DataBind();
            rptSubContent.DataSource = dsSub;
            rptSubContent.DataBind();
        }
    }

    protected void rptSubContent_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView drv = (DataRowView)e.Item.DataItem;
            int subClassId = Convert.ToInt32(drv["ID"]);

            Repeater rptProducts = (Repeater)e.Item.FindControl("rptProducts");

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT t1.CN_Name, t1.EN_Name, ");
            strSql.Append("(SELECT TOP 1 pro_img FROM pro_att_info t2 WHERE t1.P_Id = t2.pro_id ORDER BY at_id ASC) AS pro_img ");
            strSql.Append("FROM Product t1 ");
            strSql.Append("WHERE t1.ClassId = @ClassId ");
            strSql.Append("ORDER BY t1.Sort ASC");

            System.Data.SqlClient.SqlParameter[] parameters = {
                new System.Data.SqlClient.SqlParameter("@ClassId", System.Data.SqlDbType.Int)
            };
            parameters[0].Value = subClassId;

            DataSet ds = NetWise.DBUtility.DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                rptProducts.DataSource = ds;
                rptProducts.DataBind();
            }
        }
    }

    protected void rptSubCategory_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
    }
}
