using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;

namespace Repository
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<IGymRepository> _gymRepository;
        private readonly Lazy<IExerciseRepository> _exerciseRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        { 
            _repositoryContext = repositoryContext;
            _gymRepository = new Lazy<IGymRepository>(() => new GymRepository(repositoryContext));
            _exerciseRepository = new Lazy<IExerciseRepository> (()=> new ExerciseRepository(repositoryContext));
        }

        public IGymRepository Gym => _gymRepository.Value;
        public IExerciseRepository Exercise => _exerciseRepository.Value;

        public void Save() => _repositoryContext.SaveChanges();
    }
}
