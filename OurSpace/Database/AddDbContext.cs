using System;
using OurSpace.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace OurSpace.Data
{
    public class AddDbContext : DbContext
    {
        public DbSet<Bookings> bookings { get; set; }

        public AddDbContext(DbContextOptions<AddDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}