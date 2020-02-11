using AdMob_xamarin_forms_setup;
using AdMob_xamarin_forms_setup.Controls;
using AdMob_xamarin_forms_setup.iOS;

using Google.MobileAds;
using System.ComponentModel;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using AdMob_xamarin_forms_setup.iOS.Helpers;

[assembly: ExportRenderer(typeof(AdControlView), typeof(AdViewRenderer))]
namespace AdMob_xamarin_forms_setup.iOS.Helpers
{
	public class AdViewRenderer : ViewRenderer<AdControlView, BannerView>
	{
		protected override void OnElementChanged(ElementChangedEventArgs<AdControlView> e)
		{
			base.OnElementChanged(e);

			if (e.NewElement != null && Control == null)
				SetNativeControl(CreateBannerView());
		}

		protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);

			if (e.PropertyName == nameof(BannerView.AdUnitID))
				Control.AdUnitID = "ca-app-pub-3940256099942544/6300978111";
		}

		private BannerView CreateBannerView()
		{
			var bannerView = new BannerView(AdSizeCons.SmartBannerPortrait)
			{
				AdUnitID = "ca-app-pub-3940256099942544/6300978111",
				RootViewController = GetVisibleViewController()
			};

			bannerView.LoadRequest(GetRequest());

			Request GetRequest()
			{
				var request = Request.GetDefaultRequest();
				return request;
			}

			return bannerView;
		}

		private UIViewController GetVisibleViewController()
		{
			var windows = UIApplication.SharedApplication.Windows;
			foreach (var window in windows)
			{
				if (window.RootViewController != null)
				{
					return window.RootViewController;
				}
			}
			return null;
		}
	}
}