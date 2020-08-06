using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SimpleAuthAPI.Database;
using SimpleAuthAPI.Interfaces;
using SimpleAuthAPI.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleAuthAPI.Services
{
    public class BuslineRepository : BaseRepository<BuslineRepository, AuthDbContext>, IBuslineRepository
    {
        public BuslineRepository(AuthDbContext context, ILogger<BuslineRepository> logger) : base(context, logger) { }

        public async Task<Busline> AddBusline(CreateBuslineRequest request)
        {
            var busline = new Busline()
            {
                Number = request.Number
            };
            await _context.Buslines.AddAsync(busline);
            await _context.SaveChangesAsync();
            return busline;
        }

        public async Task<Busline> GetBusline(int id)
        {
            var busline = await _context.Buslines.FindAsync(id);
            return busline;
        }

        public async Task<List<Busline>> GetBuslines()
        {
            var buslines = await _context.Buslines.ToListAsync();
            return buslines;
        }

        public async Task RemoveBusline(int id)
        {
            var busline = new Busline() { Id = id };          
            _context.Buslines.Remove(busline);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateBusline(UpdateBuslineRequest request, int id)
        {
            var busline = new Busline()
            {
                Id = id,
                Number = request.Number
            };  
            _context.Buslines.Update(busline);
            await _context.SaveChangesAsync();
        }
    }
}
