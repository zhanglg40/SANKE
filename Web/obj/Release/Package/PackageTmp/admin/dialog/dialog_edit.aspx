<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dialog_edit.aspx.cs" Inherits="Web.admin.dialog.dialog_edit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>修改商品數量窗口</title>
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../../scripts/jquery/PCASClass.js"></script>
    <script type="text/javascript" src="../js/layout.js"></script>
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
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

        //页面加载完成执行
        $(function () {
            $("#lbOrderNo").val($("#spanOrderNo", W.document).text());
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
            $("#lbAmount").val(price*num);
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
                "order_no": $("#spanOrderNo", W.document).text(), "edit_type": "order_edit",
                "id": $("#lbID").val(), "num": $("#tbNum").val()
            };
            //发送AJAX请求
            W.sendAjaxUrl(api, postData, "../../tools/admin_ajax.ashx?action=edit_order_status");
            return false;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="div-content">
        <dl>
            <dt>訂單號</dt>
            <dd><input type="text" id="lbOrderNo" class="input txt" disabled="disabled" style="color:Gray;"/>
                <input type="text" id="lbID" style="display:none;" value="<%=model.id %>" />
            </dd>
        </dl>
        <dl>
            <dt>商品名稱</dt>
            <dd><input type="text" id="lbGoodsName" class="input txt" value="<%=model.goods_title %>" disabled="disabled" style="color:Gray;"/></dd>
        </dl>
        <dl>
            <dt>單價</dt>
            <dd><input type="text" id="lbPrice" class="input txt" value="<%=model.real_price %>" disabled="disabled" style="color:Gray;"/> PLN</dd>
        </dl>
        <dl>
            <dt>數量</dt>
            <dd><input type="text" id="tbNum" class="input txt" value="<%=model.quantity %>" onkeypress="keyPress()" oninput="ChangeNum()" onpropertychange="ChangeNum()" /> <span class="Validform_checktip">*</span></dd>
        </dl>
        <dl>
            <dt>總金額</dt>
            <dd><input type="text" id="lbAmount" class="input txt" value="<%=model.real_price*model.quantity %>" disabled="disabled" style="color:Gray;"/></dd>
        </dl>
    </div>
    </form>
</body>
</html>
