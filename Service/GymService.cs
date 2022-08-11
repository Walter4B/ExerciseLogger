using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.Contracts;
using Contracts;
using Entities.Models;

namespace Service
{
    internal sealed class GymService : IGymService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _loggerManager;

        public GymService(IRepositoryManager repository, ILoggerManager logger)
        { 
            _repositoryManager = repository;
            _loggerManager = logger;
        }

        public IEnumerable<Gym> GetAllGyms(bool trackChanges)
        {
            try
            {
                var gyms = _repositoryManager.Gym.GetAllGyms(trackChanges);

                return gyms;
            }
            catch (Exception ex)
            {
                _loggerManager.LogError($"Something went wrong in the {nameof(GetAllGyms)} service method {ex}");
                throw;
            }
        }
    }
}
