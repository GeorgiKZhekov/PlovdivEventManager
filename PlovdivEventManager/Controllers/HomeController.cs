namespace PlovdivEventManager.Controllers
{
    using System.Diagnostics;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using PlovdivEventManager.Data;
    using PlovdivEventManager.Models;
    using PlovdivEventManager.Models.Home;

    public class HomeController : Controller
    {
        private readonly PlovdivEventManagerDbContext data;

        public HomeController(PlovdivEventManagerDbContext data)
        {
            this.data = data;
        }


        public IActionResult Index()
        {
            var totalEvents = this.data.Events.Count();

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

            return View(new IndexViewModel
            {
                TotalEvents = totalEvents,
                Events = events
            });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
