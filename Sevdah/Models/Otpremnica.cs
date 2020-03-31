using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sevdah.Models
{
    public class Otpremnica
    {

        [Key]
        public int OtpremnicaID { get; set; }
        public DateTime Datum { get; set; }


        [ForeignKey(nameof(Kupac))]
        public int KupacID { get; set; }
        public Kupac Kupac { get; set; }

        public bool Revers { get; set; } // da li je revers(true) ili otpremnica(false)

    }
}
