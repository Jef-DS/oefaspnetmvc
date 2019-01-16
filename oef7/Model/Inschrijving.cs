using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace oef7.Model
{
    public class Inschrijving
    {
        public int Id { get; set; }
        public int CursusId { get; set; }
        public Cursus Cursus { get; set; }
        public int CursistId { get; set; }
        public Cursist Cursist { get; set; }
        [Range(minimum:0,maximum:20)]
        public int? punten { get; set; }
    }
}
