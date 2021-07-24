using System.Collections.Generic;

namespace PlovdivEventManager.Data.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Event> Events { get; set; }
    }
}