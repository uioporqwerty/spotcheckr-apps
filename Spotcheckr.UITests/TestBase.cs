using NUnit.Framework;
using Uno.UITest;
using Uno.UITests.Helpers;

namespace Spotcheckr.UITests
{
	public class TestBase
	{
		private IApp _app;

		static TestBase()
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
			AppInitializer.TestEnvironment.CurrentPlatform = Uno.UITest.Helpers.Queries.Platform.Browser;

#if DEBUG
			// Show the running tests in a browser window
			AppInitializer.TestEnvironment.WebAssemblyHeadless = false;
#endif

			// Start the app only once, so the tests runs don't restart it
			// and gain some time for the tests.
			AppInitializer.ColdStartApp();
		}

		protected IApp App { get; set; }

		[SetUp]
		// Attach to the running application, for better performance
		public void StartApp() => App = AppInitializer.AttachToApp();
	}
}
