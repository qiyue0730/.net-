using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace BLL
{
   public class FilesBLL
    {
       public static DataSet SelectBLL()
       {
           return DAL.FilesDAL.SelectDAL();
       }

    }
}
