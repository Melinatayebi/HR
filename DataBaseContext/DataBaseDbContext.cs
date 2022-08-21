
using HR.Entities;
using Microsoft.EntityFrameworkCore;

namespace HR.DataBaseContext
{
    public class DataBaseDbContext : DbContext
    {
      
        public DataBaseDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
       {
            modelBuilder.Entity<EmployeeEntity>().HasOne(s => s.Department)
              .WithMany(s => s.Employees);
        }

}
}
