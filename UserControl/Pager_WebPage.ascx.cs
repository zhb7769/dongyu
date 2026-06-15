using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class UserControl_Pager_WebPage : System.Web.UI.UserControl
{
    public delegate void RefreshPage();
    private RefreshPage _refresh;
    //页显示数
    private int _PageSize = 15;
    //页总数
    private int _PageCount = 1;
    //页码
    private int _PageIndex = 1;
    //数据条数
    private int _Count = 0;
    //绑定类型 
    private int _BindType = 0;
    //第一条记录下标
    private int _iSindex = 1;
    //最后一条记录下标
    private int _iEindex = 15;

    //总数据集
    private DataTable _dt_Tmp;

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    #region 属性
    /// <summary>
    /// 设置总数据集，用来计算总数据行数与总页数
    /// </summary>
    public int SetPageNum
    {
        set
        {
            setShowPageAll();
            //获得总记录数
            int iCount = value;
            //获取总页数
            int iPageCount = iCount % Int32.Parse(lb_PageSize.Text) > 0 ? iCount / Int32.Parse(lb_PageSize.Text) + 1 : iCount / Int32.Parse(lb_PageSize.Text);
            Count = iCount;//总记录数
            PageCount = iPageCount == 0 ? 1 : iPageCount;//总页数

            setShowPage(PageCount);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    private void setShowPageAll()
    {
        //LinkButton2.CssClass = "show";
        //LinkButton3.CssClass = "show";
        //LinkButton4.CssClass = "show";
        //LinkButton5.CssClass = "show";
        //LinkButton6.CssClass = "show";

    }

    /// <summary>
    /// 获取或设置页显示数量
    /// </summary>
    public int PageSize
    {
        get { return _PageSize; }
        set
        {
            _PageSize = value;
            lb_PageSize.Text = _PageSize.ToString();
        }
    }

    /// <summary>
    /// 获取或设置数据数量
    /// </summary>
    public int Count
    {
        get { return _Count; }
        set
        {
            _Count = value;
            lb_iCount.Text = _Count.ToString();
        }
    }

    /// <summary>
    /// 获取或设置页数量
    /// </summary>
    public int PageCount
    {
        get { return _PageCount; }
        set
        {
            _PageCount = value;
            lb_pcount.Text = _PageCount.ToString();
            setShowPage(_PageCount); // 设置页数显示
        }
    }

    /// <summary>
    /// 获取或设置页码
    /// </summary>
    public int PageIndex
    {
        get { return _PageIndex; }
        set
        {
            _PageIndex = value;
            lb_index.Text = _PageIndex.ToString();
            int pageNum = Convert.ToInt32(lb_pcount.Text);
            setShowPage(pageNum, _PageIndex); // 调整显示页数
        }
    }

    /// <summary>
    /// 设置页数显示，最多6页
    /// </summary>
    private void setShowPage(int pageNum)
    {
        if (pageNum == 1)
        {
            LinkButton1.Attributes.Remove("style");
            LinkButton1.Visible = true;
            LinkButton2.Visible = false;
            LinkButton3.Visible = false;
            LinkButton4.Visible = false;
            LinkButton5.Visible = false;
            LinkButton6.Visible = false;
            //LinkButton2.Attributes.Add("style", "display:none;");
            //LinkButton3.Attributes.Add("style", "display:none;");
            //LinkButton4.Attributes.Add("style", "display:none;");
            //LinkButton5.Attributes.Add("style", "display:none;");
            //LinkButton6.Attributes.Add("style", "display:none;");
        }
        else if (pageNum == 2)
        {
            LinkButton1.Attributes.Remove("style");
            LinkButton2.Attributes.Remove("style");
            //LinkButton3.Attributes.Add("style", "display:none;");
            //LinkButton4.Attributes.Add("style", "display:none;");
            //LinkButton5.Attributes.Add("style", "display:none;");
            //LinkButton6.Attributes.Add("style", "display:none;");
            LinkButton1.Visible = true;
            LinkButton2.Visible = true;
            LinkButton3.Visible = false;
            LinkButton4.Visible = false;
            LinkButton5.Visible = false;
            LinkButton6.Visible = false;
        }
        else if (pageNum == 3)
        {
            LinkButton1.Attributes.Remove("style");
            LinkButton2.Attributes.Remove("style");
            LinkButton3.Attributes.Remove("style");
            //LinkButton4.Attributes.Add("style", "display:none;");
            //LinkButton5.Attributes.Add("style", "display:none;");
            //LinkButton6.Attributes.Add("style", "display:none;");
            LinkButton1.Visible = true;
            LinkButton2.Visible = true;
            LinkButton3.Visible = true;
            LinkButton4.Visible = false;
            LinkButton5.Visible = false;
            LinkButton6.Visible = false;
        }
        else if (pageNum == 4)
        {
            LinkButton1.Attributes.Remove("style");
            LinkButton2.Attributes.Remove("style");
            LinkButton3.Attributes.Remove("style");
            LinkButton4.Attributes.Remove("style");
            //LinkButton5.Attributes.Add("style", "display:none;");
            //LinkButton6.Attributes.Add("style", "display:none;");
            LinkButton1.Visible = true;
            LinkButton2.Visible = true;
            LinkButton3.Visible = true;
            LinkButton4.Visible = true;
            LinkButton5.Visible = false;
            LinkButton6.Visible = false;
        }
        else if (pageNum == 5)
        {
            LinkButton1.Attributes.Remove("style");
            LinkButton2.Attributes.Remove("style");
            LinkButton3.Attributes.Remove("style");
            LinkButton4.Attributes.Remove("style");
            LinkButton5.Attributes.Remove("style");
            //LinkButton6.Attributes.Add("style", "display:none;");
            LinkButton1.Visible = true;
            LinkButton2.Visible = true;
            LinkButton3.Visible = true;
            LinkButton4.Visible = true;
            LinkButton5.Visible = true;
            LinkButton6.Visible = false;
        }
        else
        {
            LinkButton1.Attributes.Remove("style");
            LinkButton2.Attributes.Remove("style");
            LinkButton3.Attributes.Remove("style");
            LinkButton4.Attributes.Remove("style");
            LinkButton5.Attributes.Remove("style");
            LinkButton6.Attributes.Remove("style");
            LinkButton1.Visible = true;
            LinkButton2.Visible = true;
            LinkButton3.Visible = true;
            LinkButton4.Visible = true;
            LinkButton5.Visible = true;
            LinkButton6.Visible = true;
        }
    }

    /// <summary>
    /// 设置或获取当前页第一条记录的下标
    /// </summary>
    public int iSindex
    {
        get { return _iSindex; }
        set
        {
            _iSindex = value;
        }
    }

    /// <summary>
    /// 设置或获取当前页最后一条记录的下标
    /// </summary>
    public int iEindex
    {
        get { return _iEindex; }
        set
        {
            _iEindex = value;
        }
    }

    /// <summary>
    /// 获取或设置绑定类型
    /// </summary>
    public int BindType
    {
        get { return _BindType; }
        set { _BindType = value; }
    }

    /// <summary>
    /// 刷新数据
    /// </summary>
    public RefreshPage RefreshData
    {
        get { return _refresh; }
        set { _refresh = value; }
    }
    #endregion


    #region 事件
    /// <summary>
    /// 首页
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void winxpbutton1_Click(object sender, EventArgs e)
    {
        _PageIndex = 1;
        lb_index.Text = _PageIndex.ToString();

        int pageNum = Convert.ToInt32(lb_pcount.Text);
        setShowPage(pageNum, 1); // 调整显示页数

        _iSindex = 1;
        _iEindex = _PageIndex * Int32.Parse(lb_PageSize.Text);
        _refresh();
    }


    /// <summary>
    /// 尾页
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void winxpbutton2_Click(object sender, EventArgs e)
    {
        _PageIndex = Convert.ToInt32(lb_pcount.Text);
        lb_index.Text = lb_pcount.Text;

        int pageNum = Convert.ToInt32(lb_pcount.Text);
        setShowPage(pageNum, pageNum); // 调整显示页数

        _iSindex = (_PageIndex - 1) * Int32.Parse(lb_PageSize.Text) + 1;
        _iEindex = _PageIndex * Int32.Parse(lb_PageSize.Text);
        _refresh();
    }

    /// <summary>
    /// 跳转页
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void winxpbutton_Click(object sender, EventArgs e)
    {
        int pageNum = Convert.ToInt32(lb_pcount.Text); // 获取总页数
        LinkButton linkBtn = (LinkButton)sender;
        int page = Convert.ToInt32(linkBtn.Text); // 获取当前点击的页数

        setShowPage(pageNum, page); // 调整显示页数

        _PageIndex = page;
        lb_index.Text = _PageIndex.ToString();
        _iSindex = (_PageIndex - 1) * Int32.Parse(lb_PageSize.Text) + 1;
        _iEindex = _PageIndex * Int32.Parse(lb_PageSize.Text);
        _refresh();
    }

    /// <summary>
    /// 调整显示页数
    /// </summary>
    /// <param name="pageNum">总页数</param>
    /// <param name="page">当前页数</param>
    private void setShowPage(int pageNum, int page)
    {
        LinkButton1.CssClass = "";
        LinkButton2.CssClass = "";
        LinkButton3.CssClass = "";
        LinkButton4.CssClass = "";
        LinkButton5.CssClass = "";
        LinkButton6.CssClass = "";
        if (pageNum > 6)
        {
            int diff = pageNum - page;
            if (diff > 0)
            {
                if (page == 1)
                {
                    LinkButton1.Text = page.ToString();
                    LinkButton2.Text = (page + 1).ToString();
                    LinkButton3.Text = (page + 2).ToString();
                    LinkButton4.Text = (page + 3).ToString();
                    LinkButton5.Text = (page + 4).ToString();
                    LinkButton6.Text = (page + 5).ToString();
                    LinkButton1.CssClass = "act";
                }
                else if (page == 2)
                {
                    LinkButton1.Text = (page - 1).ToString();
                    LinkButton2.Text = page.ToString();
                    LinkButton3.Text = (page + 1).ToString();
                    LinkButton4.Text = (page + 2).ToString();
                    LinkButton5.Text = (page + 3).ToString();
                    LinkButton6.Text = (page + 4).ToString();
                    LinkButton2.CssClass = "act";
                }
                else if (page > 2)
                {
                    if (diff > 2)
                    {
                        LinkButton1.Text = (page - 2).ToString();
                        LinkButton2.Text = (page - 1).ToString();
                        LinkButton3.Text = page.ToString();
                        LinkButton4.Text = (page + 1).ToString();
                        LinkButton5.Text = (page + 2).ToString();
                        LinkButton6.Text = (page + 3).ToString();
                        LinkButton3.CssClass = "act";
                    }
                    else if (diff == 2)
                    {
                        LinkButton1.Text = (page - 3).ToString();
                        LinkButton2.Text = (page - 2).ToString();
                        LinkButton3.Text = (page - 1).ToString();
                        LinkButton4.Text = page.ToString();
                        LinkButton5.Text = (page + 1).ToString();
                        LinkButton6.Text = (page + 2).ToString();
                        LinkButton4.CssClass = "act";
                    }
                    else if (diff == 1)
                    {
                        LinkButton1.Text = (page - 4).ToString();
                        LinkButton2.Text = (page - 3).ToString();
                        LinkButton3.Text = (page - 2).ToString();
                        LinkButton4.Text = (page - 1).ToString();
                        LinkButton5.Text = page.ToString();
                        LinkButton6.Text = (page + 1).ToString();
                        LinkButton5.CssClass = "act";
                    }
                }
            }
            else
            {
                LinkButton1.Text = (page - 5).ToString();
                LinkButton2.Text = (page - 4).ToString();
                LinkButton3.Text = (page - 3).ToString();
                LinkButton4.Text = (page - 2).ToString();
                LinkButton5.Text = (page - 1).ToString();
                LinkButton6.Text = page.ToString();
                LinkButton6.CssClass = "act";
            }
        }
        else
        {
            switch (page)
            {
                case 1: LinkButton1.CssClass = "act"; break;
                case 2: LinkButton2.CssClass = "act"; break;
                case 3: LinkButton3.CssClass = "act"; break;
                case 4: LinkButton4.CssClass = "act"; break;
                case 5: LinkButton5.CssClass = "act"; break;
                case 6: LinkButton6.CssClass = "act"; break;
                default: break;
            }
        }
    }
    #endregion
}