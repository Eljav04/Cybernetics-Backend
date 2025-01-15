using System;
using Lesson_60_HT.Services;
using Lesson_60_HT.Models;
using Microsoft.EntityFrameworkCore;
namespace Lesson_60_HT.DAL
{
	public class AppDbContext : DbContext
	{
		public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            DbService.Bulid();
            optionsBuilder.UseSqlServer(DbService.Configuration.GetConnectionString("SqlCon"));
        }

    }
}

