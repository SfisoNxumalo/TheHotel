using Microsoft.Extensions.Logging;
using TheHotel.Application.Interfaces;
using TheHotel.Domain.DTOs.UserDTO;
using TheHotel.Domain.Entities;
using TheHotel.Domain.Interfaces.Repositories;

namespace TheHotel.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<UserService> _logger;

        public UserService(IUserRepository userRepository, ILogger<UserService> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }

        public async Task<IEnumerable<UserEntity>> GetAllUsersAsync()
        {

           return await _userRepository.GetAllAsync();
        }
        public async Task<UserEntity?> GetUserByIdAsync(Guid id)
        {
          return await _userRepository.GetByIdAsync(id);
        }

        public async Task<StaffEntity?> GetStaffByIdAsync(Guid id)
        {
            return await _userRepository.GetStaffByIdAsync(id);
        }

        public async Task<UserEntity> AddUserAsync(AddUserDTO user)
        {
            var newUser = new UserEntity
            {
                FullName = user.FullName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                PasswordHash = user.Password,
            };

           await _userRepository.AddAsync(newUser);
            return newUser;
        }
        public async Task UpdateUserAsync(UserEntity user)
        {
           await _userRepository.UpdateAsync(user);
        }
        public async Task DeleteUserAsync(Guid id)
        {
            await _userRepository.DeleteAsync(id);
        }

        public async Task<UserDetailsDTO?> GetUserAsync()
        {
            return await _userRepository.GetUserAsync();
        }

        public async Task<UserDetailsDTO?> GetStaffAsync()
        {
            return await _userRepository.GetStaffAsync();
        }
    }
}
