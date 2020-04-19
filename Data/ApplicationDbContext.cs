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
        }
        public DbSet<petOwnerOneStopShop.Models.PetOwner> PetOwner { get; set; }
        public DbSet<petOwnerOneStopShop.Models.PetBusiness> PetBusiness { get; set; }
    }
}
