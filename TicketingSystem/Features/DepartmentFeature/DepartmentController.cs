using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TicketingSystem.Features.DepartmentFeature.DTOs;
using TicketingSystem.Features.DepartmentFeature.Interfaces;
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
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IUnitOfWork unitOfWork,IDepartmentService departmentService)
        {
            _unitOfWork = unitOfWork;
            _departmentService = departmentService;
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


        [HttpGet]
        [Authorize]

        public async Task<IActionResult> GetAllDepartments([FromQuery]string? searchQuery) {

            var Response = await _departmentService.GetAllDepartments(searchQuery);

            if (!Response.Success)
            {
                return BadRequest(Response);
            }
            return Ok(Response);

        }
    }
}
