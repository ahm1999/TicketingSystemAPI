using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TicketingSystem.Features.DepartmentFeature.DTOs;
using TicketingSystem.Features.UserFeature;
using TicketingSystem.Shared.Common;
using TicketingSystem.Shared.Interfaces;

namespace TicketingSystem.Features.DepartmentFeature
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public DepartmentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost("AddDepartment")]
        [Authorize(Roles =RolesConsts.Admin)]
        public async Task<IActionResult> AddDepartment(AddDepartmentDTO dTO)
        {
            var department = new Department()
            {
                Name = dTO.Name
            };

            department = await _unitOfWork.DepartmentRepository.Create(department);

            await _unitOfWork.SaveChangesAsync();
            var respDepartment = new DepartmentResponseDTO()
            {
                Id = department.Id,
                Name = department.Name
            };

            var response = new ServiceResponse<DepartmentResponseDTO>(true, respDepartment, "Department Added");

            return Ok(response);

        }
    }
}
