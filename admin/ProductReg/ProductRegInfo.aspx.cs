using System;


public partial class admin_ProductRegInfo_ProductRegInfo : System.Web.UI.Page
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
                    var ds = new NetWise.DataAccess.ProductRegister().GetModelEx(m_Id).Tables[0];
                    if (ds.Rows.Count>0)
                    {
                        cName.Value = ds.Rows[0]["V1"].ToString(); //中文国家
                        puchaseDate.Text = Convert.ToDateTime(ds.Rows[0]["PurchaseDate"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                        pName.Value = ds.Rows[0]["pName"].ToString();
                        productType.Value = ds.Rows[0]["productType"].ToString();
                        serialNumber.Text = ds.Rows[0]["serialNumber"].ToString();
                        Email.Text = ds.Rows[0]["Email"].ToString();
                        userName.Text = ds.Rows[0]["userName"].ToString();
                        isReceive.Text = ds.Rows[0]["isReceive"].ToString() == "True" ? "是" : "否 ";

                        //英文
                        cEname.Value = ds.Rows[0]["EN_country"].ToString();
                        pEname.Value = ds.Rows[0]["pEname"].ToString();
                        EN_productType.Value = ds.Rows[0]["EN_productType"].ToString();
                        EN_serialNumber.Text = ds.Rows[0]["EN_serialNumber"].ToString();
                        EN_userName.Text = ds.Rows[0]["EN_userName"].ToString();
                        isReceive2.Text = ds.Rows[0]["isReceive"].ToString() == "True" ? "是" : "否";
                    }
                }
            }
        }
    }

    protected void btnOk_Click(object sender, EventArgs e)
    {
        //NetWise.Entity.Message message = new NetWise.Entity.Message();
        //message.MTitle = MTitle.Value;
        //message.MName = MName.Value;
        //message.CreateTime = Convert.ToDateTime(litTime.Text);
        //message.MTel = MTel.Value;
        //message.MFax = MFax.Value;
        //message.MEmail = MEmail.Value;
        //message.MContent = MContent.Value;

        //message.MCompany = string.Empty;
        //message.Remark = string.Empty;
        //message.MSex = string.Empty;
        
        //if (null != Request["m_Id"] && string.Empty != Request["m_Id"].ToString())
        //{
        //    int m_Id = 0;
        //    if (Int32.TryParse(Request["m_Id"].ToString(), out m_Id))
        //    {
        //        message.ID = m_Id;
        //        message.IsRead = true;
        //        if (new NetWise.DataAccess.Message().Update(message))
        //        {
        //            NetWise.DBUtility.JsControl.Show(this, "更新记录成功!", "Message.aspx");
        //        }
        //    }
        //}
    }
}
