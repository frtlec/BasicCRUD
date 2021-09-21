using BasicCRUD.Entities.Concrete.DataModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicCRUD.DataAccess.Concrete.EfCore.Contexts
{
    public class BasicCrudContext:DbContext
    {
        public BasicCrudContext(DbContextOptions<BasicCrudContext> option) : base(option)
        {

        }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
