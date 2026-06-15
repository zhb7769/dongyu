<%@ Page Title="" Language="C#" MasterPageFile="~/en/MasterPage.master" AutoEventWireup="true" CodeFile="About.aspx.cs" Inherits="EnAbout" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="det_pb">
        <div class="all_ban top_about">
            <div class="main_bgc">
                <div class="tit wow bounceInLeft animated"><asp:Literal ID="ltBanTitle" runat="server"></asp:Literal></div>
                <div class="all_bantit"><a href="Index.aspx">Home</a><i>></i><span>About Dongyu</span><i>></i><span>Company Profile</span></div>
            </div>
        </div>
        <div class="det_nav">
            <ul class="w100b f_flra">
                <li><a href="About.aspx" class="act">Company Profile</a></li>
                <li><a href="AboutBase.aspx">Production Base</a></li>
                <li><a href="AboutCourse.aspx">Development History</a></li>
            </ul>
        </div>
        <div class="det_con">
            <div class="main_bgc">
                <div class="det_cpa">
                    <div class="det_tit"><asp:Literal ID="ltTitle" runat="server"></asp:Literal></div>
                    <div class="det_c">
                        <asp:Literal ID="ltContent" runat="server"></asp:Literal>
                    </div>
                    <div class="w_pb">
                        <div class="abo_con f_flra fw_w b_box b_box">
                            <div class="abo_c b_box">
                                <div class="ico ico1"></div>
                                <div class="num">3</div>
                                <div class="tit">Production Bases</div>
                            </div>
                            <div class="abo_c b_box">
                                <div class="ico ico2"></div>
                                <div class="num">180,000 Tons</div>
                                <div class="tit">Annual Steel Strip Output</div>
                            </div>
                            <div class="abo_c b_box">
                                <div class="ico ico3"></div>
                                <div class="num">20 Million Meters</div>
                                <div class="tit">Annual Hose/Pipe Output</div>
                            </div>
                            <div class="abo_c b_box">
                                <div class="ico ico4"></div>
                                <div class="num">30,000 sqm</div>
                                <div class="tit">Total Factory Area</div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
