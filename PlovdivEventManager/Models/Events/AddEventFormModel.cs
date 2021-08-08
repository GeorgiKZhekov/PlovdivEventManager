namespace PlovdivEventManager.Models.Events
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants;
    public class AddEventFormModel
    {
        //TODO Add Custom error messages for all the props
        [Required]
        [StringLength(EventNameMaxLength, MinimumLength = EventNameMinLength, ErrorMessage = "Name must be between {2} and {1} characters")]
        public string Name { get; init; }
        [Required]
        [StringLength(EventDescriptionMaxLength, MinimumLength = EventDescriptionMinValue, ErrorMessage = "Description must be between {2} and {1} characters")]
        public string Description { get; init; }
        [Required]
        //[RegularExpression(DateRegexValidation, ErrorMessage = "Invalid start date. Please mind the date format")]
        //TODO Validate that the date is not before the current moment
        public string StartDate { get; init; }
        [Required]
        //[RegularExpression(DateRegexValidation, ErrorMessage = "Invalid start date. Please mind the date format")]
        public string EndDate { get; init; }
        [Required]
        //[RegularExpression(HourMinutesRegexValidation, ErrorMessage = "Invalid start hour. Please mind the hour format")]
        public string StartHour { get; init; }
        [RegularExpression(HourMinutesRegexValidation, ErrorMessage = "Invalid start hour. Please mind the hour format")]
        public string EndHour { get; init; }
        [Display(Name = "Category")]
        public int CategoryId { get; init; }
        public IEnumerable<EventCategoryViewModel> Categories { get; set; }
        [Display(Name = "Image URL")]
        [Required]
        [Url]
        public string ImageUrl { get; init; }
        [Required]
        //TODO Add a regex for validation of the street address
        public string Address { get; init; }
    }
}
