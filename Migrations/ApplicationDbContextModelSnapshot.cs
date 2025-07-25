﻿// <auto-generated />
using BigDataProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BigDataProject.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BigDataProject.Models.Result", b =>
                {
                    b.Property<string>("Word")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Url1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url10")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url4")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url5")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url6")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url7")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url8")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url9")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Word");

                    b.ToTable("Results");
                });

            modelBuilder.Entity("Page.PageRanking", b =>
                {
                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("InGoing")
                        .HasColumnType("int");

                    b.Property<int>("OutGoing")
                        .HasColumnType("int");

                    b.Property<double>("Rank")
                        .HasColumnType("float");

                    b.HasKey("Url");

                    b.ToTable("PageRankings");
                });
#pragma warning restore 612, 618
        }
    }
}
