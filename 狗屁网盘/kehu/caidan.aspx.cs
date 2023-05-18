using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

namespace 狗屁网盘.kehu
{
    public partial class caidan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Name"] != null)
                {
                    Label4.Visible = false;
                    GridView4.Visible = true;
                    GridView3.Visible = false;
                    GridView2.Visible = false;
                    GridView1.Visible = false;
                    GridView5.Visible = false;
                    Label2.Text = Session["Name"].ToString();
                    Model.Users SelectIdUsers = new Model.Users();
                    SelectIdUsers.Username = Session["Name"].ToString();
                    DataSet ds = BLL.UsersBLL.SelectIdBLL(SelectIdUsers);
                    //文档部分
                    Model.Txt TxtSelectId = new Model.Txt();
                    TxtSelectId.UserId = int.Parse(ds.Tables[0].Rows[0][0].ToString());
                    GridView4.DataSource = BLL.TxtBLL.SelectBLL(TxtSelectId);
                    GridView4.DataBind();
                    //图片部分
                    Model.Photo PhotoSelecId = new Model.Photo();
                    PhotoSelecId.UserId = int.Parse(ds.Tables[0].Rows[0][0].ToString());
                    GridView3.DataSource = BLL.PhotoBLL.SelectBLL(PhotoSelecId);
                    GridView3.DataBind();
                    //音频部分
                    Model.Music MusicSelectId = new Model.Music();
                    MusicSelectId.UserId = int.Parse(ds.Tables[0].Rows[0][0].ToString());
                    GridView2.DataSource = BLL.MusicBLL.SelectBLL(MusicSelectId);
                    GridView2.DataBind();
                    //其他部分
                    Model.Others OthersSelectId = new Model.Others();
                    OthersSelectId.UserId = int.Parse(ds.Tables[0].Rows[0][0].ToString());
                    GridView1.DataSource = BLL.OthersBLL.SelectIdBLL(OthersSelectId);
                    GridView1.DataBind();
                    //回收站
                    Model.Recoverys RecoverySelectId = new Model.Recoverys();

                    //内存计算


                    //自动删除,登录自动更新
                    Model.Recoverys RecUpSelect = new Model.Recoverys();
                    RecUpSelect.UserId = int.Parse(ds.Tables[0].Rows[0][0].ToString());
                    DataSet Recds = BLL.RecoverysBLL.RecUpSelectBLL(RecUpSelect);
                    int RecCount = Recds.Tables[0].Rows.Count;
                    for (int i = 0; i < RecCount; i++)
                    {
                        Model.Recoverys RecUp = new Model.Recoverys();
                        RecUp.RecoveryId = int.Parse(Recds.Tables[0].Rows[i][0].ToString());
                        RecUp.UserId = int.Parse(ds.Tables[0].Rows[0][0].ToString());
                        int Recrows = BLL.RecoverysBLL.RecUpdateTimeBLL(RecUp);
                        int RecDel = BLL.RecoverysBLL.RecDeleteTimeBLL();
                        RecoverySelectId.UserId = int.Parse(ds.Tables[0].Rows[0][0].ToString());
                        GridView5.DataSource = BLL.RecoverysBLL.SelectBLL(RecoverySelectId);
                        GridView5.DataBind();
                    }

