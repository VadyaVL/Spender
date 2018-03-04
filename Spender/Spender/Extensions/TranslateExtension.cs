using Spender.Resources;
using System;
using System.Globalization;
using System.Reflection;
using System.Resources;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Spender.Extensions
{
    [ContentProperty("Text")]
    public class TranslateExtension : IMarkupExtension
    {
        private readonly CultureInfo _ci;

        private const string ResourceId = "Spender.Resources.Resource";

        private static readonly Lazy<ResourceManager> ResMgr = new Lazy<ResourceManager>(() => new ResourceManager(ResourceId, typeof(TranslateExtension).GetTypeInfo().Assembly));

        public TranslateExtension()
        {
            //if (Device.RuntimePlatform == Device.iOS || Device.RuntimePlatform == Device.Android)
            //{
            //    ci = DependencyService.Get<ILocalizeService>().GetCurrentCultureInfo();
            //}

            // Set it in other place
            this._ci = Resource.Culture;
        }

        public string Text { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (this.Text == null)
            {
                return string.Empty;
            }

            var translation = ResMgr.Value.GetString(this.Text, this._ci);

            if (translation == null)
            {
#if DEBUG
                throw new ArgumentException(String.Format("Key '{0}' was not found in resources '{1}' for culture '{2}'.", Text, ResourceId, _ci.Name), "Text");
#else
                translation = Text; // returns the key, which GETS DISPLAYED TO THE USER
#endif
            }

            return translation;
        }
    }
}
