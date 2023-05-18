using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;


namespace 狗屁网盘.kehu
{
   
    public partial class WebForm1 : System.Web.UI.Page
    {
        //public static string geturl(string urlName)
        //{
        //    return urlName;
        //}
        
        
        protected void Page_Load(object sender, EventArgs e)
        {
           // Server.Execute("WebForm1.aspx");
             if (!IsPostBack)
            {
                if (Session["Txtid"]!=null)
                {
                    Model.Txt TxTid = new Model.Txt();
                    TxTid.TxtId = int.Parse((Session["Txtid"]).ToString());
                    DataSet ds = BLL.TxtBLL.TxtSelectByIdBLL(TxTid);
                    string url = ds.Tables[0].Rows[0][5].ToString();
               
                  StreamReader sr = File.OpenText(url);
                  while (sr.Peek()!=-1)
                  {
                      Response.Write(sr.ReadLine()+"<br/>");
                  }
                  sr.Close();
                  Session["Txtid"] = null;
                }
                if (Session["Photoid"]!=null)
                {
                    Model.Photo Photo=new Model.Photo ();
                    Photo.PhotoId = int.Parse(Session["Photoid"].ToString());
                    DataSet ds = BLL.PhotoBLL.PhotoSelectByIdBLL(Photo);
                    string url = ds.Tables[0].Rows[0][5].ToString();
                    string name = ds.Tables[0].Rows[0][1].ToString();
                    string lastname = Path.GetExtension(name).ToLower();
                  
                    Image1.ImageUrl = "~/aFile/"+ name;
                    Session["Photoid"] = null;
    }  
                    
                    
                }
             if (Session["Musicid"] != null)
             {
                 Model.Music Music = new Model.Music();
                 Music.MusicId = int.Parse(Session["Musicid"].ToString());
                 DataSet ds = BLL.MusicBLL.MusicSelectByIdBLL(Music);
                 string name = ds.Tables[0].Rows[0][1].ToString();
                 //Session["musicsrl"] = url;
                // MusicUrl geturl = new MusicUrl();
                 //string urlName = url;
                 //geturl(urlName);
                // HttpCookie cook = new HttpCookie("url");

                 HiddenField1.Value = "/UploadFile/" + name;
                
             }
                if (Session["Othersid"]!=null)
                {
                    Model.Others Others = new Model.Others();
                    Others.OthersId = int.Parse(Session["Othersid"].ToString());
                    DataSet ds = BLL.OthersBLL.OthersSelectByIdBLL(Others);
                    string url = ds.Tables[0].Rows[0][5].ToString();
                    Response.Write("<script>alert('下载后浏览器打开') </script>");
                }
                    
                }
                
            }
        }
    
