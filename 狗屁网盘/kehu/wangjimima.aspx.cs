using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace 狗屁网盘
{
    public partial class wangjimima : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               // this.TextBox1.Attributes["value"] = TextBox1.Text;
                this.TextBox3.Attributes["value"] = TextBox3.Text;
                this.TextBox4.Attributes["value"] = TextBox4.Text;
                this.TextBox5.Attributes["value"] = TextBox5.Text;
            }

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/登录.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Model.Users Users1 = new Model.Users();
            Model.Userinfo UserInfo1 = new Model.Userinfo();
            Users1.Username = TextBox3.Text;
             DataSet ds = BLL.UsersBLL.SelectNameBLL(Users1);
            string a = ds.Tables[0].Rows[0][0].ToString();
            if (a == "1")//判断用户名是否存在
            {
                Response.Write("<script>alert('用户名已存在')</script>");
                TextBox1.Text = "";
            }
            else if (TextBox2.Text == "")
            {
                Response.Write("<script>alert('请输入验证码！') </script>");
            }
            else if (TextBox5.Text == "")
            {
                Response.Write("<script>alert('确认密码不能为空！') </script>");
            }
            else if (TextBox2.Text != Session["mobile_code"].ToString())
            {
                Response.Write("<script>alert('验证码错误！') </script>");
            }
            else
            {
                UserInfo1.Useriphon = TextBox1.Text;
                Users1.Username = TextBox3.Text;
                Users1.Userpwd = TextBox4.Text;
                int rows = BLL.UsersBLL.UsersUpIdBLL(Users1,UserInfo1);
                if (rows>0)
                {
                     Response.Write("<script>alert('修改成功！')</script>");
                     Response.Redirect("~/登录.aspx");
                }
                else
                {
                    Response.Write("<script>alert('修改失败！')</script>");
                }
            }
        }
        public int mobile_code;
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {

                String number = this.TextBox1.Text;
                System.Net.WebClient client = new System.Net.WebClient();
                client.Credentials = System.Net.CredentialCache.DefaultCredentials;
                String userName = "jiuxuan";
                String pass = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile("18872558086", "MD5");
                Random rad = new Random();
                mobile_code = rad.Next(1000, 10000);
                Session["mobile"] = number;
                Session["mobile_code"] = mobile_code;
                Session.Timeout = 5;
                String content = "【Webdisk网盘】您的验证码是：" + mobile_code + " 。请不要把验证码泄露给其他人,验证码五分钟内有效。";
                byte[] result = client.DownloadData("http://api.smsbao.com/sms?u=" + userName + "&p=" + pass + "&m=" + number + "&c=" + content);
                String sres = System.Text.Encoding.UTF8.GetString(result); /**/

                switch (sres)
                {

                    case "0":
                        {

                            Response.Write("<script>alert('发送成功！')</script>");
                            this.TextBox4.Attributes["value"] = TextBox4.Text;
                            this.TextBox5.Attributes["value"] = TextBox5.Text;
                           // this.TextBox1.Attributes["value"] = TextBox1.Text;
                            this.TextBox3.Attributes["value"] = TextBox3.Text;
                            break;
                        }
                    case "30":
                        {
                            Response.Write("<script>alert('验证码错误！')</script>");
                            //BLL.JShelper.JsHelper.Alert("密码错误！");
                            break;
                        }
                    case "40":
                        {
                            Response.Write("<script>alert('账号不存在！')</script>");
                            //BLL.JShelper.JsHelper.Alert("账号不存在！");
                            break;
                        }


                    case "43":
                        {
                            Response.Write("<script>alert('IP地址限制！')</script>");
                            //BLL.JShelper.JsHelper.Alert("IP地址限制！");
                            break;
                        }

                    case "51":
                        {
                            Response.Write("<script>alert('手机号码不正确！')</script>");
                            //BLL.JShelper.JsHelper.Alert("手机号码不正确！");
                            break;
                        }
                    case "-1":
                        {
                          //  Response.Write("<script>alert('手机号码不正确！')</script>");
                            //BLL.JShelper.JsHelper.Alert("手机号码不正确或缺少参数！");
                            break;
                        }
                    default:
                        {
                            //BLL.JShelper.JsHelper.Alert(sres);
                            break;
                        }

                }

            }
            catch
            {
                Response.Write("<script>alert('发生异常!')</script>");
                //BLL.JShelper.JsHelper.Alert("发生异常!");
            }
        }
    }
}