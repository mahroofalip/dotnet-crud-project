using Microsoft.EntityFrameworkCore;

namespace api.EfCore
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        
        public DbSet<Employees> Employees { get; set; }
    }
}
