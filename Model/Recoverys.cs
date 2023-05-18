using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public  class Recoverys
    {
        public int RecoveryId { get; set; }
        public string RecoveryName { get; set; }
        public DateTime RecoveryTime { get; set; }
        public string  RecoverySize { get; set; }
        public int UserId { get; set; }
        public int DiffTime { get; set; }
        public string  RecoveryUrl { get; set; }
    }
}
