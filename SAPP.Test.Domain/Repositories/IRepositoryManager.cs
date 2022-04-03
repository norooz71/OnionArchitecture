using SAPP.Test.Domain.Repositories.Test;

namespace SAPP.Test.Domain.Repositories
{
    public interface IRepositoryManager
    {
        ITestParentRepository TestParentRepository { get; }

        ITestChildRepository TestChildRepository { get; }   

        IUnitOfWork UnitOfWork { get; }
    }
}
