using System;

namespace Spender.Core
{
    public class PlatformCulture
    {
        public PlatformCulture(string platformCultureString)
        {
            if (String.IsNullOrEmpty(platformCultureString))
            {
                throw new ArgumentException("Expected culture identifier", "platformCultureString"); // in C# 6 use nameof(platformCultureString)
            }

            this.PlatformString = platformCultureString.Replace("_", "-"); // .NET expects dash, not underscore

            var dashIndex = this.PlatformString.IndexOf("-", StringComparison.Ordinal);

            if (dashIndex > 0)
            {
                var parts = this.PlatformString.Split('-');
                this.LanguageCode = parts[0];
                this.LocaleCode = parts[1];
            }
            else
            {
                this.LanguageCode = this.PlatformString;
                this.LocaleCode = "";
            }
        }
        public string PlatformString { get; private set; }

        public string LanguageCode { get; private set; }

        public string LocaleCode { get; private set; }

        public override string ToString()
        {
            return this.PlatformString;
        }
    }
}
