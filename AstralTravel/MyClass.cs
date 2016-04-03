using System;
using System.Threading.Tasks;
using System.Json;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace AstralTravel
{


	public class Resource {
		public int id;
		public string name;
		public string slug;
		public string type;
	}


	public class Experience : Resource {
		public string description;
	}

	public class Protocol : Resource {
		
	}

	public class Category : Resource {
		public string icon;
	}

	public class Travel
	{
		public string Host {get;set;}

		public Travel(string host) {
			this.Host = host;
		}

		public async Task<string> Request(string method, string uri, Dictionary<string, string> data) {


			var client = new System.Net.Http.HttpClient();  
			client.BaseAddress = new Uri(this.Host);  
			
			if (method == "GET") {
				var response = await client.GetAsync("/api/v1" + uri); 

				return response.Content.ReadAsStringAsync().Result;  
			}
			if (method == "POST") {
				return "";
			}
			return "";
		}


		public async Task<JObject> RequestObject(string method, string uri, Dictionary<string, string> data) {
			var result = await this.Request(method, uri, data);
			JObject obj = JObject.Parse (result);
			return obj;
		}

		public string BaseUrl { get; set; }
	


		/// <summary>
		/// Gets the resources.
		/// </summary>
		/// <returns>The resources.</returns>
		/// <param name="method">Method.</param>
		/// <param name="url">URL.</param>
		/// <typeparam name="T">T Extends resource class</typeparam>
		public async Task<List<T>> GetResources<T>(string method, string url) where T : Resource {
			var result = await this.RequestObject (method, url, null);
			JArray array = (JArray)(result ["objects"]);
			List<T> items = new List<T> ();
			foreach (JObject obj in array) {
				items.Add (obj.ToObject<T> ());
			}
			return items;
		}


		public async Task<T> GetSingleResource<T>(string method, string url) where T : Resource {
			JObject result = await this.RequestObject (method, url, null);
			return result.ToObject<T> ();
		}


		public async Task<List<Category>> GetCategories() {
			List<Category> categories = await this.GetResources<Category> ("GET", "/category/?format=json");
			return categories;
		}

		public async Task<List<Experience>> GetExperiences() {
			List<Experience> experiences = await this.GetResources<Experience> ("GET", "/experience/?format=json");
			return experiences;
		}

		public async Task<List<Experience>> GetExperiencesForCategory(string slug) {
			List<Experience> experiences = await this.GetResources<Experience> ("GET", "/experience/?format=json&categories=" + slug);
			return experiences;
		}


		public async Task<List<Category>> GetProtocols() {
			List<Category> categories = await this.GetResources<Category> ("GET", "/protocol/?format=json");
			return categories;
		}

	}
}

