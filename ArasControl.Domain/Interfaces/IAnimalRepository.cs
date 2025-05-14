using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArasControl.Domain.Entities;

namespace ArasControl.Domain.Interfaces
{
    public interface IAnimalRepository
    {
        /// <summary>Recupera um animal pelo identificador.</summary>
        Task<Animal> GetByIdAsync(Guid id);

        /// <summary>Lista todos os animais de um determinado dono.</summary>
        Task<IEnumerable<Animal>> ListByOwnerAsync(Guid ownerId);

        /// <summary>Adiciona um novo animal.</summary>
        Task AddAsync(Animal animal);

        /// <summary>Atualiza os dados de um animal existente.</summary>
        Task UpdateAsync(Animal animal);

        /// <summary>Remove um animal do repositório.</summary>
        Task RemoveAsync(Animal animal);

        /// <summary>Adiciona um registro de alimentação (FeedRecord) para o animal.</summary>
        Task AddFeedRecordAsync(FeedRecord record);

        /// <summary>Adiciona um registro de vacina (VaccineRecord) para o animal.</summary>
        Task AddVaccineRecordAsync(VaccineRecord record);

        /// <summary>Adiciona um registro de vitamina (VitaminDose) para o animal.</summary>
        Task AddVitaminDoseAsync(VitaminDose dose);
    }
}
