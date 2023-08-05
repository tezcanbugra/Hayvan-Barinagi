using Hayvan_Barınağı.Models.Hayvan;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace Hayvan_Barınağı.Data
{
    public class BarinakDbContext : DbContext
    {
        public BarinakDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Hayvan> Hayvanlar { get; set; }
        public DbSet<Tur> Turler { get; set; }

        public DbSet<Cins> Cinsler { get; set; }

     

    }
}
