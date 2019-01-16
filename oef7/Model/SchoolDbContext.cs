using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace oef7.Model
{
    public class SchoolDbContext:DbContext
    {
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base(options) { }
        public DbSet<Cursist> Cursisten { get; set; }
        public DbSet<Inschrijving> Inschrijvingen { get; set; }
        public DbSet<Cursus> Cursussen { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Inschrijving>().ToTable("Inschrijving");
        }
    }
}
