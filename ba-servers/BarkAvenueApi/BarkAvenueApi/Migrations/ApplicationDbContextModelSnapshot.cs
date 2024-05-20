using System;
using BarkAvenueApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BarkAvenueApi.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BarkAvenueApi.Models.User", b =>
            {
                b.Property<int>("UserId")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("integer");

                NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UserId"));

                b.Property<DateTime>("DateRegistration")
                    .HasColumnType("timestamp");

                b.Property<string>("Email")
                    .IsRequired()
                    .HasColumnType("text");

                b.Property<bool>("IsActive")
                    .HasColumnType("boolean");

                b.Property<DateTime>("LastLogin")
                    .HasColumnType("timestamp");

                b.Property<string>("Password")
                    .IsRequired()
                    .HasColumnType("text");

                b.Property<string>("Permission")
                    .IsRequired()
                    .HasColumnType("text");

                b.Property<string>("PhoneNumber")
                    .IsRequired()
                    .HasColumnType("text");

                b.Property<string>("Role")
                    .IsRequired()
                    .HasColumnType("text");

                b.Property<string>("Username")
                    .IsRequired()
                    .HasColumnType("text");

                b.Property<bool>("IsEmailConfirmed")
                    .HasColumnType("boolean");

                b.HasKey("UserId");

                b.ToTable("Users");
            });
#pragma warning restore 612, 618
        }
    }
}
