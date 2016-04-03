// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace AstralTravelIOS
{
	[Register ("ExperienceViewController")]
	partial class ExperienceViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextView DescriptionText { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton EnjoyButton { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (DescriptionText != null) {
				DescriptionText.Dispose ();
				DescriptionText = null;
			}
			if (EnjoyButton != null) {
				EnjoyButton.Dispose ();
				EnjoyButton = null;
			}
		}
	}
}
