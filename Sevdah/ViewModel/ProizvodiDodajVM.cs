using Microsoft.AspNetCore.Mvc.Rendering;
using Sevdah.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sevdah.ViewModel
{
    public class ProizvodiDodajVM
    {
        public Proizvod proizvod { get; set; }
        public int SkladisteId { get; set; }
        public double CijenaBezPDVuKG { get; set; }
        public List<SelectListItem> listaSkladista { get; set; }

    }
}
