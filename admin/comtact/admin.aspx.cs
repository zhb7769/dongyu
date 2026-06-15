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

public partial class admin_comtact_admin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnOk_Click(object sender, EventArgs e)
    {
        lblMsg.Text = string.Empty;
        NetWise.Entity.Admin model = new NetWise.DataAccess.Admin().GetModel("admin", yPass.Value);
        if (null == model)
        {
            lblMsg.Text += "您输入的原密码错误！<br/>";
        }
        if (string.Empty == xPass.Value || string.Empty == oPass.Value)
        {
            lblMsg.Text += "新密码和确认密码不能为空！<br/>";
        }
        if (xPass.Value.Trim() != oPass.Value.Trim())
        {
            lblMsg.Text += "您输入的新密码和确认密码不统一！<br/>";
        }
        if (string.Empty != lblMsg.Text)
        {
            return ;
        }

        NetWise.Entity.Admin admin = new NetWise.Entity.Admin();
        admin.ID = model.ID;
        admin.AdminName = model.AdminName;
        admin.AdminPWD = xPass.Value;
        admin.IsDelete = model.IsDelete;
        if (new NetWise.DataAccess.Admin().Update(admin))
        {
            NetWise.DBUtility.JsControl.Show(this, "密码更新成功!", "admin.aspx");
        }

    }
}
