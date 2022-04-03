using SAPP.Test.Contracts.Dtos;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SAPP.Test.Services.Abstractions.Test
{
    public interface ITestChildService
    {
        Task<IEnumerable<TestChildDto>> GetAllAsync(int id,CancellationToken cancellationToken=default);

        Task<TestChildDto> GetByIdAsync(int id, CancellationToken cancellationToken);

        Task InsertAsync(TestChildDto testChildDto,CancellationToken cancellationToken=default);

        void Delete(int id);

    }
}
