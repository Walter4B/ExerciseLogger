using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Entities.Models;

namespace Repository
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        { 
        }

        public DbSet<Gym>? Gyms { get; set; }
        public DbSet<Exercise>? Exercises { get; set; }
    }
}
