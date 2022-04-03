using AutoMapper;
using SAPP.Test.Domain.Repositories;
using SAPP.Test.Services.Abstractions;
using SAPP.Test.Services.Abstractions.Test;
using SAPP.Test.Services.Test;
using System;

namespace SAPP.Test.Services
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<ITestChildService> _lazyTestChildService;

        private readonly Lazy<ITestParentService> _lazyTestParentService;

        public ServiceManager(IRepositoryManager repositoryManager,IMapper mapper)
        {
            _lazyTestChildService = new Lazy<ITestChildService>(() => new TestChildService(repositoryManager, mapper));

            _lazyTestParentService=new Lazy<ITestParentService>(() =>new TestParentService(repositoryManager,mapper));  

        }

        public ITestParentService testParentService => _lazyTestParentService.Value;

        public ITestChildService testChildService => _lazyTestChildService.Value;
    }
}
