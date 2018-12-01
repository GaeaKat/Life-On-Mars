using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Life_On_Mars.Downloads
{
    public class Rover
    {
        public int Id { get; set; }
        public String Name { get; set; }

        public String LandingDate { get; set; }
        public String LaunchDate { get; set; }
        public String Status { get; set; }

        public int MaxSol { get; set; }
        public String MaxDate { get; set; }
        public int TotalPhotos { get; set; }
        public object Cameras { get; set; }

    }
}
