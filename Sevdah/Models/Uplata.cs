using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sevdah.Models
{
    public class Uplata
    {
        [Key]
        public  int UplataID { get; set; }


        [Required]
        public DateTime Datum { get; set; }

        [Required]
        public double Iznos { get; set; }
        
        public string BrojIzvoda { get; set; }


        [Required]
        [ForeignKey(nameof(Kupac))]
        public int KupacID { get; set; }
        public Kupac Kupac { get; set; }

    }
}
