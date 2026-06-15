using System;
using System.Web.UI;
using NetWise.DataAccess;

public partial class EnNewsDetail : System.Web.UI.Page
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
        string strId = Request.QueryString["id"];
        if (!string.IsNullOrEmpty(strId))
        {
            int id;
            if (int.TryParse(strId, out id))
            {
                NetWise.DataAccess.News dal = new NetWise.DataAccess.News();
                NetWise.Entity.News model = dal.GetModel(id);
                if (model != null)
                {
                    ltTitle.Text = model.EN_Title;
                    ltTime.Text = model.CreateTime.ToString("yyyy-MM-dd");
                    ltContent.Text = model.EN_Content;
                }
            }
        }
    }
}
