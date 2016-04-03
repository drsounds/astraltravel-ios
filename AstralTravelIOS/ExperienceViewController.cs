using System;
using AstralTravel;
using UIKit;
using Foundation;

namespace AstralTravelIOS
{
	public partial class ExperienceViewController : UIViewController
	{
		public ExperienceViewController (IntPtr p) : base (p)
		{
		}
		public Resource Resource { get; set;}
		public override void PrepareForSegue (UIStoryboardSegue segue, Foundation.NSObject sender)
		{
			base.PrepareForSegue (segue, sender);
			this.Resource = ((ExperienceTableViewController)sender).Resource;

		}
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			this.View.TintColor = Application.PrimaryColor;
			// Perform any additional setup after loading the view, typically from a nib.
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}

		partial void UIButton349_TouchUpInside (UIButton sender)
		{
			this.DismissViewController(true, null);
		}
	}
}


