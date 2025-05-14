using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArasControl.Domain.Entities;

namespace ArasControl.Domain.Interfaces
{
    public interface IHarasRepository
    {
        Task<Haras> GetByIdAsync(Guid id);
        Task<IEnumerable<Haras>> ListAsync();
        Task AddAsync(Haras haras);
        Task UpdateAsync(Haras haras);
        Task RemoveAsync(Haras haras);
    }
}
