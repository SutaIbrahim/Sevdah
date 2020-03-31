using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Sevdah.Models
{
    public class RacunProizvod
    {

        public int RacunProizvodID { get; set; }

        [ForeignKey(nameof(Proizvod))]
        public int ProizvodID { get; set; }
        public Proizvod Proizvod { get; set; }

        public float KolicinaKG { get; set; }
        public double CijenaBezPDV { get; set; }

        public float Rabat { get; set; } // u %
        public double IznosRabata { get; set; }
        public double IznosBezPDV { get; set; }



        [ForeignKey(nameof(Racun))]
        public int RacunID { get; set; }
        public Racun Racun { get; set; }


    }
}
