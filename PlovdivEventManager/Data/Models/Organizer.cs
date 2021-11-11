namespace PlovdivEventManager.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants.Organizer;
    public class Organizer
    {
        public int Id { get; set; }
        [Required]
        [StringLength(NameMaxLength)]
        public string Name { get; set; }
        [Required]
        [StringLength(CompanyNameMaxLength)]
        public string CompanyName { get; set; }
        [Required]
        [StringLength(PhoneNumberMaxLength)]
        public string PhoneNumber { get; set; }
        [Required]
        public string UserId { get; set; }
        public IEnumerable<Event> Events { get; init; } = new List<Event>();
    }
}
