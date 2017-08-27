<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="good_threshold.aspx.cs" Inherits="Web.admin.channel.good_threshold" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>商品导入</title>
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
<script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
<script type="text/javascript" src="../../scripts/jquery/Validform_v5.3.2_min.js"></script>
<script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
<script type="text/javascript" src="../../scripts/datepicker/WdatePicker.js"></script>
<script type="text/javascript" src="../../scripts/swfupload/swfupload.js"></script>
<script type="text/javascript" src="../../scripts/swfupload/swfupload.queue.js"></script>
    <script type="text/javascript" src="../../scripts/swfupload/swfupload.handlers.js"></script>
<script type="text/javascript" charset="utf-8" src="../../editor/kindeditor-min.js"></script>
<script type="text/javascript" charset="utf-8" src="../../editor/lang/zh_CN.js"></script>
<script type="text/javascript" src="../js/layout.js"></script>
    <link  href="../../css/pagination.css" rel="stylesheet" type="text/css" />
<link href="../skin/default/style.css" rel="stylesheet" type="text/css" />

</head>
    <script type="text/javascript">
        $(function () {
            
            //初始化上传控件
            $(".upload-img").each(function () {
                $(this).InitSWFUpload({ btntext: "导入", btnwidth: 83, sendurl: "../../tools/upload_ajax.ashx?action=ExcelFile", flashurl: "../../scripts/swfupload/swfupload.swf", filetypes: "*.xlsx;" });
            });
        });
        //打印订单
        function OrderPrint() {

            var dialog = $.dialog({
                title: '打印',
                content: 'url:dialog/dialog_printthreshold.aspx?order_no=B16060521441555',
                min: false,
                max: false,
                lock: true,
                width: 850//,
                //height: 500
            });
        }
        </script>
<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
<div class="location">
  <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>
  <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
  <i class="arrow"></i>
  <span>商品导入</span>
</div>
    <!--/导航栏-->

<!--工具栏-->
<div class="toolbar-wrap">
  <div id="floatHead" class="toolbar">
    <div class="l-list">
      <ul class="icon-list">
        <li><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全选</span></a></li>

   <li><a class="print" href="javascript:void(0)" onclick="OrderPrint()"><i></i><span>打印全部</span></a></li>
                 <li><asp:LinkButton ID="btnExport" runat="server" CssClass="attachment" onclick="btnExport_Click"><i></i><span>导出订单</span></asp:LinkButton></li>
            <li>

      </li>
      </ul>
    </div>

  </div>
</div>
<!--/工具栏-->
        <!--列表-->
<asp:Repeater ID="rptList" runat="server">
<HeaderTemplate>
<table id="tablist" width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
  <tr>
       <th width="8%">选择</th>
    <th align="left" style="width:8%">商品编号</th>
    <th align="left" style="width:15%">商品名称</th>
    <th align="left" style="width:15%">成本</th>
    <th style="width:10%" align="left">库存量</th>
    <th align="left" style="width:10%">阀值</th>
      <th></th>
  </tr>
</HeaderTemplate>
<ItemTemplate>
  <tr>
          <td align="center">
      <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" style="vertical-align:middle;" />
       <td><asp:HiddenField ID="hidId" Value='<%#Eval("goods_no")%>' runat="server" /><%#Eval("goods_no")%></td>
    </td>
  
    <td><a href="../article/article_edit.aspx?action=Edit&channel_id=2&id=<%#Eval("id")%>"><%#Eval("title")%></a></td>
<td><%#Eval("PurchasePrice")%></td>
    <td><%#Eval("stock_quantity")%></td>
          <td><%#Eval("threshold")%></td>
      <td></td>
  </tr>
</ItemTemplate>
<FooterTemplate>
  <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"9\">暂无记录</td></tr>" : ""%>
</table>
</FooterTemplate>
</asp:Repeater>
<!--/列表-->
        <!--内容底部-->
<div class="line20"></div>
<div class="pagelist">
  <div class="l-btns">
    <span>显示</span><asp:TextBox ID="txtPageNum" runat="server" CssClass="pagenum" onkeydown="return checkNumber(event);" ontextchanged="txtPageNum_TextChanged" AutoPostBack="True"></asp:TextBox><span>条/页</span>
  </div>
  <div id="PageContent" runat="server" class="default"></div>
</div>
<!--/内容底部-->
    </form>

</body>
</html>
