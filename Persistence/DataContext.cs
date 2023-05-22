using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Persistence
{
    public class DataContext : DbContext, IUnitOfWork
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public virtual DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }

        public void SaveChanges()
        {
            base.SaveChanges();
        }
    }
}
