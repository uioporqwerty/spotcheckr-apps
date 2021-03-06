using System;
using Android.App;
using Android.Runtime;
using Com.Nostra13.Universalimageloader.Core;
using Windows.UI.Xaml.Media;
using Spotcheckr.Business.Services;

namespace Spotcheckr.Droid
{
	[Application(
		Label = "@string/ApplicationName",
		LargeHeap = true,
		HardwareAccelerated = true,
		Theme = "@style/AppTheme"
	)]
	public class Application : Windows.UI.Xaml.NativeApplication
	{
		public Application(IntPtr javaReference, JniHandleOwnership transfer)
			: base(() => new App(), javaReference, transfer)
		{
			AnalyticsService.Initialize();
			ConfigureUniversalImageLoader();
		}

		private static void ConfigureUniversalImageLoader()
		{
			// Create global configuration and initialize ImageLoader with this config
			var config = new ImageLoaderConfiguration
				.Builder(Context)
				.Build();

			ImageLoader.Instance.Init(config);

			ImageSource.DefaultImageLoader = ImageLoader.Instance.LoadImageAsync;
		}
	}
}
