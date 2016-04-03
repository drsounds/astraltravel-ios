using System;
using AstralTravel;
using UIKit;
using Foundation;

namespace AstralTravelIOS
{
	public partial class ExperienceViewController : UIViewController
	{
		public Experience Experience {
			get;
			set;
		}

		public ExperienceViewController (IntPtr p) : base (p)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			this.Title = this.Experience.name;
			this.DescriptionText.Text = this.Experience.description;
			this.View.TintColor = Application.PrimaryColor;
			// Perform any additional setup after loading the view, typically from a nib.
			this.EnjoyButton.TouchDown += (sender2, e) => {
				
			};
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}

	}
}


