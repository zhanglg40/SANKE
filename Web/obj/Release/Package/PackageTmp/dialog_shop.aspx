
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dialog_shop.aspx.cs" Inherits="Web.dialog_shop" %>
<%@ Import namespace="System.Collections.Generic" %>
<%@ Import namespace="System.Text" %>
<%@ Import namespace="System.Data" %>
<%@ Import namespace="Common" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>新添商品</title>
<script type="text/javascript" src="/scripts/jquery/jquery-1.10.2.min.js"></script>
<script type="text/javascript" src="/scripts/jquery/jquery.lazyload.min.js"></script>
<script type="text/javascript" src="/scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="/templates/green/js/cart.js">
<script type="text/javascript" src="../js/layout.js"></script>
<link href="/skin/default/style.css" rel="stylesheet" type="text/css" />
<link  href="/css/pagination.css" rel="stylesheet" type="text/css" />
    <style> 
.td{border:1px solid #F00} 
/* css注释：只对table td标签设置红色边框样式 */ 
</style> 
<script type="text/javascript">
    //窗口API
    var api = frameElement.api, W = api.opener;
    api.button({
        name: 'Dodaj do koszyka',
        focus: true,
        callback: function () {
            submitForm();
            return false;
        }
    }, {
        name: 'Anuluj'
    });
    $(function () {
        $("#lbOrderNo").val($("#spanOrderNo", W.document).text());
        imgLayout();
        $(window).resize(function () {
            imgLayout();
        });
        //图片延迟加载
        $(".pic img").lazyload({ load: AutoResizeImage, effect: "fadeIn" });
        //点击图片链接
        $(".pic img").click(function () {
            //$.dialog({ lock: true, title: "查看大图", content: "<img src=\"" + $(this).attr("src") + "\" />", padding: 0 });
            var linkUrl = $(this).parent().parent().find(".foot a").attr("href");
            if (linkUrl != "") {
                location.href = linkUrl; //跳转到修改页面
            }
        });
    });
    //只允許輸入數字
    function keyPress() {
        var keyCode = event.keyCode;
    }
        if ((keyCode >= 48 && keyCode <= 57)) {
            event.returnValue = true;
        } else {
            event.returnValue = false;
        }
        function setData(message, quantity, price, id) {
          
        CartShow(W.document.getElementById("zzz" + id), id, quantity, price, '');
        frameElement.api.close();
    }

    //提交表单处理
    function submitForm() {
        document.getElementById("btnSubmit").click();
       
       <%-- alert(1);
        var a = "<%=Getstr()%>";
        if (a == "true") {
            CartShow(W.document.getElementById("zzz273"), '273', '', '', '');
            frameElement.api.close();
        } else {
            alert(a);
        }--%>

        return false;
    }
</script>
</head>
<body class="mainbody">
<form id="form1" runat="server">
<!--工具栏-->
<div class="toolbar-wrap">
   <div><asp:Literal runat="server" Text="<%$ Resources:lang,productName%>" />： <%=title %></div> 
     <div><asp:Literal runat="server" Text="<%$ Resources:lang,buycount%>" />： <%=quantity %></div> 
</div>
<!--/工具栏-->
    <br />
<!--文字列表-->
<asp:Repeater ID="rptList" runat="server">
<HeaderTemplate>
<table style="width:100%;border: solid 1px #EEEEE0;border-collapse:collapse; "  class="ltable">
  <tr>
     <th style="width:10%;text-align:center"><asp:Literal runat="server" Text="<%$ Resources:lang,select%>" /></th>
    <th style="width:30%;text-align:center"><asp:Literal runat="server" Text="<%$ Resources:lang,store%>" /></th>
    <th style="width:50%;text-align:center"><asp:Literal runat="server" Text="<%$ Resources:lang,ShippingAddress%>" /></th>
      <th style="width:10%;text-align:center"><asp:Literal runat="server" Text="<%$ Resources:lang,buycount%>" /></th>
  </tr>
</HeaderTemplate>
<ItemTemplate>
  <tr>
        <td  style="width:10%;text-align:center"><asp:CheckBox ID="chkId" CssClass="checkall" runat="server" style="vertical-align:middle;" /><asp:HiddenField ID="hidId" Value='<%#Eval("id")%>' runat="server" /></td>
    <td style="width:30%;text-align:center"><%#Eval("shop_name")%></td>
    <td  style="width:50%;text-align:center"><%#Eval("address")%></td>
    <td  style="width:10%;text-align:center"><asp:TextBox ID="txtQuantity" runat="server" Text='<%#Eval("quantity")%>' CssClass="sort" onkeydown="return checkNumber(event);" /></td>
  </tr>
</ItemTemplate>
<FooterTemplate>
<%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"7\">" + Resources.lang.NoRecords+ "</td></tr>" : ""%>
</table>
</FooterTemplate>
</asp:Repeater>
<!--/文字列表-->
   
    <asp:Button ID="btnSubmit" style="display:none;" runat="server" Text="<%$ Resources:lang,Submits%>" CssClass="btn"  onclick="btnAdd_Click" />

</form>
</body>
</html>
