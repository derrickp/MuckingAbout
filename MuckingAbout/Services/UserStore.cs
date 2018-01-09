using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MuckingAbout
{
    public class UserStore : IDataStore<User>
    {
        IEnumerable<User> users;
        HttpClient client;

        public UserStore()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://dentedlotus.com:8080/");

            users = new List<User>();
        }

        public async Task<bool> AddItemAsync(User item)
        {
            //users.Add(item);

            //return await Task.FromResult(true);
            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(User item)
        {
            //var _item = users.Where((User arg) => arg.Display == item.Display).FirstOrDefault();
            //users.Remove(_item);
            //users.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            //var _item = users.Where((User arg) => arg.Display == id).FirstOrDefault();
            //users.Remove(_item);

            return await Task.FromResult(true);
        }

        public async Task<User> GetItemAsync(string id)
        {
            var json = await client.GetStringAsync($"allusers");
            users = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<User>>(json));
            return await Task.FromResult(users.FirstOrDefault(s => s.Display == id));
        }

        public async Task<IEnumerable<User>> GetItemsAsync(bool forceRefresh = false)
        {
            var json = await client.GetStringAsync($"allusers");
            users = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<User>>(json));
            return await Task.FromResult(users);
        }
    }
}
