using System;
using OurSpace.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using OurSpace.Database;

namespace OurSpace.Data
{
    public class AppDbContext : IdentityDbContext<UserIdentity> { 
    
        public DbSet<Bookings> bookings { get; set; }
        public DbSet<UserIdentity> AspNetUsers { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Bookings>();
        }
    }
}