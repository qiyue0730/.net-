using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using 狗屁网盘.guanliyaun;

namespace 狗屁网盘
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void qudenglu_Click(object sender, EventArgs e)
        {
            Server.Transfer("登录.aspx");
        }
    }
}