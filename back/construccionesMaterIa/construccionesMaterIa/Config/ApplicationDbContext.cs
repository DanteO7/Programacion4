using construccionesMaterIa.Models.Camion;
using Microsoft.EntityFrameworkCore;

namespace construccionesMaterIa.Config

{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Camion> Camiones { get; set; }
    }
}
