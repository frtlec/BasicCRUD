using BasicCRUD.Entities.Concrete.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicCRUD.DataAccess.Concrete.EfCore.Contexts
{
    public class BasicCrudContext: DbContext
    {
        public IConfigurationRoot Configuration { get; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("BasicCrudDB");
                optionsBuilder.UseSqlServer(connectionString, configure => {
                    configure.MigrationsAssembly("BasicCRUD.DataAccess");
                });
            }
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<AppLog> AppLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
