using Microsoft.AspNet.Identity;

namespace StartUpMentor.Repository.Common.IGenericRepository
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork CreateUnitOfWork();
    }
}
