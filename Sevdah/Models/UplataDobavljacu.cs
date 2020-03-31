using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sevdah.Models
{
    public class UplataDobavljacu
    {

        public int UplataDobavljacuID { get; set; }
        [Required]
        public DateTime Datum { get; set; }
        [Required]
        public double Iznos { get; set; }
        public string Brojizvoda { get; set; }


        [ForeignKey(nameof(RacunDobavljaca))]
        public int? RacunDobavljacaID { get; set; } // ?
        public RacunDobavljaca RacunDobavljaca { get; set; }

        [ForeignKey(nameof(Dobavljac))]
        public int DobavljacID { get; set; }
        public Dobavljac Dobavljac { get; set; }

    }
}
