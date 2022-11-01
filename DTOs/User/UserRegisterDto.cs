using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookClub_app.DTOs.User
{
    public class UserRegisterDto
    {
        public string Username { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;
        public string Firstname { get; set; } = string.Empty;

        public string Lastname { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;
    }
}