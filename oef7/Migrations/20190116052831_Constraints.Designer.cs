﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using oef7.Model;

namespace oef7.Migrations
{
    [DbContext(typeof(SchoolDbContext))]
    [Migration("20190116052831_Constraints")]
    partial class Constraints
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("oef7.Model.Cursist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Achternaam")
                        .IsRequired();

                    b.Property<string>("Voornaam")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Cursist");
                });

            modelBuilder.Entity("oef7.Model.Cursus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naam")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Cursus");
                });

            modelBuilder.Entity("oef7.Model.Inschrijving", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CursistId");

                    b.Property<int>("CursusId");

                    b.Property<int>("punten");

                    b.HasKey("Id");

                    b.HasIndex("CursistId");

                    b.HasIndex("CursusId");

                    b.ToTable("Inschrijving");
                });

            modelBuilder.Entity("oef7.Model.Inschrijving", b =>
                {
                    b.HasOne("oef7.Model.Cursist", "Cursist")
                        .WithMany("Inschrijvingen")
                        .HasForeignKey("CursistId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("oef7.Model.Cursus", "Cursus")
                        .WithMany("Inschrijvingen")
                        .HasForeignKey("CursusId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
