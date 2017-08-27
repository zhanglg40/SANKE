<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="good_import.aspx.cs" Inherits="Web.admin.channel.good_import" %>

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
<link href="../skin/default/style.css" rel="stylesheet" type="text/css" />

</head>
    <script type="text/javascript">
        $(function () {
            
            //初始化上传控件
            $(".upload-img").each(function () {
                $(this).InitSWFUpload({ btntext: "导入", btnwidth: 83, sendurl: "../../tools/upload_ajax.ashx?action=ExcelFile", flashurl: "../../scripts/swfupload/swfupload.swf", filetypes: "*.xlsx;" });
            });
        });
        function tfff(data) {
           
            if (data.length == 0) {
                alert("导入成功！");
                $('#info1').html('导入成功');
            } else {
                for(var i=0;i<data.length;i++){
                    $('#tablist').append("<tr><td>" + data[i].id +
                                         "</td><td>" + data[i].code +
                                         "</td><td>" + data[i].name +
                                         "</td><td>" + data[i].result +
                                         "</td><td>" + data[i].reason + "</td></tr>");
                }
                $('#info').hide();
                alert("部分数据未导入成功！");
            }
          
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
      
    <li><a class="attachment" href="../../tools/download.ashx?id=1"><i></i><span>下载模板</span></a></li>
            <li>
          <asp:TextBox  ID="txtImgUrl"  visible="false" runat="server" CssClass="input normal upload-path" />
           <div class="upload-box upload-img"> </div>
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
    <th  style="width:8%">序号</th>
    <th align="left" style="width:15%">条形码</th>
    <th align="left" style="width:15%">商品名称</th>
    <th align="left">上传状态</th>
    <th align="left" style="width:38%">失败原因</th>
  </tr>
</HeaderTemplate>
<ItemTemplate>
  <tr>
    <td><asp:HiddenField ID="hidId" Value='<%#Eval("id")%>' runat="server" /><%#Eval("id")%></td>
    <td><a href="payment_edit.aspx?id=<%#Eval("id")%>"><%#Eval("title")%></a></td>
    <td><%#Eval("img_url").ToString() == "" ? "-" : "<img width=\"120\" src=\"" + Eval("img_url") + "\" />"%></td>
    <td><%#Eval("remark")%></td>
    <td><asp:TextBox ID="txtSortId" runat="server" Text='<%#Eval("sort_id")%>' CssClass="sort" onkeydown="return checkNumber(event);" /></td>

  </tr>
</ItemTemplate>
<FooterTemplate>
  <tr><td  id="info" align='center' colspan='7'><div id="info1">暂无记录</div></td></tr>
</table>
</FooterTemplate>
</asp:Repeater>
<!--/列表-->
    </form>

</body>
</html>
