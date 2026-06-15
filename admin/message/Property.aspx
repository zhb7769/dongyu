<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Property.aspx.cs" Inherits="admin_message_Property" %>
<%@ Register src="../userControl/Top.ascx" tagname="Top" tagprefix="uc1" %>
<%@ Register src="../userControl/Memu.ascx" tagname="Memu" tagprefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>后台管理</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link href="../css/css.css" rel="stylesheet" type="text/css" />
<link href="../css/layout.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../js/jquery.min.js"></script>
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
    	<div class="Showpath">网站管理平台  > <span class="guide-txt">留言管理</span></div>
        <!--欢迎及上次登录 开始-->

         <div class="add-main">
          <div class="guide">
            	<ul class="ul-nav02">
                	<li ><a href="Message.aspx">留言列表</a></li>
                    <li class="hover">留言属性</li>
                    <div class="clear"></div>                                  
                </ul>
            </div>            

            
            
         <div class="add-main-w"  >
<div class="basic">
                            <div class="product_property"  >

                            <table width="600" align="left" border="0" cellpadding="0" cellspacing="0" >


                            <tr><td align="right" valign="top"><input class="property_txt_p" type="text" value=" 标题" /> ：</td><td valign="top"><input class="property_txt" type="text" value=" " /> &nbsp; <input class="property_txt_o" type="text" value="1" /> </td></tr>
                            <tr><td align="right" valign="top"><input class="property_txt_p" type="text" value=" 内容" /> ：</td><td valign="top"><input class="property_txt" type="text" value=" " />  &nbsp; <input class="property_txt_o" type="text" value="2" /></td></tr>
                            <tr><td align="right" valign="top"><input class="property_txt_p" type="text" value=" 姓名" /> ：</td><td valign="top"><input class="property_txt" type="text" value=" " />  &nbsp; <input class="property_txt_o" type="text" value="3" /></td></tr>
                            <tr><td align="right" valign="top"><input class="property_txt_p" type="text" value=" 电话" /> ：</td><td valign="top"><input class="property_txt" type="text" value=" " /> &nbsp; <input class="property_txt_o" type="text" value="4" /></td></tr>
                            <tr><td align="right" valign="top"><input class="property_txt_p" type="text" value=" 传真" /> ：</td><td valign="top"><input class="property_txt" type="text" value=" " /> &nbsp; <input class="property_txt_o" type="text" value="5" /> </td></tr>
                            <tr><td align="right" valign="top"><input class="property_txt_p" type="text" value=" 属性" /> ：</td><td valign="top"><input class="property_txt" type="text" value=" 属性值" /> <a href="">删除</a></td></tr>
                            <tr><td align="right" class="add_property"  ><a href="" class="addsx">添加留言属性</a> &nbsp;</td><td class="add_property">如果有特殊的留言要求，您可以手动添加</td></tr> </table>
 
                            </div>

</div>

                        <div class="btn-class" style="padding-top:20px;"><input type="button" class="class-btn" value="保 存" /> </div>
                        
                       <div class="basic">
                        
                         <table width="600" align="left" border="0" cellpadding="0" cellspacing="0" >
                            <tr><td valign="top"><h3><span> 注：如果英文属性不填写，默认读取中文属性信息。</span>英文信息 </h3></td></tr>

                          </table>
                         </div> 
                        
                        <div class="basic">
                            
                             <div class="product_property">
                            <table width="600" align="left" border="0" cellpadding="0" cellspacing="0" >
                            <tr><td align="right" valign="top"><input class="property_txt_p" type="text" value=" title" /> ：</td><td valign="top"><input class="property_txt" type="text" value=" " /> &nbsp; <input class="property_txt_o" type="text" value="1" /> </td></tr>
                            <tr><td align="right" valign="top"><input class="property_txt_p" type="text" value=" content" /> ：</td><td valign="top"><input class="property_txt" type="text" value=" " />  &nbsp; <input class="property_txt_o" type="text" value="2" /></td></tr>
                            <tr><td align="right" valign="top"><input class="property_txt_p" type="text" value=" name" /> ：</td><td valign="top"><input class="property_txt" type="text" value=" " />  &nbsp; <input class="property_txt_o" type="text" value="3" /></td></tr>
                            <tr><td align="right" valign="top"><input class="property_txt_p" type="text" value=" TEL." /> ：</td><td valign="top"><input class="property_txt" type="text" value=" " /> &nbsp; <input class="property_txt_o" type="text" value="4" /></td></tr>
                            <tr><td align="right" valign="top"><input class="property_txt_p" type="text" value=" FAX" /> ：</td><td valign="top"><input class="property_txt" type="text" value=" " /> &nbsp; <input class="property_txt_o" type="text" value="5" /> </td></tr>
                            <tr><td align="right" valign="top"><input class="property_txt_p" type="text" value=" 属性" /> ：</td><td valign="top"><input class="property_txt" type="text" value=" 属性值" /> <a href="">删除</a></td></tr>


                            <tr><td align="right" class="add_property"  ><a href="" class="addsx">添加留言属性</a> &nbsp;</td><td class="add_property">如果有特殊的留言要求，您可以手动添加</td></tr>
                            
                            </table>
                         
                            </div>
                        
                        </div>
                        <div class="btn-class" style="padding-top:20px;"><input type="button" class="class-btn" value="保 存" /> </div>
                </div>   
            
            
            
            
            </div>




    </div>
    <div class="clear"></div>
</div>
<!--container end -->
    </form>
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
