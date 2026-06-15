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

public partial class admin_project_Projects : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Bind();
        }
    }
    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        Bind();
    }
    private void Bind()
    {
        DataTable dt = new NetWise.DataAccess.Projects().GetList(string.Empty).Tables[0];

        PagedDataSource pds = new PagedDataSource();
        this.AspNetPager1.RecordCount = dt.Rows.Count;
        pds.DataSource = dt.DefaultView;
        pds.AllowPaging = true;
        pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
        pds.PageSize = AspNetPager1.PageSize;
        rptProject.DataSource = pds;
        rptProject.DataBind();
    }
    protected void btnDo_Click(object sender, EventArgs e)
    {
        if ("1" == ddlSelect.SelectedValue && rptProject.Items.Count > 0)
        {
            bool needRefresh = false;
            for (int i = 0; i < rptProject.Items.Count; i++)
            {
                CheckBox chkObj = (CheckBox)rptProject.Items[i].FindControl("cbDel");
                HiddenField hfID = (HiddenField)this.rptProject.Items[i].FindControl("hfID");
                if (chkObj.Checked == true)
                {
                    new NetWise.DataAccess.Projects().Delete(Convert.ToInt32(hfID.Value));
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
    protected void rptProject_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Del")
        {
            if (new NetWise.DataAccess.Projects().Delete(Convert.ToInt32(e.CommandArgument.ToString())))
            {
                NetWise.DBUtility.JsControl.Show(this, "删除记录成功!", "Projects.aspx");
            }
        }
        if (e.CommandName == "Sort")
        {
            TextBox txtSort = e.Item.FindControl("txtSort") as TextBox;
            if (new NetWise.DataAccess.Projects().UpdateProjectBySort(Convert.ToInt32(txtSort.Text), Convert.ToInt32(e.CommandArgument.ToString())))
            {
                NetWise.DBUtility.JsControl.Show(this, "更新记录成功!", "Projects.aspx");
            }
        }
    }
}
