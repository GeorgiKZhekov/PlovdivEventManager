namespace PlovdivEventManager.Services.Events
{
    using Models;
    using Data;
    using System.Linq;

    public class EventsService : IEventsService
    {
        private readonly PlovdivEventManagerDbContext _data;

        public EventsService(PlovdivEventManagerDbContext data)
        {
            this._data = data;
        }
        public EventsQueryServiceModel All(int categoryId, EventSorting sorting, int currentPage, int eventsPerPage)
        {
            var eventsQuery = this._data.Events.AsQueryable();

            if (categoryId != 0)
            {
                eventsQuery = eventsQuery.Where(e =>
                    e.CategoryId == categoryId);
            }

            eventsQuery = sorting switch
            {
                EventSorting.DateOfEvent => eventsQuery.OrderByDescending(e => e.StartDate),
                EventSorting.DateCreated or _ => eventsQuery.OrderByDescending(e => e.Id)
            };

            int totalEvents = eventsQuery.Count();

            var events = eventsQuery
                .Skip((currentPage - 1) * eventsPerPage)
                .Take(eventsPerPage)
                .Select(e => new EventServiceModel()
                {
                    Id = e.Id,
                    Name = e.Name,
                    Description = e.Description,
                    Category = e.Category.Name,
                    StartDate = e.StartDate.ToString("MM/dd/yyyy"),
                    ImageUrl = e.ImageUrl
                }).ToList();

            return new EventsQueryServiceModel()
            {
                CurrentPage = currentPage,
                Events = events,
                TotalEvents = totalEvents
            };
        }
    }
}
