using Microsoft.AspNetCore.Mvc.Rendering;
using Sevdah.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sevdah.ViewModel
{
    public class UplateDobavljaciIndexVM
    {
        public List<UplataDobavljacu> Uplate { get; set; }

        public string srchTxt { get; set; }

        public int GodinaId { get; set; }
        public List<SelectListItem> listaGodina { get; set; }

        public int MjesecId { get; set; }
        public List<SelectListItem> listaMjeseci { get; set; }

        public int zadnjiID { get; set; }
    }
}
