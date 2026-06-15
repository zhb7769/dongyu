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

public partial class admin_news_News : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //List<NetWise.Entity.NewsClass> list = new NetWise.DataAccess.NewsClass().ListNewsClass(string.Empty);
            //if (list != null && list.Count > 0)
            //{
            //    AddTypeChildNodes("0", list, "|---", ddlNewsClass);
            //}
            DataSet ds = new NetWise.DataAccess.NewsClass().GetNewsClassSort();
            if (null != ds && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    ddlNewsClass.Items.Add(new ListItem(ds.Tables[0].Rows[i]["CN_Name"].ToString(),
                        ds.Tables[0].Rows[i]["ID"].ToString()));
                }
            }

            Bind();
        }

    }
    private void AddTypeChildNodes(string parentId, List<NetWise.Entity.NewsClass> list, string strDistance, DropDownList ddl)
    {
        List<NetWise.Entity.NewsClass> currList = list.Where(a => a.ParentId == parentId).ToList();
        if (currList.Count > 0)
        {
            foreach (NetWise.Entity.NewsClass k in currList)
            {
                ddl.Items.Add(new ListItem(strDistance + k.CN_Name, k.ID.ToString()));

                AddTypeChildNodes(k.ID.ToString(), list, strDistance + "---", ddl);
            }
        }
    }

    private void Bind()
    {
        string strWhere = string.Empty;

        if (!string.IsNullOrEmpty(txtKeyWords.Text))
        {
            strWhere += @" and CN_KeyWords like '%" + txtKeyWords.Text + "%' or EN_KeyWords like '%" + txtKeyWords.Text + "%'";
        }
        if ("0" != ddlNewsClass.SelectedValue)
        {
            strWhere += " and NewsClassId='" + ddlNewsClass.SelectedValue + "' ";
        }
        string filedOrder = "CreateTime desc";

        DataTable dt = new NetWise.DataAccess.News().GetList(0, strWhere, filedOrder).Tables[0];

        PagedDataSource pds = new PagedDataSource();
        AspNetPager1.RecordCount = dt.Rows.Count;
        pds.DataSource = dt.DefaultView;
        pds.AllowPaging = true;
        pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
        pds.PageSize = AspNetPager1.PageSize;
        rptNews.DataSource = pds;
        rptNews.DataBind();
    }

    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        Bind();
    }

    protected void rptNews_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Del")
        {
            if (new NetWise.DataAccess.News().Delete(Convert.ToInt32(e.CommandArgument)))
            {
                NetWise.DBUtility.JsControl.Show(this, "删除记录成功!", "News.aspx");
            }
        }
        if (e.CommandName == "Sort")
        {
            TextBox txtSort = e.Item.FindControl("txtSort") as TextBox;
            if (new NetWise.DataAccess.News().UpdateNewsForSort(Convert.ToInt32(txtSort.Text), Convert.ToInt32(e.CommandArgument)))
            {
                NetWise.DBUtility.JsControl.Show(this, "更新记录成功!", "News.aspx");
            }
        }
    }

    protected void rptNews_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Label lblNewsClass = e.Item.FindControl("lblNewsClass") as Label;
        NetWise.Entity.NewsClass model = new NetWise.DataAccess.NewsClass().GetModel(Convert.ToInt32(lblNewsClass.Text));
        if (null != model)
        {
            lblNewsClass.Text = model.CN_Name;
        }

        Image imgIsTop = e.Item.FindControl("imgIsTop") as Image;
        if (imgIsTop.ToolTip == "True")
        {
            imgIsTop.ImageUrl = "../images/ico/ok.gif";
        }
        else
            imgIsTop.Visible = false;
    }

    protected void btnDelAll_Click(object sender, EventArgs e)
    {
        if ("1" == ddlSelect.SelectedValue && rptNews.Items.Count > 0)
        {
            bool needRefresh = false;
            for (int i = 0; i < rptNews.Items.Count; i++)
            {
                CheckBox chkObj = (CheckBox)rptNews.Items[i].FindControl("ckbSelect");
                HiddenField hfID = (HiddenField)rptNews.Items[i].FindControl("hfID");
                if (chkObj.Checked == true)
                {
                    new NetWise.DataAccess.News().Delete(Convert.ToInt32(hfID.Value));
                    needRefresh = true;
                }
            }
            if (needRefresh)
            {
                NetWise.DBUtility.JsControl.Show(this, "批量删除成功！", "News.aspx");
            }
            else
            {
                NetWise.DBUtility.JsControl.Show(this, "请先选择！");
            }
        }
        else if ("2" == ddlSelect.SelectedValue && rptNews.Items.Count > 0)
        {
            bool needRefresh = false;
            for (int i = 0; i < rptNews.Items.Count; i++)
            {
                CheckBox chkObj = (CheckBox)rptNews.Items[i].FindControl("ckbSelect");
                HiddenField hfID = (HiddenField)rptNews.Items[i].FindControl("hfID");
                if (chkObj.Checked == true)
                {
                    new NetWise.DataAccess.News().UpdateTopByID(Convert.ToInt32(hfID.Value));
                    needRefresh = true;
                }
            }
            if (needRefresh)
            {
                NetWise.DBUtility.JsControl.Show(this, "批量置顶成功！", "News.aspx");
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
