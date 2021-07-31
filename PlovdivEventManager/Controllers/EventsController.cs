namespace PlovdivEventManager.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using PlovdivEventManager.Data;
    using PlovdivEventManager.Data.Models;
    using PlovdivEventManager.Models.Events;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
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

        public IActionResult All()
        {
            var events = this.data
                .Events
                .OrderByDescending(c => c.Id)
                .Select(c => new EventListingViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description,
                    Category = c.Category.Name,
                    StartDate = c.StartDate,
                    ImageUrl = c.ImageUrl
                }).ToList();

            return View(events);
        }
        
        [HttpPost]
        public IActionResult Add(AddEventFormModel eventt)
        {
            if(!this.data.Categories.Any(c => c.Id == eventt.CategoryId))
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
                StartDate = eventt.StartDate,
                EndDate = eventt.EndDate,
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
                   .Select(c => new EventCategoryViewModel
                   {
                       Id = c.Id,
                       Name = c.Name
                   }).ToList();
                
                
    }
}
