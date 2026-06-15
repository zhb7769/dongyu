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
using System.Data.SqlClient;
using System.Collections.Generic;

public partial class admin_product_ProductClass : System.Web.UI.Page
{
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {  
            Bind();
        }
        //DataSet ds = getDate();
        //createmenu(ds, null,tree);
    }
    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        Bind();
    }
    private void Bind()
    {
        //DataTable dt = new DataTable();
        ////添加列
        //DataColumn ID = new DataColumn("ID", typeof(int));
        //DataColumn CN_Name = new DataColumn("CN_Name", typeof(string));
        //DataColumn ParentId = new DataColumn("ParentId", typeof(int));
        //DataColumn IndexShow = new DataColumn("IndexShow", typeof(bool));
        //DataColumn Sort = new DataColumn("Sort", typeof(int));
        //DataColumn Depth = new DataColumn("Depth", typeof(int));

        //dt.Columns.Add(ID);
        //dt.Columns.Add(CN_Name);
        //dt.Columns.Add(ParentId);
        //dt.Columns.Add(IndexShow);
        //dt.Columns.Add(Sort);
        //dt.Columns.Add(Depth);

        //List<NetWise.Entity.ProductClass> list = new NetWise.DataAccess.ProductClass().GetList();
        //if (list != null && list.Count > 0)
        //{
        //    AddNodes("0", list, ref dt);
        //}

        DataTable dt = new NetWise.DataAccess.ProductClass().GetProductClassSort(string.Empty).Tables[0];
         
        PagedDataSource pds = new PagedDataSource();
        AspNetPager1.RecordCount = dt.Rows.Count;
        pds.DataSource = dt.DefaultView;
        pds.AllowPaging = true;
        pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
        pds.PageSize = AspNetPager1.PageSize;
        rpt_list.DataSource = pds;
        rpt_list.DataBind();
    }

    protected void rpt_list_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Image imgIndexShow = e.Item.FindControl("imgIndexShow") as Image;
        if (imgIndexShow.ToolTip == "True")
        {
            imgIndexShow.ImageUrl = "../images/ico/ok.gif";
        }
        else
        {
            imgIndexShow.Visible = false;
        }

        Label lblNum = e.Item.FindControl("lblNum") as Label;
        lblNum.Text = new NetWise.DataAccess.ProductClass().GetNumByID(Convert.ToInt32(lblNum.Text)).ToString();

    }

    protected void rpt_list_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Del")
        {
            if (new NetWise.DataAccess.ProductClass().Delete(Convert.ToInt32(e.CommandArgument)))
            {
                NetWise.DBUtility.JsControl.Show(this, "删除记录成功!", "ProductClass.aspx");
            }
        }
    }

    protected void btnDo_Click(object sender, EventArgs e)
    {
        if ("1" == ddlSelect.SelectedValue && rpt_list.Items.Count > 0)
        {
            bool needRefresh = false;
            for (int i = 0; i < rpt_list.Items.Count; i++)
            {
                CheckBox chkObj = (CheckBox)rpt_list.Items[i].FindControl("ckbSelect");
                HiddenField hfID = (HiddenField)rpt_list.Items[i].FindControl("hfID");
                if (chkObj.Checked == true)
                {
                    new NetWise.DataAccess.ProductClass().UpdateShowByID(Convert.ToInt32(hfID.Value));
                    needRefresh = true;
                }
            }
            if (needRefresh)
            {
                NetWise.DBUtility.JsControl.Show(this, "批量操作成功！", "ProductClass.aspx");
            }
            else
            {
                NetWise.DBUtility.JsControl.Show(this, "请先选择！");
            }
        }
        else if ("2" == ddlSelect.SelectedValue && rpt_list.Items.Count > 0)
        {
            //do;
        }
        else
        {
            NetWise.DBUtility.JsControl.Show(this, "请先选择！");
        }
    }


    public void AddNodes(string parentId, List<NetWise.Entity.ProductClass> list, ref DataTable dt)
    {
        List<NetWise.Entity.ProductClass> currList = list.Where(a => a.ParentId == parentId).ToList();
        if (currList.Count > 0)
        {
            foreach (NetWise.Entity.ProductClass k in currList)
            {
                //添加行数据 
                DataRow row = dt.NewRow();

                row["ID"] = k.ID;
                row["CN_Name"] = k.CN_Name;
                row["ParentId"] = k.ParentId;
                row["IndexShow"] = k.IndexShow;
                row["Sort"] = k.Sort;
                row["Depth"] = k.Depth;

                dt.Rows.Add(row);

                AddNodes(k.ID.ToString(), list,ref dt);

            }
        }
    }

    public DataSet getDate()
    {
        DataSet ds = new DataSet();
        string config = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        SqlConnection conn = new SqlConnection(config);
        SqlDataAdapter da = new SqlDataAdapter("select * from ProductClass order by Sort", conn);
        da.Fill(ds);
        return ds;
    }
    private void createmenu(DataSet ds, string parentId, HtmlGenericControl UL)
    {
        DataRow[] rows;
        if (string.IsNullOrEmpty(parentId))
            rows = ds.Tables[0].Select("ParentId is null");//过滤 
        else
            rows = ds.Tables[0].Select("ParentId='" + parentId + "'");//过滤 
        foreach (DataRow t in rows)
        {
            DataRow[] childern = ds.Tables[0].Select("ParentId =" + t["ID"].ToString());//用于判断是否有子节点 

            HtmlGenericControl serverUL = new HtmlGenericControl("ul");//生成Li标签，作为父节点 
            serverUL.Attributes["class"] = "ul-list l";

            if (childern.Length != 0 || parentId == "")//是父节点 
            {
                //serverLi.InnerText = t["CN_Name"].ToString();

                ////生成标签a 
                //HtmlAnchor NewAnchorControl = new HtmlAnchor();
                //// 设置标签a的属性 
                //NewAnchorControl.Name = "NewAnchorControl";
                //NewAnchorControl.InnerHtml = t["CN_Name"].ToString();
                //NewAnchorControl.HRef = t["CN_Url"].ToString() + "?id=";
                //NewAnchorControl.Target = "_black";//设置显示的位置，这里改一下 
                //serverLi.Controls.Add(NewAnchorControl);

                HtmlGenericControl serverli = new HtmlGenericControl("li");
                serverli.Attributes["class"] = "sel";
                serverUL.Controls.Add(serverli);

                HtmlGenericControl serverli1 = new HtmlGenericControl("li");
                serverli1.Attributes["class"] = "Class-Name";
                HtmlGenericControl serverBr = new HtmlGenericControl("br");
                serverli1.InnerHtml = t["CN_Name"].ToString() + "<br/>" + "123";
                serverUL.Controls.Add(serverli1);

                HtmlGenericControl serverli2 = new HtmlGenericControl("li");
                serverli2.Attributes["class"] = "Class-num";
                HtmlAnchor NewAnchorControl = new HtmlAnchor();
                NewAnchorControl.InnerHtml = t["ID"].ToString();
                NewAnchorControl.HRef = "manage_product.html";
                serverli2.Controls.Add(NewAnchorControl);
                serverUL.Controls.Add(serverli2);
                UL.Controls.Add(serverUL);
                createmenu(ds, t["ID"].ToString(), serverUL);
            }
            else
            {
                HtmlGenericControl serDiv = new HtmlGenericControl("div");

                //serverLi.InnerText = t["CN_Name"].ToString();

                ////生成标签a 
                //HtmlAnchor NewAnchorControl = new HtmlAnchor();
                //// 设置标签a的属性 
                //NewAnchorControl.Name = "NewAnchorControl";
                //NewAnchorControl.InnerHtml = t["CN_Name"].ToString();
                //NewAnchorControl.HRef = t["CN_Url"].ToString() + "?id=";
                //NewAnchorControl.Target = "_black";//设置显示的位置，这里改一下 
                //serverLi.Controls.Add(NewAnchorControl);

                HtmlGenericControl serverli = new HtmlGenericControl("li");
                serverli.Attributes["class"] = "sel";
                serverUL.Controls.Add(serverli);

                HtmlGenericControl serverli1 = new HtmlGenericControl("li");
                serverli1.Attributes["class"] = "Class-Name";
                HtmlGenericControl serverBr = new HtmlGenericControl("br");
                serverli1.InnerHtml = t["CN_Name"].ToString() + "<br/>" + "123";
                serverUL.Controls.Add(serverli1);

                HtmlGenericControl serverli2 = new HtmlGenericControl("li");
                serverli2.Attributes["class"] = "Class-num";
                HtmlAnchor NewAnchorControl = new HtmlAnchor();
                NewAnchorControl.InnerHtml = t["ID"].ToString();
                NewAnchorControl.HRef = "manage_product.html";
                serverli2.Controls.Add(NewAnchorControl);
                serverUL.Controls.Add(serverli2);

                serDiv.Controls.Add(serverUL);
                UL.Controls.Add(serDiv);
                createmenu(ds, t["ID"].ToString(), UL);
                ////生成标签a 
                //HtmlAnchor NewAnchorControl = new HtmlAnchor();
                //// 设置标签a的属性 
                //NewAnchorControl.Name = "NewAnchorControl";
                //NewAnchorControl.InnerHtml = t["CN_Name"].ToString();
                //NewAnchorControl.HRef = t["CN_Url"].ToString();
                //NewAnchorControl.Target = "_black";//设置显示的位置，这里改一下 
                //serverUL.Controls.Add(NewAnchorControl);
                //UL.Controls.Add(serverUL);
                //createmenu(ds, t["ID"].ToString(), UL);
            }
        }
    }
    
}
