<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProductInfo.aspx.cs" Inherits="admin_product_ProductInfo" ValidateRequest="false" %>

<%@ Register Src="../userControl/Top.ascx" TagName="Top" TagPrefix="uc1" %>
<%@ Register Src="../userControl/Memu.ascx" TagName="Memu" TagPrefix="uc2" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>后台管理</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../css/css.css" rel="stylesheet" type="text/css" />
    <link href="../css/layout.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../js/jquery.min.js"></script>
<script src="../../DatePicker/WdatePicker.js" type="text/javascript"></script>
<style type="text/css">
    .clearfix { display: inline-block;vertical-align: middle;}
     .tab_imgup
     {
         width: 100%;
         margin-bottom: 10px;
     }
    .tab_imgup ul
    {
        width: 100%;
    }
    .tab_imgup ul li
    {
        width: 235px;
        height: 138px;
        overflow: hidden;
        float: left;
        margin-right: 10px;
        margin-bottom: 10px;
        border: 1px solid #eeeeee;
        position: relative;
    }
    .tab_imgup ul li img
    {
        width: 100%;
        min-height: 138px;
        display: inline-block;
        vertical-align: middle;
    }
    .tab_imgup ul li a.tab_imgup_a
    {
        width: 25px;
        height: 25px;
        display: block;
        background: url(../images/close.gif) center no-repeat;
        position: absolute;
        right: 0px;
        top: 0px;
        z-index: 50;
    }
    .tab_tebut
    {
        width: 50px;
        height: 26px;
        line-height: 26px;
        border-radius: 5px;
    }
        
    .btn_upload2
    {
        display: block;
        width: 60px;
        height: 26px;
        line-height: 26px;
        text-align: center;
        border: 1px solid #61cd66;
        border-radius: 5px;
        color: #61cd66;
        cursor: pointer;
    }
    .btn_upload2:hover
    {
        background-color: #61cd66;
        color: white;
    }
    .inp_file
    {
        width: 60px;
        height: 26px;
        display: block;
        filter: alpha(opacity=0);
        -moz-opacity: 0;
        -webkit-opacity: 0;
        -khtml-opacity: 0;
        opacity: 0;
        cursor: pointer;
    }
