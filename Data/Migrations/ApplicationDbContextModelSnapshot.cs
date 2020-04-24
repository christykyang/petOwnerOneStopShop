﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using petOwnerOneStopShop.Data;

namespace petOwnerOneStopShop.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = "020ffbe6-1666-4da9-b7df-834745b3ab7d",
                            ConcurrencyStamp = "4f7ada7e-9055-4223-97c3-332b5a82e561",
                            Name = "Pet Owner",
                            NormalizedName = "PET OWNER"
                        },
                        new
                        {
                            Id = "8a458493-6842-48dc-be21-7e0ae2189193",
                            ConcurrencyStamp = "525e2854-41fb-411c-9dae-ef771ee189fe",
                            Name = "Pet-Friendly Business",
                            NormalizedName = "PET-FRIENDLY BUSINESS"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("petOwnerOneStopShop.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Lat")
                        .HasColumnType("float");

                    b.Property<double>("Lng")
                        .HasColumnType("float");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("petOwnerOneStopShop.Models.Adoptable", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("PetBusinessId")
                        .HasColumnType("int");

                    b.Property<int?>("PetProfileId")
                        .HasColumnType("int");

                    b.Property<bool?>("isAdoptable")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("PetBusinessId");

                    b.HasIndex("PetProfileId");

                    b.ToTable("Adoptable");
                });

            modelBuilder.Entity("petOwnerOneStopShop.Models.BusinessType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TypeOfBusiness")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BusinessType");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            TypeOfBusiness = "Pet Sitting"
                        },
                        new
                        {
                            Id = 2,
                            TypeOfBusiness = "Pet Training"
                        },
                        new
                        {
                            Id = 3,
                            TypeOfBusiness = "Pet Boarding"
                        },
                        new
                        {
                            Id = 4,
                            TypeOfBusiness = "Veterinarian"
                        },
                        new
                        {
                            Id = 5,
                            TypeOfBusiness = "Grooming"
                        },
                        new
                        {
                            Id = 6,
                            TypeOfBusiness = "Pet Transportation"
                        },
                        new
                        {
                            Id = 7,
                            TypeOfBusiness = "Pet Supply"
                        },
                        new
                        {
                            Id = 8,
                            TypeOfBusiness = "Miscellaneous"
                        });
                });

            modelBuilder.Entity("petOwnerOneStopShop.Models.Calendar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("IdentityUserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("IdentityUserId");

                    b.ToTable("Calendar");
                });

            modelBuilder.Entity("petOwnerOneStopShop.Models.CalendarEvent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CalendarId")
                        .HasColumnType("int");

                    b.Property<int>("ColorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Delete")
                        .HasColumnType("bit");

                    b.Property<string>("Details")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CalendarId");

                    b.ToTable("Event");
                });

            modelBuilder.Entity("petOwnerOneStopShop.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Office")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfilePicture")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Salary")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("petOwnerOneStopShop.Models.FeedUpdate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("NewsFeedId")
                        .HasColumnType("int");

                    b.Property<string>("PubDate")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("NewsFeedId");

                    b.ToTable("FeedUpdate");
                });

            modelBuilder.Entity("petOwnerOneStopShop.Models.Follow", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("IsFollowing")
                        .HasColumnType("bit");

                    b.Property<int?>("PetBusinessId")
                        .HasColumnType("int");

                    b.Property<int?>("PetOwnerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PetBusinessId");

                    b.HasIndex("PetOwnerId");

                    b.ToTable("Follow");
                });

            modelBuilder.Entity("petOwnerOneStopShop.Models.Invite", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CalendarEventId")
                        .HasColumnType("int");

                    b.Property<string>("IdentityUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool?>("isInvitationAccepted")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("CalendarEventId");

                    b.HasIndex("IdentityUserId");

                    b.ToTable("Invite");
                });

            modelBuilder.Entity("petOwnerOneStopShop.Models.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MessageContent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserFromID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserToId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Message");
                });

            modelBuilder.Entity("petOwnerOneStopShop.Models.NewsFeed", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("IdentityUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("PetBusinessId")
                        .HasColumnType("int");

                    b.Property<int>("PetOwnerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdentityUserId");

                    b.HasIndex("PetBusinessId");

                    b.HasIndex("PetOwnerId");

                    b.ToTable("NewsFeed");
                });

            modelBuilder.Entity("petOwnerOneStopShop.Models.PetBusiness", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AddressId")
                        .HasColumnType("int");

                    b.Property<int?>("BusinessTypeId")
                        .HasColumnType("int");

                    b.Property<string>("IdentityUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("BusinessTypeId");

                    b.HasIndex("IdentityUserId");

                    b.ToTable("PetBusiness");
                });

            modelBuilder.Entity("petOwnerOneStopShop.Models.PetOwner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AddressId")
                        .HasColumnType("int");

                    b.Property<string>("IdentityUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("IdentityUserId");

                    b.ToTable("PetOwner");
                });

            modelBuilder.Entity("petOwnerOneStopShop.Models.PetProfile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<bool?>("IsAdopted")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsMale")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PetOwnerId")
                        .HasColumnType("int");

                    b.Property<int?>("PetTypeId")
                        .HasColumnType("int");

                    b.Property<string>("ProfilePicture")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PetOwnerId");

                    b.HasIndex("PetTypeId");

                    b.ToTable("PetProfile");
                });

            modelBuilder.Entity("petOwnerOneStopShop.Models.PetType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TypeName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PetType");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            TypeName = "Dog"
                        },
                        new
                        {
                            Id = 2,
                            TypeName = "Cat"
                        },
                        new
                        {
                            Id = 3,
                            TypeName = "Fish"
                        },
                        new
                        {
                            Id = 4,
                            TypeName = "Bird"
                        },
                        new
                        {
                            Id = 5,
                            TypeName = "Small Pet"
                        },
                        new
                        {
                            Id = 6,
                            TypeName = "Reptile"
                        },
                        new
                        {
                            Id = 7,
                            TypeName = "Amphibian"
                        },
                        new
                        {
                            Id = 8,
                            TypeName = "Farm Animal"
                        });
                });

            modelBuilder.Entity("petOwnerOneStopShop.Models.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ServiceName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Service");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ServiceName = "Pet Bathing"
                        },
                        new
                        {
                            Id = 2,
                            ServiceName = "Pet Grooming"
                        },
                        new
                        {
                            Id = 3,
                            ServiceName = "Pet Training"
                        },
                        new
                        {
                            Id = 4,
                            ServiceName = "Pet Boarding"
                        },
                        new
                        {
                            Id = 5,
                            ServiceName = "Swimming Pool"
                        },
                        new
                        {
                            Id = 6,
                            ServiceName = "Spay and Neuter"
                        },
                        new
                        {
                            Id = 7,
                            ServiceName = "Pet Vaccines"
                        },
                        new
                        {
                            Id = 8,
                            ServiceName = "Pet Physical Theraphy"
                        },
                        new
                        {
                            Id = 9,
                            ServiceName = "Pet Food"
                        },
                        new
                        {
                            Id = 10,
                            ServiceName = "Pet Socialization"
                        },
                        new
                        {
                            Id = 11,
                            ServiceName = "Pet Exercise"
                        },
                        new
                        {
                            Id = 12,
                            ServiceName = "Pet Supplies"
                        },
                        new
                        {
                            Id = 13,
                            ServiceName = "Pet Transportation"
                        },
                        new
                        {
                            Id = 14,
                            ServiceName = "Animal/Pet Educational Resources"
                        },
                        new
                        {
                            Id = 15,
                            ServiceName = "Self-Bathing Service"
                        },
                        new
                        {
                            Id = 16,
                            ServiceName = "Volunteering"
                        });
                });

            modelBuilder.Entity("petOwnerOneStopShop.Models.ServiceOffered", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cost")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PetBusinessId")
                        .HasColumnType("int");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PetBusinessId");

                    b.HasIndex("ServiceId");

                    b.ToTable("ServiceOffered");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("petOwnerOneStopShop.Models.Adoptable", b =>
                {
                    b.HasOne("petOwnerOneStopShop.Models.PetBusiness", "PetBusiness")
                        .WithMany()
                        .HasForeignKey("PetBusinessId");

                    b.HasOne("petOwnerOneStopShop.Models.PetProfile", "PetProfile")
                        .WithMany()
                        .HasForeignKey("PetProfileId");
                });

            modelBuilder.Entity("petOwnerOneStopShop.Models.Calendar", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "IdentityUser")
                        .WithMany()
                        .HasForeignKey("IdentityUserId");
                });

            modelBuilder.Entity("petOwnerOneStopShop.Models.CalendarEvent", b =>
                {
                    b.HasOne("petOwnerOneStopShop.Models.Calendar", "Calendar")
                        .WithMany()
                        .HasForeignKey("CalendarId");
                });

            modelBuilder.Entity("petOwnerOneStopShop.Models.FeedUpdate", b =>
                {
                    b.HasOne("petOwnerOneStopShop.Models.NewsFeed", "NewsFeed")
                        .WithMany("Updates")
                        .HasForeignKey("NewsFeedId");
                });

            modelBuilder.Entity("petOwnerOneStopShop.Models.Follow", b =>
                {
                    b.HasOne("petOwnerOneStopShop.Models.PetBusiness", "PetBusiness")
                        .WithMany()
                        .HasForeignKey("PetBusinessId");

                    b.HasOne("petOwnerOneStopShop.Models.PetOwner", "PetOwner")
                        .WithMany()
                        .HasForeignKey("PetOwnerId");
                });

            modelBuilder.Entity("petOwnerOneStopShop.Models.Invite", b =>
                {
                    b.HasOne("petOwnerOneStopShop.Models.CalendarEvent", "Event")
                        .WithMany()
                        .HasForeignKey("CalendarEventId");

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "IdentityUser")
                        .WithMany()
                        .HasForeignKey("IdentityUserId");
                });

            modelBuilder.Entity("petOwnerOneStopShop.Models.NewsFeed", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "IdentityUser")
                        .WithMany()
                        .HasForeignKey("IdentityUserId");

                    b.HasOne("petOwnerOneStopShop.Models.PetBusiness", "PetBusiness")
                        .WithMany()
                        .HasForeignKey("PetBusinessId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("petOwnerOneStopShop.Models.PetOwner", "PetOwner")
                        .WithMany()
                        .HasForeignKey("PetOwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("petOwnerOneStopShop.Models.PetBusiness", b =>
                {
                    b.HasOne("petOwnerOneStopShop.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");

                    b.HasOne("petOwnerOneStopShop.Models.BusinessType", "BusinessType")
                        .WithMany()
                        .HasForeignKey("BusinessTypeId");

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "IdentityUser")
                        .WithMany()
                        .HasForeignKey("IdentityUserId");
                });

            modelBuilder.Entity("petOwnerOneStopShop.Models.PetOwner", b =>
                {
                    b.HasOne("petOwnerOneStopShop.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "IdentityUser")
                        .WithMany()
                        .HasForeignKey("IdentityUserId");
                });

            modelBuilder.Entity("petOwnerOneStopShop.Models.PetProfile", b =>
                {
                    b.HasOne("petOwnerOneStopShop.Models.PetOwner", "PetOwner")
                        .WithMany()
                        .HasForeignKey("PetOwnerId");

                    b.HasOne("petOwnerOneStopShop.Models.PetType", "PetType")
                        .WithMany()
                        .HasForeignKey("PetTypeId");
                });

            modelBuilder.Entity("petOwnerOneStopShop.Models.ServiceOffered", b =>
                {
                    b.HasOne("petOwnerOneStopShop.Models.PetBusiness", "PetBusiness")
                        .WithMany()
                        .HasForeignKey("PetBusinessId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("petOwnerOneStopShop.Models.Service", "Service")
                        .WithMany()
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
