using Ciemtec_FND.Pattern.IRepository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Ciemtec_FND.Pattern.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly IHttpClientFactory _clientFactory;

        public Repository(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<bool> CreateAsync(string url, T obj)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, url);

            if (obj == null) return false;

            request.Content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");

            var client = _clientFactory.CreateClient();

            HttpResponseMessage response = await client.SendAsync(request);

            return (response.StatusCode == System.Net.HttpStatusCode.NoContent) ? true : false;
        }

        public async Task<bool> DeleteAsync(string url, int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, url + id);

            var client = _clientFactory.CreateClient();

            HttpResponseMessage response = await client.SendAsync(request);

            return (response.StatusCode == System.Net.HttpStatusCode.NoContent) ? true : false;
        }

        public async Task<IEnumerable<T>> GetAllAsync(string url)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var client = _clientFactory.CreateClient();

            HttpResponseMessage response = await client.SendAsync(request);

            return (response.StatusCode == System.Net.HttpStatusCode.OK) ?
                JsonConvert.DeserializeObject<IEnumerable<T>>(await response.Content.ReadAsStringAsync()).ToList() :
                null;
        }

        public async Task<T> GetAsync(string url, int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url + "/" + id);

            var client = _clientFactory.CreateClient();

            HttpResponseMessage response = await client.SendAsync(request);

            return (response.StatusCode == System.Net.HttpStatusCode.OK) ?
                JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync()) :
                null;
        }

        public async Task<bool> UpdateAsync(string url, T obj, int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Patch, url + "/" + id);

            if (obj == null) return false;

            request.Content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");

            var client = _clientFactory.CreateClient();

            HttpResponseMessage response = await client.SendAsync(request);

            return (response.StatusCode == System.Net.HttpStatusCode.NoContent) ? true : false;
        }
    }
}
