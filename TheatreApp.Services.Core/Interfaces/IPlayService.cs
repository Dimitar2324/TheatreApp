using TheatreApp.Web.ViewModels.Play;

namespace TheatreApp.Services.Core.Interfaces
{
    public interface IPlayService
    {
        Task<IEnumerable<AllPlaysIndexViewModel>> GetAllPlaysAsync();
        Task<PlayDetailsViewModel?> GetPlayDetailsByIdAsync(string? id);
        Task<PlayEditFormModel?> GetPlayEditableInformationAsync(string? id);
        Task<bool> EditPlayAsync(PlayEditFormModel formModel);
        Task<PlayDeleteInformationViewModel?> GetPlayDeleteInformationViewAsync(string? id);
    }
}
