using System.ComponentModel.DataAnnotations;

namespace TicketingSystem.Features.TicketFeature.DTOs
{
    public class AddTicketDTO
    {
        [Required]
        public string? Title { get; set; }

        [Required]
        public string? Description { get; set; }

        [Required]
        public int DepartmentId { get; set; }


    }
}
