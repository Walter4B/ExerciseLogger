using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public sealed class GymNotFoundException : NotFoundException
    {
        public GymNotFoundException(Guid gymId) : base($"The gym with id {gymId} does not exist in the database.") { }
    }
}
