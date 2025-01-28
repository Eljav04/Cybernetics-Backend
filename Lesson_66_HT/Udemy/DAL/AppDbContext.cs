using Microsoft.EntityFrameworkCore;
using Udemy.Entity;

namespace Udemy.DAL
{
    public class AppDbContext:DbContext
    {

        private readonly IConfiguration _configuration;

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Course> Courses { get; set; }

        public AppDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));

        }





    }
}
