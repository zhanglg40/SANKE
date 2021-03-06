﻿//删除元素
function HintRemove(obj){
	$("#"+obj).remove();
}
function change(webpath) {
    $.ajax({
        type: "post",
        url: webpath + "tools/submit_ajax.ashx?action=change_languane",
        
        dataType: "json",
        beforeSend: function(XMLHttpRequest) {
            //发送前动作
        },
        success: function(data, textStatus) {
            location.href = "index.aspx";
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("状态：" + textStatus + "；出错提示：" + errorThrown);
        },
        timeout: 20000
    });
}
//添加进购物车
function CartAdd(obj, webpath, linktype, linkurl){
	if($("#goods_id").val()=="" || $("#goods_quantity").val()==""){
		return false;
	}
	$.ajax({
		type: "post",
		url: webpath + "tools/submit_ajax.ashx?action=cart_goods_add",
		data: {
			"goods_id" : $("#goods_id").val(),
			"goods_quantity" : $("#goods_quantity").val()
		},
		dataType: "json",
		beforeSend: function(XMLHttpRequest) {
			//发送前动作
		},
		success: function(data, textStatus) {
			if (data.status == 1) {
				if(linktype==1){
					location.href=linkurl;
				}else{
					$("#cart_info_hint").remove();
					var HintHtml = '<div id="cart_info_hint" class="msg_tips cart_info">'
						+ '<div class="ico"></div>'
						+ '<div class="msg">'
						+ '<strong>商品已成功添加到购物车！</strong>'
						+ '<p>购物车共有<b>' + data.quantity + '</b>件商品，合计：<b class="red">' + data.amount + '</b>PLN</p>'
						+ '<a class="btn btn-success" title="去购物车结算" href="' + linkurl + '">去结算</a>&nbsp;&nbsp;'
						+ '<a title="再逛逛" href="javascript:;" onclick="HintRemove(\'cart_info_hint\');">再逛逛</a>'
						+ '<a class="close" title="关闭" href="javascript:;" onclick="HintRemove(\'cart_info_hint\');"><span>关闭</span></a>'
						+ '</div>'
						+ '</div>'
					$(obj).after(HintHtml); //添加节点
				}
			} else {
				$("#cart_info_hint").remove();
				var HintHtml = '<div id="cart_info_hint" class="msg_tips cart_info">'
					+ '<div class="ico error"></div>'
					+ '<div class="msg">'
					+ '<strong>商品添加到购物车失败！</strong>'
					+ '<p>' + data.msg + '</p>'
					+ '<a class="close" title="关闭" href="javascript:void(0);" onclick="HintRemove(\'cart_info_hint\');"><span>关闭</span></a>'
					+ '</div>'
					+ '</div>'
				$(obj).after(HintHtml); //添加节点
				//alert(data.msg);
			}
		},
		error: function (XMLHttpRequest, textStatus, errorThrown) {
			alert("状态：" + textStatus + "；出错提示：" + errorThrown);
		},
		timeout: 20000
	});
	return false;
}
//正则，验证数字
function validate(value) {
   
    reg = /^\d*$/;
    if (!reg.test(value)) {
        return false;
    }
    return true;
}

