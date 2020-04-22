using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using petOwnerOneStopShop.Models;

namespace petOwnerOneStopShop.Data
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
                    TypeOfBusiness = "Miscellaneous",
                });
            builder.Entity<Service>().HasData(
                new Service
                {
                    Id = 1,
                    ServiceName = "Pet Bathing",
                });
            builder.Entity<Service>().HasData(
                new Service
                {
                    Id = 2,
                    ServiceName = "Pet Grooming",
                }); builder.Entity<Service>().HasData(
                 new Service
                 {
                     Id = 3,
                     ServiceName = "Pet Training",
                 }); builder.Entity<Service>().HasData(
                 new Service
                 {
                     Id = 4,
                     ServiceName = "Pet Boarding",
                 }); builder.Entity<Service>().HasData(
                 new Service
                 {
                     Id = 5,
                     ServiceName = "Swimming Pool",
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
                    ServiceName = "Pet Vaccines",
                });
            builder.Entity<Service>().HasData(
                new Service
                {
                    Id = 8,
                    ServiceName = "Pet Physical Theraphy",
                });
            builder.Entity<Service>().HasData(
                new Service
                {
                    Id = 9,
                    ServiceName = "Pet Food",
                });
            builder.Entity<Service>().HasData(
                new Service
                {
                    Id = 10,
                    ServiceName = "Pet Socialization",
                });
            builder.Entity<Service>().HasData(
                new Service
                {
                    Id = 11,
                    ServiceName = "Pet Exercise",
                });
            builder.Entity<Service>().HasData(
                new Service
                {
                    Id = 12,
                    ServiceName = "Pet Supplies",
                });
            builder.Entity<Service>().HasData(
                new Service
                {
                    Id = 13,
                    ServiceName = "Pet Transportation",
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
        }
        public DbSet<petOwnerOneStopShop.Models.PetOwner> PetOwner { get; set; }
        public DbSet<petOwnerOneStopShop.Models.PetBusiness> PetBusiness { get; set; }
        public DbSet<petOwnerOneStopShop.Models.Address> Address { get; set; }
        public DbSet<petOwnerOneStopShop.Models.Event> Event { get; set; }
        public DbSet<petOwnerOneStopShop.Models.Calendar> Calendar { get; set; }
        public DbSet<petOwnerOneStopShop.Models.Follow> Follow { get; set; }
        public DbSet<petOwnerOneStopShop.Models.PetProfile> PetProfile { get; set; }
        public DbSet<petOwnerOneStopShop.Models.Adoptable> Adoptable { get; set; }
        public DbSet<petOwnerOneStopShop.Models.Invite> Invite { get; set; }
        public DbSet<petOwnerOneStopShop.Models.Message> Message { get; set; }
    }
}
