using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheHotel.Domain.DTOs.UserDTO
{
    public class UserDetailsDTO
    {

        public Guid Id { get; set; }

        public required string FullName { get; set; }

        [Required]
        public required string Email { get; set; }

        [Required]
        public required string PhoneNumber { get; set; }

        public string Token { get; set; }
    }
}
