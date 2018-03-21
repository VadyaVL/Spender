using Android.Content;
using Android.Widget;
using Com.Airbnb.Lottie;
using Spender.Controls;
using Spender.Droid.Renderer;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(LottieControlView), typeof(LottieViewRenderer))]
namespace Spender.Droid.Renderer
{
    public class LottieViewRenderer : ViewRenderer<LottieControlView, LottieAnimationView>
    {
        private LottieAnimationView lottieAnimationView;

        private LottieAnimationView CreateLottieView()
        {
            if (this.lottieAnimationView != null)
            {
                return this.lottieAnimationView;
            }

            this.lottieAnimationView = new LottieAnimationView(this.Context)
            {
                LayoutParameters = new LinearLayout.LayoutParams(LayoutParams.MatchParent, LayoutParams.MatchParent),
            };

            this.lottieAnimationView.SetAnimation("splashy_loader.json");
            this.lottieAnimationView.Loop(true);    // fix it
            this.lottieAnimationView.PlayAnimation();

            return this.lottieAnimationView;
        }

        public LottieViewRenderer(Context context) : base(context)
        {

        }
        
        protected override void OnElementChanged(ElementChangedEventArgs<LottieControlView> e)
        {
            base.OnElementChanged(e);

            if (this.Control == null)
            {
                this.CreateLottieView();
                this.SetNativeControl(this.lottieAnimationView);
            }
        }
    }
}