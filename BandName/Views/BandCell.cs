using System;
using Xamarin.Forms;

namespace BandName
{
	public class BandCell : ViewCell
	{
		public BandCell ()
		{
			var nameLabel = new Label
			{
				Font = Font.OfSize("Helvetica Light", 18),
				YAlign = TextAlignment.Center,
				XAlign = TextAlignment.Start,
				HorizontalOptions= LayoutOptions.FillAndExpand
			};
			nameLabel.SetBinding(Label.TextProperty, "band_name");

			var viewLayout = new StackLayout()
			{
				Padding = new Thickness(25, 0, 0, 0),
				Orientation = StackOrientation.Horizontal,
				Children = { nameLabel }
			};

			View = viewLayout;
		}
	}
}

