using System;
using System.ComponentModel.DataAnnotations;

namespace Sevdah.ViewModel
{
    public class DobavljacNapraviKontoKarticuVM
    {
        [Required(ErrorMessage = "Datum je obavezan!")]
        public string datumOdString { get; set; }
        public string datumDoString { get; set; }
        public int DobavljacID { get; set; }
        public string Grad { get; set; }

        public DateTime datumOd => Convert.ToDateTime(datumOdString);
        public DateTime datumDo => Convert.ToDateTime(datumDoString);
    }
}
