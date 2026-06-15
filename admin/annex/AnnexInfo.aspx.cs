using System;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;
using System.IO;

public partial class admin_annex_AnnexInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataSet ds = new NetWise.DataAccess.DownloadClass().GetDownloadClassSort(string.Empty);
            if (null != ds && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    ddlProductClass.Items.Add(new ListItem(ds.Tables[0].Rows[i]["CN_Name"].ToString(),
                        ds.Tables[0].Rows[i]["ID"].ToString()));
                }
            }

            txtCreateTime.Text = DateTime.Now.ToString("yyyy-MM-dd");
            if (null != Request["L_id"] && string.Empty != Request["L_id"].ToString())
            {
                int L_id = 0;
                if (Int32.TryParse(Request["L_id"].ToString(), out L_id))
                {
                    NetWise.Entity.Download model = new NetWise.DataAccess.Download().GetModel(L_id);
                    if (null != model)
                    {
                        ddlProductClass.SelectedValue = model.ClassId.ToString();
                        txtCN_Title.Text = model.CN_Title;
                        txtEN_Title.Text = model.EN_Title;
                        txtSort.Text = model.Sort.ToString();
                        txtCreateTime.Text = model.CreateTime.ToString("yyyy-MM-dd");
                        txtPic_Url.Text = model.Download_Url;
                        txtPic3_Url.Text = model.CN_Summary; //附件2
                        txtPic2_Url.Text = model.Remark;//目录图片的存放地址
                        if (!string.IsNullOrEmpty(txtPic2_Url.Text))
                        {
                            imgPic_Url.ImageUrl = "~/uploadfiles/" + txtPic2_Url.Text;
                        }
                        FCKeditor1.Value = model.CN_Content;
                        FCKeditor2.Value = model.EN_Content;
                    }

                }
            }
        }

    }


    /// <summary>
    /// 附件1上传按钮
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnPic_Url_Click(object sender, EventArgs e)
    {
        lblMsg.Text = string.Empty;
        if (!(FileUpload1.HasFile))
        {
            lblMsg.Text += "请至少选择一个文件！ <br />";
        }
        if (FileUpload1.HasFile)
        {
            if (FileUpload1.FileContent.Length / 1024 > 40960)
            {
                lblMsg.Text += "上传文件大小限制为 40MB ！<br />";
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
            if (!Directory.Exists(HttpContext.Current.Request.PhysicalApplicationPath + "uploadfiles"))
            {
                Directory.CreateDirectory(HttpContext.Current.Request.PhysicalApplicationPath + "uploadfiles");
            }
            string SavePath = Server.MapPath("../../uploadfiles/");
            string extension = Path.GetExtension(FileUpload1.PostedFile.FileName);
            string FileName = NetWise.DBUtility.StringMethodControl.RadomFileName() + extension;
            string path = SavePath + FileName;
            FileUpload1.PostedFile.SaveAs(path);

            txtPic_Url.Text = FileName;
        }

    }


    /// <summary>
    /// 附件2上传按钮
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnPic3_Url_Click(object sender, EventArgs e)
    {
        lblMsg.Text = string.Empty;
        if (!(FileUpload3.HasFile))
        {
            lblMsg.Text += "请至少选择一个文件！ <br />";
        }
        if (FileUpload3.HasFile)
        {
            if (FileUpload3.FileContent.Length / 1024 > 40960)
            {
                lblMsg.Text += "上传文件大小限制为 40MB ！<br />";
            }
        }
        if (string.Empty != lblMsg.Text)
        {
            return;
        }
        //检测一下uploadFile是否选择了上传文件
        if (FileUpload3.HasFile)
        {
            //检测目录是否存在
            if (!Directory.Exists(HttpContext.Current.Request.PhysicalApplicationPath + "uploadfiles"))
            {
                Directory.CreateDirectory(HttpContext.Current.Request.PhysicalApplicationPath + "uploadfiles");
            }
            string SavePath = Server.MapPath("../../uploadfiles/");
            string extension = Path.GetExtension(FileUpload3.PostedFile.FileName);
            string FileName = NetWise.DBUtility.StringMethodControl.RadomFileName() + extension;
            string path = SavePath + FileName;
            FileUpload3.PostedFile.SaveAs(path);
            txtPic3_Url.Text = FileName;
        }

    }


    /// <summary>
    /// 目录图片上传
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnPic2_Url_Click(object sender, EventArgs e)
    {
        lblMsg.Text = string.Empty;
        if (!(FileUpload2.HasFile))
        {
            lblMsg.Text += "请至少选择一个文件！ <br />";
        }
        if (FileUpload2.HasFile)
        {
            if (FileUpload1.FileContent.Length / 1024 > 40960)
            {
                lblMsg.Text += "上传文件大小限制为 40MB ！<br />";
            }
        }
        if (string.Empty != lblMsg.Text)
        {
            return;
        }
        //检测一下uploadFile是否选择了上传文件
        if (FileUpload2.HasFile)
        {
            //检测目录是否存在
            if (!Directory.Exists(HttpContext.Current.Request.PhysicalApplicationPath + "uploadfiles"))
            {
                Directory.CreateDirectory(HttpContext.Current.Request.PhysicalApplicationPath + "uploadfiles");
            }
            string SavePath = Server.MapPath("../../uploadfiles/");
            string extension = Path.GetExtension(FileUpload2.PostedFile.FileName);
            string FileName = NetWise.DBUtility.StringMethodControl.RadomFileName() + extension;
            string path = SavePath + FileName;
            FileUpload2.PostedFile.SaveAs(path);
            txtPic2_Url.Text = FileName;
            imgPic_Url.ImageUrl = "~/uploadfiles/" + txtPic2_Url.Text;
        }
    }


    /// <summary>
    /// 提交按钮
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnOk_Click(object sender, EventArgs e)
    {
        int Sort = 0;
        NetWise.Entity.Download download = new NetWise.Entity.Download();
        download.CN_Title = txtCN_Title.Text;
        download.EN_Title = txtEN_Title.Text;
        Int32.TryParse(txtSort.Text, out Sort);
        download.Sort = Sort;
        download.CreateTime = Convert.ToDateTime(txtCreateTime.Text);
        download.Download_Url = txtPic_Url.Text; //附件1
        download.CN_Summary = txtPic3_Url.Text; //附件2
        download.CN_Content = FCKeditor1.Value;
        download.EN_Content = FCKeditor2.Value;
        download.Remark = txtPic2_Url.Text; //图片
        //download.EN_Summary = tb_password.Text;//密码
        download.ClassId = Convert.ToInt32(ddlProductClass.SelectedValue);

        if (null != Request["L_id"] && string.Empty != Request["L_id"].ToString())
        {
            int L_id = 0;
            if (Int32.TryParse(Request["L_id"].ToString(), out L_id))
            {
                download.ID = L_id;
                if (new NetWise.DataAccess.Download().Update(download))
                {
                    NetWise.DBUtility.JsControl.Show(this, "更新记录成功!", "Annex.aspx");
                }
                else
                {
                    NetWise.DBUtility.JsControl.Show(this, "更新记录失败!");
                }
            }

        }
        else
        {
            if (new NetWise.DataAccess.Download().Add(download) > 0)
            {
                NetWise.DBUtility.JsControl.Show(this, "添加记录成功!", "Annex.aspx");
            }
            else
            {
                NetWise.DBUtility.JsControl.Show(this, "添加记录失败!");
            }
        }
    }

}
