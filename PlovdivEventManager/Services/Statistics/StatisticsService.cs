namespace PlovdivEventManager.Services.Statistics
{
    using System.Linq;
    using PlovdivEventManager.Data;

    public class StatisticsService : IStatisticsService
    {
        private readonly PlovdivEventManagerDbContext _data;

        public StatisticsService(PlovdivEventManagerDbContext data)
        {
            this._data = data;
        }
        public StatisticsServiceModel Total()
        {
            var totalEvents = this._data.Events.Count();
            var totalUsers = this._data.Users.Count();

            return new StatisticsServiceModel
            {
                TotalEvents = totalEvents,
                TotalUsers = totalUsers
            };

        }
    }
}
