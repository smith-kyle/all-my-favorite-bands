using System;
using Xamarin.Forms;

namespace BandName
{
	public class AddBandView : ContentPage
	{
		public AddBandView (AddBandViewModel viewModel)
		{
			Title = "Add Band";
			this.BindingContext = viewModel;
			Padding = new Thickness (20, 50, 20, 40);

			var greeting_label = new Label () {
				Text = "I <3 U",
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Font = Font.SystemFontOfSize(50)
			};

			var bandName_entry = new Entry()
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Placeholder = "Band Name"
			};
			bandName_entry.SetBinding(Entry.TextProperty, "Name");


			var submit_btn = new Button () {
				Text = "Submit",
				TextColor = Color.White,
				BackgroundColor = Color.FromRgb(200,200,200)
			};

			submit_btn.Clicked += async delegate {
				if(await viewModel.Submit()){
					await Navigation.PushModalAsync(new ConfirmationView(new ConfirmationViewModel()));
					viewModel.Name = String.Empty;
				}
			};


			Content = new StackLayout
			{
				Spacing = 10,
				Children = { /*greeting_label*/ bandName_entry, submit_btn}
			};
		}
	}
}

