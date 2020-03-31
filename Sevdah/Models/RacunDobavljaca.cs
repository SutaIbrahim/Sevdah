using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sevdah.Models
{
    public class RacunDobavljaca
    {
        public int RacunDobavljacaID { get; set; }

        public string  BrojRacuna { get; set; }
        public DateTime Datum { get; set; }
        public double UkupnoBezPDV { get; set; }
        public double UkupnoSaPDV { get; set; }
        public double DosadPlaceno { get; set; }
        public bool Placeno { get; set; }


        [ForeignKey(nameof(Dobavljac))]
        public int DobavljacID { get; set; }
        public Dobavljac Dobavljac { get; set; }



    }
}
