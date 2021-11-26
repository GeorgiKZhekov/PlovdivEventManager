namespace PlovdivEventManager.Models
{
    using Events;

    public class AllEventsRequestModel
    {
        public int EventsPerPage { get; init; } = 5;
        public EventSorting Sorting { get; init; }
        public int CategoryId { get; set; }
        public int CurrentPage { get; set; } = 1;
        public int TotalEvents { get; set; }
    }
}
