namespace PlovdivEventManager.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using PlovdivEventManager.Models.Events;

    public class EventsController : Controller
    {
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(AddEventFormModel eventModel)
        {

            return View();
        }
    }
}
