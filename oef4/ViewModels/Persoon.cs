using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace oef4.ViewModels
{
    public class Persoon
    {
        [Required(ErrorMessage ="Naam is verplicht")]
        public String Naam { get; set; }
        [DataType(DataType.Date)]
        public DateTime GeboorteDatum { get; set; }
        public int Leeftijd
        {
            get
            {
                DateTime vandaag = DateTime.Today;
                int leeftijd = vandaag.Year - GeboorteDatum.Year;
                DateTime verjaardag = GeboorteDatum.AddYears(leeftijd).Date;
                if (verjaardag > vandaag) leeftijd--;
                return leeftijd;
            }
        }
    }
    public class PersoonViewModel
    {
        public Persoon NieuwePersoon { get; set; }
        public Persoon VorigePersoon { get; set; }
    }
}
