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
        }
        public DbSet<petOwnerOneStopShop.Models.PetOwner> PetOwner { get; set; }
        public DbSet<petOwnerOneStopShop.Models.PetBusiness> PetBusiness { get; set; }
    }
}
