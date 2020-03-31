using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sevdah.ViewModel
{
    public class RacuniIndexVM
    {
        public class Row
        {
            public int RacunId { get; set; }
            public string BrojRacuna { get; set; }
            public DateTime DatumIzdavanja { get; set; }
            public double UkupnoZaNaplatu { get; set; }
            public double DoSadaPlaceno { get; set; }
            public string Kupac { get; set; }
            public bool Placeno { get; set; }
        }
        public List<Row> listaRacuna { get; set; }

        public int GodinaId { get; set; }
        public List<SelectListItem> listaGodina { get; set; }

        public int MjesecId { get; set; }
        public List<SelectListItem> listaMjeseci { get; set; }

        public string srchTxt { get; set; }
        public int zadnjiID { get; set; }


    }
}
