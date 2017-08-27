﻿using System;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;
using System.IO;
using System.Collections;
using Aspose.Cells;
using System.Reflection;
using CheckBox = System.Web.UI.WebControls.CheckBox;
namespace Web.admin.order
{
    public partial class order_confirm : Web.UI.ManagePage
    {
        protected int totalCount;
        protected int page;
        protected int pageSize;

        protected string keywords = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.keywords = AXRequest.GetQueryString("keywords");

            this.pageSize = GetPageSize(10); //每页数量
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("order_list", AXEnums.ActionEnum.View.ToString()); //检查权限
                RptBind("status=1" + CombSqlTxt(this.keywords), "add_time desc,id desc");
            }
        }

        #region 数据绑定=================================
        private void RptBind(string _strWhere, string _orderby)
        {
            this.page = AXRequest.GetQueryInt("page", 1);
            txtKeywords.Text = this.keywords;
            BLL.orders bll = new BLL.orders();
            this.rptList.DataSource = bll.GetList(this.pageSize, this.page, _strWhere, _orderby, out this.totalCount);
            this.rptList.DataBind();

            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("order_confirm.aspx", "keywords={0}&page={1}", this.keywords, "__id__");
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
        }
        #endregion

        #region 组合SQL查询语句==========================
        protected string CombSqlTxt(string _keywords)
        {
            StringBuilder strTemp = new StringBuilder();
            _keywords = _keywords.Replace("'", "");
            if (!string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append(" and (order_no like '%" + _keywords + "%' or user_name like '%" + _keywords + "%' or accept_name like '%" + _keywords + "%')");
            }
            return strTemp.ToString();
        }
        #endregion

        #region 返回用户每页数量=========================
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("order_confirm_page_size"), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    return _pagesize;
                }
            }
            return _default_size;
        }
        #endregion

        #region 返回订单状态=============================
        protected string GetOrderStatus(int _id)
        {
            string _title = string.Empty;
            Model.orders model = new BLL.orders().GetModel(_id);
            switch (model.status)
            {
                case 1: //如果是线下支付，支付状态为0，如果是线上支付，支付成功后会自动改变订单状态为已确认
                    if (model.payment_status > 0)
                    {
                        _title = "待付款";
                    }
                    else
                    {
                        _title = "待确认";
                    }
                    break;
                case 2: //如果订单为已确认状态，则进入送货状态
                    if (model.express_status > 1)
                    {
                        _title = "已送货";
                    }
                    else
                    {
                        _title = "待送货";
                    }
                    break;
                case 3:
                    _title = "交易完成";
                    break;
                case 4:
                    _title = "已取消";
                    break;
                case 5:
                    _title = "已作废";
                    break;
            }

            return _title;
        }
        #endregion

        //关健字查询
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("order_confirm.aspx", "keywords={0}", txtKeywords.Text));
        }
        protected void btnExport2_Click(object sender, EventArgs e)
        {

            Workbook workbook = new Workbook();
           
            //清除页先 要不然 新建就有一个sheet
            workbook.Worksheets.Clear();
             //为标题设置样式    
              Aspose.Cells.Style styleTitle = workbook.Styles[workbook.Styles.Add()];//新增样式
            styleTitle.HorizontalAlignment = TextAlignmentType.Center;//文字居中
            StringBuilder sb = new StringBuilder();
            sb.Append("(");
            BLL.orders bll = new BLL.orders();
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);

                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    Model.orders model = bll.GetModel(id);
                   // sb.Append(id).Append(",");
                 Worksheet sheet=workbook.Worksheets.Add(model.order_no);
                
                   sheet.Cells["A" + 1].PutValue("No");
                     sheet.Cells["B" + 1].PutValue("Barcode");
                  sheet.Cells["C" + 1].PutValue("Name");
                   sheet.Cells["D" + 1].PutValue("NameP");
                   sheet.Cells["E" + 1].PutValue("Quantity");
                   sheet.Cells["F" + 1].PutValue("UnitPrice");
                   sheet.Cells["G" + 1].PutValue("DiscountRate");
                   sheet.Cells["A" + 2].PutValue("税号");
                   sheet.Cells["B" + 2].PutValue("条形码");
                   sheet.Cells["C" + 2].PutValue("中文名");
                   sheet.Cells["D" + 2].PutValue("外文名");
                   sheet.Cells["E" + 2].PutValue("数量");
                   sheet.Cells["F" + 2].PutValue("批发价");
                   sheet.Cells["G" + 2].PutValue("折扣率");
                
                    int j=3;
                    foreach (Model.order_goods good in model.order_goods)
                    {

                        sheet.Cells["A" + j].PutValue(model.taxid);
                        sheet.Cells["B" + j].PutValue(good.Barcode);
                        sheet.Cells["C" + j].PutValue(good.goods_title);
                        sheet.Cells["D" + j].PutValue(good.english_name);
                        sheet.Cells["E" + j].PutValue(good.quantity);
                        sheet.Cells["F" + j].PutValue(good.real_price);
                        if (good.real_price == 0)
                            sheet.Cells["G" + j].PutValue("");
                        else
                        {
                            decimal d = good.real_price * 100 / good.goods_price;

                            sheet.Cells["G" + j].PutValue(d.ToString("#0.0"));
                        }
                        j++;
                    }
                }
            }
       
            workbook.Save(DateTime.Now.ToString("yyyyMMddhhmmss") + ".xlsx", Aspose.Cells.FileFormatType.Excel2007Xlsx, Aspose.Cells.SaveType.OpenInExcel, Response);
        }
        //设置分页数量
        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("order_confirm_page_size", _pagesize.ToString(), 14400);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("order_confirm.aspx", "keywords={0}", this.keywords));
        }
        /// <summary>
        /// 导出订单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnExport_Click(object sender, EventArgs e)
        {
           // string path1 = "/upload/templates/Webshop.xlsx";
            
            string filename =Path.Combine(  "/upload/excel",Common.Utils.GetCheckCode(12) + ".xlsx");
          filename=  Common.Utils.GetMapPath(filename);
            //复制文件 
         //   System.IO.File.Copy(Utils.GetMapPath(path1), filename);
            List<DictionaryEntry> list = new List<DictionaryEntry>();
             BLL.orders bll = new BLL.orders();
             int count = 0;
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                  int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    count++;
                    Model.orders model = bll.GetModel(id);
                    List<string> sd = new List<string>();
                    List<IList<object>> ld = new List<IList<object>>();
                 
                   DictionaryEntry de =
                               new DictionaryEntry();

                   sd.Add(model.order_no);
                   sd.Add("No");
                   sd.Add("Barcode");
                   sd.Add("Name");
                   sd.Add("NameP");
                   sd.Add("Quantity");
                   sd.Add("UnitPrice");
                   sd.Add("DiscountRate");
                   IList<object> il1 = new List<object>();
                   il1.Add("税号");
                   il1.Add("条形码");
                   il1.Add("中文名");
                   il1.Add("外文名");
                   il1.Add("数量");
                   il1.Add("批发价");
                   il1.Add("折扣率");
                   ld.Add(il1);
                   foreach (Model.order_goods good in model.order_goods)
                   {
                       IList<object> il = new List<object>();
                       il.Add(model.taxid);
                       il.Add(good.Barcode);
                       il.Add(good.goods_title);
                       il.Add(good.english_name);
                       il.Add(good.quantity);
                       il.Add(good.real_price);
                       if (good.real_price == 0)
                           il.Add("");
                       else
                       {
                           decimal d = good.real_price * 100 / good.goods_price;
                         
                           il.Add(d.ToString("#0.0"));
                       }
                       ld.Add(il);
                   }
                  
                   
                  // ld.Add(il);
                    de.Key = sd;
                    de.Value = ld;
                    list.Add(de);
                }
            }
            if (count == 0) return;
            Common.ExcelHelper.NewExport(list, filename);
                // We successfully managed to export to an Excel file.
                // Now, get the ASP.Net application to open this Excel file, ready for the user to view.
                Response.ClearContent();
                FileStream fs1 = new FileStream(filename, FileMode.Open, FileAccess.Read);
                byte[] data1 = new byte[fs1.Length];
                fs1.Read(data1, 0, data1.Length);

                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("Content-Disposition", string.Format("attachment; filename={0}", filename));
                Response.BinaryWrite(data1);
                Response.End();
          
        }
        //确认订单
        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("order_list", AXEnums.ActionEnum.Confirm.ToString()); //检查权限
            int sucCount = 0;
            int errorCount = 0;
            BLL.orders bll = new BLL.orders();
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    Model.orders model = bll.GetModel(id);
                    if (model != null)
                    {
                        //检查订单是否使用在线支付方式
                        if (model.payment_status > 0)
                        {
                            //在线支付方式
                            model.payment_status = 2; //标志已付款
                            model.payment_time = DateTime.Now; //支付时间
                            model.status = 2; // 订单为确认状态
                            model.confirm_time = DateTime.Now; //确认时间
                        }
                        else
                        {
                            //线下支付方式
                            model.status = 2; // 订单为确认状态
                            model.confirm_time = DateTime.Now; //确认时间
                        }
                        if (bll.Update(model))
                        {
                            sucCount++;
                        }
                        else
                        {
                            errorCount++;
                        }
                    }
                    else
                    {
                        errorCount++;
                    }
                }
            }
            AddAdminLog(AXEnums.ActionEnum.Confirm.ToString(), "确认订单成功" + sucCount + "条，失败" + errorCount + "条"); //记录日志
            JscriptMsg("确认成功" + sucCount + "条，失败" + errorCount + "条！", Utils.CombUrlTxt("order_confirm.aspx", "keywords={0}", this.keywords), "Success");
        }
    }
}