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
    public class AnimalRepository : IAnimalRepository
    {
        private readonly AppDbContext _context;

        public AnimalRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Animal> GetByIdAsync(Guid id)
        {
            return await _context.Animals
                .Include(a => a.FeedRecords)
                .Include(a => a.VaccineRecords)
                .Include(a => a.VitaminDoses)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<Animal>> ListByOwnerAsync(Guid ownerId)
        {
            return await _context.Animals
                .Where(a => a.OwnerId == ownerId)
                .ToListAsync();
        }

        public async Task AddAsync(Animal animal)
        {
            _context.Animals.Add(animal);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Animal animal)
        {
            _context.Animals.Update(animal);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(Animal animal)
        {
            _context.Animals.Remove(animal);
            await _context.SaveChangesAsync();
        }

        public async Task AddFeedRecordAsync(FeedRecord record)
        {
            _context.FeedRecords.Add(record);
            await _context.SaveChangesAsync();
        }

        public async Task AddVaccineRecordAsync(VaccineRecord record)
        {
            _context.VaccineRecords.Add(record);
            await _context.SaveChangesAsync();
        }

        public async Task AddVitaminDoseAsync(VitaminDose dose)
        {
            _context.VitaminDoses.Add(dose);
            await _context.SaveChangesAsync();
        }
    }
}
