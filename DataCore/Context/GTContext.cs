using Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DataCore.Context
{
    public class GTContext : DbContext
    {
        public GTContext()
            : base("name=GTContext")
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Competition> Competitions { get; set; }
        public DbSet<Competitor> Competitors { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<GTUser> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
