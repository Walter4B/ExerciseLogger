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
    }
}
