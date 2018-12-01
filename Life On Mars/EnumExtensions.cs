using Life_On_Mars.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Life_On_Mars
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum value)
        {
            DescriptionAttribute[] descriptionAttributes = (DescriptionAttribute[])value.GetType().GetField(value.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);
            return (descriptionAttributes != null && descriptionAttributes.Length > 0 ? descriptionAttributes[0].Description : null);
        }
        public static bool IsEnabledOnRover(this EnumCamera value,EnumRover rover)
        {
            EnabledOnRoverAttribute[] roverAttributes = (EnabledOnRoverAttribute[])value.GetType().GetField(value.ToString()).GetCustomAttributes(typeof(EnabledOnRoverAttribute), false);
            return (roverAttributes != null && (roverAttributes.Length > 0) ? (roverAttributes[0].enabledon & rover)==rover : false);
        }
    }
}
