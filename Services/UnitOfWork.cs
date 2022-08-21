using HR.DataBaseContext;
using HR.RepositoryContract;
using HR.RespositoryConcrete;

namespace HR.Services
{
    public class UnitOfWork : IUnitOfWork
    {
       
        private DataBaseDbContext _context;
       
        public UnitOfWork (DataBaseDbContext context)
        {
            _context=context;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

    }
}
