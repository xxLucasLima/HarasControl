using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArasControl.Domain.Entities;

namespace ArasControl.Domain.Interfaces
{
    public interface IFeedInventoryRepository
    {
        Task<FeedInventory> GetByAnimalIdAsync(Guid animalId);
        Task AddAsync(FeedInventory inventory);
        Task UpdateAsync(FeedInventory inventory);
    }
}