</style>
    <script type="text/javascript">
        var cnLeftArr = [];
        var cnRightArr = [];
        var enLeftArr = [];
        var enRightArr = [];

        function addCnValue() {
            var str = "<div class=\"fieldline\">" +
                "<div class=\"c1\">参数</div >" +
                "<div class=\"c2\">" +
                "<input type=\"text\" class=\"i-a\" name=\"cnLeft\" />" +
                "</div>" +
                "<div class=\"c2\">" +
                "<input type=\"text\" class=\"i-a\" name=\"cnRight\"/>" +
                "</div>" +
                "<div class=\"c2\">" +
                "<input type=\"button\" onclick=\"delValue(this)\" class=\"class-btn\" value=\"删除\"/>" +
                "</div>" +
                "<div class=\"clear\">" +
                "</div>" +
                "</div >";
            $("#cnValueDiv").append(str);
        }

        function addEnValue() {
            var str = "<div class=\"fieldline\">" +
                "<div class=\"c1\">参数</div >" +
                "<div class=\"c2\">" +
                "<input type=\"text\" class=\"i-a\" name=\"enLeft\" />" +
                "</div>" +
                "<div class=\"c2\">" +
                "<input type=\"text\" class=\"i-a\" name=\"enRight\"/>" +
                "</div>" +
                "<div class=\"c2\">" +
                "<input type=\"button\" onclick=\"delValue(this)\" class=\"class-btn\" value=\"删除\"/>" +
                "</div>" +
                "<div class=\"clear\">" +
                "</div>" +
                "</div >";
            $("#enValueDiv").append(str);
        }

        function delValue(obj) {
            $(obj).parent().parent().remove();
        }


        //提交前触发
        function ExSubmitValue() {
            $("input[name='cnLeft']").each(function(index, item) {
                cnLeftArr.push(item.value);
            });
            $("#hf_leftValue").val(cnLeftArr.join('~'));

            $("input[name='cnRight']").each(function (index, item) {
                cnRightArr.push(item.value);
            });
            $("#hf_rightValue").val(cnRightArr.join('~'));

            $("input[name='enLeft']").each(function (index, item) {
                enLeftArr.push(item.value);
            });
            $("#hf_enLeftValue").val(enLeftArr.join('~'));

            $("input[name='enRight']").each(function (index, item) {
                enRightArr.push(item.value);
            });
            $("#hf_enRightValue").val(enRightArr.join('~'));
        }

        //页面加载的时候触发
        $(function () {
            if ($("#hf_hf_leftValue").val() !== "") {
                console.log("进来了")
                var leftArr = $("#hf_leftValue").val().split("~");
                var rightArr = $("#hf_rightValue").val().split("~");
                var leftEnArr = $("#hf_enLeftValue").val().split("~");
                var rightEnArr = $("#hf_enRightValue").val().split("~");

                for (var i = 0; i < leftArr.length; i++) {
                    addValue(leftArr[i], rightArr[i], leftEnArr[i], rightEnArr[i]);
                }
            }
        });


        function addValue(leftValue, rightValue,leftEnValue,rightEnValue) {
            var str = "<div class=\"fieldline\">" +
                "<div class=\"c1\">参数</div >" +
                "<div class=\"c2\">" +
                "<input type=\"text\" class=\"i-a\" name=\"cnLeft\" value=\"" + leftValue + "\" />" +
                "</div>" +
                "<div class=\"c2\">" +
                "<input type=\"text\" class=\"i-a\" name=\"cnRight\" value=\"" + rightValue + "\" />" +
                "</div>" +
                "<div class=\"c2\">" +
                "<input type=\"button\" onclick=\"delValue(this)\" class=\"class-btn\" value=\"删除\"/>" +
                "</div>" +
                "<div class=\"clear\">" +
                "</div>" +
                "</div >";
            $("#cnValueDiv").append(str);

            var str1 = "<div class=\"fieldline\">" +
                "<div class=\"c1\">参数</div >" +
                "<div class=\"c2\">" +
                "<input type=\"text\" class=\"i-a\" name=\"enLeft\" value=\"" + leftEnValue + "\" />" +
                "</div>" +
                "<div class=\"c2\">" +
                "<input type=\"text\" class=\"i-a\" name=\"enRight\" value=\"" + rightEnValue + "\" />" +
                "</div>" +
                "<div class=\"c2\">" +
                "<input type=\"button\" onclick=\"delValue(this)\" class=\"class-btn\" value=\"删除\"/>" +
                "</div>" +
                "<div class=\"clear\">" +
                "</div>" +
                "</div >";
            $("#enValueDiv").append(str1);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="hf_img" runat="server" />
        <asp:HiddenField ID="hf_leftValue" runat="server" />
        <asp:HiddenField ID="hf_enLeftValue" runat="server" />
        <asp:HiddenField ID="hf_rightValue" runat="server" />
        <asp:HiddenField ID="hf_enRightValue" runat="server" />
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
                    网站管理平台 > <span class="guide-txt">产品管理</span></div>
                <!--欢迎及上次登录 开始-->
                <div class="add-main">
                    <div class="guide">
                        <ul class="ul-nav02">
                            <li class="hover1">添加产品</li>
                            <div class="clear">
                            </div>
                        </ul>
                    </div>
                    <div class="add-main-w">
                    <asp:Label ID="lblMsg" runat="server" Text="" ForeColor="Red"></asp:Label>
                        <div class="basic">
                            <div class="fieldline">
                                <div class="c1">
                                    产品分类</div>
                                <div class="c2" style="margin-right: 8px;">
                                    <asp:DropDownList ID="ddlProductClass" runat="server">
                                      <asp:ListItem Text="　　顶级分类　" Value="0"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="clear"></div>
                            </div>
                            <div class="fieldline">
                                <div class="c1">尺寸(中英)</div>
                                <div class="c2">
                                  <FCKeditorV2:FCKeditor ID="FCKeditor3"  runat="server" Width="500" Height="200" ToolbarSet="Basic"></FCKeditorV2:FCKeditor>
                                </div>
                                <div class="clear"></div>
                            </div>
                            <div class="fieldline">
                                <div class="c1">名称</div>
                                <div class="c2">
                                <asp:TextBox ID="txtCN_Name" runat="server" CssClass="i-a06"></asp:TextBox></div>
                                <div class="clear"></div>
                            </div>
                            <div class="fieldline">
                                <div class="c1">简单描述</div>
                                <div class="c2">
                                    <FCKeditorV2:FCKeditor ID="fck_CN_Label"  runat="server" Width="500" Height="200" ToolbarSet="Basic"></FCKeditorV2:FCKeditor>
                                </div>
                                <div class="clear"></div>
                            </div>
                            <div class="fieldline">
                                <div class="c1">视频链接</div>
                                <div class="c2">
                                    <FCKeditorV2:FCKeditor ID="txt_video"  runat="server" Width="500" Height="200" ToolbarSet="Basic"></FCKeditorV2:FCKeditor>
                                </div>
                                <div class="clear"></div>
                            </div>
                            <div class="fieldline">
                                <div class="c1">排 序</div>
                                <div class="c2">
                                    <asp:TextBox ID="txtSort" runat="server" CssClass="i-a05" onkeypress="return isNumber(event);" Text="0"></asp:TextBox></div>
                                    <asp:CheckBox ID="ckbIsPage" runat="server" CssClass="i-a-tj" /><span class="c2 m-r">首页推荐</span>
                                    <div style="display:none"> 
                                      <asp:CheckBox ID="ckbIsTop" runat="server" CssClass="i-a-tj" /><span class="c2 m-r">是否新产品</span></div>
                                <div class="clear"></div>
                            </div>
                            <div class="fieldline" style="display:none;">
                                <div class="c1">实物图片</div>
                                <div class="c2">
                                    <asp:TextBox ID="txtL_Img" runat="server" CssClass="i-a"></asp:TextBox></div>
                                <div class="c2">
                                    <asp:FileUpload ID="FileUpload1" CssClass="i-a" runat="server" /></div>
                                <div class="c2">
                                    <asp:Button ID="btnImg" runat="server" Text="上 传" CssClass="class-btn" onclick="btnImg_Click" /></div>
                                <div class="clear"></div>
                            </div>
                            <ul class="productimg" style="display:none;">
                               <asp:HyperLink ID="hlk" runat="server"><asp:Image ID="imgM_Img" runat="server" ImageUrl="~/admin/images/noneimg.gif" /></asp:HyperLink>
                                <div class="clear"></div>
                            </ul>
                            <div class="fieldline">
                                <div class="c1">细节图</div>
                                <div class="c2">
                                    <asp:TextBox ID="txtL_Img2" runat="server" CssClass="i-a"></asp:TextBox></div>
                                <div class="c2">
                                    <asp:FileUpload ID="FileUpload2" CssClass="i-a" runat="server" /></div>
                                <div class="c2">
                                    <asp:Button ID="bt_multiUpload" runat="server" Text="上 传" CssClass="class-btn" 
                                        onclick="bt_multiUpload_Click" /></div>
                                <div class="clear"></div>
                            </div>
                            <div class="fieldline">
                                    <div class="tab_imgup">
                                        <ul class="clearfix">
                                        <asp:Repeater runat="server" ID="rpt_img" onitemcommand="rpt_img_ItemCommand">
                                            <ItemTemplate>
                                                <li>
                                                    <img src='../../uploadfiles/product/<%#Eval("pro_img") %>' />
                                                    <asp:LinkButton ID="lb_del" runat="server" class="tab_imgup_a" CommandArgument='<%#Eval("at_id") %>' CommandName="del"></asp:LinkButton>
                                                </li>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </ul>
                                    </div>
                            </div>
                            <!--详细参数-->
                            <div id="cnValueDiv">
                            </div>
                            <div class="fabu0412">
                                <input type="button" onclick="addCnValue()" class="class-btn" value="增加参数"/>
                            </div>
                            <div class="fieldline"></div>
                            <div class="fieldline">
                                <div class="c1">
                                    产品内容</div>
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
                                    <div class="c1">名称</div>
                                    <div class="c2"><asp:TextBox ID="txtEN_Name" runat="server" CssClass="i-a06"></asp:TextBox></div>
                                    <div class="clear"></div>
                                </div>
                                <div class="fieldline">
                                    <div class="c1">简单描述</div>
                                    <div class="c2">
                                        <FCKeditorV2:FCKeditor ID="fck_EN_Label"  runat="server" Width="500" Height="200" ToolbarSet="Basic"></FCKeditorV2:FCKeditor>
                                    </div>
                                    <div class="clear"></div>
                                </div>
                                <!--详细参数-->
                                <div id="enValueDiv">
                                </div>
                                <div class="fabu0412">
                                    <input type="button" onclick="addEnValue()" class="class-btn" value="增加参数"/>
                                </div>
                                <div class="fieldline"></div>
                                <div class="fieldline">
                                    <div class="c1">
                                        产品内容</div>
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
                                <asp:Button ID="btnOk" runat="server" Text="发   布"  CssClass="btn-submit" OnClientClick="ExSubmitValue()" 
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
<script type="text/javascript">
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
            document.getElementById("<%=txtEN_Name.ClientID %>").value = document.getElementById("<%=txtCN_Name.ClientID %>").value;

            var fck1_text = FCKeditorAPI.GetInstance('<%=FCKeditor1.ClientID %>').EditorDocument.body.innerText;
            FCKeditorAPI.GetInstance('<%=FCKeditor2.ClientID %>').SetHTML(fck1_text);

            var temp = FCKeditorAPI.GetInstance('<%=fck_CN_Label.ClientID %>').EditorDocument.body.innerText;
            FCKeditorAPI.GetInstance('<%=fck_EN_Label.ClientID %>').SetHTML(temp);
      
        }
        else
        {
            document.getElementById("<%=txtEN_Name.ClientID %>").value = "";

            FCKeditorAPI.GetInstance('<%=FCKeditor2.ClientID %>').SetHTML("");

            FCKeditorAPI.GetInstance('<%=fck_EN_Label.ClientID %>').SetHTML("");
        }
    
    }
</script>
<script type="text/javascript">


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
