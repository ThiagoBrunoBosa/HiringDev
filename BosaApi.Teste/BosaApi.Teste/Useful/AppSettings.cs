using System.Diagnostics.CodeAnalysis;

namespace BosaApi.Teste.Useful
{
    /// <summary>
    /// Abstração dos dados do appsettings.json
    /// </summary>
    public class AppSettings
    {
        public CacheSettings Cache { get; set; }
            = CacheSettings.Default;
        public SecuritySettings Security { get; set; }
            = SecuritySettings.Default;

        public static AppSettings Default
            => new AppSettings { };

        [SuppressMessage("Design", "CA1034:Nested types should not be visible")]
        public class CacheSettings
        {
            public int Duration { get; set; } = 45;

            public static CacheSettings Default
                => new CacheSettings { };
        }

        [SuppressMessage("Design", "CA1034:Nested types should not be visible")]
        public class SecuritySettings
        {
            public string Secret { get; set; }
                = "If you want to keep a secret, you must also hide it from yourself.";

            public int Expires { get; set; } = 7;

            public static SecuritySettings Default
                => new SecuritySettings { };
        }
    }
}
