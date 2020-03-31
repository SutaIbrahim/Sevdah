using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sevdah.Models
{
    public class Kupac
    {

        [Key]
        public int KupacID { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string NazivKupca { get; set; }
        [Required]
        public string ID_broj { get; set; }
        [Required]
        public string PDV_broj { get; set; }

        [StringLength(100)]
        public string Adresa { get; set; }

        [Required]
        [ForeignKey(nameof(Grad))]
        public int GradID { get; set; }
        public Grad Grad { get; set; }


        public double? Kredit { get; set; } // u slucaju da kupac pretplati sve račune, cuva visak uplate 

    }
}
