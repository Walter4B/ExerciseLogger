using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;

namespace Contracts
{
    public interface IGymRepository
    {
        Task<IEnumerable<Gym>> GetAllGymsAsync(bool trackChanges);
        Task<Gym> GetGymAsync(Guid gymId, bool trackChanges);
        void CreateGym(Gym gym);
        Task<IEnumerable<Gym>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges);
        void DeleteGym(Gym gym);
    }
}
