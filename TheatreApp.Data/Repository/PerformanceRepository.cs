using TheatreApp.Data.Models;
using TheatreApp.Data.Repository.Interfaces;

namespace TheatreApp.Data.Repository
{
    public class PerformanceRepository : BaseRepository<Performance, Guid>, IPerformanceRepository
    {
        public PerformanceRepository(TheatreAppDbContext dbContext) 
            : base(dbContext)
        {
        }
    }
}
