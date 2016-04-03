using System;
using UIKit;
using Foundation;

namespace AstralTravelIOS
{
	[Register("AstralTabBarController")]
	public class AstralTabBarController : UITabBarController
	{
		public AstralTabBarController(IntPtr handle) : base (handle) {
		}
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			this.TabBar.BarStyle = UIBarStyle.Black;
	
			this.TabBar.TintColor = Application.PrimaryColor;
		
		}
	}
}

