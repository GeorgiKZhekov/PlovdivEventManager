namespace PlovdivEventManager.Models.Organizers
{
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants.Organizer;
    public class BecomeOrganizerFormModel
    { 
        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength, ErrorMessage = "Name should contain minimum 3 and max 25 symbols")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Company name")]
        [StringLength(CompanyNameMaxLength, MinimumLength = CompanyNameMinLength, ErrorMessage = "Company name should be at least 2 and maximum 35 symbols")]
        public string CompanyName { get; set; }
        [Required]
        [Display(Name = "Mobile phone number")]
        [RegularExpression(PhoneNumberRegexValidation)]
        [StringLength(PhoneNumberMaxLength, MinimumLength = PhoneNumberMinLength, ErrorMessage = "Mobile phone number must contain between 10 and 13 digits")]
        public string PhoneNumber { get; set; }
    }
}
