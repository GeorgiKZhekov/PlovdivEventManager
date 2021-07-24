

namespace PlovdivEventManager.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;
    public class Event
    {
        public int Id { get; init; }
        [Required]
        [StringLength(EventNameMaxLength)]
        public string Name { get; set; }
        [Required]
        [StringLength(EventDescriptionMaxLength)]
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime StartHour { get; set; }
        public DateTime? EndHour { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; init; }
        [Required]
        [Url]
        public string ImageUrl { get; set; }
        public string Address { get; set; }

    }
}
