using Microsoft.AspNetCore.Identity;

namespace ArasControl.Domain.Entities.Auth
{
    public class ApplicationUser : IdentityUser
    {
        public Guid? AnimalOwnerId { get; set; }
        public Guid? HarasOwnerId { get; set; }
        public string RoleType { get; set; } // "AnimalOwner" ou "HarasOwner"
    }
}

