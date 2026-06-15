using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web.UI.WebControls;
public partial class admin_ProductReg_ProductReg : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Bind();
        }
    }

    private void Bind()
    {
        string strWhere = string.Empty;
        string filedOrder = "PurchaseDate desc";
        DataTable dt = new NetWise.DataAccess.ProductRegister().GetListJoinEx(0, strWhere, filedOrder).Tables[0];

        PagedDataSource pds = new PagedDataSource();
        AspNetPager1.RecordCount = dt.Rows.Count;
        pds.DataSource = dt.DefaultView;
        pds.AllowPaging = true;
        pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
        pds.PageSize = AspNetPager1.PageSize;
        rptMsg.DataSource = pds;
        rptMsg.DataBind();
    }

    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        Bind();
    }

    protected void rptMsg_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Del")
        {
            if (new NetWise.DataAccess.ProductRegister().Delete(Convert.ToInt32(e.CommandArgument)))
            {
                NetWise.DBUtility.JsControl.Show(this, "删除记录成功!", "ProductReg.aspx");
            }
        }
    }

    protected void rptMsg_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        //Image imgIsRead = e.Item.FindControl("imgIsRead") as Image;
        //if (imgIsRead.ToolTip == "True")
        //{
        //    imgIsRead.Visible = false;
        //}
        //else
        //{
        //    imgIsRead.ImageUrl = "../images/newico.gif";
        //}

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
                    new NetWise.DataAccess.ProductRegister().Delete(Convert.ToInt32(hfID.Value));
                    needRefresh = true;
                }
            }
            if (needRefresh)
            {
                NetWise.DBUtility.JsControl.Show(this, "删除成功！", "ProductReg.aspx");
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
