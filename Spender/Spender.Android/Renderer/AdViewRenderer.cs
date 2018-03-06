using Android.Content;
using Android.Gms.Ads;
using Android.Widget;
using Spender.Controls;
using Spender.Droid.Renderer;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(AdControlView), typeof(AdViewRenderer))]
namespace Spender.Droid.Renderer
{
    public class AdViewRenderer : ViewRenderer<AdControlView, AdView>
    {
        private string adUnitId = "ca-app-pub-9279700841245761/2577527036";
        private AdSize adSize = AdSize.SmartBanner;
        private AdView adView;

        private AdView CreateAdView()
        {
            if(this.adView != null)
            {
                return this.adView;
            }

            this.adView = new AdView(this.Context)
            {
                AdSize = this.adSize,
                AdUnitId = this.adUnitId,
                LayoutParameters = new LinearLayout.LayoutParams(LayoutParams.WrapContent, LayoutParams.WrapContent),
            };

            this.adView.LoadAd(new AdRequest.Builder().Build());

            return this.adView;
        }

        public AdViewRenderer(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<AdControlView> e)
        {
            base.OnElementChanged(e);

            if(this.Control == null)
            {
                this.CreateAdView();
                this.SetNativeControl(this.adView);
            }
        }
    }
}