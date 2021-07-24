namespace PlovdivEventManager.Models.Events
{
    using System.ComponentModel.DataAnnotations;
    public class AddEventFormModel
    {
        public string Name { get; init; }
        public string Description { get; init; }
        public string StartDate { get; init; }
        public string EndDate { get; init; }
        public string StartHour { get; init; }
        public string EndHour { get; init; }
        public int CategoryId { get; init; }
        [Display(Name = "Image URL")]
        public string ImageUrl { get; init; }
        public string Address { get; init; }
    }
}
