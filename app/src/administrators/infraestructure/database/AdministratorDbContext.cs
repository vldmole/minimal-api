using Microsoft.EntityFrameworkCore;
using minimal_api.src.administrators.domain.entities;

namespace minimal_api.src.administrators.infraestructure.database
{
    public class AdministratorDbContext(IConfiguration appSettings) : DbContext
    {
        private readonly IConfiguration _appSettings = appSettings;

        public DbSet<Administrator> Administrators { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.Entity<Administrator>().HasData(
                new Administrator()
                {
                    Id = 1,
                    Email = "administrator@myCompany.com",
                    Password = "1234",
                    Perfil = "Admin"
                }
            );
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string? connectionString = _appSettings.GetConnectionString("MySql");

            if (string.IsNullOrEmpty(connectionString))
                throw new Exception($"Database connection string could not be null {connectionString}");

            optionsBuilder.UseMySql(
                connectionString,
                ServerVersion.AutoDetect(connectionString)
            );
        }
    }
}