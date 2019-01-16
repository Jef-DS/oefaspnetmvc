using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace oef7.Model
{
    [Table("Cursus")]
    public class Cursus
    {
        public int Id { get; set; }
        [Required]
        public String Naam { get; set; }
        public ICollection<Inschrijving> Inschrijvingen { get; set; }
    }
}
