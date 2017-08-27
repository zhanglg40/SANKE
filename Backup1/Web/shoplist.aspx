<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="shoplist.aspx.cs" Inherits="Web.shoplist" %>

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
    <link  href="css/pagination.css" rel="stylesheet" type="text/css" />
<link media="screen" type="text/css" rel="stylesheet"  href="/templates/green/css/zlg.css" />
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
                        <a title="加入收藏" class="Collect" href="javascript:if(document.all){window.external.addFavorite('http://www.heng24.com','恒24小时便利店');}else if(window.sidebar){window.sidebar.addPanel('恒24小时便利店', 'http://www.heng24.com','');}">收藏本站</a>
                        <script type="text/javascript">
                            $.ajax({
                                type: "POST",
                                url: "/tools/submit_ajax.ashx?action=user_check_login",
                                dataType: "json",
                                timeout: 20000,
                                success: function (data, textStatus) {
                                    if (data.status == 1) {
                                        $("#menu").append('<li><a href="/usercenter.aspx?action=exit">退出</a></li>');
                                        $("#menu").append('<li><a href="/usercenter.aspx?action=index">会员中心</a></li>');
                                    } else {
                                        $("#menu").append('<li><a href="/register.aspx">注册</a></li>');
                                        $("#menu").append('<li><a href="/login.aspx">登录</a></li>');
                                    }
                                }
                            });
    </script>
                        <ul class="header_login" id="menu">
                            <li><a href="/content.aspx?page=lianxiwomen">联系我们</a></li>

                            <li><a href="/usercenter.aspx?action=exit">退出</a></li>
                            <li><a href="/usercenter.aspx?action=index">会员中心</a></li>
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
                                    <img title="波兰国贸城" alt="波兰国贸城" src="/templates/green/images/logo.jpg"/></a></li>
                                <li class="header_search" id="show_store_search">
                                    <div class="header_search_input patt_bg_search patt_border_search">
                                        <input name="keywords" id="keywords" autofocus="" onkeydown="if(event.keyCode==13){SiteSearch('/search.aspx', '#keywords');return false};" type="text" placeholder="输入回车搜索" value="" x-webkit-speech="" remind="" />
                                        <a onclick="SiteSearch('/search.aspx', '#keywords');">
                                            <p class="patt_font_search" id="search_button">搜索</p>
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
						
                                <span>全部商品分类</span>
                                <div class="header_button_b"></div>
                              
                            </div>
                            <div class="header_sortnav" id="show_store_menu">
                                <ul class="menu_hot">

                                    <li class="header_cheaked patt_bg_header_checked"><a href="/index.aspx">首页</a></li>
                                    <li><a href="/content.aspx?page=ruhexiadan">购物流程</a></li>
                                    <li><a href="/content.aspx?page=zoujinwomen">关于我们</a></li>
                                    <li><a href="/content.aspx?page=peisongshijian">配送服务</a></li>
                                    <li><a href="/content.aspx?page=lianxiwomen">联系我们</a></li>
                                </ul>
                            </div>
                            <div class="header_cart_box">
                                <%
                                    Model.users userModel = new Web.UI.BasePage().GetUserInfo();
                                            if (userModel == null)   {      %>
                                <div class="header_cart"><a href="/shopping.aspx?action=cart">购物车<script src="/tools/submit_ajax.ashx?action=view_cart_count" type="text/javascript"></script>件</a></div>
                                  <% }else{%>
                                 <div class="header_cart"><a href="/shoppingNew.aspx?action=cart">购物车结算</a></div>
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
      <h3>交易管理</h3>
      <ul>
        <li><a href="/userorder.aspx?action=list">交易订单</a></li>
        <li><a href="/userorder.aspx?action=close">已关闭订单</a></li>
      </ul>
      <h3>账户管理</h3>
      <ul>
        <li><a href="/useramount.aspx?action=recharge">账户余额</a></li>
        <li><a href="/usermessage.aspx?action=system">站内短信</a></li>
        <li><a href="/usercenter.aspx?action=invite">邀请码</a></li>
      </ul>
      <h3>基本资料</h3>
      <ul>
        <li><a href="/usercenter.aspx?action=proinfo">个人资料</a></li>
        <li><a href="/usercenter.aspx?action=address">收货地址</a></li>
        <li><a href="/shoplist.aspx">店铺管理</a></li>
        <li><a href="/usercenter.aspx?action=password">修改密码</a></li>
        <li><a href="/usercenter.aspx?action=exit">退出登录</a></li>
      </ul>
    </div>
    <!--/Sidebar-->
  </div>
        <div class="right757">
      <%-- <form name="info_form" id="info_form" url="/tools/submit_ajax.ashx?action=user_info_edit">--%>
    <h1 class="main_tit">
      <span><a href="/usercenter.aspx?action=index">管理首页</a></span>
      店铺管理
      <strong>shopList</strong>
    </h1>
    
     <div class="page_btns">
          <a  href="/shop.aspx?action=Add">新增</a>  

     </div>
      <asp:Repeater ID="rptList" runat="server">
<HeaderTemplate>
 <table style="width:100%;border:0px ;border-collapse:collapse; "   class="ltable">
  <tr>
    
    <th style="width:16%;text-align:center">商店名称</th>
       <th style="width:12%;text-align:center">城市</th>
    <th style="width:25%;text-align:center">地址</th>
    <th style="width:15%;text-align:center">联系人</th>
    <th style="width:15%;text-align:center">联系电话</th>
      <th style="width:15%;text-align:center">操作</th>
  </tr>
 </HeaderTemplate>
 <ItemTemplate>
  <tr>

    <td style="width:16%;text-align:center"><%#Eval("shop_name")%></td>
       <td style="width:12%;text-align:center"><%#Eval("city")%></td>
    <td style="width:25%;text-align:center"><%#Eval("address")%></td>
    <td style="width:15%;text-align:center"><%#Eval("linkman")%></td>
    <td style="width:15%;text-align:center"><%#Eval("telphone")%></td>
     <td style="width:15%;text-align:center"><a href="/shop.aspx?action=<%#Common.AXEnums.ActionEnum.Edit %>&id=<%#Eval("id")%>">编辑</a>
         <asp:LinkButton ID="btnDelete" runat="server" Text="删除" CssClass="TestStyle"  CommandArgument='<%# Eval("id")%>' onclick="btnDelete_Click" />
     </td>
     </tr>
</ItemTemplate>
<FooterTemplate>
  <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"9\">暂无商店</td></tr>" : ""%>
</table>
</FooterTemplate>
  </asp:Repeater>
        
            
            
                </div>
    </div>
      
    </form>
</body>
</html>
