using Microsoft.EntityFrameworkCore;
using wpf_task.DAL.Entities;

namespace wpf_task.DAL.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
    }
}
