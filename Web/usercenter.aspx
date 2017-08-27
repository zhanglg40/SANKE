﻿<%@ Page Language="C#" AutoEventWireup="true" Inherits="Web.UI.Page.usercenter" ValidateRequest="false" %>
<%@ Import namespace="System.Collections.Generic" %>
<%@ Import namespace="System.Text" %>
<%@ Import namespace="System.Data" %>
<%@ Import namespace="Common" %>

<script runat="server">
override protected void OnInit(EventArgs e)
{
    HttpCookie cookie = HttpContext.Current.Request.Cookies["lang"];
    string lang = cookie != null ? cookie.Value : "pl-PL";
	/* 
		This page was created by AoXiang Template Engine at 2016-11-26 21:30:55.
		本页面代码由AoXiang模板引擎生成于 2016-11-26 21:30:55. 
	*/

	base.OnInit(e);
	StringBuilder templateBuilder = new StringBuilder(220000);
    templateBuilder.Append("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">\r\n<html xmlns=\"http://www.w3.org/1999/xhtml\">\r\n<head>\r\n<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" />\r\n<title>");
     templateBuilder.Append(Resources.lang.membercentre+" - ");
	templateBuilder.Append(Utils.ObjectToStr(config.webname));
	templateBuilder.Append("</title>\r\n<meta content=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webkeyword));
	templateBuilder.Append("\" name=\"keywords\" />\r\n<meta content=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webdescription));
	templateBuilder.Append("\" name=\"description\" />\r\n<link media=\"screen\" type=\"text/css\" href=\"");
	templateBuilder.Append("/templates/green");
	templateBuilder.Append("/css/style.css\" rel=\"stylesheet\" />\r\n<script type=\"text/javascript\" src=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("scripts/jquery/jquery-1.10.2.min.js\"></");
	templateBuilder.Append("script>\r\n<script type=\"text/javascript\" src=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("scripts/lhgdialog/lhgdialog.js?skin=idialog\"></");
    templateBuilder.Append("script>\r\n<script type=\"text/javascript\" src=\"");
    templateBuilder.Append("/templates/green");
    templateBuilder.Append("/js/cart.js\"></");
	templateBuilder.Append("script>\r\n<script type=\"text/javascript\" src=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("scripts/calendar.js\"></");
	templateBuilder.Append("script>\r\n<script type=\"text/javascript\" src=\"");
	templateBuilder.Append("/templates/green");
	templateBuilder.Append("/js/base.js\"></");
	templateBuilder.Append("script>\r\n<link media=\"screen\" type=\"text/css\" rel=\"stylesheet\" href=\"");
	templateBuilder.Append("/templates/green");
	templateBuilder.Append("/images/jquery-ui.min.css\">\r\n<link media=\"screen\" type=\"text/css\" rel=\"stylesheet\"  href=\"");
	templateBuilder.Append("/templates/green");
	templateBuilder.Append("/css/common.min.css\">\r\n<link media=\"screen\" type=\"text/css\" rel=\"stylesheet\"  href=\"");
	templateBuilder.Append("/templates/green");
	templateBuilder.Append("/images/maincolor_10.css\">\r\n<link media=\"screen\" type=\"text/css\" rel=\"stylesheet\"  href=\"");
	templateBuilder.Append("/templates/green");
	templateBuilder.Append("/images/mainplugincolor_10.css\">\r\n<link media=\"screen\" type=\"text/css\" rel=\"stylesheet\"  href=\"");
	templateBuilder.Append("/templates/green");
	templateBuilder.Append("/images/deputycolor_0.css\">\r\n<link media=\"screen\" type=\"text/css\" rel=\"stylesheet\"  href=\"");
	templateBuilder.Append("/templates/green");
	templateBuilder.Append("/images/bordercolor_2.css\" >\r\n<script type=\"text/javascript\" src=\"");
	templateBuilder.Append("/templates/green");
	templateBuilder.Append("/images/jquery-ui-1.11.1.custom.min.js\"></");
	templateBuilder.Append("script>\r\n<script type=\"text/javascript\" src=\"");
	templateBuilder.Append("/templates/green");
	templateBuilder.Append("/images/common.min.js\"></");
	templateBuilder.Append("script>\r\n<script type=\"text/javascript\"  src=\"");
	templateBuilder.Append("/templates/green");
	templateBuilder.Append("/images/jquery.filedownload.min.js\"></");
	templateBuilder.Append("script>\r\n\r\n</head>\r\n\r\n<body style=\"background-color: rgb(255, 255, 255);\">\r\n	<div id=\"main\">\r\n<!--Header-->\r\n");

	templateBuilder.Append("<script src=\"");
	templateBuilder.Append("/templates/green");
	templateBuilder.Append("/images/logon_status.js\" type=\"text/javascript\"></");
	templateBuilder.Append("script>\r\n <script type=\"text/javascript\"  src=\"");
	templateBuilder.Append("/templates/green");
	templateBuilder.Append("/js/base.js\"></");
	templateBuilder.Append("script>\r\n<script type=\"text/javascript\">\r\n    var Configure = {\r\n        Third_Jump: \"http://\",\r\n        ShowHeader: true,\r\n        ShowZhuyun: true,\r\n        ShowNav: true\r\n    };\r\n    var browser_now = new Date();\r\n    function is_logon() {\r\n        return logon_type != null;\r\n    }\r\n    function get_logon_type() {\r\n        return logon_type;\r\n    }\r\n    function get_logon_name() {\r\n        return logon_name;\r\n    }\r\n    function get_logon_now() {\r\n        return logon_now;\r\n    }\r\n    function get_real_now() {\r\n        var diff = browser_now.getTime() - logon_now.getTime();\r\n        var now = new Date();\r\n        return new Date(now.getTime() - diff);\r\n    }\r\n</");
	templateBuilder.Append("script>\r\n\r\n<div id=\"store_header\">\r\n	<div class=\"header\">\r\n		<div class=\"header_tt\">\r\n        <a class=\"Collect\" href=\"javascript:if(document.all){window.external.addFavorite('http://www.heng24.com','恒24小时便利店');}else if(window.sidebar){window.sidebar.addPanel('恒24小时便利店', 'http://www.heng24.com','');}\" title=\"加入收藏\">" + Resources.lang.Collection+ "</a>	\r\n            		    <script type=\"text/javascript\">\r\n            		        $.ajax({\r\n            		            type: \"POST\",\r\n            		            url: \"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("tools/submit_ajax.ashx?action=user_check_login\",\r\n            		            dataType: \"json\",\r\n            		            timeout: 20000,\r\n            		            success: function (data, textStatus) {\r\n            		                if (data.status == 1) {\r\n            		                    $(\"#menu\").append('<li><a href=\"");
	templateBuilder.Append(linkurl("usercenter","exit"));

	templateBuilder.Append("\">" + Resources.lang.logout + "</a></li>');\r\n            		                    $(\"#menu\").append('<li><a href=\"");
	templateBuilder.Append(linkurl("usercenter","index"));

	templateBuilder.Append("\">" + Resources.lang.membercentre+ "</a></li>');\r\n            		                } else {\r\n            		                    $(\"#menu\").append('<li><a href=\"");
	templateBuilder.Append(linkurl("register"));

    templateBuilder.Append("\">" + Resources.lang.register + "</a></li>');\r\n            		                    $(\"#menu\").append('<li><a href=\"");
    templateBuilder.Append(linkurl("login"));

    templateBuilder.Append("\">" + Resources.lang.login + "</a></li>');\r\n            		                }\r\n            		            }\r\n            		        });\r\n    </");
    templateBuilder.Append("script>\r\n           ");
    templateBuilder.Append(" <ul class=\"header_login\" id=\"menu\" >\r\n     ");
    templateBuilder.Append("<li>");
    templateBuilder.Append("<a href=\"javascript:void(0);\" onclick=\"change('" + Utils.ObjectToStr(config.webpath) + "');\" >");
    templateBuilder.Append(Resources.lang.language);
    templateBuilder.Append("</a></li>");
    //templateBuilder.Append("<li> 语言:  <select><option value =\"volvo\">Volvo</option><option value =\"saab\">Saab</option>");
    //templateBuilder.Append(" <option value=\"opel\">Opel</option>");
    //templateBuilder.Append("  <option value=\"audi\">Audi</option>");
    //templateBuilder.Append(" </select></li>");
    templateBuilder.Append(" <li><a href=\"");
    templateBuilder.Append(linkurl("content", "lianxiwomen"));

    templateBuilder.Append("\">" + Resources.lang.contactus + "</a></li>");

    templateBuilder.Append("</ul>\r\n		</div>\r\n	</div>\r\n		<div id=\"header_content_box\"><div id=\"header_content\">\r\n</div></div>\r\n			");
    templateBuilder.Append("<div class=\"header_style0\">\r\n				<div class=\"header_logo_content\">\r\n					<div class=\"header_logo_gox\">\r\n						<ul>\r\n							<li class=\"header_logo\" id=\"store_info_logo\"><a href=\"index.aspx\"><img alt=\"");
    templateBuilder.Append(Utils.ObjectToStr(config.webname));
    templateBuilder.Append("\" title=\"");
    templateBuilder.Append(Utils.ObjectToStr(config.webname));
    templateBuilder.Append("\" src=\"");
    templateBuilder.Append("/templates/green");
    templateBuilder.Append("/images/logo.jpg\"></a></li>\r\n							<li class=\"header_search\" id=\"show_store_search\">\r\n								<div class=\"header_search_input patt_bg_search patt_border_search\">\r\n<input id=\"keywords\" name=\"keywords\" remind=\"\" value=\"\" type=\"text\" x-webkit-speech=\"\" autofocus=\"\" placeholder=\"" + Resources.lang.enter + "\" onkeydown=\"if(event.keyCode==13){SiteSearch('");
    templateBuilder.Append(linkurl("search"));

    templateBuilder.Append("', '#keywords');return false};\" />\r\n      <a onclick=\"SiteSearch('");
    templateBuilder.Append(linkurl("search"));

    templateBuilder.Append("', '#keywords');\" ><p id=\"search_button\" class=\"patt_font_search\">" + Resources.lang.search + "</p></a>						\r\n								</div>\r\n							</li>\r\n							<li class=\"header_ad\" id=\"store_info_ad\">\r\n									\r\n							</li>\r\n						</ul>\r\n					</div>\r\n				</div>\r\n				<div class=\"header_navbox patt_bg_nav\">\r\n					<div class=\"header_nav\">\r\n						<div class=\"header_sort patt_bg_sort\">\r\n							<span>" + Resources.lang.goodtype + "</span>\r\n							<div class=\"header_button_b\"></div>\r\n							<div class=\"Nav_TitleStyleBox\" style=\"position: absolute;top: 33px;width: 183px;left: -6px;display:none\">\r\n								<div class=\"nav_style1_main_content_border\">\r\n								<div class=\"nav_style1_main_content\">\r\n									<ul class=\"nav_style1_content nav_style1_color1\" style=\"cursor: default;\">\r\n         ");
    DataTable category_list33 = get_category_child_list("goods", 0);

    int cdr33__loop__id = 0;
    foreach (DataRow cdr33 in category_list33.Rows)
    {
        cdr33__loop__id++;


        templateBuilder.Append("\r\n											<li class=\"class1 nav_style1_content_li\" class1_id=\"6461\"><p class=\"nav_p\"><a target=\"_parent\"  href=\"");
        templateBuilder.Append(linkurl("goods_list", Utils.ObjectToStr(cdr33["id"])));

        templateBuilder.Append("\">");
        if (lang.Equals("pl-PL"))
        {
            templateBuilder.Append(Utils.ObjectToStr(cdr33["seo_title"]));
        }
        else
        {
            templateBuilder.Append(Utils.ObjectToStr(cdr33["title"]));
        }
        templateBuilder.Append("</a></p><div class=\"nav_style1_button_arrow icon_nav_arrow\"></div></li>\r\n											");
    }	//end for if

    templateBuilder.Append("\r\n									</ul>\r\n         ");
    DataTable category_list44 = get_category_child_list("goods", 0);

    int cdr44__loop__id = 0;
    foreach (DataRow cdr44 in category_list44.Rows)
    {
        cdr44__loop__id++;


        templateBuilder.Append("\r\n										<div class=\"nav_style1_sub patt_header_leftnav\" style=\"display: none;\">\r\n												<dl class=\"nav_style1_sub_class2\">\r\n													<dt class=\"class2\" class2_id=\"7524\"><a target=\"_blank\" href=\"");
        templateBuilder.Append(linkurl("goods_list", Utils.ObjectToStr(cdr44["id"])));

        templateBuilder.Append("\">");
        if (lang.Equals("pl-PL"))
        {
            templateBuilder.Append(Utils.ObjectToStr(cdr44["seo_title"]));
        }
        else
        {
            templateBuilder.Append(Utils.ObjectToStr(cdr44["title"]));
        }
        templateBuilder.Append("</a></a></dt>\r\n													<dd>\r\n          ");
        DataTable category_list55 = get_category_child_list("goods", Utils.StrToInt(Utils.ObjectToStr(cdr44["id"]), 0));

        int cdr55__loop__id = 0;
        foreach (DataRow cdr55 in category_list55.Rows)
        {
            cdr55__loop__id++;


            templateBuilder.Append("\r\n															<em class=\"class3\" class3_id=\"10006\"><a target=\"_parent\" href=\"");
            templateBuilder.Append(linkurl("goods_list", Utils.ObjectToStr(cdr55["id"])));

            templateBuilder.Append("\">" + Utils.ObjectToStr(cdr55["title"]) + "</a></em>\r\n																");
        }	//end for if

        templateBuilder.Append("\r\n													</dd>\r\n												</dl>\r\n												\r\n										</div>\r\n									");
    }	//end for if

    templateBuilder.Append("\r\n								</div>\r\n								</div>\r\n							</div>\r\n						</div>\r\n						<div class=\"header_sortnav\" id=\"show_store_menu\">\r\n							");
    //
    templateBuilder.Append("<ul class=\"menu_hot\">\r\n\r\n         ");
    foreach (DataRow cdr33 in category_list33.Rows)
    {
        templateBuilder.Append("\r\n<li class=\"header_cheaked patt_bg_header_checked\"><a href=\"");
        templateBuilder.Append(linkurl("goods_list", Utils.ObjectToStr(cdr33["id"])));

        templateBuilder.Append("\">");
        if (lang.Equals("pl-PL"))
        {
            templateBuilder.Append(Utils.ObjectToStr(cdr33["seo_title"]));
        }
        else
        {
            templateBuilder.Append(Utils.ObjectToStr(cdr33["title"]));
        }
        templateBuilder.Append("</a></li>\r\n											");

    }
    /*
    templateBuilder.Append("<li class=\"header_cheaked patt_bg_header_checked\"><a href=\"");
	templateBuilder.Append(linkurl("index"));
	templateBuilder.Append("\">"+Resources.lang.home+"</a></li>\r\n   ");
    //templateBuilder.Append("     <li><a href=\"");
    //templateBuilder.Append(linkurl("goods"));

    //templateBuilder.Append("\">积分商城</a></li>\r\n    ");
    templateBuilder.Append("    <li><a href=\"");
	templateBuilder.Append(linkurl("content","ruhexiadan"));

	templateBuilder.Append("\">" + Resources.lang.process+ "</a></li>\r\n        <li><a href=\"");
	templateBuilder.Append(linkurl("content","zoujinwomen"));

	templateBuilder.Append("\">"+Resources.lang.aboutus+"</a></li>	\r\n        <li><a href=\"");
	templateBuilder.Append(linkurl("content","peisongshijian"));

	templateBuilder.Append("\">"+Resources.lang.Deliveryservice+"</a></li>\r\n        <li><a href=\"");
	templateBuilder.Append(linkurl("content","lianxiwomen"));

    templateBuilder.Append("\">" + Resources.lang.contactus + "</a></li>										\r\n							");
   */

    templateBuilder.Append("</ul>\r\n						</div>\r\n						");
    Model.users userModel = new Web.UI.BasePage().GetUserInfo();
    int count = 0;
    BLL.shop shop = new BLL.shop();
    if (userModel != null)
    {
        count = shop.GetCount("user_id=" + userModel.id, "");
    }
    if (count == 0)
    {
        templateBuilder.Append("<div class=\"header_cart_box\">\r\n							<div class=\"header_cart\"> <a style=\"font-size:5px\" href=\"");
        templateBuilder.Append(linkurl("shopping", "cart"));

        templateBuilder.Append("\">" + Resources.lang.settle + "</a></div>\r\n							");
    }
    else
    {
        templateBuilder.Append("<div class=\"header_cart_box\">\r\n							<div class=\"header_cart\"> <a style=\"font-size:5px\" href=\"");
        templateBuilder.Append(linkurl("shoppingNew", "cart"));

        templateBuilder.Append("\">" + Resources.lang.settle + "</a></div>\r\n							");
    }



    templateBuilder.Append("<div class=\"small_cart\"></div>\r\n						</div>\r\n					</div>\r\n				</div>\r\n			</div>\r\n\r\n	");
    templateBuilder.Append("<div id=\"show_store_nav\">\r\n			<div class=\"header_subnavbox\">\r\n				<div class=\"header_subnav_header\" style=\"display:none;\">\r\n					<div style=\"width:1190px;height:32px;overflow:hidden;position:relative;z-index:1\">\r\n					<ul class=\"header_subnav\" style=\"width: 792px;\">\r\n                    ");
    DataTable category_list22 = get_category_child_list("goods", 0);

    int cdr22__loop__id = 0;
    foreach (DataRow cdr22 in category_list22.Rows)
    {
        cdr22__loop__id++;


        templateBuilder.Append("\r\n							<li class=\"subnav_li\"><a  class=\"class1\" class1_id=\"6461\" href=\"");
        templateBuilder.Append(linkurl("goods_list", Utils.ObjectToStr(cdr22["id"])));

        templateBuilder.Append("\">" + Utils.ObjectToStr(cdr22["title"]) + "</a><div class=\"header_button_a\"></div></li>\r\n			");
    }	//end for if

    templateBuilder.Append("\r\n					</ul>\r\n					</div>\r\n					<div class=\"header_subclass\">\r\n       ");
    DataTable category_list3 = get_category_child_list("goods", 0);

    int cdr3__loop__id = 0;
    foreach (DataRow cdr3 in category_list3.Rows)
    {
        cdr3__loop__id++;


        templateBuilder.Append("\r\n<div class=\"header_subclass_nav\" style=\"display: none;\">\r\n								<div class=\"header_subclass_nav_content\">\r\n									<div class=\"header_subclass_nav_goods patt_header_subnav\">\r\n										<dl class=\"header_subclass_nav_a\">\r\n											<dt><a class=\"class2\" class2_id=\"7524\" href=\"");
        templateBuilder.Append(linkurl("goods_list", Utils.ObjectToStr(cdr3["id"])));

        templateBuilder.Append("\">" + Utils.ObjectToStr(cdr3["title"]) + "</a></dt>\r\n											<dd>\r\n             ");
        DataTable category_list21 = get_category_child_list("goods", Utils.StrToInt(Utils.ObjectToStr(cdr3["id"]), 0));

        int cdr21__loop__id = 0;
        foreach (DataRow cdr21 in category_list21.Rows)
        {
            cdr21__loop__id++;


            templateBuilder.Append("\r\n												<em><a target=\"_parent\" class=\"class3\" class3_id=\"10006\" href=\"");
            templateBuilder.Append(linkurl("goods_list", Utils.ObjectToStr(cdr21["id"])));

            templateBuilder.Append("\">" + Utils.ObjectToStr(cdr21["title"]) + "</a></em>\r\n											    ");
        }	//end for if

        templateBuilder.Append("\r\n											</dd>\r\n										</dl>\r\n										\r\n									</div>\r\n								</div>\r\n							</div>\r\n              ");
    }	//end for if

    templateBuilder.Append("\r\n\r\n					</div>\r\n				</div>\r\n			</div>\r\n	");
    templateBuilder.Append("</div>\r\n</div>");


    templateBuilder.Append("\r\n<!--/Header-->\r\n<div  style=\"height:10px;\"></div>\r\n\r\n<div class=\"boxwrap\">\r\n  <div class=\"left180\">\r\n    <!--Sidebar-->\r\n    ");

	templateBuilder.Append("    <div class=\"sidebar\">\r\n      <h3>" + Resources.lang.Transaction+ "</h3>\r\n      <ul>\r\n        <li><a href=\"");
	templateBuilder.Append(linkurl("userorder","list"));

	templateBuilder.Append("\">" + Resources.lang.torder + "</a></li>\r\n        <li><a href=\"");
	templateBuilder.Append(linkurl("userorder","close"));

	templateBuilder.Append("\">" + Resources.lang.closeorder + "</a></li>\r\n      </ul>\r\n      <h3>" + Resources.lang.AccountM+ "</h3>\r\n      <ul>\r\n        <li><a href=\"");
	templateBuilder.Append(linkurl("useramount","recharge"));

	templateBuilder.Append("\">" + Resources.lang.Balance+ "</a></li>\r\n        ");
    //templateBuilder.Append("<li><a href=\"");
    //templateBuilder.Append(linkurl("userpoint","convert"));

    //templateBuilder.Append("\">" + Resources.lang.scores+ "</a></li>\r\n        ");
    templateBuilder.Append("<li><a href=\"");
	templateBuilder.Append(linkurl("usermessage","system"));

	templateBuilder.Append("\">" + Resources.lang.SMS+ "</a></li>\r\n        <li><a href=\"");
	templateBuilder.Append(linkurl("usercenter","invite"));

	templateBuilder.Append("\">" + Resources.lang.Invitation+ "</a></li>\r\n      </ul>\r\n      <h3>" + Resources.lang.basic+ "</h3>\r\n      <ul>\r\n        <li><a href=\"");
	templateBuilder.Append(linkurl("usercenter","proinfo"));

	templateBuilder.Append("\">" + Resources.lang.information+ "</a></li>\r\n        <li><a href=\"");
    templateBuilder.Append(linkurl("usercenter", "address"));
    	templateBuilder.Append("\">" + Resources.lang.ShippingAddress+ "</a></li>\r\n        <li><a href=\"");
   	templateBuilder.Append("/shoplist.aspx\">" + Resources.lang.shopm+ "</a></li> <li><a href=\"");
        templateBuilder.Append(linkurl("usercenter", "password"));
         
	templateBuilder.Append("\">" + Resources.lang.changePSD+ "</a></li>\r\n        <li><a href=\"");
	templateBuilder.Append(linkurl("usercenter","exit"));

	templateBuilder.Append("\">" + Resources.lang.logout+ "</a></li>\r\n      </ul>\r\n    </div>");


	templateBuilder.Append("\r\n    <!--/Sidebar-->\r\n  </div>\r\n  \r\n  <div class=\"right757\">\r\n    ");
	if (action=="index")
	{

	templateBuilder.Append("\r\n    <!--会员中心-->\r\n    <h1 class=\"main_tit\">\r\n      <span><a href=\"");
	templateBuilder.Append(linkurl("usercenter","exit"));

    templateBuilder.Append("\">" + Resources.lang.logout + "</a></span>\r\n      " + Resources.lang.membercentre + "\r\n      <strong>Profile</strong>\r\n    </h1>\r\n    <!--会员中心-->\r\n    <div class=\"main_head\">\r\n      <div class=\"avatarbox\">\r\n        ");
	if (userModel.avatar!="")
	{

	templateBuilder.Append("\r\n        <img src=\"");
	templateBuilder.Append(Utils.ObjectToStr(userModel.avatar));
	templateBuilder.Append("\" />\r\n        ");
	}
	else
	{

	templateBuilder.Append("\r\n        <img src=\"");
	templateBuilder.Append("/templates/green");
	templateBuilder.Append("/images/user_avatar.png\" alt=\"求真像\" />\r\n        ");
	}	//end for if

	templateBuilder.Append("\r\n        <span><a href=\"");
	templateBuilder.Append(linkurl("usercenter","avatar"));

    templateBuilder.Append("\">" + Resources.lang.SetAvatar + "</a></span>\r\n      ");
    if (lang.Equals("pl-PL"))
    {
        templateBuilder.Append("</div>\r\n      <div class=\"tips_box\">\r\n        <h3><span class=\"red\">");
        templateBuilder.Append(Utils.ObjectToStr(userModel.user_name));
        templateBuilder.Append("</span></h3>\r\n        <dl>\r\n          <dt>Poziom członkostwa：</dt>\r\n          <dd>");
        templateBuilder.Append(Utils.ObjectToStr(groupModel.title));
        templateBuilder.Append("</dd>\r\n        </dl>\r\n       ");
        templateBuilder.Append("    <dl>\r\n          <dt>Ten login IP：</dt>\r\n          <dd>");
        templateBuilder.Append(Utils.ObjectToStr(curr_login_ip));
        templateBuilder.Append("</dd>\r\n        </dl>\r\n  <dl>\r\n  <dt>Ostatnie logowanie IP：</dt>\r\n <dd>");
        templateBuilder.Append(Utils.ObjectToStr(pre_login_ip));
        templateBuilder.Append("</dd>\r\n    </dl>\r\n  <dl>\r\n<dt>Czas rejestracji：</dt>\r\n<dd>");
        templateBuilder.Append(Utils.ObjectToStr(userModel.reg_time));
        templateBuilder.Append("</dd>\r\n    </dl>\r\n   <dl>\r\n <dt>Ostatni czas logowania：</dt>\r\n <dd>");
        templateBuilder.Append(Utils.ObjectToStr(pre_login_time));
        templateBuilder.Append("</dd>\r\n        </dl>\r\n      </div>\r\n </div>\r\n    <div class=\"line20\"></div>\r\n    <div class=\"tips_box\">\r\n      <h2>" + Resources.lang.statistics + "</h2>\r\n      <dl>\r\n        <dt>Saldo konta：</dt>\r\n        <dd><b class=\"red\">");
        templateBuilder.Append(Utils.ObjectToStr(userModel.amount));
        templateBuilder.Append("</b> PLN</dd>\r\n      </dl>\r\n    ");

        templateBuilder.Append("    <dl>\r\n <dt>Nieskończone zamówienie：</dt>\r\n        <dd><b class=\"red\">");
        templateBuilder.Append(get_user_order_count("status<3 and user_id=" + userModel.id).ToString());

        templateBuilder.Append("</b> 个</dd>\r\n      </dl>\r\n      <dl>\r\n  <dt>Nieprzeczytana wiadomość SMS：</dt>\r\n        <dd><b class=\"red\">");
        templateBuilder.Append(get_user_message_count("type<3 and is_read=0 and accept_user_name='" + userModel.user_name + "'").ToString());

        templateBuilder.Append("</b></dd>\r\n      </dl>\r\n    </div>\r\n    <!--/会员中心-->\r\n    ");
    }
    else
    {
        templateBuilder.Append("</div>\r\n      <div class=\"tips_box\">\r\n        <h3>尊敬的<span class=\"red\">");
        templateBuilder.Append(Utils.ObjectToStr(userModel.user_name));
        templateBuilder.Append("</span>，欢迎您！</h3>\r\n        <dl>\r\n          <dt>会员等级：</dt>\r\n          <dd>");
        templateBuilder.Append(Utils.ObjectToStr(groupModel.title));
        templateBuilder.Append("</dd>\r\n        </dl>\r\n       ");
        templateBuilder.Append("    <dl>\r\n          <dt>本次登录IP：</dt>\r\n          <dd>");
        templateBuilder.Append(Utils.ObjectToStr(curr_login_ip));
        templateBuilder.Append("</dd>\r\n        </dl>\r\n  <dl>\r\n  <dt>上次登录IP：</dt>\r\n <dd>");
        templateBuilder.Append(Utils.ObjectToStr(pre_login_ip));
        templateBuilder.Append("</dd>\r\n    </dl>\r\n  <dl>\r\n<dt>注册时间：</dt>\r\n<dd>");
        templateBuilder.Append(Utils.ObjectToStr(userModel.reg_time));
        templateBuilder.Append("</dd>\r\n    </dl>\r\n   <dl>\r\n <dt>上次登录时间：</dt>\r\n <dd>");
        templateBuilder.Append(Utils.ObjectToStr(pre_login_time));
        templateBuilder.Append("</dd>\r\n        </dl>\r\n      </div>\r\n </div>\r\n    <div class=\"line20\"></div>\r\n    <div class=\"tips_box\">\r\n      <h2>" + Resources.lang.statistics + "</h2>\r\n      <dl>\r\n        <dt>账户余额：</dt>\r\n        <dd><b class=\"red\">");
        templateBuilder.Append(Utils.ObjectToStr(userModel.amount));
        templateBuilder.Append("</b> PLN</dd>\r\n      </dl>\r\n    ");

        templateBuilder.Append("    <dl>\r\n <dt>未完成订单：</dt>\r\n        <dd><b class=\"red\">");
        templateBuilder.Append(get_user_order_count("status<3 and user_id=" + userModel.id).ToString());

        templateBuilder.Append("</b> 个</dd>\r\n      </dl>\r\n      <dl>\r\n  <dt>未读短信：</dt>\r\n        <dd><b class=\"red\">");
        templateBuilder.Append(get_user_message_count("type<3 and is_read=0 and accept_user_name='" + userModel.user_name + "'").ToString());

        templateBuilder.Append("</b>条</dd>\r\n      </dl>\r\n    </div>\r\n    <!--/会员中心-->\r\n    ");
    }  
	}
	else if (action=="password")
	{

	templateBuilder.Append("\r\n    <!--修改密码-->\r\n    <link rel=\"stylesheet\" href=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("css/validate.css\" />\r\n    <script type=\"text/javascript\" src=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("scripts/jquery/jquery.form.min.js\"></");
	templateBuilder.Append("script>\r\n    <script type=\"text/javascript\" src=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("scripts/jquery/Validform_v5.3.2_min.js\"></");
	templateBuilder.Append("script>\r\n    <script type=\"text/javascript\">\r\n      $(function(){\r\n	    //初始化表单\r\n		AjaxInitForm('pwd_form', 'btnSubmit', 1);\r\n	  });\r\n    </");
	templateBuilder.Append("script>\r\n    <h1 class=\"main_tit\">\r\n      <span><a href=\"");
	templateBuilder.Append(linkurl("usercenter","index"));

	templateBuilder.Append("\">" + Resources.lang.mhome+ "</a></span>\r\n      "+Resources.lang.changePSD+"\r\n      <strong>Password</strong>\r\n    </h1>\r\n    <form name=\"pwd_form\" id=\"pwd_form\" url=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("tools/submit_ajax.ashx?action=user_password_edit\">\r\n    <div class=\"form_box\">\r\n      <dl>\r\n        <dt>" + Resources.lang.username+ "：</dt>\r\n        <dd>");
	templateBuilder.Append(Utils.ObjectToStr(userModel.user_name));
    templateBuilder.Append("</dd>\r\n      </dl>\r\n      ");
    if (lang.Equals("pl-PL"))
    {
        templateBuilder.Append("<dl>\r\n<dt>Stare hasło：</dt>\r\n<dd><input name=\"txtOldPassword\" id=\"txtOldPassword\" type=\"password\" class=\"input txt\" datatype=\"*6-20\" nullmsg=\"Wprowadź stare hasło\" errormsg=\"od 6 do 16znaków\" sucmsg=\" \" /></dd>\r\n      </dl>\r\n      <dl>\r\n        <dt>Nowe hasło：</dt>\r\n        <dd><input name=\"txtPassword\" id=\"txtPassword\" type=\"password\" class=\"input txt\" datatype=\"*6-20\" nullmsg=\"Wprowadź swoje hasło\" errormsg=\"od 6 do 16znaków\" sucmsg=\" \" /></dd>\r\n      </dl>\r\n      <dl>\r\n        <dt>Potwierdź nowe hasło：</dt>\r\n        <dd><input name=\"txtPassword1\" id=\"txtPassword1\" type=\"password\" class=\"input txt\" datatype=\"*\" recheck=\"txtPassword\" nullmsg=\"Wprowadź ponownie hasło\" errormsg=\"Wprowadzone hasło jest niespójne\" sucmsg=\" \" /></dd>\r\n      </dl>\r\n      <dl>\r\n        <dt></dt>\r\n        <dd><input name=\"btnSubmit\" id=\"btnSubmit\" type=\"submit\" class=\"btn_submit\" value=\"Potwierdź zmiany\" /></dd>\r\n      </dl>\r\n    ");
    }
    else{
        templateBuilder.Append("<dl>\r\n<dt>旧密码：</dt>\r\n<dd><input name=\"txtOldPassword\" id=\"txtOldPassword\" type=\"password\" class=\"input txt\" datatype=\"*6-20\" nullmsg=\"请输入旧密码\" errormsg=\"密码范围在6-20位之间\" sucmsg=\" \" /></dd>\r\n      </dl>\r\n      <dl>\r\n        <dt>新密码：</dt>\r\n        <dd><input name=\"txtPassword\" id=\"txtPassword\" type=\"password\" class=\"input txt\" datatype=\"*6-20\" nullmsg=\"请输入密码\" errormsg=\"密码范围在6-20位之间\" sucmsg=\" \" /></dd>\r\n      </dl>\r\n      <dl>\r\n        <dt>确认新密码：</dt>\r\n        <dd><input name=\"txtPassword1\" id=\"txtPassword1\" type=\"password\" class=\"input txt\" datatype=\"*\" recheck=\"txtPassword\" nullmsg=\"请再输入一次密码\" errormsg=\"两次输入的密码不一致\" sucmsg=\" \" /></dd>\r\n      </dl>\r\n      <dl>\r\n        <dt></dt>\r\n        <dd><input name=\"btnSubmit\" id=\"btnSubmit\" type=\"submit\" class=\"btn_submit\" value=\"确认修改\" /></dd>\r\n      </dl>\r\n    ");
  
    }
    templateBuilder.Append("</div>\r\n    </form>\r\n    <!--/修改密码-->\r\n    ");
	}
	else if (action=="proinfo")
	{

	templateBuilder.Append("\r\n    <!--修改资料-->\r\n    <link rel=\"stylesheet\" href=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("css/validate.css\" />\r\n    <script type=\"text/javascript\" src=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("scripts/jquery/jquery.form.min.js\"></");
	templateBuilder.Append("script>\r\n    <script type=\"text/javascript\" src=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("scripts/jquery/Validform_v5.3.2_min.js\"></");
	templateBuilder.Append("script>\r\n    <script type=\"text/javascript\">\r\n      $(function(){\r\n	    //初始化表单\r\n		AjaxInitForm('info_form', 'btnSubmit', 1);\r\n	  });\r\n    </");
	templateBuilder.Append("script>\r\n    <form name=\"info_form\" id=\"info_form\" url=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("tools/submit_ajax.ashx?action=user_info_edit\">\r\n    <h1 class=\"main_tit\">\r\n      <span><a href=\"");
	templateBuilder.Append(linkurl("usercenter","index"));

    templateBuilder.Append("\">" + Resources.lang.mhome + "</a></span>\r\n      " + Resources.lang.information + "\r\n      <strong>Information</strong>\r\n    </h1>\r\n    \r\n    <div class=\"form_box\">\r\n      <dl>\r\n        <dt>" + Resources.lang.username + "：</dt>\r\n        <dd>");
	templateBuilder.Append(Utils.ObjectToStr(userModel.user_name));
	templateBuilder.Append("</dd>\r\n      </dl>\r\n      <dl>\r\n        <dt>Email：</dt>\r\n        <dd><input name=\"txtEmail\" id=\"txtEmail\" type=\"text\" class=\"input txt\" maxlength=\"50\" value=\"");
	templateBuilder.Append(Utils.ObjectToStr(userModel.email));
	templateBuilder.Append("\" readonly=\"readonly\" datatype=\"e\" sucmsg=\" \" /></dd>\r\n      </dl>\r\n      <dl>\r\n        <dt>" + Resources.lang.name+ "：</dt>\r\n        <dd><input name=\"txtNickName\" id=\"txtNickName\" type=\"text\" class=\"input txt\" value=\"");
	templateBuilder.Append(Utils.ObjectToStr(userModel.nick_name));
	templateBuilder.Append("\" datatype=\"*\" sucmsg=\" \" /></dd>\r\n      </dl>\r\n      <dl>\r\n        <dt>" + Resources.lang.sex+ "：</dt>\r\n        <dd>\r\n          ");
	if (userModel.sex=="" + Resources.lang.male+ "")
	{

	templateBuilder.Append("\r\n            <label><input name=\"rblSex\" type=\"radio\" value=\"" + Resources.lang.male+ "\" checked=\"checked\" />" + Resources.lang.male+ "</label> \r\n            <label><input name=\"rblSex\" type=\"radio\" value=\"" + Resources.lang.female+ "\" />" + Resources.lang.female+ "</label>\r\n            <label><input name=\"rblSex\" type=\"radio\" value=\"" + Resources.lang.Confidentiality+ "\" datatype=\"*\" sucmsg=\" \" />" + Resources.lang.Confidentiality+ "</label>\r\n            ");
	}
	else if (userModel.sex=="" + Resources.lang.female+ "")
	{

	templateBuilder.Append("\r\n            <label><input name=\"rblSex\" type=\"radio\" value=\"" + Resources.lang.male+ "\" />" + Resources.lang.male+ "</label>\r\n            <label><input name=\"rblSex\" type=\"radio\" value=\"" + Resources.lang.female+ "\" checked=\"checked\" />" + Resources.lang.female+ "</label>\r\n            <label><input name=\"rblSex\" type=\"radio\" value=\"" + Resources.lang.Confidentiality+ "\" datatype=\"*\" sucmsg=\" \" />" + Resources.lang.Confidentiality+ "</label>\r\n            ");
	}
	else
	{

	templateBuilder.Append("\r\n            <label><input name=\"rblSex\" type=\"radio\" value=\"" + Resources.lang.male+ "\" />" + Resources.lang.male+ "</label>\r\n            <label><input name=\"rblSex\" type=\"radio\" value=\"" + Resources.lang.female+ "\" />" + Resources.lang.female+ "</label>\r\n            <label><input name=\"rblSex\" type=\"radio\" value=\"" + Resources.lang.Confidentiality+ "\" checked=\"checked\" datatype=\"*\" sucmsg=\" \" />" + Resources.lang.Confidentiality+ "</label>\r\n            ");
	}	//end for if

	templateBuilder.Append("\r\n        </dd>\r\n      </dl>\r\n     ");

    templateBuilder.Append("    <dl>\r\n        <dt>" + Resources.lang.ContactNo + "：</dt>\r\n        <dd><input name=\"txtTelphone\" id=\"txtTelphone\" type=\"text\" class=\"input txt\" maxlength=\"50\" value=\"");
	templateBuilder.Append(Utils.ObjectToStr(userModel.telphone));
    templateBuilder.Append("\" /></dd>\r\n      </dl>\r\n      <dl>\r\n        <dt>" + Resources.lang.phoneNo + "：</dt>\r\n        <dd><input name=\"txtMobile\" id=\"txtMobile\" type=\"text\" class=\"input txt\" maxlength=\"20\" value=\"");
	templateBuilder.Append(Utils.ObjectToStr(userModel.mobile));
	templateBuilder.Append("\" datatype=\"*\" sucmsg=\" \" /></dd>\r\n      </dl>\r\n      <dl>\r\n        <dt>QQ：</dt>\r\n        <dd><input name=\"txtQQ\" id=\"txtQQ\" type=\"text\" class=\"input txt\" maxlength=\"20\" value=\"");
	templateBuilder.Append(Utils.ObjectToStr(userModel.qq));
    templateBuilder.Append("\" /></dd>\r\n      </dl>\r\n   ");
    templateBuilder.Append("<dl>\r\n        <dt>weChat：</dt>\r\n        <dd><input name=\"txtWeChat\" id=\"txtWeChat\" type=\"text\" class=\"input txt\" maxlength=\"20\" value=\"");
    templateBuilder.Append(Utils.ObjectToStr(userModel.wechat));
    templateBuilder.Append("\" /></dd>\r\n      </dl>\r\n   ");

    templateBuilder.Append("<dl>\r\n        <dt>" + Resources.lang.ShippingAddress + "：</dt>\r\n        <dd><input name=\"txtAddress\" id=\"txtAddress\" type=\"text\" class=\"input wide\" maxlength=\"250\" value=\"");
	templateBuilder.Append(Utils.ObjectToStr(userModel.address));
    templateBuilder.Append("\" /></dd>\r\n      </dl>\r\n ");
    if (lang.Equals("pl-PL"))
    {
        templateBuilder.Append("<dl>\r\n        <dt>Numer sklepu：</dt>\r\n        <dd><input name=\"txtComID\" id=\"txtComID\" type=\"text\" class=\"input wide\" maxlength=\"250\" value=\"");
        templateBuilder.Append(Utils.ObjectToStr(userModel.companyid));
        templateBuilder.Append("\" /></dd>\r\n      </dl>\r\n ");
        templateBuilder.Append("<dl>\r\n        <dt>Numer podatkowy：</dt>\r\n        <dd><input name=\"txtTaxid\" id=\"txtTaxid\" type=\"text\" class=\"input wide\" maxlength=\"250\" value=\"");
        templateBuilder.Append(Utils.ObjectToStr(userModel.taxid));
        templateBuilder.Append("\" /></dd>\r\n      </dl>\r\n ");
        templateBuilder.Append("<dl>\r\n        <dt>Nazwa firmy：</dt>\r\n        <dd><input name=\"txtComName\" id=\"txtComName\" type=\"text\" class=\"input wide\" maxlength=\"250\" value=\"");
        templateBuilder.Append(Utils.ObjectToStr(userModel.companyname));
        templateBuilder.Append("\" /></dd>\r\n      </dl>\r\n ");
        templateBuilder.Append("<dl>\r\n        <dt>Adres firmy：</dt>\r\n        <dd><input name=\"txtComAddress\" id=\"txtComAddress\" type=\"text\" class=\"input wide\" maxlength=\"250\" value=\"");
        templateBuilder.Append(Utils.ObjectToStr(userModel.companyaddress));
        templateBuilder.Append("\" /></dd>\r\n      </dl>\r\n ");
        templateBuilder.Append("     <dl>\r\n        <dt></dt>\r\n        <dd><input name=\"btnSubmit\" id=\"btnSubmit\" type=\"submit\" class=\"btn_submit\" value=\"Potwierdź zmiany\" /></dd>\r\n      </dl>\r\n    </div>\r\n    </form>\r\n    <!--/修改资料-->\r\n    ");
    }
    else
    {
        templateBuilder.Append("<dl>\r\n        <dt>商店号：</dt>\r\n        <dd><input name=\"txtComID\" id=\"txtComID\" type=\"text\" class=\"input wide\" maxlength=\"250\" value=\"");
        templateBuilder.Append(Utils.ObjectToStr(userModel.companyid));
        templateBuilder.Append("\" /></dd>\r\n      </dl>\r\n ");
        templateBuilder.Append("<dl>\r\n        <dt>税号：</dt>\r\n        <dd><input name=\"txtTaxid\" id=\"txtTaxid\" type=\"text\" class=\"input wide\" maxlength=\"250\" value=\"");
        templateBuilder.Append(Utils.ObjectToStr(userModel.taxid));
        templateBuilder.Append("\" /></dd>\r\n      </dl>\r\n ");
        templateBuilder.Append("<dl>\r\n        <dt>公司名称：</dt>\r\n        <dd><input name=\"txtComName\" id=\"txtComName\" type=\"text\" class=\"input wide\" maxlength=\"250\" value=\"");
        templateBuilder.Append(Utils.ObjectToStr(userModel.companyname));
        templateBuilder.Append("\" /></dd>\r\n      </dl>\r\n ");
        templateBuilder.Append("<dl>\r\n        <dt>公司地址：</dt>\r\n        <dd><input name=\"txtComAddress\" id=\"txtComAddress\" type=\"text\" class=\"input wide\" maxlength=\"250\" value=\"");
        templateBuilder.Append(Utils.ObjectToStr(userModel.companyaddress));
        templateBuilder.Append("\" /></dd>\r\n      </dl>\r\n ");
        templateBuilder.Append("     <dl>\r\n        <dt></dt>\r\n        <dd><input name=\"btnSubmit\" id=\"btnSubmit\" type=\"submit\" class=\"btn_submit\" value=\"确认修改\" /></dd>\r\n      </dl>\r\n    </div>\r\n    </form>\r\n    <!--/修改资料-->\r\n    ");

    }
	}
    else if (action == "address")
    {

        templateBuilder.Append("\r\n    <!--管理地址-->\r\n    <link rel=\"stylesheet\" href=\"");
        templateBuilder.Append(Utils.ObjectToStr(config.webpath));
        templateBuilder.Append("css/validate.css\" />\r\n    <script type=\"text/javascript\" src=\"");
        templateBuilder.Append(Utils.ObjectToStr(config.webpath));
        templateBuilder.Append("scripts/jquery/jquery.form.min.js\"></");
        templateBuilder.Append("script>\r\n    <script type=\"text/javascript\" src=\"");
        templateBuilder.Append(Utils.ObjectToStr(config.webpath));
        templateBuilder.Append("scripts/jquery/Validform_v5.3.2_min.js\"></");
        templateBuilder.Append("script>\r\n    <script type=\"text/javascript\">\r\n      $(function(){\r\n	    //初始化表单\r\n		AjaxInitForm('info_form', 'btnSubmit', 1);\r\n	  });\r\n    </");
        templateBuilder.Append("script>\r\n    <form name=\"info_form\" id=\"info_form\" url=\"");
        templateBuilder.Append(Utils.ObjectToStr(config.webpath));
        templateBuilder.Append("tools/submit_ajax.ashx?action=user_info_edit\">\r\n    <h1 class=\"main_tit\">\r\n      <span><a href=\"");
        templateBuilder.Append(linkurl("usercenter", "index"));

        templateBuilder.Append("\">" + Resources.lang.mhome + "</a></span>\r\n      " + Resources.lang.ShippingAddress + "\r\n      <strong>Information</strong>\r\n    </h1>\r\n    \r\n");
        templateBuilder.Append(" <div class=\"page_btns\">\r\n        <a  href=\"/address.aspx?action=Add\">" + Resources.lang.add + "</a>\r\n          </div>\r\n");
        templateBuilder.Append(" <table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" class=\"mtable\">\r\n      ");
        int totalcount = 0;
        DataTable list1 = get_user_address(10, 10, "user_name='" + userModel.user_name + "'", out totalcount);
        templateBuilder.Append("<tr><th>" + Resources.lang.Receiver+ "</th><th>" + Resources.lang.city+ "</th><th>" + Resources.lang.ShippingAddress+ "</th><th>" + Resources.lang.zipCode+ "</th><th>" + Resources.lang.ContactNo+ "</th><th>" + Resources.lang.phoneNo+ "</th><th>" + Resources.lang.edit+ "</th><th>" + Resources.lang.delete+ "</th><th>默认</th></tr> ");
     //   templateBuilder.Append("<tr><td>1</td><td>1</td><td>1</td><td>1</td><td>1</td><td>1</td><td>1</td></tr> </table>");
        templateBuilder.Append(" <!--取得分页页码列表-->\r\n      ");
        int dr__loop__id = 0;
        foreach (DataRow dr in list1.Rows)
        {
            dr__loop__id++;


            templateBuilder.Append("\r\n      <tr>\r\n    <td width=\"150\" style=\"text-align:center\">" + Utils.ObjectToStr(dr["nick_name"]) + "</td>\r\n        ");
              templateBuilder.Append("<td>\r\n          " + Utils.ObjectToStr(dr["city"]) + "\r\n          ");
           
            templateBuilder.Append("\r\n        </td>\r\n ");
            templateBuilder.Append("<td>\r\n          " + Utils.ObjectToStr(dr["address"]) + "\r\n          ");
           
            templateBuilder.Append("\r\n        </td>\r\n          ");

            templateBuilder.Append("<td>\r\n          " + Utils.ObjectToStr(dr["post_code"]) + "\r\n          ");

            templateBuilder.Append("\r\n        </td>\r\n        <td width=\"50\">\r\n          ");
                templateBuilder.Append("\r\n            +" + Utils.ObjectToStr(dr["telphone"]) + "\r\n          ");
         	//end for if

            templateBuilder.Append("\r\n        </td>\r\n        <td width=\"50\">\r\n          ");
            templateBuilder.Append("\r\n            +" + Utils.ObjectToStr(dr["mobile"]) + "\r\n          ");

            templateBuilder.Append("\r\n        </td>\r\n        <td width=\"30\"><a  href=\"/address.aspx?action=Edit&id=" + Utils.ObjectToStr(dr["id"]) + "\">" + Resources.lang.edit+ "</a></td>\r\n    ");
            templateBuilder.Append("<td width=\"30\"><a onclick=\"ExecDelete('/tools/submit_ajax.ashx?action=user_address_delete'," + Utils.ObjectToStr(dr["id"]) + ", 'turl');\" href=\"javascript:;\">" + Resources.lang.delete+ "</a></td>\r\n    ");
            templateBuilder.Append("<td width=\"30\"><a onclick=\"clickSubmit('/tools/submit_ajax.ashx?action=set_user_address&id=" + Utils.ObjectToStr(dr["id"]) + "');\" href=\"javascript:;\">设为默认</a></td>\r\n    ");
            templateBuilder.Append("  </tr>\r\n      ");
        }	//end for if
        templateBuilder.Append(" </table>");
        templateBuilder.Append("    <div class=\"form_box\">\r\n   ");

        //templateBuilder.Append(" <dl>\r\n    <dt>" + Resources.lang.Receiver+ "：</dt>\r\n        <dd><input name=\"txtNickName\" id=\"txtNickName\" type=\"text\" class=\"input txt\" value=\"");
        //templateBuilder.Append(Utils.ObjectToStr(userModel.nick_name));
        //templateBuilder.Append("\" datatype=\"*\" sucmsg=\" \" /></dd>\r\n      </dl>\r\n    ");


    
     
        //templateBuilder.Append("    <dl>\r\n        <dt>联系电话：</dt>\r\n        <dd><input name=\"txtTelphone\" id=\"txtTelphone\" type=\"text\" class=\"input txt\" maxlength=\"50\" value=\"");
        //templateBuilder.Append(Utils.ObjectToStr(userModel.telphone));
        //templateBuilder.Append("\" /></dd>\r\n      </dl>\r\n      <dl>\r\n        <dt>手机号码：</dt>\r\n        <dd><input name=\"txtMobile\" id=\"txtMobile\" type=\"text\" class=\"input txt\" maxlength=\"20\" value=\"");
        //templateBuilder.Append(Utils.ObjectToStr(userModel.mobile));
        //templateBuilder.Append("\" datatype=\"*\" sucmsg=\" \" /></dd>\r\n      </dl>\r\n   ");



     
        //templateBuilder.Append("<dl>\r\n        <dt>托运地址：</dt>\r\n        <dd><input name=\"txtAddress\" id=\"txtAddress\" type=\"text\" class=\"input wide\" maxlength=\"250\" value=\"");
        //templateBuilder.Append(Utils.ObjectToStr(userModel.address));
        //templateBuilder.Append("\" /></dd>\r\n      </dl>\r\n ");
  
        //templateBuilder.Append("     <dl>\r\n        <dt></dt>\r\n        <dd><input name=\"btnSubmit\" id=\"btnSubmit\" type=\"submit\" class=\"btn_submit\" value=\"确认修改\" /></dd>\r\n      </dl>\r\n    </div>\r\n    </form>\r\n    <!--/修改资料-->\r\n    ");
        templateBuilder.Append("  </div>\r\n    </form>\r\n    <!--/修改资料-->\r\n    ");
        templateBuilder.Append(" <input id=\"turl\" type=\"hidden\" value=\"");
	templateBuilder.Append(linkurl("usercenter","address"));

	templateBuilder.Append("\" />\r\n    ");
    }
	else if (action=="avatar")
	{

	templateBuilder.Append("\r\n    <!--" + Resources.lang.SetAvatar+ "-->\r\n    <link rel=\"stylesheet\" href=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("css/jquery.jcrop.css\" type=\"text/css\" />\r\n    <script type=\"text/javascript\" src=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("scripts/jquery/jquery.form.min.js\"></");
	templateBuilder.Append("script>\r\n    <script src=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("scripts/jquery/jquery.jcrop.min.js\" type=\"text/javascript\"></");
	templateBuilder.Append("script>\r\n    <script src=\"");
	templateBuilder.Append("/templates/green");
	templateBuilder.Append("/js/avatar.js\" type=\"text/javascript\"></");
	templateBuilder.Append("script>\r\n    <h1 class=\"main_tit\">\r\n      <span><a href=\"");
	templateBuilder.Append(linkurl("usercenter","index"));
     if (lang.Equals("pl-PL"))
    {
        templateBuilder.Append("\">" + Resources.lang.mhome + "</a></span>\r\n      Ustawienia Avatar\r\n      <strong>Avatar</strong>\r\n    </h1>\r\n    \r\n    <strong>Aktualny awatar</strong>\r\n    <p>Jeśli nie ustawisz własnego awatara, system pojawi się jako domyślny avatar, musisz przesłać nowe zdjęcie jako osobisty awatar。</p>\r\n    <div class=\"img_box\">\r\n      ");
	 }
    else
    {
        templateBuilder.Append("\">" + Resources.lang.mhome + "</a></span>\r\n      头像设置\r\n      <strong>Avatar</strong>\r\n    </h1>\r\n    \r\n    <strong>当前我的头像</strong>\r\n    <p>如果您还没有设置自己的头像，系统会显示为默认头像，您需要自己上传一张新照片来作为自己的个人头像。</p>\r\n    <div class=\"img_box\">\r\n      ");
    }
    if (userModel.avatar!="")
	{

	templateBuilder.Append("\r\n        <img src=\"");
	templateBuilder.Append(Utils.ObjectToStr(userModel.avatar));
	templateBuilder.Append("\" width=\"180\" height=\"180\" />\r\n      ");
	}
	else
	{

	templateBuilder.Append("\r\n        <img src=\"");
	templateBuilder.Append("/templates/green");
	templateBuilder.Append("/images/user_avatar.png\" width=\"180\" height=\"180\" />\r\n      ");
	}	//end for if
    if (lang.Equals("pl-PL"))
    {
        templateBuilder.Append("\r\n    </div>\r\n    <strong>Ustaw nowy avatar</strong>\r\n    <p>Po pomyślnym przesłaniu, wyrzuć odpowiedni avatar, aby potwierdzić zapis。</p>\r\n    <form id=\"upload_form\" name=\"upload_form\">\r\n      <div class=\"avatar_upload\">\r\n        <a href=\"javascript:;\" class=\"files\"><input type=\"file\" id=\"Filedata\" name=\"Filedata\" onchange=\"Upload('");
        templateBuilder.Append(Utils.ObjectToStr(config.webpath));
        templateBuilder.Append("');\" /></a>\r\n        <span class=\"uploading\">Wczytywanie, proszę czekać...</span>\r\n      </div>\r\n      <div class=\"clear\"></div>\r\n      <div class=\"avatar_box\">\r\n        <div class=\"avatar_big_warp\">\r\n          <div class=\"avatar_big_box\">\r\n            <div class=\"avatar_big_pic\">\r\n              <img id=\"target\" src=\"");
        templateBuilder.Append("/templates/green");
        templateBuilder.Append("/images/pic_pl_bg.png\" />\r\n            </div>\r\n          </div>\r\n        </div>\r\n        <div class=\"avatar_small_warp\">\r\n          <div class=\"avatar_small_box\">\r\n            <div class=\"avatar_small_pic\"><img id=\"preview\" src=\"");
        templateBuilder.Append("/templates/green");
        templateBuilder.Append("/images/pic_pl_bg.png\" /></div>\r\n          </div>\r\n          <p style=\"text-align:center;\"><strong>Obszar podglądu ankiety</strong></p>\r\n          <p style=\"text-align:center;\"><input id=\"btnSubmit\" name=\"btnSubmit\" type=\"button\" class=\"btn btn-success\" value=\"OK, aby zapisać\" onclick=\"CropSubmit('");
        templateBuilder.Append(Utils.ObjectToStr(config.webpath));
        templateBuilder.Append("');return false;\" /></p>\r\n          <p>Wskazówka: wygeneruj rozmiar zdjęcia 180 * 180 pikseli Po przesłaniu obrazu wybierz odpowiedni rozmiar po lewej stronie, kliknij przycisk Zapisz poniżej。</p>\r\n        </div>\r\n      </div>\r\n      <input id=\"hideFileName\" name=\"hideFileName\" type=\"hidden\" />\r\n      <input id=\"hideX1\" name=\"hideX1\" type=\"hidden\" value=\"0\" />\r\n      <input id=\"hideY1\" name=\"hideY1\" type=\"hidden\" value=\"0\" />\r\n      <input id=\"hideWidth\" name=\"hideWidth\" type=\"hidden\" value=\"0\" />\r\n      <input id=\"hideHeight\" name=\"hideHeight\" type=\"hidden\" value=\"0\" />\r\n    </form>\r\n    <!--/" + Resources.lang.SetAvatar + "-->\r\n    ");

    }
    else
    {
        templateBuilder.Append("\r\n    </div>\r\n    <strong>设置我的新头像</strong>\r\n    <p>上传成功后，请裁剪合适的头像确认保存后才能生效。</p>\r\n    <form id=\"upload_form\" name=\"upload_form\">\r\n      <div class=\"avatar_upload\">\r\n        <a href=\"javascript:;\" class=\"files\"><input type=\"file\" id=\"Filedata\" name=\"Filedata\" onchange=\"Upload('");
        templateBuilder.Append(Utils.ObjectToStr(config.webpath));
        templateBuilder.Append("');\" /></a>\r\n        <span class=\"uploading\">正在上传，请稍候...</span>\r\n      </div>\r\n      <div class=\"clear\"></div>\r\n      <div class=\"avatar_box\">\r\n        <div class=\"avatar_big_warp\">\r\n          <div class=\"avatar_big_box\">\r\n            <div class=\"avatar_big_pic\">\r\n              <img id=\"target\" src=\"");
        templateBuilder.Append("/templates/green");
        templateBuilder.Append("/images/pic_bg.png\" />\r\n            </div>\r\n          </div>\r\n        </div>\r\n        <div class=\"avatar_small_warp\">\r\n          <div class=\"avatar_small_box\">\r\n            <div class=\"avatar_small_pic\"><img id=\"preview\" src=\"");
        templateBuilder.Append("/templates/green");
        templateBuilder.Append("/images/pic_bg.png\" /></div>\r\n          </div>\r\n          <p style=\"text-align:center;\"><strong>头像预览区</strong></p>\r\n          <p style=\"text-align:center;\"><input id=\"btnSubmit\" name=\"btnSubmit\" type=\"button\" class=\"btn btn-success\" value=\"确定保存\" onclick=\"CropSubmit('");
        templateBuilder.Append(Utils.ObjectToStr(config.webpath));
        templateBuilder.Append("');return false;\" /></p>\r\n          <p>提示：生成头像大小180*180相素上传图片后，左侧选取图片合适大小，点击下面的保存按钮。</p>\r\n        </div>\r\n      </div>\r\n      <input id=\"hideFileName\" name=\"hideFileName\" type=\"hidden\" />\r\n      <input id=\"hideX1\" name=\"hideX1\" type=\"hidden\" value=\"0\" />\r\n      <input id=\"hideY1\" name=\"hideY1\" type=\"hidden\" value=\"0\" />\r\n      <input id=\"hideWidth\" name=\"hideWidth\" type=\"hidden\" value=\"0\" />\r\n      <input id=\"hideHeight\" name=\"hideHeight\" type=\"hidden\" value=\"0\" />\r\n    </form>\r\n    <!--/" + Resources.lang.SetAvatar + "-->\r\n    ");

    }
   	}
	else if (action=="invite")
	{

    //templateBuilder.Append("\r\n    <!--邀请码-->\r\n    <h1 class=\"main_tit\">\r\n      <span><a href=\"javascript:;\" onclick=\"clickSubmit('");
    //templateBuilder.Append(Utils.ObjectToStr(config.webpath));
    //templateBuilder.Append("tools/submit_ajax.ashx?action=user_invite_code');\">申请邀请码</a></span>\r\n      我的邀请码\r\n      <strong>Invite</strong>\r\n    </h1>\r\n    \r\n    <p>说明：您购买的邀请码会在失效之后由系统定时清理，不会长期驻留在列表中</p>\r\n    <div class=\"line10\"></div>\r\n    <table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" class=\"ftable\">\r\n      <tr>\r\n        <th align=\"left\">" + Resources.lang.Invitation+ "</th>\r\n        <th width=\"150\">申请时间</th>\r\n        <th width=\"150\">过期时间</th>\r\n        <th width=\"80\">已使用次数</th>\r\n        <th width=\"80\">状态</th>\r\n      </tr>\r\n      ");
    //DataTable list1 = get_user_invite_list(0, "user_name='"+userModel.user_name+"'");

    //templateBuilder.Append(" <!--取得一个DataTable-->\r\n      ");
    //int dr__loop__id=0;
    //foreach(DataRow dr in list1.Rows)
    //{
    //    dr__loop__id++;


    //templateBuilder.Append("\r\n      <tr>\r\n        <td>" + Utils.ObjectToStr(dr["str_code"]) + " &nbsp; <a href=\"javascript:;\" onclick=\"copyText('邀请码：" + Utils.ObjectToStr(dr["str_code"]) + "');\">[复制]</a></td>\r\n        <td align=\"center\">" + Utils.ObjectToStr(dr["add_time"]) + "</td>\r\n        <td align=\"center\">\r\n          ");
    //if (Utils.ObjectToStr(dr["eff_time"])=="")
    //{

    //templateBuilder.Append("\r\n          无限制\r\n          ");
    //}
    //else
    //{

    //templateBuilder.Append("\r\n          " + Utils.ObjectToStr(dr["eff_time"]) + "\r\n          ");
    //}	//end for if

    //templateBuilder.Append("\r\n        </td>\r\n        <td align=\"center\">" + Utils.ObjectToStr(dr["count"]) + "</td>\r\n        <td align=\"center\">\r\n          ");
    //if (get_invite_status(Utils.ObjectToStr(dr["str_code"])))
    //{

    //templateBuilder.Append("\r\n          有效\r\n          ");
    //}
    //else
    //{

    //templateBuilder.Append("\r\n          已失效\r\n          ");
    //}	//end for if

    //templateBuilder.Append("\r\n        </td>\r\n      </tr>\r\n      ");
    //}	//end for if

    //if (list1.Rows.Count<1)
    //{

    //templateBuilder.Append("\r\n      <tr><td align=\"center\" colspan=\"5\">" + Resources.lang.NoRecords+ "</td></tr>\r\n      ");
    //}	//end for if

    //templateBuilder.Append("\r\n    </table>\r\n    <!--/邀请码-->\r\n    ");
	}	//end for if

	templateBuilder.Append("\r\n    \r\n  </div>\r\n  <div class=\"clear\"></div>\r\n</div>\r\n\r\n<div class=\"clear\"></div>\r\n</div>\r\n<!--Footer-->\r\n");

	templateBuilder.Append("<div id=\"footer\">\r\n		<div id=\"store_footer_box\">\r\n	<div class=\"footer-box\">\r\n			<ul class=\"footer\">\r\n\r\n        ");
	DataTable category_listfoot1 = get_category_child_list("content", 0);

	int cdrfoot1__loop__id=0;
	foreach(DataRow cdrfoot1 in category_listfoot1.Rows)
	{
        cdrfoot1__loop__id++;


        templateBuilder.Append("\r\n				<li class=\"footer_firstlist\">\r\n					<dl class=\"footer_list_title\">\r\n						<dt>");
        if (lang.Equals("pl-PL"))
        {
            templateBuilder.Append(Utils.ObjectToStr(cdrfoot1["seo_title"]));
        }
        else
        {
            templateBuilder.Append(Utils.ObjectToStr(cdrfoot1["title"]));
        }

        templateBuilder.Append("</dt>\r\n            "); DataTable category_listfoot2 = get_category_child_list("content", Utils.StrToInt(Utils.ObjectToStr(cdrfoot1["id"]), 0));

	int cdrfoot2__loop__id=0;
	foreach(DataRow cdrfoot2 in category_listfoot2.Rows)
	{
        cdrfoot2__loop__id++;


        templateBuilder.Append("\r\n						<dd><a target=\"_blank\" href=\"");
        templateBuilder.Append(linkurl("content", Utils.ObjectToStr(cdrfoot2["call_index"])));

        templateBuilder.Append("\" rel=\"nofollow\">");
        if (lang.Equals("pl-PL"))
        {
            templateBuilder.Append(Utils.ObjectToStr(cdrfoot2["seo_title"]));
        }
        else
        {
            templateBuilder.Append(Utils.ObjectToStr(cdrfoot2["title"]));
        }

        templateBuilder.Append("</a></dd>\r\n            ");
    }	//end for if

	templateBuilder.Append("\r\n					</dl>\r\n				</li>\r\n       ");
	}	//end for if

    templateBuilder.Append("\r\n\r\n			</ul>\r\n	</div>\r\n	<div class=\"footer_copyright\" id=\"store_footer\">\r\n		<div id=\"footer_content\">\r\n        <div style=\"text-align:center;\">\r\n        <div class=\"links\" style=\"margin:0px;padding:0px;color:#666666;font-family:Arial, Verdana, 宋体;text-align:center;white-space:normal;background-color:#FFFFFF;\">\r\n        <br />\r\n        <p align=\"center\" style=\"orphans:2;white-space:normal;widows:2;background-color:#FFFFFF;margin-top:0px;margin-bottom:0px;color:#666666;font-family:&#39;Microsoft YaHei&#39;, SimSun, Arial;padding:0px;\"><span style=\"outline:none;text-decoration:none;color:#666666;margin:0px;padding:0px;font-family:&#39;Microsoft YaHei&#39;;line-height:2;font-size:12px;\">" + Resources.lang.ICP + " Copyright © 2016&nbsp;</span><span style=\"margin:0px;padding:0px;font-family:&#39;Microsoft YaHei&#39;;line-height:2;\"><span style=\"color:#666666;font-size:12px;\">All Rights Reserved </span>\r\n <span style=\"color:#666666;font-size:12px;\">&nbsp;</span></span><span style=\"margin:0px;padding:0px;font-family:&#39;Microsoft YaHei&#39;;line-height:2;color:#666666;font-size:12px;\">" + Resources.lang.BQ + "</span> </p><p align=\"center\" style=\"orphans:2;white-space:normal;widows:2;background-color:#FFFFFF;margin-top:0px;margin-bottom:0px;color:#666666;font-family:&#39;Microsoft YaHei&#39;, SimSun, Arial;padding:0px;\">");
    //templateBuilder.Append("<img src=\"/templates/green");
    //templateBuilder.Append("/images/wKgJNFIjQWqAJKM9AAAIu06yUwg699.png\" style=\"border-style:none;vertical-align:middle;margin:0px;padding:0px;\"><span style=\"color:#666666;font-size:12px;\">&nbsp;</span><img title=\"网站备案\" src=\"");
    //templateBuilder.Append("/templates/green");
    //templateBuilder.Append("/images/wKgJNFIhXSiAHPFHAAAGom5QmAk433.png\" height=\"50\" width=\"110\" style=\"border-style:none;vertical-align:middle;margin:0px;padding:0px;\"><span style=\"color:#666666;font-size:12px;\">&nbsp;&nbsp;</span><img src=\"");
    //templateBuilder.Append("/templates/green");
    //templateBuilder.Append("/images/wKgJNFIy2qyAEa3yAAAMqg2PFik097.jpg\" style=\"border-style:none;vertical-align:middle;margin:0px;padding:0px;\"><span style=\"color:#666666;font-size:12px;\">&nbsp;</span><img title=\"网银\" src=\"");
    //templateBuilder.Append("/templates/green");
    //templateBuilder.Append("/images/wKgJNFIhXS-AVNvhAAAJ3K_rPvM818.png\" height=\"50\" width=\"140\" style=\"border-style:none;vertical-align:middle;margin:0px;padding:0px;\">");
    templateBuilder.Append("<span style=\"color:#666666;font-size:12px;\">&nbsp;&nbsp;</span><span style=\"color:#666666;font-size:12px;\">&nbsp;</span></p><p align=\"center\" style=\"orphans:2;white-space:normal;widows:2;background-color:#FFFFFF;margin-top:0px;margin-bottom:0px;color:#666666;font-family:&#39;Microsoft YaHei&#39;, SimSun, Arial;padding:0px;\"><span style=\"margin:0px;padding:0px;font-family:&#39;Microsoft YaHei&#39;;line-height:2;color:#666666;font-size:12px;\">" + Resources.lang.Support + ":&nbsp;</span><span style=\"outline:none;margin:0px;padding:0px;font-family:&#39;Microsoft YaHei&#39;;line-height:2;\"><span style=\"outline:none;text-decoration:none;color:#666666;margin:0px;padding:0px;font-size:12px;\"><a href=\"\" target=\"_blank\" style=\"outline:none;text-decoration:none;color:#2A586F;margin:0px;padding:0px;\"><span style=\"color:#666666;\">腾龙科技</span></a></span></span> </p></div></div></div>\r\n	</div>\r\n</div>\r\n</div>  \r\n\r\n<script src=\"");
    templateBuilder.Append("/templates/green");

	templateBuilder.Append("/images/header.js\" type=\"text/javascript\"></");
	templateBuilder.Append("script>\r\n<script type=\"text/javascript\">\r\n    show_store_nav();\r\n</");
	templateBuilder.Append("script>\r\n\r\n");


	templateBuilder.Append("\r\n<!--/Footer-->\r\n</body>\r\n</html>\r\n");
	Response.Write(templateBuilder.ToString());
}
</script>
