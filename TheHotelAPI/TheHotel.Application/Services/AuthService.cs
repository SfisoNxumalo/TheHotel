using Microsoft.AspNetCore.Identity;
using TheHotel.Application.Interfaces;
using TheHotel.Application.ServiceCustomExceptions;
using TheHotel.Domain.DTOs;
using TheHotel.Domain.DTOs.UserDTO;
using TheHotel.Domain.Entities;
using TheHotel.Domain.Interfaces.Integrations;
using TheHotel.Domain.Interfaces.Repositories;
using PasswordVerificationResult = Microsoft.AspNetCore.Identity.PasswordVerificationResult;

namespace TheHotel.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepo;
        private readonly ITokenService _tokenService;
        public AuthService(IAuthRepository authRepo, ITokenService tokenService)
        {
            _authRepo = authRepo;
            _tokenService = tokenService;
        }

        public async Task<UserDetailsDTO> Login(AuthDTO user)
        {
            if (user == null)
            {
                throw new NoContentException("Email and password are required");
            }

            if (string.IsNullOrWhiteSpace(user.email) || string.IsNullOrWhiteSpace(user.password))
            {
                throw new NoContentException(
                   string.IsNullOrWhiteSpace(user.email) ? "Email is required" : "Password is required"
                );
            }

            var userLogin = await _authRepo.GetUserDetailsByEmailAsync(user);

            
            if (userLogin == null)
            {
                throw new NotFoundException("A user with the entered details was not found");
            }

            var hasher = new PasswordHasher<UserEntity>();
            var result = hasher.VerifyHashedPassword(userLogin, userLogin.PasswordHash, user.password);

            if (result == PasswordVerificationResult.Failed)
                throw new Exception("Invalid credentials");

            var userLoginDetails = new UserDetailsDTO
            {
                Id = userLogin.Id,
                Email = userLogin.Email,
                FullName = userLogin.FullName,
                PhoneNumber = userLogin.PhoneNumber,
            };

            userLoginDetails.Token = await _tokenService.EncodeToken(userLoginDetails);

            return userLoginDetails;
        }

        public async Task<bool> Register(AddUserDTO newUser)
        {
            if (newUser == null)
            {
                throw new NoContentException("Email and password are required");
            }

            if (string.IsNullOrWhiteSpace(newUser.Email) || string.IsNullOrWhiteSpace(newUser.Password))
            {
                throw new NoContentException("Please insert all the required fields");
            }

            //if (string.IsNullOrEmpty(newUser))
            //{
            //    userEntity.Uid = Convert.ToString(Guid.NewGuid())!;
            //}

            var User = new UserEntity
            {
                FullName = newUser.FullName,
                Email = newUser.Email,
                PasswordHash = newUser.Password,
                PhoneNumber = newUser.PhoneNumber,
            };

            var hasher = new PasswordHasher<UserEntity>();
            User.PasswordHash = hasher.HashPassword(User, User.PasswordHash);

            var userRegistered = await _authRepo.Register(User);

            if (!userRegistered)
            {
                throw new NotFoundException("User registration failed");
            }

            return true;
        }
    }
}
