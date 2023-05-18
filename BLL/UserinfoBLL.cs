using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace BLL
{
   public class UserinfoBLL
    {
        public static int UpdateuserBLL(Model.Userinfo ui)
        {
            return DAL.UserinfoDAL.UpdateuserDAL(ui);
        }
        public static int InsertDAL(Model.Userinfo ui)
        {
            return DAL.UserinfoDAL.InsertDAL(ui);
        }
        public static int DeleteBLL(Model.Userinfo us)
        {
            return DAL.UserinfoDAL.DeleteDAL(us);
        }
        public static DataSet SelectBLL(Model.Userinfo InfoSel)//查询
       {
           return DAL.UserinfoDAL.SelectDAL(InfoSel);
       }
       public static int InfoInsertBLL(Model.Userinfo InfoInsert)
       {
           return DAL.UserinfoDAL.InfoInsertDAL(InfoInsert);
       }
       public static int InfoUPdateBLL(Model.Userinfo InfoUpdate)
       {
           return DAL.UserinfoDAL.InfoUPdateDAL(InfoUpdate);
       }
    }
}
