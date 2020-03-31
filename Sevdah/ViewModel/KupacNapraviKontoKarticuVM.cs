using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sevdah.ViewModel
{
    public class KupacNapraviKontoKarticuVM
    {
        [DataType(DataType.Date)]
        [Required(ErrorMessage ="Datum je obavezan!")]
        public DateTime datumOd { get; set; }

        [DataType(DataType.Date)]
        public DateTime datumDo { get; set; }
        public int KupacID { get; set; }

        public string Grad { get; set; }
    }
}
