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

public partial class admin_product_new_ProductClassInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataSet ds = new NetWise.DataAccess.PartsClass().GetPartsClassSort("1");
            if (null != ds && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    ddlProductClass.Items.Add(new ListItem(ds.Tables[0].Rows[i]["CN_Name"].ToString(),
                        ds.Tables[0].Rows[i]["ID"].ToString()));
                }
            }

            if (null != Request["C_id"] && string.Empty != Request["C_id"].ToString())
            {
                int C_id = 0;
                if (Int32.TryParse(Request["C_id"].ToString(), out C_id))
                {
                    NetWise.Entity.PartsClass model = new NetWise.DataAccess.PartsClass().GetModel(C_id);
                    if (null != model)
                    {
                        txtCN_Name.Text = model.CN_Name;
                        txtEN_Name.Text = model.EN_Name;
                        ddlProductClass.SelectedValue = model.ParentId;
                        txtSort.Text = model.Sort.ToString();
                        ckbIndexShow.Checked = model.IndexShow;
                        txtC_Pic.Text = model.C_Pic;
                        if (string.Empty != model.C_Pic)
                        {
                            imgC_Pic.ImageUrl = "/uploadfiles/productClass/" + model.C_Pic;
                        }
                        txtB_Pic.Text = model.B_Pic;
                        if (string.Empty != model.B_Pic)
                        {
                            imgB_Pic.ImageUrl = "/uploadfiles/productClass/" + model.B_Pic;
                        }
                    }
                }
            }
        }
    }

    protected void btnC_Pic_Click(object sender, EventArgs e)
    {
        lblMessage.Text = string.Empty;
        if (!(fuC_Pic.HasFile))
        {
            lblMessage.Text += "请至少选择一张商品图片！ <br />";
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
            if (!Directory.Exists(HttpContext.Current.Request.PhysicalApplicationPath + "uploadfiles//productClass"))
            {
                Directory.CreateDirectory(HttpContext.Current.Request.PhysicalApplicationPath + "uploadfiles//productClass");
            }
            string SavePath = Server.MapPath("/uploadfiles/productClass/");
            string extension = Path.GetExtension(fuC_Pic.PostedFile.FileName);
            string FileName = NetWise.DBUtility.StringMethodControl.RadomFileName() + extension;
            string path = SavePath + FileName;
            fuC_Pic.PostedFile.SaveAs(path);

            imgC_Pic.ImageUrl = "/uploadfiles/productClass/" + FileName;
            txtC_Pic.Text = FileName;
        }
    }
    protected void btnB_Pic_Click(object sender, EventArgs e)
    {
        lblMessage.Text = string.Empty;
        if (!(fuB_Pic.HasFile))
        {
            lblMessage.Text += "请至少选择一张商品图片！ <br />";
        }
        if (fuB_Pic.HasFile)
        {
            if (fuB_Pic.PostedFile.ContentType.ToString().ToLower().IndexOf("image") == -1)
            {
                lblMessage.Text += "图片格式不正确！<br />";
            }
            if (fuB_Pic.FileContent.Length / 1024 > 4096)
            {
                lblMessage.Text += "上传文件大小限制为 4MB ！<br />";
            }
        }
        if (string.Empty != lblMessage.Text)
        {
            return;
        }
        //检测一下uploadFile是否选择了上传文件
        if (fuB_Pic.HasFile)
        {
            //检测目录是否存在
            if (!Directory.Exists(HttpContext.Current.Request.PhysicalApplicationPath + "uploadfiles//productClass"))
            {
                Directory.CreateDirectory(HttpContext.Current.Request.PhysicalApplicationPath + "uploadfiles//productClass");
            }
            string SavePath = Server.MapPath("/uploadfiles/productClass/");
            string extension = Path.GetExtension(fuB_Pic.PostedFile.FileName);
            string FileName = NetWise.DBUtility.StringMethodControl.RadomFileName() + extension;
            string path = SavePath + FileName;
            fuB_Pic.PostedFile.SaveAs(path);

            imgB_Pic.ImageUrl = "/uploadfiles/productClass/" + FileName;
            txtB_Pic.Text = FileName;
        }
    }
    protected void btnOk_Click(object sender, EventArgs e)
    {
        int Sort = 0;
        NetWise.Entity.PartsClass model = new NetWise.Entity.PartsClass();
        model.CN_Name = txtCN_Name.Text;
        model.EN_Name = txtEN_Name.Text;
        model.ParentId = ddlProductClass.SelectedValue;
        Int32.TryParse(txtSort.Text.ToString(), out Sort);
        model.Sort = Sort;
        model.IndexShow = ckbIndexShow.Checked;
        model.C_Pic = txtC_Pic.Text;
        model.B_Pic = txtB_Pic.Text;

        object obj = new NetWise.DataAccess.PartsClass().GetDepthByID(Convert.ToInt32(ddlProductClass.SelectedValue));
        if (obj != null)
        {
            model.Depth = Convert.ToInt32(obj) + 1;
        }
        else
        {
            model.Depth = Convert.ToInt32(ddlProductClass.SelectedValue);
        }
        model.CN_Url = "1";  //是否是新产品分类标识
        model.EN_Url = string.Empty;

        if (null != Request["C_id"] && string.Empty != Request["C_id"].ToString())
        {
            int C_id = 0;
            if (Int32.TryParse(Request["C_id"].ToString(), out C_id))
            {
                model.ID = C_id;
                NetWise.Entity.PartsClass productClass = new NetWise.DataAccess.PartsClass().GetModel(Convert.ToInt32(ddlProductClass.SelectedValue));
                if (Convert.ToInt32(ddlProductClass.SelectedValue) == C_id || (productClass != null && productClass.ParentId == C_id.ToString()))
                {
                    NetWise.DBUtility.JsControl.Show(this, "所选的上级分类不能是当前分类或者当前分类的下级分类!");
                }
                else
                {
                    if (new NetWise.DataAccess.PartsClass().Update(model))
                    {
                        NetWise.DBUtility.JsControl.Show(this, "更新记录成功!", "ProductClass.aspx");
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
            if (new NetWise.DataAccess.PartsClass().Add(model) > 0)
            {
                NetWise.DBUtility.JsControl.Show(this, "添加记录成功!", "ProductClass.aspx");
            }
            else
            {
                NetWise.DBUtility.JsControl.Show(this, "添加记录失败!");
            }
        }
    }

}
