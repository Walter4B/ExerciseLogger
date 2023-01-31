using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.Contracts;
using Contracts;
using Entities.Models;
using Shared.DataTransferObjects;
using AutoMapper;
using Entities.Exceptions;

namespace Service
{
    internal sealed class GymService : IGymService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _loggerManager;
        private readonly IMapper _mapper;

        public GymService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        { 
            _repositoryManager = repository;
            _loggerManager = logger;
            _mapper = mapper;

        }

        public async Task<IEnumerable<GymDto>> GetAllGymsAsync(bool trackChanges)
        {

            var gyms = await _repositoryManager.Gym.GetAllGymsAsync(trackChanges);

            var gymDtos = _mapper.Map<IEnumerable<GymDto>>(gyms);

            return gymDtos;

        }

        public async Task<GymDto> GetGymAsync(Guid id, bool trackingChanges)
        {
            var gym = await _repositoryManager.Gym.GetGymAsync(id, trackingChanges);
            if (gym is null)
                throw new GymNotFoundException(id);

            var gymDto = _mapper.Map<GymDto>(gym);

            return gymDto;
        }

        public async Task<GymDto> CreateGymAsync(GymForCreationDto gym)
        { 
            var gymEntity = _mapper.Map<Gym> (gym);

            _repositoryManager.Gym.CreateGym(gymEntity);
            await _repositoryManager.SaveAsync();

            var gymToReturn = _mapper.Map<GymDto>(gymEntity);

            return gymToReturn;
        }

        public async Task<IEnumerable<GymDto>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges)
        {
            if (ids is null)
            {
                throw new IdParametersBadRequestException();
            }

            var gymEntities = await _repositoryManager.Gym.GetByIdsAsync(ids, trackChanges);
            if (ids.Count() != gymEntities.Count())
            {
                throw new CollectionByIdsBadRequestException();
            }

            var gymsToReturn = _mapper.Map<IEnumerable<GymDto>>(gymEntities);

            return gymsToReturn;
        }

        public async Task<(IEnumerable<GymDto> gyms, string ids)> CreateGymCollectionAsync(IEnumerable<GymForCreationDto> gymCollection)
        {
            if (gymCollection is null)
            {
                throw new GymCollectionBadRequest();
            }

            var gymEntities = _mapper.Map<IEnumerable<Gym>>(gymCollection);

            foreach (var gym in gymEntities)
            {
                _repositoryManager.Gym.CreateGym(gym);
            }

            await _repositoryManager.SaveAsync();

            var gymCollectionToReturn = _mapper.Map<IEnumerable<GymDto>>(gymEntities);
            var ids = string.Join(",", gymCollectionToReturn.Select(g => g.Id));

            return (gyms: gymCollectionToReturn, ids: ids);
        }

        public async Task DeleteGymAsync(Guid gymId, bool trackChanges) 
        {
            var gym = await _repositoryManager.Gym.GetGymAsync(gymId, trackChanges);
            if(gym is null)
            {
                throw new GymNotFoundException(gymId);
            }

            _repositoryManager.Gym.DeleteGym(gym);
            await _repositoryManager.SaveAsync();
        }

        public async Task UpdateGymAsync(Guid gymId, GymForUpdateDto gymForUpdate, bool trackChanges)
        {
            var gymEntity = await _repositoryManager.Gym.GetGymAsync(gymId, trackChanges);
            if (gymEntity is null)
            {
                throw new GymNotFoundException(gymId);
            }

            _mapper.Map(gymForUpdate, gymEntity);
            await _repositoryManager.SaveAsync();

        }
    }
}
