using System;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace BandName
{
	public class BandListView : ContentPage
	{


		BandListViewModel viewModel;
		ObservableCollection<Band> itemList;
		public BandListView ()
		{
			Title = "Band List";
			NavigationPage.SetBackButtonTitle (this, "Back");
			viewModel = new BandListViewModel ();
			viewModel.ListLoaded += updateList;
			this.BindingContext = viewModel;


			var loadingIndicator = new ActivityIndicator () {
				IsVisible = true,
				IsRunning = true,
				Color     = Color.Black,
				MinimumWidthRequest = 40
			};

			var listView = new ListView
			{
				RowHeight = 50
			};

			itemList = viewModel.BandList;
			listView.ItemsSource = itemList;
			listView.ItemTemplate = new DataTemplate (typeof(BandCell));
			listView.ItemSelected += async (sender, e) => { 
				var selectedBand = (Band)e.SelectedItem;
				Navigation.PushAsync(new EditBandView(selectedBand));
			};


			Content = new StackLayout
			{
				Padding = new Thickness(-15, 0, 0, 0),
				VerticalOptions = LayoutOptions.FillAndExpand,
				Children = { listView }
			};







			//var absLayout = new AbsoluteLayout ();
			//absLayout.Children.Add (MainLayout, new Point (0, 0));
			//absLayout.Children.Add (loadingIndicator, new Point (150, 170));
			
			//Content = absLayout;

			ToolbarItems.Add(new ToolbarItem("Add Band", "add_band.png", async () =>
				{ await Navigation.PushAsync(new AddBandView(new AddBandViewModel())); }));
		}


		protected override void OnAppearing ()
		{
			base.OnAppearing ();
			viewModel.GetBandList ();
		}


		private void updateList(){
			itemList.Clear ();
			foreach(Band item in viewModel.BandList){
				itemList.Add(item);
			}
		}
	}
}

