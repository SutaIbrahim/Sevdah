using Sevdah.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sevdah.ViewModel
{
    public class OtpremnicaDetaljiVM
    {
        public Otpremnica otpremnica { get; set; }

        public List<OtpremnicaProizvod> stavke { get; set; }
    }
}
