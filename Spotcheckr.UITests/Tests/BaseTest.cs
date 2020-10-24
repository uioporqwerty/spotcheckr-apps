using NUnit.Framework;
using Uno.UITest;
using Uno.UITest.Helpers.Queries;

namespace Spotcheckr.UITests.Tests
{
	[TestFixture(Platform.Android)]
	[TestFixture(Platform.iOS)]
	[TestFixture(Platform.Browser)]
	public abstract class BaseTest
	{
		protected IApp App => AppManager.App;

		protected bool OnAndroid => AppManager.Platform == Platform.Android;

		protected bool OniOS => AppManager.Platform == Platform.iOS;

		protected bool OnBrowser => AppManager.Platform == Platform.Browser;

		protected BaseTest(Platform platform)
		{
			AppManager.Platform = platform;
		}

		[SetUp]
		public virtual void BeforeEachTest() => AppManager.StartApp();
	}
}
