namespace Solution.Infrastructure.DataAccessObject
{
    public interface IUnitOfWork
    {
        void SaveChanges();
    }
}
