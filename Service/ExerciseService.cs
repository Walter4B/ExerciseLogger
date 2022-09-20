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
using Entities.Models;

namespace Service
{
    internal sealed class ExerciseService : IExerciseService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _loggerManager;
        private readonly IMapper _mapper;

        public ExerciseService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        { 
            _repository = repository;
            _loggerManager = logger;
            _mapper = mapper;
        }

        public IEnumerable<ExerciseDto> GetExercises(Guid gymId, bool trackChanges)
        {
            var gym = _repository.Gym.GetGym(gymId, trackChanges);
            if (gym is null)
                throw new GymNotFoundException(gymId);

            var exercisesFromDb = _repository.Exercise.GetExercises(gymId, trackChanges);

            var exercisesDto = _mapper.Map<IEnumerable<ExerciseDto>>(exercisesFromDb);

            return exercisesDto;

        }

        public ExerciseDto GetExercise(Guid gymId, Guid id, bool trackChanges)
        {
            var gym = _repository.Gym.GetGym(gymId, trackChanges);
            if (gym is null)
                throw new GymNotFoundException(gymId);

            var exerciseDb = _repository.Exercise.GetExercise(gymId, id, trackChanges);
            if (exerciseDb is null)
                throw new ExerciseNotFoundException(id);

            var exercise = _mapper.Map<ExerciseDto>(exerciseDb);
            return exercise;
        }

        public ExerciseDto CreateExerciseForGym(Guid gymId, ExerciseForCreationDto exerciseForCreation, bool trackingChanges)
        {
            var gym = _repository.Gym.GetGym(gymId, trackingChanges);

            if (gym is null)
            {
                throw new GymNotFoundException(gymId);
            }

            var exerciseEntity = _mapper.Map<Exercise>(exerciseForCreation);

            _repository.Exercise.CreateExerciseForGym(gymId, exerciseEntity);
            _repository.Save();

            var exerciseToReturn = _mapper.Map<ExerciseDto>(exerciseEntity);

            return exerciseToReturn;
        }
    }
}
