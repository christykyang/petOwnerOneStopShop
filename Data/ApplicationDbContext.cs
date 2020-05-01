using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PawentsOneStopShop.Models;

namespace PawentsOneStopShop.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Name = "Pet Owner",
                    NormalizedName = "PET OWNER",
                });
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Name = "Pet-Friendly Business",
                    NormalizedName = "PET-FRIENDLY BUSINESS",
                });
            builder.Entity<PetType>().HasData(
                new PetType
                {
                    Id = 1,
                    TypeName = "Dog",
                });
            builder.Entity<PetType>().HasData(
                new PetType
                {
                    Id = 2,
                    TypeName = "Cat",
                });
            builder.Entity<PetType>().HasData(
                new PetType
                {
                    Id = 3,
                    TypeName = "Fish",
                });
            builder.Entity<PetType>().HasData(
                new PetType
                {
                    Id = 4,
                    TypeName = "Bird",
                });
            builder.Entity<PetType>().HasData(
                new PetType
                {
                    Id = 5,
                    TypeName = "Small Pet",
                });
            builder.Entity<PetType>().HasData(
                new PetType
                {
                    Id = 6,
                    TypeName = "Reptile",
                });
            builder.Entity<PetType>().HasData(
                new PetType
                {
                    Id = 7,
                    TypeName = "Amphibian",
                });
            builder.Entity<PetType>().HasData(
                new PetType
                {
                    Id = 8,
                    TypeName = "Farm Animal",
                });
            builder.Entity<BusinessType>().HasData(
                new BusinessType
                {
                    Id = 1,
                    TypeOfBusiness = "Pet Sitting",
                });
            builder.Entity<BusinessType>().HasData(
                new BusinessType
                {
                    Id = 2,
                    TypeOfBusiness = "Pet Training",
                });
            builder.Entity<BusinessType>().HasData(
                new BusinessType
                {
                    Id = 3,
                    TypeOfBusiness = "Pet Boarding",
                });
            builder.Entity<BusinessType>().HasData(
                new BusinessType
                {
                    Id = 4,
                    TypeOfBusiness = "Veterinarian",
                });
            builder.Entity<BusinessType>().HasData(
                new BusinessType
                {
                    Id = 5,
                    TypeOfBusiness = "Grooming",
                });
            builder.Entity<BusinessType>().HasData(
                new BusinessType
                {
                    Id = 6,
                    TypeOfBusiness = "Pet Transportation",
                });
            builder.Entity<BusinessType>().HasData(
                new BusinessType
                {
                    Id = 7,
                    TypeOfBusiness = "Pet Supply",
                });
            builder.Entity<BusinessType>().HasData(
                new BusinessType
                {
                    Id = 8,
                    TypeOfBusiness = "Food Manufacture",
                });
            builder.Entity<BusinessType>().HasData(
                new BusinessType
                {
                    Id = 9,
                    TypeOfBusiness = "Pet Cafe",
                });
            builder.Entity<BusinessType>().HasData(
                new BusinessType
                {
                    Id = 10,
                    TypeOfBusiness = "Pet-Friendly Restuarants",
                });
            builder.Entity<BusinessType>().HasData(
                new BusinessType
                {
                    Id = 11,
                    TypeOfBusiness = "Pet-Friendly Stores",
                });
            builder.Entity<Service>().HasData(
                new Service
                {
                    Id = 1,
                    ServiceName = "Bathing",
                });
            builder.Entity<Service>().HasData(
                new Service
                {
                    Id = 2,
                    ServiceName = "Grooming",
                }); builder.Entity<Service>().HasData(
                 new Service
                 {
                     Id = 3,
                     ServiceName = "Training",
                 }); builder.Entity<Service>().HasData(
                 new Service
                 {
                     Id = 4,
                     ServiceName = "Boarding",
                 }); builder.Entity<Service>().HasData(
                 new Service
                 {
                     Id = 5,
                     ServiceName = "Swimming Facilities",
                 }); builder.Entity<Service>().HasData(
                 new Service
                 {
                     Id = 6,
                     ServiceName = "Spay and Neuter",
                 });
            builder.Entity<Service>().HasData(
                new Service
                {
                    Id = 7,
                    ServiceName = "Vaccines",
                });
            builder.Entity<Service>().HasData(
                new Service
                {
                    Id = 8,
                    ServiceName = "Physical Theraphy",
                });
            builder.Entity<Service>().HasData(
                new Service
                {
                    Id = 9,
                    ServiceName = "Raw Food",
                });
            builder.Entity<Service>().HasData(
                new Service
                {
                    Id = 10,
                    ServiceName = "Socialization",
                });
            builder.Entity<Service>().HasData(
                new Service
                {
                    Id = 11,
                    ServiceName = "Exercise",
                });
            builder.Entity<Service>().HasData(
                new Service
                {
                    Id = 12,
                    ServiceName = "Supplies",
                });
            builder.Entity<Service>().HasData(
                new Service
                {
                    Id = 13,
                    ServiceName = "Transportation",
                });
            builder.Entity<Service>().HasData(
                new Service
                {
                    Id = 14,
                    ServiceName = "Animal/Pet Educational Resources",
                });
            builder.Entity<Service>().HasData(
                new Service
                {
                    Id = 15,
                    ServiceName = "Self-Bathing Service",
                });
            builder.Entity<Service>().HasData(
                new Service
                {
                    Id = 16,
                    ServiceName = "Volunteering",
                });
            builder.Entity<BusinessType>().HasData(
                new BusinessType
                {
                    Id = 17,
                    TypeOfBusiness = "Kibble",
                });
        }
        public DbSet<PawentsOneStopShop.Models.PetOwner> PetOwner { get; set; }
        public DbSet<PawentsOneStopShop.Models.PetBusiness> PetBusiness { get; set; }
        public DbSet<PawentsOneStopShop.Models.Address> Address { get; set; }
        public DbSet<PawentsOneStopShop.Models.ObjectEvent> ObjectEvent { get; set; }
        public DbSet<PawentsOneStopShop.Models.ObjectInvite> ObjectInvite { get; set; }
        public DbSet<PawentsOneStopShop.Models.ObjectCalendar> ObjectCalendar { get; set; }
        public DbSet<PawentsOneStopShop.Models.Follow> Follow { get; set; }
        public DbSet<PawentsOneStopShop.Models.PetProfile> PetProfile { get; set; }
        public DbSet<PawentsOneStopShop.Models.Adoptable> Adoptable { get; set; }
        public DbSet<PawentsOneStopShop.Models.Message> Message { get; set; }
        public DbSet<PawentsOneStopShop.Models.FeedUpdate> FeedUpdate { get; set; }
        public DbSet<PawentsOneStopShop.Models.ServiceOffered> ServiceOffered { get; set; }
    }
}
