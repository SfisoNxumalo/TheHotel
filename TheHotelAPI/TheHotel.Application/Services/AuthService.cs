using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using TheHotel.Application.Interfaces;
using TheHotel.Application.Models;
using TheHotel.Application.ServiceCustomExceptions;
using TheHotel.Domain.DTOs;
using TheHotel.Domain.DTOs.UserDTO;
using TheHotel.Domain.Entities;
using TheHotel.Domain.Interfaces.Integrations;
using TheHotel.Domain.Interfaces.Repositories;
using PasswordVerificationResult = Microsoft.AspNetCore.Identity.PasswordVerificationResult;

namespace TheHotel.Application.Services
{
    // Handles all authentication-related business logic for the application.
    // This service manages user and staff login flows, password verification,
    // JWT access/refresh token generation, and user registration. It acts as
    // the middle layer between controllers and the auth repository, enforcing
    // validation, error handling, and security-related rules.
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepo;
        private readonly ITokenService _tokenService;
        private readonly ILogger<AuthService> _logger;
        public AuthService(IAuthRepository authRepo, ITokenService tokenService, ILogger<AuthService> logger)
        {
            _authRepo = authRepo;
            _tokenService = tokenService;
            _logger = logger;
        }

        public async Task<AuthModel> Login(AuthDTO user)
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

            var userLogin = await _authRepo.GetUserDetailsByEmailAsync(user.email);

            StaffEntity staffLogin = null;

            if (userLogin == null)
                 staffLogin = await _authRepo.GetStaffDetailsByEmailAsync(user.email);

            if (userLogin == null && staffLogin == null)
            {
                _logger.LogError($"User ${userLogin.Id} found");
                throw new NotFoundException("A user with the entered details was not found");
            }

            AuthModel userFound = null;

            if (userLogin != null)
            {
                userFound = UserSetup(userLogin, user.password);
            }
            else
            {
                userFound = StaffSetup(staffLogin, user.password);
            }

            return userFound;
        }

        internal AuthModel UserSetup(UserEntity userLogin, string userPassword)
        {
            var hasher = new PasswordHasher<UserEntity>();
            var result = hasher.VerifyHashedPassword(userLogin, userLogin.PasswordHash, userPassword);

            if (result == PasswordVerificationResult.Failed)
                throw new IncorrectPassword("Invalid credentials");

            var userLoginDetails = new UserDetailsDTO
            {
                Id = userLogin.Id,
                Email = userLogin.Email,
                FullName = userLogin.FullName,
                PhoneNumber = userLogin.PhoneNumber,
                Role = userLogin.Role,
            };

            userLoginDetails.Token = _tokenService.GenerateAccessToken(userLoginDetails);
            var refreshtoken = _tokenService.GenerateRefreshToken(userLogin.Id);

            var userDetails = new AuthModel
            {
                UserDetails = userLoginDetails,
                RefreshToken = refreshtoken
            };

            return userDetails;
        }

        internal AuthModel StaffSetup(StaffEntity staffLogin, string userPassword)
        {
            var hasher = new PasswordHasher<StaffEntity>();
            var result = hasher.VerifyHashedPassword(staffLogin, staffLogin.PasswordHash, userPassword);

            if (result == PasswordVerificationResult.Failed)
                throw new IncorrectPassword("Invalid credentials");

            var staffLoginDetails = new UserDetailsDTO
            {
                Id = staffLogin.Id,
                Email = staffLogin.Email,
                FullName = staffLogin.FullName,
                PhoneNumber = staffLogin.PhoneNumber,
                Role = staffLogin.Role,
            };

            staffLoginDetails.Token = _tokenService.GenerateAccessToken(staffLoginDetails);
            var refreshtoken = _tokenService.GenerateRefreshToken(staffLogin.Id);

            var userDetails = new AuthModel
            {
                UserDetails = staffLoginDetails,
                RefreshToken = refreshtoken
            };

            return userDetails;
        }

        public async Task<string> RefreshAsync(string? refreshToken)
        {
            var userEmail = _tokenService.RefreshAsync(refreshToken);

            if(userEmail == null)
                throw new NotFoundException("A user with the entered details was not found");

            var user = await _authRepo.GetUserDetailsByEmailAsync(userEmail);

            if (user == null)
            {
                _logger.LogError($"User ${user.Id} found");
                throw new NotFoundException("A user with the entered details was not found");
            }

            var userLoginDetails = new UserDetailsDTO
            {
                Id = user.Id,
                Email = user.Email,
                FullName = user.FullName,
                PhoneNumber = user.PhoneNumber,
            };

            var token = _tokenService.GenerateAccessToken(userLoginDetails);

            return token;
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

            var existingUser = await _authRepo.GetUserDetailsByEmailAsync(newUser.Email);

            if (existingUser != null)
                throw new DuplicateRecordException($"A user with email '{newUser.Email}' already exists.");

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
