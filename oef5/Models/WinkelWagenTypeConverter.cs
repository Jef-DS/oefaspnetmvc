using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using oef5.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace oef5.Models
{
    public class WinkelWagenTypeConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(String))
            {
                return true;
            }
            return base.CanConvertFrom(context, sourceType);
        }
 
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value is String)
            {
                object resultaat = JsonConvert.DeserializeObject(value.ToString());
                WinkelWagen wagen = new WinkelWagen();

                foreach (JToken token in (Newtonsoft.Json.Linq.JArray)resultaat)
                {
                    BesteldProduct product = token.ToObject<BesteldProduct>();
                    wagen.AddProduct(product.Product, product.Aantal);
                }
                return wagen;
            }
            return base.ConvertFrom(context, culture, value);
        }
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(String))
            {
                WinkelWagen wagen = value as WinkelWagen;
                if (wagen != null)
                {
                    String resultaat = JsonConvert.SerializeObject(wagen.GetProducten());
                    return resultaat;
                }

            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}
