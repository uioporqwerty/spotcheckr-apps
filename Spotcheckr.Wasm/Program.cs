using Windows.UI.Xaml;

namespace Spotcheckr.Wasm
{
	public class Program
	{
		private static App _app;

		static int Main(string[] args)
		{

			Uno.UI.FeatureConfiguration.UIElement.AssignDOMXamlName = true;
			Application.Start(_ => _app = new App());
			return 0;
		}
	}
}
