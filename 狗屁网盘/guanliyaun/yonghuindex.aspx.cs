using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace 狗屁网盘.guanliyaun
{
    public partial class yonghuindex : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //if (Session["Name"] != null)
                //{
                //    Label2.Text = Session["Name"].ToString();
                //    //文档部分
                GridView1.DataSource = BLL.TxtBLL.SelectallDAL();
                GridView1.DataBind();
                //图片部分
                GridView2.DataSource = BLL.PhotoBLL.SelectallDAL();
                GridView2.DataBind();
                ////音频部分
                GridView3.DataSource = BLL.MusicBLL.SelectallDAL();
                GridView3.DataBind();
                ////其他部分
                GridView4.DataSource = BLL.OthersBLL.SelectallDAL();
                GridView4.DataBind();
                ////用户部分
                GridView5.DataSource = BLL.UsersBLL.SelecttwoBLL();
                GridView5.DataBind();
                ////封禁部分
                GridView6.DataSource = BLL.UsersBLL.SelectUserBLL();
                GridView6.DataBind();
                ////隐藏
                LinkButton2.Visible = false;
                DropDownList1.Visible = true;
                GridView6.Visible = false;
                GridView5.Visible = false;
                GridView4.Visible = false;
                GridView2.Visible = false;
                GridView3.Visible = false;
                GridView1.Visible = true;
                //}
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedValue == "1")
            {
                GridView1.Visible = true;
                GridView2.Visible = false;
                GridView3.Visible = false;
                GridView4.Visible = false;
            }
            else if (DropDownList1.SelectedValue == "2")
            {
                GridView2.Visible = true;
                GridView1.Visible = false;
                GridView3.Visible = false;
                GridView4.Visible = false;
            }
            else if (DropDownList1.SelectedValue == "3")
            {
                GridView3.Visible = true;
                GridView2.Visible = false;
                GridView1.Visible = false;
                GridView4.Visible = false;
            }
            else if (DropDownList1.SelectedValue == "4")
            {
                GridView4.Visible = true;
                GridView2.Visible = false;
                GridView3.Visible = false;
                GridView1.Visible = false;
            }
            else
            {
                Response.Write("<script>alert('运行出现错误')</script>");
            }
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            GridView1.DataSource = BLL.TxtBLL.SelectallDAL();
            GridView1.DataBind();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Model.Txt t = new Model.Txt();
            t.TxtId = int.Parse(GridView1.Rows[e.RowIndex].Cells[0].Text);
            if (BLL.TxtBLL.DeleteTXTBLL(t) > 0)
            {
                Response.Write("<script>alert('文件删除成功！')</script>");
                GridView1.DataSource = BLL.TxtBLL.SelectallDAL();
                GridView1.DataBind();
            }
            else
            {
                Response.Write("<script>alert('删除失败')</script>");
            }
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            GridView1.DataSource = BLL.TxtBLL.SelectallDAL();
            GridView1.DataBind();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Model.Txt t = new Model.Txt();
            t.TxtId = int.Parse(GridView1.DataKeys[e.RowIndex].Value.ToString());
            t.TxtName = ((TextBox)(this.GridView1.Rows[e.RowIndex].Cells[1].Controls[0])).Text;
            if (BLL.TxtBLL.UpdateTxtnameBLL(t) > 0)
            {
                Response.Write("<script>alert('文件重命名成功！')</script>");
                GridView1.EditIndex = -1;
                GridView1.DataSource = BLL.TxtBLL.SelectallDAL();
                GridView1.DataBind();
            }
            else
            {
                Response.Write("<script>alert('修改失败')</script>");
            }
        }

        protected void GridView2_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView2.EditIndex = -1;
            GridView2.DataSource = BLL.PhotoBLL.SelectallDAL();
            GridView2.DataBind();
        }

        protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Model.Photo p = new Model.Photo();
            p.PhotoId = int.Parse(GridView2.Rows[e.RowIndex].Cells[0].Text);
            if (BLL.PhotoBLL.DeletephoneDAL(p) > 0)
            {
                Response.Write("<script>alert('文件删除成功！')</script>");
                GridView2.DataSource = BLL.PhotoBLL.SelectallDAL();
                GridView2.DataBind();
            }
            else
            {
                Response.Write("<script>alert('删除失败')</script>");
            }
        }

        protected void GridView2_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView2.EditIndex = e.NewEditIndex;
            GridView2.DataSource = BLL.PhotoBLL.SelectallDAL();
            GridView2.DataBind();
        }

        protected void GridView2_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Model.Photo p = new Model.Photo();
            p.PhotoId = int.Parse(GridView2.DataKeys[e.RowIndex].Value.ToString());
            p.PhotoName = ((TextBox)(this.GridView2.Rows[e.RowIndex].Cells[1].Controls[0])).Text;
            if (BLL.PhotoBLL.UpdatephoneameDAL(p) > 0)
            {
                Response.Write("<script>alert('文件重命名成功！')</script>");
                GridView2.EditIndex = -1;
                GridView2.DataSource = BLL.PhotoBLL.SelectallDAL();
                GridView2.DataBind();
            }
            else
            {
                Response.Write("<script>alert('修改失败')</script>");
            }
        }

        protected void GridView3_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView3.EditIndex = -1;
            GridView3.DataSource = BLL.MusicBLL.SelectallDAL();
            GridView3.DataBind();
        }

        protected void GridView3_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Model.Music m = new Model.Music();
            m.MusicId = int.Parse(GridView3.Rows[e.RowIndex].Cells[0].Text);
            if (BLL.MusicBLL.DeletephoneDAL(m) > 0)
            {
                Response.Write("<script>alert('文件删除成功！')</script>");
                GridView3.DataSource = BLL.MusicBLL.SelectallDAL();
                GridView3.DataBind();
            }
            else
            {
                Response.Write("<script>alert('删除失败')</script>");
            }
        }

        protected void GridView3_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView3.EditIndex = e.NewEditIndex;
            GridView3.DataSource = BLL.MusicBLL.SelectallDAL();
            GridView3.DataBind();
        }

        protected void GridView3_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Model.Music m = new Model.Music();
            m.MusicId = int.Parse(GridView3.DataKeys[e.RowIndex].Value.ToString());
            m.MusicName = ((TextBox)(this.GridView3.Rows[e.RowIndex].Cells[1].Controls[0])).Text;
            if (BLL.MusicBLL.UpdatephoneameDAL(m) > 0)
            {
                Response.Write("<script>alert('文件重命名成功！')</script>");
                GridView3.EditIndex = -1;
                GridView3.DataSource = BLL.MusicBLL.SelectallDAL();
                GridView3.DataBind();
            }
            else
            {
                Response.Write("<script>alert('修改失败')</script>");
            }
        }

        protected void GridView4_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView4.EditIndex = -1;
            GridView4.DataSource = BLL.OthersBLL.SelectallDAL();
            GridView4.DataBind();
        }

        protected void GridView4_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Model.Others o = new Model.Others();
            o.OthersId = int.Parse(GridView4.Rows[e.RowIndex].Cells[0].Text);
            if (BLL.OthersBLL.DeletephoneDAL(o) > 0)
            {
                Response.Write("<script>alert('文件删除成功！')</script>");
                GridView4.DataSource = BLL.OthersBLL.SelectallDAL();
                GridView4.DataBind();
            }
            else
            {
                Response.Write("<script>alert('删除失败')</script>");
            }
        }

        protected void GridView4_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView4.EditIndex = e.NewEditIndex;
            GridView4.DataSource = BLL.OthersBLL.SelectallDAL();
            GridView4.DataBind();
        }

        protected void GridView4_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Model.Others o = new Model.Others();
            o.OthersId = int.Parse(GridView4.DataKeys[e.RowIndex].Value.ToString());
            o.OthersName = ((TextBox)(this.GridView4.Rows[e.RowIndex].Cells[1].Controls[0])).Text;
            if (BLL.OthersBLL.UpdatephoneameDAL(o) > 0)
            {
                Response.Write("<script>alert('文件重命名成功！')</script>");
                GridView4.EditIndex = -1;
                GridView4.DataSource = BLL.OthersBLL.SelectallDAL();
                GridView4.DataBind();
            }
            else
            {
                Response.Write("<script>alert('修改失败')</script>");
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/guanliyaun/yonghuxiougai.aspx");
        }

        protected void GridView5_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Model.Users us = new Model.Users();
            us.UserId = int.Parse(GridView5.Rows[e.RowIndex].Cells[0].Text);
            Model.Userinfo ui = new Model.Userinfo();
            ui.UserId = int.Parse(GridView5.Rows[e.RowIndex].Cells[0].Text);
            ui.Userage = int.Parse(GridView5.Rows[e.RowIndex].Cells[4].Text);
            ui.Useremil = GridView5.Rows[e.RowIndex].Cells[5].Text;
            ui.Useriphon = GridView5.Rows[e.RowIndex].Cells[6].Text;

            if (ui.Userage != null || ui.Useremil != null || ui.Useriphon != null)
            {
                if (BLL.UserinfoBLL.DeleteBLL(ui) > 0)
                {
                    if (BLL.UsersBLL.DeleteBLL(us) > 0)
                    {
                        Response.Write("<script>alert('文件删除成功！')</script>");
                        GridView5.DataSource = BLL.UsersBLL.SelecttwoBLL();
                        GridView5.DataBind();
                    }
                    else
                    {
                        Response.Write("<script>alert('删除失败')</script>");
                    }

                }
                else
                {
                    Response.Write("<script>alert('删除失败')</script>");
                }
            }
            else
            {
                if (BLL.UsersBLL.DeleteBLL(us) > 0)
                {
                    Response.Write("<script>alert('文件删除成功！')</script>");
                    GridView5.DataSource = BLL.UsersBLL.SelecttwoBLL();
                    GridView5.DataBind();
                }
                else
                {
                    Response.Write("<script>alert('删除失败')</script>");
                }
            }


        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/guanliyaun/yonghutianjia.aspx");
        }

        protected void GridView5_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Model.Users us = new Model.Users();
            us.UserId = int.Parse(GridView5.Rows[e.RowIndex].Cells[0].Text);
            us.Username = ((TextBox)(this.GridView5.Rows[e.RowIndex].Cells[1].Controls[0])).Text;
            us.Userpwd = ((TextBox)(this.GridView5.Rows[e.RowIndex].Cells[2].Controls[0])).Text;
            us.LOA = ((TextBox)(this.GridView5.Rows[e.RowIndex].Cells[3].Controls[0])).Text;
            Model.Userinfo ui = new Model.Userinfo();
            ui.UserId = int.Parse(GridView5.Rows[e.RowIndex].Cells[0].Text);
            ui.Userage = int.Parse(((TextBox)(this.GridView5.Rows[e.RowIndex].Cells[4].Controls[0])).Text);
            ui.Useremil = ((TextBox)(this.GridView5.Rows[e.RowIndex].Cells[5].Controls[0])).Text;
            ui.Useriphon = ((TextBox)(this.GridView5.Rows[e.RowIndex].Cells[6].Controls[0])).Text;
            if (BLL.UserinfoBLL.SelectBLL(ui).Tables[0].Rows.Count != 0)
            {
                if (BLL.UserinfoBLL.UpdateuserBLL(ui) > 0)
                {
                    if (BLL.UsersBLL.UpdateuserBLL(us) > 0)
                    {
                        Response.Write("<script>alert('文件修改成功！')</script>");
                        GridView5.EditIndex = -1;
                        GridView5.DataSource = BLL.UsersBLL.SelecttwoBLL();
                        GridView5.DataBind();
                    }
                    else
                    {
                        Response.Write("<script>alert('修改失败')</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('修改失败?????')</script>");
                }
            }
            else
            {
                if (BLL.UserinfoBLL.InsertDAL(ui) > 0)
                {
                    if (BLL.UsersBLL.UpdateuserBLL(us) > 0)
                    {
                        Response.Write("<script>alert('文件修改成功！')</script>");
                        GridView5.EditIndex = -1;
                        GridView5.DataSource = BLL.UsersBLL.SelecttwoBLL();
                        GridView5.DataBind();
                    }
                    else
                    {
                        Response.Write("<script>alert('修改失败')</script>");
                    }
                }
            }

        }

        protected void GridView5_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView5.EditIndex = -1;
            GridView5.DataSource = BLL.UsersBLL.SelecttwoBLL();
            GridView5.DataBind();
        }

        protected void GridView5_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView5.EditIndex = e.NewEditIndex;
            GridView5.DataSource = BLL.UsersBLL.SelecttwoBLL();
            GridView5.DataBind();
        }

        protected void LinkButton2_Click1(object sender, EventArgs e)
        {

        }

        protected void GridView6_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
        }

        protected void GridView6_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
        }

        protected void GridView6_RowEditing(object sender, GridViewEditEventArgs e)
        {
        }

        protected void GridView6_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
        }

        protected void GridView6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void LinkButton1_Click1(object sender, EventArgs e)
        {
            Model.Users us = new Model.Users();
            us.UserId = int.Parse((((LinkButton)sender).CommandArgument));
            us.LOA = "被封禁用户";
            string qx = BLL.UsersBLL.SelectuserIdDAL(us).Tables[0].Rows[0][3].ToString();
            if (qx == "被封禁用户")
            {
                us.LOA = "普通用户";
                if (BLL.UsersBLL.UpdateloaBLL(us) > 0)
                {
                    Response.Write("<script>alert('用户解禁成功！')</script>");
                    GridView6.DataSource = BLL.UsersBLL.SelectUserBLL();
                    GridView6.DataBind();
                }
                else
                {
                    Response.Write("<script>alert('修改??！')</script>");
                }
            }
            else
            {
                if (BLL.UsersBLL.UpdateloaBLL(us) > 0)
                {
                    Response.Write("<script>alert('用户封禁成功！')</script>");
                    GridView6.DataSource = BLL.UsersBLL.SelectUserBLL();
                    GridView6.DataBind();
                }
                else
                {
                    Response.Write("<script>alert('修改??！')</script>");
                }
            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            LinkButton2.Visible = false;
            DropDownList1.Visible = true;
            GridView6.Visible = false;
            GridView5.Visible = false;
            GridView4.Visible = false;
            GridView2.Visible = false;
            GridView3.Visible = false;
            GridView1.Visible = true;
            Label3.Visible = true;
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            LinkButton2.Visible = true;
            DropDownList1.Visible = false;
            GridView6.Visible = false;
            GridView5.Visible = true;
            GridView4.Visible = false;
            GridView2.Visible = false;
            GridView3.Visible = false;
            GridView1.Visible = false;
            Label3.Visible = false;
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            LinkButton2.Visible = false;
            DropDownList1.Visible = false;
            GridView6.Visible = true;
            GridView5.Visible = false;
            GridView4.Visible = false;
            GridView2.Visible = false;
            GridView3.Visible = false;
            GridView1.Visible = false;
            Label3.Visible = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/index.aspx");
        }
    }
}