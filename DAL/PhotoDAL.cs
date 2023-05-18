using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL
{
   public class PhotoDAL
    {
        //管理员
        public static DataSet SelectallDAL()
        {
            string sql = "select*from Photo ";
            return DBHelper.GetDataSet(sql);
        }
        public static int DeletephoneDAL(Model.Photo p)
        {
            string sql = string.Format("delete from Photo where TxtId='{0}'", p.PhotoId);
            return DBHelper.zsg(sql);
        }
        public static int UpdatephoneameDAL(Model.Photo p)
        {
            string sql = string.Format("update Photo set PhotoName='{0}'where PhotoId='{1}'", p.PhotoName, p.PhotoId);
            return DBHelper.zsg(sql);
        }
        //普通用户
        public static DataSet SelectDAL(Model.Photo PhotoSelectId)
       {
           string sql = string.Format("select*from Photo where UserId='{0}'",PhotoSelectId.UserId);
           return DBHelper.GetDataSet(sql);
       }
       public static int PhotoUpdate1DAL(Model.Photo PhotoUpdate)
       {
           string sql = string.Format("update Photo set PhotoName='{0}',PhotoTime='{1}' where PhotoId='{2}'",PhotoUpdate.PhotoName,PhotoUpdate.PhotoTime,PhotoUpdate.PhotoId);
           return DBHelper.zsg(sql);
       }
       public static DataSet PhotoSelectByIdDAL(Model.Photo PhotoSelectById)
       {
           string sql = string.Format("select*from Photo where PhotoId='{0}'", PhotoSelectById.PhotoId);
           return DBHelper.GetDataSet(sql);
       }
       public static int PhotoDeleteDAL(Model.Photo PhotoDelete)
       {
           string sql = string.Format("delete from Photo where PhotoId='{0}'",PhotoDelete.PhotoId);
           return DBHelper.zsg(sql);
       }
       public static int PhotoInsertDAL(Model.Photo PhotoInsert)
       {
           string sql = string.Format("insert into Photo values('{0}','{1}','{2}','{3}','{4}')",PhotoInsert.PhotoName,PhotoInsert.PhotoTime,PhotoInsert.PhotoSize,PhotoInsert.UserId,PhotoInsert.PhotoUrl);
           return DBHelper.zsg(sql);
       }

        //查询大小
        public static DataSet PhotoSizeDAL(Model.Photo photo)
        {
            string sql = string.Format("select PhotoSize from  [dbo].[Photo] where UserId='{0}'", photo.UserId);
            return DBHelper.GetDataSet(sql);
        }
        public static DataSet rightPhotoSizeDAL(Model.Photo photo)
        {
            string sql = string.Format("select RIGHT(PhotoSize,2) from [dbo].[Photo] where UserId='{0}'", photo.PhotoId);
            return DBHelper.GetDataSet(sql);
        }
        public static DataSet selectnameDAL(Model.Photo name)
        {
            string sql = string.Format("select*from Photo where PhotoName='{0}'",name.PhotoName);
            return DBHelper.GetDataSet(sql);
        }
        public static DataSet uniqueDAL(Model.Photo name)
        {
            string sql = string.Format("select*from Photo where PhotoName='{0}' and UserId='{1}'",name.PhotoName,name.UserId);
            return DBHelper.GetDataSet(sql);
        }
       
       }
}
