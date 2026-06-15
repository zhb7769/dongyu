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
using System.IO;

public partial class admin_project_PojectInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtCreateTime.Text = DateTime.Now.ToString("yyyy-MM-dd");
            if (null != Request["L_id"] && string.Empty != Request["L_id"].ToString())
            {
                int L_id = 0;
                if (Int32.TryParse(Request["L_id"].ToString(), out L_id))
                {
                    NetWise.Entity.Projects model = new NetWise.DataAccess.Projects().GetModel(L_id);
                    if (null != model)
                    {
                        txtCN_Title.Text = model.CN_Title;
                        txtEN_Title.Text = model.EN_Title;
                        txtSort.Text = model.Sort.ToString();
                        ckbHomeShow.Checked = model.HomeShow;
                        txtPic_Url.Text = model.Pic_Url;
                        if (string.Empty != model.Pic_Url)
                        {
                            imgPic_Url.ImageUrl = "../../uploadfiles/projects/" + model.Pic_Url;
                        }
                        txtCN_Summary.Text = model.CN_Summary;
                        txtEN_Summary.Text = model.EN_Summary;
                        FCKeditor1.Value = model.CN_Content;
                        FCKeditor2.Value = model.EN_Content;
                        txtCreateTime.Text = model.CreateTime.ToString("yyyy-MM-dd");
                    }

                }
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
            if (!Directory.Exists(HttpContext.Current.Request.PhysicalApplicationPath + "uploadfiles//projects"))
            {
                Directory.CreateDirectory(HttpContext.Current.Request.PhysicalApplicationPath + "uploadfiles//projects");
            }
            string SavePath = Server.MapPath("../../uploadfiles/projects/");
            string extension = Path.GetExtension(FileUpload1.PostedFile.FileName);
            string FileName = NetWise.DBUtility.StringMethodControl.RadomFileName() + extension;
            string path = SavePath + FileName;
            FileUpload1.PostedFile.SaveAs(path);

            imgPic_Url.ImageUrl = path;
            txtPic_Url.Text = FileName;
        }

    }

    protected void btnOk_Click(object sender, EventArgs e)
    {
        int Sort = 0;
        NetWise.Entity.Projects project = new NetWise.Entity.Projects();
        project.ClassID = 0;
        project.CN_Title = txtCN_Title.Text;
        project.EN_Title = txtEN_Title.Text;
        Int32.TryParse(txtSort.Text, out Sort);
        project.Sort = Sort;
        project.HomeShow = ckbHomeShow.Checked;
        project.Pic_Url = txtPic_Url.Text;
        project.CN_Summary = txtCN_Summary.Text;
        project.EN_Summary = txtEN_Summary.Text;
        project.CN_Content = FCKeditor1.Value;
        project.EN_Content = FCKeditor2.Value;
        project.CreateTime = Convert.ToDateTime(txtCreateTime.Text);
        project.Remark = string.Empty;

        if (null != Request["L_id"] && string.Empty != Request["L_id"].ToString())
        {
            int L_id = 0;
            if (Int32.TryParse(Request["L_id"].ToString(), out L_id))
            {
                project.ID = L_id;
                if (new NetWise.DataAccess.Projects().Update(project))
                {
                    NetWise.DBUtility.JsControl.Show(this, "更新记录成功!", "Projects.aspx");
                }
                else
                {
                    NetWise.DBUtility.JsControl.Show(this, "更新记录失败!");
                }
            }

        }
        else
        {
            if (new NetWise.DataAccess.Projects().Add(project) > 0)
            {
                NetWise.DBUtility.JsControl.Show(this, "添加记录成功!", "Projects.aspx");
            }
            else
            {
                NetWise.DBUtility.JsControl.Show(this, "添加记录失败!");
            }
        }
    }
}
