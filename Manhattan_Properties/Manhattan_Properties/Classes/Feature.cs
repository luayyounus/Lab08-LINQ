using System;
using System.Collections.Generic;
using System.Text;

namespace Manhattan_Properties.Classes
{
    public class Feature
    {
        public string Type { get; set; }
        public Geometry Geometry { get; set; }
        public Properties Properties { get; set; }
    }
}
