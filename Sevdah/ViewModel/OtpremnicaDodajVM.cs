using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sevdah.ViewModel
{
    public class OtpremnicaDodajVM
    {
        public List<SelectListItem> Kupci { get; set; }

        public int KupacID { get; set; }

        public bool Revers { get; set; }
    }
}
