using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public class Txt
    {
        public int TxtId { get; set; }
        public string TxtName { get; set; }
        public DateTime TxtTime { get; set; }
        public string TxtSize { get; set; }
        public int UserId { get; set; }
        public string  TxtUrl { get; set; }
    }
}
