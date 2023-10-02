using ClienteBlazor.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClienteBlazor.Service
{
    public interface IInmuebleService 
    {
        Task<IEnumerable<InmuebleDto>> GetAllAsync();
    }
}

