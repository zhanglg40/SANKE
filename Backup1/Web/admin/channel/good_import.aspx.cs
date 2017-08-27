using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.admin.channel
{
    public partial class good_import : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BLL.payment bll = new BLL.payment();
            DataTable dt = new DataTable();
            this.rptList.DataSource =dt;
            this.rptList.DataBind();
      
        }
        protected void btnDown_Click(object sender, EventArgs e)
        {
            BLL.payment bll = new BLL.payment();
            this.rptList.DataSource = bll.GetList(0, "id>0", "sort_id asc,id desc");
            this.rptList.DataBind();
        }
        protected void changeValue(object sender, EventArgs e)
        {
            BLL.payment bll = new BLL.payment();
            this.rptList.DataSource = bll.GetList(0, "id>0", "sort_id asc,id desc");
            this.rptList.DataBind();
        }
    }
}