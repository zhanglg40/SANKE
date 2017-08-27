<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="address.aspx.cs" Inherits="Web.address" %>

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
                                    <img title="波兰国贸城" alt="波兰国贸城" src="/templates/green/images/logo.jpg"></a></li>
                                <li class="header_search" id="show_store_search">
                                    <div class="header_search_input patt_bg_search patt_border_search">
                                        <input name="keywords" id="keywords" autofocus="" onkeydown="if(event.keyCode==13){SiteSearch('/search.aspx', '#keywords');return false};" type="text" placeholder="输入回车搜索" value="" x-webkit-speech="" remind="">
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
                                <div class="Nav_TitleStyleBox" style="left: -6px; top: 33px; width: 183px; display: none; position: absolute;">
                                    <div class="nav_style1_main_content_border">
                                        <div class="nav_style1_main_content">
                                            <ul class="nav_style1_content nav_style1_color1" style="cursor: default;">

                                                <li class="class1 nav_style1_content_li" class1_id="6461">
                                                    <p class="nav_p"><a href="/goods_list.aspx?category_id=2" target="_blank">服装鞋帽</a></p>
                                                    <div class="nav_style1_button_arrow icon_nav_arrow"></div>
                                                </li>

                                                <li class="class1 nav_style1_content_li" class1_id="6461">
                                                    <p class="nav_p"><a href="/goods_list.aspx?category_id=14" target="_blank">畅快痛饮</a></p>
                                                    <div class="nav_style1_button_arrow icon_nav_arrow"></div>
                                                </li>

                                                <li class="class1 nav_style1_content_li" class1_id="6461">
                                                    <p class="nav_p"><a href="/goods_list.aspx?category_id=19" target="_blank">护理中心</a></p>
                                                    <div class="nav_style1_button_arrow icon_nav_arrow"></div>
                                                </li>

                                                <li class="class1 nav_style1_content_li" class1_id="6461">
                                                    <p class="nav_p"><a href="/goods_list.aspx?category_id=43" target="_blank">厨房秀技</a></p>
                                                    <div class="nav_style1_button_arrow icon_nav_arrow"></div>
                                                </li>

                                                <li class="class1 nav_style1_content_li" class1_id="6461">
                                                    <p class="nav_p"><a href="/goods_list.aspx?category_id=52" target="_blank">日用百货</a></p>
                                                    <div class="nav_style1_button_arrow icon_nav_arrow"></div>
                                                </li>

                                                <li class="class1 nav_style1_content_li" class1_id="6461">
                                                    <p class="nav_p"><a href="/goods_list.aspx?category_id=60" target="_blank">美酒人生</a></p>
                                                    <div class="nav_style1_button_arrow icon_nav_arrow"></div>
                                                </li>

                                                <li class="class1 nav_style1_content_li" class1_id="6461">
                                                    <p class="nav_p"><a href="/goods_list.aspx?category_id=65" target="_blank">礼品特选</a></p>
                                                    <div class="nav_style1_button_arrow icon_nav_arrow"></div>
                                                </li>

                                            </ul>

                                            <div class="nav_style1_sub patt_header_leftnav" style="display: none;">
                                                <dl class="nav_style1_sub_class2">
                                                    <dt class="class2" class2_id="7524"><a href="/goods_list.aspx?category_id=2" target="_blank">服装鞋帽</a></dt>
                                                    <dd>

                                                        <em class="class3" class3_id="10006"><a href="/goods_list.aspx?category_id=36" target="_blank">方便速食</a></em>

                                                        <em class="class3" class3_id="10006"><a href="/goods_list.aspx?category_id=35" target="_blank">巧克力</a></em>

                                                        <em class="class3" class3_id="10006"><a href="/goods_list.aspx?category_id=34" target="_blank">卤味肉食</a></em>

                                                        <em class="class3" class3_id="10006"><a href="/goods_list.aspx?category_id=33" target="_blank">糖类</a></em>

                                                        <em class="class3" class3_id="10006"><a href="/goods_list.aspx?category_id=11" target="_blank">膨化</a></em>

                                                        <em class="class3" class3_id="10006"><a href="/goods_list.aspx?category_id=13" target="_blank">干果梅类</a></em>

                                                        <em class="class3" class3_id="10006"><a href="/goods_list.aspx?category_id=12" target="_blank">饼干糕点</a></em>

                                                    </dd>
                                                </dl>

                                            </div>

                                            <div class="nav_style1_sub patt_header_leftnav" style="display: none;">
                                                <dl class="nav_style1_sub_class2">
                                                    <dt class="class2" class2_id="7524"><a href="/goods_list.aspx?category_id=14" target="_blank">畅快痛饮</a></dt>
                                                    <dd>

                                                        <em class="class3" class3_id="10006"><a href="/goods_list.aspx?category_id=15" target="_blank">饮用水</a></em>

                                                        <em class="class3" class3_id="10006"><a href="/goods_list.aspx?category_id=16" target="_blank">碳酸饮料</a></em>

                                                        <em class="class3" class3_id="10006"><a href="/goods_list.aspx?category_id=17" target="_blank">乳制品</a></em>

                                                        <em class="class3" class3_id="10006"><a href="/goods_list.aspx?category_id=18" target="_blank">茶饮料</a></em>

                                                        <em class="class3" class3_id="10006"><a href="/goods_list.aspx?category_id=37" target="_blank">果蔬饮品</a></em>

                                                        <em class="class3" class3_id="10006"><a href="/goods_list.aspx?category_id=38" target="_blank">功能饮料</a></em>

                                                        <em class="class3" class3_id="10006"><a href="/goods_list.aspx?category_id=39" target="_blank">茶叶</a></em>

                                                        <em class="class3" class3_id="10006"><a href="/goods_list.aspx?category_id=40" target="_blank">营养冲剂</a></em>

                                                    </dd>
                                                </dl>

                                            </div>

                                            <div class="nav_style1_sub patt_header_leftnav" style="display: none;">
                                                <dl class="nav_style1_sub_class2">
                                                    <dt class="class2" class2_id="7524"><a href="/goods_list.aspx?category_id=19" target="_blank">护理中心</a></dt>
                                                    <dd>

                                                        <em class="class3" class3_id="10006"><a href="/goods_list.aspx?category_id=20" target="_blank">护肤美颜</a></em>

                                                        <em class="class3" class3_id="10006"><a href="/goods_list.aspx?category_id=21" target="_blank">美发护理</a></em>

                                                        <em class="class3" class3_id="10006"><a href="/goods_list.aspx?category_id=22" target="_blank">沐浴护理</a></em>

                                                        <em class="class3" class3_id="10006"><a href="/goods_list.aspx?category_id=23" target="_blank">口腔护理</a></em>

                                                        <em class="class3" class3_id="10006"><a href="/goods_list.aspx?category_id=24" target="_blank">女性护理</a></em>

                                                        <em class="class3" class3_id="10006"><a href="/goods_list.aspx?category_id=41" target="_blank">婴儿护理</a></em>

                                                        <em class="class3" class3_id="10006"><a href="/goods_list.aspx?category_id=42" target="_blank">计生用品</a></em>

                                                    </dd>
                                                </dl>

                                            </div>

                                            <div class="nav_style1_sub patt_header_leftnav" style="display: none;">
                                                <dl class="nav_style1_sub_class2">
                                                    <dt class="class2" class2_id="7524"><a href="/goods_list.aspx?category_id=43" target="_blank">厨房秀技</a></dt>
                                                    <dd>

                                                        <em class="class3" class3_id="10006"><a href="/goods_list.aspx?category_id=44" target="_blank">厨房清洁</a></em>

                                                        <em class="class3" class3_id="10006"><a href="/goods_list.aspx?category_id=45" target="_blank">厨房用具</a></em>

                                                        <em class="class3" class3_id="10006"><a href="/goods_list.aspx?category_id=46" target="_blank">食用油</a></em>

                                                        <em class="class3" class3_id="10006"><a href="/goods_list.aspx?category_id=47" target="_blank">米面杂粮</a></em>

                                                        <em class="class3" class3_id="10006"><a href="/goods_list.aspx?category_id=48" target="_blank">生抽酱油</a></em>

                                                        <em class="class3" class3_id="10006"><a href="/goods_list.aspx?category_id=49" target="_blank">调味料</a></em>

                                                        <em class="class3" class3_id="10006"><a href="/goods_list.aspx?category_id=50" target="_blank">调味酱</a></em>

                                                        <em class="class3" class3_id="10006"><a href="/goods_list.aspx?category_id=51" target="_blank">干货速冻</a></em>

                                                    </dd>
                                                </dl>

                                            </div>

                                            <div class="nav_style1_sub patt_header_leftnav" style="display: none;">
                                                <dl class="nav_style1_sub_class2">
                                                    <dt class="class2" class2_id="7524"><a href="/goods_list.aspx?category_id=52" target="_blank">日用百货</a></dt>
                                                    <dd>

                                                        <em class="class3" class3_id="10006"><a href="/goods_list.aspx?category_id=53" target="_blank">纸品</a></em>

                                                        <em class="class3" class3_id="10006"><a href="/goods_list.aspx?category_id=54" target="_blank">居家清洁</a></em>

                                                        <em class="class3" class3_id="10006"><a href="/goods_list.aspx?category_id=55" target="_blank">夏日驱蚊</a></em>

                                                        <em class="class3" class3_id="10006"><a href="/goods_list.aspx?category_id=56" target="_blank">居家服饰</a></em>

                                                        <em class="class3" class3_id="10006"><a href="/goods_list.aspx?category_id=57" target="_blank">杯盒之选</a></em>

                                                        <em class="class3" class3_id="10006"><a href="/goods_list.aspx?category_id=58" target="_blank">文体用品</a></em>

                                                        <em class="class3" class3_id="10006"><a href="/goods_list.aspx?category_id=59" target="_blank">其他用品</a></em>

                                                    </dd>
                                                </dl>

                                            </div>

                                            <div class="nav_style1_sub patt_header_leftnav" style="display: none;">
                                                <dl class="nav_style1_sub_class2">
                                                    <dt class="class2" class2_id="7524"><a href="/goods_list.aspx?category_id=60" target="_blank">美酒人生</a></dt>
                                                    <dd>

                                                        <em class="class3" class3_id="10006"><a href="/goods_list.aspx?category_id=61" target="_blank">精酿白酒</a></em>

                                                        <em class="class3" class3_id="10006"><a href="/goods_list.aspx?category_id=62" target="_blank">品味红酒</a></em>

                                                        <em class="class3" class3_id="10006"><a href="/goods_list.aspx?category_id=63" target="_blank">畅爽啤酒</a></em>

                                                        <em class="class3" class3_id="10006"><a href="/goods_list.aspx?category_id=64" target="_blank">其他酒类</a></em>

                                                    </dd>
                                                </dl>

                                            </div>

                                            <div class="nav_style1_sub patt_header_leftnav" style="display: none;">
                                                <dl class="nav_style1_sub_class2">
                                                    <dt class="class2" class2_id="7524"><a href="/goods_list.aspx?category_id=65" target="_blank">礼品特选</a></dt>
                                                    <dd>

                                                        <em class="class3" class3_id="10006"><a href="/goods_list.aspx?category_id=66" target="_blank">节日礼品</a></em>

                                                        <em class="class3" class3_id="10006"><a href="/goods_list.aspx?category_id=67" target="_blank">送小孩</a></em>

                                                        <em class="class3" class3_id="10006"><a href="/goods_list.aspx?category_id=68" target="_blank">送女士</a></em>

                                                        <em class="class3" class3_id="10006"><a href="/goods_list.aspx?category_id=69" target="_blank">送男士</a></em>

                                                        <em class="class3" class3_id="10006"><a href="/goods_list.aspx?category_id=70" target="_blank">结婚礼品</a></em>

                                                    </dd>
                                                </dl>

                                            </div>

                                        </div>
                                    </div>
                                </div>
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
                                <div class="header_cart"><a href="/shopping.aspx?action=cart">购物车<script src="/tools/submit_ajax.ashx?action=view_cart_count" type="text/javascript"></script>件</a></div>
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
      地址管理
      <strong>Address</strong>
    </h1>
    

          <div class="form_box">
    <dl>
    <dt>收货人：</dt>
        <dd><asp:TextBox runat="server" CssClass="input" name="txtNickName" id="txtNickName"  datatype="*" sucmsg=" " > </asp:TextBox> </dd>
      </dl>
        <dl>
        <dt>联系电话：</dt>
        <dd><asp:TextBox runat="server" CssClass="input"  name="txtTelphone" id="txtTelphone" datatype="*" sucmsg=" " > </asp:TextBox> </dd>
      </dl>
      <dl>
        <dt>手机号码：</dt>
        <dd><asp:TextBox runat="server" CssClass="input"  name="txtMobile" id="txtMobile" > </asp:TextBox></dd>
      </dl>
                <dl>
        <dt>城市：</dt>
        <dd><asp:TextBox runat="server" CssClass="input" width="250px" name="txtCity" id="txtCity" > </asp:TextBox></dd>
      </dl>
   <dl>
        <dt>托运地址：</dt>
        <dd><asp:TextBox runat="server" CssClass="input" width="250px" name="txtAddress" id="txtAddress" > </asp:TextBox></dd>
      </dl>
               <dl>
        <dt>邮编：</dt>
        <dd><asp:TextBox runat="server" CssClass="input" width="250px" name="txtPost" id="txtPost" > </asp:TextBox></dd>
      </dl>
        <dl>
            <dt></dt>
             <dd><asp:Label runat="server" name="txtMessage" id="txtMessage" Text=""></asp:Label></dd>
        </dl>
      <dl>
        <dt></dt>
        <dd> <asp:Button ID="btnSubmit" runat="server" Text="提交保存" CssClass="btn" onclick="btnSubmit_Click" /></dd>
      </dl>
    </div>
   <%-- </form>--%>
            </div>
    </div>
      
    </form>
</body>
</html>
