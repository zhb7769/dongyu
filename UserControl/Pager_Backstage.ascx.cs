using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class UserControl_Pager_Backstage : System.Web.UI.UserControl
{
    public delegate void RefreshPage();
    private RefreshPage _refresh;
    //页显示数
    private int _PageSize = 20;
    //页总数
    private int _PageCount = 1;
    //页码
    private int _PageIndex = 1;
    //数据条数
    private int _Count = 0;
    //跳转页码
    private int _GoIndex = 0;
    //绑定类型 
    private int _BindType = 0;
    //第一条记录下标
    private int _iSindex = 1;
    //最后一条记录下标
    private int _iEindex = 20;

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
            //获得总记录数
            int iCount = value;
            //获取总页数
            int iPageCount = iCount % Int32.Parse(lb_PageSize.Text) > 0 ? iCount / Int32.Parse(lb_PageSize.Text) + 1 : iCount / Int32.Parse(lb_PageSize.Text);
            Count = iCount;//总记录数
            PageCount = iPageCount == 0 ? 1 : iPageCount;//总页数
            Console.WriteLine(Count + " " + PageCount);
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
    /// 获取或设置页数量
    /// </summary>
    public int PageCount
    {
        get { return _PageCount; }
        set
        {
            _PageCount = value;

            lb_pcount.Text = _PageCount.ToString();

        }
    }

    /// <summary>
    /// 获取或设置页码
    /// </summary>
    public int PageIndex
    {
        get
        {
            return Convert.ToInt32(lb_index.Text);
        }
        set
        {
            _PageIndex = value;
            lb_index.Text = _PageIndex.ToString();
        }
    }

    /// <summary>
    /// 获取或设置数据订单数量
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
    /// 获取或设置跳转页面
    /// </summary>
    public int GoIndex
    {
        get { return _GoIndex; }
        set { _GoIndex = value; }
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
    protected void winxpbutton1_Click(object sender, ImageClickEventArgs e)
    {        
        _PageIndex = 1;
        lb_index.Text = _PageIndex.ToString();
        _iSindex = 1;
        _iEindex = _PageIndex * Int32.Parse(lb_PageSize.Text);
        _refresh();
    }

    /// <summary>
    /// 上一页
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void winxpbutton2_Click(object sender, ImageClickEventArgs e)
    {
        int tmp = Convert.ToInt32(lb_index.Text);
        tmp = tmp - 1;
        if (tmp <= 0)
        {
            tmp = 1;
        }
        _PageIndex = tmp;
        lb_index.Text = _PageIndex.ToString();
        _iSindex = (_PageIndex - 1) * Int32.Parse(lb_PageSize.Text) + 1;
        _iEindex = _PageIndex * Int32.Parse(lb_PageSize.Text);

        _refresh();
    }

    /// <summary>
    /// 下一页
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void winxpbutton3_Click(object sender, ImageClickEventArgs e)
    {
        int tmp = Convert.ToInt32(lb_pcount.Text);
        int tmp2 = Convert.ToInt32(lb_index.Text);
        tmp2 = tmp2 + 1;
        if (tmp2 > tmp)
        {
            _PageIndex = tmp;
            lb_index.Text = tmp.ToString();
        }
        else
        {
            _PageIndex = tmp2;
            lb_index.Text = tmp2.ToString();
        }

        _iSindex = (_PageIndex - 1) * Int32.Parse(lb_PageSize.Text) + 1;
        _iEindex = _PageIndex * Int32.Parse(lb_PageSize.Text);
        _refresh();
    }

    /// <summary>
    /// 最后页
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void winxpbutton4_Click(object sender, ImageClickEventArgs e)
    {
        _PageIndex = Convert.ToInt32(lb_pcount.Text);
        lb_index.Text = lb_pcount.Text;

        _iSindex = (_PageIndex - 1) * Int32.Parse(lb_PageSize.Text) + 1;
        _iEindex = _PageIndex * Int32.Parse(lb_PageSize.Text);
        _refresh();
    }

    /// <summary>
    /// 跳转
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void winxpbutton5_Click(object sender, EventArgs e)
    {
        int tmp = 0;
        try
        {
            tmp = Convert.ToInt32(txt_Go.Text);
        }
        catch
        {
            tmp = 1;
            txt_Go.Text = "1";
        }
        if (tmp <= 0)
        {
            tmp = 1;
        }
        int tmp2 = Convert.ToInt32(lb_pcount.Text);
        if (tmp > tmp2)
        {
            _PageIndex = tmp2;
        }
        else
        {
            _PageIndex = tmp;
        }
        lb_index.Text = _PageIndex.ToString();
        txt_Go.Text = _PageIndex.ToString();
        _iSindex = (_PageIndex - 1) * Int32.Parse(lb_PageSize.Text) + 1;
        _iEindex = _PageIndex * Int32.Parse(lb_PageSize.Text);
        _refresh();
    }
    #endregion


    /// <summary>
    /// GO按钮事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void bt_go_Click(object sender, EventArgs e)
    {
        winxpbutton5_Click(null, null);
    }
}