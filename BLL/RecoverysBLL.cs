using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BLL
{
   public  class RecoverysBLL
    {
        public static DataSet SelectallDAL()
        {
            return DAL.TxtDAL.SelectallDAL();
        }
        public static int DeleteTXTBLL(Model.Recoverys r)
        {
            return DAL.RecoverysDAL.DeleteTXTDAL(r);
        }
        public static int UpdateTxtnameBLL(Model.Recoverys r)
        {
            return DAL.RecoverysDAL.UpdateTxtnameDAL(r);
        }
        public static DataSet SelectBLL(Model.Recoverys RecoverySelect)
       {
           return DAL.RecoverysDAL.SelectDAL(RecoverySelect);
       }
       public static DataSet SelectByIdBLL(Model.Recoverys RecoverySelectById)
       {
           return DAL.RecoverysDAL.SelectByIdDAL(RecoverySelectById);
       }
       public static int RecInsertBLL(Model.Recoverys RecInsert)
       {
           return DAL.RecoverysDAL.RecInsertDAL(RecInsert);
       }
       public static int RecDeleteBLL(Model.Recoverys RecDaelete)
       {
           return DAL.RecoverysDAL.RecDeleteDAL(RecDaelete);
       }
       public static DataSet RecUpSelectBLL(Model.Recoverys RecUpSelect)
       {
           return DAL.RecoverysDAL.RecUpSelectDAL(RecUpSelect);
       }//查询有几个回收数据
       public static int RecUpdateTimeBLL(Model.Recoverys RecUodateTime)
       {
           return DAL.RecoverysDAL.RecUpdateTimeDAL(RecUodateTime);
       }//回收站保存天数
       public static int RecDeleteTimeBLL()
       {
           return DAL.RecoverysDAL.RecDeleteTimeDAL();
       }//回收站删除
       public static DataSet selectnameBLL(Model.Recoverys name)
       {
           return DAL.RecoverysDAL.selectnameDAL(name);
       }
    }
}
