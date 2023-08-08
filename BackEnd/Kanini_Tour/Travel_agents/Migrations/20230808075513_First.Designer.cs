﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tour_Package.Context;

#nullable disable

namespace Tour_Package.Migrations
{
    [DbContext(typeof(AgentContext))]
    [Migration("20230808075513_First")]
    partial class First
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Tour_Package.Models.Location", b =>
                {
                    b.Property<int>("Location_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Location_Id"));

                    b.Property<string>("Location_Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location_Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Location_Id");

                    b.ToTable("locations");
                });

            modelBuilder.Entity("Tour_Package.Models.Package", b =>
                {
                    b.Property<int>("Package_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Package_Id"));

                    b.Property<string>("Duration")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Location_Id")
                        .HasColumnType("int");

                    b.Property<string>("Package_Food")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Package_Hotel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Package_Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Package_Itenary")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Package_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Package_Rate")
                        .HasColumnType("int");

                    b.Property<string>("Package_Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Travelagent_Id")
                        .HasColumnType("int");

                    b.HasKey("Package_Id");

                    b.HasIndex("Location_Id");

                    b.HasIndex("Travelagent_Id");

                    b.ToTable("packages");
                });

            modelBuilder.Entity("Tour_Package.Models.Spots", b =>
                {
                    b.Property<int>("Spot_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Spot_Id"));

                    b.Property<int>("Package_Id")
                        .HasColumnType("int");

                    b.Property<string>("Spot_Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Spot_Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Spot_Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Spot_Id");

                    b.HasIndex("Package_Id");

                    b.ToTable("spots");
                });

            modelBuilder.Entity("Tour_Package.Models.Travel_agent", b =>
                {
                    b.Property<int>("Travelagent_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Travelagent_Id"));

                    b.Property<string>("Travelagency_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("Travelagent_Contact")
                        .HasColumnType("bigint");

                    b.Property<string>("Travelagent_Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Travelagent_Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Travelagent_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Travelagent_Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Travelagent_Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Travelagent_Id");

                    b.ToTable("travel_agents");
                });

            modelBuilder.Entity("Tour_Package.Models.Package", b =>
                {
                    b.HasOne("Tour_Package.Models.Location", "Locations")
                        .WithMany("packages")
                        .HasForeignKey("Location_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tour_Package.Models.Travel_agent", "Travel_agents")
                        .WithMany("packages")
                        .HasForeignKey("Travelagent_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Locations");

                    b.Navigation("Travel_agents");
                });

            modelBuilder.Entity("Tour_Package.Models.Spots", b =>
                {
                    b.HasOne("Tour_Package.Models.Package", "packages")
                        .WithMany("spots")
                        .HasForeignKey("Package_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("packages");
                });

            modelBuilder.Entity("Tour_Package.Models.Location", b =>
                {
                    b.Navigation("packages");
                });

            modelBuilder.Entity("Tour_Package.Models.Package", b =>
                {
                    b.Navigation("spots");
                });

            modelBuilder.Entity("Tour_Package.Models.Travel_agent", b =>
                {
                    b.Navigation("packages");
                });
#pragma warning restore 612, 618
        }
    }
}
