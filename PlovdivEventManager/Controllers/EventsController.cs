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

            return RedirectToAction("Index", "Home");
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
