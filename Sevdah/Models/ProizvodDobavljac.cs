using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sevdah.Models
{
    public class ProizvodDobavljac
    {
        public int ProizvodDobavljacID { get; set; }

        [ForeignKey(nameof(Dobavljac))]
        public int DobavljacID { get; set; }
        public Dobavljac Dobavljac { get; set; }

        [ForeignKey(nameof(VrstaProizvoda))]
        public int VrstaProizvodaID { get; set; }
        public VrstaProizvoda VrstaProizvoda { get; set; }

    }
}
