using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sevdah.ViewModel
{
    public class DobavljacNapraviKontoKarticuVM
    {

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Datum je obavezan!")]
        public DateTime datumOd { get; set; }

        [DataType(DataType.Date)]
        public DateTime datumDo { get; set; }
        public int DobavljacID { get; set; }
        public string Grad { get; set; }
    }
}
