using TheatreApp.Web.ViewModels.Performance;

namespace TheatreApp.Services.Core.Interfaces
{
    public interface IPerformanceService
    {
        Task<IEnumerable<PerformanceIndexViewModel>> GetAllPerformancesAsync();
    }
}
