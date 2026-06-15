using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class admin_annex_Annex : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Bind();
        }
    }
    protected void AspNetPager1_PageChanging(object sender, EventArgs e)
    {
        Bind();
    }
    private void Bind()
    {
        DataTable dt = new NetWise.DataAccess.Download().GetList(" 1=1 order by sort asc").Tables[0];

        PagedDataSource pds = new PagedDataSource();
        this.AspNetPager1.RecordCount = dt.Rows.Count;
        pds.DataSource = dt.DefaultView;
        pds.AllowPaging = true;
        pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
        pds.PageSize = AspNetPager1.PageSize;
        rptAnnex.DataSource = pds;
        rptAnnex.DataBind();
    }
    protected void btnDo_Click(object sender, EventArgs e)
    {
        if ("1" == ddlSelect.SelectedValue && rptAnnex.Items.Count > 0)
        {
            bool needRefresh = false;
            for (int i = 0; i < rptAnnex.Items.Count; i++)
            {
                CheckBox chkObj = (CheckBox)rptAnnex.Items[i].FindControl("cbDel");
                HiddenField hfID = (HiddenField)this.rptAnnex.Items[i].FindControl("hfID");
                if (chkObj.Checked == true)
                {
                    new NetWise.DataAccess.Download().Delete(Convert.ToInt32(hfID.Value));
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
    protected void rptAnnex_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Del")
        {
            if (new NetWise.DataAccess.Download().Delete(Convert.ToInt32(e.CommandArgument.ToString())))
            {
                NetWise.DBUtility.JsControl.Show(this, "删除记录成功!", "Annex.aspx");
            }
        }
        if (e.CommandName == "Sort")
        {
            TextBox txtSort = e.Item.FindControl("txtSort") as TextBox;
            if (new NetWise.DataAccess.Download().UpdateDownloadBySort(Convert.ToInt32(txtSort.Text), Convert.ToInt32(e.CommandArgument.ToString())))
            {
                NetWise.DBUtility.JsControl.Show(this, "更新记录成功!", "Annex.aspx");
            }
        }
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void rptAnnex_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Label lblProductClass = e.Item.FindControl("lblProductClass") as Label;
        NetWise.Entity.DownloadClass model = new NetWise.DataAccess.DownloadClass().GetModel(Convert.ToInt32(lblProductClass.Text));
        if (null != model)
        {
            lblProductClass.Text = model.CN_Name;
        }
    }
}
