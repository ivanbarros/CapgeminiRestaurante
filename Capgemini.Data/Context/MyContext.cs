using Capgemini.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Capgemini.Data.Context
{
    public class MyContext : DbContext
    {
        public DbSet<FoodEntity> Foods { get; set; }
        public DbSet<LogEntity> Logs { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }
        
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
     
}
