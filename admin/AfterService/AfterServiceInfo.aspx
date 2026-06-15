<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AfterServiceInfo.aspx.cs" Inherits="admin_AfterService_AfterServiceInfo" %>

<%@ Register Src="../userControl/Top.ascx" TagName="Top" TagPrefix="uc1" %>
<%@ Register Src="../userControl/Memu.ascx" TagName="Memu" TagPrefix="uc2" %>
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
        <uc1:Top ID="Top1" runat="server" />
        <div id="content">
            <uc2:Memu ID="Memu1" runat="server" />
            <div class="Main">
                <div class="Showpath">
                    网站管理平台 > <span class="guide-txt">售后服务管理</span>
                </div>
                <div class="add-main">
                    <div class="guide">
                        <ul class="ul-nav02">
                            <li class="hover1">售后服务查看</li>
                            <div class="clear">
                            </div>
                        </ul>
                    </div>
                    <div class="add-main-w">
                        <!--中文-->
                        <div class="basic">
                            <div class="fieldline">
                                <div class="c1">
                                    国家
                                </div>
                                <div class="c2">
                                    <input class="i-a" type="text" id="cName" runat="server" />
                                </div>
                                <div class="c1">
                                    购买日期：
                                </div>
                                <div class="c2">
                                    <asp:Literal ID="puchaseDate" runat="server"></asp:Literal>
                                </div>
                                <div class="clear">
                                </div>
                            </div>
                            <div class="fieldline">
                                <div class="c1">
                                    采购渠道
                                </div>
                                <div class="c2">
                                    <input class="i-a" type="text" id="pName" runat="server" />
                                </div>
                                <div class="c1">
                                    城市：
                                </div>
                                <div class="c2">
                                    <asp:Literal ID="city" runat="server"></asp:Literal>
                                </div>
                                <div class="clear">
                                </div>
                            </div>
                            <div class="fieldline">
                                <div class="c1">
                                    电话
                                </div>
                                <div class="c2">
                                    <input class="i-a" type="text" id="phoneNumber" runat="server" />
                                </div>
                                <div class="clear">
                                </div>
                            </div>
                            <div class="fieldline">
                                <div class="c1">
                                    订单号码
                                </div>
                                <div class="c2">
                                    <input class="i-a" type="text" id="orderNumber" runat="server" />
                                </div>
                                <div class="clear">
                                </div>
                            </div>
                            <div class="fieldline">
                                <div class="c1">
                                    产品类型
                                </div>
                                <div class="c2">
                                    <input class="i-a" type="text" id="productType" runat="server" />
                                </div>
                                <div class="clear">
                                </div>
                            </div>

                            <div class="fieldline">
                                <div class="c1">
                                    产品描述
                                </div>
                                <div class="c2">
                                    <textarea id="productDescription" class="Abstract" runat="server"></textarea>
                                </div>
                                <div class="clear">
                                </div>
                            </div>
                            <div class="fieldline">
                                <div class="c1">序列号</div>
                                <div class="c2">
                                    <asp:TextBox ID="serialNumber" runat="server" CssClass="i-a06"></asp:TextBox>
                                </div>
                                <div class="clear"></div>
                            </div>
                            <div class="fieldline">
                                <div class="c1">版本号</div>
                                <div class="c2">
                                    <asp:TextBox ID="versionNumber" runat="server" CssClass="i-a06"></asp:TextBox>
                                </div>
                                <div class="clear"></div>
                            </div>
                        </div>
                        <div class="basic">
                            <div class="fieldline">
                                <div class="c1" style="font-weight:bold">
                                    英文信息
                                </div>
                            </div>
                        </div>
                        <!--英文-->
                        <div class="basic">
                            <div class="fieldline">
                                <div class="c1">
                                    国家
                                </div>
                                <div class="c2">
                                    <input class="i-a" type="text" id="cEname" runat="server" />
                                </div>
                                <div class="clear">
                                </div>
                            </div>
                            <div class="fieldline">
                                <div class="c1">
                                    采购渠道
                                </div>
                                <div class="c2">
                                    <input class="i-a" type="text" id="pEname" runat="server" />
                                </div>
                                <div class="c1">
                                    城市：
                                </div>
                                <div class="c2">
                                    <asp:Literal ID="EN_city" runat="server"></asp:Literal>
                                </div>
                                <div class="clear">
                                </div>
                            </div>
                            <div class="fieldline">
                                <div class="c1">
                                    订单号码
                                </div>
                                <div class="c2">
                                    <input class="i-a" type="text" id="EN_orderNumber" runat="server" />
                                </div>
                                <div class="clear">
                                </div>
                            </div>
                            <div class="fieldline">
                                <div class="c1">
                                    产品类型
                                </div>
                                <div class="c2">
                                    <input class="i-a" type="text" id="EN_productType" runat="server" />
                                </div>
                                <div class="clear">
                                </div>
                            </div>

                            <div class="fieldline">
                                <div class="c1">
                                    产品描述
                                </div>
                                <div class="c2">
                                    <textarea id="EN_productDescription" class="Abstract" runat="server"></textarea>
                                </div>
                                <div class="clear">
                                </div>
                            </div>
                            <div class="fieldline">
                                <div class="c1">序列号</div>
                                <div class="c2">
                                    <asp:TextBox ID="EN_serialNumber" runat="server" CssClass="i-a06"></asp:TextBox>
                                </div>
                                <div class="clear"></div>
                            </div>
                            <div class="fieldline">
                                <div class="c1">版本号</div>
                                <div class="c2">
                                    <asp:TextBox ID="EN_versionNumber" runat="server" CssClass="i-a06"></asp:TextBox>
                                </div>
                                <div class="clear"></div>
                            </div>
                        </div>
                        <div class="btn-class" style="padding-top: 20px; display: none">
                            <asp:Button ID="btnOk" runat="server" Text="保 存" CssClass="class-btn"
                                OnClick="btnOk_Click" />
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


        $(".nav-item li h1").click(function () {

            $(this).siblings().slideDown("fast")
            $(this).parent().siblings().find(".nav-item02").slideUp("fast")

        })


        guide = $(".guide-txt").text()


        for (var i = 0; i < 9; i++) {
            if ($('.nav-item li h1 a:eq(' + i + ')').text() == guide) {
                $('.nav-item li h1 a:eq(' + i + ')').parent().siblings().show()
            }
        }

    </script>
</body>
</html>
