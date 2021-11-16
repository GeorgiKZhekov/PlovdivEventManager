using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlovdivEventManager.Services.Statistics
{
    public interface IStatisticsService
    {
        StatisticsServiceModel Total();
    }
}
