using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace BandName
{
	public class AddBandViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		string _name;
		public string Name
		{
			get { return _name; }
			set
			{
				if (value.Equals(_name, StringComparison.Ordinal))
				{
					// Nothing to do - the value hasn't changed;
					return;
				}
				_name = value;
				OnPropertyChanged();

			}
		}

		void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			var handler = PropertyChanged;
			if (handler != null)
			{
				handler(this, new PropertyChangedEventArgs(propertyName));
			}
		}





		async public Task<bool> Submit(){
			if (String.IsNullOrEmpty (Name))
				return false;
			else {
				var webPost = new WebPost ();
				webPost.AddBandName (Name);
				return true;
			}
		}
	}

}

