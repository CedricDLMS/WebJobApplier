using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    // DB Context
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public DbSet<Apply> Applies { get; set; }
        public DbSet<Entreprise> Entreprises { get; set; }
        public DbSet<JobOffer> JobOffers { get; set; }
        public DbSet<MotivationLetter> MotivationLetters { get; set; }
        public DbSet<UserApplier> UserAppliers { get; set; }
        public DbSet<Skills> Skills { get; set; }
        public DbSet<Formation> Formations { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
