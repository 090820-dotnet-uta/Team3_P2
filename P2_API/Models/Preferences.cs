using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2_API.Models
{
    public class Preferences
    {
        public int PreferencesId { get; set; }
        public bool Animals { get; set; }
        public bool Art { get; set; }
        public bool Nightlife { get; set; }
        public bool Beauty { get; set; }
        public bool Learning { get; set; }
        public bool Entertainment { get; set; }
        public bool Religion { get; set; }
        public bool Shopping { get; set; }
        public bool HomeDecour { get; set; }
        public bool Fitness { get; set; }
    }
}

