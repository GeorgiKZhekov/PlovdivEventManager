

using PlovdivEventManager.Models.Api.Events;

namespace PlovdivEventManager.Controllers.Api
{
    using Microsoft.AspNetCore.Mvc;
    using Data;
    using System.Linq;
    using System.Collections.Generic;
    using PlovdivEventManager.Services.Events;
    using Models;

    [ApiController]
    [Route("api/events")]
    public class EventsApiController : ControllerBase
    {
        private readonly PlovdivEventManagerDbContext _data;

        public EventsApiController(PlovdivEventManagerDbContext data)
        {
            this._data = data;
        }

        [HttpGet]
        public ActionResult<AllEventsResponseModel> All([FromQuery] AllEventsRequestModel query)
        {
            var eventsQuery = this._data.Events.AsQueryable();

            if (query.CategoryId != 0)
            {
                eventsQuery = eventsQuery.Where(e =>
                    e.CategoryId == query.CategoryId);
            }

            eventsQuery = query.Sorting switch
            {
                EventSorting.DateOfEvent => eventsQuery.OrderByDescending(e => e.StartDate),
                EventSorting.DateCreated or _ => eventsQuery.OrderByDescending(e => e.Id)
            };

            int totalEvents = eventsQuery.Count();

            var events = eventsQuery
                .Skip((query.CurrentPage - 1) * query.EventsPerPage)
                .Take(query.EventsPerPage)
                .Select(e => new EventResponseModel
                {
                    Id = e.Id,
                    Name = e.Name,
                    Description = e.Description,
                    Category = e.Category.Name,
                    StartDate = e.StartDate.ToString("MM/dd/yyyy"),
                    ImageUrl = e.ImageUrl
                }).ToList();

            return new AllEventsResponseModel
            {
                CurrentPage = query.CurrentPage,
                Events = events,   
                TotalEvents = totalEvents
            };
        }
    }
}
