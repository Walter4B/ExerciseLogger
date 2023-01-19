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

        public IEnumerable<GymDto> GetAllGyms(bool trackChanges)
        {

            var gyms = _repositoryManager.Gym.GetAllGyms(trackChanges);

            var gymDtos = _mapper.Map<IEnumerable<GymDto>>(gyms);

            return gymDtos;

        }

        public GymDto GetGym(Guid id, bool trackingChanges)
        {
            var gym = _repositoryManager.Gym.GetGym(id, trackingChanges);
            if (gym is null)
                throw new GymNotFoundException(id);

            var gymDto = _mapper.Map<GymDto>(gym);

            return gymDto;
        }

        public GymDto CreateGym(GymForCreationDto gym)
        { 
            var gymEntity = _mapper.Map<Gym> (gym);

            _repositoryManager.Gym.CreateGym(gymEntity);
            _repositoryManager.Save();

            var gymToReturn = _mapper.Map<GymDto>(gymEntity);

            return gymToReturn;
        }

        public IEnumerable<GymDto> GetByIds(IEnumerable<Guid> ids, bool trackChanges)
        {
            if (ids is null)
            {
                throw new IdParametersBadRequestException();
            }

            var gymEntities = _repositoryManager.Gym.GetByIds(ids, trackChanges);
            if (ids.Count() != gymEntities.Count())
            {
                throw new CollectionByIdsBadRequestException();
            }

            var gymsToReturn = _mapper.Map<IEnumerable<GymDto>>(gymEntities);

            return gymsToReturn;
        }

        public (IEnumerable<GymDto> gyms, string ids) CreateGymCollection(IEnumerable<GymForCreationDto> gymCollection)
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

            _repositoryManager.Save();

            var gymCollectionToReturn = _mapper.Map<IEnumerable<GymDto>>(gymEntities);
            var ids = string.Join(",", gymCollectionToReturn.Select(g => g.Id));

            return (gyms: gymCollectionToReturn, ids: ids);
        }

        public void DeleteGym(Guid gymId, bool trackChanges) 
        {
            var gym = _repositoryManager.Gym.GetGym(gymId, trackChanges);
            if(gym is null)
            {
                throw new GymNotFoundException(gymId);
            }

            _repositoryManager.Gym.DeleteGym(gym);
            _repositoryManager.Save();
        }

        public void UpdateGym(Guid gymId, GymForUpdateDto gymForUpdate, bool trackChanges)
        {
            var gymEntity = _repositoryManager.Gym.GetGym(gymId, trackChanges);
            if (gymEntity is null)
            {
                throw new GymNotFoundException(gymId);
            }

            _mapper.Map(gymForUpdate, gymEntity);
            _repositoryManager.Save();

        }
    }
}
