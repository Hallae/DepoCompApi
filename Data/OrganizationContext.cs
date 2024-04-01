


namespace DepoCompApi.Data
{
    public class OrganizationContext : DbContext
    {
        public OrganizationContext(DbContextOptions<OrganizationContext> options) : base(options) { }
        public DbSet<OrganizationContext> Organization { get; set; }

    }
  
}
