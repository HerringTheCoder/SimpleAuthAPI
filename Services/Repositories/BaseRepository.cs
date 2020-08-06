using Microsoft.Extensions.Logging;

namespace SimpleAuthAPI.Services
{
    public class BaseRepository<TEntity, TContext> 
    where TEntity : class
    where TContext : class
    {
        protected readonly TContext _context;
        protected readonly ILogger<TEntity> _logger;
        public BaseRepository(TContext context, ILogger<TEntity> logger)
        {
            _logger = logger;
            _context = context;
        }
    }
}
