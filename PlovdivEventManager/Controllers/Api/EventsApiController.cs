namespace PlovdivEventManager.Controllers.Api
{
    using Services.Events;
    using Microsoft.AspNetCore.Mvc;
    using Models;

    [ApiController]
    [Route("api/events")]
    public class EventsApiController : ControllerBase
    {
        private readonly IEventsService _events;

        public EventsApiController(IEventsService events)
        {
            this._events = events;
        }

        [HttpGet]
        public EventsQueryServiceModel All([FromQuery] AllEventsRequestModel query)
        => this._events.All(
                query.CategoryId,
                query.Sorting,
                query.CurrentPage,
                query.EventsPerPage);
        
    }
}
