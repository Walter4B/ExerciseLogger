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
using System.Runtime.CompilerServices;

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

        public async Task<IEnumerable<ExerciseDto>> GetExercisesAsync(Guid gymId, bool trackChanges)
        {
            var gym = await _repository.Gym.GetGymAsync(gymId, trackChanges);
            if (gym is null)
                throw new GymNotFoundException(gymId);

            var exercisesFromDb = await _repository.Exercise.GetExercisesAsync(gymId, trackChanges);

            var exercisesDto = _mapper.Map<IEnumerable<ExerciseDto>>(exercisesFromDb);

            return exercisesDto;

        }

        public async Task<ExerciseDto> GetExerciseAsync(Guid gymId, Guid id, bool trackChanges)
        {
            var gym = await _repository.Gym.GetGymAsync(gymId, trackChanges);
            if (gym is null)
                throw new GymNotFoundException(gymId);

            var exerciseDb = await _repository.Exercise.GetExerciseAsync(gymId, id, trackChanges);
            if (exerciseDb is null)
                throw new ExerciseNotFoundException(id);

            var exercise = _mapper.Map<ExerciseDto>(exerciseDb);
            return exercise;
        }

        public async Task<ExerciseDto> CreateExerciseForGymAsync(Guid gymId, ExerciseForCreationDto exerciseForCreation, bool trackingChanges)
        {
            var gym = await _repository.Gym.GetGymAsync(gymId, trackingChanges);

            if (gym is null)
            {
                throw new GymNotFoundException(gymId);
            }

            var exerciseEntity = _mapper.Map<Exercise>(exerciseForCreation);

            _repository.Exercise.CreateExerciseForGym(gymId, exerciseEntity);
            await _repository.SaveAsync();

            var exerciseToReturn = _mapper.Map<ExerciseDto>(exerciseEntity);

            return exerciseToReturn;
        }

        public async Task DeleteExerciseForGymAsync(Guid gymId, Guid id, bool trackChanges) 
        {
            var gym = await _repository.Gym.GetGymAsync(gymId, trackChanges);

            if(gym is null)
            {
                throw new GymNotFoundException(gymId);
            }

            var exerciseEntity = await _repository.Exercise.GetExerciseAsync(gymId, id, trackChanges);

            if (exerciseEntity is null)
            {
                throw new ExerciseNotFoundException(id);
            }

            _repository.Exercise.DeleteExercise(exerciseEntity);
            await _repository.SaveAsync();
        }

        public async Task UpdateExerciseForGymAsync(Guid gymId, Guid id, ExerciseForUpdateDto exerciseForUpdate, bool gymTrackChanges, bool exerTrackChanges)
        {
            var gym = await _repository.Gym.GetGymAsync(gymId, gymTrackChanges);
            if(gym is null) 
            {
                throw new GymNotFoundException(gymId);
            }

            var exerciseEntity = await _repository.Exercise.GetExerciseAsync(gymId, id, exerTrackChanges);
            if(exerciseEntity is null)
            {
                throw new ExerciseNotFoundException(id);
            }

            _mapper.Map(exerciseForUpdate, exerciseEntity);
            await _repository.SaveAsync();

        }

        public async Task<(ExerciseForUpdateDto exerciseToPatch, Exercise exerciseEntity)> GetExerciseForPatchAsync(Guid gymId, Guid id, bool gymTrackChanges, bool exerTrachChanges)
        {
            var gym = await _repository.Gym.GetGymAsync(gymId, gymTrackChanges);
            if(gym is null)
            {
                throw new GymNotFoundException(gymId);
            }

            var exerciseEntity = await _repository.Exercise.GetExerciseAsync(gymId, id, exerTrachChanges);
            if(exerciseEntity is null)
            {
                throw new ExerciseNotFoundException(id);
            }

            var exerciseToPatch = _mapper.Map<ExerciseForUpdateDto>(exerciseEntity);

            return (exerciseToPatch, exerciseEntity);
        }

        public async Task SaveChangesForPatchAsync(ExerciseForUpdateDto exerciseToPatch, Exercise exerciseEntity)
        {
            _mapper.Map(exerciseToPatch, exerciseEntity);
            await _repository.SaveAsync();
        }
    }
}
