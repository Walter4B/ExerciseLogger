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
    }
}
