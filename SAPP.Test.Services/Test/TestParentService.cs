using AutoMapper;
using SAPP.Test.Contracts.Dtos;
using SAPP.Test.Domain.Entities.Test;
using SAPP.Test.Domain.Exeptions.Test;
using SAPP.Test.Domain.Repositories;
using SAPP.Test.Services.Abstractions.Test;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SAPP.Test.Services.Test
{
    public sealed class TestParentService : ITestParentService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        
        public TestParentService(IRepositoryManager repositoryManager,IMapper mapper)
        {
            this._repositoryManager = repositoryManager; 
            this._mapper = mapper;
        }
        public async Task Delete(int id,CancellationToken cancellationToken)
        {
            var testParent = await _repositoryManager.TestParentRepository.GetById(id, cancellationToken);
            _repositoryManager.TestParentRepository.Remove(testParent);
        }

        public async Task<IEnumerable<TestParentDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var testParents=await _repositoryManager.TestParentRepository.GetAllAsync(cancellationToken);
           
            var result=_mapper.Map<IEnumerable<TestParentDto>>(testParents);

            return result;
        }

        public async Task<TestParentDto> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var testParent=await _repositoryManager.TestParentRepository.GetById(id, cancellationToken);

            if (testParent==null)
            {
                throw new TestParentNotFoundException(id);
            }

            var result=_mapper.Map<TestParentDto>(testParent);

            return result;
        }

        public async Task InsertAsync(TestParentDto testDto, CancellationToken cancellationToken)
        {
            var entity=_mapper.Map<TestParent>(testDto);

            await _repositoryManager.TestParentRepository.InsertAsync(entity, cancellationToken);

            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

        }
    }
}
