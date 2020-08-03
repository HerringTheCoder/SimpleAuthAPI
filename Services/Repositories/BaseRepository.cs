using Microsoft.Extensions.Logging;
using SimpleAuthAPI.Database;

namespace SimpleAuthAPI.Services
{
    public class BaseRepository<T> where T : class
    {
        protected readonly AuthDbContext _context;
        protected readonly ILogger<T> _logger;
        public BaseRepository(AuthDbContext context, ILogger<T> logger)
        {
            _logger = logger;
            _context = context;
        }
    }
}
