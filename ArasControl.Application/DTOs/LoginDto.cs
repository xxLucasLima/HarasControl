using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArasControl.Application.DTOs
{
    public class LoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class LoginResponse
    {
        public string Token { get; set; }
        public DateTime ExpiresAt { get; set; }
    }

    public class RegisterRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public Guid? AnimalOwnerId { get; set; }
        public Guid? HarasOwnerId { get; set; }
        public Guid? HarasId { get; set; }
        public string RoleType { get; set; }
    }
}
