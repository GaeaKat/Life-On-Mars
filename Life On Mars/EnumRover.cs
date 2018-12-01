using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Life_On_Mars
{
    [Flags]
    public enum EnumRover
    {
        Curiosity = 0x0001,
        Opportunity = 0x0002,
        Spirit= 0x0004
    }
}
