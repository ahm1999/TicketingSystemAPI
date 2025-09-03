using TicketingSystem.Features.DepartmentFeature.DTOs;
using TicketingSystem.Shared.Common;

namespace TicketingSystem.Features.DepartmentFeature.Interfaces
{
    public interface IDepartmentService
    {

        Task<ServiceResponse<DepartmentResponseDTO>> AddDepartment(AddDepartmentDTO dto);


        Task<ServiceResponse<List<DepartmentResponseDTO>>> GetAllDepartments (string? searchQuery);
    }
}
