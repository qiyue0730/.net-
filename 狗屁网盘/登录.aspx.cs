using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using DAL;
using BLL;
using System.Data;
namespace 大二项目
{
    public partial class 登录 : System.Web.UI.Page
    {
        public int mobile_code;
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Model.Users Users1 = new Model.Users();
            Users1.Username = this.TextBox1.Text;
            Users1.Userpwd = this.TextBox2.Text;
            DataSet ds = BLL.UsersBLL.Denglu1BLL(Users1);
            if (ds.Tables[0].Rows.Count > 0)
            {
                string loa = ds.Tables[0].Rows[0][3].ToString();
                if (loa == "管理员")
                {
                    Response.Write("<script>alert('管理员登录成功！')</script>");
                    Server.Transfer("guanliyaun/yonghuindex.aspx");
                }
                else if (loa == "普通用户")
                {
                    Session["Name"] = TextBox1.Text;
                    Response.Write("<script>alert('登录成功！')</script>");
                    Server.Transfer("kehu/caidan.aspx");

                }
                else
                {
                    Response.Write("<script>alert('用户直接G')</script>");
                }
            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {


        }

        protected void Button2_Click1(object sender, EventArgs e)
        {
            Model.Userinfo InfoInsert = new Model.Userinfo();
            Model.Users Name = new Model.Users();
            Name.Username = TextBox3.Text;
            DataSet ds = BLL.UsersBLL.SelectNameBLL(Name);
            string a = ds.Tables[0].Rows[0][0].ToString();
            if (a == "1")//判断用户名是否存在
            {
                Response.Write("<script>alert('用户名已存在')</script>");
                TextBox1.Text = "";

                int iphon = (TextBox4.Text).Length;
                if (iphon == 11)
                {

                }
                else
                {
                    Response.Write("<script>alert('手机号码有误！') </script>");
                    TextBox4.Text = "";
                }
            }
            else if (TextBox4.Text == "")
            {
                Response.Write("<script>alert('请输入验证码！') </script>");
            }
            else if (TextBox5.Text == "")
            {
                Response.Write("<script>alert('确认密码不能为空！') </script>");
            }
            else if (TextBox7.Text!= Session["mobile_code"].ToString())
	{
        Response.Write("<script>alert('验证码错误！') </script>");
	}
            else
            {
                Model.Users Insert = new Model.Users();
                Insert.Username = TextBox3.Text;

                Insert.Userpwd = TextBox5.Text;
                Insert.LOA = "普通用户";
                Insert.Isvip = 0;
                int rows = BLL.UsersBLL.InsertBLL(Insert);
                Model.Users Select = new Model.Users();
                Select.Username = TextBox3.Text;
                DataSet ds1 = BLL.UsersBLL.UserNameBLL(Select);
                int rows1 = ds1.Tables[0].Rows.Count;

                if (rows > 0 && rows1 > 0)
                {
                    InfoInsert.UserId = int.Parse(ds1.Tables[0].Rows[0][0].ToString());
                    InfoInsert.Useriphon = TextBox4.Text;
                    int Inrows = BLL.UserinfoBLL.InfoInsertBLL(InfoInsert);
                    // Response.Write("<script>alert('注册成功！') </script>");
                    Response.Write("<script>if(confirm(\"注册成功！\")==true){window.close(); }</script>");
                    Response.Redirect("~/登录.aspx");
                }
                else
                {
                    Response.Write("<script>alert('注册失败！') </script>");
                    int UserDel = BLL.UsersBLL.UserDelBLL(Select);
                    TextBox1.Text = "";
                    TextBox2.Text = "";
                    TextBox3.Text = "";
                    TextBox4.Text = "";
                }

            }


        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/kehu/wangjimima.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                String number = this.TextBox4.Text;
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
                            this.TextBox2.Attributes["value"] = TextBox2.Text;
                            this.TextBox3.Attributes["value"] = TextBox3.Text;
                            break;
                        }
                    case "30":
                        {
                            Response.Write("<script>alert('密码错误！')</script>");
                            //BLL.JShelper.JsHelper.Alert("密码错误！");
                            break;
                        }
                    case "40":
                        {
                            //BLL.JShelper.JsHelper.Alert("账号不存在！");
                            break;
                        }


                    case "43":
                        {
                            //BLL.JShelper.JsHelper.Alert("IP地址限制！");
                            break;
                        }

                    case "51":
                        {
                            //BLL.JShelper.JsHelper.Alert("手机号码不正确！");
                            break;
                        }
                    case "-1":
                        {
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
                Response.Write("<script>alert('发生异常！')</script>");
                //BLL.JShelper.JsHelper.Alert("发生异常!");
            }

        }
    }
}