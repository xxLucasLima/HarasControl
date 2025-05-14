using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArasControl.Domain.Entities;
using ArasControl.Domain.Interfaces;
using ArasControl.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ArasControl.Infrastructure.Repositories
{
    public class FeedInventoryRepository : IFeedInventoryRepository
    {
        private readonly AppDbContext _context;

        public FeedInventoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<FeedInventory> GetByAnimalIdAsync(Guid animalId)
        {
            return await _context.FeedInventories
                .FirstOrDefaultAsync(fi => fi.AnimalId == animalId);
        }

        public async Task AddAsync(FeedInventory inventory)
        {
            _context.FeedInventories.Add(inventory);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(FeedInventory inventory)
        {
            _context.FeedInventories.Update(inventory);
            await _context.SaveChangesAsync();
        }
    }
}
