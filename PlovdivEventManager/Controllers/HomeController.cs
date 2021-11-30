using PlovdivEventManager.Services.Statistics;

namespace PlovdivEventManager.Controllers
{
    using System.Diagnostics;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using Data;
    using Models;
    using Models.Home;

    public class HomeController : Controller
    {
        private readonly PlovdivEventManagerDbContext data;
        private readonly IStatisticsService _statistics;

        public HomeController(PlovdivEventManagerDbContext data,
            IStatisticsService statistics)
        {
            this.data = data;
            _statistics = statistics;
        }


        public IActionResult Index()
        {

            var events = this.data
                .Events
                .OrderByDescending(c => c.Id)
                .Select(c => new EventIndexViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description,
                    ImageUrl = c.ImageUrl
                })
                .Take(3)
                .ToList();

            var totalStatistics = this._statistics.Total();

            return View(new IndexViewModel
            {
                TotalEvents = totalStatistics.TotalEvents,
                TotalUsers = totalStatistics.TotalUsers,
                Events = events
            });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
