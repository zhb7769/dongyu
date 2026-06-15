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

public partial class admin_seo_Seo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int id = new NetWise.DataAccess.Seo().GetScalar();
            if (id > 0)
            {
                NetWise.Entity.Seo model = new NetWise.DataAccess.Seo().GetModel(id);
                txt_Home_CNTitle.Text = model.CN_Title;
                txt_Home_ENTitle.Text = model.EN_Title;
                txt_Home_CNDescription.Text = model.CN_Description;
                txt_Home_ENDescription.Text = model.EN_Description;
                txt_Home_CNKeywords.Text = model.CN_Keywords;
                txt_Home_ENKeywords.Text = model.EN_Keywords;
            }
        }
    }
    protected void btnHome_Click(object sender, EventArgs e)
    {
        NetWise.Entity.Seo model = new NetWise.Entity.Seo();
        model.CN_Title = txt_Home_CNTitle.Text;
        model.EN_Title = txt_Home_ENTitle.Text;
        model.CN_Description = txt_Home_CNDescription.Text;
        model.EN_Description = txt_Home_ENDescription.Text;
        model.CN_Keywords = txt_Home_CNKeywords.Text;
        model.EN_Keywords = txt_Home_ENKeywords.Text;

        model.Remark = string.Empty;

        int id = new NetWise.DataAccess.Seo().GetScalar();
        if (id > 0)
        {
            model.ID = id;
            if (new NetWise.DataAccess.Seo().Update(model))
            {
                NetWise.DBUtility.JsControl.Show(this, "更新记录成功!");
            }
        }
        else
        {
            if (new NetWise.DataAccess.Seo().Add(model) > 0)
            {
                NetWise.DBUtility.JsControl.Show(this, "添加记录成功!");
            }
        }
    }
}
