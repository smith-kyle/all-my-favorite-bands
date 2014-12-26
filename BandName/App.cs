using System;
using Xamarin.Forms;

namespace BandName
{
	public class App
	{
		public static Page GetMainPage ()
		{	
			var mainNav = new NavigationPage(new BandListView()){ Tint = Color.FromRgb(59,89,152) };
			return mainNav;
		}
	}
}

