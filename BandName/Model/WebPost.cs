using System;
using System.Net;
using System.IO;
using System.Xml;
using System.Threading.Tasks;
using System.Net.Http;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BandName
{
	public class WebPost
	{
		/* Password removed from open source version*/
		private string password = "";

		// Get Band List
		public async Task<ObservableCollection<Band>> getBandList(){
			var httpClient = new HttpClient();
			Task<string> contentsTask = httpClient.GetStringAsync(String.Format("http://www.dev.kylesmiff.com/?password={0}&get_list=true", password)); // async method!
			string contents = await contentsTask;

			ObservableCollection<Band> myBandList = new ObservableCollection<Band> ();
			myBandList = (ObservableCollection<Band>) Newtonsoft.Json.JsonConvert.DeserializeObject(contents, typeof(ObservableCollection<Band>));
			return myBandList;
		}





		// Add Band Name
		public bool AddBandName(string band_name){
			string webServiceAddress = String.Format(@"http://www.dev.kylesmiff.com/?password={0}&band_name={1}", password, band_name);           

			HttpWebRequest httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(webServiceAddress);
			httpWebRequest.Method = "GET";

			httpWebRequest.BeginGetResponse(Response_Completed, httpWebRequest);

			return true;
		}



		// Delete Band Name
		public bool DeleteBandName(int id){
			string webServiceAddress = String.Format(@"http://www.dev.kylesmiff.com/?password={0}&delete&id={1}", password, id);           

			HttpWebRequest httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(webServiceAddress);
			httpWebRequest.Method = "GET";

			httpWebRequest.BeginGetResponse(Response_Completed, httpWebRequest);

			return true;
		}





		// Edit Band Name
		public bool EditBandName(int id, string band_name){
			string webServiceAddress = String.Format(@"http://www.dev.kylesmiff.com/?password={0}&id={1}&band_name={2}", password, id, band_name);           

			HttpWebRequest httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(webServiceAddress);
			httpWebRequest.Method = "GET";

			httpWebRequest.BeginGetResponse(Response_Completed, httpWebRequest);

			return true;
		}


		void Response_Completed(IAsyncResult result)
		{
			HttpWebRequest request = (HttpWebRequest)result.AsyncState;
			//HttpWebResponse response = (HttpWebResponse)request.EndGetResponse(result);
		}
	}
}
