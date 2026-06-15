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
using System.Collections.Generic;

public partial class admin_product_new_ProductClass : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Bind();
        }
    }
    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        Bind();
    }
    private void Bind()
    {
        DataTable dt = new NetWise.DataAccess.PartsClass().GetPartsClassSort("1").Tables[0];

        PagedDataSource pds = new PagedDataSource();
        AspNetPager1.RecordCount = dt.Rows.Count;
        pds.DataSource = dt.DefaultView;
        pds.AllowPaging = true;
        pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
        pds.PageSize = AspNetPager1.PageSize;
        rpt_list.DataSource = pds;
        rpt_list.DataBind();
    }

    public void AddNodes(string parentId, List<NetWise.Entity.PartsClass> list, ref DataTable dt)
    {
        List<NetWise.Entity.PartsClass> currList = list.Where(a => a.ParentId == parentId).ToList();
        if (currList.Count > 0)
        {
            foreach (NetWise.Entity.PartsClass k in currList)
            {
                //添加行数据 
                DataRow row = dt.NewRow();
                row["ID"] = k.ID;
                row["CN_Name"] = k.CN_Name;
                row["ParentId"] = k.ParentId;
                row["IndexShow"] = k.IndexShow;
                row["Sort"] = k.Sort;
                row["Depth"] = k.Depth;
                dt.Rows.Add(row);
                AddNodes(k.ID.ToString(), list, ref dt);
            }
        }
    }

    protected void rpt_list_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Image imgIndexShow = e.Item.FindControl("imgIndexShow") as Image;
        if (imgIndexShow.ToolTip == "True")
        {
            imgIndexShow.ImageUrl = "/images/ico/ok.gif";
        }
        else
        {
            imgIndexShow.Visible = false;
        }

        Label lblNum = e.Item.FindControl("lblNum") as Label;
        lblNum.Text = new NetWise.DataAccess.PartsClass().GetNumByID(Convert.ToInt32(lblNum.Text)).ToString();

    }

    protected void rpt_list_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Del")
        {
            if (new NetWise.DataAccess.PartsClass().Delete(Convert.ToInt32(e.CommandArgument)))
            {
                NetWise.DBUtility.JsControl.Show(this, "删除记录成功!", "ProductClass.aspx");
            }
        }
    }

    protected void btnDo_Click(object sender, EventArgs e)
    {
        if ("1" == ddlSelect.SelectedValue && rpt_list.Items.Count > 0)
        {
            bool needRefresh = false;
            for (int i = 0; i < rpt_list.Items.Count; i++)
            {
                CheckBox chkObj = (CheckBox)rpt_list.Items[i].FindControl("ckbSelect");
                HiddenField hfID = (HiddenField)rpt_list.Items[i].FindControl("hfID");
                if (chkObj.Checked == true)
                {
                    new NetWise.DataAccess.PartsClass().UpdateShowByID(Convert.ToInt32(hfID.Value));
                    needRefresh = true;
                }
            }
            if (needRefresh)
            {
                NetWise.DBUtility.JsControl.Show(this, "批量操作成功！", "ProductClass.aspx");
            }
            else
            {
                NetWise.DBUtility.JsControl.Show(this, "请先选择！");
            }
        }
        else if ("2" == ddlSelect.SelectedValue && rpt_list.Items.Count > 0)
        {
            //do;
        }
        else
        {
            NetWise.DBUtility.JsControl.Show(this, "请先选择！");
        }
    }
}
