
namespace PlovdivEventManager.Models.Home
{
    using System.Collections.Generic;

    public class IndexViewModel
    {
        public int TotalEvents { get; init; }
        public int TotalUsers { get; init; }
        public List<EventIndexViewModel> Events { get; set; }
    }
}
