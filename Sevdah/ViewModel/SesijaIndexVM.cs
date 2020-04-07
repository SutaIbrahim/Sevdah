using System;
using System.Collections.Generic;

namespace Sevdah.ViewModel
{
    public class SesijaIndexVM
    {
        public List<Row> Rows { get; set; }
        public string TrenutniToken { get; set; }

        public class Row
        {
            public DateTime VrijemeLogiranja { get; set; }
            public string token { get; set; }
            public string IpAdresa { get; set; }
        }
    }
}
