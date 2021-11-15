using System.Linq;
using PlovdivEventManager.Data;
using PlovdivEventManager.Models.Api;

namespace PlovdivEventManager.Controllers.Api
{
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/statistics")]
    public class StatisticsApiController : ControllerBase
    {
        private readonly PlovdivEventManagerDbContext _data;

        public StatisticsApiController(PlovdivEventManagerDbContext data)
        {
            this._data = data;
        }

        [HttpGet]
        public StatisticsResponseModel GetStatistics()
        {
            var totalEvents = this._data.Events.Count();
            var totalUsers = this._data.Users.Count();

            return new StatisticsResponseModel
            {
                TotalEvents = this._data.Events.Count(),
                TotalUsers = this._data.Users.Count()
            };
        }
    }
}
