namespace PlovdivEventManager.Models.Api.Events
{
    public class EventResponseModel
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public string Description { get; init; }
        public string StartDate { get; init; }
        public string ImageUrl { get; init; }
        public string Category { get; init; }
    }
}
