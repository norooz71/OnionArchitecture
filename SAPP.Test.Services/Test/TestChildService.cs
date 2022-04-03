using AutoMapper;
using SAPP.Test.Contracts.Dtos;
using SAPP.Test.Domain.Entities.Test;
using SAPP.Test.Domain.Repositories;
using SAPP.Test.Services.Abstractions.Test;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SAPP.Test.Services.Test
{
    public class TestChildService : ITestChildService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public TestChildService(IRepositoryManager repositoryManager,IMapper mapper)
        {
            _repositoryManager= repositoryManager;

            _mapper = mapper;
        }
        public async void Delete(int id)
        {
            var testChild=await _repositoryManager.TestChildRepository.GetByIdAsync(id);

            _repositoryManager.TestChildRepository.Remove(testChild);
        }

        public async Task<IEnumerable<TestChildDto>> GetAllAsync(int id,CancellationToken cancellationToken = default)
        {
            var testChildren = await _repositoryManager.TestChildRepository.GetAllByTestIdAsync(id, cancellationToken);

            var result=_mapper.Map<IEnumerable<TestChildDto>>(testChildren);

            return result;
        }

        public async Task<TestChildDto> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            var testChildDto = await _repositoryManager.TestChildRepository.GetByIdAsync(id, cancellationToken);

            var result=_mapper.Map<TestChildDto>(testChildDto);
            
            return result;  
        }

        public async Task InsertAsync(TestChildDto testChildDto, CancellationToken cancellationToken = default)
        {
            var testChild=_mapper.Map<TestChild>(testChildDto);

            await _repositoryManager.TestChildRepository.Insert(testChild);
        }
    }
}
