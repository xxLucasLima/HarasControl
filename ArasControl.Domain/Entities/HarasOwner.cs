using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArasControl.Domain.Entities
{
    public class HarasOwner
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }

        public HarasOwner(Guid id, string name, string email)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("Invalid HarasOwner Id.", nameof(id));
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name is required.", nameof(name));
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email is required.", nameof(email));

            Id = id;
            Name = name;
            Email = email;
        }

        public void UpdateContact(string name, string email)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name is required.", nameof(name));
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email is required.", nameof(email));

            Name = name;
            Email = email;
        }
    }
}
