using System;

using UIKit;
using AstralTravel;
using System.Collections.Generic;


namespace AstralTravelIOS
{
	public partial class ExperienceTableViewController : UITableViewController
	{
		public class ExperienceDataSource : ResourceCollectionViewDataSource<Experience> {

		}
		public Category category;
		public Travel travelAgent;
		public Resource Resource {get; set;}
		public Experience SelectedExperience { get; set;}
		public ExperienceDataSource DataSource { get; set;}
		public ExperienceTableViewController (IntPtr p) : base(p)
		{
		}

		public override void RowSelected (UITableView tableView, Foundation.NSIndexPath indexPath)
		{
			this.Resource = this.DataSource [indexPath.Row];
			this.SelectedExperience = (Experience)this.Resource;
			this.PerformSegue ("viewExperience", this);

		}

		public override void PrepareForSegue (UIStoryboardSegue segue, Foundation.NSObject sender)
		{
			if (segue.Identifier == "viewExperience") {
				ExperienceViewController evc = (ExperienceViewController)segue.DestinationViewController;
				evc.Experience = this.SelectedExperience;
			}
		}

		public override async void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			// Perform any additional setup after loading the view, typically from a nib.
			this.travelAgent = new Travel (Application.AccessPoint);
			this.DataSource = new ExperienceDataSource ();
			this.TableView.DataSource = (UITableViewDataSource)this.DataSource;

			List<Experience> experiences = new List<Experience> ();
			if (category == null) {
				experiences = await this.travelAgent.GetExperiences ();
			} else {
				experiences = await this.travelAgent.GetExperiencesForCategory (category.id.ToString());
			}			

			foreach (Experience xp in experiences) {
				this.DataSource.Insert (0, xp);
			}
			this.TableView.ReloadData (); 

		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}


