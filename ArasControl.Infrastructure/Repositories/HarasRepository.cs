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
    public class HarasRepository : IHarasRepository
    {
        private readonly AppDbContext _context;

        public HarasRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Haras> GetByIdAsync(Guid id)
        {
            return await _context.Haras.FindAsync(id);
        }

        public async Task<IEnumerable<Haras>> ListAsync()
        {
            return await _context.Haras.ToListAsync();
        }

        public async Task AddAsync(Haras haras)
        {
            _context.Haras.Add(haras);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Haras haras)
        {
            _context.Haras.Update(haras);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(Haras haras)
        {
            _context.Haras.Remove(haras);
            await _context.SaveChangesAsync();
        }
    }
}