//添加进购物车
function CartAddNew(obj, id, webpath, linktype, linkurl,lang) {
   
  
    
    if ($("#goods_id").val() == "" || $("#goods_quantity" + id).val() == "") {
        return false;
    }
    if (!validate($("#goods_quantity" + id).val())) {
        if (lang == "pl-PL") {
            alert("Proszę podać liczbę całkowitą");
        } else {
            alert("请输入数字");
        }
       
        return false;
    }
    if (parseInt($("#goods_quantity" + id).val()) > parseInt($("#goods_count" + id).val())) {
        if (lang == "pl-PL") {
            alert("Proszę podać liczbę całkowitą");
        } else {
            alert("Brak w magazynie");
        }
       
        return false;
    }
    $.ajax({
        type: "post",
        url: webpath + "tools/submit_ajax.ashx?action=cart_goods_add",
        data: {
            "goods_id": id,
            "goods_quantity": $("#goods_quantity" + id).val()
        },
        dataType: "json",
        beforeSend: function (XMLHttpRequest) {
            //发送前动作
        },
        success: function (data, textStatus) {
            if (data.status == 1) {
                if (linktype == 1) {
                    location.href = linkurl;
                } else {
                    $("#cart_info_hint").remove();
                    var HintHtml = '<div id="cart_info_hint" class="msg_tips cart_info">'
						+ '<div class="ico"></div>'
						+ '<div class="msg">'
						+ '<strong>商品已成功添加到购物车！</strong>'
						+ '<strong>购物车共有<b>' + data.quantity + '</b>件商品，合计：<b class="red">' + data.amount + '</b>PLN</strong>'
						+ '<a class="btn btn-success" title="去购物车结算" href="/shopping.aspx?action=cart">去结算</a>&nbsp;&nbsp;'
						+ '<a title="再逛逛" href="javascript:;" onclick="HintRemove(\'cart_info_hint\');">再逛逛</a>'
						+ '<a class="close" title="关闭" href="javascript:;" onclick="HintRemove(\'cart_info_hint\');"><span>关闭</span></a>'
						+ '</div>'
						+ '</div>';
                    if (lang == "pl-PL") {
                        HintHtml = '<div id="cart_info_hint" class="msg_tips cart_info">'
						+ '<div class="ico"></div>'
						+ '<div class="msg">'
						+ '<strong>Produkt został pomyślnie dodany do koszyka！</strong>'
						+ '<strong>Koszyk Total<b>' + data.quantity + '</b>Kawałki towarów, ogółem：<b class="red">' + data.amount + '</b>PLN</strong>'
						+ '<a class="btn btn-success" title="去购物车结算" href="/shopping.aspx?action=cart">Ustalić</a>&nbsp;&nbsp;'
						+ '<a title="Rozejrzeć się" href="javascript:;" onclick="HintRemove(\'cart_info_hint\');">Rozejrzeć się</a>'
						+ '<a class="close" title="Zamknięte" href="javascript:;" onclick="HintRemove(\'cart_info_hint\');"><span>Zamknięte</span></a>'
						+ '</div>'
						+ '</div>';
                    }
                    $(obj).after(HintHtml); //添加节点
                }
            } else {
                $("#cart_info_hint").remove();
                var HintHtml = '<div id="cart_info_hint" class="msg_tips cart_info">'
					+ '<div class="ico error"></div>'
					+ '<div class="msg">'
					+ '<strong>商品添加到购物车失败！</strong>'
					+ '<p>' + data.msg + '</p>'
					+ '<a class="close" title="关闭" href="javascript:void(0);" onclick="HintRemove(\'cart_info_hint\');"><span>关闭</span></a>'
					+ '</div>'
					+ '</div>'
                if (lang == "pl-PL") {
                    HintHtml = '<div id="cart_info_hint" class="msg_tips cart_info">'
                   + '<div class="ico error"></div>'
                   + '<div class="msg">'
                   + '<strong>Dodano merchandising do koszyka！</strong>'
                   + '<p>' + data.msg + '</p>'
                   + '<a class="close" title="关闭" href="javascript:void(0);" onclick="HintRemove(\'cart_info_hint\');"><span>Zamknięte</span></a>'
                   + '</div>'
                   + '</div>'
                }
                $(obj).after(HintHtml); //添加节点
                //alert(data.msg);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("状态：" + textStatus + "；出错提示：" + errorThrown);
        },
        timeout: 20000
    });
    return false;
}

function CartAddShop(obj, id, webpath,title, linktype, linkurl) {

    if ($("#goods_id").val() == "" || $("#goods_quantity" + id).val() == "") {
        return false;
    }
    if (!validate($("#goods_quantity" + id).val())) {
        alert("请输入数字");
        return false;
    }

    if (parseInt($("#goods_quantity" + id).val()) > parseInt($("#goods_count" + id).val())) {
        alert("购买数量大于库存数");
        return false;
    }
    //修改商品數量

        var dialog = $.dialog({
            title: '购物车',
            id:"cart",
            content: 'url:dialog_shop.aspx?id=' + id + '&quantity=' + $("#goods_quantity" + id).val() + '&price=' + $("#goods_price" + id).val() + '&title=' + title,
            min: false,
            max: false,
            lock: true,
            width: 680,
            height: 350
        });

}
function CartShow(obj, id, quantity, price, linkurl) {

    var HintHtml = '<div id="cart_info_hint" class="msg_tips cart_info">'
+ '<div class="ico"></div>'
+ '<div class="msg">'
+ '<strong>商品已成功添加到购物车！</strong>'
+ '<strong>购物车共有<b>' + quantity + '</b>件商品，合计：<b class="red">' + price + '</b>PLN</strong>'
+ '<a class="btn btn-success" title="去购物车结算" href="/shoppingNew.aspx?action=cart">去结算</a>&nbsp;&nbsp;'
+ '<a title="再逛逛" href="javascript:;" onclick="HintRemove(\'cart_info_hint\');">再逛逛</a>'
+ '<a class="close" title="关闭" href="javascript:;" onclick="HintRemove(\'cart_info_hint\');"><span>关闭</span></a>'
+ '</div>'
+ '</div>'
    $(obj).after(HintHtml); //添加节点
}

//删除购物车商品
function DeleteCart(obj, webpath, goods_id){
	if(!confirm("您确认要从购物车中移除吗？") || goods_id==""){
		return false;
	}
	$.ajax({
		type: "post",
		url: webpath + "tools/submit_ajax.ashx?action=cart_goods_delete",
		data: {"goods_id" : goods_id},
		dataType: "json",
		beforeSend: function(XMLHttpRequest) {
			//发送前动作
		},
		success: function(data, textStatus) {
			if (data.status == 1) {
				location.reload();
			} else {
				alert(data.msg);
			}
		},
		error: function (XMLHttpRequest, textStatus, errorThrown) {
			alert("状态：" + textStatus + "；出错提示：" + errorThrown);
		},
		timeout: 20000
	});
	return false;
}
//删除购物车商品
function DeleteCartNew(obj, webpath, id) {
    if (!confirm("您确认要从购物车中移除吗？") || id == "") {
        return false;
    }
    $.ajax({
        type: "post",
        url: webpath + "tools/submit_ajax.ashx?action=cart_goods_deleteNew",
        data: { "id": id },
        dataType: "json",
        beforeSend: function (XMLHttpRequest) {
            //发送前动作
        },
        success: function (data, textStatus) {
            if (data.status == 1) {
                location.reload();
            } else {
                alert(data.msg);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("状态：" + textStatus + "；出错提示：" + errorThrown);
        },
        timeout: 20000
    });
    return false;
}
function SaveOrder(obj, webpath) {
   
    $.ajax({
        type: "post",
        url: webpath + "tools/submit_ajax.ashx?action=order_saveNew",
        //data: { "id": id },
        dataType: "json",
        beforeSend: function (XMLHttpRequest) {
            //发送前动作
        },
        success: function (data, textStatus) {
            if (data.status == 1) {
                location.reload();
            } else {
                alert(data.msg);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("状态：" + textStatus + "；出错提示：" + errorThrown);
        },
        timeout: 20000
    });
    return false;
}

//计算购物车金额
function CartAmountTotal(obj, webpath, goods_id){
	if(isNaN($(obj).val())){
		alert('商品数量只能输入数字!');
		$(obj).val("1");
	}
	$.ajax({
		type: "post",
		url: webpath + "tools/submit_ajax.ashx?action=cart_goods_update",
		data: {
			"goods_id" : goods_id,
			"goods_quantity" : $(obj).val()
		},
		dataType: "json",
		beforeSend: function(XMLHttpRequest) {
			//发送前动作
		},
		success: function(data, textStatus) {
			if (data.status == 1) {
				location.reload();
			} else {
				alert(data.msg);
				location.reload();
			}
		},
		error: function (XMLHttpRequest, textStatus, errorThrown) {
			alert("状态：" + textStatus + "；出错提示：" + errorThrown);
		},
		timeout: 20000
	});
	return false;
}
//购物车数量加减
function CartComputNum(obj, webpath, goods_id, num){
	if(num > 0){
		var goods_quantity = $(obj).prev("input[name='goods_quantity']");
		$(goods_quantity).val(parseInt($(goods_quantity).val()) + 1);
		//计算购物车金额
		CartAmountTotal($(goods_quantity), webpath, goods_id);
	}else{
		var goods_quantity = $(obj).next("input[name='goods_quantity']");
		if(parseInt($(goods_quantity).val()) > 1){
			$(goods_quantity).val(parseInt($(goods_quantity).val()) - 1);
			//计算购物车金额
			CartAmountTotal($(goods_quantity), webpath, goods_id);
		}
	}
}
//购物车数量加减
function CartComputNumNew(obj, webpath, id, shop_id, num) {

    if (num > 0) {
        var goods_quantity = $(obj).prev("input[name='goods_quantity']");
        $(goods_quantity).val(parseInt($(goods_quantity).val()) + 1);
        //计算购物车金额
        CartAmountTotalNew($(goods_quantity), webpath, id, shop_id);
    } else {
        var goods_quantity = $(obj).next("input[name='goods_quantity']");
        if (parseInt($(goods_quantity).val()) > 1) {
            $(goods_quantity).val(parseInt($(goods_quantity).val()) - 1);
            //计算购物车金额
            CartAmountTotalNew($(goods_quantity), webpath, id, shop_id);
        }
    }
}

//计算购物车金额
function CartAmountTotalNew(obj, webpath, id, shop_id) {
    if (isNaN($(obj).val())) {
        alert('商品数量只能输入数字!');
        $(obj).val("1");
    }
   
    $.ajax({
        type: "post",
        url: webpath + "tools/submit_ajax.ashx?action=cart_goods_updateNew",
        data: {
            "shop_id": shop_id,
            "goods_quantity": $(obj).val(),
            "id": id
        },
        dataType: "json",
        beforeSend: function (XMLHttpRequest) {
            //发送前动作
        },
        success: function (data, textStatus) {
            if (data.status == 1) {
                location.reload();
            } else {
                alert(data.msg);
                location.reload();
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("状态：" + textStatus + "；出错提示：" + errorThrown);
        },
        timeout: 20000
    });
    return false;
}
//计算支付手续费总金额
function PaymentAmountTotal(obj){
	var payment_price = $(obj).next("input[name='payment_price']").val();
	$("#payment_fee").text(payment_price); //运费
	OrderAmountTotal();
}
//计算配送费用总金额
function FreightAmountTotal(obj){
	var express_price = $(obj).next("input[name='express_price']").val();
	$("#express_fee").text(express_price); //运费
	OrderAmountTotal();
}
//计算订单总金额
function OrderAmountTotal(){
	var goods_amount = $("#goods_amount").text(); //商品总金额
	var payment_fee = $("#payment_fee").text(); //手续费
	var express_fee = $("#express_fee").text(); //运费
	var order_amount = parseFloat(goods_amount) + parseFloat(payment_fee) + parseFloat(express_fee); //订单总金额 = 商品金额 + 手续费 + 运费
	$("#order_amount").text(order_amount.toFixed(2));
}