using TheatreApp.Data.Models;
using TheatreApp.Data.Repository.Interfaces;

namespace TheatreApp.Data.Repository
{
    public class PlayRepository : BaseRepository<Play, Guid>, IPlayRepository
    {
        public PlayRepository(TheatreAppDbContext dbContext) 
            : base(dbContext)
        {
        }
    }
}
