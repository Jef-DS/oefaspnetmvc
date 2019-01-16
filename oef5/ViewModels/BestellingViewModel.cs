using oef5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace oef5.ViewModels
{
    public class BestellingViewModel
    {
        public List<Product> Producten { get; set; }
        public String BesteldProduct { get; set; }
        public int Aantal { get; set; }
        public decimal TotaalPrijs { get; set; }
        public List<BesteldProduct> Bestellingen { get; set; }
    }
}
