using Microsoft.EntityFrameworkCore;
using VerticalSliceArchitectureCQRSMediatRCarter.Entities;

namespace VerticalSliceArchitectureCQRSMediatRCarter.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Book> Books { get; set; }
    }
}
