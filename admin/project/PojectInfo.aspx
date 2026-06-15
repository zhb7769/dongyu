<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PojectInfo.aspx.cs" Inherits="admin_project_PojectInfo" %>
<%@ Register Src="../userControl/Top.ascx" TagName="Top" TagPrefix="uc1" %>
<%@ Register Src="../userControl/Memu.ascx" TagName="Memu" TagPrefix="uc2" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>后台管理</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../css/css.css" rel="stylesheet" type="text/css" />
    <link href="../css/layout.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="../js/jquery.min.js"></script>
    <script src="../../DatePicker/WdatePicker.js" type="text/javascript"></script>
</head>
<body>
        <form id="form1" runat="server">
    <!--header begin-->
    <uc1:Top ID="Top1" runat="server" />
    <!--header end-->
    <!--container begin -->
    <div id="content">
        <!--leftbar begin-->
        <uc2:Memu ID="Memu1" runat="server" />
        <!--leftbar end-->
        <div class="Main">
            <div class="Showpath">
                网站管理平台 > <span class="guide-txt">案例管理</span></div>
            <!--欢迎及上次登录 开始-->
            <div class="add-main">
                <div class="guide">
                    <ul class="ul-nav02">
                        <li class="hover1">添加案例</li>
                        <div class="clear">
                        </div>
                    </ul>
                </div>
                <div class="add-main-w">
                <asp:Label ID="lblMsg" runat="server" Text="" ForeColor="Red"></asp:Label>
                    <div class="basic">
                        <div class="fieldline">
                            <div class="c1">
                                案例标题（中）</div> 
                            <div class="c2">
                                <asp:TextBox ID="txtCN_Title" CssClass="i-a" runat="server"></asp:TextBox></div>
                            <div class="c1">
                                案例标题（英）</div>
                            <div class="c2">
                                <asp:TextBox ID="txtEN_Title" CssClass="i-a" runat="server"></asp:TextBox></div>
                            <div class="clear">
                            </div>
                        </div>
                        <div class="fieldline">
                            <div class="c1">
                                排 序</div>
                            <div class="c2">
                                <asp:TextBox ID="txtSort" CssClass="i-a05" runat="server" onkeypress="return isNumber(event);"></asp:TextBox></div>
                                <asp:CheckBox ID="ckbHomeShow" runat="server" CssClass="i-a-tj" /><span class="c2 m-r">首页推荐</span>
                            <div class="clear">
                            </div>
                        </div>
                        <div>
                            <div class="f-l">
                                <div class="fieldline">
                                    <div class="c1">
                                        上传图片
                                    </div>
                                    <div class="c2">
                                        <asp:TextBox ID="txtPic_Url" CssClass="i-a" runat="server"></asp:TextBox></div>
                                    <div class="c2">
                                        <asp:FileUpload ID="FileUpload1" runat="server" CssClass="i-a" />&nbsp;<asp:Button
                                            ID="btnPic_Url" runat="server" Text="上 传" CssClass="class-btn" 
                                            onclick="btnPic_Url_Click"  /></div>
                                    <div class="clear"> </div>
                                    <div class="article-img">
                                    <asp:Image ID="imgPic_Url" runat="server" ImageUrl="~/admin/images/noneimg.gif" Width="140" Height="140" /></div>
                                  <div class="clear"> </div>
                                </div>
                                <div class="fieldline">
                                    <div class="c1">
                                        案例摘要(中)</div>
                                    <div class="c2">
                                        <asp:TextBox ID="txtCN_Summary" runat="server" TextMode="MultiLine" CssClass="Abstract"></asp:TextBox></div>
                                    <div class="clear">
                                    </div>
                                </div>
                                <div class="fieldline">
                                    <div class="c1">
                                        案例摘要(英)</div>
                                    <div class="c2">
                                        <asp:TextBox ID="txtEN_Summary" runat="server" TextMode="MultiLine" CssClass="Abstract"></asp:TextBox></div>
                                    <div class="clear">
                                    </div>
                                </div>
                            </div>
                            <div class="clear">
                            </div>
                        </div>
                        <div class="fieldline">
                            <div class="c1">
                                案例内容(中)</div>
                            <div class="c2">
                               <FCKeditorV2:FCKeditor ID="FCKeditor1" runat="server" Width="600" Height="250" ToolbarSet="Basic"></FCKeditorV2:FCKeditor>
                            <div class="clear">
                            </div>
                        </div>
                        <div class="fieldline">
                        <div class="clear">
                            </div>
                        </div>
                        <div class="fieldline">
                            <div class="c1">
                                案例内容(英)</div>
                            <div class="c2">
                                <FCKeditorV2:FCKeditor ID="FCKeditor2" runat="server" Width="600" Height="250" ToolbarSet="Basic"></FCKeditorV2:FCKeditor></div>
                            <div class="clear">
                            </div>
                        </div>
                        <div class="fieldline">
                            <div class="c1">
                                发布时间</div>
                            <div class="c2">
                                <asp:TextBox ID="txtCreateTime" CssClass="i-a04 Wdate" runat="server" onFocus="WdatePicker({isShowClear:false,readOnly:true})"></asp:TextBox></div>
                            <div class="clear">
                            </div>
                        </div>
                        <div class="fabu0412">
                            <asp:Button ID="btnOk" runat="server" Text="发 布" CssClass="btn-submit" 
                                onclick="btnOk_Click" /></div>
                    </div>
                </div>
            </div>
        </div>
        <div class="clear">
        </div>
    </div>
    <!--container end -->
    </form>
<script language="javascript" type="text/javascript">
 isNumber = function (e) {  
    if ($.browser.msie) {  
        if ( ((event.keyCode > 47) && (event.keyCode < 58)) ||  (event.keyCode == 8)  || (event.keyCode == 46)) {  
            return true;  
        } else {  
            return false;  
        }  
    } else {  
        if ( ((e.which > 47) && (e.which < 58)) ||  (e.which == 8)  || (e.which == 46 )) {  
            return true;  
        } else {  
            return false;  
        }  
    }  
}
</script>
<script language="javascript" type="text/javascript">


$(".nav-item li h1").click(function(){
	
	$(this).siblings().slideDown("fast")
	$(this).parent().siblings().find(".nav-item02").slideUp("fast")
	
	})


guide=$(".guide-txt").text()


for(var i=0;i<9;i++)
{
    if($('.nav-item li h1 a:eq('+i+')').text()==guide)
    {	
      $('.nav-item li h1 a:eq('+i+')').parent().siblings().show()
    }
}

</script>
</body>
</html>
