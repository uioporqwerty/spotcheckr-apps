using System;
using Uno.UITest;
using Uno.UITest.Helpers.Queries;

namespace Spotcheckr.UITests
{
	public class PlatformQuery
	{
		public Func<IAppQuery, IAppQuery> Android
		{
			set
			{
				if (AppManager.Platform == Platform.Android)
				{
					_current = value;
				}
			}
		}

		public Func<IAppQuery, IAppQuery> IOs
		{
			set
			{
				if (AppManager.Platform == Platform.iOS)
				{
					_current = value;
				}
			}
		}

		public Func<IAppQuery, IAppQuery> Browser
		{
			set
			{
				if (AppManager.Platform == Platform.Browser)
				{
					_current = value;
				}
			}
		}

		private Func<IAppQuery, IAppQuery> _current;
		public Func<IAppQuery, IAppQuery> Current
		{
			get
			{
				if (_current == null)
				{
					throw new NullReferenceException("Trait not set for current platform");
				}

				return _current;
			}
		}
	}
}
