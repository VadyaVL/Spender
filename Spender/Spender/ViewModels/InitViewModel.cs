using Spender.Logic.Services;
using Spender.Resources;
using Spender.Services;
using System.Globalization;
using Xamarin.Forms;

namespace Spender.ViewModels
{
    public class InitViewModel : BasicViewModel
    {
        #region Constructors

        public InitViewModel(ISettingService settingService, ICategoryService categoryService)
        {
            this.SettingService = settingService;
            this.CategoryService = categoryService;
        }

        #endregion

        #region Methods

        public override void Init(object initData)
        {
            base.Init(initData);

            // Localization
            if (Device.RuntimePlatform == Device.iOS || Device.RuntimePlatform == Device.Android)
            {
                //var ci = DependencyService.Get<ILocalizeService>().GetCurrentCultureInfo();
                var ci = new CultureInfo(this.SettingService.LocalizationCode);
                Resource.Culture = ci;                                      // set the RESX for resource localization
                DependencyService.Get<ILocalizeService>().SetLocale(ci);    // set the Thread for locale-aware methods
            }

            // First Init. Ask question. Replace to wecome view
            if (this.SettingService.IsFirstApplicationRun)
            {
                this.SettingService.IsFirstApplicationRun = false;

                if (!this.SettingService.IsDefaultCategoryInit)
                {
                    this.SettingService.IsDefaultCategoryInit = true;
                    
                    this.CategoryService.InitDefault();
                }
            }

            if(App.Current is App app)
            {
                app.OpenMainPage();
            }
        }
        
        #endregion
    }
}
