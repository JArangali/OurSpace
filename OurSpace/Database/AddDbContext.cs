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

            modelBuilder.Entity<Bookings>().HasData(
                new Bookings()
                {
                    BId = 1,
                    BName = "Jasper Lindell Arangali",
                    BEmail = "jasperlindell.arangali.cics@ust.edu.ph",
                    BCNum = "09950188463",
                    BDate = DateOnly.Parse("08/21/2023"),
                    BTime = TimeOnly.Parse("08:00"),
                    BPNum = 1,
                    BMessage = "Hello"
                }
            );
        }
    }
}