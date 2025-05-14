using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArasControl.Domain.Entities;

namespace ArasControl.Domain.Interfaces
{
    public interface IAnimalOwnerRepository
    {
        Task<AnimalOwner> GetByIdAsync(Guid id);
        Task<IEnumerable<AnimalOwner>> ListByHarasAsync(Guid harasId);
        Task AddAsync(AnimalOwner owner);
        Task UpdateAsync(AnimalOwner owner);
        Task RemoveAsync(AnimalOwner owner);
    }
}
