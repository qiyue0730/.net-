using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace 狗屁网盘.guanliyaun
{
    public partial class yonghutianjia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Model.Userinfo ui = new Model.Userinfo();
            ui.Userage = int.Parse(TextBox3.Text);
            ui.Useriphon = TextBox4.Text;
            ui.Useremil = TextBox5.Text;
            Model.Users us = new Model.Users();
            us.Username = TextBox1.Text;
            us.Userpwd = TextBox2.Text;
            if (RadioButton1.Checked == true)
            {
                us.LOA = RadioButton1.Text;
            }
            else
            {
                us.LOA = RadioButton2.Text;
            }
            if (BLL.UsersBLL.InsertBLL(us) > 0)
            {
                ui.UserId = int.Parse(BLL.UsersBLL.SelectIdBLL(us).Tables[0].Rows[0][0].ToString());
                if (BLL.UserinfoBLL.InsertDAL(ui) > 0)
                {
                    Response.Write("<script>alert('用户添加成功！');window.location.href='yonghuindex.aspx'</script></script>");

                }
                else
                {
                    Response.Write("<script>alert('用户添加失败！')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('用户添加失败！')</script>");
            }

        }
    }
}