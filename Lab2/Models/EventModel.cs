using System.ComponentModel.DataAnnotations;

namespace Lab2.Models
{
    public class EventModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "The {0} value must be between {2} and {1} characters")]
        public string Location { get; set; }
    }
}