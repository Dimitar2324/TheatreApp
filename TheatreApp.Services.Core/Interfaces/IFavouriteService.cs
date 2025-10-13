using TheatreApp.Web.ViewModels.Favourite;

namespace TheatreApp.Services.Core.Interfaces
{
    public interface IFavouriteService
    {
        Task<IEnumerable<FavouriteViewModel>> GetUsersFavouritePlays(string id);
        Task<bool> AddPlayAsync(string? playId, string? userId);
        Task<bool> RemoveFromFavouritesAsync(string? playId, string? userId);
    }
}
