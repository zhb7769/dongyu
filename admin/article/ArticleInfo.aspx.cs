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
using System.IO;
using NetWise.DBUtility;

public partial class admin_Article_ArticleInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtCreateTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
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
                    NetWise.Entity.Article model = new NetWise.DataAccess.Article().GetModel(C_id);
                    if (null != model)
                    {
                        ddlArticleClass.SelectedValue = model.ArticleClassId.ToString();
                        txtCN_Title.Text = model.CN_Title;
                        txtEN_Title.Text = model.EN_Title;
                        txtSort.Text = model.Sort.ToString();
                        txtCN_KeyWords.Text = model.CN_KeyWords;
                        txtEN_KeyWords.Text = model.EN_KeyWords;
                        txtPic_Url.Text = model.Pic_Url;
                        if (string.Empty != model.Pic_Url)
                        {
                            imgPic_Url.ImageUrl = "../../uploadfiles/article/" + model.Pic_Url;
                        }
                        txtCN_Summary.Text = model.CN_Summary;
                        txtEN_Summary.Text = model.EN_Summary;
                        FCKeditor1.Value = model.CN_Content;
                        FCKeditor2.Value = model.EN_Content;
                        txtCreateTime.Text = model.CreateTime.ToString("yyyy-MM-dd HH:mm:ss");
                    }

                }
            }
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

    protected void btnPic_Url_Click(object sender, EventArgs e)
    {
        lblMsg.Text = string.Empty;
        if (!(FileUpload1.HasFile))
        {
            lblMsg.Text += "请至少选择一张商品图片！ <br />";
        }
        if (FileUpload1.HasFile)
        {
            if (FileUpload1.PostedFile.ContentType.ToString().ToLower().IndexOf("image") == -1)
            {
                lblMsg.Text += "图片格式不正确！<br />";
            }
            if (FileUpload1.FileContent.Length / 1024 > 4096)
            {
                lblMsg.Text += "上传文件大小限制为 4MB ！<br />";
            }
        }
        if (string.Empty != lblMsg.Text)
        {
            return;
        }
        //检测一下uploadFile是否选择了上传文件
        if (FileUpload1.HasFile)
        {
            //检测目录是否存在
            if (!Directory.Exists(HttpContext.Current.Request.PhysicalApplicationPath + "uploadfiles//article"))
            {
                Directory.CreateDirectory(HttpContext.Current.Request.PhysicalApplicationPath + "uploadfiles//article");
            }
            string SavePath = Server.MapPath("../../uploadfiles/article/");
            string extension = Path.GetExtension(FileUpload1.PostedFile.FileName);
            string FileName = StringMethodControl.RadomFileName() + extension;
            string path = SavePath + FileName;
            FileUpload1.PostedFile.SaveAs(path);

            imgPic_Url.ImageUrl = "../../uploadfiles/article/" + FileName;
            txtPic_Url.Text = FileName;
        }

    }

    protected void btnOk_Click(object sender, EventArgs e)
    {
        int Sort = 0;
        NetWise.Entity.Article article = new NetWise.Entity.Article();
        article.ArticleClassId = Convert.ToInt32(ddlArticleClass.SelectedValue);
        article.CN_Title = txtCN_Title.Text;
        article.EN_Title = txtEN_Title.Text;
        Int32.TryParse(txtSort.Text, out Sort);
        article.Sort = Sort;
        article.CN_KeyWords = txtCN_KeyWords.Text;
        article.EN_KeyWords = txtEN_KeyWords.Text;
        article.Pic_Url = txtPic_Url.Text;
        article.CN_Summary = txtCN_Summary.Text;
        article.EN_Summary = txtEN_Summary.Text;
        article.CN_Content = FCKeditor1.Value;
        article.EN_Content = FCKeditor2.Value;
        article.CreateTime = Convert.ToDateTime(txtCreateTime.Text);
        article.Remark = string.Empty;

        if (null != Request["C_id"] && string.Empty != Request["C_id"].ToString())
        {
            int C_id = 0;
            if (Int32.TryParse(Request["C_id"].ToString(), out C_id))
            {
                article.ID = C_id;
                if (new NetWise.DataAccess.Article().Update(article))
                {
                    NetWise.DBUtility.JsControl.Show(this, "更新记录成功!", "ArticleList.aspx");
                }
                else
                {
                    NetWise.DBUtility.JsControl.Show(this, "更新记录失败!");
                }
            }
            
        }
        else
        {
            if (new NetWise.DataAccess.Article().Add(article) > 0)
            {
                NetWise.DBUtility.JsControl.Show(this, "添加记录成功!", "ArticleList.aspx");
            }
            else
            {
                NetWise.DBUtility.JsControl.Show(this, "添加记录失败!");
            }
        }
    }
}
