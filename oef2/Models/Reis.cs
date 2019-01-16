using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace oef2.Models
{
    public class Reis
    {
        public String Bestemming { get; set; }
        public decimal DagPrijs { get; set; }
        public int AantalDagen { get; set; }
        public bool HeeftKorting { get; set; }
        public override string ToString()
        {
            decimal prijs = DagPrijs * AantalDagen;
            prijs = HeeftKorting ? prijs * 0.95m : prijs;
            return String.Format("De reis naar {0} kost {1:0.00} EUR", Bestemming, prijs);
        }
    }
}
