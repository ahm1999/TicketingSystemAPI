using Microsoft.EntityFrameworkCore;
using TicketingSystem.Features.DepartmentFeature.DTOs;
using TicketingSystem.Features.DepartmentFeature.Interfaces;
using TicketingSystem.Shared.Common;
using TicketingSystem.Shared.Data;

namespace TicketingSystem.Features.DepartmentFeature
{
    public class DepartmentService : IDepartmentService
    {
        private readonly ApplicationDBContext _context;

        public DepartmentService(ApplicationDBContext context)
        {
            _context = context;
        }
        public Task<ServiceResponse<DepartmentResponseDTO>> AddDepartment(AddDepartmentDTO dto)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<List<DepartmentResponseDTO>>> GetAllDepartments(string? searchQuery)
        {
            var query = _context.Departments.AsQueryable(); 
            if (!string.IsNullOrWhiteSpace(searchQuery))
            {
                query = query.Where(d => d.Name!.StartsWith(searchQuery.Trim().ToLower()));
            }

            var Response = await query.Select<Department, DepartmentResponseDTO>(d =>
              new DepartmentResponseDTO()
              {
                  Name = d.Name,
                  Id = d.Id
              }).ToListAsync();
           

          

            return new ServiceResponse<List<DepartmentResponseDTO>>(true, Response, "Departments Retrieved Succsefully");
        }
    }
}
