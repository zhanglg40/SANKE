using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;

namespace Web.admin.dialog
{
    public partial class dialog_edit : Web.UI.ManagePage
    {
        private int id = 0;
        protected Model.order_goods model = new Model.order_goods();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.id = AXRequest.GetQueryInt("id");
            if (this.id == 0)
            {
                JscriptMsg("传输参数不正确！", "back", "Error");
                return;
            }
            if (!new BLL.orders().ExistsGoods(this.id))
            {
                JscriptMsg("记录不存在或已被删除！", "back", "Error");
                return;
            }
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("order_list", AXEnums.ActionEnum.View.ToString()); //检查权限
                ShowInfo(this.id);
            }
        }

        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {
            BLL.orders bll = new BLL.orders();
            model = bll.GetModelGoods(_id);
        }
        #endregion
    }
}