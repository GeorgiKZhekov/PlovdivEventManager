namespace PlovdivEventManager.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using PlovdivEventManager.Data;
    using PlovdivEventManager.Data.Models;
    using PlovdivEventManager.Models.Events;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class EventsController : Controller
    {
        private readonly PlovdivEventManagerDbContext data;

        public EventsController(PlovdivEventManagerDbContext data)
        {
            this.data = data;
        }
        public IActionResult Add() => View(new AddEventFormModel
        {
           //Loading the view with the Categories in the dropdown menu
           Categories = this.GetEventCategories()
        });

        public IActionResult All([FromQuery]SearchEventsViewModel query)
        {
            var eventsQuery = this.data.Events.AsQueryable();

            if(query.CategoryId != 0)
            {
                eventsQuery = eventsQuery.Where(e =>
                e.CategoryId == query.CategoryId);
            }

            eventsQuery = query.Sorting switch
            {
                EventSorting.DateOfEvent => eventsQuery.OrderByDescending(e => e.StartDate),
                EventSorting.DateCreated or _ => eventsQuery.OrderByDescending(e => e.Id)
            };

            var events = eventsQuery
                .Skip((query.CurrentPage - 1) * SearchEventsViewModel.EventsPerPage)
                .Take(SearchEventsViewModel.EventsPerPage)
                .Select(e => new EventListingViewModel
                {
                    Id = e.Id,
                    Name = e.Name,
                    Description = e.Description,
                    Category = e.Category.Name,
                    StartDate = e.StartDate.ToString("MM/dd/yyyy"),
                    ImageUrl = e.ImageUrl
                }).ToList();

            query.Events = events;
            query.Categories = GetEventCategories();

            return View(query);
        }
        
        [HttpPost]
        public IActionResult Add(AddEventFormModel eventt)
        {
            if(!this.data.Categories.Any(e => e.Id == eventt.CategoryId))
            {
                this.ModelState.AddModelError(nameof(eventt.CategoryId), "Category does not exist!");
            }

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
            };

            this.data.Events.Add(eventtToAdd);
            this.data.SaveChanges();

            return RedirectToAction(nameof(All));
        }

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
