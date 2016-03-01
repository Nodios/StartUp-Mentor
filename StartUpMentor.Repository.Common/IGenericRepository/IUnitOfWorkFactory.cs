namespace StartUpMentor.Repository.Common.IGenericRepository
{
	public interface IUnitOfWorkFactory
    {
        IUnitOfWork CreateUnitOfWork();
    }
}
