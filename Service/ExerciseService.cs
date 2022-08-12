using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.Contracts;
using Contracts;
using AutoMapper;
using Shared.DataTransferObjects;
using Entities.Exceptions;

namespace Service
{
    internal sealed class ExerciseService : IExerciseService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _loggerManager;
        private readonly IMapper _mapper;

        public ExerciseService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        { 
            _repositoryManager = repository;
            _loggerManager = logger;
            _mapper = mapper;
        }

        public IEnumerable<ExerciseDto> GetExercises(Guid gymId, bool trackChanges)
        {
            var gym = _repositoryManager.Gym.GetGym(gymId, trackChanges);
            if (gym is null)
                throw new GymNotFoundException(gymId);

            var exercisesFromDb = _repositoryManager.Exercise.GetExercises(gymId, trackChanges);

            var exercisesDto = _mapper.Map<IEnumerable<ExerciseDto>>(exercisesFromDb);

            return exercisesDto;

        }
    }
}
