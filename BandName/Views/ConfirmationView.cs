using System;
using Xamarin.Forms;

namespace BandName
{
	public class ConfirmationView : ContentPage
	{
		public ConfirmationView (ConfirmationViewModel viewModel)
		{
			this.BindingContext = viewModel;
			Padding = new Thickness (20, 20);

			var thankyou_label = new Label () {
				Text = "Thanks Bates!",
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Font = Font.OfSize("Helvetica Light", 60),
				XAlign = TextAlignment.Center
			};


			var ilu_label = new Label () {
				Text = "I love you",
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Font = Font.OfSize("Helvetica Light", 40),
				XAlign = TextAlignment.Center
			};
					

			var ilu2_btn = new Button () {
				Text = "I love you too, Kyle",
				TextColor = Color.White,
				BackgroundColor = Color.FromRgb(200,200,200)
			};


			ilu2_btn.Clicked += async delegate {
				await Navigation.PopModalAsync();
			};




			var youreok_btn = new Button () {
				Text = "You're alright in my book",
				TextColor = Color.White,
				BackgroundColor = Color.FromRgb(200,200,200)
			};

			youreok_btn.Clicked += delegate {
				DisplayAlert("Sorry", "This button doesn't work", "No, I'm sorry", null);
			};
				

			Content = new StackLayout
			{
				Spacing = 20,
				Padding = new Thickness(0, 30, 0, 0),
				Children = { thankyou_label, ilu_label, ilu2_btn, youreok_btn }
			};
		}
	}
}

