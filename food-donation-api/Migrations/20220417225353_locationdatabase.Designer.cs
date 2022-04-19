﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using food_donation_api.Connection;

namespace food_donation_api.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220417225353_locationdatabase")]
    partial class locationdatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("food_donation_api.Models.Organization", b =>
                {
                    b.Property<string>("OrganizationEmail")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("Lat")
                        .HasColumnType("float");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Long")
                        .HasColumnType("float");

                    b.Property<string>("OrganizationCode")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<string>("OrganizationName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.HasKey("OrganizationEmail");

                    b.ToTable("Organization");
                });

            modelBuilder.Entity("food_donation_api.Models.User", b =>
                {
                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.HasKey("Email");

                    b.ToTable("User");
                });

            modelBuilder.Entity("food_donation_api.Models.UserDonatesOrganization", b =>
                {
                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("OrganizationEmail")
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid>("DonationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("RequestStatus")
                        .HasColumnType("int");

                    b.Property<int>("ReviewFromUser")
                        .HasColumnType("int");

                    b.HasKey("Email", "OrganizationEmail");

                    b.HasIndex("OrganizationEmail");

                    b.ToTable("UserDonatesOrganization");
                });

            modelBuilder.Entity("food_donation_api.Models.UserDonatesOrganization", b =>
                {
                    b.HasOne("food_donation_api.Models.Organization", "Organization")
                        .WithMany("UserDonatesOrganizations")
                        .HasForeignKey("Email")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("food_donation_api.Models.User", "User")
                        .WithMany("UserDonatesOrganizations")
                        .HasForeignKey("OrganizationEmail")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organization");

                    b.Navigation("User");
                });

            modelBuilder.Entity("food_donation_api.Models.Organization", b =>
                {
                    b.Navigation("UserDonatesOrganizations");
                });

            modelBuilder.Entity("food_donation_api.Models.User", b =>
                {
                    b.Navigation("UserDonatesOrganizations");
                });
#pragma warning restore 612, 618
        }
    }
}
