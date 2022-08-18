using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    [Serializable]
    public record GymDto
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public string Address {get; init;}
    }
}
