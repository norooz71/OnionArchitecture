using SAPP.Test.Domain.Repositories;
using SAPP.Test.Persistance.Repositories;
using System.Threading;
using System.Threading.Tasks;

internal class UnitOfWork : IUnitOfWork
{
    private readonly RepositoryDbContext _repositoryDbContext;

    public UnitOfWork(RepositoryDbContext repositoryDbContext)
    {
        _repositoryDbContext = repositoryDbContext;
    }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken) => 
        _repositoryDbContext.SaveChangesAsync(cancellationToken);

}

