#if __IOS__ || __ANDROID__ || NETFX_CORE
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;

namespace Spotcheckr.Shared.Services
{
    public static partial class AnalyticsService
    {
		static partial void InitializePartial()
		{
			const string iOSId = "5ff920d3-d043-43b1-afc1-3267cf12beb6";
			const string androidId = "51904ea9-5554-4ccc-aaae-c1d7285e118d";
			const string uwpId = "98d917fa-1080-4d19-b46f-a1eed12b0c09";

			AppCenter.Start($"ios={iOSId};uwp={uwpId};android={androidId}",
				typeof(Analytics), typeof(Crashes));
		}

		static async partial void TrackViewPartial(string viewName)
		{
			if (await Analytics.IsEnabledAsync())
			{
				Analytics.TrackEvent(viewName);
			}
		}
    }
}
#endif
