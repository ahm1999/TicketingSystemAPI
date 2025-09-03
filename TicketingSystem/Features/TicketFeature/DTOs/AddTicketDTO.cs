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
        [DeniedValues(0)]
        public int DepartmentId { get; set; }


    }
}
