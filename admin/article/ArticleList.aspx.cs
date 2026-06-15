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

public partial class admin_Article_ArticleList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //List<NetWise.Entity.ArticleClass> list = new NetWise.DataAccess.ArticleClass().ListArticleClass(string.Empty);
            //if (list != null && list.Count > 0)
            //{
            //    AddTypeChildNodes("0", list, "|---", ddlArticleClass);
            //}
            DataSet ds = new NetWise.DataAccess.ArticleClass().GetArticleClassSort();
            if (null != ds && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    ddlArticleClass.Items.Add(new ListItem(ds.Tables[0].Rows[i]["CN_Name"].ToString(),
                        ds.Tables[0].Rows[i]["ID"].ToString()));
                }
            }

            Bind();
        }

    }
    private void AddTypeChildNodes(string parentId, List<NetWise.Entity.ArticleClass> list, string strDistance, DropDownList ddl)
    {
        List<NetWise.Entity.ArticleClass> currList = list.Where(a => a.ParentId == parentId).ToList();
        if (currList.Count > 0)
        {
            foreach (NetWise.Entity.ArticleClass k in currList)
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
        if ("0" != ddlArticleClass.SelectedValue)
        {
            strWhere += " and ArticleClassId='" + ddlArticleClass.SelectedValue + "' ";
        }
        string filedOrder = "CreateTime desc";

        DataTable dt = new NetWise.DataAccess.Article().GetList(0,strWhere,filedOrder).Tables[0];

        PagedDataSource pds = new PagedDataSource();
        AspNetPager1.RecordCount = dt.Rows.Count;
        pds.DataSource = dt.DefaultView;
        pds.AllowPaging = true;
        pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
        pds.PageSize = AspNetPager1.PageSize;
        rptArticleList.DataSource = pds;
        rptArticleList.DataBind();
    }
    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        Bind();
    }

    protected void rptArticleList_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Del")
        {
            if (new NetWise.DataAccess.Article().Delete(Convert.ToInt32(e.CommandArgument)))
            {
                NetWise.DBUtility.JsControl.Show(this, "删除记录成功!", "ArticleList.aspx");
            }
        }
    }

    protected void rptArticleList_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Label lblArticleClass = e.Item.FindControl("lblArticleClass") as Label;
        NetWise.Entity.ArticleClass model = new NetWise.DataAccess.ArticleClass().GetModel(Convert.ToInt32(lblArticleClass.Text));
        if (null != model)
        {
            lblArticleClass.Text = model.CN_Name;
        }
    }

    protected void btnDelAll_Click(object sender, EventArgs e)
    {
        if ("1" == ddlSelect.SelectedValue && rptArticleList.Items.Count > 0)
        {
            bool needRefresh = false;
            for (int i = 0; i < rptArticleList.Items.Count; i++)
            {
                CheckBox chkObj = (CheckBox) rptArticleList.Items[i].FindControl("ckbSelect");
                HiddenField hfID = (HiddenField) rptArticleList.Items[i].FindControl("hfID");
                if (chkObj.Checked == true)
                {
                    new NetWise.DataAccess.Article().Delete(Convert.ToInt32(hfID.Value));
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

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Bind();
    }

}
