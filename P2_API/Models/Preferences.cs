using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2_API.Models
{
    public class Preferences
    {
        public int PreferencesId { get; set; }
        public bool Aquarium { get; set; }
        public bool Boxing { get; set; }
        public bool Movies { get; set; }
    }
}

