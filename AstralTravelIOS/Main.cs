using UIKit;

namespace AstralTravelIOS
{
	public class Application
	{
		public static UIColor PrimaryColor = UIColor.FromRGB (109, 192, 163); //UIColor.FromRGB(208, 227, 204);
		public static string AccessPoint = "http://portal.aquajogging.se/api/v1";
		// This is the main entry point of the application.
		static void Main (string[] args)
		{
			// if you want to use a different Application Delegate class from "AppDelegate"
			// you can specify it here.
			UIApplication.Main (args, null, "AppDelegate");
			
		}
	}
}
