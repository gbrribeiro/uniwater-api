using Microsoft.EntityFrameworkCore;
using UniWater_API.Models;

namespace UniWater_API.Data
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Recording> Records { get; set; }
        public DbSet<SystemParameters> SystemParameters { get; set; }
        public DbSet<StreamingData> StreamData { get; set; }
        public DatabaseContext(DbContextOptions options) : base(options) { }
    }
}
