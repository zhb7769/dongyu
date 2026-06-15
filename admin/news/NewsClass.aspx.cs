using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class admin_news_NewsClass : System.Web.UI.Page
{
   protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.rpt_list.DataSource = new NetWise.DataAccess.NewsClass().GetNewsClassSort();
            this.rpt_list.DataBind();
        }
    }
    protected void rpt_list_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Del")
        {
            if (new NetWise.DataAccess.NewsClass().Delete(Convert.ToInt32(e.CommandArgument)))
            {
                NetWise.DBUtility.JsControl.Show(this, "删除记录成功!", "NewsClass.aspx");
            }
        }
    }
    protected void rpt_list_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Label lblNum = e.Item.FindControl("lblNum") as Label;
        lblNum.Text = new NetWise.DataAccess.NewsClass().GetNumByID(Convert.ToInt32(lblNum.Text)).ToString();
    }



    private DataTable GetData()
    {
        DataTable dt = new DataTable();
        DataColumn dc = new DataColumn("id");
        dt.Columns.Add(dc);
        dc = new DataColumn("deep");
        dt.Columns.Add(dc);
        dc = new DataColumn("name");
        dt.Columns.Add(dc);
        dc = new DataColumn("count");
        dt.Columns.Add(dc);
        dc = new DataColumn("sort");
        dt.Columns.Add(dc);

        DataRow dr;
        for (int i = 0; i < 3; i++)
        {
            dr = dt.NewRow();
            dr["id"] = i;
            dr["deep"] = i;
            dr["count"] = i;
            dr["name"] = "分类" + i;
            dr["sort"] = 0;
            dt.Rows.Add(dr);
        }

        return dt;
    }

}
