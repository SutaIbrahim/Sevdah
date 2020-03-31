using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sevdah.ViewModel
{
    public class CalendarApiVM
    {
        public class Row
        {
            public string title { get; set; }
            public string start { get; set; }
        }
        public List<Row> listaRacuna { get; set; }
    }
}
