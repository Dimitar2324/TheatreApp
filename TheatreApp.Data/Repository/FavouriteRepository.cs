using Microsoft.EntityFrameworkCore;
using TheatreApp.Data.Models;
using TheatreApp.Data.Repository.Interfaces;

namespace TheatreApp.Data.Repository
{
    public class FavouriteRepository : BaseRepository<UserPlay, object>, IFavouriteRepository
    {
        public FavouriteRepository(TheatreAppDbContext dbContext) 
            : base(dbContext)
        {
        }

        public Task<UserPlay?> GetByCompositeKeyAsync(string userId, string playId)
        {
            return this
                .All()
                .FirstOrDefaultAsync(up => up.UserId.ToLower() == userId.ToLower()
                                           && up.PlayId.ToString().ToLower() == playId.ToLower());
        }

        public Task<bool> ExistsAsync(string userId, string playId)
        {
            return this
               .All()
               .AnyAsync(up => up.UserId.ToLower() == userId.ToLower()
                            && up.PlayId.ToString().ToLower() == playId.ToLower());
        }
    }
}
