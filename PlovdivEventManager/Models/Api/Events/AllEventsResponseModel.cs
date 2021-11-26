namespace PlovdivEventManager.Models.Api.Events
{
    using System.Collections.Generic;
    public class AllEventsResponseModel
    {
        public int CurrentPage { get; init; } = 1;
        public int TotalEvents { get; set; }
        public IEnumerable<EventResponseModel> Events { get; set; }  
    }
}
