using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MuckingAbout
{
    public class BlogStore : IDataStore<BlogPost>
    {
        IEnumerable<BlogPost> _blogPosts;
        HttpClient client;

        public BlogStore()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://dentedlotus.com:8080/");

            _blogPosts = new List<BlogPost>();
        }

        public async Task<bool> AddItemAsync(BlogPost item)
        {
            //users.Add(item);

            //return await Task.FromResult(true);
            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(BlogPost item)
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

        public async Task<BlogPost> GetItemAsync(string id)
        {
            var json = await client.GetStringAsync($"blogs");
            _blogPosts = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<BlogPost>>(json));
            return await Task.FromResult(_blogPosts.FirstOrDefault(s => s.Title == id));
        } 

        public async Task<IEnumerable<BlogPost>> GetItemsAsync(bool forceRefresh = false)
        {
            var json = await client.GetStringAsync($"blogs");
            _blogPosts = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<BlogPost>>(json));
            return await Task.FromResult(_blogPosts);
        }
    }
}
