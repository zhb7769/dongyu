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

public partial class admin_product_Products : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataSet ds = new NetWise.DataAccess.ProductClass().GetProductClassSort(string.Empty);
            if (null != ds && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    ddlProductClass.Items.Add(new ListItem(ds.Tables[0].Rows[i]["CN_Name"].ToString(),
                        ds.Tables[0].Rows[i]["ID"].ToString()));
                }
            }
            //List<NetWise.Entity.ProductClass> list = new NetWise.DataAccess.ProductClass().GetList();
            //if (list != null && list.Count > 0)
            //{
            //    AddTypeChildNodes("0", list, "|---", ddlProductClass);
            //}

            Bind();

        }
    }
    private void AddTypeChildNodes(string parentId, List<NetWise.Entity.ProductClass> list, string strDistance, DropDownList ddl)
    {
        List<NetWise.Entity.ProductClass> currList = list.Where(a => a.ParentId == parentId).ToList();
        if (currList.Count > 0)
        {
            foreach (NetWise.Entity.ProductClass k in currList)
            {
                ddl.Items.Add(new ListItem(strDistance + k.CN_Name, k.ID.ToString()));

                AddTypeChildNodes(k.ID.ToString(), list, strDistance + "---", ddl);
            }
        }
    }
    private void Bind()
    {
        string strWhere = "";

        if (!string.IsNullOrEmpty(txtKeyWords.Text))
        {
            strWhere += @" and CN_Label like '%" + txtKeyWords.Text + "%' or CN_Label like '%" + txtKeyWords.Text + "%'";
        }
        if ("0" != ddlProductClass.SelectedValue)
        {
            strWhere += " and ClassId='" + ddlProductClass.SelectedValue + "' ";
        }
        string filedOrder = "IsPage desc,Sort,CreateTime desc";

        DataTable dt = new NetWise.DataAccess.Product().GetList(0, strWhere, filedOrder).Tables[0];

        PagedDataSource pds = new PagedDataSource();
        AspNetPager1.RecordCount = dt.Rows.Count;
        pds.DataSource = dt.DefaultView;
        pds.AllowPaging = true;
        pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
        pds.PageSize = AspNetPager1.PageSize;
        rptProducts.DataSource = pds;
        rptProducts.DataBind();
    }
    
    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        Bind();
    }
    protected void rptProducts_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Label lblProductClass = e.Item.FindControl("lblProductClass") as Label;
        NetWise.Entity.ProductClass model = new NetWise.DataAccess.ProductClass().GetModel(Convert.ToInt32(lblProductClass.Text));
        if (null != model)
        {
            lblProductClass.Text = model.CN_Name;
        }

        Image imgIsTop = e.Item.FindControl("imgIsTop") as Image;
        if (imgIsTop.ToolTip == "True")
        {
            imgIsTop.ImageUrl = "../images/ico/ok.gif";
        }
        else
            imgIsTop.Visible = false;
    }
    protected void rptProducts_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Del")
        {
            if (new NetWise.DataAccess.Product().Delete(Convert.ToInt32(e.CommandArgument)))
            {
                NetWise.DBUtility.JsControl.Show(this, "删除记录成功!", "Products.aspx");
            }
        }
        if (e.CommandName == "Sort")
        {
            TextBox txtSort = e.Item.FindControl("txtSort") as TextBox;
            if (new NetWise.DataAccess.Product().UpdateProductForSort(Convert.ToInt32(txtSort.Text), Convert.ToInt32(e.CommandArgument)))
            {
                NetWise.DBUtility.JsControl.Show(this, "更新记录成功!", "Products.aspx");
            }
        }
    }
    protected void btnDelAll_Click(object sender, EventArgs e)
    {
        if ("1" == ddlSelect.SelectedValue && rptProducts.Items.Count > 0)
        {
            bool needRefresh = false;
            for (int i = 0; i < rptProducts.Items.Count; i++)
            {
                CheckBox chkObj = (CheckBox)rptProducts.Items[i].FindControl("ckbSelect");
                HiddenField hfID = (HiddenField)rptProducts.Items[i].FindControl("hfID");
                if (chkObj.Checked == true)
                {
                    new NetWise.DataAccess.Product().Delete(Convert.ToInt32(hfID.Value));
                    needRefresh = true;
                }
            }
            if (needRefresh)
            {
                NetWise.DBUtility.JsControl.Show(this, "删除成功！", "Products.aspx");
            }
            else
            {
                NetWise.DBUtility.JsControl.Show(this, "请先选择！");
            }
        }
        else if ("2" == ddlSelect.SelectedValue && rptProducts.Items.Count > 0)
        {
            //do;
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
