<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dialog_printthreshold.aspx.cs" Inherits="Web.admin.dialog.dialog_printthreshold" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>打印订单窗口</title>
<script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
<script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
<script type="text/javascript">
    $(function () {
         printWin();
    });
    //窗口API
    var api = frameElement.api, W = api.opener;
    api.button({
        name: '确认打印',
        focus: true,
        callback: function () {
            printWin();
        }
    }, {
        name: '取消'
    });
    //打印方法
    function printWin() {
        var oWin = window.open("", "_blank");
        oWin.document.write(document.getElementById("content").innerHTML);
        oWin.focus();
        oWin.document.close();
        oWin.print()
        oWin.close()
    }
</script>
</head>

<body style="margin:0;">
<form id="form1" runat="server">
<div id="content">
<table width="800" border="0" align="center" cellpadding="3" cellspacing="0" style="font-size:12px; font-family:'微软雅黑'; background:#fff;">
    <tr>
        <td width="346" height="30" style="font-size:10px;">供内部使用</td>
        <td width="220"  style="font-size:10px;">打印时间：<%=DateTime.Now%></td>
    </tr>
<tr>
  <td width="346" height="30" style="font-size:20px;"><%=siteConfig.webname%></td>
  <td width="216" style="font-size:20px;"> 库存不足商品明细表</td>
 
</tr>
<tr>
  <td colspan="3" style="padding:10px 0; ">
  <asp:Repeater ID="rptList" runat="server">
      <HeaderTemplate>
        <table width="100%" border="1" cellspacing="0" cellpadding="5" style="font-size:12px; font-family:'微软雅黑'; background:#fff;">
          <tr>
            <td width="8%" align="left" style="background:#ccc;">商品编号</th>
            <td width="12%" align="left" style="background:#ccc;">商品名称</td>
            <td width="8%" align="left" style="background:#ccc;">成本</td>
           
            <td width="8%" align="left" style="background:#ccc;">库存量</td>
            <td width="12%" align="left" style="background:#ccc;">供应商</td>
               <td width="12%" align="left" style="background:#ccc;">电话/Email</td>
           <td width="32%" align="left" style="background:#ccc;">地址</td>
                 <td width="7%" align="left" style="background:#ccc;">订购量</td>
          </tr>
      </HeaderTemplate>
      <ItemTemplate>
          <tr>
            <td><%#Eval("goods_no")%></td>
            <td><%#Eval("title")%></td>
            <td><%#Eval("PurchasePrice")%></td>
          
            <td><%#Eval("stock_quantity")%></td>
            <td></td>
         <td></td>
                <td></td>
                <td></td>
              
          </tr>
      </ItemTemplate>
      <FooterTemplate>
            <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"5\">暂无记录</td></tr>" : ""%>
          </table>
     </FooterTemplate>
  </asp:Repeater>
  </td>
  </tr>

</table>
</div>
</form>
</body>
</html>