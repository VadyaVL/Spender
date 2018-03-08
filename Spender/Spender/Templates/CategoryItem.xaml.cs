using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Spender.Templates
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CategoryItem : StackLayout
    {
        public static readonly BindableProperty StartCommandProperty = BindableProperty.Create(nameof(StartCommand), typeof(Command), typeof(CategoryItem), null);

        public static readonly BindableProperty StartCommandParameterProperty = BindableProperty.Create(nameof(StartCommandParameter), typeof(object), typeof(CategoryItem), null);

        public Command StartCommand
        {
            get => (Command)GetValue(StartCommandProperty);
            set => SetValue(StartCommandProperty, value);
        }

        public object StartCommandParameter
        {
            get => GetValue(StartCommandParameterProperty);
            set => SetValue(StartCommandParameterProperty, value);
        }

        public CategoryItem ()
		{
			InitializeComponent ();
		}

        private void OnClick(object sender, EventArgs args)
        {
            this.StartCommand?.Execute(this.StartCommandParameter);
        }
    }
}