namespace PlovdivEventManager.Services.Events
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Models;

    public class EventsQueryServiceModel
    {
        public int CurrentPage { get; init; } = 1;
        public int TotalEvents { get; set; }
        public IEnumerable<EventServiceModel> Events { get; set; }  

    }
}
