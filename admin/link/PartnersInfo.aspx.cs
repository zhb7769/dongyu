using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class admin_link_PartnersInfo : System.Web.UI.Page
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
                    NetWise.Entity.Link model = new NetWise.DataAccess.Link().GetModel(L_id);
                    if (null != model)
                    {
                        txtName.Text = model.LinkName;
                        txtName_en.Text = model.LinkName_en;
                        txtLinkUrl.Text = model.LinkUrl;
                        txtLinkPic.Text = model.LinkPic;
                        txtSort.Text = model.Sort.ToString();
                        if (string.Empty != model.LinkPic)
                        {
                            imgView.ImageUrl = "../../uploadfiles/link/" + model.LinkPic;
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
            if (!Directory.Exists(HttpContext.Current.Request.PhysicalApplicationPath + "uploadfiles//link"))
            {
                Directory.CreateDirectory(HttpContext.Current.Request.PhysicalApplicationPath + "uploadfiles//link");
            }
            string SavePath = Server.MapPath("../../uploadfiles/link/");
            string extension = Path.GetExtension(FileUpload1.PostedFile.FileName);
            string FileName = NetWise.DBUtility.StringMethodControl.RadomFileName() + extension;
            string path = SavePath + FileName;
            FileUpload1.PostedFile.SaveAs(path);

            imgView.ImageUrl = path;
            txtLinkPic.Text = FileName;
        }
    }
    protected void btnOk_Click(object sender, EventArgs e)
    {
        int Sort = 0;
        NetWise.Entity.Link model = new NetWise.Entity.Link();
        model.LinkName = txtName.Text;
        model.LinkName_en = txtName_en.Text;
        model.LinkUrl = txtLinkUrl.Text;
        model.LinkPic = txtLinkPic.Text;

        model.LinkType = 2;  //合作伙伴

        Int32.TryParse(txtSort.Text, out Sort);
        model.Sort = Sort;
        if (null != Request["L_id"] && string.Empty != Request["L_id"].ToString())
        {
            int L_id = 0;
            if (Int32.TryParse(Request["L_id"].ToString(), out L_id))
            {
                model.ID = L_id;
                if (new NetWise.DataAccess.Link().Update(model))
                {
                    NetWise.DBUtility.JsControl.Show(this, "更新记录成功!", "Partners.aspx");
                }
                else
                {
                    NetWise.DBUtility.JsControl.Show(this, "更新记录失败!", "PartnersInfo.aspx");
                }
            }

        }
        else
        {
            if (new NetWise.DataAccess.Link().Add(model) > 0)
            {
                NetWise.DBUtility.JsControl.Show(this, "添加记录成功!", "Partners.aspx");
            }
            else
            {
                NetWise.DBUtility.JsControl.Show(this, "添加记录失败!", "PartnersInfo.aspx");
            }
        }
    }
}
