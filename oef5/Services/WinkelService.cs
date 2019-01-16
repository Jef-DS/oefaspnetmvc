using oef5.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace oef5.Services
{
    public class WinkelService:IEnumerable<Product>
    {
        private IList<Product> producten;
        public WinkelService()
        {
            producten = new List<Product>
            {
                new Product{Naam="potlood", Prijs = 1},
                new Product{Naam="gom", Prijs=2},
                new Product{Naam="meetlat", Prijs=4}
            };
        }
        public Product GetProduct(String naam)
        {
            return producten.First(p => p.Naam.Equals(naam));
        }
        public IEnumerator<Product> GetEnumerator()
        {
            return producten.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return producten.GetEnumerator();
        }
    }
}
