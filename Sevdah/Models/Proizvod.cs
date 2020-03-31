using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sevdah.Models
{
    public class Proizvod
    {
        [Key]
        public int ProizvodID { get; set; }

        public string Naziv { get; set; }

        public float Masa { get; set; }

        public double CijenaBezPDV { get; set; }
        public double CijenaSaPDV { get; set; }

        public string BarKod { get; set; }

        [ForeignKey(nameof(Skladiste))]
        public int SkladisteID { get; set; }
        public Skladiste Skladiste { get; set; }
    }
}
