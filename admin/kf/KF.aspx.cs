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

public partial class admin_kf_KF : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           DataSet ds = new NetWise.DataAccess.CustomService().GetList(string.Empty);
           rptServic.DataSource = ds;
           rptServic.DataBind();
        }
    }
    protected void rptServic_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Del")
        {
            if (new NetWise.DataAccess.CustomService().Delete(Convert.ToInt32(e.CommandArgument)))
            {
                NetWise.DBUtility.JsControl.Show(this, "删除成功！","KF.aspx");
            }
            
        }
        if (e.CommandName == "Modify")
        {
            TextBox txtNum = e.Item.FindControl("txtNum") as TextBox;
            if (new NetWise.DataAccess.CustomService().Update(txtNum.Text, Convert.ToInt32(e.CommandArgument)))
            {
                NetWise.DBUtility.JsControl.Show(this, "修改成功！","KF.aspx");
            }
                
        }
    }
    protected void btnOk_Click(object sender, EventArgs e)
    {
        if (string.Empty != ddlSelect.SelectedValue)
        {
            NetWise.Entity.CustomService model = new NetWise.Entity.CustomService();
            model.ServiceType = ddlSelect.SelectedValue;
            model.Number = TxtNumber.Text;
            model.Remark = string.Empty;

            if (new NetWise.DataAccess.CustomService().Add(model) > 0)
            {
                NetWise.DBUtility.JsControl.Show(this, "添加成功！","KF.aspx");
            }
        }
    }
}
