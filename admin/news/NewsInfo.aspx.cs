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

public partial class admin_news_NewsInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtCreateTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
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

            if (null != Request["C_id"] && string.Empty != Request["C_id"].ToString())
            {
                int C_id = 0;
                if (Int32.TryParse(Request["C_id"].ToString(), out C_id))
                {
                    NetWise.Entity.News model = new NetWise.DataAccess.News().GetModel(C_id);
                    if (null != model)
                    {
                        ddlNewsClass.SelectedValue = model.NewsClassId.ToString();
                        txtCN_Title.Text = model.CN_Title;
                        txtEN_Title.Text = model.EN_Title;
                        txtSort.Text = model.Sort.ToString();
                        ckbIsTop.Checked = model.IsTop;
                        txtCN_KeyWords.Text = model.CN_KeyWords;
                        txtEN_KeyWords.Text = model.EN_KeyWords;
                        txtPic_Url.Text = model.Pic_Url;
                        if (string.Empty != model.Pic_Url)
                        {
                            imgPic_Url.ImageUrl = "../../uploadfiles/news/" + model.Pic_Url;
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
            if (!Directory.Exists(HttpContext.Current.Request.PhysicalApplicationPath + "uploadfiles//news"))
            {
                Directory.CreateDirectory(HttpContext.Current.Request.PhysicalApplicationPath + "uploadfiles//news");
            }
            string SavePath = Server.MapPath("../../uploadfiles/news/");
            string extension = Path.GetExtension(FileUpload1.PostedFile.FileName);
            string FileName = NetWise.DBUtility.StringMethodControl.RadomFileName() + extension;
            string path = SavePath + FileName;
            FileUpload1.PostedFile.SaveAs(path);

            imgPic_Url.ImageUrl = "../../uploadfiles/news/" + FileName;
            txtPic_Url.Text = FileName;
        }

    }

    protected void btnOk_Click(object sender, EventArgs e)
    {
        int Sort = 0;
        NetWise.Entity.News model = new NetWise.Entity.News();
        model.NewsClassId = Convert.ToInt32(ddlNewsClass.SelectedValue);
        model.CN_Title = txtCN_Title.Text;
        model.EN_Title = txtEN_Title.Text;
        Int32.TryParse(txtSort.Text, out Sort);
        model.Sort = Sort;
        if (ckbIsTop.Checked)
            model.IsTop = true;
        else
            model.IsTop = false;
        model.CN_KeyWords = txtCN_KeyWords.Text;
        model.EN_KeyWords = txtEN_KeyWords.Text;
        model.Pic_Url = txtPic_Url.Text;
        model.CN_Summary = txtCN_Summary.Text;
        model.EN_Summary = txtEN_Summary.Text;
        model.CN_Content = FCKeditor1.Value;
        model.EN_Content = FCKeditor2.Value;
        model.CreateTime = Convert.ToDateTime(txtCreateTime.Text);
        model.Remark = string.Empty;

        if (null != Request["C_id"] && string.Empty != Request["C_id"].ToString())
        {
            int C_id = 0;
            if (Int32.TryParse(Request["C_id"].ToString(), out C_id))
            {
                model.ID = C_id;
                if (new NetWise.DataAccess.News().Update(model))
                {
                    NetWise.DBUtility.JsControl.Show(this, "更新记录成功!", "News.aspx");
                }
                else
                {
                    NetWise.DBUtility.JsControl.Show(this, "更新记录失败!");
                }
            }

        }
        else
        {
            if (new NetWise.DataAccess.News().Add(model) > 0)
            {
                NetWise.DBUtility.JsControl.Show(this, "添加记录成功!", "News.aspx");
            }
            else
            {
                NetWise.DBUtility.JsControl.Show(this, "添加记录失败!");
            }
        }
    }
    protected void ckb_CheckedChanged(object sender, EventArgs e)
    {
        if (ckbCopy.Checked == true)
        {
            txtEN_Title.Text = txtCN_Title.Text;
            txtEN_KeyWords.Text = txtCN_KeyWords.Text;
            txtEN_Summary.Text = txtCN_Summary.Text;
            FCKeditor2.Value = FCKeditor1.Value;

        }
        else
        {
            txtEN_Title.Text = string.Empty;
            txtEN_KeyWords.Text = string.Empty;
            txtEN_Summary.Text = string.Empty;
            FCKeditor2.Value = string.Empty;
        }
    }
}
