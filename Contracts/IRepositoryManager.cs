﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositoryManager
    {
        IGymRepository Gym { get; }
        IExerciseRepository Exercise { get; }

        void Save();
    }
}