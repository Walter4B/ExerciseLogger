using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.Contracts;
using Contracts;

namespace Service
{
    internal sealed class ExerciseService : IExerciseService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _loggerManager;

        public ExerciseService(IRepositoryManager repository, ILoggerManager logger)
        { 
            _repositoryManager = repository;
            _loggerManager = logger;
        }
    }
}
