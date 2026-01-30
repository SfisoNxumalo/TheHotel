using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheHotel.Domain.DTOs.UserDTO
{
    public class AddUserDTO
    {
        [Required]
        public string FullName { get; set; } = null!;

        [Required]
        public string Email { get; set; } = null!;

        [Required]
        public string PhoneNumber { get; set; }

        [Required]

        public string Password { get; set; }

    }
}
