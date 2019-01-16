using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace oef5.Models
{
    public class Product
    {
        public String Naam { get; set; }
        public decimal Prijs { get; set; }

        public override bool Equals(object obj)
        {
            var product = obj as Product;
            return product != null &&
                   Naam == product.Naam;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Naam);
        }
        public String Text
        {
            get { return String.Format("{0} ({1:C})", Naam, Prijs); }
        }
    }
}
