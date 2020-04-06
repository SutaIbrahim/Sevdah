using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Sevdah.Helpers
{
    public static class Configuration
    {
        public static readonly List<SystemLanguage> SupportedSystemLanguages = new List<SystemLanguage>
        {
            new SystemLanguage
            {
                Title = "Bosanski",
                Name = "bs-Latn-BA",
                DateFormat = "dd.mm.yyyy",
                ClockTimeType = 24,
                CultureInfo = new CultureInfo("bs-Latn-BA"),
                Default = true,
            }
        };

        public static string DefaultCulture => SupportedSystemLanguages.Where(sl => sl.Default).Select(sl => sl.Name).Single();
        public static int CurrentClockTimeType => SupportedSystemLanguages.Single(sl => sl.Name == CultureInfo.CurrentCulture.Name).ClockTimeType;
    }
}
