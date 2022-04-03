using SAPP.Test.Domain.Repositories;
using SAPP.Test.Domain.Repositories.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPP.Test.Persistance.Repositories
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly Lazy<ITestParentRepository> _testParentRepository;

        private readonly Lazy<ITestChildRepository> _testChildRepository;

        public RepositoryManager(RepositoryDbContext repositoryDbContext)
        {
            _testChildRepository = new Lazy<ITestChildRepository>(()=>new TestChildRepository(repositoryDbContext));

            _testParentRepository = new Lazy<ITestParentRepository>(()=>new TestParentRepository(repositoryDbContext));
        }

        public ITestParentRepository TestParentRepository => _testParentRepository.Value;

        public ITestChildRepository TestChildRepository => _testChildRepository.Value;
    }
}
