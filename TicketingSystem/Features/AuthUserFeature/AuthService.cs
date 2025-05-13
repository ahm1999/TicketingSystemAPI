using System.Runtime.CompilerServices;
using TicketingSystem.Features.AuthUserFeature.DTOs;
using TicketingSystem.Features.AuthUserFeature.interfaces;
using TicketingSystem.Shared.Common;
using TicketingSystem.Shared.Interfaces;
using static TicketingSystem.Features.AuthUserFeature.Specifications.AuthUserSpecifcation;

namespace TicketingSystem.Features.AuthUserFeature
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AuthService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<ServiceResponse<LogInResponse>> LogInAsync(LogInDTO dto)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<SignUpResponse>> SignUpAsync(SignUpDTO dto)
        {
           
            //check if any users are registerd to the same email

            var emailspec = new FindByEmailSpecification(dto.Email!);

            List<AuthUser> users = await _unitOfWork.AuthUserRepository.ListAsync(emailspec);

            if (users.Count != 0) {

                return new ServiceResponse<SignUpResponse>(false, "A user with that email already registerd");
            
            }

            AuthUser authUser = new AuthUser() { 
                Email = dto.Email,
                //add Hash functionality
                PasswordHash =dto.Password
            };


            //register AuthUser 

            await _unitOfWork.AuthUserRepository.Create(authUser);
            await _unitOfWork.SaveChangesAsync();
            //register User

            return new ServiceResponse<SignUpResponse>(true,
                new SignUpResponse()
                {
                    UserId = authUser.Id,
                    UserName = "to be added"
                }
                ,
                "User Added Succefully");
            //Hash password


            //throw new NotImplementedException();

        }
    }
}
