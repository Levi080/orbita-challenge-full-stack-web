using AmaisEducacao.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AmaisEducacao.Data.Context
{
    public class AmaisEducacaoContext : DbContext
    {
        public AmaisEducacaoContext(DbContextOptions<AmaisEducacaoContext> options) : base(options) { }

        public DbSet<Student> Student { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
