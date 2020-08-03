using SimpleAuthAPI.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleAuthAPI.Interfaces
{
    public interface IBuslineRepository
    {
        public Task<Busline> GetBusline(int id);
        public Task<List<Busline>> GetBuslines();
        public Task<Busline> AddBusline(CreateBuslineRequest request);
        public Task RemoveBusline(int id);
        public Task UpdateBusline(UpdateBuslineRequest request, int id);
    }
}
