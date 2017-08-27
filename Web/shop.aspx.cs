using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;
namespace Web
{
    public partial class shop : Web.UI.UserPage
    {
        protected string action = string.Empty;
        protected string curr_login_ip = string.Empty;
        protected string pre_login_ip = string.Empty;
        protected string pre_login_time = string.Empty;
        protected int total_order;
        protected int total_msg;
        private int id = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = AXRequest.GetQueryString("action");

            if (!string.IsNullOrEmpty(_action) && _action == AXEnums.ActionEnum.Edit.ToString())
            {
                this.action = AXEnums.ActionEnum.Edit.ToString();//修改类型
                this.id = AXRequest.GetQueryInt("id");
                if (this.id == 0)
                {
                    JscriptMsg("传输参数不正确！", "back", "Error");
                    return;
                }
                if (!new BLL.article_attribute_field().Exists(this.id))
                {
                    JscriptMsg("记录不存在或已被删除！", "back", "Error");
                    return;
                }
            }else{
                action = _action;
            }
          
            if (!Page.IsPostBack)
            {
               
                if (action == AXEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.id);
                }
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (action == AXEnums.ActionEnum.Edit.ToString()) //修改
            {
             //   ChkAdminLevel("site_channel_field", AXEnums.ActionEnum.Edit.ToString()); //检查权限
                if (!DoEdit(this.id))
                {
                    txtMessage.Text = "保存过程中发生错误！";
                
                    return;
                }
                Response.Redirect(Utils.CombUrlTxt("usercenter.aspx", "action={0}", "address"));
               
            }
            else //添加
            {
             //   ChkAdminLevel("site_channel_field", AXEnums.ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    txtMessage.Text = "保存过程中发生错误！";
                    return;
                }
                Response.Redirect("shoplist.aspx");
            }
        }
        #region 增加" + Resources.lang.operating+ "=================================
        private bool DoAdd()
        {
            bool result = false;
            Model.shop model = new Model.shop();
            BLL.shop bll = new BLL.shop();
            Model.users userModel = new Web.UI.BasePage().GetUserInfo();
            model.address = txtAddress.Text.Trim(); ;
            model.user_id = userModel.id;
            model.shop_name = txtShopName.Text.Trim();
            model.telphone = txtTelphone.Text.Trim();
            model.city = txtCity.Text.Trim();
            model.linkman = txtLinkman.Text.Trim();
            if (bll.Add(model) > 0)
            {
                
                result = true;
            }
            return result;
        }
        #endregion
        #region 修改" + Resources.lang.operating+ "=================================
        private bool DoEdit(int _id)
        {
            bool result = false;
            BLL.shop bll = new BLL.shop();
            Model.shop model = bll.GetModel(_id);
            model.address = txtAddress.Text.Trim(); ;

            model.shop_name = txtShopName.Text.Trim();
            model.telphone = txtTelphone.Text.Trim();
            model.city = txtCity.Text.Trim();
            model.linkman = txtLinkman.Text.Trim();
            if (bll.Update(model))
            {
                
                result = true;
            }

            return result;
        }
        #endregion

        private void ShowInfo(int _id)
        {
            BLL.shop bll = new BLL.shop();
            Model.shop model = bll.GetModel(_id);

            txtShopName.Text = model.shop_name;
            txtTelphone.Text = model.telphone;
          
            txtAddress.Text = model.address;
            txtLinkman.Text = model.linkman;
            txtCity.Text = model.city;
        }
    }
}