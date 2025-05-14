using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArasControl.Domain.Entities;

namespace ArasControl.Domain.Interfaces
{
    public interface IHarasOwnerRepository
    {
        Task<HarasOwner> GetByIdAsync(Guid id);
        Task<IEnumerable<HarasOwner>> ListAsync();
        Task AddAsync(HarasOwner owner);
        Task UpdateAsync(HarasOwner owner);
        Task RemoveAsync(HarasOwner owner);
    }
}
