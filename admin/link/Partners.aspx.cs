using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class admin_link_Partners : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Bind();
        }
    }
    protected void rptLink_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Del")
        {
            if (new NetWise.DataAccess.Link().Delete(Convert.ToInt32(e.CommandArgument.ToString())))
            {
                NetWise.DBUtility.JsControl.Show(this, "删除记录成功!", "Partners.aspx");
            }
        }
        if (e.CommandName == "Sort")
        {
            TextBox txtSort = e.Item.FindControl("txtSort") as TextBox;
            if (new NetWise.DataAccess.Link().UpdateLinkBySort(Convert.ToInt32(txtSort.Text), Convert.ToInt32(e.CommandArgument.ToString())))
            {
                NetWise.DBUtility.JsControl.Show(this, "更新记录成功!", "Partners.aspx");
            }
        }

    }
    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        Bind();
    }
    private void Bind()
    {
        DataTable dt = new NetWise.DataAccess.Link().GetList(" LinkType = 2 ").Tables[0];

        PagedDataSource pds = new PagedDataSource();
        this.AspNetPager1.RecordCount = dt.Rows.Count;
        pds.DataSource = dt.DefaultView;
        pds.AllowPaging = true;
        pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
        pds.PageSize = AspNetPager1.PageSize;
        rptLink.DataSource = pds;
        rptLink.DataBind();
    }
    protected void btnDo_Click(object sender, EventArgs e)
    {
        if ("1" == ddlSelect.SelectedValue && rptLink.Items.Count > 0)
        {
            bool needRefresh = false;
            for (int i = 0; i < rptLink.Items.Count; i++)
            {
                CheckBox chkObj = (CheckBox)rptLink.Items[i].FindControl("cbDel");
                HiddenField hfID = (HiddenField)this.rptLink.Items[i].FindControl("hfID");
                if (chkObj.Checked == true)
                {
                    new NetWise.DataAccess.Link().Delete(Convert.ToInt32(hfID.Value));
                    needRefresh = true;
                }
            }
            if (needRefresh)
            {
                NetWise.DBUtility.JsControl.Show(this, "删除成功！");
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
}