                    //判断是否为vip实现充值
                    Model.Users users = new Model.Users();
                    users.Username = Session["Name"].ToString();
                    DataSet dsisvip = BLL.UsersBLL.SelidBLL(users);
                    int isvip = int.Parse(dsisvip.Tables[0].Rows[0][1].ToString());
                    if (isvip == 0)
                    {
                        Label5.Text = "/50MB";
                    }
                    else
                    {
                        Label5.Text = "/100MB";
                    }
                    Model.Txt txt = new Model.Txt();
                    txt.UserId = int.Parse(ds.Tables[0].Rows[0][0].ToString());
                    //txt表获取文件大小
                    DataSet txtsize = BLL.TxtBLL.TxtSizeBLL(txt);
                    //txt最终内存大小
                    double txtzhuan = 0, tetsum = 0;
                    string txtsizedaxiao = "0";
                    for (int i = 0; i < BLL.TxtBLL.TxtSizeBLL(txt).Tables[0].Rows.Count; i++)
                    {
                        txtsizedaxiao = BLL.TxtBLL.TxtSizeBLL(txt).Tables[0].Rows[i][0].ToString();
                        if (txtsizedaxiao.IndexOf("KB") != -1)
                        {
                            if (txtsizedaxiao.Substring(txtsizedaxiao.LastIndexOf("K")) == "KB")
                            {
                                string[] txtsArray = txtsizedaxiao.Split('K');
                                txtzhuan = double.Parse(txtsArray[0]) / 1024;
                            }
                        }
                        if (txtsizedaxiao.IndexOf("KB") == -1 && txtsizedaxiao.IndexOf("MB") == -1)
                        {
                            if (txtsizedaxiao.Substring(txtsizedaxiao.LastIndexOf("B")) == "B")
                            {
                                string[] txtsArray = txtsizedaxiao.Split('B');
                                txtzhuan = double.Parse(txtsArray[0]) / 1024 / 1024;
                            }
                        }
                        if (txtsizedaxiao.IndexOf("MB") != -1)
                        {
                            if (txtsizedaxiao.Substring(txtsizedaxiao.LastIndexOf("M")) == "MB")
                            {
                                string[] txtsArray = txtsizedaxiao.Split('M');
                                txtzhuan = double.Parse(txtsArray[0]);
                            }
                        }

                        tetsum = tetsum + txtzhuan;

                    }
                    Model.Music music = new Model.Music();
                    music.MusicId = txt.UserId;
                    //Music表获取文件大小
                    DataSet Musicsize = BLL.MusicBLL.MusicSizeBLL(music);
                    //Music最终内存大小
                    double musiczhuan = 0, musicsum = 0;
                    string mudicsizedaxiao = "0";
                    int musicshu = BLL.MusicBLL.MusicSizeBLL(music).Tables[0].Rows.Count;
                    for (int i = 0; i < musicshu; i++)
                    {
                        mudicsizedaxiao = BLL.MusicBLL.MusicSizeBLL(music).Tables[0].Rows[i][0].ToString();
                        if (mudicsizedaxiao.IndexOf("MB") != -1)
                        {
                            if (mudicsizedaxiao.Substring(mudicsizedaxiao.LastIndexOf("M")) == "MB")
                            {
                                string[] musicsArray = mudicsizedaxiao.Split('M');
                                musiczhuan = double.Parse(musicsArray[0]);
                            }
                        }
                        if (mudicsizedaxiao.IndexOf("KB") != -1)
                        {
                            if (mudicsizedaxiao.Substring(mudicsizedaxiao.LastIndexOf("K")) == "KB")
                            {
                                string[] musicsArray = mudicsizedaxiao.Split('K');
                                musiczhuan = double.Parse(musicsArray[0]) / 1024;
                            }
                        }
                        if (mudicsizedaxiao.IndexOf("KB") == -1 && mudicsizedaxiao.IndexOf("MB") == -1)
                        {
                            if (mudicsizedaxiao.Substring(mudicsizedaxiao.LastIndexOf("B")) == "B")
                            {
                                string[] musicsArray = mudicsizedaxiao.Split('B');
                                musiczhuan = double.Parse(musicsArray[0]) / 1024 / 1024;
                            }
                        }


                        musicsum = musicsum + musiczhuan;
                    }
                    //Others表获取文件大小
                    Model.Others others = new Model.Others();
                    others.UserId = txt.UserId;
                    DataSet othersize = BLL.OthersBLL.OtherssizeBLL(others);
                    double otherzhuan = 0, othersum = 0;
                    string othersizedaxiao = "0";
                    int othershu = BLL.OthersBLL.OtherssizeBLL(others).Tables[0].Rows.Count;
                    for (int i = 0; i < othershu; i++)
                    {
                        othersizedaxiao = BLL.OthersBLL.OtherssizeBLL(others).Tables[0].Rows[i][0].ToString();
                        if (othersizedaxiao.IndexOf("KB") != -1)
                        {
                            if (othersizedaxiao.Substring(othersizedaxiao.LastIndexOf("K")) == "KB")
                            {
                                string[] otherArray = othersizedaxiao.Split('K');
                                otherzhuan = double.Parse(otherArray[0]) / 1024;
                            }
                        }
                        if (othersizedaxiao.IndexOf("MB") != -1)
                        {
                            if (othersizedaxiao.Substring(othersizedaxiao.LastIndexOf("M")) == "MB")
                            {
                                string[] otherArray = othersizedaxiao.Split('M');
                                otherzhuan = double.Parse(otherArray[0]);
                            }
                        }
                        if (othersizedaxiao.IndexOf("KB") == -1 && othersizedaxiao.IndexOf("MB") == -1)
                        {
                            if (othersizedaxiao.Substring(othersizedaxiao.LastIndexOf("B")) == "B")
                            {
                                string[] otherArray = othersizedaxiao.Split('B');
                                otherzhuan = double.Parse(otherArray[0]) / 1024 / 1024;
                            }
                        }

                        othersum = othersum + otherzhuan;
                    }
                    //photo表获取文件大小
                    Model.Photo photo = new Model.Photo();
                    photo.UserId = txt.UserId;
                    DataSet photosize = BLL.PhotoBLL.PhotoSizeBLL(photo);
                    double photozhuan = 0, photosum = 0;
                    string photosizedaxiao = "0";
                    int photoshu = BLL.PhotoBLL.PhotoSizeBLL(photo).Tables[0].Rows.Count;
                    for (int i = 0; i < photoshu; i++)
                    {
                        photosizedaxiao = BLL.PhotoBLL.PhotoSizeBLL(photo).Tables[0].Rows[i][0].ToString();
                        if (photosizedaxiao.IndexOf("KB") != -1)
                        {
                            if (photosizedaxiao.Substring(photosizedaxiao.LastIndexOf("K")) == "KB")
                            {
                                string[] photoArray = photosizedaxiao.Split('K');
                                photozhuan = double.Parse(photoArray[0]) / 1024;

                            }
                        }
                        if (photosizedaxiao.IndexOf("MB") != -1)
                        {
                            if (photosizedaxiao.Substring(photosizedaxiao.LastIndexOf("M")) == "MB")
                            {
                                string[] photoArray = photosizedaxiao.Split('M');
                                photozhuan = double.Parse(photoArray[0]);
                            }
                        }

                        if (photosizedaxiao.IndexOf("MB") == -1 && photosizedaxiao.IndexOf("KB") == -1)
                        {
                            if (photosizedaxiao.Substring(photosizedaxiao.LastIndexOf("B")) == "B")
                            {
                                string[] photoArray = photosizedaxiao.Split('B');
                                photozhuan = double.Parse(photoArray[0]) / 1024 / 1024;
                            }
                        }
                        photosum = photosum + photozhuan;
                    }
                    Label3.Text = Math.Round(musicsum + tetsum + othersum + photosum, 2) + "MB".ToString();
                    HiddenField1.Value = Math.Round(musicsum + tetsum + othersum + photosum, 2).ToString();
                }

            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/kehu/gerenxx.aspx");
        } //个人信息跳转
        //文档重命名
        protected void GridView4_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView4.EditIndex = e.NewEditIndex;
            Model.Users SelectIdUsers = new Model.Users();
            SelectIdUsers.Username = Session["Name"].ToString();
            DataSet ds = BLL.UsersBLL.SelectIdBLL(SelectIdUsers);
            Model.Txt TxtSelectId = new Model.Txt();
            TxtSelectId.UserId = int.Parse(ds.Tables[0].Rows[0][0].ToString());
            GridView4.DataSource = BLL.TxtBLL.SelectBLL(TxtSelectId);
            GridView4.DataBind();
        }

        protected void GridView4_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView4.EditIndex = -1;
            Model.Users SelectIdUsers = new Model.Users();
            SelectIdUsers.Username = Session["Name"].ToString();
            DataSet ds = BLL.UsersBLL.SelectIdBLL(SelectIdUsers);
            Model.Txt TxtSelectId = new Model.Txt();
            TxtSelectId.UserId = int.Parse(ds.Tables[0].Rows[0][0].ToString());
            GridView4.DataSource = BLL.TxtBLL.SelectBLL(TxtSelectId);
            GridView4.DataBind();
        }

        protected void GridView4_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Model.Txt TxtUpdate = new Model.Txt();
            TxtUpdate.TxtId = int.Parse(GridView4.DataKeys[e.RowIndex].Value.ToString());
            TxtUpdate.TxtName = ((TextBox)(this.GridView4.Rows[e.RowIndex].Cells[1].Controls[0])).Text;
            TxtUpdate.TxtTime = DateTime.Now;
            int rows = BLL.TxtBLL.TxtUpdate1BLL(TxtUpdate);
            if (rows > 0)
            {
                GridView4.EditIndex = -1;
                Model.Users SelectIdUsers = new Model.Users();
                SelectIdUsers.Username = Session["Name"].ToString();
                DataSet ds = BLL.UsersBLL.SelectIdBLL(SelectIdUsers);
                Model.Txt TxtSelectId = new Model.Txt();
                TxtSelectId.UserId = int.Parse(ds.Tables[0].Rows[0][0].ToString());
                GridView4.DataSource = BLL.TxtBLL.SelectBLL(TxtSelectId);
                GridView4.DataBind();
            }
        }
        //图片重命名
        protected void GridView3_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView3.EditIndex = e.NewEditIndex;
            Model.Users SelectIdUsers = new Model.Users();
            SelectIdUsers.Username = Session["Name"].ToString();
            DataSet ds = BLL.UsersBLL.SelectIdBLL(SelectIdUsers);
            Model.Photo PhotoSelecId = new Model.Photo();
            PhotoSelecId.UserId = int.Parse(ds.Tables[0].Rows[0][0].ToString());
            GridView3.DataSource = BLL.PhotoBLL.SelectBLL(PhotoSelecId);
            GridView3.DataBind();
        }

        protected void GridView3_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView3.EditIndex = -1;
            Model.Users SelectIdUsers = new Model.Users();
            SelectIdUsers.Username = Session["Name"].ToString();
            DataSet ds = BLL.UsersBLL.SelectIdBLL(SelectIdUsers);
            Model.Photo PhotoSelecId = new Model.Photo();
            PhotoSelecId.UserId = int.Parse(ds.Tables[0].Rows[0][0].ToString());
            GridView3.DataSource = BLL.PhotoBLL.SelectBLL(PhotoSelecId);
            GridView3.DataBind();
        }

        protected void GridView3_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Model.Photo PhotoUpdate = new Model.Photo();
            PhotoUpdate.PhotoId = int.Parse(GridView3.DataKeys[e.RowIndex].Value.ToString());
            PhotoUpdate.PhotoName = ((TextBox)(this.GridView3.Rows[e.RowIndex].Cells[1].Controls[0])).Text;
            PhotoUpdate.PhotoTime = DateTime.Now;
            int rows = BLL.PhotoBLL.PhotoUpdate1BLL(PhotoUpdate);
            if (rows > 0)
            {
                GridView3.EditIndex = -1;
                Model.Users SelectIdUsers = new Model.Users();
                SelectIdUsers.Username = Session["Name"].ToString();
                DataSet ds = BLL.UsersBLL.SelectIdBLL(SelectIdUsers);
                Model.Photo PhotoSelecId = new Model.Photo();
                PhotoSelecId.UserId = int.Parse(ds.Tables[0].Rows[0][0].ToString());
                GridView3.DataSource = BLL.PhotoBLL.SelectBLL(PhotoSelecId);
                GridView3.DataBind();
            }
        }
        //音频重命名
        protected void GridView2_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView2.EditIndex = e.NewEditIndex;
            Model.Users SelectIdUsers = new Model.Users();
            SelectIdUsers.Username = Session["Name"].ToString();
            DataSet ds1 = BLL.UsersBLL.SelectIdBLL(SelectIdUsers);
            Model.Music MusicSelectId = new Model.Music();
            MusicSelectId.UserId = int.Parse(ds1.Tables[0].Rows[0][0].ToString());
            GridView2.DataSource = BLL.MusicBLL.SelectBLL(MusicSelectId);
            GridView2.DataBind();
        }

        protected void GridView2_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView2.EditIndex = -1;
            Model.Users SelectIdUsers = new Model.Users();
            SelectIdUsers.Username = Session["Name"].ToString();
            DataSet ds1 = BLL.UsersBLL.SelectIdBLL(SelectIdUsers);
            Model.Music MusicSelectId = new Model.Music();
            MusicSelectId.UserId = int.Parse(ds1.Tables[0].Rows[0][0].ToString());
            GridView2.DataSource = BLL.MusicBLL.SelectBLL(MusicSelectId);
            GridView2.DataBind();
        }

        protected void GridView2_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Model.Music MusicUpdate = new Model.Music();
            MusicUpdate.MusicId = int.Parse(GridView2.DataKeys[e.RowIndex].Value.ToString());
            MusicUpdate.MusicName = ((TextBox)(this.GridView2.Rows[e.RowIndex].Cells[1].Controls[0])).Text;
            MusicUpdate.MusicTime = DateTime.Now;
            int rows = BLL.MusicBLL.MusicUpdateBLL(MusicUpdate);
            if (rows > 0)
            {
                GridView2.EditIndex = -1;
                Model.Users SelectIdUsers = new Model.Users();
                SelectIdUsers.Username = Session["Name"].ToString();
                DataSet ds1 = BLL.UsersBLL.SelectIdBLL(SelectIdUsers);
                Model.Music MusicSelectId = new Model.Music();
                MusicSelectId.UserId = int.Parse(ds1.Tables[0].Rows[0][0].ToString());
                GridView2.DataSource = BLL.MusicBLL.SelectBLL(MusicSelectId);
                GridView2.DataBind();
            }
        }
        //其他重命名
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            Model.Users SelectIdUsers = new Model.Users();
            SelectIdUsers.Username = Session["Name"].ToString();
            DataSet ds1 = BLL.UsersBLL.SelectIdBLL(SelectIdUsers);
            Model.Others OthersSelectId = new Model.Others();
            OthersSelectId.UserId = int.Parse(ds1.Tables[0].Rows[0][0].ToString());
            GridView1.DataSource = BLL.OthersBLL.SelectIdBLL(OthersSelectId);
            GridView1.DataBind();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            Model.Users SelectIdUsers = new Model.Users();
            SelectIdUsers.Username = Session["Name"].ToString();
            DataSet ds1 = BLL.UsersBLL.SelectIdBLL(SelectIdUsers);
            Model.Others OthersSelectId = new Model.Others();
            OthersSelectId.UserId = int.Parse(ds1.Tables[0].Rows[0][0].ToString());
            GridView1.DataSource = BLL.OthersBLL.SelectIdBLL(OthersSelectId);
            GridView1.DataBind();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Model.Others OthersUpdate = new Model.Others();
            OthersUpdate.OthersId = int.Parse(GridView1.DataKeys[e.RowIndex].Value.ToString());
            OthersUpdate.OthersName = ((TextBox)(this.GridView1.Rows[e.RowIndex].Cells[1].Controls[0])).Text;
            OthersUpdate.OthersTime = DateTime.Now;
            int rows = BLL.OthersBLL.OthersUpdateBLL(OthersUpdate);
            if (rows > 0)
            {
                GridView1.EditIndex = -1;
                Model.Users SelectIdUsers = new Model.Users();
                SelectIdUsers.Username = Session["Name"].ToString();
                DataSet ds1 = BLL.UsersBLL.SelectIdBLL(SelectIdUsers);
                Model.Others OthersSelectId = new Model.Others();
                OthersSelectId.UserId = int.Parse(ds1.Tables[0].Rows[0][0].ToString());
                GridView1.DataSource = BLL.OthersBLL.SelectIdBLL(OthersSelectId);
                GridView1.DataBind();
            }
        }

        protected void LinkButton1_Click2(object sender, EventArgs e)
        {
            Model.Txt SelectId = new Model.Txt();
            SelectId.TxtId = int.Parse(((LinkButton)sender).CommandArgument);
            DataSet ds1 = BLL.TxtBLL.TxtSelectByIdBLL(SelectId);
            Model.Recoverys RecInsert = new Model.Recoverys();
            RecInsert.RecoveryName = ds1.Tables[0].Rows[0][1].ToString();
            RecInsert.RecoveryTime = DateTime.Now;
            RecInsert.RecoverySize = ds1.Tables[0].Rows[0][3].ToString();
            RecInsert.UserId = int.Parse(ds1.Tables[0].Rows[0][4].ToString());
            RecInsert.RecoveryUrl = ds1.Tables[0].Rows[0][5].ToString();
            RecInsert.DiffTime = 10 - ((DateTime.Now - RecInsert.RecoveryTime).Days);
            int rows1 = BLL.RecoverysBLL.RecInsertBLL(RecInsert);
            if (rows1 > 0)
            {
                Model.Txt TxtDelete = new Model.Txt();
                TxtDelete.TxtId = int.Parse(((LinkButton)sender).CommandArgument);
                int rows = BLL.TxtBLL.TxtDeleteBLL(TxtDelete);

                if (rows > 0)
                {
                    Model.Users SelectIdUsers = new Model.Users();
                    SelectIdUsers.Username = Session["Name"].ToString();
                    DataSet ds = BLL.UsersBLL.SelectIdBLL(SelectIdUsers);
                    //文档部分
                    Model.Txt TxtSelectId = new Model.Txt();
                    TxtSelectId.UserId = int.Parse(ds.Tables[0].Rows[0][0].ToString());
                    GridView4.DataSource = BLL.TxtBLL.SelectBLL(TxtSelectId);
                    GridView4.DataBind();//文档刷新
                    Model.Recoverys RecoverySelectId = new Model.Recoverys();
                    RecoverySelectId.UserId = int.Parse(ds.Tables[0].Rows[0][0].ToString());
                    GridView5.DataSource = BLL.RecoverysBLL.SelectBLL(RecoverySelectId);
                    GridView5.DataBind();//回收站刷新
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
            //刷新内存大小
            if (Session["Name"] != null)
            {
                Label2.Text = Session["Name"].ToString();
                Model.Users SelectIdUsers = new Model.Users();
                SelectIdUsers.Username = Session["Name"].ToString();
                DataSet ds = BLL.UsersBLL.SelectIdBLL(SelectIdUsers);
                //判断是否为vip实现充值
                Model.Users users = new Model.Users();
                users.Username = Session["Name"].ToString();
                DataSet dsisvip = BLL.UsersBLL.SelidBLL(users);
                int isvip = int.Parse(dsisvip.Tables[0].Rows[0][1].ToString());
                if (isvip == 0)
                {
                    Label5.Text = "/50MB";
                }
                else if (isvip == 1)
                {
                    Label5.Text = "/100MB";
                }
                Model.Txt txt = new Model.Txt();
                txt.UserId = int.Parse(ds.Tables[0].Rows[0][0].ToString());
                //txt表获取文件大小
                DataSet txtsize = BLL.TxtBLL.TxtSizeBLL(txt);
                //txt最终内存大小
                double txtzhuan = 0, tetsum = 0;
                string txtsizedaxiao = "0";
                for (int i = 0; i < BLL.TxtBLL.TxtSizeBLL(txt).Tables[0].Rows.Count; i++)
                {
                    txtsizedaxiao = BLL.TxtBLL.TxtSizeBLL(txt).Tables[0].Rows[i][0].ToString();
                    if (txtsizedaxiao.IndexOf("KB") != -1)
                    {
                        if (txtsizedaxiao.Substring(txtsizedaxiao.LastIndexOf("K")) == "KB")
                        {
                            string[] txtsArray = txtsizedaxiao.Split('K');
                            txtzhuan = double.Parse(txtsArray[0]) / 1024;
                        }
                    }
                    if (txtsizedaxiao.IndexOf("KB") == -1 && txtsizedaxiao.IndexOf("MB") == -1)
                    {
                        if (txtsizedaxiao.Substring(txtsizedaxiao.LastIndexOf("B")) == "B")
                        {
                            string[] txtsArray = txtsizedaxiao.Split('B');
                            txtzhuan = double.Parse(txtsArray[0]) / 1024 / 1024;
                        }
                    }
                    if (txtsizedaxiao.IndexOf("MB") != -1)
                    {
                        if (txtsizedaxiao.Substring(txtsizedaxiao.LastIndexOf("M")) == "MB")
                        {
                            string[] txtsArray = txtsizedaxiao.Split('M');
                            txtzhuan = double.Parse(txtsArray[0]);
                        }
                    }

                    tetsum = tetsum + txtzhuan;

                }
                Model.Music music = new Model.Music();
                music.MusicId = txt.UserId;
                //Music表获取文件大小
                DataSet Musicsize = BLL.MusicBLL.MusicSizeBLL(music);
                //Music最终内存大小
                double musiczhuan = 0, musicsum = 0;
                string mudicsizedaxiao = "0";
                int musicshu = BLL.MusicBLL.MusicSizeBLL(music).Tables[0].Rows.Count;
                for (int i = 0; i < musicshu; i++)
                {
                    mudicsizedaxiao = BLL.MusicBLL.MusicSizeBLL(music).Tables[0].Rows[i][0].ToString();
                    if (mudicsizedaxiao.IndexOf("MB") != -1)
                    {
                        if (mudicsizedaxiao.Substring(mudicsizedaxiao.LastIndexOf("M")) == "MB")
                        {
                            string[] musicsArray = mudicsizedaxiao.Split('M');
                            musiczhuan = double.Parse(musicsArray[0]);
                        }
                    }
                    if (mudicsizedaxiao.IndexOf("KB") != -1)
                    {
                        if (mudicsizedaxiao.Substring(mudicsizedaxiao.LastIndexOf("K")) == "KB")
                        {
                            string[] musicsArray = mudicsizedaxiao.Split('K');
                            musiczhuan = double.Parse(musicsArray[0]) / 1024;
                        }
                    }
                    if (mudicsizedaxiao.IndexOf("KB") == -1 && mudicsizedaxiao.IndexOf("MB") == -1)
                    {
                        if (mudicsizedaxiao.Substring(mudicsizedaxiao.LastIndexOf("B")) == "B")
                        {
                            string[] musicsArray = mudicsizedaxiao.Split('B');
                            musiczhuan = double.Parse(musicsArray[0]) / 1024 / 1024;
                        }
                    }


                    musicsum = musicsum + musiczhuan;
                }
                //Others表获取文件大小
                Model.Others others = new Model.Others();
                others.UserId = txt.UserId;
                DataSet othersize = BLL.OthersBLL.OtherssizeBLL(others);
                double otherzhuan = 0, othersum = 0;
                string othersizedaxiao = "0";
                int othershu = BLL.OthersBLL.OtherssizeBLL(others).Tables[0].Rows.Count;
                for (int i = 0; i < othershu; i++)
                {
                    othersizedaxiao = BLL.OthersBLL.OtherssizeBLL(others).Tables[0].Rows[i][0].ToString();
                    if (othersizedaxiao.IndexOf("KB") != -1)
                    {
                        if (othersizedaxiao.Substring(othersizedaxiao.LastIndexOf("K")) == "KB")
                        {
                            string[] otherArray = othersizedaxiao.Split('K');
                            otherzhuan = double.Parse(otherArray[0]) / 1024;
                        }
                    }
                    if (othersizedaxiao.IndexOf("MB") != -1)
                    {
                        if (othersizedaxiao.Substring(othersizedaxiao.LastIndexOf("M")) == "MB")
                        {
                            string[] otherArray = othersizedaxiao.Split('M');
                            otherzhuan = double.Parse(otherArray[0]);
                        }
                    }
                    if (othersizedaxiao.IndexOf("KB") == -1 && othersizedaxiao.IndexOf("MB") == -1)
                    {
                        if (othersizedaxiao.Substring(othersizedaxiao.LastIndexOf("B")) == "B")
                        {
                            string[] otherArray = othersizedaxiao.Split('B');
                            otherzhuan = double.Parse(otherArray[0]) / 1024 / 1024;
                        }
                    }

                    othersum = othersum + otherzhuan;
                }
                //photo表获取文件大小
                Model.Photo photo = new Model.Photo();
                photo.UserId = int.Parse(ds.Tables[0].Rows[0][0].ToString());
                DataSet photosize = BLL.PhotoBLL.PhotoSizeBLL(photo);
                double photozhuan = 0, photosum = 0;
                string photosizedaxiao = "0";
                int photoshu = BLL.PhotoBLL.PhotoSizeBLL(photo).Tables[0].Rows.Count;
                for (int i = 0; i < photoshu; i++)
                {
                    photosizedaxiao = BLL.PhotoBLL.PhotoSizeBLL(photo).Tables[0].Rows[i][0].ToString();
                    if (photosizedaxiao.IndexOf("KB") != -1)
                    {
                        if (photosizedaxiao.Substring(photosizedaxiao.LastIndexOf("K")) == "KB")
                        {
                            string[] photoArray = photosizedaxiao.Split('K');
                            photozhuan = double.Parse(photoArray[0]) / 1024;

                        }
                    }
                    if (photosizedaxiao.IndexOf("MB") != -1)
                    {
                        if (photosizedaxiao.Substring(photosizedaxiao.LastIndexOf("M")) == "MB")
                        {
                            string[] photoArray = photosizedaxiao.Split('M');
                            photozhuan = double.Parse(photoArray[0]);
                        }
                    }

                    if (photosizedaxiao.IndexOf("MB") == -1 && photosizedaxiao.IndexOf("KB") == -1)
                    {
                        if (photosizedaxiao.Substring(photosizedaxiao.LastIndexOf("B")) == "B")
                        {
                            string[] photoArray = photosizedaxiao.Split('B');
                            photozhuan = double.Parse(photoArray[0]) / 1024 / 1024;
                        }
                    }


                    photosum = photosum + photozhuan;
                }
                Label3.Text = Math.Round(musicsum + tetsum + othersum + photosum, 2) + "MB".ToString();
                HiddenField1.Value = Math.Round(musicsum + tetsum + othersum + photosum, 2).ToString();
            }
        }//文档删除部分

        protected void LinkButton1_Click3(object sender, EventArgs e)
        {

            Model.Photo PhotoSelectById = new Model.Photo();
            PhotoSelectById.PhotoId = int.Parse(((LinkButton)sender).CommandArgument);
            DataSet ds1 = BLL.PhotoBLL.PhotoSelectByIdBLL(PhotoSelectById);
            Model.Recoverys RecInsert = new Model.Recoverys();
            RecInsert.RecoveryName = ds1.Tables[0].Rows[0][1].ToString();
            RecInsert.RecoveryTime = DateTime.Now;
            RecInsert.RecoverySize = ds1.Tables[0].Rows[0][3].ToString();
            RecInsert.UserId = int.Parse(ds1.Tables[0].Rows[0][4].ToString());
            RecInsert.RecoveryUrl = ds1.Tables[0].Rows[0][5].ToString();
            RecInsert.DiffTime = 10 - ((DateTime.Now - RecInsert.RecoveryTime).Days);
            int rows1 = BLL.RecoverysBLL.RecInsertBLL(RecInsert);
            if (rows1 > 0)
            {
                Model.Photo PhotoDelete = new Model.Photo();
                PhotoDelete.PhotoId = int.Parse(((LinkButton)sender).CommandArgument);
                int rows = BLL.PhotoBLL.PhotoDeleteBLL(PhotoDelete);

                if (rows > 0)
                {
                    Model.Users SelectIdUsers = new Model.Users();
                    SelectIdUsers.Username = Session["Name"].ToString();
                    DataSet ds = BLL.UsersBLL.SelectIdBLL(SelectIdUsers);
                    //图片部分
                    Model.Photo PhotoSelecId = new Model.Photo();
                    PhotoSelecId.UserId = int.Parse(ds.Tables[0].Rows[0][0].ToString());
                    GridView3.DataSource = BLL.PhotoBLL.SelectBLL(PhotoSelecId);
                    GridView3.DataBind();
                    //刷新
                    Model.Recoverys RecoverySelectId = new Model.Recoverys();
                    RecoverySelectId.UserId = int.Parse(ds.Tables[0].Rows[0][0].ToString());
                    GridView5.DataSource = BLL.RecoverysBLL.SelectBLL(RecoverySelectId);
                    GridView5.DataBind();//回收站刷新
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
            //刷新内存大小
            if (Session["Name"] != null)
            {
                Label2.Text = Session["Name"].ToString();
                Model.Users SelectIdUsers = new Model.Users();
                SelectIdUsers.Username = Session["Name"].ToString();
                DataSet ds = BLL.UsersBLL.SelectIdBLL(SelectIdUsers);
                //判断是否为vip实现充值
                Model.Users users = new Model.Users();
                users.Username = Session["Name"].ToString();
                DataSet dsisvip = BLL.UsersBLL.SelidBLL(users);
                int isvip = int.Parse(dsisvip.Tables[0].Rows[0][1].ToString());
                if (isvip == 0)
                {
                    Label5.Text = "/50MB";
                }
                Model.Txt txt = new Model.Txt();
                txt.UserId = int.Parse(ds.Tables[0].Rows[0][0].ToString());
                //txt表获取文件大小
                DataSet txtsize = BLL.TxtBLL.TxtSizeBLL(txt);
                //txt最终内存大小
                double txtzhuan = 0, tetsum = 0;
                string txtsizedaxiao = "0";
                for (int i = 0; i < BLL.TxtBLL.TxtSizeBLL(txt).Tables[0].Rows.Count; i++)
                {
                    txtsizedaxiao = BLL.TxtBLL.TxtSizeBLL(txt).Tables[0].Rows[i][0].ToString();
                    if (txtsizedaxiao.IndexOf("KB") != -1)
                    {
                        if (txtsizedaxiao.Substring(txtsizedaxiao.LastIndexOf("K")) == "KB")
                        {
                            string[] txtsArray = txtsizedaxiao.Split('K');
                            txtzhuan = double.Parse(txtsArray[0]) / 1024;
                        }
                    }
                    if (txtsizedaxiao.IndexOf("KB") == -1 && txtsizedaxiao.IndexOf("MB") == -1)
                    {
                        if (txtsizedaxiao.Substring(txtsizedaxiao.LastIndexOf("B")) == "B")
                        {
                            string[] txtsArray = txtsizedaxiao.Split('B');
                            txtzhuan = double.Parse(txtsArray[0]) / 1024 / 1024;
                        }
                    }
                    if (txtsizedaxiao.IndexOf("MB") != -1)
                    {
                        if (txtsizedaxiao.Substring(txtsizedaxiao.LastIndexOf("M")) == "MB")
                        {
                            string[] txtsArray = txtsizedaxiao.Split('M');
                            txtzhuan = double.Parse(txtsArray[0]);
                        }
                    }

                    tetsum = tetsum + txtzhuan;

                }
                Model.Music music = new Model.Music();
                music.MusicId = txt.UserId;
                //Music表获取文件大小
                DataSet Musicsize = BLL.MusicBLL.MusicSizeBLL(music);
                //Music最终内存大小
                double musiczhuan = 0, musicsum = 0;
                string mudicsizedaxiao = "0";
                int musicshu = BLL.MusicBLL.MusicSizeBLL(music).Tables[0].Rows.Count;
                for (int i = 0; i < musicshu; i++)
                {
                    mudicsizedaxiao = BLL.MusicBLL.MusicSizeBLL(music).Tables[0].Rows[i][0].ToString();
                    if (mudicsizedaxiao.IndexOf("MB") != -1)
                    {
                        if (mudicsizedaxiao.Substring(mudicsizedaxiao.LastIndexOf("M")) == "MB")
                        {
                            string[] musicsArray = mudicsizedaxiao.Split('M');
                            musiczhuan = double.Parse(musicsArray[0]);
                        }
                    }
                    if (mudicsizedaxiao.IndexOf("KB") != -1)
                    {
                        if (mudicsizedaxiao.Substring(mudicsizedaxiao.LastIndexOf("K")) == "KB")
                        {
                            string[] musicsArray = mudicsizedaxiao.Split('K');
                            musiczhuan = double.Parse(musicsArray[0]) / 1024;
                        }
                    }
                    if (mudicsizedaxiao.IndexOf("KB") == -1 && mudicsizedaxiao.IndexOf("MB") == -1)
                    {
                        if (mudicsizedaxiao.Substring(mudicsizedaxiao.LastIndexOf("B")) == "B")
                        {
                            string[] musicsArray = mudicsizedaxiao.Split('B');
                            musiczhuan = double.Parse(musicsArray[0]) / 1024 / 1024;
                        }
                    }


                    musicsum = musicsum + musiczhuan;
                }
                //Others表获取文件大小
                Model.Others others = new Model.Others();
                others.UserId = txt.UserId;
                DataSet othersize = BLL.OthersBLL.OtherssizeBLL(others);
                double otherzhuan = 0, othersum = 0;
                string othersizedaxiao = "0";
                int othershu = BLL.OthersBLL.OtherssizeBLL(others).Tables[0].Rows.Count;
                for (int i = 0; i < othershu; i++)
                {
                    othersizedaxiao = BLL.OthersBLL.OtherssizeBLL(others).Tables[0].Rows[i][0].ToString();
                    if (othersizedaxiao.IndexOf("KB") != -1)
                    {
                        if (othersizedaxiao.Substring(othersizedaxiao.LastIndexOf("K")) == "KB")
                        {
                            string[] otherArray = othersizedaxiao.Split('K');
                            otherzhuan = double.Parse(otherArray[0]) / 1024;
                        }
                    }
                    if (othersizedaxiao.IndexOf("MB") != -1)
                    {
                        if (othersizedaxiao.Substring(othersizedaxiao.LastIndexOf("M")) == "MB")
                        {
                            string[] otherArray = othersizedaxiao.Split('M');
                            otherzhuan = double.Parse(otherArray[0]);
                        }
                    }
                    if (othersizedaxiao.IndexOf("KB") == -1 && othersizedaxiao.IndexOf("MB") == -1)
                    {
                        if (othersizedaxiao.Substring(othersizedaxiao.LastIndexOf("B")) == "B")
                        {
                            string[] otherArray = othersizedaxiao.Split('B');
                            otherzhuan = double.Parse(otherArray[0]) / 1024 / 1024;
                        }
                    }

                    othersum = othersum + otherzhuan;
                }
                //photo表获取文件大小
                Model.Photo photo = new Model.Photo();
                photo.UserId = int.Parse(ds.Tables[0].Rows[0][0].ToString());
                DataSet photosize = BLL.PhotoBLL.PhotoSizeBLL(photo);
                double photozhuan = 0, photosum = 0;
                string photosizedaxiao = "0";
                int photoshu = BLL.PhotoBLL.PhotoSizeBLL(photo).Tables[0].Rows.Count;
                for (int i = 0; i < photoshu; i++)
                {
                    photosizedaxiao = BLL.PhotoBLL.PhotoSizeBLL(photo).Tables[0].Rows[i][0].ToString();
                    if (photosizedaxiao.IndexOf("KB") != -1)
                    {
                        if (photosizedaxiao.Substring(photosizedaxiao.LastIndexOf("K")) == "KB")
                        {
                            string[] photoArray = photosizedaxiao.Split('K');
                            photozhuan = double.Parse(photoArray[0]) / 1024;

                        }
                    }
                    if (photosizedaxiao.IndexOf("MB") != -1)
                    {
                        if (photosizedaxiao.Substring(photosizedaxiao.LastIndexOf("M")) == "MB")
                        {
                            string[] photoArray = photosizedaxiao.Split('M');
                            photozhuan = double.Parse(photoArray[0]);
                        }
                    }

                    if (photosizedaxiao.IndexOf("MB") == -1 && photosizedaxiao.IndexOf("KB") == -1)
                    {
                        if (photosizedaxiao.Substring(photosizedaxiao.LastIndexOf("B")) == "B")
                        {
                            string[] photoArray = photosizedaxiao.Split('B');
                            photozhuan = double.Parse(photoArray[0]) / 1024 / 1024;
                        }
                    }


                    photosum = photosum + photozhuan;
                }
                Label3.Text = Math.Round(musicsum + tetsum + othersum + photosum, 2) + "MB".ToString();
                HiddenField1.Value = Math.Round(musicsum + tetsum + othersum + photosum, 2).ToString();
            }
        }//图片删除部分

        protected void LinkButton1_Click5(object sender, EventArgs e)
        {
            Model.Music MusicSelectById = new Model.Music();
            MusicSelectById.MusicId = int.Parse(((LinkButton)sender).CommandArgument);
            DataSet ds1 = BLL.MusicBLL.MusicSelectByIdBLL(MusicSelectById);
            Model.Recoverys RecInsert = new Model.Recoverys();
            RecInsert.RecoveryName = ds1.Tables[0].Rows[0][1].ToString();
            RecInsert.RecoveryTime = DateTime.Now;
            RecInsert.RecoverySize = ds1.Tables[0].Rows[0][3].ToString();
            RecInsert.RecoveryUrl = ds1.Tables[0].Rows[0][5].ToString();
            RecInsert.UserId = int.Parse(ds1.Tables[0].Rows[0][4].ToString());
            RecInsert.DiffTime = 10 - ((DateTime.Now - RecInsert.RecoveryTime).Days);
            int rows1 = BLL.RecoverysBLL.RecInsertBLL(RecInsert);
            if (rows1 > 0)
            {
                Model.Music MusicDelete = new Model.Music();
                MusicDelete.MusicId = int.Parse(((LinkButton)sender).CommandArgument);
                int rows = BLL.MusicBLL.MusicDeleteBLL(MusicDelete);

                if (rows > 0)
                {
                    Model.Users SelectIdUsers = new Model.Users();
                    SelectIdUsers.Username = Session["Name"].ToString();
                    DataSet ds = BLL.UsersBLL.SelectIdBLL(SelectIdUsers);
                    //音频部分
                    Model.Music MusicSelectId = new Model.Music();
                    MusicSelectId.UserId = int.Parse(ds.Tables[0].Rows[0][0].ToString());
                    GridView2.DataSource = BLL.MusicBLL.SelectBLL(MusicSelectId);
                    GridView2.DataBind();
                    //刷新
                    Model.Recoverys RecoverySelectId = new Model.Recoverys();
                    RecoverySelectId.UserId = int.Parse(ds.Tables[0].Rows[0][0].ToString());
                    GridView5.DataSource = BLL.RecoverysBLL.SelectBLL(RecoverySelectId);
                    GridView5.DataBind();//回收站刷新
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
            //刷新内存大小
            if (Session["Name"] != null)
            {
                Label2.Text = Session["Name"].ToString();
                Model.Users SelectIdUsers = new Model.Users();
                SelectIdUsers.Username = Session["Name"].ToString();
                DataSet ds = BLL.UsersBLL.SelectIdBLL(SelectIdUsers);
                //判断是否为vip实现充值
                Model.Users users = new Model.Users();
                users.Username = Session["Name"].ToString();
                DataSet dsisvip = BLL.UsersBLL.SelidBLL(users);
                int isvip = int.Parse(dsisvip.Tables[0].Rows[0][1].ToString());
                if (isvip == 0)
                {
                    Label5.Text = "/50MB";
                }
                Model.Txt txt = new Model.Txt();
                txt.UserId = int.Parse(ds.Tables[0].Rows[0][0].ToString());
                //txt表获取文件大小
                DataSet txtsize = BLL.TxtBLL.TxtSizeBLL(txt);
                //txt最终内存大小
                double txtzhuan = 0, tetsum = 0;
                string txtsizedaxiao = "0";
                for (int i = 0; i < BLL.TxtBLL.TxtSizeBLL(txt).Tables[0].Rows.Count; i++)
                {
                    txtsizedaxiao = BLL.TxtBLL.TxtSizeBLL(txt).Tables[0].Rows[i][0].ToString();
                    if (txtsizedaxiao.IndexOf("KB") != -1)
                    {
                        if (txtsizedaxiao.Substring(txtsizedaxiao.LastIndexOf("K")) == "KB")
                        {
                            string[] txtsArray = txtsizedaxiao.Split('K');
                            txtzhuan = double.Parse(txtsArray[0]) / 1024;
                        }
                    }
                    if (txtsizedaxiao.IndexOf("KB") == -1 && txtsizedaxiao.IndexOf("MB") == -1)
                    {
                        if (txtsizedaxiao.Substring(txtsizedaxiao.LastIndexOf("B")) == "B")
                        {
                            string[] txtsArray = txtsizedaxiao.Split('B');
                            txtzhuan = double.Parse(txtsArray[0]) / 1024 / 1024;
                        }
                    }
                    if (txtsizedaxiao.IndexOf("MB") != -1)
                    {
                        if (txtsizedaxiao.Substring(txtsizedaxiao.LastIndexOf("M")) == "MB")
                        {
                            string[] txtsArray = txtsizedaxiao.Split('M');
                            txtzhuan = double.Parse(txtsArray[0]);
                        }
                    }

                    tetsum = tetsum + txtzhuan;

                }
                Model.Music music = new Model.Music();
                music.MusicId = txt.UserId;
                //Music表获取文件大小
                DataSet Musicsize = BLL.MusicBLL.MusicSizeBLL(music);
                //Music最终内存大小
                double musiczhuan = 0, musicsum = 0;
                string mudicsizedaxiao = "0";
                int musicshu = BLL.MusicBLL.MusicSizeBLL(music).Tables[0].Rows.Count;
                for (int i = 0; i < musicshu; i++)
                {
                    mudicsizedaxiao = BLL.MusicBLL.MusicSizeBLL(music).Tables[0].Rows[i][0].ToString();
                    if (mudicsizedaxiao.IndexOf("MB") != -1)
                    {
                        if (mudicsizedaxiao.Substring(mudicsizedaxiao.LastIndexOf("M")) == "MB")
                        {
                            string[] musicsArray = mudicsizedaxiao.Split('M');
                            musiczhuan = double.Parse(musicsArray[0]);
                        }
                    }
                    if (mudicsizedaxiao.IndexOf("KB") != -1)
                    {
                        if (mudicsizedaxiao.Substring(mudicsizedaxiao.LastIndexOf("K")) == "KB")
                        {
                            string[] musicsArray = mudicsizedaxiao.Split('K');
                            musiczhuan = double.Parse(musicsArray[0]) / 1024;
                        }
                    }
                    if (mudicsizedaxiao.IndexOf("KB") == -1 && mudicsizedaxiao.IndexOf("MB") == -1)
                    {
                        if (mudicsizedaxiao.Substring(mudicsizedaxiao.LastIndexOf("B")) == "B")
                        {
                            string[] musicsArray = mudicsizedaxiao.Split('B');
                            musiczhuan = double.Parse(musicsArray[0]) / 1024 / 1024;
                        }
                    }


                    musicsum = musicsum + musiczhuan;
                }
                //Others表获取文件大小
                Model.Others others = new Model.Others();
                others.UserId = txt.UserId;
                DataSet othersize = BLL.OthersBLL.OtherssizeBLL(others);
                double otherzhuan = 0, othersum = 0;
                string othersizedaxiao = "0";
                int othershu = BLL.OthersBLL.OtherssizeBLL(others).Tables[0].Rows.Count;
                for (int i = 0; i < othershu; i++)
                {
                    othersizedaxiao = BLL.OthersBLL.OtherssizeBLL(others).Tables[0].Rows[i][0].ToString();
                    if (othersizedaxiao.IndexOf("KB") != -1)
                    {
                        if (othersizedaxiao.Substring(othersizedaxiao.LastIndexOf("K")) == "KB")
                        {
                            string[] otherArray = othersizedaxiao.Split('K');
                            otherzhuan = double.Parse(otherArray[0]) / 1024;
                        }
                    }
                    if (othersizedaxiao.IndexOf("MB") != -1)
                    {
                        if (othersizedaxiao.Substring(othersizedaxiao.LastIndexOf("M")) == "MB")
                        {
                            string[] otherArray = othersizedaxiao.Split('M');
                            otherzhuan = double.Parse(otherArray[0]);
                        }
                    }
                    if (othersizedaxiao.IndexOf("KB") == -1 && othersizedaxiao.IndexOf("MB") == -1)
                    {
                        if (othersizedaxiao.Substring(othersizedaxiao.LastIndexOf("B")) == "B")
                        {
                            string[] otherArray = othersizedaxiao.Split('B');
                            otherzhuan = double.Parse(otherArray[0]) / 1024 / 1024;
                        }
                    }

                    othersum = othersum + otherzhuan;
                }
                //photo表获取文件大小
                Model.Photo photo = new Model.Photo();
                photo.UserId = int.Parse(ds.Tables[0].Rows[0][0].ToString());
                DataSet photosize = BLL.PhotoBLL.PhotoSizeBLL(photo);
                double photozhuan = 0, photosum = 0;
                string photosizedaxiao = "0";
                int photoshu = BLL.PhotoBLL.PhotoSizeBLL(photo).Tables[0].Rows.Count;
                for (int i = 0; i < photoshu; i++)
                {
                    photosizedaxiao = BLL.PhotoBLL.PhotoSizeBLL(photo).Tables[0].Rows[i][0].ToString();
                    if (photosizedaxiao.IndexOf("KB") != -1)
                    {
                        if (photosizedaxiao.Substring(photosizedaxiao.LastIndexOf("K")) == "KB")
                        {
                            string[] photoArray = photosizedaxiao.Split('K');
                            photozhuan = double.Parse(photoArray[0]) / 1024;

                        }
                    }
                    if (photosizedaxiao.IndexOf("MB") != -1)
                    {
                        if (photosizedaxiao.Substring(photosizedaxiao.LastIndexOf("M")) == "MB")
                        {
                            string[] photoArray = photosizedaxiao.Split('M');
                            photozhuan = double.Parse(photoArray[0]);
                        }
                    }

                    if (photosizedaxiao.IndexOf("MB") == -1 && photosizedaxiao.IndexOf("KB") == -1)
                    {
                        if (photosizedaxiao.Substring(photosizedaxiao.LastIndexOf("B")) == "B")
                        {
                            string[] photoArray = photosizedaxiao.Split('B');
                            photozhuan = double.Parse(photoArray[0]) / 1024 / 1024;
                        }
                    }


                    photosum = photosum + photozhuan;
                }
                Label3.Text = Math.Round(musicsum + tetsum + othersum + photosum, 2) + "MB".ToString();
                HiddenField1.Value = Math.Round(musicsum + tetsum + othersum + photosum, 2).ToString();
            }
        }//音频删除部分

        protected void LinkButton1_Click1(object sender, EventArgs e)
        {
            Model.Others OthersSelectById = new Model.Others();
            OthersSelectById.OthersId = int.Parse(((LinkButton)sender).CommandArgument);
            DataSet ds1 = BLL.OthersBLL.OthersSelectByIdBLL(OthersSelectById);
            Model.Recoverys RecInsert = new Model.Recoverys();
            RecInsert.RecoveryName = ds1.Tables[0].Rows[0][1].ToString();
            RecInsert.RecoveryTime = DateTime.Now;
            RecInsert.RecoveryUrl = ds1.Tables[0].Rows[0][5].ToString();
            RecInsert.RecoverySize = ds1.Tables[0].Rows[0][3].ToString();
            RecInsert.UserId = int.Parse(ds1.Tables[0].Rows[0][4].ToString());
            RecInsert.DiffTime = 10 - ((DateTime.Now - RecInsert.RecoveryTime).Days);
            int rows1 = BLL.RecoverysBLL.RecInsertBLL(RecInsert);
            if (rows1 > 0)
            {
                Model.Others OthersDelete = new Model.Others();
                OthersDelete.OthersId = int.Parse(((LinkButton)sender).CommandArgument);
                int rows = BLL.OthersBLL.OthersDeleteBLL(OthersDelete);

                if (rows > 0)
                {
                    Model.Users SelectIdUsers = new Model.Users();
                    SelectIdUsers.Username = Session["Name"].ToString();
                    DataSet ds = BLL.UsersBLL.SelectIdBLL(SelectIdUsers);
                    //音频部分
                    Model.Others OthersSelectId = new Model.Others();
                    OthersSelectId.UserId = int.Parse(ds.Tables[0].Rows[0][0].ToString());
                    GridView1.DataSource = BLL.OthersBLL.SelectIdBLL(OthersSelectId);
                    GridView1.DataBind();
                    //刷新
                    Model.Recoverys RecoverySelectId = new Model.Recoverys();
                    RecoverySelectId.UserId = int.Parse(ds.Tables[0].Rows[0][0].ToString());
                    GridView5.DataSource = BLL.RecoverysBLL.SelectBLL(RecoverySelectId);
                    GridView5.DataBind();//回收站刷新
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
            //刷新内存大小
            if (Session["Name"] != null)
            {
                Label2.Text = Session["Name"].ToString();
                Model.Users SelectIdUsers = new Model.Users();
                SelectIdUsers.Username = Session["Name"].ToString();
                DataSet ds = BLL.UsersBLL.SelectIdBLL(SelectIdUsers);
                //判断是否为vip实现充值
                Model.Users users = new Model.Users();
                users.Username = Session["Name"].ToString();
                DataSet dsisvip = BLL.UsersBLL.SelidBLL(users);
                int isvip = int.Parse(dsisvip.Tables[0].Rows[0][1].ToString());
                if (isvip == 0)
                {
                    Label5.Text = "/50MB";
                }
                else if (isvip == 1)
                {
                    Label5.Text = "/100MB";
                }
                Model.Txt txt = new Model.Txt();
                txt.UserId = int.Parse(ds.Tables[0].Rows[0][0].ToString());
                //txt表获取文件大小
                DataSet txtsize = BLL.TxtBLL.TxtSizeBLL(txt);
                //txt最终内存大小
                double txtzhuan = 0, tetsum = 0;
                string txtsizedaxiao = "0";
                for (int i = 0; i < BLL.TxtBLL.TxtSizeBLL(txt).Tables[0].Rows.Count; i++)
                {
                    txtsizedaxiao = BLL.TxtBLL.TxtSizeBLL(txt).Tables[0].Rows[i][0].ToString();
                    if (txtsizedaxiao.IndexOf("KB") != -1)
                    {
                        if (txtsizedaxiao.Substring(txtsizedaxiao.LastIndexOf("K")) == "KB")
                        {
                            string[] txtsArray = txtsizedaxiao.Split('K');
                            txtzhuan = double.Parse(txtsArray[0]) / 1024;
                        }
                    }
                    if (txtsizedaxiao.IndexOf("KB") == -1 && txtsizedaxiao.IndexOf("MB") == -1)
                    {
                        if (txtsizedaxiao.Substring(txtsizedaxiao.LastIndexOf("B")) == "B")
                        {
                            string[] txtsArray = txtsizedaxiao.Split('B');
                            txtzhuan = double.Parse(txtsArray[0]) / 1024 / 1024;
                        }
                    }
                    if (txtsizedaxiao.IndexOf("MB") != -1)
                    {
                        if (txtsizedaxiao.Substring(txtsizedaxiao.LastIndexOf("M")) == "MB")
                        {
                            string[] txtsArray = txtsizedaxiao.Split('M');
                            txtzhuan = double.Parse(txtsArray[0]);
                        }
                    }

                    tetsum = tetsum + txtzhuan;

                }
                Model.Music music = new Model.Music();
                music.MusicId = txt.UserId;
                //Music表获取文件大小
                DataSet Musicsize = BLL.MusicBLL.MusicSizeBLL(music);
                //Music最终内存大小
                double musiczhuan = 0, musicsum = 0;
                string mudicsizedaxiao = "0";
                int musicshu = BLL.MusicBLL.MusicSizeBLL(music).Tables[0].Rows.Count;
                for (int i = 0; i < musicshu; i++)
                {
                    mudicsizedaxiao = BLL.MusicBLL.MusicSizeBLL(music).Tables[0].Rows[i][0].ToString();
                    if (mudicsizedaxiao.IndexOf("MB") != -1)
                    {
                        if (mudicsizedaxiao.Substring(mudicsizedaxiao.LastIndexOf("M")) == "MB")
                        {
                            string[] musicsArray = mudicsizedaxiao.Split('M');
                            musiczhuan = double.Parse(musicsArray[0]);
                        }
                    }
                    if (mudicsizedaxiao.IndexOf("KB") != -1)
                    {
                        if (mudicsizedaxiao.Substring(mudicsizedaxiao.LastIndexOf("K")) == "KB")
                        {
                            string[] musicsArray = mudicsizedaxiao.Split('K');
                            musiczhuan = double.Parse(musicsArray[0]) / 1024;
                        }
                    }
                    if (mudicsizedaxiao.IndexOf("KB") == -1 && mudicsizedaxiao.IndexOf("MB") == -1)
                    {
                        if (mudicsizedaxiao.Substring(mudicsizedaxiao.LastIndexOf("B")) == "B")
                        {
                            string[] musicsArray = mudicsizedaxiao.Split('B');
                            musiczhuan = double.Parse(musicsArray[0]) / 1024 / 1024;
                        }
                    }


                    musicsum = musicsum + musiczhuan;
                }
                //Others表获取文件大小
                Model.Others others = new Model.Others();
                others.UserId = txt.UserId;
                DataSet othersize = BLL.OthersBLL.OtherssizeBLL(others);
                double otherzhuan = 0, othersum = 0;
                string othersizedaxiao = "0";
                int othershu = BLL.OthersBLL.OtherssizeBLL(others).Tables[0].Rows.Count;
                for (int i = 0; i < othershu; i++)
                {
                    othersizedaxiao = BLL.OthersBLL.OtherssizeBLL(others).Tables[0].Rows[i][0].ToString();
                    if (othersizedaxiao.IndexOf("KB") != -1)
                    {
                        if (othersizedaxiao.Substring(othersizedaxiao.LastIndexOf("K")) == "KB")
                        {
                            string[] otherArray = othersizedaxiao.Split('K');
                            otherzhuan = double.Parse(otherArray[0]) / 1024;
                        }
                    }
                    if (othersizedaxiao.IndexOf("MB") != -1)
                    {
                        if (othersizedaxiao.Substring(othersizedaxiao.LastIndexOf("M")) == "MB")
                        {
                            string[] otherArray = othersizedaxiao.Split('M');
                            otherzhuan = double.Parse(otherArray[0]);
                        }
                    }
                    if (othersizedaxiao.IndexOf("KB") == -1 && othersizedaxiao.IndexOf("MB") == -1)
                    {
                        if (othersizedaxiao.Substring(othersizedaxiao.LastIndexOf("B")) == "B")
                        {
                            string[] otherArray = othersizedaxiao.Split('B');
                            otherzhuan = double.Parse(otherArray[0]) / 1024 / 1024;
                        }
                    }

                    othersum = othersum + otherzhuan;
                }
                //photo表获取文件大小
                Model.Photo photo = new Model.Photo();
                photo.UserId = int.Parse(ds.Tables[0].Rows[0][0].ToString());
                DataSet photosize = BLL.PhotoBLL.PhotoSizeBLL(photo);
                double photozhuan = 0, photosum = 0;
                string photosizedaxiao = "0";
                int photoshu = BLL.PhotoBLL.PhotoSizeBLL(photo).Tables[0].Rows.Count;
                for (int i = 0; i < photoshu; i++)
                {
                    photosizedaxiao = BLL.PhotoBLL.PhotoSizeBLL(photo).Tables[0].Rows[i][0].ToString();
                    if (photosizedaxiao.IndexOf("KB") != -1)
                    {
                        if (photosizedaxiao.Substring(photosizedaxiao.LastIndexOf("K")) == "KB")
                        {
                            string[] photoArray = photosizedaxiao.Split('K');
                            photozhuan = double.Parse(photoArray[0]) / 1024;

                        }
                    }
                    if (photosizedaxiao.IndexOf("MB") != -1)
                    {
                        if (photosizedaxiao.Substring(photosizedaxiao.LastIndexOf("M")) == "MB")
                        {
                            string[] photoArray = photosizedaxiao.Split('M');
                            photozhuan = double.Parse(photoArray[0]);
                        }
                    }

                    if (photosizedaxiao.IndexOf("MB") == -1 && photosizedaxiao.IndexOf("KB") == -1)
                    {
                        if (photosizedaxiao.Substring(photosizedaxiao.LastIndexOf("B")) == "B")
                        {
                            string[] photoArray = photosizedaxiao.Split('B');
                            photozhuan = double.Parse(photoArray[0]) / 1024 / 1024;
                        }
                    }


                    photosum = photosum + photozhuan;
                }
                Label3.Text = Math.Round(musicsum + tetsum + othersum + photosum, 2) + "MB".ToString();
                HiddenField1.Value = Math.Round(musicsum + tetsum + othersum + photosum, 2).ToString();
            }
        }//其他删除部分

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Model.Recoverys RecDelete = new Model.Recoverys();
            RecDelete.RecoveryId = int.Parse(((LinkButton)sender).CommandArgument);
            DataSet fileds = BLL.RecoverysBLL.SelectByIdBLL(RecDelete);
            string filename = fileds.Tables[0].Rows[0][1].ToString();
            Model.Txt txtname = new Model.Txt();
            txtname.TxtName = filename;
            Model.Photo photoname = new Model.Photo();
            photoname.PhotoName = filename;
            Model.Music musicname = new Model.Music();
            musicname.MusicName = filename;
            Model.Others others = new Model.Others();
            others.OthersName = filename;
            RecDelete.RecoveryName = filename;
            DataSet name = BLL.RecoverysBLL.selectnameBLL(RecDelete);
            DataSet name1 = BLL.TxtBLL.selectnameBLL(txtname);
            DataSet name2 = BLL.PhotoBLL.selectnameBLL(photoname);
            DataSet name3 = BLL.MusicBLL.selectnameBLL(musicname);
            DataSet name4 = BLL.OthersBLL.selectnameBLL(others);
            int han = name.Tables[0].Rows.Count + name1.Tables[0].Rows.Count + name2.Tables[0].Rows.Count + name3.Tables[0].Rows.Count + name4.Tables[0].Rows.Count;
            if (han < 2)
            {
                File.Delete(Server.MapPath(upload + filename));
            }
            //删除项目文件中文件
            int rows = BLL.RecoverysBLL.RecDeleteBLL(RecDelete);

            if (rows > 0)
            {
                Model.Users SelectIdUsers = new Model.Users();
                SelectIdUsers.Username = Session["Name"].ToString();
                DataSet ds = BLL.UsersBLL.SelectIdBLL(SelectIdUsers);
                Model.Recoverys RecoverySelectId = new Model.Recoverys();
                RecoverySelectId.UserId = int.Parse(ds.Tables[0].Rows[0][0].ToString());
                GridView5.DataSource = BLL.RecoverysBLL.SelectBLL(RecoverySelectId);
                GridView5.DataBind();//回收站刷新
            }
            else
            {
                Response.Write("<script>alert('删除失败')</script>");
            }
        }//回收站删除

        protected void LinkButton1_Click4(object sender, EventArgs e)
        {

            Model.Recoverys RecoverysById = new Model.Recoverys();
            RecoverysById.RecoveryId = int.Parse(((LinkButton)sender).CommandArgument);
            DataSet ds = BLL.RecoverysBLL.SelectByIdBLL(RecoverysById);
            string a = ds.Tables[0].Rows[0][1].ToString();
            Model.Txt txtunique = new Model.Txt();
            txtunique.TxtName = a; txtunique.UserId = int.Parse(ds.Tables[0].Rows[0][4].ToString());
            Model.Photo photounique = new Model.Photo();
            photounique.PhotoName = a; photounique.UserId = int.Parse(ds.Tables[0].Rows[0][4].ToString());
            Model.Music musicunique = new Model.Music();
            musicunique.MusicName = a; musicunique.UserId = int.Parse(ds.Tables[0].Rows[0][4].ToString());
            Model.Others othersunique = new Model.Others();
            othersunique.OthersName = a; othersunique.UserId = int.Parse(ds.Tables[0].Rows[0][4].ToString());
            DataSet txtname = BLL.TxtBLL.uniqueBLL(txtunique); int b = txtname.Tables[0].Rows.Count;
            DataSet photoname = BLL.PhotoBLL.uniqueBLL(photounique);
            DataSet musicname = BLL.MusicBLL.uniqueBLL(musicunique);
            DataSet othersname = BLL.OthersBLL.uniqueBLL(othersunique);
            int unique = txtname.Tables[0].Rows.Count + photoname.Tables[0].Rows.Count + musicname.Tables[0].Rows.Count + othersname.Tables[0].Rows.Count;







            Label2.Text = Session["Name"].ToString();
            Model.Users SelectIdUsers8 = new Model.Users();
            SelectIdUsers8.Username = Session["Name"].ToString();
            DataSet dss8 = BLL.UsersBLL.SelectIdBLL(SelectIdUsers8);
            //判断是否为vip实现充值
            Model.Users users8 = new Model.Users();
            users8.Username = Session["Name"].ToString();
            DataSet dsisvip8 = BLL.UsersBLL.SelidBLL(users8);
            int isvip8 = int.Parse(dsisvip8.Tables[0].Rows[0][1].ToString());
            if (isvip8 == 0)
            {
                Label5.Text = "/50MB";
            }
            else if (isvip8 == 1)
            {
                Label5.Text = "/100MB";
            }
            Model.Txt txt8 = new Model.Txt();
            txt8.UserId = int.Parse(dss8.Tables[0].Rows[0][0].ToString());
            //txt表获取文件大小
            DataSet txtsize8 = BLL.TxtBLL.TxtSizeBLL(txt8);
            //txt最终内存大小
            double txtzhuan8 = 0, tetsum8 = 0;
            string txtsizedaxiao8 = "0";
            for (int i = 0; i < BLL.TxtBLL.TxtSizeBLL(txt8).Tables[0].Rows.Count; i++)
            {
                txtsizedaxiao8 = BLL.TxtBLL.TxtSizeBLL(txt8).Tables[0].Rows[i][0].ToString();
                if (txtsizedaxiao8.IndexOf("KB") != -1)
                {
                    if (txtsizedaxiao8.Substring(txtsizedaxiao8.LastIndexOf("K")) == "KB")
                    {
                        string[] txtsArray8 = txtsizedaxiao8.Split('K');
                        txtzhuan8 = double.Parse(txtsArray8[0]) / 1024;
                    }
                }
                if (txtsizedaxiao8.IndexOf("KB") == -1 && txtsizedaxiao8.IndexOf("MB") == -1)
                {
                    if (txtsizedaxiao8.Substring(txtsizedaxiao8.LastIndexOf("B")) == "B")
                    {
                        string[] txtsArray8 = txtsizedaxiao8.Split('B');
                        txtzhuan8 = double.Parse(txtsArray8[0]) / 1024 / 1024;
                    }
                }
                if (txtsizedaxiao8.IndexOf("MB") != -1)
                {
                    if (txtsizedaxiao8.Substring(txtsizedaxiao8.LastIndexOf("M")) == "MB")
                    {
                        string[] txtsArray = txtsizedaxiao8.Split('M');
                        txtzhuan8 = double.Parse(txtsArray[0]);
                    }
                }

                tetsum8 = tetsum8 + txtzhuan8;

            }
            Model.Music music8 = new Model.Music();
            music8.MusicId = txt8.UserId;
            //Music表获取文件大小
            DataSet Musicsize8 = BLL.MusicBLL.MusicSizeBLL(music8);
            //Music最终内存大小
            double musiczhuan8 = 0, musicsum8 = 0;
            string mudicsizedaxiao8 = "0";
            int musicshu8 = BLL.MusicBLL.MusicSizeBLL(music8).Tables[0].Rows.Count;
            for (int i = 0; i < musicshu8; i++)
            {
                mudicsizedaxiao8 = BLL.MusicBLL.MusicSizeBLL(music8).Tables[0].Rows[i][0].ToString();
                if (mudicsizedaxiao8.IndexOf("MB") != -1)
                {
                    if (mudicsizedaxiao8.Substring(mudicsizedaxiao8.LastIndexOf("M")) == "MB")
                    {
                        string[] musicsArray = mudicsizedaxiao8.Split('M');
                        musiczhuan8 = double.Parse(musicsArray[0]);
                    }
                }
                if (mudicsizedaxiao8.IndexOf("KB") != -1)
                {
                    if (mudicsizedaxiao8.Substring(mudicsizedaxiao8.LastIndexOf("K")) == "KB")
                    {
                        string[] musicsArray8 = mudicsizedaxiao8.Split('K');
                        musiczhuan8 = double.Parse(musicsArray8[0]) / 1024;
                    }
                }
                if (mudicsizedaxiao8.IndexOf("KB") == -1 && mudicsizedaxiao8.IndexOf("MB") == -1)
                {
                    if (mudicsizedaxiao8.Substring(mudicsizedaxiao8.LastIndexOf("B")) == "B")
                    {
                        string[] musicsArray8 = mudicsizedaxiao8.Split('B');
                        musiczhuan8 = double.Parse(musicsArray8[0]) / 1024 / 1024;
                    }
                }


                musicsum8 = musicsum8 + musiczhuan8;
            }
            //Others表获取文件大小
            Model.Others others8 = new Model.Others();
            others8.UserId = txt8.UserId;
            DataSet othersize8 = BLL.OthersBLL.OtherssizeBLL(others8);
            double otherzhuan8 = 0, othersum8 = 0;
            string othersizedaxiao8 = "0";
            //Others表获取文件大小
            int othershu8 = BLL.OthersBLL.OtherssizeBLL(others8).Tables[0].Rows.Count;
            for (int i = 0; i < othershu8; i++)
            {
                othersizedaxiao8 = BLL.OthersBLL.OtherssizeBLL(others8).Tables[0].Rows[i][0].ToString();
                if (othersizedaxiao8.IndexOf("KB") != -1)
                {
                    if (othersizedaxiao8.Substring(othersizedaxiao8.LastIndexOf("K")) == "KB")
                    {
                        string[] otherArray = othersizedaxiao8.Split('K');
                        otherzhuan8 = double.Parse(otherArray[0]) / 1024;
                    }
                }
                if (othersizedaxiao8.IndexOf("MB") != -1)
                {
                    if (othersizedaxiao8.Substring(othersizedaxiao8.LastIndexOf("M")) == "MB")
                    {
                        string[] otherArray = othersizedaxiao8.Split('M');
                        otherzhuan8 = double.Parse(otherArray[0]);
                    }
                }
                if (othersizedaxiao8.IndexOf("KB") == -1 && othersizedaxiao8.IndexOf("MB") == -1)
                {
                    if (othersizedaxiao8.Substring(othersizedaxiao8.LastIndexOf("B")) == "B")
                    {
                        string[] otherArray = othersizedaxiao8.Split('B');
                        otherzhuan8 = double.Parse(otherArray[0]) / 1024 / 1024;
                    }
                }

                othersum8 = othersum8 + otherzhuan8;
            }



            ////Others表获取文件大小
            //Model.Others others8 = new Model.Others();
            //others8.UserId = txt8.UserId;
            //DataSet othersize8 = BLL.OthersBLL.OtherssizeBLL(others8);
            //double otherzhuan8 = 0, othersum8 = 0;
            //string othersizedaxiao8 = "0";
            ////Others表获取文件大小

            //photo表获取文件大小
            Model.Photo photo7 = new Model.Photo();
            photo7.UserId = txt8.UserId;
            DataSet photosize7 = BLL.PhotoBLL.PhotoSizeBLL(photo7);
            double photozhuan7 = 0, photosum7 = 0;
            string photosizedaxiao7 = "0";
            int photoshu8 = BLL.PhotoBLL.PhotoSizeBLL(photo7).Tables[0].Rows.Count;
            for (int i = 0; i < photoshu8; i++)
            {
                photosizedaxiao7 = BLL.PhotoBLL.PhotoSizeBLL(photo7).Tables[0].Rows[i][0].ToString();
                if (photosizedaxiao7.IndexOf("KB") != -1)
                {
                    if (photosizedaxiao7.Substring(photosizedaxiao7.LastIndexOf("K")) == "KB")
                    {
                        string[] photoArray7 = photosizedaxiao7.Split('K');
                        photozhuan7 = double.Parse(photoArray7[0]) / 1024;

                    }
                }
                if (photosizedaxiao7.IndexOf("MB") != -1)
                {
                    if (photosizedaxiao7.Substring(photosizedaxiao7.LastIndexOf("M")) == "MB")
                    {
                        string[] photoArray7 = photosizedaxiao7.Split('M');
                        photozhuan7 = double.Parse(photoArray7[0]);
                    }
                }

                if (photosizedaxiao7.IndexOf("MB") == -1 && photosizedaxiao7.IndexOf("KB") == -1)
                {
                    if (photosizedaxiao7.Substring(photosizedaxiao7.LastIndexOf("B")) == "B")
                    {
                        string[] photoArray7 = photosizedaxiao7.Split('B');
                        photozhuan7 = double.Parse(photoArray7[0]) / 1024 / 1024;
                    }
                }
                photosum7 = photosum7 + photozhuan7;
            }
            Label3.Text = Math.Round(musicsum8 + tetsum8 + othersum8 + photosum7, 2) + "MB".ToString();
            HiddenField1.Value = Math.Round(musicsum8 + tetsum8 + othersum8 + photosum7, 2).ToString();




            string daxiao = ds.Tables[0].Rows[0][3].ToString();
            double huishoudaxiao = 0;
            if (daxiao.IndexOf("KB") != -1)
            {
                if (daxiao.Substring(daxiao.LastIndexOf("K")) == "KB")
                {
                    string[] otherArray = daxiao.Split('K');
                    huishoudaxiao = double.Parse(otherArray[0]) / 1024;
                }
            }
            if (daxiao.IndexOf("MB") != -1)
            {
                if (daxiao.Substring(daxiao.LastIndexOf("M")) == "MB")
                {
                    string[] otherArray = daxiao.Split('M');
                    huishoudaxiao = double.Parse(otherArray[0]);
                }
            }
            if (daxiao.IndexOf("KB") == -1 && daxiao.IndexOf("MB") == -1)
            {
                if (daxiao.Substring(daxiao.LastIndexOf("B")) == "B")
                {
                    string[] otherArray = daxiao.Split('B');
                    huishoudaxiao = double.Parse(otherArray[0]) / 1024 / 1024;
                }
            }





            if (isvip8 == 0)
            {
                if (Math.Round(musicsum8 + tetsum8 + othersum8 + photosum7, 2) + huishoudaxiao <= 50)
                {
                    if (unique == 0)
                    {
                        a = a.Substring(a.LastIndexOf("."));//获取后缀名

                        if (a == ".docx" || a == ".doc" || a == ".txt" || a == ".pptx" || a == ".ppt" || a == ".pdf" || a == ".rtf" || a == ".xls" || a == ".xlsx")
                        {
                            Model.Txt TxtInsert = new Model.Txt();
                            TxtInsert.TxtName = ds.Tables[0].Rows[0][1].ToString();
                            TxtInsert.TxtTime = DateTime.Now;
                            TxtInsert.TxtSize = ds.Tables[0].Rows[0][3].ToString();
                            TxtInsert.TxtUrl = ds.Tables[0].Rows[0][6].ToString();
                            TxtInsert.UserId = int.Parse(ds.Tables[0].Rows[0][4].ToString());
                            int rows = BLL.TxtBLL.TxtInsertBLL(TxtInsert);//回收添加
                            Model.Recoverys RecDelete = new Model.Recoverys();
                            RecDelete.RecoveryId = int.Parse(((LinkButton)sender).CommandArgument);
                            int rows1 = BLL.RecoverysBLL.RecDeleteBLL(RecDelete);//回收站删除
                            Model.Recoverys RecSelect = new Model.Recoverys();
                            RecSelect.UserId = int.Parse(ds.Tables[0].Rows[0][4].ToString());
                            GridView5.DataSource = BLL.RecoverysBLL.SelectBLL(RecSelect);
                            GridView5.DataBind();//回收站刷新
                            Model.Txt TxtSelect = new Model.Txt();
                            TxtSelect.UserId = int.Parse(ds.Tables[0].Rows[0][4].ToString());
                            GridView4.DataSource = BLL.TxtBLL.SelectBLL(TxtSelect);
                            GridView4.DataBind();//文档刷新

                        }
                        else if (a == ".jpg" || a == ".gif" || a == ".psd" || a == ".png" || a == ".jpeg" || a == ".bmp")
                        {
                            Model.Photo PhotoInsert = new Model.Photo();
                            PhotoInsert.PhotoName = ds.Tables[0].Rows[0][1].ToString();
                            PhotoInsert.PhotoTime = DateTime.Now;
                            PhotoInsert.PhotoSize = ds.Tables[0].Rows[0][3].ToString();
                            PhotoInsert.UserId = int.Parse(ds.Tables[0].Rows[0][4].ToString());
                            PhotoInsert.PhotoUrl = ds.Tables[0].Rows[0][6].ToString();
                            int rwos = BLL.PhotoBLL.PhotoInsertBLL(PhotoInsert);//回收添加
                            Model.Recoverys RecDelete = new Model.Recoverys();
                            RecDelete.RecoveryId = int.Parse(((LinkButton)sender).CommandArgument);
                            int rows1 = BLL.RecoverysBLL.RecDeleteBLL(RecDelete);//回收站删除
                            Model.Recoverys RecSelect = new Model.Recoverys();
                            RecSelect.UserId = int.Parse(ds.Tables[0].Rows[0][4].ToString());
                            GridView5.DataSource = BLL.RecoverysBLL.SelectBLL(RecSelect);
                            GridView5.DataBind();//回收站刷新
                            Model.Photo PhotoSelect = new Model.Photo();
                            PhotoSelect.UserId = int.Parse(ds.Tables[0].Rows[0][4].ToString());
                            GridView3.DataSource = BLL.PhotoBLL.SelectBLL(PhotoSelect);
                            GridView3.DataBind();//图片刷新
                        }
                        else if (a == ".mp3" || a == ".mgg" || a == ".wma" || a == ".cd")
                        {
                            Model.Music MusicInsert = new Model.Music();
                            MusicInsert.MusicName = ds.Tables[0].Rows[0][1].ToString();
                            MusicInsert.MusicTime = DateTime.Now;
                            MusicInsert.MusicSize = ds.Tables[0].Rows[0][3].ToString();
                            MusicInsert.UserId = int.Parse(ds.Tables[0].Rows[0][4].ToString());
                            MusicInsert.MusicUrl = ds.Tables[0].Rows[0][6].ToString();
                            int rows = BLL.MusicBLL.MusicInsertBLL(MusicInsert);//回收添加
                            Model.Recoverys RecDelete = new Model.Recoverys();
                            RecDelete.RecoveryId = int.Parse(((LinkButton)sender).CommandArgument);
                            int rows1 = BLL.RecoverysBLL.RecDeleteBLL(RecDelete);//回收站删除
                            Model.Recoverys RecSelect = new Model.Recoverys();
                            RecSelect.UserId = int.Parse(ds.Tables[0].Rows[0][4].ToString());
                            GridView5.DataSource = BLL.RecoverysBLL.SelectBLL(RecSelect);
                            GridView5.DataBind();//回收站刷新
                            Model.Music MusicSelect = new Model.Music();
                            MusicSelect.UserId = int.Parse(ds.Tables[0].Rows[0][4].ToString());
                            GridView2.DataSource = BLL.MusicBLL.SelectBLL(MusicSelect);
                            GridView2.DataBind();//音频刷新
                        }
                        else
                        {
                            Model.Others OthersInsert = new Model.Others();
                            OthersInsert.OthersName = ds.Tables[0].Rows[0][1].ToString();
                            OthersInsert.OthersTime = DateTime.Now;
                            OthersInsert.OthersSize = ds.Tables[0].Rows[0][3].ToString();
                            OthersInsert.UserId = int.Parse(ds.Tables[0].Rows[0][4].ToString());
                            OthersInsert.OthersUrl = ds.Tables[0].Rows[0][6].ToString();
                            int rows = BLL.OthersBLL.OthersInsertBLL(OthersInsert);//回收添加
                            Model.Recoverys RecDelete = new Model.Recoverys();
                            RecDelete.RecoveryId = int.Parse(((LinkButton)sender).CommandArgument);
                            int rows1 = BLL.RecoverysBLL.RecDeleteBLL(RecDelete);//回收站删除
                            Model.Recoverys RecSelect = new Model.Recoverys();
                            RecSelect.UserId = int.Parse(ds.Tables[0].Rows[0][4].ToString());
                            GridView5.DataSource = BLL.RecoverysBLL.SelectBLL(RecSelect);
                            GridView5.DataBind();//回收站刷新
                            Model.Others OthersSelect = new Model.Others();
                            OthersSelect.UserId = int.Parse(ds.Tables[0].Rows[0][4].ToString());
                            GridView1.DataSource = BLL.OthersBLL.SelectIdBLL(OthersSelect);
                            GridView1.DataBind();//其他刷新
                        }
                        //刷新内存大小
                        if (Session["Name"] != null)
                        {
                            Label2.Text = Session["Name"].ToString();
                            Model.Users SelectIdUsers = new Model.Users();
                            SelectIdUsers.Username = Session["Name"].ToString();
                            DataSet dss = BLL.UsersBLL.SelectIdBLL(SelectIdUsers);
                            //判断是否为vip实现充值
                            Model.Users users = new Model.Users();
                            users.Username = Session["Name"].ToString();
                            DataSet dsisvip = BLL.UsersBLL.SelidBLL(users);
                            int isvip = int.Parse(dsisvip.Tables[0].Rows[0][1].ToString());
                            if (isvip == 0)
                            {
                                Label5.Text = "/50MB";
                            }
                            else if (isvip == 1)
                            {
                                Label5.Text = "/100MB";
                            }
                            Model.Txt txt = new Model.Txt();
                            txt.UserId = int.Parse(dss.Tables[0].Rows[0][0].ToString());
                            //txt表获取文件大小
                            DataSet txtsize = BLL.TxtBLL.TxtSizeBLL(txt);
                            //txt最终内存大小
                            double txtzhuan = 0, tetsum = 0;
                            string txtsizedaxiao = "0";
                            for (int i = 0; i < BLL.TxtBLL.TxtSizeBLL(txt).Tables[0].Rows.Count; i++)
                            {
                                txtsizedaxiao = BLL.TxtBLL.TxtSizeBLL(txt).Tables[0].Rows[i][0].ToString();
                                if (txtsizedaxiao.IndexOf("KB") != -1)
                                {
                                    if (txtsizedaxiao.Substring(txtsizedaxiao.LastIndexOf("K")) == "KB")
                                    {
                                        string[] txtsArray = txtsizedaxiao.Split('K');
                                        txtzhuan = double.Parse(txtsArray[0]) / 1024;
                                    }
                                }
                                if (txtsizedaxiao.IndexOf("KB") == -1 && txtsizedaxiao.IndexOf("MB") == -1)
                                {
                                    if (txtsizedaxiao.Substring(txtsizedaxiao.LastIndexOf("B")) == "B")
                                    {
                                        string[] txtsArray = txtsizedaxiao.Split('B');
                                        txtzhuan = double.Parse(txtsArray[0]) / 1024 / 1024;
                                    }
                                }
                                if (txtsizedaxiao.IndexOf("MB") != -1)
                                {
                                    if (txtsizedaxiao.Substring(txtsizedaxiao.LastIndexOf("M")) == "MB")
                                    {
                                        string[] txtsArray = txtsizedaxiao.Split('M');
                                        txtzhuan = double.Parse(txtsArray[0]);
                                    }
                                }

                                tetsum = tetsum + txtzhuan;

                            }
                            Model.Music music = new Model.Music();
                            music.MusicId = txt.UserId;
                            //Music表获取文件大小
                            DataSet Musicsize = BLL.MusicBLL.MusicSizeBLL(music);
                            //Music最终内存大小
                            double musiczhuan = 0, musicsum = 0;
                            string mudicsizedaxiao = "0";
                            int musicshu = BLL.MusicBLL.MusicSizeBLL(music).Tables[0].Rows.Count;
                            for (int i = 0; i < musicshu; i++)
                            {
                                mudicsizedaxiao = BLL.MusicBLL.MusicSizeBLL(music).Tables[0].Rows[i][0].ToString();
                                if (mudicsizedaxiao.IndexOf("MB") != -1)
                                {
                                    if (mudicsizedaxiao.Substring(mudicsizedaxiao.LastIndexOf("M")) == "MB")
                                    {
                                        string[] musicsArray = mudicsizedaxiao.Split('M');
                                        musiczhuan = double.Parse(musicsArray[0]);
                                    }
                                }
                                if (mudicsizedaxiao.IndexOf("KB") != -1)
                                {
                                    if (mudicsizedaxiao.Substring(mudicsizedaxiao.LastIndexOf("K")) == "KB")
                                    {
                                        string[] musicsArray = mudicsizedaxiao.Split('K');
                                        musiczhuan = double.Parse(musicsArray[0]) / 1024;
                                    }
                                }
                                if (mudicsizedaxiao.IndexOf("KB") == -1 && mudicsizedaxiao.IndexOf("MB") == -1)
                                {
                                    if (mudicsizedaxiao.Substring(mudicsizedaxiao.LastIndexOf("B")) == "B")
                                    {
                                        string[] musicsArray = mudicsizedaxiao.Split('B');
                                        musiczhuan = double.Parse(musicsArray[0]) / 1024 / 1024;
                                    }
                                }


                                musicsum = musicsum + musiczhuan;
                            }
                            //Others表获取文件大小
                            Model.Others others = new Model.Others();
                            others.UserId = txt.UserId;
                            DataSet othersize = BLL.OthersBLL.OtherssizeBLL(others);
                            double otherzhuan = 0, othersum = 0;
                            string othersizedaxiao = "0";
                            int othershu = BLL.OthersBLL.OtherssizeBLL(others).Tables[0].Rows.Count;
                            for (int i = 0; i < othershu; i++)
                            {
                                othersizedaxiao = BLL.OthersBLL.OtherssizeBLL(others).Tables[0].Rows[i][0].ToString();
                                if (othersizedaxiao.IndexOf("KB") != -1)
                                {
                                    if (othersizedaxiao.Substring(othersizedaxiao.LastIndexOf("K")) == "KB")
                                    {
                                        string[] otherArray = othersizedaxiao.Split('K');
                                        otherzhuan = double.Parse(otherArray[0]) / 1024;
                                    }
                                }
                                if (othersizedaxiao.IndexOf("MB") != -1)
                                {
                                    if (othersizedaxiao.Substring(othersizedaxiao.LastIndexOf("M")) == "MB")
                                    {
                                        string[] otherArray = othersizedaxiao.Split('M');
                                        otherzhuan = double.Parse(otherArray[0]);
                                    }
                                }
                                if (othersizedaxiao.IndexOf("KB") == -1 && othersizedaxiao.IndexOf("MB") == -1)
                                {
                                    if (othersizedaxiao.Substring(othersizedaxiao.LastIndexOf("B")) == "B")
                                    {
                                        string[] otherArray = othersizedaxiao.Split('B');
                                        otherzhuan = double.Parse(otherArray[0]) / 1024 / 1024;
                                    }
                                }

                                othersum = othersum + otherzhuan;
                            }
                            //photo表获取文件大小
                            Model.Photo photo = new Model.Photo();
                            photo.UserId = int.Parse(ds.Tables[0].Rows[0][0].ToString());
                            DataSet photosize = BLL.PhotoBLL.PhotoSizeBLL(photo);
                            double photozhuan = 0, photosum = 0;
                            string photosizedaxiao = "0";
                            int photoshu = BLL.PhotoBLL.PhotoSizeBLL(photo).Tables[0].Rows.Count;
                            for (int i = 0; i < photoshu; i++)
                            {
                                photosizedaxiao = BLL.PhotoBLL.PhotoSizeBLL(photo).Tables[0].Rows[i][0].ToString();
                                if (photosizedaxiao.IndexOf("KB") != -1)
                                {
                                    if (photosizedaxiao.Substring(photosizedaxiao.LastIndexOf("K")) == "KB")
                                    {
                                        string[] photoArray = photosizedaxiao.Split('K');
                                        photozhuan = double.Parse(photoArray[0]) / 1024;

                                    }
                                }
                                if (photosizedaxiao.IndexOf("MB") != -1)
                                {
                                    if (photosizedaxiao.Substring(photosizedaxiao.LastIndexOf("M")) == "MB")
                                    {
                                        string[] photoArray = photosizedaxiao.Split('M');
                                        photozhuan = double.Parse(photoArray[0]);
                                    }
                                }

                                if (photosizedaxiao.IndexOf("MB") == -1 && photosizedaxiao.IndexOf("KB") == -1)
                                {
                                    if (photosizedaxiao.Substring(photosizedaxiao.LastIndexOf("B")) == "B")
                                    {
                                        string[] photoArray = photosizedaxiao.Split('B');
                                        photozhuan = double.Parse(photoArray[0]) / 1024 / 1024;
                                    }
                                }
                                photosum = photosum + photozhuan;
                            }
                            Label3.Text = Math.Round(musicsum + tetsum + othersum + photosum, 2) + "MB".ToString();
                            HiddenField1.Value = Math.Round(musicsum + tetsum + othersum + photosum, 2).ToString();
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('此文件已存在！')</script>");
                    }
                    //刷新内存大小
                    if (Session["Name"] != null)
                    {
                        Label2.Text = Session["Name"].ToString();
                        Model.Users SelectIdUsers = new Model.Users();
                        SelectIdUsers.Username = Session["Name"].ToString();
                        DataSet dss = BLL.UsersBLL.SelectIdBLL(SelectIdUsers);
                        //判断是否为vip实现充值
                        Model.Users users = new Model.Users();
                        users.Username = Session["Name"].ToString();
                        DataSet dsisvip = BLL.UsersBLL.SelidBLL(users);
                        int isvip = int.Parse(dsisvip.Tables[0].Rows[0][1].ToString());
                        if (isvip == 0)
                        {
                            Label5.Text = "/50MB";
                        }
                        Model.Txt txt = new Model.Txt();
                        txt.UserId = int.Parse(dss.Tables[0].Rows[0][0].ToString());
                        //txt表获取文件大小
                        DataSet txtsize = BLL.TxtBLL.TxtSizeBLL(txt);
                        //txt最终内存大小
                        double txtzhuan = 0, tetsum = 0;
                        string txtsizedaxiao = "0";
                        for (int i = 0; i < BLL.TxtBLL.TxtSizeBLL(txt).Tables[0].Rows.Count; i++)
                        {
                            txtsizedaxiao = BLL.TxtBLL.TxtSizeBLL(txt).Tables[0].Rows[i][0].ToString();
                            if (txtsizedaxiao.IndexOf("KB") != -1)
                            {
                                if (txtsizedaxiao.Substring(txtsizedaxiao.LastIndexOf("K")) == "KB")
                                {
                                    string[] txtsArray = txtsizedaxiao.Split('K');
                                    txtzhuan = double.Parse(txtsArray[0]) / 1024;
                                }
                            }
                            if (txtsizedaxiao.IndexOf("KB") == -1 && txtsizedaxiao.IndexOf("MB") == -1)
                            {
                                if (txtsizedaxiao.Substring(txtsizedaxiao.LastIndexOf("B")) == "B")
                                {
                                    string[] txtsArray = txtsizedaxiao.Split('B');
                                    txtzhuan = double.Parse(txtsArray[0]) / 1024 / 1024;
                                }
                            }
                            if (txtsizedaxiao.IndexOf("MB") != -1)
                            {
                                if (txtsizedaxiao.Substring(txtsizedaxiao.LastIndexOf("M")) == "MB")
                                {
                                    string[] txtsArray = txtsizedaxiao.Split('M');
                                    txtzhuan = double.Parse(txtsArray[0]);
                                }
                            }

                            tetsum = tetsum + txtzhuan;

                        }
                        Model.Music music = new Model.Music();
                        music.MusicId = txt.UserId;
                        //Music表获取文件大小
                        DataSet Musicsize = BLL.MusicBLL.MusicSizeBLL(music);
                        //Music最终内存大小
                        double musiczhuan = 0, musicsum = 0;
                        string mudicsizedaxiao = "0";
                        int musicshu = BLL.MusicBLL.MusicSizeBLL(music).Tables[0].Rows.Count;
                        for (int i = 0; i < musicshu; i++)
                        {
                            mudicsizedaxiao = BLL.MusicBLL.MusicSizeBLL(music).Tables[0].Rows[i][0].ToString();
                            if (mudicsizedaxiao.IndexOf("MB") != -1)
                            {
                                if (mudicsizedaxiao.Substring(mudicsizedaxiao.LastIndexOf("M")) == "MB")
                                {
                                    string[] musicsArray = mudicsizedaxiao.Split('M');
                                    musiczhuan = double.Parse(musicsArray[0]);
                                }
                            }
                            if (mudicsizedaxiao.IndexOf("KB") != -1)
                            {
                                if (mudicsizedaxiao.Substring(mudicsizedaxiao.LastIndexOf("K")) == "KB")
                                {
                                    string[] musicsArray = mudicsizedaxiao.Split('K');
                                    musiczhuan = double.Parse(musicsArray[0]) / 1024;
                                }
                            }
                            if (mudicsizedaxiao.IndexOf("KB") == -1 && mudicsizedaxiao.IndexOf("MB") == -1)
                            {
                                if (mudicsizedaxiao.Substring(mudicsizedaxiao.LastIndexOf("B")) == "B")
                                {
                                    string[] musicsArray = mudicsizedaxiao.Split('B');
                                    musiczhuan = double.Parse(musicsArray[0]) / 1024 / 1024;
                                }
                            }


                            musicsum = musicsum + musiczhuan;
                        }
                        //Others表获取文件大小
                        Model.Others others = new Model.Others();
                        others.UserId = txt.UserId;
                        DataSet othersize = BLL.OthersBLL.OtherssizeBLL(others);
                        double otherzhuan = 0, othersum = 0;
                        string othersizedaxiao = "0";
                        int othershu = BLL.OthersBLL.OtherssizeBLL(others).Tables[0].Rows.Count;
                        for (int i = 0; i < othershu; i++)
                        {
                            othersizedaxiao = BLL.OthersBLL.OtherssizeBLL(others).Tables[0].Rows[i][0].ToString();
                            if (othersizedaxiao.IndexOf("KB") != -1)
                            {
                                if (othersizedaxiao.Substring(othersizedaxiao.LastIndexOf("K")) == "KB")
                                {
                                    string[] otherArray = othersizedaxiao.Split('K');
                                    otherzhuan = double.Parse(otherArray[0]) / 1024;
                                }
                            }
                            if (othersizedaxiao.IndexOf("MB") != -1)
                            {
                                if (othersizedaxiao.Substring(othersizedaxiao.LastIndexOf("M")) == "MB")
                                {
                                    string[] otherArray = othersizedaxiao.Split('M');
                                    otherzhuan = double.Parse(otherArray[0]);
                                }
                            }
                            if (othersizedaxiao.IndexOf("KB") == -1 && othersizedaxiao.IndexOf("MB") == -1)
                            {
                                if (othersizedaxiao.Substring(othersizedaxiao.LastIndexOf("B")) == "B")
                                {
                                    string[] otherArray = othersizedaxiao.Split('B');
                                    otherzhuan = double.Parse(otherArray[0]) / 1024 / 1024;
                                }
                            }

                            othersum = othersum + otherzhuan;
                        }
                        //photo表获取文件大小
                        Model.Photo photo = new Model.Photo();
                        photo.UserId = int.Parse(dss.Tables[0].Rows[0][0].ToString());
                        DataSet photosize = BLL.PhotoBLL.PhotoSizeBLL(photo);
                        double photozhuan = 0, photosum = 0;
                        string photosizedaxiao = "0";
                        int photoshu = BLL.PhotoBLL.PhotoSizeBLL(photo).Tables[0].Rows.Count;
                        for (int i = 0; i < photoshu; i++)
                        {
                            photosizedaxiao = BLL.PhotoBLL.PhotoSizeBLL(photo).Tables[0].Rows[i][0].ToString();
                            if (photosizedaxiao.IndexOf("KB") != -1)
                            {
                                if (photosizedaxiao.Substring(photosizedaxiao.LastIndexOf("K")) == "KB")
                                {
                                    string[] photoArray = photosizedaxiao.Split('K');
                                    photozhuan = double.Parse(photoArray[0]) / 1024;

                                }
                            }
                            if (photosizedaxiao.IndexOf("MB") != -1)
                            {
                                if (photosizedaxiao.Substring(photosizedaxiao.LastIndexOf("M")) == "MB")
                                {
                                    string[] photoArray = photosizedaxiao.Split('M');
                                    photozhuan = double.Parse(photoArray[0]);
                                }
                            }

                            if (photosizedaxiao.IndexOf("MB") == -1 && photosizedaxiao.IndexOf("KB") == -1)
                            {
                                if (photosizedaxiao.Substring(photosizedaxiao.LastIndexOf("B")) == "B")
                                {
                                    string[] photoArray = photosizedaxiao.Split('B');
                                    photozhuan = double.Parse(photoArray[0]) / 1024 / 1024;
                                }
                            }
                            photosum = photosum + photozhuan;
                        }
                        Label3.Text = Math.Round(musicsum + tetsum + othersum + photosum, 2) + "MB".ToString();
                        HiddenField1.Value = Math.Round(musicsum + tetsum + othersum + photosum, 2).ToString();
                    }
                }
                else
                {
                    Response.Write("<script>alert('剩余存储空间不够，请充值VIP！')</script>");
                }
            }
            else if (isvip8 == 1)
            {
                if (Math.Round(musicsum8 + tetsum8 + othersum8 + photosum7, 2) + huishoudaxiao <= 100)
                {
                    if (unique == 0)
                    {
                        a = a.Substring(a.LastIndexOf("."));//获取后缀名

                        if (a == ".docx" || a == ".doc" || a == ".txt" || a == ".pptx" || a == ".ppt" || a == ".pdf" || a == ".rtf" || a == ".xls" || a == ".xlsx")
                        {
                            Model.Txt TxtInsert = new Model.Txt();
                            TxtInsert.TxtName = ds.Tables[0].Rows[0][1].ToString();
                            TxtInsert.TxtTime = DateTime.Now;
                            TxtInsert.TxtSize = ds.Tables[0].Rows[0][3].ToString();
                            TxtInsert.TxtUrl = ds.Tables[0].Rows[0][6].ToString();
                            TxtInsert.UserId = int.Parse(ds.Tables[0].Rows[0][4].ToString());
                            int rows = BLL.TxtBLL.TxtInsertBLL(TxtInsert);//回收添加
                            Model.Recoverys RecDelete = new Model.Recoverys();
                            RecDelete.RecoveryId = int.Parse(((LinkButton)sender).CommandArgument);
                            int rows1 = BLL.RecoverysBLL.RecDeleteBLL(RecDelete);//回收站删除
                            Model.Recoverys RecSelect = new Model.Recoverys();
                            RecSelect.UserId = int.Parse(ds.Tables[0].Rows[0][4].ToString());
                            GridView5.DataSource = BLL.RecoverysBLL.SelectBLL(RecSelect);
                            GridView5.DataBind();//回收站刷新
                            Model.Txt TxtSelect = new Model.Txt();
                            TxtSelect.UserId = int.Parse(ds.Tables[0].Rows[0][4].ToString());
                            GridView4.DataSource = BLL.TxtBLL.SelectBLL(TxtSelect);
                            GridView4.DataBind();//文档刷新

                        }
                        else if (a == ".jpg" || a == ".gif" || a == ".psd" || a == ".png" || a == ".jpeg" || a == ".bmp")
                        {
                            Model.Photo PhotoInsert = new Model.Photo();
                            PhotoInsert.PhotoName = ds.Tables[0].Rows[0][1].ToString();
                            PhotoInsert.PhotoTime = DateTime.Now;
                            PhotoInsert.PhotoSize = ds.Tables[0].Rows[0][3].ToString();
                            PhotoInsert.UserId = int.Parse(ds.Tables[0].Rows[0][4].ToString());
                            PhotoInsert.PhotoUrl = ds.Tables[0].Rows[0][6].ToString();
                            int rwos = BLL.PhotoBLL.PhotoInsertBLL(PhotoInsert);//回收添加
                            Model.Recoverys RecDelete = new Model.Recoverys();
                            RecDelete.RecoveryId = int.Parse(((LinkButton)sender).CommandArgument);
                            int rows1 = BLL.RecoverysBLL.RecDeleteBLL(RecDelete);//回收站删除
                            Model.Recoverys RecSelect = new Model.Recoverys();
                            RecSelect.UserId = int.Parse(ds.Tables[0].Rows[0][4].ToString());
                            GridView5.DataSource = BLL.RecoverysBLL.SelectBLL(RecSelect);
                            GridView5.DataBind();//回收站刷新
                            Model.Photo PhotoSelect = new Model.Photo();
                            PhotoSelect.UserId = int.Parse(ds.Tables[0].Rows[0][4].ToString());
                            GridView3.DataSource = BLL.PhotoBLL.SelectBLL(PhotoSelect);
                            GridView3.DataBind();//图片刷新
                        }
                        else if (a == ".mp3" || a == ".mgg" || a == ".wma" || a == ".cd")
                        {
                            Model.Music MusicInsert = new Model.Music();
                            MusicInsert.MusicName = ds.Tables[0].Rows[0][1].ToString();
                            MusicInsert.MusicTime = DateTime.Now;
                            MusicInsert.MusicSize = ds.Tables[0].Rows[0][3].ToString();
                            MusicInsert.UserId = int.Parse(ds.Tables[0].Rows[0][4].ToString());
                            MusicInsert.MusicUrl = ds.Tables[0].Rows[0][6].ToString();
                            int rows = BLL.MusicBLL.MusicInsertBLL(MusicInsert);//回收添加
                            Model.Recoverys RecDelete = new Model.Recoverys();
                            RecDelete.RecoveryId = int.Parse(((LinkButton)sender).CommandArgument);
                            int rows1 = BLL.RecoverysBLL.RecDeleteBLL(RecDelete);//回收站删除
                            Model.Recoverys RecSelect = new Model.Recoverys();
                            RecSelect.UserId = int.Parse(ds.Tables[0].Rows[0][4].ToString());
                            GridView5.DataSource = BLL.RecoverysBLL.SelectBLL(RecSelect);
                            GridView5.DataBind();//回收站刷新
                            Model.Music MusicSelect = new Model.Music();
                            MusicSelect.UserId = int.Parse(ds.Tables[0].Rows[0][4].ToString());
                            GridView2.DataSource = BLL.MusicBLL.SelectBLL(MusicSelect);
                            GridView2.DataBind();//音频刷新
                        }
                        else
                        {
                            Model.Others OthersInsert = new Model.Others();
                            OthersInsert.OthersName = ds.Tables[0].Rows[0][1].ToString();
                            OthersInsert.OthersTime = DateTime.Now;
                            OthersInsert.OthersSize = ds.Tables[0].Rows[0][3].ToString();
                            OthersInsert.UserId = int.Parse(ds.Tables[0].Rows[0][4].ToString());
                            OthersInsert.OthersUrl = ds.Tables[0].Rows[0][6].ToString();
                            int rows = BLL.OthersBLL.OthersInsertBLL(OthersInsert);//回收添加
                            Model.Recoverys RecDelete = new Model.Recoverys();
                            RecDelete.RecoveryId = int.Parse(((LinkButton)sender).CommandArgument);
                            int rows1 = BLL.RecoverysBLL.RecDeleteBLL(RecDelete);//回收站删除
                            Model.Recoverys RecSelect = new Model.Recoverys();
                            RecSelect.UserId = int.Parse(ds.Tables[0].Rows[0][4].ToString());
                            GridView5.DataSource = BLL.RecoverysBLL.SelectBLL(RecSelect);
                            GridView5.DataBind();//回收站刷新
                            Model.Others OthersSelect = new Model.Others();
                            OthersSelect.UserId = int.Parse(ds.Tables[0].Rows[0][4].ToString());
                            GridView1.DataSource = BLL.OthersBLL.SelectIdBLL(OthersSelect);
                            GridView1.DataBind();//其他刷新
                        }
                        //刷新内存大小
                        if (Session["Name"] != null)
                        {
                            Label2.Text = Session["Name"].ToString();
                            Model.Users SelectIdUsers = new Model.Users();
                            SelectIdUsers.Username = Session["Name"].ToString();
                            DataSet dss = BLL.UsersBLL.SelectIdBLL(SelectIdUsers);
                            //判断是否为vip实现充值
                            Model.Users users = new Model.Users();
                            users.Username = Session["Name"].ToString();
                            DataSet dsisvip = BLL.UsersBLL.SelidBLL(users);
                            int isvip = int.Parse(dsisvip.Tables[0].Rows[0][1].ToString());
                            if (isvip == 0)
                            {
                                Label5.Text = "/50MB";
                            }
                            else if (isvip == 1)
                            {
                                Label5.Text = "/100MB";
                            }
                            Model.Txt txt = new Model.Txt();
                            txt.UserId = int.Parse(dss.Tables[0].Rows[0][0].ToString());
                            //txt表获取文件大小
                            DataSet txtsize = BLL.TxtBLL.TxtSizeBLL(txt);
                            //txt最终内存大小
                            double txtzhuan = 0, tetsum = 0;
                            string txtsizedaxiao = "0";
                            for (int i = 0; i < BLL.TxtBLL.TxtSizeBLL(txt).Tables[0].Rows.Count; i++)
                            {
                                txtsizedaxiao = BLL.TxtBLL.TxtSizeBLL(txt).Tables[0].Rows[i][0].ToString();
                                if (txtsizedaxiao.IndexOf("KB") != -1)
                                {
                                    if (txtsizedaxiao.Substring(txtsizedaxiao.LastIndexOf("K")) == "KB")
                                    {
                                        string[] txtsArray = txtsizedaxiao.Split('K');
                                        txtzhuan = double.Parse(txtsArray[0]) / 1024;
                                    }
                                }
                                if (txtsizedaxiao.IndexOf("KB") == -1 && txtsizedaxiao.IndexOf("MB") == -1)
                                {
                                    if (txtsizedaxiao.Substring(txtsizedaxiao.LastIndexOf("B")) == "B")
                                    {
                                        string[] txtsArray = txtsizedaxiao.Split('B');
                                        txtzhuan = double.Parse(txtsArray[0]) / 1024 / 1024;
                                    }
                                }
                                if (txtsizedaxiao.IndexOf("MB") != -1)
                                {
                                    if (txtsizedaxiao.Substring(txtsizedaxiao.LastIndexOf("M")) == "MB")
                                    {
                                        string[] txtsArray = txtsizedaxiao.Split('M');
                                        txtzhuan = double.Parse(txtsArray[0]);
                                    }
                                }

                                tetsum = tetsum + txtzhuan;

                            }
                            Model.Music music = new Model.Music();
                            music.MusicId = txt.UserId;
                            //Music表获取文件大小
                            DataSet Musicsize = BLL.MusicBLL.MusicSizeBLL(music);
                            //Music最终内存大小
                            double musiczhuan = 0, musicsum = 0;
                            string mudicsizedaxiao = "0";
                            int musicshu = BLL.MusicBLL.MusicSizeBLL(music).Tables[0].Rows.Count;
                            for (int i = 0; i < musicshu; i++)
                            {
                                mudicsizedaxiao = BLL.MusicBLL.MusicSizeBLL(music).Tables[0].Rows[i][0].ToString();
                                if (mudicsizedaxiao.IndexOf("MB") != -1)
                                {
                                    if (mudicsizedaxiao.Substring(mudicsizedaxiao.LastIndexOf("M")) == "MB")
                                    {
                                        string[] musicsArray = mudicsizedaxiao.Split('M');
                                        musiczhuan = double.Parse(musicsArray[0]);
                                    }
                                }
                                if (mudicsizedaxiao.IndexOf("KB") != -1)
                                {
                                    if (mudicsizedaxiao.Substring(mudicsizedaxiao.LastIndexOf("K")) == "KB")
                                    {
                                        string[] musicsArray = mudicsizedaxiao.Split('K');
                                        musiczhuan = double.Parse(musicsArray[0]) / 1024;
                                    }
                                }
                                if (mudicsizedaxiao.IndexOf("KB") == -1 && mudicsizedaxiao.IndexOf("MB") == -1)
                                {
                                    if (mudicsizedaxiao.Substring(mudicsizedaxiao.LastIndexOf("B")) == "B")
                                    {
                                        string[] musicsArray = mudicsizedaxiao.Split('B');
                                        musiczhuan = double.Parse(musicsArray[0]) / 1024 / 1024;
                                    }
                                }


                                musicsum = musicsum + musiczhuan;
                            }
                            //Others表获取文件大小
                            Model.Others others = new Model.Others();
                            others.UserId = txt.UserId;
                            DataSet othersize = BLL.OthersBLL.OtherssizeBLL(others);
                            double otherzhuan = 0, othersum = 0;
                            string othersizedaxiao = "0";
                            int othershu = BLL.OthersBLL.OtherssizeBLL(others).Tables[0].Rows.Count;
                            for (int i = 0; i < othershu; i++)
                            {
                                othersizedaxiao = BLL.OthersBLL.OtherssizeBLL(others).Tables[0].Rows[i][0].ToString();
                                if (othersizedaxiao.IndexOf("KB") != -1)
                                {
                                    if (othersizedaxiao.Substring(othersizedaxiao.LastIndexOf("K")) == "KB")
                                    {
                                        string[] otherArray = othersizedaxiao.Split('K');
                                        otherzhuan = double.Parse(otherArray[0]) / 1024;
                                    }
                                }
                                if (othersizedaxiao.IndexOf("MB") != -1)
                                {
                                    if (othersizedaxiao.Substring(othersizedaxiao.LastIndexOf("M")) == "MB")
                                    {
                                        string[] otherArray = othersizedaxiao.Split('M');
                                        otherzhuan = double.Parse(otherArray[0]);
                                    }
                                }
                                if (othersizedaxiao.IndexOf("KB") == -1 && othersizedaxiao.IndexOf("MB") == -1)
                                {
                                    if (othersizedaxiao.Substring(othersizedaxiao.LastIndexOf("B")) == "B")
                                    {
                                        string[] otherArray = othersizedaxiao.Split('B');
                                        otherzhuan = double.Parse(otherArray[0]) / 1024 / 1024;
                                    }
                                }

                                othersum = othersum + otherzhuan;
                            }
                            //photo表获取文件大小
                            Model.Photo photo = new Model.Photo();
                            photo.UserId = int.Parse(ds.Tables[0].Rows[0][0].ToString());
                            DataSet photosize = BLL.PhotoBLL.PhotoSizeBLL(photo);
                            double photozhuan = 0, photosum = 0;
                            string photosizedaxiao = "0";
                            int photoshu = BLL.PhotoBLL.PhotoSizeBLL(photo).Tables[0].Rows.Count;
                            for (int i = 0; i < photoshu; i++)
                            {
                                photosizedaxiao = BLL.PhotoBLL.PhotoSizeBLL(photo).Tables[0].Rows[i][0].ToString();
                                if (photosizedaxiao.IndexOf("KB") != -1)
                                {
                                    if (photosizedaxiao.Substring(photosizedaxiao.LastIndexOf("K")) == "KB")
                                    {
                                        string[] photoArray = photosizedaxiao.Split('K');
                                        photozhuan = double.Parse(photoArray[0]) / 1024;

                                    }
                                }
                                if (photosizedaxiao.IndexOf("MB") != -1)
                                {
                                    if (photosizedaxiao.Substring(photosizedaxiao.LastIndexOf("M")) == "MB")
                                    {
                                        string[] photoArray = photosizedaxiao.Split('M');
                                        photozhuan = double.Parse(photoArray[0]);
                                    }
                                }

                                if (photosizedaxiao.IndexOf("MB") == -1 && photosizedaxiao.IndexOf("KB") == -1)
                                {
                                    if (photosizedaxiao.Substring(photosizedaxiao.LastIndexOf("B")) == "B")
                                    {
                                        string[] photoArray = photosizedaxiao.Split('B');
                                        photozhuan = double.Parse(photoArray[0]) / 1024 / 1024;
                                    }
                                }
                                photosum = photosum + photozhuan;
                            }
                            Label3.Text = Math.Round(musicsum + tetsum + othersum + photosum, 2) + "MB".ToString();
                            HiddenField1.Value = Math.Round(musicsum + tetsum + othersum + photosum, 2).ToString();
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('此文件已存在！')</script>");
                    }
                    //刷新内存大小
                    if (Session["Name"] != null)
                    {
                        Label2.Text = Session["Name"].ToString();
                        Model.Users SelectIdUsers = new Model.Users();
                        SelectIdUsers.Username = Session["Name"].ToString();
                        DataSet dss = BLL.UsersBLL.SelectIdBLL(SelectIdUsers);
                        //判断是否为vip实现充值
                        Model.Users users = new Model.Users();
                        users.Username = Session["Name"].ToString();
                        DataSet dsisvip = BLL.UsersBLL.SelidBLL(users);
                        int isvip = int.Parse(dsisvip.Tables[0].Rows[0][1].ToString());
                        if (isvip == 0)
                        {
                            Label5.Text = "/50MB";
                        }
                        Model.Txt txt = new Model.Txt();
                        txt.UserId = int.Parse(dss.Tables[0].Rows[0][0].ToString());
                        //txt表获取文件大小
                        DataSet txtsize = BLL.TxtBLL.TxtSizeBLL(txt);
                        //txt最终内存大小
                        double txtzhuan = 0, tetsum = 0;
                        string txtsizedaxiao = "0";
                        for (int i = 0; i < BLL.TxtBLL.TxtSizeBLL(txt).Tables[0].Rows.Count; i++)
                        {
                            txtsizedaxiao = BLL.TxtBLL.TxtSizeBLL(txt).Tables[0].Rows[i][0].ToString();
                            if (txtsizedaxiao.IndexOf("KB") != -1)
                            {
                                if (txtsizedaxiao.Substring(txtsizedaxiao.LastIndexOf("K")) == "KB")
                                {
                                    string[] txtsArray = txtsizedaxiao.Split('K');
                                    txtzhuan = double.Parse(txtsArray[0]) / 1024;
                                }
                            }
                            if (txtsizedaxiao.IndexOf("KB") == -1 && txtsizedaxiao.IndexOf("MB") == -1)
                            {
                                if (txtsizedaxiao.Substring(txtsizedaxiao.LastIndexOf("B")) == "B")
                                {
                                    string[] txtsArray = txtsizedaxiao.Split('B');
                                    txtzhuan = double.Parse(txtsArray[0]) / 1024 / 1024;
                                }
                            }
                            if (txtsizedaxiao.IndexOf("MB") != -1)
                            {
                                if (txtsizedaxiao.Substring(txtsizedaxiao.LastIndexOf("M")) == "MB")
                                {
                                    string[] txtsArray = txtsizedaxiao.Split('M');
                                    txtzhuan = double.Parse(txtsArray[0]);
                                }
                            }

                            tetsum = tetsum + txtzhuan;

                        }
                        Model.Music music = new Model.Music();
                        music.MusicId = txt.UserId;
                        //Music表获取文件大小
                        DataSet Musicsize = BLL.MusicBLL.MusicSizeBLL(music);
                        //Music最终内存大小
                        double musiczhuan = 0, musicsum = 0;
                        string mudicsizedaxiao = "0";
                        int musicshu = BLL.MusicBLL.MusicSizeBLL(music).Tables[0].Rows.Count;
                        for (int i = 0; i < musicshu; i++)
                        {
                            mudicsizedaxiao = BLL.MusicBLL.MusicSizeBLL(music).Tables[0].Rows[i][0].ToString();
                            if (mudicsizedaxiao.IndexOf("MB") != -1)
                            {
                                if (mudicsizedaxiao.Substring(mudicsizedaxiao.LastIndexOf("M")) == "MB")
                                {
                                    string[] musicsArray = mudicsizedaxiao.Split('M');
                                    musiczhuan = double.Parse(musicsArray[0]);
                                }
                            }
                            if (mudicsizedaxiao.IndexOf("KB") != -1)
                            {
                                if (mudicsizedaxiao.Substring(mudicsizedaxiao.LastIndexOf("K")) == "KB")
                                {
                                    string[] musicsArray = mudicsizedaxiao.Split('K');
                                    musiczhuan = double.Parse(musicsArray[0]) / 1024;
                                }
                            }
                            if (mudicsizedaxiao.IndexOf("KB") == -1 && mudicsizedaxiao.IndexOf("MB") == -1)
                            {
                                if (mudicsizedaxiao.Substring(mudicsizedaxiao.LastIndexOf("B")) == "B")
                                {
                                    string[] musicsArray = mudicsizedaxiao.Split('B');
                                    musiczhuan = double.Parse(musicsArray[0]) / 1024 / 1024;
                                }
                            }


                            musicsum = musicsum + musiczhuan;
                        }
                        //Others表获取文件大小
                        Model.Others others = new Model.Others();
                        others.UserId = txt.UserId;
                        DataSet othersize = BLL.OthersBLL.OtherssizeBLL(others);
                        double otherzhuan = 0, othersum = 0;
                        string othersizedaxiao = "0";
                        int othershu = BLL.OthersBLL.OtherssizeBLL(others).Tables[0].Rows.Count;
                        for (int i = 0; i < othershu; i++)
                        {
                            othersizedaxiao = BLL.OthersBLL.OtherssizeBLL(others).Tables[0].Rows[i][0].ToString();
                            if (othersizedaxiao.IndexOf("KB") != -1)
                            {
                                if (othersizedaxiao.Substring(othersizedaxiao.LastIndexOf("K")) == "KB")
                                {
                                    string[] otherArray = othersizedaxiao.Split('K');
                                    otherzhuan = double.Parse(otherArray[0]) / 1024;
                                }
                            }
                            if (othersizedaxiao.IndexOf("MB") != -1)
                            {
                                if (othersizedaxiao.Substring(othersizedaxiao.LastIndexOf("M")) == "MB")
                                {
                                    string[] otherArray = othersizedaxiao.Split('M');
                                    otherzhuan = double.Parse(otherArray[0]);
                                }
                            }
                            if (othersizedaxiao.IndexOf("KB") == -1 && othersizedaxiao.IndexOf("MB") == -1)
                            {
                                if (othersizedaxiao.Substring(othersizedaxiao.LastIndexOf("B")) == "B")
                                {
                                    string[] otherArray = othersizedaxiao.Split('B');
                                    otherzhuan = double.Parse(otherArray[0]) / 1024 / 1024;
                                }
                            }

                            othersum = othersum + otherzhuan;
                        }
                        //photo表获取文件大小
                        Model.Photo photo = new Model.Photo();
                        photo.UserId = int.Parse(dss.Tables[0].Rows[0][0].ToString());
                        DataSet photosize = BLL.PhotoBLL.PhotoSizeBLL(photo);
                        double photozhuan = 0, photosum = 0;
                        string photosizedaxiao = "0";
                        int photoshu = BLL.PhotoBLL.PhotoSizeBLL(photo).Tables[0].Rows.Count;
                        for (int i = 0; i < photoshu; i++)
                        {
                            photosizedaxiao = BLL.PhotoBLL.PhotoSizeBLL(photo).Tables[0].Rows[i][0].ToString();
                            if (photosizedaxiao.IndexOf("KB") != -1)
                            {
                                if (photosizedaxiao.Substring(photosizedaxiao.LastIndexOf("K")) == "KB")
                                {
                                    string[] photoArray = photosizedaxiao.Split('K');
                                    photozhuan = double.Parse(photoArray[0]) / 1024;

                                }
                            }
                            if (photosizedaxiao.IndexOf("MB") != -1)
                            {
                                if (photosizedaxiao.Substring(photosizedaxiao.LastIndexOf("M")) == "MB")
                                {
                                    string[] photoArray = photosizedaxiao.Split('M');
                                    photozhuan = double.Parse(photoArray[0]);
                                }
                            }

                            if (photosizedaxiao.IndexOf("MB") == -1 && photosizedaxiao.IndexOf("KB") == -1)
                            {
                                if (photosizedaxiao.Substring(photosizedaxiao.LastIndexOf("B")) == "B")
                                {
                                    string[] photoArray = photosizedaxiao.Split('B');
                                    photozhuan = double.Parse(photoArray[0]) / 1024 / 1024;
                                }
                            }
                            photosum = photosum + photozhuan;
                        }
                        Label3.Text = Math.Round(musicsum + tetsum + othersum + photosum, 2) + "MB".ToString();
                        HiddenField1.Value = Math.Round(musicsum + tetsum + othersum + photosum, 2).ToString();
                    }
                }
                else
                {
                    Response.Write("<script>alert('剩余存储空间不够，请充值VIP！')</script>");
                }
            }
        }//还原


        protected string upload = "~/UploadFile/";
        protected string aDile = "~/aFile";
        protected void Button7_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                Model.Users SelectIdUsers = new Model.Users();
                SelectIdUsers.Username = Session["Name"].ToString();
                DataSet ds = BLL.UsersBLL.SelectIdBLL(SelectIdUsers);
                int kbc = 1024;
                int mbc = kbc * 1024;
                int gbc = mbc * 1024;
                string filename = FileUpload1.PostedFile.FileName;//获取文件名称

                int filecount = int.Parse(FileUpload1.PostedFile.ContentLength.ToString());//获取文件大小
                //选取所选文件的本地路径
                Model.Txt txtunique = new Model.Txt();
                txtunique.TxtName = filename; txtunique.UserId = int.Parse(ds.Tables[0].Rows[0][0].ToString());
                Model.Photo photounique = new Model.Photo();
                photounique.PhotoName = filename; photounique.UserId = int.Parse(ds.Tables[0].Rows[0][0].ToString());
                Model.Music musicunique = new Model.Music();
                musicunique.MusicName = filename; musicunique.UserId = int.Parse(ds.Tables[0].Rows[0][0].ToString());
                Model.Others othersunique = new Model.Others();
                othersunique.OthersName = filename; othersunique.UserId = int.Parse(ds.Tables[0].Rows[0][0].ToString());
                DataSet txtname = BLL.TxtBLL.uniqueBLL(txtunique);
                DataSet photoname = BLL.PhotoBLL.uniqueBLL(photounique);
                DataSet musicname = BLL.MusicBLL.uniqueBLL(musicunique);
                DataSet othersname = BLL.OthersBLL.uniqueBLL(othersunique);
                int unique = txtname.Tables[0].Rows.Count + photoname.Tables[0].Rows.Count + musicname.Tables[0].Rows.Count + othersname.Tables[0].Rows.Count;
                if (unique == 0)
                {
                    FileUpload1.SaveAs(Server.MapPath(upload) + filename);
                    string filemb;
                    if (filecount > 1024 && filecount < mbc)
                    {
                        filemb = Math.Round(filecount / (float)kbc, 2).ToString() + "KB";
                    }
                    else if (filecount > mbc && filecount < gbc)
                    {
                        filemb = Math.Round(filecount / (float)mbc, 2).ToString() + "MB";
                    }
                    else if (filecount > gbc)
                    {
                        filemb = Math.Round(filecount / (float)gbc, 2).ToString() + "GB";
                    }
                    else
                    {
                        filemb = filecount.ToString() + "B";
                    }

                    string b = filename.Substring(filename.LastIndexOf(".")).ToLower();//获取后缀名

                    //刷新内存大小
                    if (Session["Name"] != null)
                    {
                        Label2.Text = Session["Name"].ToString();
                        Model.Users SelectIdUserss = new Model.Users();
                        SelectIdUserss.Username = Session["Name"].ToString();
                        DataSet dss = BLL.UsersBLL.SelectIdBLL(SelectIdUserss);
                        //判断是否为vip实现充值
                        Model.Users users = new Model.Users();
                        users.Username = Session["Name"].ToString();
                        DataSet dsisvip = BLL.UsersBLL.SelidBLL(users);
                        int isvip = int.Parse(dsisvip.Tables[0].Rows[0][1].ToString());
                        if (isvip == 0)
                        {
                            Label5.Text = "/50MB";
                        }
                        else if (isvip == 1)
                        {
                            Label5.Text = "/100MB";
                        }
                        Model.Txt txt = new Model.Txt();
                        txt.UserId = int.Parse(dss.Tables[0].Rows[0][0].ToString());
                        //txt表获取文件大小
                        DataSet txtsize = BLL.TxtBLL.TxtSizeBLL(txt);
                        //txt最终内存大小
                        double txtzhuan = 0, tetsum = 0;
                        string txtsizedaxiao = "0";
                        for (int i = 0; i < BLL.TxtBLL.TxtSizeBLL(txt).Tables[0].Rows.Count; i++)
                        {
                            txtsizedaxiao = BLL.TxtBLL.TxtSizeBLL(txt).Tables[0].Rows[i][0].ToString();
                            if (txtsizedaxiao.IndexOf("KB") != -1)
                            {
                                if (txtsizedaxiao.Substring(txtsizedaxiao.LastIndexOf("K")) == "KB")
                                {
                                    string[] txtsArray = txtsizedaxiao.Split('K');
                                    txtzhuan = double.Parse(txtsArray[0]) / 1024;
                                }
                            }
                            if (txtsizedaxiao.IndexOf("KB") == -1 && txtsizedaxiao.IndexOf("MB") == -1)
                            {
                                if (txtsizedaxiao.Substring(txtsizedaxiao.LastIndexOf("B")) == "B")
                                {
                                    string[] txtsArray = txtsizedaxiao.Split('B');
                                    txtzhuan = double.Parse(txtsArray[0]) / 1024 / 1024;
                                }
                            }
                            if (txtsizedaxiao.IndexOf("MB") != -1)
                            {
                                if (txtsizedaxiao.Substring(txtsizedaxiao.LastIndexOf("M")) == "MB")
                                {
                                    string[] txtsArray = txtsizedaxiao.Split('M');
                                    txtzhuan = double.Parse(txtsArray[0]);
                                }
                            }

                            tetsum = tetsum + txtzhuan;

                        }
                        Model.Music music = new Model.Music();
                        music.MusicId = txt.UserId;
                        //Music表获取文件大小
                        DataSet Musicsize = BLL.MusicBLL.MusicSizeBLL(music);
                        //Music最终内存大小
                        double musiczhuan = 0, musicsum = 0;
                        string mudicsizedaxiao = "0";
                        int musicshu = BLL.MusicBLL.MusicSizeBLL(music).Tables[0].Rows.Count;
                        for (int i = 0; i < musicshu; i++)
                        {
                            mudicsizedaxiao = BLL.MusicBLL.MusicSizeBLL(music).Tables[0].Rows[i][0].ToString();
                            if (mudicsizedaxiao.IndexOf("MB") != -1)
                            {
                                if (mudicsizedaxiao.Substring(mudicsizedaxiao.LastIndexOf("M")) == "MB")
                                {
                                    string[] musicsArray = mudicsizedaxiao.Split('M');
                                    musiczhuan = double.Parse(musicsArray[0]);
                                }
                            }
                            if (mudicsizedaxiao.IndexOf("KB") != -1)
                            {
                                if (mudicsizedaxiao.Substring(mudicsizedaxiao.LastIndexOf("K")) == "KB")
                                {
                                    string[] musicsArray = mudicsizedaxiao.Split('K');
                                    musiczhuan = double.Parse(musicsArray[0]) / 1024;
                                }
                            }
                            if (mudicsizedaxiao.IndexOf("KB") == -1 && mudicsizedaxiao.IndexOf("MB") == -1)
                            {
                                if (mudicsizedaxiao.Substring(mudicsizedaxiao.LastIndexOf("B")) == "B")
                                {
                                    string[] musicsArray = mudicsizedaxiao.Split('B');
                                    musiczhuan = double.Parse(musicsArray[0]) / 1024 / 1024;
                                }
                            }


                            musicsum = musicsum + musiczhuan;
                        }
                        //Others表获取文件大小
                        Model.Others others = new Model.Others();
                        others.UserId = txt.UserId;
                        DataSet othersize = BLL.OthersBLL.OtherssizeBLL(others);
                        double otherzhuan = 0, othersum = 0;
                        string othersizedaxiao = "0";
                        int othershu = BLL.OthersBLL.OtherssizeBLL(others).Tables[0].Rows.Count;
                        for (int i = 0; i < othershu; i++)
                        {
                            othersizedaxiao = BLL.OthersBLL.OtherssizeBLL(others).Tables[0].Rows[i][0].ToString();
                            if (othersizedaxiao.IndexOf("KB") != -1)
                            {
                                if (othersizedaxiao.Substring(othersizedaxiao.LastIndexOf("K")) == "KB")
                                {
                                    string[] otherArray = othersizedaxiao.Split('K');
                                    otherzhuan = double.Parse(otherArray[0]) / 1024;
                                }
                            }
                            if (othersizedaxiao.IndexOf("MB") != -1)
                            {
                                if (othersizedaxiao.Substring(othersizedaxiao.LastIndexOf("M")) == "MB")
                                {
                                    string[] otherArray = othersizedaxiao.Split('M');
                                    otherzhuan = double.Parse(otherArray[0]);
                                }
                            }
                            if (othersizedaxiao.IndexOf("KB") == -1 && othersizedaxiao.IndexOf("MB") == -1)
                            {
                                if (othersizedaxiao.Substring(othersizedaxiao.LastIndexOf("B")) == "B")
                                {
                                    string[] otherArray = othersizedaxiao.Split('B');
                                    otherzhuan = double.Parse(otherArray[0]) / 1024 / 1024;
                                }
                            }

                            othersum = othersum + otherzhuan;
                        }
                        //photo表获取文件大小
                        Model.Photo photo = new Model.Photo();
                        photo.UserId = int.Parse(dss.Tables[0].Rows[0][0].ToString());
                        DataSet photosize = BLL.PhotoBLL.PhotoSizeBLL(photo);
                        double photozhuan = 0, photosum = 0;
                        string photosizedaxiao = "0";
                        int photoshu = BLL.PhotoBLL.PhotoSizeBLL(photo).Tables[0].Rows.Count;
                        for (int i = 0; i < photoshu; i++)
                        {
                            photosizedaxiao = BLL.PhotoBLL.PhotoSizeBLL(photo).Tables[0].Rows[i][0].ToString();
                            if (photosizedaxiao.IndexOf("KB") != -1)
                            {
                                if (photosizedaxiao.Substring(photosizedaxiao.LastIndexOf("K")) == "KB")
                                {
                                    string[] photoArray = photosizedaxiao.Split('K');
                                    photozhuan = double.Parse(photoArray[0]) / 1024;
                                }
                            }
                            if (photosizedaxiao.IndexOf("MB") != -1)
                            {
                                if (photosizedaxiao.Substring(photosizedaxiao.LastIndexOf("M")) == "MB")
                                {
                                    string[] photoArray = photosizedaxiao.Split('M');
                                    photozhuan = double.Parse(photoArray[0]);
                                }
                            }

                            if (photosizedaxiao.IndexOf("MB") == -1 && photosizedaxiao.IndexOf("KB") == -1)
                            {
                                if (photosizedaxiao.Substring(photosizedaxiao.LastIndexOf("B")) == "B")
                                {
                                    string[] photoArray = photosizedaxiao.Split('B');
                                    photozhuan = double.Parse(photoArray[0]) / 1024 / 1024;
                                }
                            }
                            photosum = photosum + photozhuan;
                        }



                        if (b == ".docx" || b == ".doc" || b == ".txt" || b == ".pptx" || b == ".ppt" || b == ".pdf" || b == ".rtf" || b == ".xls" || b == ".xlsx")
                        {
                            Model.Txt TxtInsert = new Model.Txt();
                            TxtInsert.TxtName = filename;
                            TxtInsert.TxtTime = DateTime.Now;
                            TxtInsert.TxtSize = filemb;
                            TxtInsert.TxtUrl = Server.MapPath(upload) + filename;
                            TxtInsert.UserId = int.Parse(ds.Tables[0].Rows[0][0].ToString());
                            int rows1 = 0, textzhuan = 0;
                            //if (TxtInsert.TxtSize.IndexOf("KB") != -1)
                            //{
                            //    string[] txtArray = TxtInsert.TxtSize.Split('K');
                            //    textzhuan = int.Parse(txtArray[0]) / 1024;
                            //}
                            //if (TxtInsert.TxtSize.IndexOf("MB") != -1)
                            //{
                            //    string[] txtArray = othersizedaxiao.Split('M');
                            //    textzhuan = int.Parse(txtArray[0]);
                            //}

                            //if (TxtInsert.TxtSize.IndexOf("MB") == -1 && TxtInsert.TxtSize.IndexOf("KB") == -1)
                            //{
                            //    string[] txtArray = othersizedaxiao.Split('B');
                            //    textzhuan = int.Parse(txtArray[0]) / 1024 / 1024;
                            //}
                            //int a = 0;
                            if (int.Parse(BLL.UsersBLL.SelidBLL(users).Tables[0].Rows[0][1].ToString()) == 1)
                            {
                                int chuang = int.Parse(FileUpload1.PostedFile.ContentLength.ToString()) / 1024 / 1024;
                                if (Math.Round(musicsum + tetsum + othersum + photosum, 2) + chuang < 100)
                                {
                                    rows1 = BLL.TxtBLL.TxtInsertBLL(TxtInsert);//上传添加
                                    Model.Txt TxtSelect = new Model.Txt();
                                    TxtSelect.UserId = int.Parse(ds.Tables[0].Rows[0][0].ToString());
                                    GridView4.DataSource = BLL.TxtBLL.SelectBLL(TxtSelect);
                                    GridView4.DataBind();//文档刷新
                                    if (rows1 > 0)
                                    {
                                        Response.Write("<script>alert('上传成功！')</script>");
                                    }
                                }
                                else
                                {
                                    Response.Write("<script>alert('您的剩余容量已达上线，无法上传')</script>");
                                }
                            }
                            else if (int.Parse(BLL.UsersBLL.SelidBLL(users).Tables[0].Rows[0][1].ToString()) == 0)
                            {
                                int chuang = int.Parse(FileUpload1.PostedFile.ContentLength.ToString()) / 1024 / 1024;
                                if (Math.Round(musicsum + tetsum + othersum + photosum, 2) + chuang < 50)
                                {
                                    rows1 = BLL.TxtBLL.TxtInsertBLL(TxtInsert);//上传添加
                                    Model.Txt TxtSelect = new Model.Txt();
                                    TxtSelect.UserId = int.Parse(ds.Tables[0].Rows[0][0].ToString());
                                    GridView4.DataSource = BLL.TxtBLL.SelectBLL(TxtSelect);
                                    GridView4.DataBind();//文档刷新
                                    if (rows1 > 0)
                                    {
                                        Response.Write("<script>alert('上传成功！')</script>");
                                    }
                                }
                                else
                                {
                                    Response.Write("<script>alert('您的剩余容量不足，请充值VIP')</script>");
                                }
                            }

                        }
                        else if (b == ".jpg" || b == ".gif" || b == ".psd" || b == ".png" || b == ".jpeg" || b == ".bmp")
                        {
                            FileUpload1.SaveAs(Server.MapPath("~/aFile/") + filename);
                            Model.Photo PhotoInsert = new Model.Photo();
                            PhotoInsert.PhotoName = filename;
                            PhotoInsert.PhotoTime = DateTime.Now;
                            PhotoInsert.PhotoSize = filemb;
                            PhotoInsert.PhotoUrl = Server.MapPath(upload) + filename;
                            PhotoInsert.UserId = int.Parse(ds.Tables[0].Rows[0][0].ToString());
                            int rows1 = 0; double Photozhuan = 0;
                            //if (PhotoInsert.PhotoSize.IndexOf("KB") != -1)
                            //{
                            //    string[] txtArray = PhotoInsert.PhotoSize.Split('K');
                            //    Photozhuan = int.Parse(txtArray[0]) / 1024;
                            //}
                            //if (PhotoInsert.PhotoSize.IndexOf("MB") != -1)
                            //{
                            //    string[] txtArray = othersizedaxiao.Split('M');
                            //    Photozhuan = int.Parse(txtArray[0]);
                            //}

                            //if (PhotoInsert.PhotoSize.IndexOf("MB") == -1 && PhotoInsert.PhotoSize.IndexOf("KB") == -1)
                            //{
                            //    string[] txtArray = othersizedaxiao.Split('B');
                            //    Photozhuan = int.Parse(txtArray[0]) / 1024 / 1024;
                            //}
                            if (int.Parse(BLL.UsersBLL.SelidBLL(users).Tables[0].Rows[0][1].ToString()) == 1)
                            {
                                int chuang = int.Parse(FileUpload1.PostedFile.ContentLength.ToString()) / 1024 / 1024;
                                if (Math.Round(musicsum + tetsum + othersum + photosum, 2) + chuang < 100)
                                {
                                    rows1 = BLL.PhotoBLL.PhotoInsertBLL(PhotoInsert);//上传添加
                                    Model.Photo PhotoSelect = new Model.Photo();
                                    PhotoSelect.UserId = int.Parse(ds.Tables[0].Rows[0][0].ToString());
                                    GridView3.DataSource = BLL.PhotoBLL.SelectBLL(PhotoSelect);
                                    GridView3.DataBind();//图片刷新
                                    if (rows1 > 0)
                                    {
                                        Response.Write("<script>alert('上传成功！')</script>");
                                    }
                                }
                                else
                                {
                                    Response.Write("<script>alert('您的剩余容量已达上线，无法上传')</script>");
                                }
                            }
                            else if (int.Parse(BLL.UsersBLL.SelidBLL(users).Tables[0].Rows[0][1].ToString()) == 0)
                            {
                                int chuang = int.Parse(FileUpload1.PostedFile.ContentLength.ToString()) / 1024 / 1024;
                                if (Math.Round(musicsum + tetsum + othersum + photosum, 2) + chuang < 50)
                                {
                                    rows1 = BLL.PhotoBLL.PhotoInsertBLL(PhotoInsert);//上传添加
                                    Model.Photo PhotoSelect = new Model.Photo();
                                    PhotoSelect.UserId = int.Parse(ds.Tables[0].Rows[0][0].ToString());
                                    GridView3.DataSource = BLL.PhotoBLL.SelectBLL(PhotoSelect);
                                    GridView3.DataBind();//图片刷新
                                    if (rows1 > 0)
                                    {
                                        Response.Write("<script>alert('上传成功！')</script>");
                                    }
                                }
                                else
                                {
                                    Response.Write("<script>alert('您的剩余容量不足，请充值VIP！')</script>");
                                }
                            }

                        }
                        else if (b == ".mp3" || b == ".mgg" || b == ".wma" || b == ".cd")
                        {
                            Model.Music MusicInsert = new Model.Music();
                            MusicInsert.MusicName = filename;
                            MusicInsert.MusicTime = DateTime.Now;
                            MusicInsert.MusicSize = filemb;
                            MusicInsert.MusicUrl = Server.MapPath(upload) + filename;
                            MusicInsert.UserId = int.Parse(ds.Tables[0].Rows[0][0].ToString());
                            int rows1 = 0;
                            //if (MusicInsert.MusicSize.IndexOf("KB") != -1)
                            //{
                            //    string[] txtArray = MusicInsert.MusicSize.Split('K');
                            //    musiczhuan = double.Parse(txtArray[0]) / 1024;
                            //}
                            //if (MusicInsert.MusicSize.IndexOf("MB") != -1)
                            //{
                            //    string[] txtArray = othersizedaxiao.Split('M');
                            //    musiczhuan = double.Parse(txtArray[0]);
                            //}

                            //if (MusicInsert.MusicSize.IndexOf("MB") == -1 && MusicInsert.MusicSize.IndexOf("KB") == -1)
                            //{
                            //    string[] txtArray = othersizedaxiao.Split('B');
                            //    musiczhuan = double.Parse(txtArray[0]) / 1024 / 1024;
                            //}
                            if (int.Parse(BLL.UsersBLL.SelidBLL(users).Tables[0].Rows[0][1].ToString()) == 1)
                            {
                                int chuang = int.Parse(FileUpload1.PostedFile.ContentLength.ToString()) / 1024 / 1024;
                                if (Math.Round(musicsum + tetsum + othersum + photosum, 2) + chuang < 100)
                                {
                                    rows1 = BLL.MusicBLL.MusicInsertBLL(MusicInsert);//上传添加
                                    Model.Music MusicSelect = new Model.Music();
                                    MusicSelect.UserId = int.Parse(ds.Tables[0].Rows[0][0].ToString());
                                    GridView2.DataSource = BLL.MusicBLL.SelectBLL(MusicSelect);
                                    GridView2.DataBind();
                                    if (rows1 > 0)
                                    {
                                        Response.Write("<script>alert('上传成功！')</script>");
                                    }
                                }
                                else
                                {
                                    Response.Write("<script>alert('您的剩余容量已达上线，无法上传')</script>");
                                }
                            }
                            else if (int.Parse(BLL.UsersBLL.SelidBLL(users).Tables[0].Rows[0][1].ToString()) == 0)
                            {
                                int chuang = int.Parse(FileUpload1.PostedFile.ContentLength.ToString()) / 1024 / 1024;
                                if (Math.Round(musicsum + tetsum + othersum + photosum, 2) + chuang < 50)
                                {
                                    rows1 = BLL.MusicBLL.MusicInsertBLL(MusicInsert);//上传添加
                                    Model.Music MusicSelect = new Model.Music();
                                    MusicSelect.UserId = int.Parse(ds.Tables[0].Rows[0][0].ToString());
                                    GridView2.DataSource = BLL.MusicBLL.SelectBLL(MusicSelect);
                                    GridView2.DataBind();
                                    if (rows1 > 0)
                                    {
                                        Response.Write("<script>alert('上传成功！')</script>");
                                    }
                                }
                                else
                                {
                                    Response.Write("<script>alert('您的剩余容量不足，请充值VIP！')</script>");
                                }
                            }



                        }
                        else
                        {
                            Model.Others OthersInsert = new Model.Others();
                            OthersInsert.OthersName = filename;
                            OthersInsert.OthersTime = DateTime.Now;
                            OthersInsert.OthersSize = filemb;
                            OthersInsert.OthersUrl = Server.MapPath(upload) + filename;
                            OthersInsert.UserId = int.Parse(ds.Tables[0].Rows[0][0].ToString());
                            int rows1 = 0;
                            //if (OthersInsert.OthersSize.IndexOf("KB") != -1)
                            //{
                            //    string[] txtArray = OthersInsert.OthersSize.Split('K');
                            //    otherzhuan = double.Parse(txtArray[0]) / 1024;
                            //}
                            //if (OthersInsert.OthersSize.IndexOf("MB") != -1)
                            //{
                            //    string[] txtArray = othersizedaxiao.Split('M');
                            //    otherzhuan = double.Parse(txtArray[0]);
                            //}

                            //if (OthersInsert.OthersSize.IndexOf("MB") == -1 && OthersInsert.OthersSize.IndexOf("KB") == -1)
                            //{
                            //    string[] txtArray = othersizedaxiao.Split('B');
                            //    otherzhuan = double.Parse(txtArray[0]) / 1024 / 1024;
                            //}
                            if (int.Parse(BLL.UsersBLL.SelidBLL(users).Tables[0].Rows[0][1].ToString()) == 1)
                            {
                                int chuang = int.Parse(FileUpload1.PostedFile.ContentLength.ToString()) / 1024 / 1024;
                                if (Math.Round(musicsum + tetsum + othersum + photosum, 2) + chuang < 100)
                                {
                                    rows1 = BLL.OthersBLL.OthersInsertBLL(OthersInsert);//上传添加
                                    if (rows1 > 0)
                                    {
                                        Response.Write("<script>alert('上传成功！')</script>");
                                    }
                                }

                                else
                                {
                                    Response.Write("<script>alert('您的剩余容量已达上线，无法上传')</script>");

                                }
                            }
                            else if (int.Parse(BLL.UsersBLL.SelidBLL(users).Tables[0].Rows[0][1].ToString()) == 0)
                            {
                                int chuang = int.Parse(FileUpload1.PostedFile.ContentLength.ToString()) / 1024 / 1024;
                                if (Math.Round(musicsum + tetsum + othersum + photosum, 2) + chuang < 50)
                                {
                                    rows1 = BLL.OthersBLL.OthersInsertBLL(OthersInsert);//上传添加
                                    if (rows1 > 0)
                                    {
                                        Response.Write("<script>alert('上传成功！')</script>");
                                    }
                                }

                                else
                                {
                                    Response.Write("<script>alert('您的剩余容量不足，请充值VIP！')</script>");

                                }
                            }
                            Model.Others OthersSelect = new Model.Others();
                            OthersSelect.UserId = int.Parse(ds.Tables[0].Rows[0][0].ToString());
                            GridView1.DataSource = BLL.OthersBLL.SelectIdBLL(OthersSelect);
                            GridView1.DataBind();
                        }
                    }
                }
                else
                {
                    Response.Write("<script>alert('此文件已存在！')</script>");
                }

            }
            //刷新内存大小
            if (Session["Name"] != null)
            {
                Label2.Text = Session["Name"].ToString();
                Model.Users SelectIdUsers = new Model.Users();
                SelectIdUsers.Username = Session["Name"].ToString();
                DataSet dss = BLL.UsersBLL.SelectIdBLL(SelectIdUsers);
                //判断是否为vip实现充值
                Model.Users users = new Model.Users();
                users.Username = Session["Name"].ToString();
                DataSet dsisvip = BLL.UsersBLL.SelidBLL(users);
                int isvip = int.Parse(dsisvip.Tables[0].Rows[0][1].ToString());
                if (isvip == 0)
                {
                    Label5.Text = "/50MB";
                }
                Model.Txt txt = new Model.Txt();
                txt.UserId = int.Parse(dss.Tables[0].Rows[0][0].ToString());
                //txt表获取文件大小
                DataSet txtsize = BLL.TxtBLL.TxtSizeBLL(txt);
                //txt最终内存大小
                double txtzhuan = 0, tetsum = 0;
                string txtsizedaxiao = "0";
                for (int i = 0; i < BLL.TxtBLL.TxtSizeBLL(txt).Tables[0].Rows.Count; i++)
                {
                    txtsizedaxiao = BLL.TxtBLL.TxtSizeBLL(txt).Tables[0].Rows[i][0].ToString();
                    if (txtsizedaxiao.IndexOf("KB") != -1)
                    {
                        if (txtsizedaxiao.Substring(txtsizedaxiao.LastIndexOf("K")) == "KB")
                        {
                            string[] txtsArray = txtsizedaxiao.Split('K');
                            txtzhuan = double.Parse(txtsArray[0]) / 1024;
                        }
                    }
                    if (txtsizedaxiao.IndexOf("KB") == -1 && txtsizedaxiao.IndexOf("MB") == -1)
                    {
                        if (txtsizedaxiao.Substring(txtsizedaxiao.LastIndexOf("B")) == "B")
                        {
                            string[] txtsArray = txtsizedaxiao.Split('B');
                            txtzhuan = double.Parse(txtsArray[0]) / 1024 / 1024;
                        }
                    }
                    if (txtsizedaxiao.IndexOf("MB") != -1)
                    {
                        if (txtsizedaxiao.Substring(txtsizedaxiao.LastIndexOf("M")) == "MB")
                        {
                            string[] txtsArray = txtsizedaxiao.Split('M');
                            txtzhuan = double.Parse(txtsArray[0]);
                        }
                    }

                    tetsum = tetsum + txtzhuan;

                }
                Model.Music music = new Model.Music();
                music.MusicId = txt.UserId;
                //Music表获取文件大小
                DataSet Musicsize = BLL.MusicBLL.MusicSizeBLL(music);
                //Music最终内存大小
                double musiczhuan = 0, musicsum = 0;
                string mudicsizedaxiao = "0";
                int musicshu = BLL.MusicBLL.MusicSizeBLL(music).Tables[0].Rows.Count;
                for (int i = 0; i < musicshu; i++)
                {
                    mudicsizedaxiao = BLL.MusicBLL.MusicSizeBLL(music).Tables[0].Rows[i][0].ToString();
                    if (mudicsizedaxiao.IndexOf("MB") != -1)
                    {
                        if (mudicsizedaxiao.Substring(mudicsizedaxiao.LastIndexOf("M")) == "MB")
                        {
                            string[] musicsArray = mudicsizedaxiao.Split('M');
                            musiczhuan = double.Parse(musicsArray[0]);
                        }
                    }
                    if (mudicsizedaxiao.IndexOf("KB") != -1)
                    {
                        if (mudicsizedaxiao.Substring(mudicsizedaxiao.LastIndexOf("K")) == "KB")
                        {
                            string[] musicsArray = mudicsizedaxiao.Split('K');
                            musiczhuan = double.Parse(musicsArray[0]) / 1024;
                        }
                    }
                    if (mudicsizedaxiao.IndexOf("KB") == -1 && mudicsizedaxiao.IndexOf("MB") == -1)
                    {
                        if (mudicsizedaxiao.Substring(mudicsizedaxiao.LastIndexOf("B")) == "B")
                        {
                            string[] musicsArray = mudicsizedaxiao.Split('B');
                            musiczhuan = double.Parse(musicsArray[0]) / 1024 / 1024;
                        }
                    }


                    musicsum = musicsum + musiczhuan;
                }
                //Others表获取文件大小
                Model.Others others = new Model.Others();
                others.UserId = txt.UserId;
                DataSet othersize = BLL.OthersBLL.OtherssizeBLL(others);
                double otherzhuan = 0, othersum = 0;
                string othersizedaxiao = "0";
                int othershu = BLL.OthersBLL.OtherssizeBLL(others).Tables[0].Rows.Count;
                for (int i = 0; i < othershu; i++)
                {
                    othersizedaxiao = BLL.OthersBLL.OtherssizeBLL(others).Tables[0].Rows[i][0].ToString();
                    if (othersizedaxiao.IndexOf("KB") != -1)
                    {
                        if (othersizedaxiao.Substring(othersizedaxiao.LastIndexOf("K")) == "KB")
                        {
                            string[] otherArray = othersizedaxiao.Split('K');
                            otherzhuan = double.Parse(otherArray[0]) / 1024;
                        }
                    }
                    if (othersizedaxiao.IndexOf("MB") != -1)
                    {
                        if (othersizedaxiao.Substring(othersizedaxiao.LastIndexOf("M")) == "MB")
                        {
                            string[] otherArray = othersizedaxiao.Split('M');
                            otherzhuan = double.Parse(otherArray[0]);
                        }
                    }
                    if (othersizedaxiao.IndexOf("KB") == -1 && othersizedaxiao.IndexOf("MB") == -1)
                    {
                        if (othersizedaxiao.Substring(othersizedaxiao.LastIndexOf("B")) == "B")
                        {
                            string[] otherArray = othersizedaxiao.Split('B');
                            otherzhuan = double.Parse(otherArray[0]) / 1024 / 1024;
                        }
                    }

                    othersum = othersum + otherzhuan;
                }
                //photo表获取文件大小
                Model.Photo photo = new Model.Photo();
                photo.UserId = int.Parse(dss.Tables[0].Rows[0][0].ToString());
                DataSet photosize = BLL.PhotoBLL.PhotoSizeBLL(photo);
                double photozhuan = 0, photosum = 0;
                string photosizedaxiao = "0";
                int photoshu = BLL.PhotoBLL.PhotoSizeBLL(photo).Tables[0].Rows.Count;
                for (int i = 0; i < photoshu; i++)
                {
                    photosizedaxiao = BLL.PhotoBLL.PhotoSizeBLL(photo).Tables[0].Rows[i][0].ToString();
                    if (photosizedaxiao.IndexOf("KB") != -1)
                    {
                        if (photosizedaxiao.Substring(photosizedaxiao.LastIndexOf("K")) == "KB")
                        {
                            string[] photoArray = photosizedaxiao.Split('K');
                            photozhuan = double.Parse(photoArray[0]) / 1024;

                        }
                    }
                    if (photosizedaxiao.IndexOf("MB") != -1)
                    {
                        if (photosizedaxiao.Substring(photosizedaxiao.LastIndexOf("M")) == "MB")
                        {
                            string[] photoArray = photosizedaxiao.Split('M');
                            photozhuan = double.Parse(photoArray[0]);
                        }
                    }

                    if (photosizedaxiao.IndexOf("MB") == -1 && photosizedaxiao.IndexOf("KB") == -1)
                    {
                        if (photosizedaxiao.Substring(photosizedaxiao.LastIndexOf("B")) == "B")
                        {
                            string[] photoArray = photosizedaxiao.Split('B');
                            photozhuan = double.Parse(photoArray[0]) / 1024 / 1024;
                        }
                    }
                    photosum = photosum + photozhuan;
                }
                Label3.Text = Math.Round(musicsum + tetsum + othersum + photosum, 2) + "MB".ToString();
                HiddenField1.Value = Math.Round(musicsum + tetsum + othersum + photosum, 2).ToString();
            }
        }//上传
        //退出登录
        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/index.aspx");

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Button7.Visible = true;
            FileUpload1.Visible = true;
            Label4.Visible = false;
            GridView4.Visible = true;
            GridView3.Visible = false;
            GridView2.Visible = false;
            GridView1.Visible = false;
            GridView5.Visible = false;

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Button7.Visible = true;
            FileUpload1.Visible = true;
            Label4.Visible = false;
            GridView4.Visible = false;
            GridView3.Visible = true;
            GridView2.Visible = false;
            GridView1.Visible = false;
            GridView5.Visible = false;
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Button7.Visible = true;
            FileUpload1.Visible = true;
            Label4.Visible = false;
            GridView4.Visible = false;
            GridView3.Visible = false;
            GridView2.Visible = true;
            GridView1.Visible = false;
            GridView5.Visible = false;
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Button7.Visible = true;
            FileUpload1.Visible = true;
            Label4.Visible = false;
            GridView4.Visible = false;
            GridView3.Visible = false;
            GridView2.Visible = false;
            GridView1.Visible = true;
            GridView5.Visible = false;
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            Button7.Visible = false;
            GridView4.Visible = false;
            GridView3.Visible = false;
            GridView2.Visible = false;
            GridView1.Visible = false;
            GridView5.Visible = true;
            FileUpload1.Visible = false;
            Model.Users SelectIdUsers = new Model.Users();
            SelectIdUsers.Username = Session["Name"].ToString();
            DataSet ds = BLL.UsersBLL.SelectIdBLL(SelectIdUsers);
            Model.Recoverys RecoverySelectId = new Model.Recoverys();
            RecoverySelectId.UserId = int.Parse(ds.Tables[0].Rows[0][0].ToString());
            GridView5.DataSource = BLL.RecoverysBLL.SelectBLL(RecoverySelectId);
            GridView5.DataBind();
            DataSet hui = BLL.RecoverysBLL.SelectBLL(RecoverySelectId);
            if (hui.Tables[0].Rows.Count == 0)
            {
                Label4.Visible = true;
            }
            else
            {
                Label4.Visible = false;
            }
        }
        //文档下载
        protected void LinkButton2_Click1(object sender, EventArgs e)
        {
            Model.Txt TxtSel = new Model.Txt();
            TxtSel.TxtId = int.Parse(((LinkButton)sender).CommandArgument);
            DataSet ds = BLL.TxtBLL.TxtSelectByIdBLL(TxtSel);
            string filename = ds.Tables[0].Rows[0][1].ToString().ToString();
            string fileurl = ds.Tables[0].Rows[0][5].ToString();
            FileInfo fileinfo = new FileInfo(fileurl);
            Response.Clear();
            Response.ClearContent();
            Response.ClearHeaders();
            Response.AddHeader("Content-Disposition", "attachment;filename=" + filename);
            Response.AddHeader("Content-Length", fileinfo.Length.ToString());
            Response.AddHeader("Content-Transfer-Encoding", "binary");
            Response.ContentType = "application/octet-stream";
            Response.ContentEncoding = System.Text.Encoding.GetEncoding("gb2312");
            Response.WriteFile(fileinfo.FullName);
            Response.Flush();
            Response.End();

        }
        //图片下载
        protected void LinkButton2_Click2(object sender, EventArgs e)
        {
            Model.Photo PhotoSel = new Model.Photo();
            PhotoSel.PhotoId = int.Parse(((LinkButton)sender).CommandArgument);
            DataSet ds = BLL.PhotoBLL.PhotoSelectByIdBLL(PhotoSel);
            string filename = ds.Tables[0].Rows[0][1].ToString();
            string fileurl = ds.Tables[0].Rows[0][5].ToString();
            FileInfo fileinfo = new FileInfo(fileurl);
            Response.Clear();
            Response.ClearContent();
            Response.ClearHeaders();
            Response.AddHeader("Content-Disposition", "attachment;filename=" + filename);
            Response.AddHeader("Content-Length", fileinfo.Length.ToString());
            Response.AddHeader("Content-Transfer-Encoding", "binary");
            Response.ContentType = "application/octet-stream";
            Response.ContentEncoding = System.Text.Encoding.GetEncoding("gb2312");
            Response.WriteFile(fileinfo.FullName);
            Response.Flush();
            Response.End();

        }
        //音频下载
        protected void LinkButton2_Click3(object sender, EventArgs e)
        {
            Model.Music MusicSel = new Model.Music();
            MusicSel.MusicId = int.Parse(((LinkButton)sender).CommandArgument);
            DataSet ds = BLL.MusicBLL.MusicSelectByIdBLL(MusicSel);
            string filename = ds.Tables[0].Rows[0][1].ToString();
            string fileurl = ds.Tables[0].Rows[0][5].ToString();
            FileInfo fileinfo = new FileInfo(fileurl);
            Response.Clear();
            Response.ClearContent();
            Response.ClearHeaders();
            Response.AddHeader("Content-Disposition", "attachment;filename=" + filename);
            Response.AddHeader("Content-Length", fileinfo.Length.ToString());
            Response.AddHeader("Content-Transfer-Encoding", "binary");
            Response.ContentType = "application/octet-stream";
            Response.ContentEncoding = System.Text.Encoding.GetEncoding("gb2312");
            Response.WriteFile(fileinfo.FullName);
            Response.Flush();
            Response.End();
        }
        //其他下载
        protected void LinkButton2_Click4(object sender, EventArgs e)
        {
            Model.Others OthersSel = new Model.Others();
            OthersSel.OthersId = int.Parse(((LinkButton)sender).CommandArgument);
            DataSet ds = BLL.OthersBLL.OthersSelectByIdBLL(OthersSel);
            string filename = ds.Tables[0].Rows[0][1].ToString();
            string fileurl = ds.Tables[0].Rows[0][5].ToString();
            FileInfo fileinfo = new FileInfo(fileurl);
            Response.Clear();
            Response.ClearContent();
            Response.ClearHeaders();
            Response.AddHeader("Content-Disposition", "attachment;filename=" + filename);
            Response.AddHeader("Content-Length", fileinfo.Length.ToString());
            Response.AddHeader("Content-Transfer-Encoding", "binary");
            Response.ContentType = "application/octet-stream";
            Response.ContentEncoding = System.Text.Encoding.GetEncoding("gb2312");
            Response.WriteFile(fileinfo.FullName);
            Response.Flush();
            Response.End();
        }

        protected void LinkButton2_Click5(object sender, EventArgs e)
        {
            if (Session["Name"] != null)
            {

                Model.Users SelectIdUsers = new Model.Users();
                SelectIdUsers.Username = Session["Name"].ToString();
                DataSet ds = BLL.UsersBLL.SelectIdBLL(SelectIdUsers);
                Model.Users us = new Model.Users();
                us.UserId = int.Parse(ds.Tables[0].Rows[0][0].ToString());
                if (BLL.UsersBLL.UsersUpISVIPBLL(us) > 0)
                {
                    Response.Write("<script>alert('成功注册为VIP！')</script>");
                }
                //判断是否为vip实现充值
                Model.Users users = new Model.Users();
                users.Username = Session["Name"].ToString();
                DataSet dsisvip = BLL.UsersBLL.SelidBLL(users);
                int isvip = int.Parse(dsisvip.Tables[0].Rows[0][1].ToString());
                if (isvip == 0)
                {
                    Label5.Text = "/50MB";
                }
                else
                {
                    Label5.Text = "/100MB";
                }
                Model.Txt txt = new Model.Txt();
                txt.UserId = int.Parse(ds.Tables[0].Rows[0][0].ToString());
                //txt表获取文件大小
                DataSet txtsize = BLL.TxtBLL.TxtSizeBLL(txt);
                //txt最终内存大小
                double txtzhuan = 0, tetsum = 0;
                string txtsizedaxiao = "0";
                for (int i = 0; i < BLL.TxtBLL.TxtSizeBLL(txt).Tables[0].Rows.Count; i++)
                {
                    txtsizedaxiao = BLL.TxtBLL.TxtSizeBLL(txt).Tables[0].Rows[i][0].ToString();
                    if (txtsizedaxiao.IndexOf("KB") != -1)
                    {
                        if (txtsizedaxiao.Substring(txtsizedaxiao.LastIndexOf("K")) == "KB")
                        {
                            string[] txtsArray = txtsizedaxiao.Split('K');
                            txtzhuan = double.Parse(txtsArray[0]) / 1024;
                        }
                    }
                    if (txtsizedaxiao.IndexOf("KB") == -1 && txtsizedaxiao.IndexOf("MB") == -1)
                    {
                        if (txtsizedaxiao.Substring(txtsizedaxiao.LastIndexOf("B")) == "B")
                        {
                            string[] txtsArray = txtsizedaxiao.Split('B');
                            txtzhuan = double.Parse(txtsArray[0]) / 1024 / 1024;
                        }
                    }
                    if (txtsizedaxiao.IndexOf("MB") != -1)
                    {
                        if (txtsizedaxiao.Substring(txtsizedaxiao.LastIndexOf("M")) == "MB")
                        {
                            string[] txtsArray = txtsizedaxiao.Split('M');
                            txtzhuan = double.Parse(txtsArray[0]);
                        }
                    }

                    tetsum = tetsum + txtzhuan;

                }
                Model.Music music = new Model.Music();
                music.MusicId = txt.UserId;
                //Music表获取文件大小
                DataSet Musicsize = BLL.MusicBLL.MusicSizeBLL(music);
                //Music最终内存大小
                double musiczhuan = 0, musicsum = 0;
                string mudicsizedaxiao = "0";
                int musicshu = BLL.MusicBLL.MusicSizeBLL(music).Tables[0].Rows.Count;
                for (int i = 0; i < musicshu; i++)
                {
                    mudicsizedaxiao = BLL.MusicBLL.MusicSizeBLL(music).Tables[0].Rows[i][0].ToString();
                    if (mudicsizedaxiao.IndexOf("MB") != -1)
                    {
                        if (mudicsizedaxiao.Substring(mudicsizedaxiao.LastIndexOf("M")) == "MB")
                        {
                            string[] musicsArray = mudicsizedaxiao.Split('M');
                            musiczhuan = double.Parse(musicsArray[0]);
                        }
                    }
                    if (mudicsizedaxiao.IndexOf("KB") != -1)
                    {
                        if (mudicsizedaxiao.Substring(mudicsizedaxiao.LastIndexOf("K")) == "KB")
                        {
                            string[] musicsArray = mudicsizedaxiao.Split('K');
                            musiczhuan = double.Parse(musicsArray[0]) / 1024;
                        }
                    }
                    if (mudicsizedaxiao.IndexOf("KB") == -1 && mudicsizedaxiao.IndexOf("MB") == -1)
                    {
                        if (mudicsizedaxiao.Substring(mudicsizedaxiao.LastIndexOf("B")) == "B")
                        {
                            string[] musicsArray = mudicsizedaxiao.Split('B');
                            musiczhuan = double.Parse(musicsArray[0]) / 1024 / 1024;
                        }
                    }


                    musicsum = musicsum + musiczhuan;
                }
                //Others表获取文件大小
                Model.Others others = new Model.Others();
                others.UserId = txt.UserId;
                DataSet othersize = BLL.OthersBLL.OtherssizeBLL(others);
                double otherzhuan = 0, othersum = 0;
                string othersizedaxiao = "0";
                int othershu = BLL.OthersBLL.OtherssizeBLL(others).Tables[0].Rows.Count;
                for (int i = 0; i < othershu; i++)
                {
                    othersizedaxiao = BLL.OthersBLL.OtherssizeBLL(others).Tables[0].Rows[i][0].ToString();
                    if (othersizedaxiao.IndexOf("KB") != -1)
                    {
                        if (othersizedaxiao.Substring(othersizedaxiao.LastIndexOf("K")) == "KB")
                        {
                            string[] otherArray = othersizedaxiao.Split('K');
                            otherzhuan = double.Parse(otherArray[0]) / 1024;
                        }
                    }
                    if (othersizedaxiao.IndexOf("MB") != -1)
                    {
                        if (othersizedaxiao.Substring(othersizedaxiao.LastIndexOf("M")) == "MB")
                        {
                            string[] otherArray = othersizedaxiao.Split('M');
                            otherzhuan = double.Parse(otherArray[0]);
                        }
                    }
                    if (othersizedaxiao.IndexOf("KB") == -1 && othersizedaxiao.IndexOf("MB") == -1)
                    {
                        if (othersizedaxiao.Substring(othersizedaxiao.LastIndexOf("B")) == "B")
                        {
                            string[] otherArray = othersizedaxiao.Split('B');
                            otherzhuan = double.Parse(otherArray[0]) / 1024 / 1024;
                        }
                    }

                    othersum = othersum + otherzhuan;
                }
                //photo表获取文件大小
                Model.Photo photo = new Model.Photo();
                photo.UserId = txt.UserId;
                DataSet photosize = BLL.PhotoBLL.PhotoSizeBLL(photo);
                double photozhuan = 0, photosum = 0;
                string photosizedaxiao = "0";
                int photoshu = BLL.PhotoBLL.PhotoSizeBLL(photo).Tables[0].Rows.Count;
                for (int i = 0; i < photoshu; i++)
                {
                    photosizedaxiao = BLL.PhotoBLL.PhotoSizeBLL(photo).Tables[0].Rows[i][0].ToString();
                    if (photosizedaxiao.IndexOf("KB") != -1)
                    {
                        if (photosizedaxiao.Substring(photosizedaxiao.LastIndexOf("K")) == "KB")
                        {
                            string[] photoArray = photosizedaxiao.Split('K');
                            photozhuan = double.Parse(photoArray[0]) / 1024;

                        }
                    }
                    if (photosizedaxiao.IndexOf("MB") != -1)
                    {
                        if (photosizedaxiao.Substring(photosizedaxiao.LastIndexOf("M")) == "MB")
                        {
                            string[] photoArray = photosizedaxiao.Split('M');
                            photozhuan = double.Parse(photoArray[0]);
                        }
                    }

                    if (photosizedaxiao.IndexOf("MB") == -1 && photosizedaxiao.IndexOf("KB") == -1)
                    {
                        if (photosizedaxiao.Substring(photosizedaxiao.LastIndexOf("B")) == "B")
                        {
                            string[] photoArray = photosizedaxiao.Split('B');
                            photozhuan = double.Parse(photoArray[0]) / 1024 / 1024;
                        }
                    }


                    photosum = photosum + photozhuan;
                }
                Label3.Text = Math.Round(musicsum + tetsum + othersum + photosum, 2) + "MB".ToString();
                HiddenField1.Value = Math.Round(musicsum + tetsum + othersum + photosum, 2).ToString();
            }
        }
        //查看Photo
        protected void LinkButton3_Click2(object sender, EventArgs e)
        {

            string id = (((LinkButton)sender).CommandArgument).ToString();
            Session["Photoid"] = id;//图片id
            Response.Redirect("~/kehu/WebForm1.aspx");

        }
        //查看音乐
        protected void LinkButton3_Click3(object sender, EventArgs e)
        {
            string id = (((LinkButton)sender).CommandArgument).ToString();
            Session["Musicid"] = id;//图片id
            // Response.Write("<script>alert('下载后浏览器打开') </script>");
            Response.Redirect("~/kehu/WebForm1.aspx");
        }
        //查看其他
        protected void LinkButton3_Click4(object sender, EventArgs e)
        {
            string id = (((LinkButton)sender).CommandArgument).ToString();
            Session["Othersid"] = id;//其他id
            Response.Write("<script>alert('下载后浏览器打开') </script>");
            // Response.Redirect("~/kehu/WebForm1.aspx");
        }

        protected void LinkButton3_Click1(object sender, EventArgs e)
        {
            string id = (((LinkButton)sender).CommandArgument).ToString();
            Session["Txtid"] = id;

            //HttpCookie cookie = new HttpCookie("TxtUrl");
            //cookie.Values.Add("url",url);
            //cookie.Expires = DateTime.MaxValue;
            //Response.Cookies.Add(cookie);
            Response.Redirect("~/kehu/WebForm1.aspx");
        }

    }

}
