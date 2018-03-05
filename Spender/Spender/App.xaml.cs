using FreshMvvm;
using Spender.ViewModels;
using Xamarin.Forms;

namespace Spender
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

            AppSetup.Instance.Setup();

            // Set Localization.
            // Set default data.
            // Redo InitViewModel to First Show Page: with set lang and loa default or not. Imlement localization
            var initViewModel = FreshPageModelResolver.ResolvePageModel<InitViewModel>();  // Call Init model - bad solution. Find better
        }

        public void OpenMainPage()
        {
            this.MainPage = new FreshNavigationContainer(FreshPageModelResolver.ResolvePageModel<MainViewModel>());
        }

        // Open another page: login, welcome or smt.
    }
}
