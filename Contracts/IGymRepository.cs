﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;

namespace Contracts
{
    public interface IGymRepository
    {
        IEnumerable<Gym> GetAllGyms(bool trackChanges);
        Gym GetGym(Guid gymId, bool trackChanges);
    }
}
