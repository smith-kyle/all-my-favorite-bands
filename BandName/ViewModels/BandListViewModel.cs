using System;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace BandName
{
	public class BandListViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		public delegate void OnListLoaded();
		public event OnListLoaded ListLoaded;

		WebPost webPost;
		Task<ObservableCollection<Band>> response;
		public BandListViewModel ()
		{
			GetBandList ();
		}


		public async void GetBandList(){
			webPost = new WebPost ();
			response = webPost.getBandList ();

			var tempBandList = await response;
			BandList = new ObservableCollection<Band> (tempBandList);
		}



		bool _isLoading = true;
		public bool IsLoading
		{
			get { return _isLoading; }
			set
			{
				_isLoading = value;
				OnPropertyChanged();
			}
		}



		ObservableCollection<Band> _bandList = new ObservableCollection<Band> ();
		public ObservableCollection<Band> BandList
		{
			get { return _bandList; }
			set
			{
				_bandList = value;
				ListLoaded.Invoke ();
				IsLoading = false;
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
	}
}

