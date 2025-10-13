using Microsoft.EntityFrameworkCore;

using TheatreApp.Data.Models;
using TheatreApp.Data.Repository.Interfaces;
using TheatreApp.Services.Core.Interfaces;
using TheatreApp.Web.ViewModels.Favourite;
using TheatreApp.Utils.Constants;

namespace TheatreApp.Services.Core
{
    public class FavouriteService : IFavouriteService
    {
        private readonly IFavouriteRepository favouriteRepository;
       
        public FavouriteService(IFavouriteRepository favouriteRepository)
        {
            this.favouriteRepository = favouriteRepository;
        }

        public async Task<IEnumerable<FavouriteViewModel>> GetUsersFavouritePlays(string id)
        {
            IEnumerable<FavouriteViewModel> plays = await this.favouriteRepository
                .All()
                .Include(up => up.Play)
                .AsNoTracking()
                .Where(up => up.UserId.ToLower() == id.ToLower())
                .Select(up => new FavouriteViewModel()
                {
                    PlayId = up.PlayId.ToString(),
                    Title = up.Play.Title,
                    Genre = up.Play.Genre,
                    ReleaseDate = up.Play.ReleaseDate.ToString(GlobalApplicationConstants.ReleaseDateFormat),
                    ImageUrl = up.Play.ImageUrl ?? GlobalApplicationConstants.NotExistingImageUrl,
                })
                .ToArrayAsync();

            return plays;
        }

        public async Task<bool> AddPlayAsync(string? playId, string? userId)
        {
            bool result = false;

            if (playId != null && userId != null)
            {
                bool isGuidValid = Guid.TryParse(playId, out var playGuid);
                if (isGuidValid)
                {
                    UserPlay? userPlays = await this.favouriteRepository
                        .All()
                        .IgnoreQueryFilters()
                        .FirstOrDefaultAsync(up => up.UserId.ToLower() == userId.ToLower()
                                                    && up.PlayId.ToString() == playGuid.ToString());

                    if (userPlays != null)
                    {
                        userPlays.IsDeleted = false;
                        result = await this.favouriteRepository.UpdateAsync(userPlays);
                    }
                    else
                    {
                        UserPlay newRecord = new UserPlay()
                        {
                            UserId = userId,
                            PlayId = playGuid
                        };

                        await this.favouriteRepository.AddAsync(newRecord);
                        result = true;
                    }
                }
            }

            return result;
        }

        public async Task<bool> RemoveFromFavouritesAsync(string? playId, string? userId)
        {
            bool result = false;

            if (playId != null && userId != null)
            {
                bool isGuidValid = Guid.TryParse(playId, out var playGuid);
                if (isGuidValid)
                {
                    UserPlay? userPlays = await this.favouriteRepository
                                                    .FirstOrDefaultAsync(up => up.UserId.ToLower() == userId.ToLower()
                                                                               && up.PlayId.ToString() == playGuid.ToString());

                    if (userPlays != null)
                    {
                        result = await this.favouriteRepository.DeleteAsync(userPlays);
                    }
                }
            }

            return result;
        }
    }
}
