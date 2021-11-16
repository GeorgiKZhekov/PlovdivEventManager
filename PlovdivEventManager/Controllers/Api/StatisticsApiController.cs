namespace PlovdivEventManager.Controllers.Api
{
    using PlovdivEventManager.Data;
    using PlovdivEventManager.Services.Statistics;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/statistics")]
    public class StatisticsApiController : ControllerBase
    {
        private readonly IStatisticsService _statistics;

        public StatisticsApiController(PlovdivEventManagerDbContext data, IStatisticsService statistics)
        {
            this._statistics = statistics;
        }

        [HttpGet]
        public StatisticsServiceModel GetStatistics() => this._statistics.Total();
        
    }
}
