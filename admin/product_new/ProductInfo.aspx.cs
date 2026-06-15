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
using NetWise.DBUtility;
using System.IO;

public partial class admin_product_new_ProductInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtCreateTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            DataSet ds = new NetWise.DataAccess.PartsClass().GetPartsClassSort("1");
            if (null != ds && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    ddlProductClass.Items.Add(new ListItem(ds.Tables[0].Rows[i]["CN_Name"].ToString(),
                        ds.Tables[0].Rows[i]["ID"].ToString()));
                }
            }

            if (null != Request["P_Id"] && string.Empty != Request["P_Id"].ToString())
            {
                int P_Id = 0;
                if (Int32.TryParse(Request["P_Id"].ToString(), out P_Id))
                {
                    NetWise.Entity.Parts model = new NetWise.DataAccess.Parts().GetModel(P_Id);
                    if (null != model)
                    {
                        ddlProductClass.SelectedValue = model.ClassId.ToString();
                        txtCN_Name.Text = model.CN_Name;
                        txtEN_Name.Text = model.EN_Name;
                        ckbIsPage.Checked = model.IsPage;
                        ckbIsTop.Checked = model.IsTop;
                        txtCN_Label.Text = model.CN_Label;
                        txtEN_Label.Text = model.EN_Label;
                        txtSort.Text = model.Sort.ToString();

                        FCKeditor1.Value = model.CN_Synopsis;
                        FCKeditor2.Value = model.EN_Synopsis;
                        txtCreateTime.Text = model.CreateTime.ToString("yyyy-MM-dd HH:mm:ss");

                        //下面图片绑定
                        hlk.NavigateUrl = "/uploadfiles/Parts/" + model.L_Img;
                        imgM_Img.ImageUrl = "/uploadfiles/Parts/" + model.M_Img;
                        hfL_Img.Value = model.L_Img;
                        hfM_Img.Value = model.M_Img;
                    }
                }
            }
            else
            {
                //hf.Value = new NetWise.DataAccess.Parts().GetMaxID().ToString();
                //BindrptP_Photos(Convert.ToInt32(hf.Value));
            }
        }
    }
    private void AddTypeChildNodes(string parentId, List<NetWise.Entity.PartsClass> list, string strDistance, DropDownList ddl)
    {
        List<NetWise.Entity.PartsClass> currList = list.Where(a => a.ParentId == parentId).ToList();
        if (currList.Count > 0)
        {
            foreach (NetWise.Entity.PartsClass k in currList)
            {
                ddl.Items.Add(new ListItem(strDistance + k.CN_Name, k.ID.ToString()));
                AddTypeChildNodes(k.ID.ToString(), list, strDistance + "---", ddl);
            }
        }
    }

    protected void rptP_Photos_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Del")
        {
            if (new NetWise.DataAccess.P_Photos().Delete(Convert.ToInt32(e.CommandArgument)))
            {
                JsControl.Show(this, "删除记录成功!", "PartsInfo.aspx");
            }
        }
    }
    private void BindrptP_Photos(int PartsId)
    {
        //rptP_Photos.DataSource = new NetWise.DataAccess.P_Photos().GetListByPartsId(PartsId);
        //rptP_Photos.DataBind();
    }
    protected void btnImg_Click(object sender, EventArgs e)
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
            if (!Directory.Exists(HttpContext.Current.Request.PhysicalApplicationPath + "uploadfiles//Parts"))
            {
                Directory.CreateDirectory(HttpContext.Current.Request.PhysicalApplicationPath + "uploadfiles//Parts");
            }
            string SavePath = Server.MapPath("/uploadfiles/Parts/");
            string extension = Path.GetExtension(FileUpload1.PostedFile.FileName);
            string FileName = StringMethodControl.RadomFileName() + extension;
            string path = SavePath + FileName;
            FileUpload1.PostedFile.SaveAs(path);
            hfL_Img.Value = FileName;
            FileName = NetWise.DBUtility.StringMethodControl.RadomFileName() + extension;
            if (WebImages.GetThumbNail(SavePath + hfL_Img.Value, SavePath + FileName, 150, 150, WebImages.ThumbNailScale.ScaleDown))
            {
                hfM_Img.Value = FileName;

            }

            imgM_Img.ImageUrl = "/uploadfiles/Parts/" + hfM_Img.Value;
        }

    }

    protected void btnOk_Click(object sender, EventArgs e)
    {
        NetWise.Entity.Parts model = new NetWise.Entity.Parts();
        model.ClassId = Convert.ToInt32(ddlProductClass.SelectedValue);
        model.CN_Name = txtCN_Name.Text;
        model.EN_Name = txtEN_Name.Text;
        model.IsPage = ckbIsPage.Checked;
        model.IsTop = true;
        model.CN_Label = txtCN_Label.Text;
        model.EN_Label = txtEN_Label.Text;

        int Sort = 0;
        Int32.TryParse(txtSort.Text, out Sort);
        model.Sort = Sort;

        model.CN_Synopsis = FCKeditor1.Value;
        model.EN_Synopsis = FCKeditor2.Value;
        model.CreateTime = Convert.ToDateTime(txtCreateTime.Text);

        model.L_Img = hfL_Img.Value;
        model.M_Img = hfM_Img.Value;
        model.O_Img = string.Empty;
        model.S_Img = string.Empty;

        model.Remark = string.Empty;

        if (null != Request["P_Id"] && string.Empty != Request["P_Id"].ToString())
        {
            int P_Id = 0;
            if (Int32.TryParse(Request["P_Id"].ToString(), out P_Id))
            {
                model.P_Id = P_Id;
                if (new NetWise.DataAccess.Parts().Update(model))
                {
                    JsControl.Show(this, "更新记录成功!", "Products.aspx");
                }
            }
        }
        else
        {

            if (new NetWise.DataAccess.Parts().Add(model) > 0)
            {
                JsControl.Show(this, "配件添加成功！", "Products.aspx");
            }
        }
    }
}
