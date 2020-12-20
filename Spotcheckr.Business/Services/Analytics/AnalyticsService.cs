namespace Spotcheckr.Business.Services
{
    public static partial class AnalyticsService
    {
	    public static void Initialize() => InitializePartial();

	    public static void TrackView(string viewName) => TrackViewPartial(viewName);

		static partial void TrackViewPartial(string viewName);

	    static partial void InitializePartial();
    }
}
