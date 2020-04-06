using System.Globalization;

namespace Sevdah.Helpers
{
    public class SystemLanguage
    {
        public string Title { get; set; }
        public string Name { get; set; }
        public string DateFormat { get; set; }
        public int ClockTimeType { get; set; }
        public CultureInfo CultureInfo { get; set; }
        public bool Default { get; set; }
    }
}