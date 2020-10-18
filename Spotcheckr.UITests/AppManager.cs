using System;
using Uno.UITest;
using Uno.UITest.Helpers.Queries;
using Uno.UITests.Helpers;

namespace Spotcheckr.UITests
{
	public static class AppManager
	{

		private static IApp _app;

		public static IApp App =>
			_app ??
			throw new NullReferenceException(
				"AppManager.App not set. Call AppManager.StartApp() before trying to access it.");

		private static Platform? _platform;

		public static Platform Platform
		{
			get => _platform ?? throw new NullReferenceException("'AppManager.Platform' not set.");

			set => _platform = value;
		}

		private static bool _coldStartComplete;

		public static void StartApp()
		{
			// Change this to your android app name
			AppInitializer.TestEnvironment.AndroidAppName = "app.nybble.spotcheckr";

			// Change this to the URL of your WebAssembly app, found in launchsettings.json
			AppInitializer.TestEnvironment.WebAssemblyDefaultUri = "https://localhost:44371/";

			// Change this to the bundle ID of your app
			AppInitializer.TestEnvironment.iOSAppName = "app.nybble.spotcheckr";

			// Change this to the iOS device you want to test on
			AppInitializer.TestEnvironment.iOSDeviceNameOrId = "iPhone 11 Pro";

			// The current platform to test.
			AppInitializer.TestEnvironment.CurrentPlatform = Platform;

#if DEBUG
			// Show the running tests in a browser window
			AppInitializer.TestEnvironment.WebAssemblyHeadless = false;
#endif

			if (!_coldStartComplete)
			{
				// Start the app only once, so the tests runs don't restart it
				// and gain some time for the tests.
				AppInitializer.ColdStartApp();
				_coldStartComplete = true;
			}

			_app = AppInitializer.AttachToApp();
		}
	}
}
