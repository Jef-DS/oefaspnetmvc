using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace oef1.Models
{
    public class Rekenmachine
    {
        public int Getal1 { get; set; }
        public int Getal2 { get; set; }
        public int Som {
            get { return Getal1 + Getal2; }
        }
    }
}
