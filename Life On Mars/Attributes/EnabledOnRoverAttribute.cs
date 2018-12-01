using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Life_On_Mars.Attributes
{
    [AttributeUsage(System.AttributeTargets.All)]
    
    public class EnabledOnRoverAttribute:System.Attribute
    {
        public EnumRover enabledon;
        public EnabledOnRoverAttribute(EnumRover enabledOn) => this.enabledon = enabledOn;
    }
}
