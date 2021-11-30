namespace PlovdivEventManager.Services.Events
{
    using Models;
    public interface IEventsService
    {
        EventsQueryServiceModel All(int categoryId, EventSorting sorting, int currentPage, int eventsPerPage);
    }
}
