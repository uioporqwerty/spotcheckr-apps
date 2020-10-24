#if __IOS__ || __ANDROID__ || NETFX_CORE || __MACOS__
using System;
using System.Collections.Generic;
using Microsoft.AppCenter.Crashes;

namespace Spotcheckr.Shared.Services
{
    public static partial class DiagnosticsService
    {
	    static partial void TrackErrorPartial(Exception exception, Dictionary<string, string> properties = null) =>
		    Crashes.TrackError(exception, properties);
    }
}
#endif
