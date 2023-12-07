using System;
using OurSpace.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace OurSpace.Data
{
    public class AddDbContext : DbContext
    {
        public DbSet<Bookings> bookings { get; set; }
        public DbSet<Accepted> accepted { get; set; }

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
                });

            modelBuilder.Entity<Accepted>().HasData(
                new Accepted()
                {
                    AId = 1,
                    AName = "Jasper Lindell Arangali",
                    AEmail = "jasperlindell.arangali.cics@ust.edu.ph",
                    ACNum = "09950188463",
                    ADate = DateOnly.Parse("08/21/2023"),
                    ATime = TimeOnly.Parse("08:00"),
                    APNum = 1,
                    AMessage = "Hello"
                }
            );
        }
    }
}