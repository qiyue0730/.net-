using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BLL
{
    public class PhotoBLL
    {
        public static DataSet SelectallDAL()
        {
            return DAL.PhotoDAL.SelectallDAL();
        }
        public static int DeletephoneDAL(Model.Photo p)
        {
            return DAL.PhotoDAL.DeletephoneDAL(p);
        }
        public static int UpdatephoneameDAL(Model.Photo p)
        {
            return DAL.PhotoDAL.UpdatephoneameDAL(p);
        }
        public static DataSet SelectBLL(Model.Photo PhotoSelectId)
        {
            return DAL.PhotoDAL.SelectDAL(PhotoSelectId);
        }
        public static int PhotoUpdate1BLL(Model.Photo PhotoUpdate)
        {
            return DAL.PhotoDAL.PhotoUpdate1DAL(PhotoUpdate);
        }
        public static DataSet PhotoSelectByIdBLL(Model.Photo PhotoSelectById)
        {
            return DAL.PhotoDAL.PhotoSelectByIdDAL(PhotoSelectById);
        }
        public static int PhotoDeleteBLL(Model.Photo PhotoDelete)
        {
            return DAL.PhotoDAL.PhotoDeleteDAL(PhotoDelete);
        }
        public static int PhotoInsertBLL(Model.Photo PhotoInsert)
        {
            return DAL.PhotoDAL.PhotoInsertDAL(PhotoInsert);
        }
        public static DataSet PhotoSizeBLL(Model.Photo photo)
        {
            return DAL.PhotoDAL.PhotoSizeDAL(photo);
        }
        public static DataSet rightPhotoSizeBLL(Model.Photo photo)
        {
            return DAL.PhotoDAL.rightPhotoSizeDAL(photo);
        }
        public static DataSet selectnameBLL(Model.Photo name)
        {
            return DAL.PhotoDAL.selectnameDAL(name);
        }
        public static DataSet uniqueBLL(Model.Photo name)
        {
            return DAL.PhotoDAL.uniqueDAL(name);
        }
    }
}
