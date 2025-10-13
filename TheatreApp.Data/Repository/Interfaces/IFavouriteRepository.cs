using TheatreApp.Data.Models;

namespace TheatreApp.Data.Repository.Interfaces
{
    public interface IFavouriteRepository : IRepository<UserPlay, object>
    {
        Task<UserPlay?> GetByCompositeKeyAsync(string userId, string playId);
        Task<bool> ExistsAsync(string userId, string playId);
    }
}
