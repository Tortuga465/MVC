using Microsoft.EntityFrameworkCore;

namespace MVC.databaseClasses
{
    public class applicationDbContext : DbContext
    {
        public applicationDbContext(DbContextOptions<applicationDbContext> option) : base(option)
        {
            
        }
        public DbSet<miniature> Miniatures { get; set; }
    }
}
