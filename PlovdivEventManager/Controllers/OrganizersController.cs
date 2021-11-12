
namespace PlovdivEventManager.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;
    using Microsoft.AspNetCore.Authorization;
    using PlovdivEventManager.Data;
    using PlovdivEventManager.Data.Models;
    using PlovdivEventManager.Infrastructure;
    using PlovdivEventManager.Models.Organizers;

    public class OrganizersController : Controller
    {
        private readonly PlovdivEventManagerDbContext _data;

        public OrganizersController(PlovdivEventManagerDbContext data)
        {
            this._data = data;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Become() => View();

        [HttpPost]
        [Authorize]
        public IActionResult Become(BecomeOrganizerFormModel organizer)
        {
            var userId = this.User.GetId();

            var userIdAlreadyOrganizer = this._data
                .Organizers
                .Any(o => o.UserId == userId);

            if (userIdAlreadyOrganizer)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View(organizer);
            }

            var organizerToAdd = new Organizer
            {
                Name = organizer.Name,
                CompanyName = organizer.CompanyName,
                PhoneNumber = organizer.PhoneNumber,
                UserId = userId
            };

            this._data.Organizers.Add(organizerToAdd);
            this._data.SaveChanges();

            return RedirectToAction("All", "Events");
        } 
    }
}
