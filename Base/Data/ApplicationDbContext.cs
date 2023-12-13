using BufaloCargo.Models.Globals;
using BufaloCargo.Models.Masters;
using BufaloCargo.Models.Security;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BufaloCargo.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Countrys> Countrys { get; set; }
        public DbSet<Departments> Departments { get; set; }
        public DbSet<Municipalities> Municipalities { get; set; }
        public DbSet<DocumentType> DocumentType { get; set; }
        public DbSet<Company> Empresa { get; set; }
        public DbSet<Campus> Sede { get; set; }
    }
}