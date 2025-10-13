using Microsoft.EntityFrameworkCore;
using TheatreApp.Data.Repository.Interfaces;
using TheatreApp.Services.Core.Interfaces;
using TheatreApp.Utils.Constants;
using TheatreApp.Web.ViewModels.Performance;

namespace TheatreApp.Services.Core
{
    public class PerformanceService : IPerformanceService
    {
        private readonly IPerformanceRepository performanceRepository;

        public PerformanceService(IPerformanceRepository performanceRepository)
        {
            this.performanceRepository = performanceRepository;
        }

        public async Task<IEnumerable<PerformanceIndexViewModel>> GetAllPerformancesAsync()
        {
            var performances = await this.performanceRepository
                                .All()
                                .Include(p => p.Play)
                                .Select(p => new PerformanceIndexViewModel()
                                {
                                    Id = p.Id.ToString(),
                                    HallName = p.HallName,
                                    StartTime = p.StartTime.ToString(GlobalApplicationConstants.PerformanceStartTimeFormat),
                                    AvailableSeats = p.AvailableSeats,
                                    PlayId = p.PlayId.ToString(),
                                    PlayTitle = p.Play.Title,
                                    ImageUrl = p.Play.ImageUrl ?? GlobalApplicationConstants.NotExistingImageUrl
                                })
                                .ToListAsync();

            return performances;
        }
    }
}
