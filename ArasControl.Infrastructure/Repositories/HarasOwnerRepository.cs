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
    public class HarasOwnerRepository : IHarasOwnerRepository
    {
        private readonly AppDbContext _context;

        public HarasOwnerRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<HarasOwner> GetByIdAsync(Guid id)
        {
            return await _context.HarasOwners.FindAsync(id);
        }

        public async Task<IEnumerable<HarasOwner>> ListAsync()
        {
            return await _context.HarasOwners.ToListAsync();
        }

        public async Task AddAsync(HarasOwner owner)
        {
            _context.HarasOwners.Add(owner);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(HarasOwner owner)
        {
            _context.HarasOwners.Update(owner);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(HarasOwner owner)
        {
            _context.HarasOwners.Remove(owner);
            await _context.SaveChangesAsync();
        }
    }
}
