using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace 狗屁网盘.kehu
{
    public partial class gerenxx : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if(Session["Name"]!=null)
                {
                    TextBox1.Text = Session["Name"].ToString();
                    Model.Users SelectIdUsers = new Model.Users();
                    SelectIdUsers.Username = Session["Name"].ToString();
                    DataSet ds = BLL.UsersBLL.SelectIdBLL(SelectIdUsers);
                    Model.Userinfo UserInfoSel = new Model.Userinfo();
                    UserInfoSel.UserId = int.Parse(ds.Tables[0].Rows[0][0].ToString());
                    DataSet Infods = BLL.UserinfoBLL.SelectBLL(UserInfoSel);
                    TextBox2.Text = Infods.Tables[0].Rows[0][3].ToString();
                    TextBox4.Text = Infods.Tables[0].Rows[0][2].ToString();
                    TextBox3.Text = Infods.Tables[0].Rows[0][4].ToString();
                    }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/kehu/caidan.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
           
           
            TextBox2.ReadOnly = false;
            TextBox3.ReadOnly = false;
            TextBox4.ReadOnly = false;
            LinkButton2.Visible =false ;
            LinkButton3.Visible = true;
            LinkButton4.Visible = true;
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Model.Users SelectIdUsers = new Model.Users();
            SelectIdUsers.Username = Session["Name"].ToString();
            DataSet ds = BLL.UsersBLL.SelectIdBLL(SelectIdUsers);
            
            Model.Userinfo InfoInsert = new Model.Userinfo();
            InfoInsert.UserId = int.Parse(ds.Tables[0].Rows[0][0].ToString());
            DataSet InfoId = BLL.UserinfoBLL.SelectBLL(InfoInsert);
            InfoInsert.UserinfoId=int.Parse(InfoId.Tables[0].Rows[0][0].ToString());
            InfoInsert.Userage = int.Parse(TextBox4.Text);
            InfoInsert.Useremil = TextBox3.Text;
            InfoInsert.Useriphon = TextBox2.Text;
            
            int rows = BLL.UserinfoBLL.InfoUPdateBLL(InfoInsert);
            if (rows > 0)
            {
                Response.Write("<script>alert('修改成功！')</script>");
               
                TextBox2.ReadOnly = true;
                TextBox3.ReadOnly = true;
                TextBox4.ReadOnly = true;
                LinkButton2.Visible = true;
                LinkButton3.Visible = false;
            }
            else
            {
                LinkButton3.Visible = false;
                Response.Write("<script>alert('修改失败！')</script>");
                TextBox1.Text = Session["Name"].ToString();
               
                Model.Userinfo UserInfoSel = new Model.Userinfo();
                UserInfoSel.UserId = int.Parse(ds.Tables[0].Rows[0][0].ToString());
                DataSet Infods = BLL.UserinfoBLL.SelectBLL(UserInfoSel);
                TextBox2.Text = Infods.Tables[0].Rows[0][3].ToString();
                TextBox4.Text = Infods.Tables[0].Rows[0][2].ToString();
                TextBox3.Text = Infods.Tables[0].Rows[0][4].ToString();
            }
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            LinkButton2.Visible = true;
            LinkButton3.Visible = false;
            LinkButton4.Visible = false;
            Model.Users SelectIdUsers = new Model.Users();
            SelectIdUsers.Username = Session["Name"].ToString();
            DataSet ds = BLL.UsersBLL.SelectIdBLL(SelectIdUsers);
            Model.Userinfo UserInfoSel = new Model.Userinfo();
            UserInfoSel.UserId = int.Parse(ds.Tables[0].Rows[0][0].ToString());
            DataSet Infods = BLL.UserinfoBLL.SelectBLL(UserInfoSel);
            TextBox2.Text = Infods.Tables[0].Rows[0][3].ToString();
            TextBox4.Text = Infods.Tables[0].Rows[0][2].ToString();
            TextBox3.Text = Infods.Tables[0].Rows[0][4].ToString();
        }
    }
}