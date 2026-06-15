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
using System.Collections.Generic;
using System.IO;

public partial class admin_Article_ArticleClassInfo : System.Web.UI.Page
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

            if (null != Request["C_id"] && string.Empty != Request["C_id"].ToString())
            {
                int C_id = 0;
                if (Int32.TryParse(Request["C_id"].ToString(), out C_id))
                {
                    NetWise.Entity.ArticleClass model = new NetWise.DataAccess.ArticleClass().GetModel(C_id);
                    if (null != model)
                    {
                        txtCN_Name.Text = model.CN_Name;
                        txtEN_Name.Text = model.EN_Name;
                        ddlArticleClass.SelectedValue = model.ParentId;
                        txtSort.Text = model.Sort.ToString();
                        txtC_Pic.Text = model.CN_Url;
                        if (string.Empty != model.CN_Url)
                        {
                            imgC_Pic.ImageUrl = "../../uploadfiles/articleClass/" + model.CN_Url;
                        } 
                        ckbIsShow.Checked = model.IsShow;
                    }
                }
            }
        }
    }
    private void AddTypeChildNodes(string parentId, List<NetWise.Entity.ArticleClass> list, string strDistance, DropDownList ddl)
    {
        //List<NetWise.Entity.ArticleClass> currList = list.Where(a => a.ParentId == parentId).ToList();
        //if (currList.Count > 0)
        //{
        //    foreach (NetWise.Entity.ArticleClass k in currList)
        //    {
        //        ddl.Items.Add(new ListItem(strDistance + k.CN_Name, k.ID.ToString()));

        //        AddTypeChildNodes(k.ID.ToString(), list, strDistance + "---", ddl);
        //    }
        //}
    }
    protected void btnC_Pic_Click(object sender, EventArgs e)
    {
        lblMessage.Text = string.Empty;
        if (!(fuC_Pic.HasFile))
        {
            lblMessage.Text += "请至少选择一张类别图片！ <br />";
        }
        if (fuC_Pic.HasFile)
        {
            if (fuC_Pic.PostedFile.ContentType.ToString().ToLower().IndexOf("image") == -1)
            {
                lblMessage.Text += "图片格式不正确！<br />";
            }
            if (fuC_Pic.FileContent.Length / 1024 > 4096)
            {
                lblMessage.Text += "上传文件大小限制为 4MB ！<br />";
            }
        }
        if (string.Empty != lblMessage.Text)
        {
            return;
        }
        //检测一下uploadFile是否选择了上传文件
        if (fuC_Pic.HasFile)
        {
            //检测目录是否存在
            if (!Directory.Exists(HttpContext.Current.Request.PhysicalApplicationPath + "uploadfiles//articleClass"))
            {
                Directory.CreateDirectory(HttpContext.Current.Request.PhysicalApplicationPath + "uploadfiles//articleClass");
            }
            string SavePath = Server.MapPath("../../uploadfiles/articleClass/");
            string extension = Path.GetExtension(fuC_Pic.PostedFile.FileName);
            string FileName = NetWise.DBUtility.StringMethodControl.RadomFileName() + extension;
            string path = SavePath + FileName;
            fuC_Pic.PostedFile.SaveAs(path);

            imgC_Pic.ImageUrl = "../../uploadfiles/articleClass/" + FileName;
            txtC_Pic.Text = FileName;
        }
    }
    protected void btnOk_Click(object sender, EventArgs e)
    {
        int Sort = 0;
        NetWise.Entity.ArticleClass model = new NetWise.Entity.ArticleClass();
        model.CN_Name = txtCN_Name.Text;
        model.EN_Name = txtEN_Name.Text;
        model.ParentId = ddlArticleClass.SelectedValue;
        Int32.TryParse(txtSort.Text.ToString(), out Sort);
        model.Sort = Sort;
        model.IsShow = ckbIsShow.Checked;
        object obj = new NetWise.DataAccess.ArticleClass().GetDepthByID(Convert.ToInt32(ddlArticleClass.SelectedValue));
        if (obj != null)
        {
            model.Depth = Convert.ToInt32(obj) + 1;
        }
        else
        {
            model.Depth = Convert.ToInt32(ddlArticleClass.SelectedValue);
        }
        model.CN_Url = txtC_Pic.Text;
        model.EN_Url = string.Empty;
        model.Remark = string.Empty;

        if (null != Request["C_id"] && string.Empty != Request["C_id"].ToString())
        {
            int C_id = 0;
            if (Int32.TryParse(Request["C_id"].ToString(), out C_id))
            {
                model.ID = C_id;
                NetWise.Entity.ArticleClass articleClass = new NetWise.DataAccess.ArticleClass().GetModel(Convert.ToInt32(ddlArticleClass.SelectedValue));
                if (Convert.ToInt32(ddlArticleClass.SelectedValue) == C_id || (articleClass != null && articleClass.ParentId == C_id.ToString()))
                {
                    NetWise.DBUtility.JsControl.Show(this, "所选的上级分类不能是当前分类或者当前分类的下级分类!");
                }
                else
                {
                    if (new NetWise.DataAccess.ArticleClass().Update(model))
                    {
                        NetWise.DBUtility.JsControl.Show(this, "更新记录成功!", "ArticleClassList.aspx");
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
            if (new NetWise.DataAccess.ArticleClass().Add(model) > 0)
            {
                NetWise.DBUtility.JsControl.Show(this, "添加记录成功!", "ArticleClassList.aspx");
            }
            else
            {
                NetWise.DBUtility.JsControl.Show(this, "添加记录失败!");
            }
        }
    }
}
