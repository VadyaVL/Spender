using System.Globalization;

namespace Spender.Services
{
    public interface ILocalizeService
    {
        CultureInfo GetCurrentCultureInfo();

        void SetLocale(CultureInfo ci);
    }
}