using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BLL
{
   public class MusicBLL
    {
        public static DataSet SelectallDAL()
        {
            return DAL.MusicDAL.SelectallDAL();
        }
        public static int DeletephoneDAL(Model.Music m)
        {
            return DAL.MusicDAL.DeletephoneDAL(m);
        }
        public static int UpdatephoneameDAL(Model.Music m)
        {
            return DAL.MusicDAL.UpdatephoneameDAL(m);
        }
        public static DataSet SelectBLL(Model.Music MusicSelectId)
       {
           return DAL.MusicDAL.SelectDAL(MusicSelectId);
       }
       public static int MusicUpdateBLL(Model.Music MusicUpdate)
       {
           return DAL.MusicDAL.MusicUpdateDAL(MusicUpdate);
       }
       public static DataSet MusicSelectByIdBLL(Model.Music MusicSelectById)
       {
           return DAL.MusicDAL.MusicSelectByIdDAL(MusicSelectById);
       }
       public static int MusicDeleteBLL(Model.Music MusicDelete)
       {
           return DAL.MusicDAL.MusicDeleteDAL(MusicDelete);
       }
       public static int MusicInsertBLL(Model.Music MusicInsert)
       {
           return DAL.MusicDAL.MusicInsertDAL(MusicInsert);
       }
        public static DataSet MusicSizeBLL(Model.Music music)
        {
            return DAL.MusicDAL.MusicSizeDAL(music);
        }
        public static DataSet rightMusicSizeBLL(Model.Music music)
        {
            return DAL.MusicDAL.rightMusicSizeDAL(music);
        }
        public static DataSet selectnameBLL(Model.Music name)
        {
            return DAL.MusicDAL.selectnameDAL(name);
        }
        public static DataSet uniqueBLL(Model.Music name)
        {
            return DAL.MusicDAL.uniqueDAL(name);
        }
    }
}
