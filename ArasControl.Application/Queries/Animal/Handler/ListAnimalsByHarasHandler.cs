﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArasControl.Application.DTOs;
using ArasControl.Domain.Interfaces;
using MediatR;

namespace ArasControl.Application.Queries.Animal.Handler
{
    public class ListAnimalsByHarasHandler : IRequestHandler<ListAnimalsByHarasQuery, IEnumerable<AnimalDto>>
    {
        private readonly IAnimalRepository _repo;

        public ListAnimalsByHarasHandler(IAnimalRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<AnimalDto>> Handle(ListAnimalsByHarasQuery request, CancellationToken cancellationToken)
        {
            var animals = await _repo.ListByHarasAsync(request.HarasId);
            return animals.Select(a => new AnimalDto
            {
                Name = a.Name,
                Breed = a.Breed,
                Color = a.Color,
                WeightKg = a.Dimensions.WeightKg,
                HeightCm = a.Dimensions.HeightCm,
                HarasId = a.HarasId,
                OwnerId = a.OwnerId,
                DateOfBirth = a.DateOfBirth,
                Sex = a.Sex,
                MicrochipId = a.MicrochipId,
                RegistrationNumber = a.RegistrationNumber,
                Temperament = a.Temperament,
                MedicalHistory = a.MedicalHistory
            });
        }
    }
}