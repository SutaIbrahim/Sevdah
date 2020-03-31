using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sevdah.Models
{
    public class RacunProizvodDobavljaca
    {
        public int RacunProizvodDobavljacaID { get; set; }
        public float KolicinaUkomadima { get; set; }
        public double IznosBezPDV { get; set; }
        public double IznosSaPDV { get; set; }

        [ForeignKey(nameof(RacunDobavljaca))]
        public int RacunDobavljacaID { get; set; }
        public RacunDobavljaca RacunDobavljaca { get; set; }

        [ForeignKey(nameof(VrstaProizvoda))]
        public int VrstaProizvodaID { get; set; }
        public VrstaProizvoda VrstaProizvoda { get; set; }

    }
}
