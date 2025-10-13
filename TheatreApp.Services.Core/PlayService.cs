using Microsoft.EntityFrameworkCore;
using System.Globalization;

using TheatreApp.Data.Models;
using TheatreApp.Data.Repository.Interfaces;
using TheatreApp.Services.Core.Interfaces;
using TheatreApp.Web.ViewModels.Play;
using TheatreApp.Utils.Constants;

namespace TheatreApp.Services.Core
{
    public class PlayService : IPlayService
    {
        private readonly IPlayRepository playRepository;
      
        public PlayService(IPlayRepository playRepository)
        {
            this.playRepository = playRepository;
        }

        public async Task<IEnumerable<AllPlaysIndexViewModel>> GetAllPlaysAsync()
        {
            IEnumerable<AllPlaysIndexViewModel> plays = await this.playRepository
                 .AllAsNoTracking()
                 .Select(p => new AllPlaysIndexViewModel()
                 {
                     Id = p.Id.ToString(),
                     Title = p.Title,
                     Genre = p.Genre,
                     ReleaseDate = p.ReleaseDate.ToString(GlobalApplicationConstants.ReleaseDateFormat),
                     Director = p.Director,
                     Author = p.Author,
                     ImageUrl = p.ImageUrl
                 })
                 .ToListAsync();

            foreach (var playViewModel in plays)
            {
                if (string.IsNullOrEmpty(playViewModel.ImageUrl))
                {
                    playViewModel.ImageUrl = GlobalApplicationConstants.NotExistingImageUrl;
                }
            }

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

        public async Task<PlayDetailsViewModel?> GetPlayDetailsByIdAsync(string? id)
        {
            PlayDetailsViewModel? playDetailsModel = null;
            Play? play = await this.FindPlayByStringId(id);

            if (play != null)
            {
                playDetailsModel = new PlayDetailsViewModel()
                {
                    Id = play.Id.ToString(),
                    Title = play.Title,
                    Author = play.Author,
                    Description = play.Description,
                    Genre = play.Genre,
                    Director = play.Director,
                    ScreenWriter = play.ScreenWriter,
                    Duration = play.Duration,
                    ReleaseDate = play.ReleaseDate.ToString(GlobalApplicationConstants.ReleaseDateFormat),
                    ImageUrl = play.ImageUrl ?? GlobalApplicationConstants.NotExistingImageUrl,
                };
            }

            return playDetailsModel;
        }

        public async Task<PlayEditFormModel?> GetPlayEditableInformationAsync(string? id)
        {
            PlayEditFormModel? editablePlay = null;
            Play? play = await this.FindPlayByStringId(id);

            if (play != null)
            {
                editablePlay = new PlayEditFormModel()
                {
                    Id = play.Id.ToString(),
                    Title = play.Title,
                    Author = play.Author,
                    Description = play.Description,
                    Genre = play.Genre,
                    Director = play.Director,
                    ScreenWriter = play.ScreenWriter,
                    Duration = play.Duration,
                    ReleaseDate = play.ReleaseDate.ToString(GlobalApplicationConstants.ReleaseDateFormat),
                    ImageUrl = play.ImageUrl ?? GlobalApplicationConstants.NotExistingImageUrl
                };
            }

            return editablePlay;
        }

        public async Task<bool> EditPlayAsync(PlayEditFormModel formModel)
        {
            Play? play = await this.FindPlayByStringId(formModel.Id);

            if (play == null)
            {
                return false;
            }

            DateOnly releaseDate = DateOnly
                .ParseExact(formModel.ReleaseDate, GlobalApplicationConstants.ReleaseDateFormat,
                    CultureInfo.InvariantCulture, DateTimeStyles.None);

            play.Title = formModel.Title;
            play.Author = formModel.Author;
            play.Description = formModel.Description;
            play.Genre = formModel.Genre;
            play.Director = formModel.Director;
            play.ScreenWriter = formModel.ScreenWriter;
            play.Duration = formModel.Duration;
            play.ReleaseDate = releaseDate;
            play.ImageUrl = formModel.ImageUrl;

            return await this.playRepository.UpdateAsync(play);
        }

        public async Task<PlayDeleteInformationViewModel?> GetPlayDeleteInformationViewAsync(string? id)
        {
            PlayDeleteInformationViewModel? playInformation = null;
            Play? play = await this.FindPlayByStringId(id);

            if (play != null)
            {
                playInformation = new PlayDeleteInformationViewModel()
                {
                    Id = play.Id.ToString(),
                    Title = play.Title,
                    ImageUrl = play.ImageUrl ?? GlobalApplicationConstants.NotExistingImageUrl,
                };
            }

            return playInformation;
        }

        public async Task<bool> SoftDeletePlayAsync(string? id)
        {
            Play? targetPlay = await this.FindPlayByStringId(id);

            if (targetPlay == null)
            {
                return false;
            }

            return await this.playRepository.DeleteAsync(targetPlay);            
        }


        public async Task<bool> DeletePlayAsync(string? id)
        {
            Play? play = await this.FindPlayByStringId(id);

            if (play == null)
            {
                return false;
            }

            return await this.playRepository.HardDeleteAsync(play);
        }

        private async Task<Play?> FindPlayByStringId(string? id)
        {
            Play? play = null;

            if (!string.IsNullOrWhiteSpace(id))
            {
                bool isValidGuid = Guid.TryParse(id, out var guid);
                if (isValidGuid)
                {
                    play = await this.playRepository.GetByIdAsync(guid);
                }
            }

            return play;
        }
    }
}
