using System;
using System.Collections.Generic;

namespace Spotcheckr.Shared.Services
{
    public static partial class DiagnosticsService
    {
	    public static void TrackError(Exception exception, Dictionary<string, string> properties = null) =>
		    TrackErrorPartial(exception, properties);

	    static partial void TrackErrorPartial(Exception exception, Dictionary<string, string> properties = null);
    }
}
