using PlovdivEventManager.Services.Events;

namespace PlovdivEventManager.Controllers
{
    using Models;
    using Microsoft.AspNetCore.Mvc;
    using Data;
    using PlovdivEventManager.Data.Models;
    using Models.Events;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.AspNetCore.Authorization;
    using Infrastructure;

    public class EventsController : Controller
    {
        private readonly IEventsService _events;
        private readonly PlovdivEventManagerDbContext data;

        public EventsController(PlovdivEventManagerDbContext data, IEventsService events)
        {
            this.data = data;
            this._events = events;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Add()
        {
            if (!this.UserIsOrganizer())
            {
                return RedirectToAction(nameof(OrganizersController.Become), "Organizers", "Become");
            }

            return View(new AddEventFormModel
            {
                //Loading the view with the Categories in the dropdown menu
                Categories = this.GetEventCategories()
            });
        } 
        
        //The models do not bind automatically by get operation that is why the [FromQuery] in front of the model
        public IActionResult All([FromQuery]SearchEventsViewModel query)
        {

            var queryResult = this._events.All(
                query.CategoryId,
                query.Sorting,
                query.CurrentPage,
                SearchEventsViewModel.EventsPerPage);

            query.Events = queryResult.Events.Select(e => new EventListingViewModel
            {
                Category = e.Category,
                Description = e.Description,
                Id = e.Id,
                ImageUrl = e.ImageUrl,
                Name = e.Name,
                StartDate = e.StartDate
            });

            query.Categories = GetEventCategories();
            query.TotalEvents = queryResult.TotalEvents;
            
            return View(query);
        }
        
        [HttpPost]
        [Authorize]
        public IActionResult Add(AddEventFormModel eventt)
        {
            var organizerId = this.data
                .Organizers
                .Where(o => o.UserId == this.User.GetId())
                .Select(o => o.Id)
                .FirstOrDefault();

            if (organizerId == 0)
            {
                return RedirectToAction(nameof(OrganizersController.Become), "Organizers", "Become");
            }

            //Adding an error for the case when the category doesn't exist
            //Adding an error to the model state
            if (!this.data.Categories.Any(e => e.Id == eventt.CategoryId))
            {
                this.ModelState.AddModelError(nameof(eventt.CategoryId), "Category does not exist!");
            }

            //Checks if all of the requirements are OK and if not takes the categories again and returns the view
            if (!ModelState.IsValid)
            {
                eventt.Categories = this.GetEventCategories();
                return View(eventt);
            }

            var eventtToAdd = new Event
            {
                Name = eventt.Name,
                Description = eventt.Description,
                StartDate = DateTime.Parse(eventt.StartDate),
                EndDate = DateTime.Parse(eventt.EndDate),
                StartHour = eventt.StartHour,
                EndHour = eventt.EndHour,
                CategoryId = eventt.CategoryId,
                ImageUrl = eventt.ImageUrl,
                Address = eventt.Address,
                OrganizerId = organizerId
            };

            this.data.Events.Add(eventtToAdd);
            this.data.SaveChanges();

            return RedirectToAction(nameof(All));
        }

        //public IActionResult Details

        private bool UserIsOrganizer()
        => this.data
            .Organizers
            .Any(o => o.UserId == this.User.GetId());

        private IEnumerable<EventCategoryViewModel> GetEventCategories()
            //Taking the categories from the database
            => this.data
                   .Categories
                   .Select(e => new EventCategoryViewModel
                   {
                       Id = e.Id,
                       Name = e.Name
                   }).ToList();
                
                
    }
}
