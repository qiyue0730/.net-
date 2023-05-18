using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace DAL
{
   public  class FilesDAL
    {
       public static DataSet  SelectDAL()
       {
           string sql = "select*from files";
           return DBHelper.GetDataSet(sql);
       }

    }
}
