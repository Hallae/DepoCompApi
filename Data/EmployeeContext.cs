

namespace DepoCompApi.Data
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options) { }
        public DbSet<EmployeeContext> Employee { get; set; }

    }
}
