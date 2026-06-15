using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NetWise.DataAccess;

public partial class About : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        HengTuo.PageValidation.Sqlzy(this);
        if (!IsPostBack)
        {
            Bind();
        }
    }

    private void Bind()
    {
        NetWise.DataAccess.Article dal = new NetWise.DataAccess.Article();
        NetWise.Entity.Article model = dal.GetModelByClassID(1);
        if (model != null)
        {
            ltBanTitle.Text = model.CN_Title;
            ltTitle.Text = model.CN_Title;
            ltContent.Text = model.CN_Content;
        }
    }
}
