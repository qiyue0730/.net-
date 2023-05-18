using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BLL
{
   public class TxtBLL
    {
        public static DataSet SelectallDAL()
        {
            return DAL.TxtDAL.SelectallDAL();
        }
        public static int DeleteTXTBLL(Model.Txt t)
        {
            return DAL.TxtDAL.DeleteTXTDAL(t);
        }
        public static int UpdateTxtnameBLL(Model.Txt t)
        {
            return DAL.TxtDAL.UpdateTxtnameDAL(t);
        }
        public static DataSet SelectBLL(Model.Txt TxtSelectId)
       {
           return DAL.TxtDAL.SelectDAL(TxtSelectId);
       }
       public static int TxtUpdate1BLL(Model.Txt TxtUpdate)
       {
           return DAL.TxtDAL.TxtUpdate1DAL(TxtUpdate);
       }
       public static int TxtDeleteBLL(Model.Txt TxtDelete)
       {
           return DAL.TxtDAL.TxtDeleteDAL(TxtDelete);
       }
       public static DataSet TxtSelectByIdBLL(Model.Txt TxtSelectById)
       {
           return DAL.TxtDAL.TxtSelectByIdDAL(TxtSelectById);
       }
       public static int TxtInsertBLL(Model.Txt TxtInsert)
       {
           return DAL.TxtDAL.TxtInsertDAL(TxtInsert);
       }
        public static DataSet TxtSizeBLL(Model.Txt Txt)
        {
            return DAL.TxtDAL.TxtSizeDAL(Txt);
        }
        public static DataSet rightTxtSizeBLL(Model.Txt Txt)
        {
            return DAL.TxtDAL.rightTxtSizeDAL(Txt);
        }
        public static DataSet selectnameBLL(Model.Txt name)
        {
            return DAL.TxtDAL.selectnameDAL(name);
        }
        public static DataSet uniqueBLL(Model.Txt name)
        {
            return DAL.TxtDAL.uniqueDAL(name);
        }
    }
}
