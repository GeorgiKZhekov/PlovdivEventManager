using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlovdivEventManager.Models.Events
{
    public class EventListingViewModel
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public string Description { get; init; }
        public string StartDate { get; init; }
        public string ImageUrl { get; init; }
        public string Category { get; init; }
    }
}
