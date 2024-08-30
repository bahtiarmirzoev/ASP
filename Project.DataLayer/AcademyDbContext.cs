using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Project.DataLayer.Models;

namespace Project.DataLayer
{
    public class AcademyDbContext : DbContext
    {
        public AcademyDbContext()
        {
            
        }
        public AcademyDbContext(DbContextOptions<AcademyDbContext> options) :base(options) 
        {
            
        }

        public DbSet<StudentModel> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var connectionString = config.GetConnectionString("Local");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
