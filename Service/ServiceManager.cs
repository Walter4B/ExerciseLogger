using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.Contracts;
using Contracts;

namespace Service
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IGymService> _gymService;
        private readonly Lazy<IExerciseService> _exerciseService;

        public ServiceManager (IRepositoryManager repositoryManager, ILoggerManager loggerManager)
        {
            _gymService = new Lazy<IGymService>(() => new GymService(repositoryManager, loggerManager));
            _exerciseService = new Lazy<IExerciseService>(() => new ExerciseService(repositoryManager, loggerManager));
        }

        public IGymService GymService => _gymService.Value;
        public IExerciseService ExerciseService => _exerciseService.Value;
    }
}
