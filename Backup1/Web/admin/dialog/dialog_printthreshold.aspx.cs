using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;

namespace Web.admin.dialog
{
    public partial class dialog_printthreshold : Web.UI.ManagePage
    {
     //   private string order_no = string.Empty;
  

        protected void Page_Load(object sender, EventArgs e)
        {
            //order_no = AXRequest.GetQueryString("order_no");
            //if (order_no == "")
            //{
            //    JscriptMsg("传输参数不正确！", "back", "Error");
            //    return;
            //}
            //if (!new BLL.orders().Exists(order_no))
            //{
            //    JscriptMsg("订单不存在或已被删除！", "back", "Error");
            //    return;
            //}
            if (!Page.IsPostBack)
            {
                ShowInfo();
            }
        }

        #region 赋值操作=================================
        private void ShowInfo()
        {
            BLL.article bll = new BLL.article();
            int total = 0;
      

            this.rptList.DataSource = bll.GetListthreshold(0, out total, 1000);
            this.rptList.DataBind();
        }
        #endregion
    }
}