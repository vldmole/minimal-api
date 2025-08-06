using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using minimal_api.src.auth.domain.entities;

namespace minimal_api.src.auth.infraestructure.database
{
    public class AuthDbContext : DbContext
    {
        private readonly IConfiguration _appSettings;

        public AuthDbContext(IConfiguration appSettings)
        {
            this._appSettings = appSettings;
        }

        public DbSet<Administrator> Administrators { get; set; } = default!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string? connectionString = _appSettings.GetConnectionString("mysql");

            if (string.IsNullOrEmpty(connectionString))
                throw new Exception($"Database connection string could not be null {connectionString}");

            optionsBuilder.UseMySql(
                connectionString,
                ServerVersion.AutoDetect(connectionString)
            );
        }
    }
}