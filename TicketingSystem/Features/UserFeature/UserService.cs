using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TicketingSystem.Features.DepartmentFeature;
using TicketingSystem.Features.UserFeature.Dtos;
using TicketingSystem.Features.UserFeature.Interfaces;
using TicketingSystem.Shared.Common;
using TicketingSystem.Shared.Data;
using TicketingSystem.Shared.Interfaces;
using static TicketingSystem.Features.UserFeature.UserSpecifications;

namespace TicketingSystem.Features.UserFeature
{
    public class UserService : IUserService
    {
        private readonly ILogger<UserService> _Logger;

        private readonly ApplicationDBContext _context;
        public UserService(IUnitOfWork unitOfWork,ILogger<UserService> logger,ApplicationDBContext context)
        {
            _Logger = logger;
            _context = context;
        }
        public async Task<ServiceResponse<User>> AddDepartmentToUser(int UserId, int DepartmentId)
        {
            _Logger.LogInformation("logger works");


            Department? department = await _context.Departments.FirstOrDefaultAsync(d => d.Id == DepartmentId);
            User? user = await _context.Users
                                      .Include(u => u.Departments ) 
                                      .FirstOrDefaultAsync(u => u.Id == UserId);

            if (user is null|| department is null)
            {

                return new ServiceResponse<User>(false, "User or Department doesn't exist");

            }

            if (user.Departments is null)
            {
                user.Departments = new List<Department>();
            }

            if (user.Departments.Any(d => d.Id == DepartmentId))
            {

                return new ServiceResponse<User>(false, "User already in Department");
            }

            user.Departments.Add(department);

            await _context.SaveChangesAsync();

            return new ServiceResponse<User>(true, user, "Department Added Succesfully");
        }

        public async Task<ServiceResponse<UserResponseDTO>> GetUserData(int UserId)
        {
            UserResponseDTO? user = await _context.Users
                                                  .Select(d =>
                                                          new UserResponseDTO()
                                                          {
                                                              Id = d.Id,
                                                              email = d.AuthUser!.Email,
                                                              role = d.role,
                                                              UserName = d.UserName

                                                          }
                                                    ).FirstOrDefaultAsync(d => d.Id == UserId);
            if (user is null) { 
                return new ServiceResponse<UserResponseDTO>(false, "User doesn't exist");
            }

            return new ServiceResponse<UserResponseDTO>(true, user, "User Data");
        }
    }
}
