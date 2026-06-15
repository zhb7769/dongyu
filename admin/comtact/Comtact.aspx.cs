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

public partial class admin_comtact_Comtact : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int id = new NetWise.DataAccess.Contact().GetScalar();
            if (id > 0)
            {
                NetWise.Entity.Contact model = new NetWise.DataAccess.Contact().GetModel(id);
                txtCN_Company.Text = model.CN_Company;
                txtEN_Company.Text = model.EN_Company;
                txtCN_Person.Text = model.CN_Person;
                txtEN_Person.Text = model.EN_Person;
                txtCN_Address.Text = model.CN_Address;
                txtEN_Address.Text = model.EN_Address;
                txtCN_CompanyTel.Text = model.CN_CompanyTel;
                txtEN_CompanyTel.Text = model.EN_CompanyTel;
                txtCN_Phone.Text = model.CN_Phone;
                txtEN_Phone.Text = model.EN_Phone;
                txtFax.Text = model.Fax;
                txtPostCode.Text = model.PostCode;
                txtEmail.Text = model.Email;
                txtWebsite.Text = model.Website;
                txtQQ.Text = model.QQ;
                txtSKYPE.Text = model.SKYPE;
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        NetWise.Entity.Contact model = new NetWise.Entity.Contact();
        model.CN_Company = txtCN_Company.Text;
        model.EN_Company = txtEN_Company.Text;
        model.CN_Person = txtCN_Person.Text;
        model.EN_Person = txtEN_Person.Text;
        model.CN_Address = txtCN_Address.Text;
        model.EN_Address = txtEN_Address.Text;
        model.CN_CompanyTel = txtCN_CompanyTel.Text;
        model.EN_CompanyTel = txtEN_CompanyTel.Text;
        model.CN_Phone = txtCN_Phone.Text;
        model.EN_Phone = txtEN_Phone.Text;
        model.Fax = txtFax.Text;
        model.PostCode = txtPostCode.Text;
        model.Email = txtEmail.Text;
        model.Website = txtWebsite.Text;
        model.QQ = txtQQ.Text;
        model.SKYPE = txtSKYPE.Text;

        model.CN_Content = string.Empty;
        model.EN_Content = string.Empty;

        int id = new NetWise.DataAccess.Contact().GetScalar();
        if (id > 0)
        {
            model.ID = id;
            if (new NetWise.DataAccess.Contact().Update(model))
            {
                NetWise.DBUtility.JsControl.Show(this, "更新记录成功!");
            }
        }
        else
        {
            if (new NetWise.DataAccess.Contact().Add(model) > 0)
            {
                NetWise.DBUtility.JsControl.Show(this, "添加记录成功!");
            }
        }

    }
}
