﻿// <auto-generated />
using Admins.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Admins.Migrations
{
    [DbContext(typeof(AdminContextClass))]
    partial class AdminContextClassModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Admins.Model.Admin", b =>
                {
                    b.Property<int>("Admin_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Admin_id"));

                    b.Property<string>("Admin_Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Admin_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Admin_Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Admin_id");

                    b.ToTable("Admins");
                });
#pragma warning restore 612, 618
        }
    }
}
