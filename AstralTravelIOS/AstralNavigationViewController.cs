using System;
using Foundation;
using UIKit;
namespace AstralTravelIOS
{
	[Register("AstralNavigationViewController")]
	public class AstralNavigationViewController : UINavigationController
	{
			public AstralNavigationViewController (IntPtr p) : base(p)
		{
		}
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			this.NavigationBar.BarTintColor = Application.PrimaryColor;
		}
	}
}

