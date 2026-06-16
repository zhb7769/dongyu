<%@ Page Title="" Language="C#" MasterPageFile="~/en/MasterPage.master" AutoEventWireup="true" CodeFile="Equipment.aspx.cs" Inherits="EnEquipment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="det_pb">
        <div class="all_ban top_equ">
            <div class="main_bgc">
                <div class="tit wow bounceInLeft animated">Process & Equipment</div>
                <div class="all_bantit"><a href="Index.aspx">Home</a><i>></i><span>Process & Equipment</span></div>
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
                            In addition to the equipment introduced above, the company has over one hundred other large-scale stainless steel production equipment units, such as 750 cold rolling mills, 350 cold rolling mills, 850 AGC cold rolling mills, 550 eight-roll continuous rolling mills, 850 bright annealing furnaces, 750 bright annealing furnaces, 750 slitting machines, and 500 Northwest precision slitting machines. Our company sincerely welcome you to visit our factory to see more.
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
                                                    <img src='<%# string.IsNullOrEmpty(Eval("Pic_Url").ToString()) ? "" : "/uploadfiles/article/" + Eval("Pic_Url") %>' alt="" />
                                                </div>
                                                <div class="news_lc">
                                                    <div class="news_lca">
                                                        <div class="news_lc_tit"><%# Eval("EN_Title") %></div>
                                                        <div class="equ_lc_con">
                                                            <%# Eval("EN_Content") %>
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
