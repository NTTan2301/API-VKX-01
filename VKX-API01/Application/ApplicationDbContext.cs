using Microsoft.EntityFrameworkCore;
using VKX_API01.Models;

namespace VKX_API01.Application
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions) : base(dbContextOptions)
        {
            
        }
        public DbSet<Company> Company { get; set; }
    }
}
