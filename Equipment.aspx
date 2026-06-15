<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Equipment.aspx.cs" Inherits="Equipment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="det_pb">
        <div class="all_ban top_equ">
            <div class="main_bgc">
                <div class="tit wow bounceInLeft animated">工艺及设备</div>
                <div class="all_bantit"><a href="Index.aspx">首页</a><i>></i><span>工艺及设备</span></div>
            </div>
        </div>
        <div class="det_con bg_gray">
            <div class="main_bgc">
                <div class="det_cpa">
                    <div class="det_tit"><asp:Literal ID="ltProcessTitle" runat="server"></asp:Literal></div>
                    <div class="det_c">
                        <asp:Literal ID="ltProcessContent" runat="server"></asp:Literal>
                    </div>
                </div>
            </div>
        </div>
        <div class="det_con">
            <div class="main_bgc">
                <div class="det_cpa">
                    <div class="w100b">
                        <div class="det_tit"><asp:Literal ID="ltEquipTitle" runat="server"></asp:Literal></div>
                        <div class="det_c pb0">
                            除以下介绍设备外，公司还有其他大型不锈钢生产设备百余台；如750冷轧机,350冷轧机,850AGC冷轧机,550八轴连轧机，850光亮退火炉，750光亮退火炉以及750分条机，500西北精密分条机等。欢迎客户到厂参观。
                        </div>
                    </div>
                    <div class="news_list pb30">
                        <ul>
                            <asp:Repeater ID="rptEquipment" runat="server">
                                <ItemTemplate>
                                    <li>
                                        <div class="news_la">
                                            <div class="w100b f_fl_nc">
                                                <div class="news_limg equ_limg">
                                                    <img src='<%# Eval("Pic_Url") %>' alt="" />
                                                </div>
                                                <div class="news_lc">
                                                    <div class="news_lca">
                                                        <div class="news_lc_tit"><%# Eval("CN_Title") %></div>
                                                        <div class="equ_lc_con">
                                                            <%# Eval("CN_Content") %>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
