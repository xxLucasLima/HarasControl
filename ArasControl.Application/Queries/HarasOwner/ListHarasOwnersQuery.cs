﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArasControl.Application.DTOs;
using MediatR;

namespace ArasControl.Application.Queries.HarasOwner
{
    public class ListHarasOwnersQuery : IRequest<IEnumerable<HarasOwnerDto>>
    {
    }
}
