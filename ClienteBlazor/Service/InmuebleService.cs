using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Json;
using ClienteBlazor.Model; // Aquí importamos el namespace donde está InmuebleDto

namespace ClienteBlazor.Service
{
    public class InmuebleService : IInmuebleService
    {
        private readonly HttpClient _httpClient;
        
        public InmuebleService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<InmuebleDto>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<InmuebleDto>>("api/Inmuebles");
        }
    }
}

