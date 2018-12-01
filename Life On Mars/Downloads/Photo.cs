using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Life_On_Mars.Downloads
{
    public class Photo
    {
        public int id { get; set; }
        public int sol { get; set; }
        public string img_src { get; set; }
        public string earth_date { get; set; }
        public object camera { get; set; }
        public object rover { get; set; }
    }
}
