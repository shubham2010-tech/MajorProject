using Microsoft.EntityFrameworkCore;
using CrimeMgmnt.Models;

namespace CrimeMgmnt.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<User> users { get; set; }

        public DbSet<CyberCell> cyberCells { get; set; }
        
    }
}
