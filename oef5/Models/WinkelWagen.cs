using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace oef5.Models
{
    [TypeConverter(typeof(WinkelWagenTypeConverter))]
    public class WinkelWagen
    {
        private Dictionary<Product, int> producten = new Dictionary<Product, int>();
        public void AddProduct(Product p, int aantal)
        {
            if (producten.ContainsKey(p))
            {
                producten[p] = producten[p] + aantal;
            }
            else
            {
                producten.Add(p, aantal);
            }
        }
        public IEnumerable<BesteldProduct> GetProducten()
        {
            return producten.Select(item => new BesteldProduct(item.Key, item.Value));
        }

        public decimal TotaalPrijs
        {
            get
            {
                return producten.Sum(item => item.Key.Prijs * item.Value);
            }
        }
    }
    public class BesteldProduct
    {
        [JsonProperty]
        private Product product;
        [JsonProperty]
        private int aantal;
        public BesteldProduct(Product p, int aantal)
        {
            this.product = p;
            this.aantal = aantal;
        }
        [JsonIgnore]
        public Product Product
        {
            get { return product; }
        }
        [JsonIgnore]
        public String Naam
        {
            get { return product.Naam; }
        }
        [JsonIgnore]
        public int Aantal
        {
            get { return aantal; }
        }
        [JsonIgnore]
        public decimal EenheidsPrijs
        {
            get { return product.Prijs; }
        }
        [JsonIgnore]
        public decimal Subtotaal
        {
            get { return aantal * product.Prijs; }
        }
    }
}
