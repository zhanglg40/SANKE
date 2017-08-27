using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;

namespace Web
{
    public partial class dialog_shop : Web.UI.UserPage
    {
        private int id;
        public string title;
        public int quantity;
        protected Model.article_attribute_value model = new Model.article_attribute_value();
        private float price;
        protected int channel_id;
        protected int totalCount;
        protected int page;
        protected int pageSize;

        protected int category_id;
        protected string channel_name = string.Empty;
        protected string property = string.Empty;
        protected string keywords = string.Empty;
        protected string action = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.id = AXRequest.GetQueryInt("id");
            this.title = AXRequest.GetQueryString("title");
            quantity = AXRequest.GetQueryInt("quantity");
            price = AXRequest.GetQueryFloat("price",0);
            if (!Page.IsPostBack)
            {
                BLL.shop_log bll = new BLL.shop_log();
                string _strWhere = " user_id=" + userModel.id;
                string _orderby = "";
                this.rptList.DataSource = bll.GetShopList(_strWhere, _orderby);
                this.rptList.DataBind();
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Getstr();
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {

        }
        protected void Getstr()
        {
            int tolcount=0;
            List<Model.shop_log> list = new List<Model.shop_log>();
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
              //  int state = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidState")).Value);
               
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    Model.shop_log shop = new Model.shop_log();
                     Model.users userModel = new Web.UI.BasePage().GetUserInfo();
                     shop.user_id = userModel.id;
                    
                    int count;
                    if (!int.TryParse(((TextBox)rptList.Items[i].FindControl("txtQuantity")).Text.Trim(), out count))
                    {
                        count = 0;
                    }
                    shop.quantity = count;
                    shop.goods_id = this.id;
                    shop.shop_id = id;
                    list.Add(shop);
                        tolcount = tolcount + count;
                    
  
                }
            }
            string message = "";
           
            if (quantity == tolcount)
            {
                BLL.shop_log shop = new BLL.shop_log();
                shop.AddList(list);
                message = "true";
            }
            else
            {
                message = "错误：请与加入购物车数量保持一致";
                ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language='javascript' defer>alert('" + message + "');</script>");
                return;
            }
            ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>setData(" + message + "," + quantity + "," + quantity*price + "," + this.id + ");</script>");//后台调用前台JS
        }
    }
}