namespace Solution.Infrastructure.DataAccessObject
{
    public class UnitOfWork : IUnitOfWork
    {
        private Context _context { get; }

        public UnitOfWork(Context context)
        {
            _context = context;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
