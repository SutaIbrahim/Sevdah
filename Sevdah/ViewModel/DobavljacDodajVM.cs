using Microsoft.AspNetCore.Mvc.Rendering;
using Sevdah.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sevdah.ViewModel
{
    public class DobavljacDodajVM
    {
        public List<SelectListItem> gradovi { get; set; }
        public Dobavljac dobavljac { get; set; }
    }
}
