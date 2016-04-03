using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using AstralTravel;
using System.Collections.Generic;

namespace AstralTravelIOS
{
	partial class CategoryTableViewController : UITableViewController
	{
		public CategoryTableDataSource DataSource { get; set; }
		public CategoryTableViewController (IntPtr handle) : base (handle)
		{
		}
		public async override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			this.DataSource = new CategoryTableDataSource();
			this.TableView.DataSource = this.DataSource;
			Travel travelAgent = new Travel (Application.AccessPoint);
			List<Category> categories = await travelAgent.GetCategories ();
			foreach (Category cat in categories) {
				this.DataSource.Insert (0, cat);
			}
			this.TableView.ReloadData ();

		}
		public Category SelectedCategory { get; set; }
		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			this.SelectedCategory = this.DataSource [indexPath.Row];
			this.PerformSegue ("viewExperiencesForCategory", this);
		}

	}
	public class CategoryTableDataSource : ResourceCollectionViewDataSource<Category> {
	}
}
