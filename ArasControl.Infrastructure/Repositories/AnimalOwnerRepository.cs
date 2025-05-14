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
    public class AnimalOwnerRepository : IAnimalOwnerRepository
    {
        private readonly AppDbContext _context;

        public AnimalOwnerRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<AnimalOwner> GetByIdAsync(Guid id)
        {
            return await _context.AnimalOwners
                .Include(o => o.Animals)
                .FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<IEnumerable<AnimalOwner>> ListByHarasAsync(Guid harasId)
        {
            return await _context.AnimalOwners
                .Where(o => o.HarasId == harasId)
                .ToListAsync();
        }

        public async Task AddAsync(AnimalOwner owner)
        {
            _context.AnimalOwners.Add(owner);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(AnimalOwner owner)
        {
            _context.AnimalOwners.Update(owner);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(AnimalOwner owner)
        {
            _context.AnimalOwners.Remove(owner);
            await _context.SaveChangesAsync();
        }
    }
}
