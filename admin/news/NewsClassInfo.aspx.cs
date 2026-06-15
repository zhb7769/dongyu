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

public partial class admin_news_NewsClassInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataSet ds = new NetWise.DataAccess.NewsClass().GetNewsClassSort();
            if (null != ds && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    ddlNewsClass.Items.Add(new ListItem(ds.Tables[0].Rows[i]["CN_Name"].ToString(),
                        ds.Tables[0].Rows[i]["ID"].ToString()));
                }
            }
            //List<NetWise.Entity.NewsClass> list = new NetWise.DataAccess.NewsClass().ListNewsClass(string.Empty);
            //if (list != null && list.Count > 0)
            //{
            //    AddTypeChildNodes("0", list, "|---", ddlNewsClass);
            //}

            if (null != Request["C_id"] && string.Empty != Request["C_id"].ToString())
            {
                int C_id = 0;
                if (Int32.TryParse(Request["C_id"].ToString(), out C_id))
                {
                    NetWise.Entity.NewsClass model = new NetWise.DataAccess.NewsClass().GetModel(C_id);
                    if (null != model)
                    {
                        txtCN_Name.Text = model.CN_Name;
                        txtEN_Name.Text = model.EN_Name;
                        ddlNewsClass.SelectedValue = model.ParentId;
                        txtSort.Text = model.Sort.ToString();
                        ckbIsShow.Checked = model.IsShow;
                    }
                }
            }
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
    
    protected void btnOk_Click(object sender, EventArgs e)
    {
        int Sort = 0;
        NetWise.Entity.NewsClass model = new NetWise.Entity.NewsClass();
        model.CN_Name = txtCN_Name.Text;
        model.EN_Name = txtEN_Name.Text;
        model.ParentId = ddlNewsClass.SelectedValue;
        Int32.TryParse(txtSort.Text.ToString(), out Sort);
        model.Sort = Sort;
        model.IsShow = ckbIsShow.Checked;
        object obj = new NetWise.DataAccess.NewsClass().GetDepthByID(Convert.ToInt32(ddlNewsClass.SelectedValue));
        if (obj != null)
        {
            model.Depth = Convert.ToInt32(obj) + 1;
        }
        else
        {
            model.Depth = Convert.ToInt32(ddlNewsClass.SelectedValue);
        }
        model.CN_Url = string.Empty;
        model.EN_Url = string.Empty;
        model.Remark = string.Empty;

        if (null != Request["C_id"] && string.Empty != Request["C_id"].ToString())
        {
            int C_id = 0;
            if (Int32.TryParse(Request["C_id"].ToString(), out C_id))
            {
                model.ID = C_id;
                NetWise.Entity.NewsClass newsClass = new NetWise.DataAccess.NewsClass().GetModel(Convert.ToInt32(ddlNewsClass.SelectedValue));
                if (Convert.ToInt32(ddlNewsClass.SelectedValue) == C_id || (newsClass != null && newsClass.ParentId == C_id.ToString()))
                {
                    NetWise.DBUtility.JsControl.Show(this, "所选的上级分类不能是当前分类或者当前分类的下级分类!");
                }
                else
                {
                    if (new NetWise.DataAccess.NewsClass().Update(model))
                    {
                        NetWise.DBUtility.JsControl.Show(this, "更新记录成功!", "NewsClass.aspx");
                    }
                    else
                    {
                        NetWise.DBUtility.JsControl.Show(this, "更新记录失败!");
                    }
                }
            }
        }
        else
        {
            if (new NetWise.DataAccess.NewsClass().Add(model) > 0)
            {
                NetWise.DBUtility.JsControl.Show(this, "添加记录成功!", "NewsClass.aspx");
            }
            else
            {
                NetWise.DBUtility.JsControl.Show(this, "添加记录失败!");
            }
        }
    }

}
