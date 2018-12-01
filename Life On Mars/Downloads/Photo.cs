using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Life_On_Mars.Downloads
{
    public class Photo
    {
        public int Id { get; set; }
        public int Sol { get; set; }
        public string ImgSrc { get; set; }
        public string EarthDate { get; set; }
        public object Camera { get; set; }
        public Rover Rover { get; set; }


        public override string ToString()
        {
            return Id.ToString() + " - " + EarthDate;
        }
    }
}
