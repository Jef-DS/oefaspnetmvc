using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace oef3.ViewModels
{
    public class Reis
    {
        public Bestemmingen Bestemming { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartDatum { get; set; }
        [DataType(DataType.Date)]
        public DateTime EindDatum { get; set; }
        public int AantalDagen
        {
            get
            {
                return (EindDatum - StartDatum).Days;
            }
        }
    }
    public enum Bestemmingen
    {
        Afrika,
        Amerika,
        Azie,
        Oceanië,
        Europa
    }
}
