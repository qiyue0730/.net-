using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL
{
   public class MusicDAL
    {
        //管理员
        public static DataSet SelectallDAL()
        {
            string sql = "select*from Music ";
            return DBHelper.GetDataSet(sql);
        }
        public static int DeletephoneDAL(Model.Music m)
        {
            string sql = string.Format("delete from Music where MusicId='{0}'", m.MusicId);
            return DBHelper.zsg(sql);
        }
        public static int UpdatephoneameDAL(Model.Music m)
        {
            string sql = string.Format("update Music set MusicName='{0}'where MusicId='{1}'", m.MusicName, m.MusicId);
            return DBHelper.zsg(sql);
        }
        //普通用户
        public static DataSet SelectDAL(Model.Music MusicSelectId)
       {
           string sql =string.Format("select*from Music where UserId='{0}'",MusicSelectId.UserId);
           return DBHelper.GetDataSet(sql);
       }
       public static int MusicUpdateDAL(Model.Music MusicUpdate)
       {
           string sql = string.Format("update Music set MusicName='{0}',MusicTime='{1}' where MusicId='{2}'",MusicUpdate.MusicName,MusicUpdate.MusicTime,MusicUpdate.MusicId);
           return DBHelper.zsg(sql);
       }
       public static DataSet MusicSelectByIdDAL(Model.Music MusicSelectById)
       {
           string sql = string.Format("select*from Music where MusicId='{0}'",MusicSelectById.MusicId);
           return DBHelper.GetDataSet(sql);
       }
       public static int MusicDeleteDAL(Model.Music MusicDelete)
       {
           string sql = string.Format("delete from Music where MusicId='{0}'",MusicDelete.MusicId);
           return DBHelper.zsg(sql);
       }
       public static int MusicInsertDAL(Model.Music MusicInsert)
       {
           string sql = string.Format("insert into Music values('{0}','{1}','{2}','{3}','{4}')",MusicInsert.MusicName,MusicInsert.MusicTime,MusicInsert.MusicSize,MusicInsert.UserId,MusicInsert.MusicUrl);
           return DBHelper.zsg(sql);
       }
        //查询大小
        public static DataSet MusicSizeDAL(Model.Music music)
        {
            string sql = string.Format("select MusicSize from [dbo].[Music] where UserId='{0}'", music.MusicId);
            return DBHelper.GetDataSet(sql);
        }
        public static DataSet rightMusicSizeDAL(Model.Music music)
        {
            string sql = string.Format("select RIGHT(MusicSize,2) from [dbo].[Music] where UserId='{0}'", music.MusicId);
            return DBHelper.GetDataSet(sql);
        }
        public static DataSet selectnameDAL(Model.Music name)
        {
            string sql = string.Format("select*from Music where MusicName='{0}'",name.MusicName);
            return DBHelper.GetDataSet(sql);
        }
        public static DataSet uniqueDAL(Model.Music name)
        {
            string sql = string.Format("select*from Music where MusicName='{0}' and UserId='{1}'",name.MusicName,name.UserId);
            return DBHelper.GetDataSet(sql);
        }
    }
}
