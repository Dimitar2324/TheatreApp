using TheatreApp.Services.Core.Interfaces;
using TheatreApp.Web.ViewModels.Admin.PlayManagement;

namespace TheatreApp.Services.Core.Admin.Interfaces
{
    public interface IPlayManagementService
    {
        Task<IEnumerable<PlayManagementIndexViewModel>> GetPlaysDashBoardInformationAsync();
        Task AddPlayAsync(PlayInputFormModel playForm);
        Task<Tuple<bool, bool>> DeleteOrRestoreMovieAsync(string? id);
    }
}
