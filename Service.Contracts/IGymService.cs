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
        Task<IEnumerable<GymDto>> GetAllGymsAsync(bool trackChanges);
        Task<GymDto> GetGymAsync(Guid gymId, bool trackChanges);
        Task<GymDto> CreateGymAsync(GymForCreationDto gym);
        Task<IEnumerable<GymDto>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges);
        Task<(IEnumerable<GymDto> gyms, string ids)> CreateGymCollectionAsync(IEnumerable<GymForCreationDto> gymCollection);
        Task DeleteGymAsync(Guid gymId, bool trackChanges);
        Task UpdateGymAsync(Guid gymId, GymForUpdateDto gymForUpdate, bool trackChanges);
    }
}
