#if __IOS__ || __ANDROID__ || NETFX_CORE
using System;
using System.Collections.Generic;
using Microsoft.AppCenter.Crashes;

namespace Spotcheckr.Business.Services
{
    public static partial class DiagnosticsService
    {
	    static partial void TrackErrorPartial(Exception exception, Dictionary<string, string> properties = null) =>
		    Crashes.TrackError(exception, properties);
    }
}
#endif
