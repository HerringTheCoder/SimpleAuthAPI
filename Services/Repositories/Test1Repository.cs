using Microsoft.Extensions.Logging;
using SimpleAuthAPI.Database;
using SimpleAuthAPI.Interfaces;
using SimpleAuthAPI.Models.LargeModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleAuthAPI.Services.Repositories
{
    public class Test1Repository : BaseRepository<Test1, LargeDataContext>, ITest1Repository
    {
        public Test1Repository(LargeDataContext context, ILogger<Test1> logger) : base(context, logger) { }

        public List<Test1> GetTest1()
        {
            var test1 = new Test {
                Test11 = "Test11",
                Test111 = "Test111",
                Test22 = "Test22",
                Test222 = "Test222"
            };
            var test2 = new Test
            {
                Test11 = "Test11",
                Test111 = "Test111",
                Test22 = "Test22",
                Test222 = "Test222"
            };
            _context.Tests.Add(test1);
            _context.Tests.Add(test2);
            _context.SaveChanges();

            var test1s =  _context.Tests.Select(t => new Test1
            {
                Test11 = t.Test11,
                Test111 = t.Test111
            }).ToList();

            return test1s;
        }
    }
}
