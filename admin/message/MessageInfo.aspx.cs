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

public partial class admin_message_MessageInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (null != Request["m_Id"] && string.Empty != Request["m_Id"].ToString())
            {
                int m_Id = 0;
                if (Int32.TryParse(Request["m_Id"].ToString(), out m_Id))
                {
                    new NetWise.DataAccess.Message().UpdateMessageForIsRead(m_Id);

                    NetWise.Entity.Message model = new NetWise.DataAccess.Message().GetModel(m_Id);
                    if (null != model)
                    {
                        MTitle.Value = model.MTitle;
                        litTime.Text = model.CreateTime.ToString("yyyy-MM-dd HH:mm:ss");
                        MName.Value = model.MName;
                        MTel.Value = model.MTel;
                        MFax.Value = model.MFax;
                        MEmail.Value = model.MEmail;
                        MContent.Value = model.MContent;

                        NetWise.Entity.Product Mproduct = new NetWise.DataAccess.Product().GetModel(model.P_ID);
                        if (Mproduct != null)
                        {
                            txtCN_Name.Text = Mproduct.CN_Name;
                            if (string.Empty != Mproduct.L_Img)
                            {
                                //下面图片绑定
                                hlk.NavigateUrl = "../../uploadfiles/product/" + Mproduct.L_Img;

                                imgM_Img.ImageUrl = "../../uploadfiles/product/" + Mproduct.L_Img;
                            }
                        }
                    }
                }
            }
        }
    }

    protected void btnOk_Click(object sender, EventArgs e)
    {
        NetWise.Entity.Message message = new NetWise.Entity.Message();
        message.MTitle = MTitle.Value;
        message.MName = MName.Value;
        message.CreateTime = Convert.ToDateTime(litTime.Text);
        message.MTel = MTel.Value;
        message.MFax = MFax.Value;
        message.MEmail = MEmail.Value;
        message.MContent = MContent.Value;

        message.MCompany = string.Empty;
        message.Remark = string.Empty;
        message.MSex = string.Empty;
        
        if (null != Request["m_Id"] && string.Empty != Request["m_Id"].ToString())
        {
            int m_Id = 0;
            if (Int32.TryParse(Request["m_Id"].ToString(), out m_Id))
            {
                message.ID = m_Id;
                message.IsRead = true;
                if (new NetWise.DataAccess.Message().Update(message))
                {
                    NetWise.DBUtility.JsControl.Show(this, "更新记录成功!", "Message.aspx");
                }
            }
        }
    }
}
