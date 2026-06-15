<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Seo.aspx.cs" Inherits="admin_seo_Seo" %>

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
            <div class="Showpath">网站管理平台 > <span class="guide-txt">网站优化</span></div>
            <div class="add-main">
                <div class="guide">
                    <ul class="ul-nav02">
                        <li class="hover">网站优化</li>
                        <%--<li class="hover" id="Tab-home">网站首页</li>
                        <li id="Tab-about">公司简介</li>
                        <li id="Tab-pro">产品展示</li>
                        <li id="Tab-news">新闻动态</li>
                        <li id="Tab-load">下载中心</li>
                        <li id="Tab-message">在线咨询</li>
                        <li id="Tab-contact">联系我们</li>--%>
                        <div class="clear"></div>
                    </ul>
                </div>
                <div>
                    <div class="add-main-w" style="display: block" id="Tab-home-con">
                        <div class="basic">
                            <div class="fieldline">
                                <div class="c1">中文标题</div>
                                <div class="c2">
                                    <asp:TextBox ID="txt_Home_CNTitle" runat="server" CssClass="i-a06"></asp:TextBox></div>
                                <div class="clear"></div>
                            </div>
                            <div class="fieldline">
                                <div class="c1">英文标题</div>
                                <div class="c2">
                                    <asp:TextBox ID="txt_Home_ENTitle" runat="server" CssClass="i-a06"></asp:TextBox></div>
                                <div class="clear"></div>
                            </div>
                            <div class="fieldline">
                                <div class="c1">中文描述</div>
                                <div class="c2">
                                    <asp:TextBox ID="txt_Home_CNDescription" runat="server" CssClass="i-a06"></asp:TextBox></div>
                                <div class="clear"></div>
                            </div>
                            <div class="fieldline">
                                <div class="c1">英文描述</div>
                                <div class="c2">
                                    <asp:TextBox ID="txt_Home_ENDescription" runat="server" CssClass="i-a06"></asp:TextBox></div>
                                <div class="clear"></div>
                            </div>
                            <div class="fieldline">
                                <div class="c1">中文关键字</div>
                                <div class="c2">
                                    <asp:TextBox ID="txt_Home_CNKeywords" runat="server" CssClass="i-a06"></asp:TextBox></div>
                                <div class="clear"></div>
                            </div>
                            <div class="fieldline">
                                <div class="c1">英文关键字</div>
                                <div class="c2">
                                    <asp:TextBox ID="txt_Home_ENKeywords" runat="server" CssClass="i-a06"></asp:TextBox></div>
                                <div class="clear"></div>
                            </div>
                        </div>
                        <div class="btn-class">
                            <asp:Button ID="btnHome" runat="server" Text="确定" CssClass="class-btn" 
                                onclick="btnHome_Click" />
                        </div>
                    </div>
                    <%--<div class="add-main-w" id="Tab-about-con">
                        <div class="basic">
                            <div class="fieldline">
                                <div class="c1">中文标题</div>
                                <div class="c2">
                                    <asp:TextBox ID="txt_About_CNTitle" runat="server" CssClass="i-a06"></asp:TextBox></div>
                                <div class="clear"></div>
                            </div>
                            <div class="fieldline">
                                <div class="c1">
                                    英文标题</div>
                                <div class="c2">
                                    <input class="i-a06" type="text" value="" /></div>
                                <div class="clear">
                                </div>
                            </div>
                            <div class="fieldline">
                                <div class="c1">
                                    中文描述</div>
                                <div class="c2">
                                    <input class="i-a06" type="text" value="" /></div>
                                <div class="clear">
                                </div>
                            </div>
                            <div class="fieldline">
                                <div class="c1">
                                    英文描述</div>
                                <div class="c2">
                                    <input class="i-a06" type="text" value="" /></div>
                                <div class="clear">
                                </div>
                            </div>
                            <div class="fieldline">
                                <div class="c1">
                                    中文关键字</div>
                                <div class="c2">
                                    <input class="i-a06" type="text" value="" /></div>
                                <div class="clear">
                                </div>
                            </div>
                            <div class="fieldline">
                                <div class="c1">
                                    英文关键字</div>
                                <div class="c2">
                                    <input class="i-a06" type="text" value="" /></div>
                                <div class="clear">
                                </div>
                            </div>
                        </div>
                        <div class="btn-class">
                            <input type="button" class="class-btn" value="确定" />
                        </div>
                    </div>
                    <div class="add-main-w" id="Tab-pro-con">
                        <div class="basic">
                            <div class="fieldline">
                                <div class="c1">
                                    中文标题</div>
                                <div class="c2">
                                    <input class="i-a06" type="text" value="" /></div>
                                <div class="clear">
                                </div>
                            </div>
                            <div class="fieldline">
                                <div class="c1">
                                    英文标题</div>
                                <div class="c2">
                                    <input class="i-a06" type="text" value="" /></div>
                                <div class="clear">
                                </div>
                            </div>
                            <div class="fieldline">
                                <div class="c1">
                                    中文描述</div>
                                <div class="c2">
                                    <input class="i-a06" type="text" value="" /></div>
                                <div class="clear">
                                </div>
                            </div>
                            <div class="fieldline">
                                <div class="c1">
                                    英文描述</div>
                                <div class="c2">
                                    <input class="i-a06" type="text" value="" /></div>
                                <div class="clear">
                                </div>
                            </div>
                            <div class="fieldline">
                                <div class="c1">
                                    中文关键字</div>
                                <div class="c2">
                                    <input class="i-a06" type="text" value="" /></div>
                                <div class="clear">
                                </div>
                            </div>
                            <div class="fieldline">
                                <div class="c1">
                                    英文关键字</div>
                                <div class="c2">
                                    <input class="i-a06" type="text" value="" /></div>
                                <div class="clear">
                                </div>
                            </div>
                        </div>
                        <div class="btn-class">
                            <input type="button" class="class-btn" value="确定" />
                        </div>
                    </div>
                    <div class="add-main-w" id="Tab-news-con">
                        <div class="basic">
                            <div class="fieldline">
                                <div class="c1">
                                    中文标题</div>
                                <div class="c2">
                                    <input class="i-a06" type="text" value="" /></div>
                                <div class="clear">
                                </div>
                            </div>
                            <div class="fieldline">
                                <div class="c1">
                                    英文标题</div>
                                <div class="c2">
                                    <input class="i-a06" type="text" value="" /></div>
                                <div class="clear">
                                </div>
                            </div>
                            <div class="fieldline">
                                <div class="c1">
                                    中文描述</div>
                                <div class="c2">
                                    <input class="i-a06" type="text" value="" /></div>
                                <div class="clear">
                                </div>
                            </div>
                            <div class="fieldline">
                                <div class="c1">
                                    英文描述</div>
                                <div class="c2">
                                    <input class="i-a06" type="text" value="" /></div>
                                <div class="clear">
                                </div>
                            </div>
                            <div class="fieldline">
                                <div class="c1">
                                    中文关键字</div>
                                <div class="c2">
                                    <input class="i-a06" type="text" value="" /></div>
                                <div class="clear">
                                </div>
                            </div>
                            <div class="fieldline">
                                <div class="c1">
                                    英文关键字</div>
                                <div class="c2">
                                    <input class="i-a06" type="text" value="" /></div>
                                <div class="clear">
                                </div>
                            </div>
                        </div>
                        <div class="btn-class">
                            <input type="button" class="class-btn" value="确定" />
                        </div>
                    </div>
                    <div class="add-main-w" id="Tab-load-con">
                        <div class="basic">
                            <div class="fieldline">
                                <div class="c1">
                                    中文标题</div>
                                <div class="c2">
                                    <input class="i-a06" type="text" value="" /></div>
                                <div class="clear">
                                </div>
                            </div>
                            <div class="fieldline">
                                <div class="c1">
                                    英文标题</div>
                                <div class="c2">
                                    <input class="i-a06" type="text" value="" /></div>
                                <div class="clear">
                                </div>
                            </div>
                            <div class="fieldline">
                                <div class="c1">
                                    中文描述</div>
                                <div class="c2">
                                    <input class="i-a06" type="text" value="" /></div>
                                <div class="clear">
                                </div>
                            </div>
                            <div class="fieldline">
                                <div class="c1">
                                    英文描述</div>
                                <div class="c2">
                                    <input class="i-a06" type="text" value="" /></div>
                                <div class="clear">
                                </div>
                            </div>
                            <div class="fieldline">
                                <div class="c1">
                                    中文关键字</div>
                                <div class="c2">
                                    <input class="i-a06" type="text" value="" /></div>
                                <div class="clear">
                                </div>
                            </div>
                            <div class="fieldline">
                                <div class="c1">
                                    英文关键字</div>
                                <div class="c2">
                                    <input class="i-a06" type="text" value="" /></div>
                                <div class="clear">
                                </div>
                            </div>
                        </div>
                        <div class="btn-class">
                            <input type="button" class="class-btn" value="确定" />
                        </div>
                    </div>
                    <div class="add-main-w" id="Tab-message-con">
                        <div class="basic">
                            <div class="fieldline">
                                <div class="c1">
                                    中文标题</div>
                                <div class="c2">
                                    <input class="i-a06" type="text" value="" /></div>
                                <div class="clear">
                                </div>
                            </div>
                            <div class="fieldline">
                                <div class="c1">
                                    英文标题</div>
                                <div class="c2">
                                    <input class="i-a06" type="text" value="" /></div>
                                <div class="clear">
                                </div>
                            </div>
                            <div class="fieldline">
                                <div class="c1">
                                    中文描述</div>
                                <div class="c2">
                                    <input class="i-a06" type="text" value="" /></div>
                                <div class="clear">
                                </div>
                            </div>
                            <div class="fieldline">
                                <div class="c1">
                                    英文描述</div>
                                <div class="c2">
                                    <input class="i-a06" type="text" value="" /></div>
                                <div class="clear">
                                </div>
                            </div>
                            <div class="fieldline">
                                <div class="c1">
                                    中文关键字</div>
                                <div class="c2">
                                    <input class="i-a06" type="text" value="" /></div>
                                <div class="clear">
                                </div>
                            </div>
                            <div class="fieldline">
                                <div class="c1">
                                    英文关键字</div>
                                <div class="c2">
                                    <input class="i-a06" type="text" value="" /></div>
                                <div class="clear">
                                </div>
                            </div>
                        </div>
                        <div class="btn-class">
                            <input type="button" class="class-btn" value="确定" />
                        </div>
                    </div>
                    <div class="add-main-w" id="Tab-contact-con">
                        <div class="basic">
                            <div class="fieldline">
                                <div class="c1">
                                    中文标题</div>
                                <div class="c2">
                                    <input class="i-a06" type="text" value="" /></div>
                                <div class="clear">
                                </div>
                            </div>
                            <div class="fieldline">
                                <div class="c1">
                                    英文标题</div>
                                <div class="c2">
                                    <input class="i-a06" type="text" value="" /></div>
                                <div class="clear">
                                </div>
                            </div>
                            <div class="fieldline">
                                <div class="c1">
                                    中文描述</div>
                                <div class="c2">
                                    <input class="i-a06" type="text" value="" /></div>
                                <div class="clear">
                                </div>
                            </div>
                            <div class="fieldline">
                                <div class="c1">
                                    英文描述</div>
                                <div class="c2">
                                    <input class="i-a06" type="text" value="" /></div>
                                <div class="clear">
                                </div>
                            </div>
                            <div class="fieldline">
                                <div class="c1">
                                    中文关键字</div>
                                <div class="c2">
                                    <input class="i-a06" type="text" value="" /></div>
                                <div class="clear">
                                </div>
                            </div>
                            <div class="fieldline">
                                <div class="c1">
                                    英文关键字</div>
                                <div class="c2">
                                    <input class="i-a06" type="text" value="" /></div>
                                <div class="clear">
                                </div>
                            </div>
                        </div>
                        <div class="btn-class">
                            <input type="button" class="class-btn" value="确定" />
                        </div>
                    </div>--%>
                </div>
            </div>
        </div>
        <div class="clear"></div>
    </div>
    </form>

<script language="javascript" type="text/javascript">
$(".nav-item li h1").click(function(){
  $(this).siblings().slideDown("fast");
  $(this).parent().siblings().find(".nav-item02").slideUp("fast");
})

guide=$(".guide-txt").text()
for(var i=0;i<9;i++)
{
    if($('.nav-item li h1 a:eq('+i+')').text()==guide)
    {	
      $('.nav-item li h1 a:eq('+i+')').parent().siblings().show()
    }
}
$(".ul-nav02 li").click(function(){											
  loca=$(this).attr("id")+"-con";				
  $("#"+loca).show();
  $("#"+loca).siblings().hide();

  $(this).addClass("hover");
  $(this).siblings().removeClass("hover");
})

</script>

</body>
</html>
