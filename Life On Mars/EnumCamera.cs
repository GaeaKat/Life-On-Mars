using Life_On_Mars.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Life_On_Mars
{
    
    public enum EnumCamera
    {
        [Description("Front Hazard Avoidance Camera")]
        [EnabledOnRover(EnumRover.Curiosity|EnumRover.Opportunity|EnumRover.Spirit)]
        FHAZ,
        [Description("Rear Hazard Avoidance Camera")]
        [EnabledOnRover(EnumRover.Curiosity | EnumRover.Opportunity | EnumRover.Spirit)]
        RHAZ,
        [Description("Mast Camera")]
        [EnabledOnRover(EnumRover.Curiosity)]
        MAST,
        [Description("Chemistry and Camera Complex")]
        [EnabledOnRover(EnumRover.Curiosity)]
        CHEMCAM,
        [Description("Mars Hand Lens Imager")]
        [EnabledOnRover(EnumRover.Curiosity)]
        MAHLI,
        [Description("Mars Descent Imager")]
        [EnabledOnRover(EnumRover.Curiosity)]
        MARDI,
        [Description("Navigation Camera")]
        [EnabledOnRover(EnumRover.Curiosity | EnumRover.Opportunity | EnumRover.Spirit)]
        NAVCAM,
        [Description("Panoramic Camera")]
        [EnabledOnRover(EnumRover.Opportunity | EnumRover.Spirit)]
        PANCAM,
        [Description("Miniature Thermal Emission Spectrometer (Mini-TES)")]
        [EnabledOnRover(EnumRover.Opportunity | EnumRover.Spirit)]
        MINITES

    }
}
