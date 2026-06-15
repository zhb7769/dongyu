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
using NetWise.Entity;

public partial class admin_product_ProductInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtCreateTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            DataSet ds = new NetWise.DataAccess.ProductClass().GetProductClassSort(string.Empty);
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
                    NetWise.Entity.Product model = new NetWise.DataAccess.Product().GetModel(P_Id);
                    if (null != model)
                    {
                        ddlProductClass.SelectedValue = model.ClassId.ToString();
                        FCKeditor3.Value = model.O_Img;

                        txtCN_Name.Text = model.CN_Name;
                        txtEN_Name.Text = model.EN_Name;
                        ckbIsPage.Checked = model.IsPage;
                        ckbIsTop.Checked = model.IsTop;
                        fck_CN_Label.Value = model.CN_Label;
                        fck_EN_Label.Value = model.EN_Label;
                        txtSort.Text = model.Sort.ToString();

                        FCKeditor1.Value = model.CN_Synopsis;
                        FCKeditor2.Value = model.EN_Synopsis;
                        txtCreateTime.Text = model.CreateTime.ToString("yyyy-MM-dd HH:mm:ss");

                        if (string.Empty != model.L_Img)
                        {
                            //下面图片绑定
                            hlk.NavigateUrl = "../../uploadfiles/product/" + model.L_Img;

                            imgM_Img.ImageUrl = "../../uploadfiles/product/" + model.L_Img;
                        }

                        txtL_Img.Text = model.L_Img;
                        txt_video.Value = model.Remark;//视频链接

                        rpt_img.DataSource = new NetWise.DataAccess.pro_att_info().GetList("pro_id=" + model.P_Id);
                        rpt_img.DataBind();

                        //获取参数值
                        var paraModel = new NetWise.DataAccess.pro_para_info();
                        var paraList = paraModel.GetList(10000, "pro_id=" + model.P_Id, "para_id ASC");
                        if (paraList.Tables[0].Rows.Count>0)
                        {
                            hf_leftValue.Value = string.Join("~",
                                (from DataRow row in paraList.Tables[0].Rows select row["para_left"].ToString())
                                .ToList());
                            hf_rightValue.Value = string.Join("~",
                                (from DataRow row in paraList.Tables[0].Rows select row["para_right"].ToString())
                                .ToList());
                            hf_enLeftValue.Value = string.Join("~",
                                (from DataRow row in paraList.Tables[0].Rows select row["para_EN_left"].ToString())
                                .ToList());
                            hf_enRightValue.Value = string.Join("~",
                                (from DataRow row in paraList.Tables[0].Rows select row["para_EN_right"].ToString())
                                .ToList());
                        }
                    }
                }
            }
        }
    }


    protected void rptP_Photos_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Del")
        {
            if (new NetWise.DataAccess.P_Photos().Delete(Convert.ToInt32(e.CommandArgument)))
            {
                JsControl.Show(this, "删除记录成功!", "ProductInfo.aspx");
            }
        }
    }
    

    /// <summary>
    /// 实物图上传
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnImg_Click(object sender, EventArgs e)
    {
        lblMsg.Text = string.Empty;
        if (!(FileUpload1.HasFile))
        {
            lblMsg.Text += "请至少选择一张商品图片！ <br />";
        }
        if (FileUpload1.HasFile)
        {
            if (FileUpload1.PostedFile.ContentType.ToLower().IndexOf("image", StringComparison.Ordinal) == -1)
                //if (FileUpload1.PostedFile.ContentType.ToString().ToLower().IndexOf("image") == -1)
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
            if (!Directory.Exists(HttpContext.Current.Request.PhysicalApplicationPath + "uploadfiles//product"))
            {
                Directory.CreateDirectory(HttpContext.Current.Request.PhysicalApplicationPath + "uploadfiles//product");
            }
            string SavePath = Server.MapPath("../../uploadfiles/product/");
            string extension = Path.GetExtension(FileUpload1.PostedFile.FileName);
            string FileName = StringMethodControl.RadomFileName() + extension;
            string path = SavePath + FileName;
            FileUpload1.PostedFile.SaveAs(path);

            txtL_Img.Text = FileName;
            imgM_Img.ImageUrl = "../../uploadfiles/product/" + FileName;
        }
    }
   

    /// <summary>
    /// 提交按钮
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnOk_Click(object sender, EventArgs e)
    {
        lblMsg.Text = string.Empty;
        var pId = 0;
        if (string.IsNullOrEmpty(hf_img.Value))
        {
            pId = new NetWise.DataAccess.Product().GetMaxID();
        } else
        {
            pId = int.Parse(hf_img.Value);
        }
       
        var cnLeftCount = hf_leftValue.Value.Split(',').Length;
        var enLeftCount = hf_enLeftValue.Value.Split(',').Length;

        if (!string.IsNullOrEmpty(hf_leftValue.Value) && !string.IsNullOrEmpty(hf_enLeftValue.Value))
        {
            if (cnLeftCount!=enLeftCount)
            {
                lblMsg.Text += "中文参数与英文参数个数不一致！ <br />";
                return;
            }
        }

        NetWise.Entity.Product model = new NetWise.Entity.Product
        {
            ClassId = Convert.ToInt32(ddlProductClass.SelectedValue),
            CN_Name = txtCN_Name.Text,
            EN_Name = txtEN_Name.Text,
            IsPage = ckbIsPage.Checked,
            IsTop = ckbIsTop.Checked,
            CN_Label = fck_CN_Label.Value,
            EN_Label = fck_EN_Label.Value,
            CN_Synopsis = FCKeditor1.Value,
            EN_Synopsis = FCKeditor2.Value,
            CreateTime = Convert.ToDateTime(txtCreateTime.Text),
            L_Img = txtL_Img.Text,
            M_Img = string.Empty,
            O_Img = FCKeditor3.Value,
            S_Img = string.Empty,
            Remark = txt_video.Value.Trim() //视频链接
        };
        int sort = 0;
        Int32.TryParse(txtSort.Text, out sort);
        model.Sort = sort;
        if (null != Request["P_Id"] && string.Empty != Request["P_Id"])
        {
            if (Int32.TryParse(Request["P_Id"], out pId))
            {
                model.P_Id = pId;
                new NetWise.DataAccess.Product().Update(model);
            }
        }
        else
        {
            if (string.IsNullOrEmpty(hf_img.Value))
            {
                new NetWise.DataAccess.Product().Add(model);
            }
            else
            {
                model.P_Id = int.Parse(hf_img.Value);
                new NetWise.DataAccess.Product().Update(model);
            }
        }


        //参数个数一致才保存
        if (!string.IsNullOrEmpty(hf_leftValue.Value) && !string.IsNullOrEmpty(hf_enLeftValue.Value))
        {
            if (cnLeftCount == enLeftCount)
            {
                AddPara(pId);
            }
        }

        JsControl.Show(this, "保存商品成功!", "Products.aspx");
    }


    /// <summary>
    /// 增加参数
    /// </summary>
    /// <param name="pId"></param>
    private void AddPara(int pId)
    {
        var paraModel = new NetWise.DataAccess.pro_para_info();
        var list = paraModel.GetList(10000, "pro_id=" + pId, "para_id ASC");
        if (list.Tables[0].Rows.Count>0)
        {
            var idArr = (from DataRow row in list.Tables[0].Rows select int.Parse(row["para_id"].ToString())).ToList();
            paraModel.DeleteList(string.Join(",", idArr));
        }

        //中文左边的参数(循环次数以这个为标准)
        if (string.IsNullOrEmpty(hf_leftValue.Value)) return;

        var leftArr = hf_leftValue.Value.Split('~').ToList();
        var leftEnArr = hf_enLeftValue.Value.Split('~').ToList();
        var rightArr = hf_rightValue.Value.Split('~').ToList();
        var rightEnArr = hf_enRightValue.Value.Split('~').ToList();

        for (var i = 0; i < leftArr.Count; i++)
        {
            var model = new pro_para_info
            {
                para_id = paraModel.GetMaxId(),
                pro_id = pId,
                para_left = leftArr[i],
                para_right = rightArr[i],
                para_EN_left = leftEnArr[i],
                para_EN_right = rightEnArr[i],
                create_time = DateTime.Now
            };
            new NetWise.DataAccess.pro_para_info().Add(model);
        }
    }


    /// <summary>
    /// 每行触发
    /// </summary>
    /// <param name="source"></param>
    /// <param name="e"></param>
    protected void rpt_img_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        string id = e.CommandArgument.ToString();
        if (e.CommandName != "del") return;
        var btei = new NetWise.DataAccess.pro_att_info();
        btei.Delete(int.Parse(id));
        if (string.IsNullOrEmpty(Request.QueryString["P_Id"]))
        {
            if (!string.IsNullOrEmpty(hf_img.Value))
            {
                rpt_img.DataSource = btei.GetList("pro_id=" + hf_img.Value);
                rpt_img.DataBind();
            }
        }
        else
        {
            string tId = Request.QueryString["P_Id"];
            rpt_img.DataSource = btei.GetList("pro_id=" + tId);
            rpt_img.DataBind();
        }
        string imgId = string.IsNullOrEmpty(Request.QueryString["P_id"]) ? hf_img.Value : Request.QueryString["P_Id"];
        rpt_img.DataSource = btei.GetList("pro_id=" + imgId);
        rpt_img.DataBind();
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('删除成功!')", true);
    }


    /// <summary>
    /// 多图上传按钮
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void bt_multiUpload_Click(object sender, EventArgs e)
    {
        lblMsg.Text = string.Empty;
        string fileName = "";
        if (!(FileUpload2.HasFile))
        {
            lblMsg.Text += "请至少选择一张商品图片！ <br />";
        }
        if (FileUpload2.HasFile)
        {
            if (FileUpload2.PostedFile.ContentType.ToLower().IndexOf("image", StringComparison.Ordinal) == -1)
            {
                lblMsg.Text += "图片格式不正确！<br />";
            }
            if (FileUpload2.FileContent.Length / 1024 > 4096)
            {
                lblMsg.Text += "上传文件大小限制为 4MB ！<br />";
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
            if (!Directory.Exists(HttpContext.Current.Request.PhysicalApplicationPath + "uploadfiles//product"))
            {
                Directory.CreateDirectory(HttpContext.Current.Request.PhysicalApplicationPath + "uploadfiles//product");
            }
            string savePath = Server.MapPath("../../uploadfiles/product/");
            string extension = Path.GetExtension(FileUpload2.PostedFile.FileName);
            fileName = StringMethodControl.RadomFileName() + extension;
            string path = savePath + fileName;
            FileUpload2.PostedFile.SaveAs(path);
            txtL_Img2.Text = fileName;
        }

        var btei = new NetWise.DataAccess.pro_att_info();
        var mtei = new NetWise.Entity.pro_att_info();
        string imgId = "";
        if (string.IsNullOrEmpty(Request.QueryString["P_Id"]))
        {
            if (string.IsNullOrEmpty(hf_img.Value))
            {
                var bbpi = new NetWise.DataAccess.Product();
                NetWise.Entity.Product model = new NetWise.Entity.Product
                {
                    ClassId = Convert.ToInt32(ddlProductClass.SelectedValue),
                    CN_Name = txtCN_Name.Text,
                    EN_Name = txtEN_Name.Text,
                    IsPage = ckbIsPage.Checked,
                    IsTop = ckbIsTop.Checked,
                    CN_Label = fck_CN_Label.Value,
                    EN_Label = fck_EN_Label.Value,
                    CN_Synopsis = FCKeditor1.Value,
                    EN_Synopsis = FCKeditor2.Value,
                    CreateTime = Convert.ToDateTime(txtCreateTime.Text),
                    L_Img = txtL_Img.Text,
                    M_Img = string.Empty,
                    O_Img = FCKeditor3.Value,
                    S_Img = string.Empty,
                    Remark = string.Empty
                };
                int sort = 0;
                Int32.TryParse(txtSort.Text, out sort);
                model.Sort = sort;
                model.P_Id = bbpi.GetMaxID();
                hf_img.Value = model.P_Id.ToString();
                new NetWise.DataAccess.Product().Add(model);
            }
            imgId = hf_img.Value;
            mtei.at_id = btei.GetMaxId();
            mtei.pro_id = int.Parse(hf_img.Value);
            mtei.create_time = DateTime.Now;
            mtei.pro_img = fileName;
            btei.Add(mtei);
        }
        else
        {
            string id = Request.QueryString["P_Id"];
            imgId = id;
            mtei.at_id = btei.GetMaxId();
            mtei.pro_id = int.Parse(id);
            mtei.create_time = DateTime.Now;
            mtei.pro_img = fileName;
            btei.Add(mtei);
        }
        rpt_img.DataSource = btei.GetList("pro_id=" + imgId);
        rpt_img.DataBind();
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('上传成功!')", true);
    }
}