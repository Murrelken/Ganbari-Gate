using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using GanbariGate.Models;

namespace GanbariGate.Services
{
    public class DecksWebApiDataStore // : IDataStore<Item>
    {
        HttpClient client;

        public DecksWebApiDataStore()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri($"{App.AzureBackendUrl}/");
        }

        public async Task<IEnumerable<Deck>> GetItemsAsync()
        {
            var json = await client.GetStringAsync("api/decks");
            var items = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<Deck>>(json));

            return items;
        }

        public async Task<Item> GetItemAsync(long id)
        {
            if (id <= 0) 
                return null;
            
            var json = await client.GetStringAsync($"api/decks/{id}");
            
            return await Task.Run(() => JsonConvert.DeserializeObject<Item>(json));

        }

        public async Task<bool> AddItemAsync(Deck deck)
        {
            if (deck == null)
                return false;

            var serializedItem = JsonConvert.SerializeObject(deck);

            var response = await client.PostAsync("api/decks", new StringContent(serializedItem, Encoding.UTF8, "application/json"));

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateItemAsync(Deck deck)
        {
            if (deck == null || deck.Id <= 0)
                return false;

            var serializedItem = JsonConvert.SerializeObject(deck);
            var buffer = Encoding.UTF8.GetBytes(serializedItem);
            var byteContent = new ByteArrayContent(buffer);

            var response = await client.PutAsync(new Uri($"api/decks/{deck.Id}"), byteContent);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteItemAsync(long id)
        {
            if (id <= 0)
                return false;

            var response = await client.DeleteAsync($"api/decks/{id}");

            return response.IsSuccessStatusCode;
        }
    }
}