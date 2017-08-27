<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="address.aspx.cs" Inherits="Web.address" %>
<%@ Import namespace="System.Collections.Generic" %>
<%@ Import namespace="System.Text" %>
<%@ Import namespace="System.Data" %>
<%@ Import namespace="Common" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title><%=Common.Utils.ObjectToStr(config.webname) %></title>
    <link media="screen" type="text/css" href="/templates/green/css/style.css" rel="stylesheet" />
<script type="text/javascript" src="/scripts/jquery/jquery-1.10.2.min.js"></script>
<script type="text/javascript" src="/scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
<script type="text/javascript" src="/scripts/calendar.js"></script>
<script type="text/javascript" src="/templates/green/js/base.js"></script>
<link media="screen" type="text/css" rel="stylesheet" href="/templates/green/images/jquery-ui.min.css"/>
<link media="screen" type="text/css" rel="stylesheet"  href="/templates/green/css/common.min.css"/>
<link media="screen" type="text/css" rel="stylesheet"  href="/templates/green/images/maincolor_10.css"/>
<link media="screen" type="text/css" rel="stylesheet"  href="/templates/green/images/mainplugincolor_10.css"/>
<link media="screen" type="text/css" rel="stylesheet"  href="/templates/green/images/deputycolor_0.css"/>
<link media="screen" type="text/css" rel="stylesheet"  href="/templates/green/images/bordercolor_2.css" />
<script type="text/javascript" src="/templates/green/images/jquery-ui-1.11.1.custom.min.js"></script>
<script type="text/javascript" src="/templates/green/images/common.min.js"></script>
<script type="text/javascript"  src="/templates/green/images/jquery.filedownload.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="main">
            <div id="store_header">
                <div class="header">
                    <div class="header_tt">
                       <script type="text/javascript">
                           $.ajax({
                               type: "POST",
                               url: "/tools/submit_ajax.ashx?action=user_check_login",
                               dataType: "json",
                               timeout: 20000,
                               success: function (data, textStatus) {
                                   if (data.status == 1) {
                                       $("#menu").append('<li><a href="/usercenter.aspx?action=exit">' + Resources.lang.logout + '</a></li>');
                                       $("#menu").append('<li><a href="/usercenter.aspx?action=index">' + Resources.lang.membercentre + '</a></li>');
                                   } else {
                                       $("#menu").append('<li><a href="/register.aspx">' + Resources.lang.register + '</a></li>');
                                       $("#menu").append('<li><a href="/login.aspx">' + Resources.lang.login + '</a></li>');
                                   }
                               }
                           });
    </script>
                        <ul class="header_login" id="menu">
                      <li><a href="/content.aspx?page=lianxiwomen"><asp:Literal runat="server" Text="<%$ Resources:lang,contactus%>" /></a></li>
                            <li><a href="/usercenter.aspx?action=exit"><asp:Literal runat="server" Text="<%$ Resources:lang,logout%>" /></a></li>
                            <li><a href="/usercenter.aspx?action=index"><asp:Literal runat="server" Text="<%$ Resources:lang,membercentre%>" /></a></li>

                        </ul>
                    </div>
                </div>
                <div id="header_content_box">
                    <div id="header_content">
                    </div>
                </div>
                <div class="header_style0">
                    <div class="header_logo_content">
                        <div class="header_logo_gox">
                            <ul>
                                <li class="header_logo" id="store_info_logo"><a href="index.aspx">
                                    <img title="star jade" alt="star jade" src="/templates/green/images/logo.jpg"/></a></li>
                                <li class="header_search" id="show_store_search">
                                    <div class="header_search_input patt_bg_search patt_border_search">
                                        <input name="keywords" id="keywords" autofocus="" onkeydown="if(event.keyCode==13){SiteSearch('/search.aspx', '#keywords');return false};" type="text" placeholder="<asp:Literal runat="server" Text="<%$ Resources:lang,enter%>" />" value="" x-webkit-speech="" remind="" />
                                        <a onclick="SiteSearch('/search.aspx', '#keywords');">
                                            <p class="patt_font_search" id="search_button"><asp:Literal runat="server" Text="<%$ Resources:lang,search%>" /></p>
                                        </a>
                                    </div>
                                </li>
                                <li class="header_ad" id="store_info_ad">
                                    <ul>
                                        <%--	<li class="ad_phone_photo"><img src="/templates/green/images/ad_photo.png"></li>
										<li class="ad_phone">0048-787247870</li>--%>
                                    </ul>
                                </li>
                            </ul>
                        </div>
                    </div>
                    <div class="header_navbox patt_bg_nav">
                        <div class="header_nav">
                            <div class="header_sort patt_bg_sort">
                                &nbsp;
						
                                <span><asp:Literal runat="server" Text="<%$ Resources:lang,goodtype%>" /></span>
                               
                              
                            </div>
                            <div class="header_sortnav" id="show_store_menu">
                                <ul class="menu_hot">
                                       <%
                                   HttpCookie cookie = HttpContext.Current.Request.Cookies["lang"];
                              string lang = cookie != null ? cookie.Value : "pl-PL";
      
                                           DataTable category_list33 = get_category_child_list("goods", 0);

                                           int cdr33__loop__id = 0;
                                            foreach (DataRow cdr33 in category_list33.Rows)
                                            {
                                            cdr33__loop__id++;

                                           %>
                                    <li class="class1 nav_style1_content_li" id="6461"><p class="nav_p"><a target="_parent"  href="<%    Response.Write(linkurl("goods_list", Utils.ObjectToStr(cdr33["id"]))); %>">
                                  
                                         <% if (lang.Equals("pl-PL"))
                                            {
                                               Response.Write(Utils.ObjectToStr(cdr33["seo_title"]));
                                            }
                                            else
                                            {
                                                Response.Write(Utils.ObjectToStr(cdr33["title"]));
                                            } 
                                            %>
                                        </a></p></li>
                                      <% 
                                      }
                                       %>
                                  </ul>
                            </div>
                            <div class="header_cart_box">
                                <%
                                    Model.users userModel = new Web.UI.BasePage().GetUserInfo();
                                            if (userModel == null)   {      %>
                                <div class="header_cart"><a  href="/shopping.aspx?action=cart">购物车<script src="/tools/submit_ajax.ashx?action=view_cart_count" type="text/javascript"></script>件</a></div>
                                  <% }else{%>
                                 <div class="header_cart"><a style="font-size:5px" href="/shoppingNew.aspx?action=cart"><asp:Literal runat="server" Text="<%$ Resources:lang,settle%>" /></a></div>
                                 <% }%>
                                <div class="small_cart"></div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="header_subclass">

              

 


       
                    </div>






                </div>
            </div>
       
        <div style="height: 10px;"></div>
    <div  class="boxwrap">
        <div class="left180">
    <!--Sidebar-->
        <div class="sidebar">
      <h3><asp:Literal runat="server" Text="<%$ Resources:lang,Transaction%>" /></h3>
      <ul>
        <li><a href="/userorder.aspx?action=list"><asp:Literal runat="server" Text="<%$ Resources:lang,torder%>" /></a></li>
        <li><a href="/userorder.aspx?action=close"><asp:Literal runat="server" Text="<%$ Resources:lang,closeorder%>" /></a></li>
      </ul>
      <h3><asp:Literal runat="server" Text="<%$ Resources:lang,AccountM%>" /></h3>
      <ul>
        <li><a href="/useramount.aspx?action=recharge"><asp:Literal runat="server" Text="<%$ Resources:lang,Balance%>" /></a></li>
        <li><a href="/usermessage.aspx?action=system"><asp:Literal runat="server" Text="<%$ Resources:lang,SMS%>" /></a></li>
        <li><a href="/usercenter.aspx?action=invite"><asp:Literal runat="server" Text="<%$ Resources:lang,Invitation%>" /></a></li>
      </ul>
      <h3><asp:Literal runat="server" Text="<%$ Resources:lang,basic%>" /></h3>
      <ul>
        <li><a href="/usercenter.aspx?action=proinfo"><asp:Literal runat="server" Text="<%$ Resources:lang,information%>" /></a></li>
        <li><a href="/usercenter.aspx?action=address"><asp:Literal runat="server" Text="<%$ Resources:lang,ShippingAddress%>" /></a></li>
        <li><a href="/shoplist.aspx"><asp:Literal runat="server" Text="<%$ Resources:lang,shopm%>" /></a></li>
        <li><a href="/usercenter.aspx?action=password"><asp:Literal runat="server" Text="<%$ Resources:lang,changePSD%>" /></a></li>
        <li><a href="/usercenter.aspx?action=exit"><asp:Literal runat="server" Text="<%$ Resources:lang,logout%>" /></a></li>
      </ul>
    </div>
    <!--/Sidebar-->
  </div>
        <div class="right757">
      <%-- <form name="info_form" id="info_form" url="/tools/submit_ajax.ashx?action=user_info_edit">--%>
    <h1 class="main_tit">
      <span><a href="/usercenter.aspx?action=index"><asp:Literal runat="server" Text="<%$ Resources:lang,mhome%>" /></a></span>
      <asp:Literal runat="server" Text="<%$ Resources:lang,ShippingAddress%>" />
      <strong>Address</strong>
    </h1>
    

          <div class="form_box">
    <dl>
    <dt><asp:Literal runat="server" Text="<%$ Resources:lang,Receiver%>" />：</dt>
        <dd><asp:TextBox runat="server" CssClass="input" name="txtNickName" id="txtNickName"  datatype="*" sucmsg=" " > </asp:TextBox> </dd>
      </dl>
        <dl>
        <dt> <asp:Literal runat="server" Text="<%$ Resources:lang,ContactNo%>" />：</dt>
        <dd><asp:TextBox runat="server" CssClass="input"  name="txtTelphone" id="txtTelphone" datatype="*" sucmsg=" " > </asp:TextBox> </dd>
      </dl>
      <dl>
        <dt><asp:Literal runat="server" Text="<%$ Resources:lang,phoneNo%>" />：</dt>
        <dd><asp:TextBox runat="server" CssClass="input"  name="txtMobile" id="txtMobile" > </asp:TextBox></dd>
      </dl>
                <dl>
        <dt><asp:Literal runat="server" Text="<%$ Resources:lang,city%>" />：</dt>
        <dd><asp:TextBox runat="server" CssClass="input" width="250px" name="txtCity" id="txtCity" > </asp:TextBox></dd>
      </dl>
   <dl>
        <dt><asp:Literal runat="server" Text="<%$ Resources:lang,ShippingAddress%>" />：</dt>
        <dd><asp:TextBox runat="server" CssClass="input" width="250px" name="txtAddress" id="txtAddress" > </asp:TextBox></dd>
      </dl>
               <dl>
        <dt><asp:Literal runat="server" Text="<%$ Resources:lang,zipCode%>" />：</dt>
        <dd><asp:TextBox runat="server" CssClass="input" width="250px" name="txtPost" id="txtPost" > </asp:TextBox></dd>
      </dl>
        <dl>
            <dt></dt>
             <dd><asp:Label runat="server" name="txtMessage" id="txtMessage" Text=""></asp:Label></dd>
        </dl>
      <dl>
        <dt></dt>
        <dd> <asp:Button ID="btnSubmit" runat="server" Text="<%$ Resources:lang,Submits%>" CssClass="btn" onclick="btnSubmit_Click" /></dd>
      </dl>
    </div>
   <%-- </form>--%>
            </div>
    </div>
      
    </form>
</body>
</html>
