using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sevdah.Models
{
    public class OdobreniRabat
    {

        public int OdobreniRabatID { get; set; }


        [ForeignKey(nameof(Proizvod))]
        public int ProizvodID { get; set; }
        public Proizvod Proizvod { get; set; }

        [ForeignKey(nameof(Kupac))]
        public int KupacID { get; set; }
        public Kupac Kupac { get; set; }

        public float IznosPostotci { get; set; }

    }
}
