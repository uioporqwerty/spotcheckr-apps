using System;
using NUnit.Framework;
using Uno.UITest;
using Uno.UITest.Helpers.Queries;

namespace Spotcheckr.UITests.Pages
{
	public abstract class BasePage
	{
		protected IApp App => AppManager.App;

		protected bool OnAndroid => AppManager.Platform == Platform.Android;

		protected bool OniOS => AppManager.Platform == Platform.iOS;

		protected bool OnBrowser => AppManager.Platform == Platform.Browser;

		protected abstract PlatformQuery Trait { get; }

		protected BasePage()
		{
			AssertOnPage(TimeSpan.FromSeconds(30));
			App.Screenshot($"On {GetType().Name}");
		}

		protected void AssertOnPage(TimeSpan? timeout = default)
		{
			var message = $"Unable to verify on page: { GetType().Name }";

			if (timeout == null)
			{
				Assert.IsNotEmpty(App.Query(Trait.Current), message);
			}
			else
			{
				Assert.DoesNotThrow(() => App.WaitForElement(Trait.Current, timeout: timeout), message);
			}
		}

		protected void WaitForPageToLeave(TimeSpan? timeout = default)
		{
			timeout = timeout ?? TimeSpan.FromSeconds(5);
			var message = $"Unable to verify *not* on page: { GetType().Name }";

			Assert.DoesNotThrow(() => App.WaitForNoElement(Trait.Current, timeout: timeout), message);
		}
	}
}
