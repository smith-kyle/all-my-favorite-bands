using System;

namespace BandName
{
	public class Band
	{
		// Unique ID of the band
		private int _id;
		public int id { 
			get { return _id; }
			set { _id = value; }
		}

		// Band Name
		private string _band_name;
		public string band_name { 
			get { return _band_name; }
			set { _band_name = value; }
		}
	}
}

