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

            this.MainPage = new FreshNavigationContainer(FreshPageModelResolver.ResolvePageModel<MainViewModel>());
        }
	}
}
