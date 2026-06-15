using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class admin_index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (null != Request.Cookies["user"])
        {
            lblName.Text = Request.Cookies["user"]["un"];
        }
        else if (null != Session["UserName"] && string.Empty != Session["UserName"].ToString())
        {
            lblName.Text = Session["UserName"].ToString();
        }
        else
        {
            Response.Redirect("login.aspx");
        }

        if (!IsPostBack)
        {
            object obj = new NetWise.DataAccess.Message().GetNumberMessage();
            if (null != obj)
            {
                litM_Num.Text = obj.ToString();
            }
        }

    }

    protected void lkbtnExit_Click(object sender, EventArgs e)
    {
        if (null != Request.Cookies["user"])
        {
            HttpCookie myCookie = Request.Cookies["user"];
            TimeSpan ts = new TimeSpan(-1, 0, 0, 0);
            myCookie.Expires = DateTime.Now.Add(ts);
            Response.Cookies.Add(myCookie);

            ClearClientPageCache();

            Response.Redirect("login.aspx");
        }
        else if (null != Session["UserName"] && string.Empty != Session["UserName"].ToString())
        {
            Session["UserName"] = null;
            ClearClientPageCache();
            Response.Redirect("login.aspx");
        }
        else
        {
            Response.Redirect("login.aspx");
        }
    }
    //清除浏览器缓存
    public void ClearClientPageCache()
    {
        Response.Buffer = true;
        Response.ExpiresAbsolute = DateTime.Now.AddDays(-1);
        Response.Cache.SetExpires(DateTime.Now.AddDays(-1));
        Response.Expires = 0;
        Response.CacheControl = "no-cache";
        Response.Cache.SetNoStore();

    }

}
