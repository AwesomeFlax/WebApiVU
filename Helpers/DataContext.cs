using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiVU.Models;

namespace WebApiVU.Helpers
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Schedule> Schedule { get; set; }
        public DbSet<Classes> Classes { get; set; }
        public DbSet<Mark> Marks { get; set; }
	}
}
