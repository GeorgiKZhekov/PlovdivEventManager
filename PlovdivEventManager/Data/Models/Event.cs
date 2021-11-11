using System.Security.Permissions;

namespace PlovdivEventManager.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants.Event;
    public class Event
    {
        public int Id { get; init; }
        [Required]
        [StringLength(NameMaxLength)]
        public string Name { get; set; }
        [Required]
        [StringLength(DescriptionMaxLength)]
        public string Description { get; set; }
        [Required]
        [StringLength(DateMaxLength)]
        public DateTime StartDate { get; set; }
        [Required]
        [StringLength(DateMaxLength)]
        public DateTime EndDate { get; set; }
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

        public int OrganizerId { get; init; }
        public Organizer Organizer { get; init; }

    }
}
