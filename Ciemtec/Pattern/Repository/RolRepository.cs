using Ciemtec_Api.Entities;
using Ciemtec_FND.Models.ViewModel;
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
    public class RolRepository : Repository<Rol>, IRolRepository
    {
        public RolRepository(IHttpClientFactory clientFactory) : base(clientFactory)
        {

        }

        public async Task<IEnumerable<PermisoViewModel>> GetPermisos(string url)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url + "/GetPermisos");
            var client = _clientFactory.CreateClient();
            HttpResponseMessage response = await client.SendAsync(request);
            return (response.StatusCode == System.Net.HttpStatusCode.OK) ?
                JsonConvert.DeserializeObject<IEnumerable<PermisoViewModel>>(await response.Content.ReadAsStringAsync()) :
                null;

        }

        public async Task<IEnumerable<PermisoByRol>> GetPermisosByRol(int rolID, string url)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url + "/GetPermisosByRol/" + rolID);

            var client = _clientFactory.CreateClient();

            HttpResponseMessage response = await client.SendAsync(request);

            return (response.StatusCode == System.Net.HttpStatusCode.OK) ?

                JsonConvert.DeserializeObject<IEnumerable<PermisoByRol>>(await response.Content.ReadAsStringAsync()) :
                null;
        }

        public async Task<bool> CreateRolPermisos(List<PermisoByRolApi> rolDto, string url)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, url);

            if (rolDto == null) return false;

            request.Content = new StringContent(JsonConvert.SerializeObject(rolDto), Encoding.UTF8, "application/json");

            var client = _clientFactory.CreateClient();

            HttpResponseMessage response = await client.SendAsync(request);

            return (response.StatusCode == System.Net.HttpStatusCode.NoContent) ? true : false;
        }
    }
}
