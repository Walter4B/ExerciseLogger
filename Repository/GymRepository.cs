using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Entities.Models;
using Contracts;

namespace Repository
{
    public class GymRepository : RepositoryBase<Gym>, IGymRepository
    {
        public GymRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }

        public async Task<IEnumerable<Gym>> GetAllGymsAsync(bool trackingChanges) =>
            await FindAll(trackingChanges)
                .OrderBy(c => c.Name)
                .ToListAsync();
        // We used await instead of .Result(), .Result() can potentially cause a deadlock which we are traying to avoid with async
        public async Task<Gym> GetGymAsync(Guid gymId, bool trackingChanges) =>
            await FindByCondition(g => g.Id.Equals(gymId), trackingChanges)
            .SingleOrDefaultAsync();

        public void CreateGym(Gym gym) => Create(gym);

        public async Task<IEnumerable<Gym>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges) =>
            await FindByCondition(x => ids.Contains(x.Id), trackChanges)
            .ToListAsync();

        public void DeleteGym(Gym gym) => Delete(gym);
    }
}
