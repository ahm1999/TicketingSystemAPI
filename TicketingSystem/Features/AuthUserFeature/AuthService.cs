﻿using System.Runtime.CompilerServices;
using TicketingSystem.Features.AuthUserFeature.DTOs;
using TicketingSystem.Features.AuthUserFeature.interfaces;
using TicketingSystem.Features.UserFeature;
using TicketingSystem.Shared.Common;
using TicketingSystem.Shared.Interfaces;
using TicketingSystem.Shared.Utils;
using static TicketingSystem.Features.AuthUserFeature.Specifications.AuthUserSpecifcation;

namespace TicketingSystem.Features.AuthUserFeature
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IPasswordHashing _passwordHashing;
        public AuthService(IUnitOfWork unitOfWork,IPasswordHashing passwordHashing)
        {
            _unitOfWork = unitOfWork;
            _passwordHashing = passwordHashing;

        }

        public async Task<ServiceResponse<LogInResponse>> LogInAsync(LogInDTO dto)
        {
            var emailspec = new FindByEmailSpecification(dto.Email!);

            List<AuthUser> users = await _unitOfWork.AuthUserRepository.ListAsync(emailspec);

            if (users.Count == 0)
            {

                return new ServiceResponse<LogInResponse>(false, "A user with that email doesn't exist");

            }

            var authuser = users[0];

            //matching the password with the hash 
            
            //wrong password rout
            if (!_passwordHashing.ValidatePassword(authuser.PasswordHash!, dto.Password))
            {
                return new ServiceResponse<LogInResponse>(false, "wrong Password");
            }

            //right password route

                        
            return new ServiceResponse<LogInResponse>(true, new LogInResponse("token") ,"Log In succesful");

        }

        public async Task<ServiceResponse<SignUpResponse>> SignUpAsync(SignUpDTO dto)
        {
           
            //check if any users are registerd to the same email

            var emailspec = new FindByEmailSpecification(dto.Email!);

            List<AuthUser> users = await _unitOfWork.AuthUserRepository.ListAsync(emailspec);

            if (users.Count != 0) {

                return new ServiceResponse<SignUpResponse>(false, "A user with that email already registerd");
            
            }

            AuthUser authUser = new AuthUser()
            {
                Email = dto.Email,
                //add Hash functionality
                PasswordHash = _passwordHashing.HashPassword(dto.Password!)
            };


            //register AuthUser 

            await _unitOfWork.AuthUserRepository.Create(authUser);

            await _unitOfWork.SaveChangesAsync();

            User relatedAppUser = new User()
            {
                AuthUserId = authUser.Id,
                UserName = dto.UserName
            };

            //register User

            await _unitOfWork.UserRepository.Create(relatedAppUser);

            await _unitOfWork.SaveChangesAsync();

            return new ServiceResponse<SignUpResponse>(true,
                new SignUpResponse()
                {
                    UserId = relatedAppUser.Id,
                    UserName = relatedAppUser.UserName
                }
                ,
                "User Added Succefully");
            //Hash password


            //throw new NotImplementedException();

        }
    }
}
