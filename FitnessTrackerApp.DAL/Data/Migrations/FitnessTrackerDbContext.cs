using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WAD_BACKEND_13851.Models;

namespace WAD_BACKEND_13851.Data.Migrations
{
    public class FitnessTrackerDbContext:DbContext
    {
        public FitnessTrackerDbContext(DbContextOptions<FitnessTrackerDbContext> options) : base(options) { }

        public DbSet<Users> Users { get; set; }
        public DbSet<Workout> Workouts { get; set; }
    }
}
