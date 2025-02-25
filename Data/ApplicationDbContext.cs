using EmreProje.Models;
using Microsoft.EntityFrameworkCore;
namespace EmreProje.Data
{
    public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    // Models
    public DbSet<Advert> Adverts { get; set; }
    public DbSet<AdvertDetails> AdvertDetails { get; set; }
    public DbSet<Admin> Admins { get; set; }
}


}
