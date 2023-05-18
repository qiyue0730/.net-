using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BLL
{
    public class OthersBLL
    {
        public static DataSet SelectallDAL()
        {
            return DAL.OthersDAL.SelectallDAL();
        }
        public static int DeletephoneDAL(Model.Others o)
        {
            return DAL.OthersDAL.DeletephoneDAL(o);
        }
        public static int UpdatephoneameDAL(Model.Others o)
        {
            return DAL.OthersDAL.UpdatephoneameDAL(o);
        }
        public static DataSet SelectIdBLL(Model.Others OthersSelectId)
        {
            return DAL.OthersDAL.SelectIdDAL(OthersSelectId);
        }
        public static int OthersUpdateBLL(Model.Others OthersUpdate)
        {
            return DAL.OthersDAL.OthersUpdateDAL(OthersUpdate);
        }
        public static DataSet OthersSelectByIdBLL(Model.Others OthersSelectById)
        {
            return DAL.OthersDAL.OthersSelectByIdDAL(OthersSelectById);
        }
        public static int OthersDeleteBLL(Model.Others OthersDelete)
        {
            return DAL.OthersDAL.OthersDeleteDAL(OthersDelete);
        }
        public static int OthersInsertBLL(Model.Others OthersInsert)
        {
            return DAL.OthersDAL.OthersInsertDAL(OthersInsert);
        }
        public static DataSet OtherssizeBLL(Model.Others others)
        {
            return DAL.OthersDAL.OtherssizeDAL(others);
        }
        public static DataSet rightOtherssizeBLL(Model.Others others)
        {
            return DAL.OthersDAL.rightOtherssizeDAL(others);
        }
        public static DataSet selectnameBLL(Model.Others name)
        {
            return DAL.OthersDAL.selectnameDAL(name);
        }
        public static DataSet uniqueBLL(Model.Others name)
        {
            return DAL.OthersDAL.uniqueDAL(name);
        }
    }
}
