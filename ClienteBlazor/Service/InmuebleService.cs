using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ServidorApi.Data;

namespace ClienteBlazor.Service
{
    public class InmuebleService : IInmuebleService
    {
        private readonly HttpClient _httpClient;
        
        public InmuebleService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Inmueble>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Inmueble>>("api/Inmuebles");
        }
    }
}
 

