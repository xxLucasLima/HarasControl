﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArasControl.Application.DTOs;
using MediatR;

namespace ArasControl.Application.Queries.Animal
{
    public class ListAnimalsByOwnerQuery : IRequest<IEnumerable<AnimalDto>>
    {
        public Guid OwnerId { get; set; }
        public ListAnimalsByOwnerQuery(Guid ownerId)
        {
            OwnerId = ownerId;
        }
    }
}
