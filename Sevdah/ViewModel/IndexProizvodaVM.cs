using Sevdah.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sevdah.ViewModel
{
    public class IndexProizvodaVM
    {
        public List<ProizvodDobavljac> proizvodi { get; set; }

        public string NazivDobavljaca { get; set; }
        public int DobavljacId { get; set; }


    }
}
