using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sevdah.Models
{
    public class Dobavljac
    {

        public int DobavljacID { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Naziv { get; set; }
     
        public string ID_broj { get; set; }
      
        public string PDV_broj { get; set; }

        [StringLength(100)]
        public string Adresa { get; set; }

        public string ZiroRacun { get; set; }

        public string Telefon { get; set; }

        [ForeignKey(nameof(Grad))]
        public int GradID { get; set; }
        public Grad Grad { get; set; }

        public double? Kredit { get; set; } // u slucaju da unaprijed uplatimo racun [avans]


    }
}
