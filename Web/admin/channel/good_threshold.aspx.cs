using Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.admin.channel
{
    public partial class good_threshold : System.Web.UI.Page
    {
        protected int totalCount;
        protected int page;
        protected int pageSize;
        protected string keywords = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.keywords = AXRequest.GetQueryString("keywords");
            this.page = AXRequest.GetQueryInt("page", 1);
            this.pageSize = GetPageSize(10); //每页数量
            BLL.article bll = new BLL.article();
          //  bll.GetListthreshold(page, out totalCount, pageSize);
            DataTable dt = bll.GetListthreshold(page, out totalCount, pageSize).Tables[0];
            this.rptList.DataSource =dt;
            this.rptList.DataBind();
            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("good_threshold.aspx", "keywords={0}&page={1}", this.keywords, "__id__");
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
        }
   
   
        //设置分页数量
        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
           
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("good_threshold_page_size", _pagesize.ToString(), 14400);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("good_threshold.aspx", "keywords={0}", this.keywords));
        }
        #region 返回用户每页数量=========================
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("good_threshold_page_size"), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    return _pagesize;
                }
            }
            return _default_size;
        }
        #endregion
        /// <summary>
        /// 导出订单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnExport_Click(object sender, EventArgs e)
        {
            BLL.article bll = new BLL.article();
            DataTable dt = bll.GetListthreshold(0, out totalCount, 1000).Tables[0];
            string FileName = Common.Utils.GetCheckCode(12) + ".xls";
            Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
            Response.AppendHeader("Content-Disposition", "attachment;filename=" + FileName);
            string colHeaders = "", ls_item = "";
            string[] lst = new string[] { "商品编号", "商品名称", "成本", "库存量", "供应商", "电话/Email", "地址", "订购量" };
            int n = 0;
            //取得数据表各列标题，各标题之间以\t分割，最后一个列标题后加回车符
            foreach (string b in lst)
            {
                n++;
                if (n == (lst.Length))//最后一列，加\n
                {
                    colHeaders += b + "\n";
                }
                else
                {
                    colHeaders += b + "\t";
                }

            }
            Response.Write(colHeaders);
         
            //向HTTP输出流中写入取得的数据信息
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["goods_no"] == null) ls_item += "\t";
                else  ls_item += dt.Rows[i]["goods_no"].ToString() + "\t";
                ls_item += dt.Rows[i]["title"].ToString() + "\t";
                if (dt.Rows[i]["PurchasePrice"] == null) ls_item += "\t";
                else  ls_item += dt.Rows[i]["PurchasePrice"].ToString() + "\t";
                ls_item += dt.Rows[i]["stock_quantity"].ToString() + "\t";
                ls_item += "\t";
                ls_item += "\t";
                ls_item += "\t";
                ls_item += "\n";
                Response.Write(ls_item);
                ls_item = "";
            }
            Response.End();
        }
    }
}