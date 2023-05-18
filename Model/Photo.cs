using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public class Photo
    {
        public int PhotoId { get; set; }
        public string PhotoName { get; set; }
        public DateTime PhotoTime { get; set; }
        public string PhotoSize { get; set; }
        public int UserId { get; set; }
        public string  PhotoUrl { get; set; }
    }
}
