using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL
{
   public  class OthersDAL
    {
        //管理员
        public static DataSet SelectallDAL()
        {
            string sql = "select*from Others ";
            return DBHelper.GetDataSet(sql);
        }
        public static int DeletephoneDAL(Model.Others o)
        {
            string sql = string.Format("delete from Others where OthersId='{0}'", o.OthersId);
            return DBHelper.zsg(sql);
        }
        public static int UpdatephoneameDAL(Model.Others o)
        {
            string sql = string.Format("update Others set OthersName='{0}'where OthersId='{1}'", o.OthersName, o.OthersId);
            return DBHelper.zsg(sql);
        }

        //普通用户
        public static DataSet SelectIdDAL(Model.Others OthersSelectId)
       {
           string sql = string.Format("select*from Others where UserId='{0}'",OthersSelectId.UserId);
           return DBHelper.GetDataSet(sql);
       }
       public static int OthersUpdateDAL(Model.Others OthersUpdate)
       {
           string sql = string.Format("update Others set OthersName='{0}',OthersTime='{1}' where OthersId='{2}'",OthersUpdate.OthersName,OthersUpdate.OthersTime,OthersUpdate.OthersId);
           return DBHelper.zsg(sql);
       }
       public static DataSet OthersSelectByIdDAL(Model.Others OthersSelectById)
       {
           string sql = string.Format("select*from Others where OthersId='{0}'",OthersSelectById.OthersId);
           return DBHelper.GetDataSet(sql);
       }
       public static int OthersDeleteDAL(Model.Others OthersDelete)
       {
           string sql = string.Format("delete from Others where OthersId='{0}'",OthersDelete.OthersId);
           return DBHelper.zsg(sql);
       }
       public static int OthersInsertDAL(Model.Others OthersInsert)
       {
           string sql = string.Format("insert into Others values('{0}','{1}','{2}','{3}','{4}')",OthersInsert.OthersName,OthersInsert.OthersTime,OthersInsert.OthersSize,OthersInsert.UserId,OthersInsert.OthersUrl);
           return DBHelper.zsg(sql);
       }
        //查询大小
        public static DataSet OtherssizeDAL(Model.Others others)
        {
            string sql = string.Format("select OthersSize from [dbo].[Others]  where UserId='{0}'", others.UserId);
            return DBHelper.GetDataSet(sql);
        }
        public static DataSet rightOtherssizeDAL(Model.Others others)
        {
            string sql = string.Format("select RIGHT(OthersSize,2) from [dbo].[Others] where UserId='{0}'", others.UserId);
            return DBHelper.GetDataSet(sql);
        }
        public static DataSet selectnameDAL(Model.Others name)
        {
            string sql = string.Format("select*from Others where OthersName='{0}'",name.OthersName);
            return DBHelper.GetDataSet(sql);
        }
        public static DataSet uniqueDAL(Model.Others name)
        {
            string sql = string.Format("select*from Others where OthersName='{0}' and UserId='{1}'",name.OthersName,name.UserId);
            return DBHelper.GetDataSet(sql);
        }
    }
}
