using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniCorn.DataModels
{
    public class WindowMetadata
    {
        public uint WindowHeight { get; set; }
        public uint WindowWidth { get; set; }
        public string WindowTitle { get; set; }
        public float ScalingFactor { get; set; }
    }
}
