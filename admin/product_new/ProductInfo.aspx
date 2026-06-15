<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProductInfo.aspx.cs" Inherits="admin_product_new_ProductInfo" %>

<%@ Register Src="../userControl/Top.ascx" TagName="Top" TagPrefix="uc1" %>
<%@ Register Src="../userControl/Memu.ascx" TagName="Memu" TagPrefix="uc2" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
                网站管理平台 > <span class="guide-txt">新配件管理</span></div>
            <!--欢迎及上次登录 开始-->
            <div class="add-main">
                <div class="guide">
                    <ul class="ul-nav02">
                        <li class="hover1">添加配件</li>
                        <div class="clear">
                        </div>
                    </ul>
                </div>
                <div class="add-main-w">
                <asp:Label ID="lblMsg" runat="server" Text="" ForeColor="Red"></asp:Label>
                    <div class="basic">
                        <div class="fieldline">
                            <div class="c1">
                                配件分类</div>
                            <div class="c2" style="margin-right: 8px;">
                                <asp:DropDownList ID="ddlProductClass" runat="server">
                                  <asp:ListItem Text="　　顶级分类　" Value="0"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="clear">
                            </div>
                        </div>
                        <div class="fieldline">
                            <div class="c1">
                                配件名称</div>
                            <div class="c2">
                            <asp:TextBox ID="txtCN_Name" runat="server" CssClass="i-a06"></asp:TextBox></div>
                           <div style="display:none"> <asp:CheckBox ID="ckbIsPage" runat="server" CssClass="i-a-tj" /><span class="c2 m-r">推荐</span>
                            <asp:CheckBox ID="ckbIsTop" runat="server" CssClass="i-a-tj" /><span class="c2 m-r">是否新产品</span></div>
                            <div class="clear">
                            </div>
                        </div>
                        <div class="fieldline">
                            <div class="c1">
                                标 签</div>
                            <div class="c2">
                                <asp:TextBox ID="txtCN_Label" runat="server" CssClass="i-a"></asp:TextBox></div>
                            <div class="clear">
                            </div>
                        </div>
                        <div class="fieldline">
                            <div class="c1">
                                排 序</div>
                            <div class="c2">
                                <asp:TextBox ID="txtSort" runat="server" CssClass="i-a05" onkeypress="return isNumber(event);"></asp:TextBox></div>
                            <div class="clear">
                            </div>
                        </div>
                        <div class="fieldline">
                            <div class="c1">
                                上传图片
                            </div>
                            <div class="c2">
                                <asp:FileUpload ID="FileUpload1" CssClass="i-a" runat="server" /></div>
                            <div class="c2">
                                <asp:Button ID="btnImg" runat="server" Text="上 传" CssClass="class-btn" 
                                    onclick="btnImg_Click" /></div>
                            <div class="clear">
                            </div>
                            <asp:HiddenField ID="hfL_Img" runat="server" />
                            <asp:HiddenField ID="hfM_Img" runat="server" />
                        </div>
                        <ul class="productimg">
                           <asp:HyperLink ID="hlk" runat="server"><asp:Image ID="imgM_Img" runat="server" /></asp:HyperLink>
                            <div class="clear"></div>
                        </ul>
                        <div class="fieldline">
                            <div class="c1">
                                配件内容</div>
                            <div class="c2">
                                <FCKeditorV2:FCKeditor ID="FCKeditor1"  runat="server" Width="600" Height="250" ToolbarSet="Basic"></FCKeditorV2:FCKeditor></div>
                            <div class="clear">
                            </div>
                        </div>
                        <div class="fieldline">
                            <div class="c1">
                                发布时间</div>
                            <div class="c2">
                                <asp:TextBox ID="txtCreateTime" CssClass="i-a04 Wdate" runat="server" Width="155" onFocus="WdatePicker({isShowClear:false,readOnly:true,dateFmt:'yyyy-MM-dd HH:mm:ss'})"></asp:TextBox></div>
                            <div class="clear">
                            </div>
                        </div>
                        <h2>
                            <span class="copytext">
                                <input id="chkCopy" name="chkCopy" type="checkbox" class="i-a-tj" onclick="getChkCopy()" />
                                复制中文信息</span>英文信息 <span class="open">[ 展开↓]</span></h2>
                                
                        <div class="information_en">
                            <div class="fieldline">
                                <div class="c1">
                                    配件名称</div>
                                <div class="c2">
                                    <asp:TextBox ID="txtEN_Name" runat="server" CssClass="i-a06"></asp:TextBox></div>
                                <div class="clear">
                                </div>
                            </div>
                            <div class="fieldline">
                                <div class="c1">
                                    标 签</div>
                                <div class="c2">
                                    <asp:TextBox ID="txtEN_Label" runat="server" CssClass="i-a"></asp:TextBox></div>
                                <div class="clear">
                                </div>
                            </div>
                            <div class="fieldline">
                                <div class="c1">
                                    配件内容</div>
                                <div class="c2">
                                    <FCKeditorV2:FCKeditor ID="FCKeditor2" runat="server" Width="600" Height="250" ToolbarSet="Basic"></FCKeditorV2:FCKeditor></div>
                                <div class="clear">
                                </div>
                            </div>
                            <h2 class="lin">
                                <%--<span class="copytext">
                                    <input name="" type="checkbox" value="" class="i-a-tj" />
                                    复制中文信息</span>--%>英文信息 <span class="close">[ 关闭↑]</span></h2>
                        </div>

                        <div class="fabu0412">
                            <asp:Button ID="btnOk" runat="server" Text="发   布"  CssClass="btn-submit" 
                                onclick="btnOk_Click" /></div>
                    </div>
                </div>
            </div>
        </div>
        <div class="clear">
        </div>
    </div>
    <asp:HiddenField ID="hf" runat="server" />
    <!--container end -->
    </form>
<script type="text/javascript" language="javascript" >
 $("h2 .open").click(function(){
     $(".information_en").show("")
 })
 $("h2 .close").click(function(){
     $(".information_en").hide("")
 })
 
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

function getChkCopy(){    
  var test = document.getElementById("chkCopy").checked;   
  if(test)
    {
      document.getElementById("<%=txtEN_Name.ClientID %>").value=document.getElementById("<%=txtCN_Name.ClientID %>").value;
      document.getElementById("<%=txtEN_Label.ClientID %>").value=document.getElementById("<%=txtCN_Label.ClientID %>").value;
      var fck1_text = FCKeditorAPI.GetInstance('<%=FCKeditor1.ClientID %>').EditorDocument.body.innerText;
      FCKeditorAPI.GetInstance('<%=FCKeditor2.ClientID %>').SetHTML(fck1_text);
    }
    else
    {
      document.getElementById("<%=txtEN_Name.ClientID %>").value="";
      document.getElementById("<%=txtEN_Label.ClientID %>").value="";
      FCKeditorAPI.GetInstance('<%=FCKeditor2.ClientID %>').SetHTML("");
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
