using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;
using Contracts;

namespace Repository
{
    public class GymRepository : RepositoryBase<Gym>, IGymRepository
    {
        public GymRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }

        public IEnumerable<Gym> GetAllGyms(bool trackingChanges) =>
            FindAll(trackingChanges)
                .OrderBy(c => c.Id)
                .ToList();

        public Gym GetGym(Guid gymId, bool trackingChanges) =>
            FindByCondition(g => g.Id.Equals(gymId), trackingChanges)
            .SingleOrDefault();

        public void CreateGym(Gym gym) => Create(gym);

        public IEnumerable<Gym> GetByIds(IEnumerable<Guid> ids, bool trackChanges) =>
            FindByCondition(x => ids.Contains(x.Id), trackChanges)
            .ToList();

        public void DeleteGym(Gym gym) => Delete(gym);
    }
}
