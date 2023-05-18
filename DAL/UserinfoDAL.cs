using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL
{
  public class UserinfoDAL
    {
        //管理员   
        public static int UpdateuserDAL(Model.Userinfo ui)
        {
            string sql = string.Format("update Userinfo set  Userage='{0}',Useriphon='{1}',Useremil='{2}' where UserId='{3}'", ui.Userage, ui.Useriphon, ui.Useremil, ui.UserId);
            return DBHelper.zsg(sql);
        }
        public static int InsertDAL(Model.Userinfo ui)
        {
            string sql = string.Format("insert into Userinfo values('{0}','{1}','{2}','{3}')", ui.UserId, ui.Userage, ui.Useriphon, ui.Useremil);
            return DBHelper.zsg(sql);
        }
        public static int DeleteDAL(Model.Userinfo us)
        {
            string sql = string.Format("delete from Userinfo where UserId='{0}'", us.UserId);
            return DBHelper.zsg(sql);
        }
        //普通用户
        public static DataSet  SelectDAL(Model.Userinfo InfoSel)//查询
      {
          string sql =string .Format( "select*from Userinfo where UserId='{0}'",InfoSel.UserId);
          return DBHelper.GetDataSet(sql);
      }
      public static int InfoInsertDAL(Model.Userinfo InfoInsert)
      {
          string sql = string.Format("insert into Userinfo(UserId,Useriphon) values('{0}','{1}')",InfoInsert.UserId,InfoInsert.Useriphon);
          return DBHelper.zsg(sql);
      }
      public static int InfoUPdateDAL(Model.Userinfo InfoUpdate)
      {
          string sql = string.Format("update Userinfo set Userage='{0}',Useriphon='{1}',Useremil='{2}' where UserinfoId='{3}'",InfoUpdate.Userage,InfoUpdate.Useriphon,InfoUpdate.Useremil,InfoUpdate.UserinfoId);
          return DBHelper.zsg(sql);
      }
    }
}
