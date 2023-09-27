using ServidorApi.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClienteBlazor.Service
{
    public interface IInmuebleService 
    {
        Task<IEnumerable<Inmueble>> GetAllAsync();
    }
}
