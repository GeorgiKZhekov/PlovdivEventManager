

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
        [Required]
        [StringLength(DateMaxLength)]
        public string StartDate { get; set; }
        [Required]
        [StringLength(DateMaxLength)]
        public string EndDate { get; set; }
        [Required]
        [StringLength(TimeMaxLength)]
        public string StartHour { get; set; }
        [StringLength(TimeMaxLength)]
        public string EndHour { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; init; }
        [Required]
        [Url]
        public string ImageUrl { get; set; }
        [StringLength(AddressMaxLength)]
        public string Address { get; set; }

    }
}
