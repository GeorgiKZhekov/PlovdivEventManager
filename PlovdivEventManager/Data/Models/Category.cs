namespace PlovdivEventManager.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants.Category;
    public class Category
    {
        public int Id { get; set; }
        [Required]
        [StringLength(NameMaxLength)]
        public string Name { get; set; }
        public IEnumerable<Event> Events { get; set; }
    }
}