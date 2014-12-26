using System;
using Xamarin.Forms;

namespace BandName
{
	public class EditBandView : ContentPage
	{
		public EditBandView (Band band)
		{
			EditBandViewModel viewModel = new EditBandViewModel ();
			viewModel.Name = band.band_name;
			viewModel.OriginalName = band.band_name;
			viewModel.Id = band.id;

			Title = "Edit Band";
			this.BindingContext = viewModel;
			Padding = new Thickness (20, 50, 20, 40);


			var bandNameEdit_entry = new Entry()
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Placeholder = "Band Name",
			};
			bandNameEdit_entry.SetBinding(Entry.TextProperty, "Name");

			var delete_btn = new Button () {
				Text = "Delete",
				TextColor = Color.White,
				BackgroundColor = Color.FromRgb(255,128,128),
				WidthRequest = 100
			};

			var save_btn = new Button () {
				Text = "Save",
				TextColor = Color.White,
				BackgroundColor = Color.FromRgb(200,200,200),
				WidthRequest = 170
			};

			save_btn.Clicked += async delegate {
				viewModel.SaveName();
				Navigation.PopAsync();
			};


			delete_btn.Clicked += (sender, e) => {
				viewModel.DeleteName();
				Navigation.PopAsync();
			};


			var Buttons = new StackLayout
			{
				Spacing = 10,
				VerticalOptions = LayoutOptions.End,
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.Start,
				Children = { delete_btn, save_btn }
			};


			Content = new StackLayout
			{
				Spacing = 10,
				Children = { bandNameEdit_entry, Buttons}
			};
		}
	}
}

