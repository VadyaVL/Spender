using FreshMvvm;
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

            // Localization. Replace to best place

            if (Device.RuntimePlatform == Device.iOS || Device.RuntimePlatform == Device.Android)
            {
                //var ci = DependencyService.Get<ILocalizeService>().GetCurrentCultureInfo();
                //var ci = new CultureInfo("uk-UA");
                var ci = new CultureInfo("en-US");
                Resource.Culture = ci;                                      // set the RESX for resource localization
                DependencyService.Get<ILocalizeService>().SetLocale(ci);    // set the Thread for locale-aware methods
            }

            AppSetup.Instance.Setup();

            this.MainPage = new FreshNavigationContainer(FreshPageModelResolver.ResolvePageModel<MainViewModel>());
        }
    }
}
