using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface IGymService
    {
        IEnumerable<GymDto> GetAllGyms(bool trackChanges);
        GymDto GetGym(Guid gymId, bool trackChanges);
        GymDto CreateGym(GymForCreationDto gym);
        IEnumerable<GymDto> GetByIds(IEnumerable<Guid> ids, bool trackChanges);
        (IEnumerable<GymDto> gyms, string ids) CreateGymCollection(IEnumerable<GymForCreationDto> gymCollection);
    }
}
