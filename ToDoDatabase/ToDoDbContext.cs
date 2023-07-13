using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

using ToDoDatabase.Entities;

namespace ToDoDatabase
{
    public class ToDoDbContext : DbContext
    {
        public DbSet<WorkTask> WorkTasks { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlite("Data Source=database\\database.sqlite");
        }
    }
}