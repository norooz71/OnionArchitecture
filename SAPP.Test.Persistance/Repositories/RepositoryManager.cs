using SAPP.Test.Domain.Repositories;
using SAPP.Test.Domain.Repositories.Test;
using System;

namespace SAPP.Test.Persistance.Repositories
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly Lazy<ITestParentRepository> _testParentRepository;

        private readonly Lazy<ITestChildRepository> _testChildRepository;
        
        private readonly Lazy<IUnitOfWork> _unitOfWork;

        public RepositoryManager(RepositoryDbContext repositoryDbContext)
        {
            _testChildRepository = new Lazy<ITestChildRepository>(()=>new TestChildRepository(repositoryDbContext));

            _testParentRepository = new Lazy<ITestParentRepository>(()=>new TestParentRepository(repositoryDbContext));

            _unitOfWork = new Lazy<IUnitOfWork>(() => new UnitOfWork(repositoryDbContext));
        }

        public ITestParentRepository TestParentRepository => _testParentRepository.Value;

        public ITestChildRepository TestChildRepository => _testChildRepository.Value;

        public IUnitOfWork UnitOfWork => _unitOfWork.Value;
    }
}
