using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace Spender.Services
{
    public class SettingService : ISettingService
    {
        private static ISettings AppSettings => CrossSettings.Current;

        public bool IsFirstApplicationRun
        {
            get => AppSettings.GetValueOrDefault(nameof(this.IsFirstApplicationRun), true);
            set => AppSettings.AddOrUpdateValue(nameof(this.IsFirstApplicationRun), value);
        }

        public bool IsDefaultCategoryInit
        {
            get => AppSettings.GetValueOrDefault(nameof(this.IsDefaultCategoryInit), false);
            set => AppSettings.AddOrUpdateValue(nameof(this.IsDefaultCategoryInit), value);
        }

        public string LocalizationCode
        {
            get => AppSettings.GetValueOrDefault(nameof(this.LocalizationCode), "en-US");   // uk-UA
            set => AppSettings.AddOrUpdateValue(nameof(this.LocalizationCode), value);
        }
    }
}