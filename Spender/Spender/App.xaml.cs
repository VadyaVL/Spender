using FreshMvvm;
using FreshTinyIoC;
using Spender.Logic.Services;
using Spender.Resources;
using Spender.Services;
using Spender.ViewModels;
using System.Globalization;
using Xamarin.Forms;

namespace Spender
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

            AppSetup.Instance.Setup();

            // Localization. Replace to best place

            if (Device.RuntimePlatform == Device.iOS || Device.RuntimePlatform == Device.Android)
            {
                //var ci = DependencyService.Get<ILocalizeService>().GetCurrentCultureInfo();
                //var ci = new CultureInfo("uk-UA");
                var ci = new CultureInfo("en-US");
                Resource.Culture = ci;                                      // set the RESX for resource localization
                DependencyService.Get<ILocalizeService>().SetLocale(ci);    // set the Thread for locale-aware methods
            }

            // First Init - find best place. Replace it to MainVm
            var setting = FreshTinyIoCContainer.Current.Resolve<ISettingService>();

            if (setting.IsFirstApplicationRun)
            {
                setting.IsFirstApplicationRun = false;

                if (!setting.IsDefaultCategoryInit)
                {
                    setting.IsDefaultCategoryInit = true;

                    var categoryService = FreshTinyIoCContainer.Current.Resolve<ICategoryService>();
                    categoryService.InitDefault();
                }
            }

            this.MainPage = new FreshNavigationContainer(FreshPageModelResolver.ResolvePageModel<MainViewModel>());
        }
    }
}
