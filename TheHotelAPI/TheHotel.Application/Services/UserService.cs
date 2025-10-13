using TheHotel.Application.Interfaces;
using TheHotel.Domain.DTOs.UserDTO;
using TheHotel.Domain.Entities;
using TheHotel.Domain.Interfaces;

namespace TheHotel.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<UserEntity>> GetAllUsersAsync()
        {

           return await _userRepository.GetAllAsync();
        }
        public async Task<UserEntity?> GetUserByIdAsync(Guid id)
        {
          return await _userRepository.GetByIdAsync(id);
        }
        public async Task<UserEntity> AddUserAsync(AddUserDTO user)
        {
            var newUser = new UserEntity
            {
                FullName = user.FullName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
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
    }
}
