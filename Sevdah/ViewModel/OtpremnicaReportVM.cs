using Sevdah.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sevdah.ViewModel
{
    public class OtpremnicaReportVM
    {
        public Otpremnica _otpremnica { get; set; }
        public Kupac _kupac { get; set; }
        public List<OtpremnicaProizvod> _listaStavki { get; set; }
        public bool _revers { get; set; }
    }
}
