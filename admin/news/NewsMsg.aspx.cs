using System;
using System.Data;
using System.Web.UI.WebControls;

public partial class admin_news_NewsMsg : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Bind();
        }

    }
    //private void AddTypeChildNodes(string parentId, List<NetWise.Entity.NewsClass> list, string strDistance, DropDownList ddl)
    //{
    //    List<NetWise.Entity.NewsClass> currList = list.Where(a => a.ParentId == parentId).ToList();
    //    if (currList.Count > 0)
    //    {
    //        foreach (NetWise.Entity.NewsClass k in currList)
    //        {
    //            ddl.Items.Add(new ListItem(strDistance + k.CN_Name, k.ID.ToString()));

    //            AddTypeChildNodes(k.ID.ToString(), list, strDistance + "---", ddl);
    //        }
    //    }
    //}

    private void Bind()
    {
        string strWhere = string.Empty;
        var id = Request.QueryString["id"];
        if (!string.IsNullOrEmpty(id))
        {
            strWhere += " NEWSID=" + id;
            string filedOrder = "CreateTime desc";
            DataTable dt = new NetWise.DataAccess.NewsMessage().GetList(0, strWhere, filedOrder).Tables[0];
            PagedDataSource pds = new PagedDataSource();
            AspNetPager1.RecordCount = dt.Rows.Count;
            pds.DataSource = dt.DefaultView;
            pds.AllowPaging = true;
            pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
            pds.PageSize = AspNetPager1.PageSize;
            rptMsg.DataSource = pds;
            rptMsg.DataBind();
        }
           
    }

    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        Bind();
    }

    protected void rptMsg_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Del")
        {
            if (new NetWise.DataAccess.NewsMessage().Delete(Convert.ToInt32(e.CommandArgument)))
            {
                NetWise.DBUtility.JsControl.Show(this, "删除记录成功!", Request.Url.ToString());
            }
        }
    }

    protected void rptNews_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        //Label lblNewsClass = e.Item.FindControl("lblNewsClass") as Label;
        //NetWise.Entity.NewsClass model = new NetWise.DataAccess.NewsClass().GetModel(Convert.ToInt32(lblNewsClass.Text));
        //if (null != model)
        //{
        //    lblNewsClass.Text = model.CN_Name;
        //}

        //Image imgIsTop = e.Item.FindControl("imgIsTop") as Image;
        //if (imgIsTop.ToolTip == "True")
        //{
        //    imgIsTop.ImageUrl = "../images/ico/ok.gif";
        //}
        //else
        //    imgIsTop.Visible = false;
    }

    protected void btnDelAll_Click(object sender, EventArgs e)
    {
        if ("1" == ddlSelect.SelectedValue && rptMsg.Items.Count > 0)
        {
            bool needRefresh = false;
            for (int i = 0; i < rptMsg.Items.Count; i++)
            {
                CheckBox chkObj = (CheckBox)rptMsg.Items[i].FindControl("ckbSelect");
                HiddenField hfID = (HiddenField)rptMsg.Items[i].FindControl("hfID");
                if (chkObj.Checked == true)
                {
                    new NetWise.DataAccess.NewsMessage().Delete(Convert.ToInt32(hfID.Value));
                    needRefresh = true;
                }
            }
            if (needRefresh)
            {
                NetWise.DBUtility.JsControl.Show(this, "批量删除成功！", "NewsMsg.aspx");
            }
            else
            {
                NetWise.DBUtility.JsControl.Show(this, "请先选择！");
            }
        }
        else
        {
            NetWise.DBUtility.JsControl.Show(this, "请先选择！");
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Bind();
    }

}
