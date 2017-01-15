using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Plugin.Connectivity;

namespace Ch15_MobileApp
{
	public class CloudDataStore : IDataStore<Item>
	{
		HttpClient client;
		IEnumerable<Item> items;

		public CloudDataStore()
		{
			client = new HttpClient();
			client.BaseAddress = new Uri($"{App.AzureMobileAppUrl}/");

			items = new List<Item>();
		}

		public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
		{
			if (forceRefresh && CrossConnectivity.Current.IsConnected)
			{
				var json = await client.GetStringAsync($"api/item");
				items = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<Item>>(json));
			}

			return items;
		}

		public async Task<Item> GetItemAsync(string id)
		{
			if (id != null && CrossConnectivity.Current.IsConnected)
			{
				var json = await client.GetStringAsync($"api/item/{id}");
				items = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<Item>>(json));
			}

			return null;
		}

		public async Task<bool> AddItemAsync(Item item)
		{
			if (item == null || !CrossConnectivity.Current.IsConnected)
				return false;

			var serializedItem = JsonConvert.SerializeObject(item);

			var response = await client.PostAsync($"api/item", new StringContent(serializedItem, Encoding.UTF8, "application/json"));

			return response.IsSuccessStatusCode ? true : false;
		}

		public async Task<bool> UpdateItemAsync(Item item)
		{
			if (item == null || item.Id == null || !CrossConnectivity.Current.IsConnected)
				return false;

			var serializedItem = JsonConvert.SerializeObject(item);
			var buffer = System.Text.Encoding.UTF8.GetBytes(serializedItem);
			var byteContent = new ByteArrayContent(buffer);

			var response = await client.PutAsync(new Uri($"api/item/{item.Id}"), byteContent);

			return response.IsSuccessStatusCode ? true : false;
		}

		public async Task<bool> DeleteItemAsync(string id)
		{
			if (string.IsNullOrEmpty(id) && !CrossConnectivity.Current.IsConnected)
				return false;

			var response = await client.DeleteAsync($"api/item/{id}");

			return response.IsSuccessStatusCode ? true : false;
		}
	}
}
