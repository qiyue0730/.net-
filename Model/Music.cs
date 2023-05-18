using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public class Music
    {
        public int MusicId { get; set; }
        public string MusicName { get; set; }
        public DateTime MusicTime { get; set; }
        public string MusicSize { get; set; }
        public int UserId { get; set; }
        public string  MusicUrl { get; set; }
    }
}
