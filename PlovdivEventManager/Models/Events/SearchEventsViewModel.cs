
namespace PlovdivEventManager.Models.Events
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class SearchEventsViewModel
    {
        public const int EventsPerPage = 3;
        public EventSorting Sorting { get; init; }
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        public int CurrentPage { get; set; } = 1;
        public IEnumerable<EventCategoryViewModel> Categories { get; set; }
        public IEnumerable<EventListingViewModel> Events { get; set; }
    }
}
