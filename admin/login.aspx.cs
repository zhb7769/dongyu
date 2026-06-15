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

public partial class admin_login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        lblMsg.Text = string.Empty;
        string adminName = userName.Value;
        string adminPwd = password.Value;
        string verifyCode = CheckCode.Value;

        if (string.Empty == adminName || string.Empty == adminPwd)
        {
            lblMsg.Text += "用户名、密码都不能为空！</br>";
        }
        if (string.Empty == verifyCode)
        {
            lblMsg.Text += "验证码不能为空！</br>";
        }
        else
        {
            if (null != Session["CheckCode"] && string.Empty != Session["CheckCode"].ToString())
            {
                if (Session["CheckCode"].ToString().ToLower() != verifyCode.ToLower())
                {
                    lblMsg.Text += "验证码不正确！</br>";
                }
            }
        }

        if (string.Empty != lblMsg.Text)
        {
            return;
        }

        NetWise.Entity.Admin model = new NetWise.DataAccess.Admin().GetModel(adminName, adminPwd);
        if (null != model)
        {
            if (ckbName.Checked)
            {
                HttpCookie myCookie = new HttpCookie("user");
                myCookie["un"] = model.AdminName;
                //myCookie["pw"] = model.AdminPWD;
                myCookie.Expires = DateTime.MaxValue;
                Response.Cookies.Add(myCookie);
            }
            else
            {
                Session["UserName"] = model.AdminName;
            }

            Response.Redirect("index.aspx");
        }
        else
        {
            lblMsg.Text = "用户名或密码错误！";
            return;
        }

    }
}
