using Microsoft.EntityFrameworkCore;
using System.Globalization;
using TheatreApp.Data.Models;
using TheatreApp.Data.Repository.Interfaces;
using TheatreApp.Services.Core.Admin.Interfaces;
using TheatreApp.Utils.Constants;
using TheatreApp.Web.ViewModels.Admin.PlayManagement;

namespace TheatreApp.Services.Core.Admin
{
    public class PlayManagementService : IPlayManagementService
    {
        private readonly IPlayRepository playRepository;
        public PlayManagementService(IPlayRepository playRepository) 
        {
            this.playRepository = playRepository;
        }

        public async Task<IEnumerable<PlayManagementIndexViewModel>> GetPlaysDashBoardInformationAsync()
        {
            IEnumerable<PlayManagementIndexViewModel> plays = await this.playRepository
                .All()
                .IgnoreQueryFilters()
                .Select(p => new PlayManagementIndexViewModel()
                {
                    Id = p.Id.ToString(),
                    Title = p.Title,
                    Genre = p.Genre,
                    Author = p.Author,
                    ReleaseDate = p.ReleaseDate.ToString(GlobalApplicationConstants.ReleaseDateFormat),
                    Duration = p.Duration,
                    IsDeleted = p.IsDeleted
                })
                .ToListAsync();

            return plays;
        }

        public async Task AddPlayAsync(PlayInputFormModel playForm)
        {
            Play newPlay = new Play()
            {
                Title = playForm.Title,
                Author = playForm.Author,
                Description = playForm.Description,
                Genre = playForm.Genre,
                Director = playForm.Director,
                ScreenWriter = playForm.ScreenWriter,
                Duration = playForm.Duration,
                ReleaseDate = DateOnly.ParseExact(playForm.ReleaseDate, GlobalApplicationConstants.ReleaseDateFormat, CultureInfo.InvariantCulture),
                ImageUrl = playForm.ImageUrl
            };

            await this.playRepository.AddAsync(newPlay);
        }

        public async Task<Tuple<bool, bool>> DeleteOrRestoreMovieAsync(string? id)
        {
            bool result = false;
            bool isRestored = false;

            if (!string.IsNullOrWhiteSpace(id))
            {
                Play? play = await this.playRepository
                    .All()
                    .IgnoreQueryFilters()
                    .SingleOrDefaultAsync(m => m.Id.ToString().ToLower() == id.ToLower());

                if (play != null)
                {
                    if (play.IsDeleted)
                    {
                        isRestored = true;
                    }

                    play.IsDeleted = !play.IsDeleted;

                    result = await this.playRepository
                        .UpdateAsync(play);
                }
            }

            return new Tuple<bool, bool>(result, isRestored);
        }
    }
}
