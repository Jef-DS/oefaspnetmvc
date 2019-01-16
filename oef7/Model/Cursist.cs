using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace oef7.Model
{
    [Table("Cursist")]
    public class Cursist
    {
        public int Id { get; set; }
        [Required]
        public String Voornaam { get; set; }
        [Required]
        public String Achternaam { get; set; }
        public String Naam { get {return Voornaam + " " + Achternaam; } }
        public ICollection<Inschrijving> Inschrijvingen { get; set; }
    }
}
