namespace PlovdivEventManager.Services.Events
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using PlovdivEventManager.Models;

    public class EventsQueryServiceModel
    {
        public const int EventsPerPage = 3;
        public EventSorting Sorting { get; init; }
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        public int CurrentPage { get; set; } = 1;
        public int TotalEvents { get; set; }
        //public IEnumerable<EventCategoryServiceModel> Categories { get; set; }
        //public IEnumerable<EventServiceModel> Events { get; set; }

    }
}
