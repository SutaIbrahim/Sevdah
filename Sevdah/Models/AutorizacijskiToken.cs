using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sevdah.Models
{
    public class AutorizacijskiToken
    {
        public int Id { get; set; }
        public string Vrijednost { get; set; }
        [ForeignKey(nameof(KorisnickiNalog))]
        public int KorisnickiNalogId { get; set; }
        public KorisnickiNalog KorisnickiNalog { get; set; }
        public DateTime VrijemeEvidentiranja { get; set; }
        public string IpAdresa { get; set; }
    }
}
