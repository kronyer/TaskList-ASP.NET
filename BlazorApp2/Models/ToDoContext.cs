using Microsoft.EntityFrameworkCore;

namespace BlazorApp2.Models
{
    public class ToDoContext : DbContext
    {
        public DbSet<ToDo> ToDos => Set<ToDo>();
        public DbSet<Category> Categories => Set<Category>();

        public ToDoContext(DbContextOptions<ToDoContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ToDo>().Property(x => x.Title).IsRequired();
            modelBuilder.Entity<ToDo>().Property(x => x.Description).IsRequired();
            modelBuilder.Entity<Category>().Property(x => x.Description).IsRequired();

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Description = "Trabalho" },
                new Category { Id = 2, Description = "Pessoal" },
                new Category { Id = 3, Description = "Outra" }
            );
        }
    }
}
