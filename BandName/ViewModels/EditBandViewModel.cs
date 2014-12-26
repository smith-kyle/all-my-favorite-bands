using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace BandName
{
	public class EditBandViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		public int Id = 0;
		public string OriginalName = null;

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
			
		async public Task<bool> SaveName(){
			if (OriginalName != Name && !String.IsNullOrEmpty (Name)) {
				var webPost = new WebPost ();
				webPost.EditBandName (Id, Name);
				return true;
			} else
				return false;
		}


		async public Task<bool> DeleteName(){
			var webPost = new WebPost ();
			webPost.DeleteBandName (Id);
			return true;
		}
	}

}

