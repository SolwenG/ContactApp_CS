using Microsoft.EntityFrameworkCore;

namespace ContactApp.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<ContactModel> Contacts { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }
    }
}