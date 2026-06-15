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

public partial class admin_loginBanner_LoginBannerInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (null != Request["L_id"] && string.Empty != Request["L_id"].ToString())
            {
                int L_id = 0;
                if (Int32.TryParse(Request["L_id"].ToString(), out L_id))
                {
                    NetWise.Entity.LoginBanner model = new NetWise.DataAccess.LoginBanner().GetModel(L_id);
                    if (null != model)
                    {
                        txtB_Title.Text = model.B_Title;
                        txtB_Style.Text = model.B_Style;
                        txtB_Add.Text = model.B_Add;
                        txtB_Pic.Text = model.B_Pic;
                        txtB_Sort.Text = model.B_Sort.ToString();
                        if (string.Empty != model.B_Pic)
                        {
                            imgView.ImageUrl = "../../uploadfiles/loginBanner/" + model.B_Pic;
                        }
                    }
                }

            }

        }
    }
    protected void btnFileUpload_Click(object sender, EventArgs e)
    {
        lblMessage.Text = string.Empty;
        if (!(FileUpload1.HasFile))
        {
            lblMessage.Text += "请至少选择一张商品图片！ <br />";
        }
        if (FileUpload1.HasFile)
        {
            if (FileUpload1.PostedFile.ContentType.ToString().ToLower().IndexOf("image") == -1)
            {
                lblMessage.Text += "图片格式不正确！<br />";
            }
            if (FileUpload1.FileContent.Length / 1024 > 4096)
            {
                lblMessage.Text += "上传文件大小限制为 4MB ！<br />";
            }
        }
        if (string.Empty != lblMessage.Text)
        {
            return;
        }
        //检测一下uploadFile是否选择了上传文件
        if (FileUpload1.HasFile)
        {
            //检测目录是否存在
            if (!Directory.Exists(HttpContext.Current.Request.PhysicalApplicationPath + "uploadfiles//loginBanner"))
            {
                Directory.CreateDirectory(HttpContext.Current.Request.PhysicalApplicationPath + "uploadfiles//loginBanner");
            }
            string SavePath = Server.MapPath("../../uploadfiles/loginBanner/");
            string extension = Path.GetExtension(FileUpload1.PostedFile.FileName);
            string FileName = NetWise.DBUtility.StringMethodControl.RadomFileName() + extension;
            string path = SavePath + FileName;
            FileUpload1.PostedFile.SaveAs(path);

            imgView.ImageUrl = "../../uploadfiles/loginBanner/" + FileName;
            txtB_Pic.Text = FileName;
        }
    }
    protected void btnOk_Click(object sender, EventArgs e)
    {
        int Sort = 0;
        NetWise.Entity.LoginBanner model = new NetWise.Entity.LoginBanner();
        model.B_Title = txtB_Title.Text;
        model.B_Style = txtB_Style.Text;
        model.B_Add = txtB_Add.Text;
        model.B_Pic = txtB_Pic.Text;
        Int32.TryParse( txtB_Sort.Text, out Sort);
        model.B_Sort = Sort;
        if (null != Request["L_id"] && string.Empty != Request["L_id"].ToString())
        {
            int L_id = 0;
            if (Int32.TryParse(Request["L_id"].ToString(), out L_id))
            {
                model.B_ID = L_id;
                if (new NetWise.DataAccess.LoginBanner().Update(model))
                {
                    NetWise.DBUtility.JsControl.Show(this, "更新记录成功!", "LoginBanners.aspx");
                }
                else
                {
                    NetWise.DBUtility.JsControl.Show(this, "更新记录失败!", "LoginBannersInfo.aspx");
                }
            }

        }
        else
        {
            if (new NetWise.DataAccess.LoginBanner().Add(model) > 0)
            {
                NetWise.DBUtility.JsControl.Show(this, "添加记录成功!", "LoginBanners.aspx");
            }
            else
            {
                NetWise.DBUtility.JsControl.Show(this, "添加记录失败!", "LoginBannersInfo.aspx");
            }
        }
    }
}
