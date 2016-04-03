using System;
using AstralTravel;
using System.Collections.Generic;
using UIKit;

namespace AstralTravelIOS
{
	public abstract class ResourceCollectionViewDataSource<T> : UITableViewDataSource where T : Resource 
	{
		
		private List<T> Items { get; set; }
		public ResourceCollectionViewDataSource () : base()
		{
			this.Items = new List<T> ();			
		}
		public void Clear() {
			this.Items.Clear();
		}
		public override nint NumberOfSections (UITableView tableView)
		{
			return 1;
		}

		public override nint RowsInSection (UITableView collectionView, nint section)
		{
			return this.Items.Count;
		}
		public override UITableViewCell GetCell (UITableView collectionView, Foundation.NSIndexPath indexPath)
		{
			int row = indexPath.Row;
			T resource = this.Items [row];
			UITableViewCell view =  collectionView.DequeueReusableCell("Cell");
			if (view == null) {
				view = new UITableViewCell (UITableViewCellStyle.Default, "Cell");
			}
			view.TextLabel.Text = resource.name;
			return view;
		}
			
		//
		// Indexer
		//
		public T this [int index] {
			get {
				return this.Items [index];
			}
			set {
				this.Items [index] = value;
			}
		}

		//
		// Methods
		//
		public int IndexOf (T item) {
			return this.Items.IndexOf (item);
		}

		public void Insert (int index, T item) {
			this.Items.Insert (index, item);
		}

		public void RemoveAt (int index) {
			this.Items.RemoveAt (index);
		}
	
	}
}

