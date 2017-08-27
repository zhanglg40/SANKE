<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dialog_list.aspx.cs" Inherits="Web.admin.dialog.dialog_list" %>
<%@ Import namespace="Common" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>新添商品</title>
<script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
<script type="text/javascript" src="../../scripts/jquery/jquery.lazyload.min.js"></script>
<script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
<script type="text/javascript" src="../js/layout.js"></script>
<link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
<link  href="../../css/pagination.css" rel="stylesheet" type="text/css" />
<script type="text/javascript">
    //窗口API
    var api = frameElement.api, W = api.opener;
    api.button({
        name: '确定',
        focus: true,
        callback: function () {
            submitForm();
            return false;
        }
    }, {
        name: '取消'
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
        if ((keyCode >= 48 && keyCode <= 57)) {
            event.returnValue = true;
        } else {
            event.returnValue = false;
        }
    }
    //change事件
    function ChangeNum() {
        var price = $("#lbPrice").val();
        var num = $("#tbNum").val();
        $("#lbAmount").val(price * num);
    }  
    //排列图文列表
    function imgLayout() {
        var imgWidth = $(".imglist").width();
        var lineCount = Math.floor(imgWidth / 222);
        var lineNum = imgWidth % 222 / (lineCount - 1);
        $(".imglist ul").width(imgWidth + Math.ceil(lineNum));
        $(".imglist ul li").css("margin-right", parseFloat(lineNum));
    }
    //等比例缩放图片大小
    function AutoResizeImage(e, s) {
        var img = new Image();
        img.src = $(this).attr("src")
        var w = img.width;
        var h = img.height;
        var wRatio = w / h;
        if ((220 / wRatio) >= 165) {
            $(this).width(220); $(this).height(220 / wRatio);
        } else {
            $(this).width(165 * wRatio); $(this).height(165);
        }
    }
    //提交表单处理
    function submitForm() {
        //验证表单
        if ($("#tbNum").val() == "") {
            W.$.dialog.alert('請填寫數量！', function () { $("#tbNum").focus(); }, api);
            return false;
        }
        //下一步，AJAX提交表单
        var postData = {
            "order_no": $("#spanOrderNo", W.document).text(), "edit_type": "order_add",
            "id": $("#lbID").val(), "num": $("#tbNum").val(), "amount": $("#lbAmount").val()
        };
        //发送AJAX请求
        W.sendAjaxUrl(api, postData, "../../tools/admin_ajax.ashx?action=edit_order_status");
        return false;
    }
</script>
</head>
<body class="mainbody">
<form id="form1" runat="server">
<!--工具栏-->
<div class="toolbar-wrap">
  <div id="floatHead" class="toolbar">
    <div class="l-list">
      <ul class="icon-list">
        <li><asp:LinkButton ID="btn" runat="server" CssClass="save" onclick="btnSearch_Click" Visible="false"><i></i><span>返回</span></asp:LinkButton></li>
      </ul>
      <div id="dll" class="menu-list" runat="server">
        <div class="rule-single-select">
          <asp:DropDownList ID="ddlCategoryId" runat="server" AutoPostBack="True" onselectedindexchanged="ddlCategoryId_SelectedIndexChanged"></asp:DropDownList>
        </div>
        <div class="rule-single-select">
          <asp:DropDownList ID="ddlProperty" runat="server" AutoPostBack="True" onselectedindexchanged="ddlProperty_SelectedIndexChanged">
            <asp:ListItem Value="" Selected="True">所有属性</asp:ListItem>
            <asp:ListItem Value="isMsg">允许评论</asp:ListItem>
            <asp:ListItem Value="isTop">置顶</asp:ListItem>
            <asp:ListItem Value="isRed">推荐</asp:ListItem>
            <asp:ListItem Value="isHot">热门</asp:ListItem>
            <asp:ListItem Value="isSlide">幻灯片</asp:ListItem>
          </asp:DropDownList>
        </div>
      </div>
    </div>
    <div class="r-list">
      <asp:TextBox ID="txtKeywords" runat="server" CssClass="keyword" />
      <asp:LinkButton ID="lbtnSearch" runat="server" CssClass="btn-search" onclick="btnSearch_Click">查询</asp:LinkButton>
      <asp:LinkButton ID="lbtnViewTxt" runat="server" CssClass="txt-view" Visible="false" onclick="lbtnViewTxt_Click" ToolTip="文字列表视图" />
    </div>
  </div>
</div>
<!--/工具栏-->
<!--文字列表-->
<asp:Repeater ID="rptList1" runat="server">
<HeaderTemplate>
<table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
  <tr>
    <th align="left">标题</th>
    <th align="left" width="20%">所属类别</th>
    <th align="left" width="20%">金額</th>
  </tr>
</HeaderTemplate>
<ItemTemplate>
  <tr>
    <td><a href="dialog_list.aspx?action=add&channel_id=<%#this.channel_id %>&id=<%#Eval("id")%>"><%#Eval("title")%></a></td>
    <td><%#new BLL.article_category().GetTitle(Convert.ToInt32(Eval("category_id")))%></td>
    <td><%#Eval("sell_price")%></td>
  </tr>
</ItemTemplate>
<FooterTemplate>
<%#rptList1.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"7\">暂无记录</td></tr>" : ""%>
</table>
</FooterTemplate>
</asp:Repeater>
<!--/文字列表-->

<!--图片列表-->
<div id="goods" class="div-content" style="display:none;" runat="server">
    <dl>
        <dt>訂單號</dt>
        <dd><input type="text" id="lbOrderNo" class="input txt" disabled="disabled" style="color:Gray;"/>
            <input type="text" id="lbID" style="display:none;" value="<%=model==null?0:model.Id %>" />
        </dd>
    </dl>
    <dl>
        <dt>商品名稱</dt>
        <dd><input type="text" id="lbGoodsName" class="input txt" value="<%=model==null?"":model.Title %>" disabled="disabled" style="color:Gray;"/></dd>
    </dl>
    <dl>
        <dt>單價</dt>
        <dd><input type="text" id="lbPrice" class="input txt" value="<%=model==null?0:model.Price %>" disabled="disabled" style="color:Gray;"/> PLN</dd>
    </dl>
    <dl>
        <dt>庫存</dt>
        <dd><input type="text" id="Text1" class="input txt" value="<%=model==null?0:model.Num %>" disabled="disabled" style="color:Gray;"/></dd>
    </dl>
    <dl>
        <dt>數量</dt>
        <dd><input type="text" id="tbNum" class="input txt" onkeypress="keyPress()" oninput="ChangeNum()" onpropertychange="ChangeNum()" /> <span class="Validform_checktip">*</span></dd>
    </dl>
    <dl>
        <dt>總金額</dt>
        <dd><input type="text" id="lbAmount" class="input txt" value="<%=model==null?0:(model.Price)%>" disabled="disabled" style="color:Gray;"/></dd>
    </dl>
</div>
<!--/图片列表-->

<!--内容底部-->
<div id="foot" runat="server">
<div class="line20"></div>
<div class="pagelist">
  <div class="l-btns">
    <span>显示</span><asp:TextBox ID="txtPageNum" runat="server" CssClass="pagenum" onkeydown="return checkNumber(event);" ontextchanged="txtPageNum_TextChanged" AutoPostBack="True"></asp:TextBox><span>条/页</span>
  </div>
  <div id="PageContent" runat="server" class="default"></div>
</div>
</div>
<!--/内容底部-->

</form>
</body>
</html>
