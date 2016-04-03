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
		public Travel travelAgent;
		public Resource Resource {get; set;}
		public ExperienceDataSource DataSource { get; set;}
		public ExperienceTableViewController (IntPtr p) : base(p)
		{
		}

		public override void RowSelected (UITableView tableView, Foundation.NSIndexPath indexPath)
		{
			this.Resource = this.DataSource [indexPath.Row];
			this.PerformSegue ("viewExperience", this);

		}
		public async override void PerformSegue (string identifier, Foundation.NSObject sender)
		{
			if (identifier == "viewExperiencesForCategory") {
				CategoryTableViewController ctv = (CategoryTableViewController)sender;
				Category selectedCategory = ctv.SelectedCategory;
				List<Experience> experiences = await this.travelAgent.GetExperiencesForCategory (selectedCategory.slug);
				this.DataSource.Clear();
				foreach (Experience xp in experiences) {
					this.DataSource.Insert (0, xp);
				}
				this.TableView.ReloadData ();
			}
		}
		public override async void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			// Perform any additional setup after loading the view, typically from a nib.
			this.travelAgent = new Travel (Application.AccessPoint);
			this.DataSource = new ExperienceDataSource ();
			this.TableView.DataSource = (UITableViewDataSource)this.DataSource;
			List<Experience> experiences = await this.travelAgent.GetExperiences ();
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


