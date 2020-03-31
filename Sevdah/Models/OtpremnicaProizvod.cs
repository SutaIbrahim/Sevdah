using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sevdah.Models
{
    public class OtpremnicaProizvod
    {

        public int OtpremnicaProizvodID { get; set; }

        public float KolicinaKG { get; set; }

        [ForeignKey(nameof(Proizvod))]
        public int ProizvodID { get; set; }
        public Proizvod Proizvod { get; set; }

        [ForeignKey(nameof(Otpremnica))]
        public int OtpremnicaID { get; set; }
        public Otpremnica Otpremnica { get; set; }

    }
}
