using Microsoft.EntityFrameworkCore;
using ReactChainsaw.API.Database.Models;

namespace ReactChainsaw.API.Database
{
    public class AppDbContext : DbContext
    {
        public DbSet<ToDoEntity> Todos { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ToDoEntity>().ToTable("ToDos");
        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }

}
