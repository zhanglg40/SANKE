using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Common;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace Web
{
    public partial class shoplist : Web.UI.UserPage
    {
        protected int totalCount;
        protected int page;
        protected int pageSize;
        private int id = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.pageSize = 20; //每页数量
            if (!Page.IsPostBack)
            {
                BLL.shop bll = new BLL.shop();
                string _strWhere = " user_id=" + userModel.id;
                string _orderby = "";
                this.rptList.DataSource = bll.GetList( _strWhere, _orderby);
                this.rptList.DataBind();
            }
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            this.id = AXRequest.GetQueryInt("id");
            BLL.shop bll = new BLL.shop();
            bll.Delete(this.id);
        }
        #region 增加" + Resources.lang.operating+ "=================================

        #endregion
        #region 修改" + Resources.lang.operating+ "=================================
       
        #endregion


    }
}