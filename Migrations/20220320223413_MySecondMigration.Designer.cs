﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using projekatWP_bar.Model;

namespace projekatWP_bar.Migrations
{
    [DbContext(typeof(ClubContext))]
    [Migration("20220320223413_MySecondMigration")]
    partial class MySecondMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("projekatWP_bar.Model.AttendingEvent", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("AttendeeID")
                        .HasColumnType("int");

                    b.Property<int?>("EventID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("AttendeeID");

                    b.HasIndex("EventID");

                    b.ToTable("AttendingEvents");
                });

            modelBuilder.Entity("projekatWP_bar.Model.Club", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Adresa")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("Adresa");

                    b.Property<string>("Ime")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("Ime");

                    b.HasKey("ID");

                    b.ToTable("Klub");
                });

            modelBuilder.Entity("projekatWP_bar.Model.Event", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Ime")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("Ime Eventa");

                    b.Property<int?>("IzvodjacID")
                        .HasColumnType("int");

                    b.Property<string>("Kategorija")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("Kategorija");

                    b.Property<int?>("KlubID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("IzvodjacID");

                    b.HasIndex("KlubID");

                    b.ToTable("Event");
                });

            modelBuilder.Entity("projekatWP_bar.Model.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Email")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("Email");

                    b.Property<string>("Ime")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("Ime");

                    b.Property<string>("Prezime")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("Prezime");

                    b.HasKey("ID");

                    b.ToTable("User");
                });

            modelBuilder.Entity("projekatWP_bar.Model.Vote", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("EventID")
                        .HasColumnType("int");

                    b.Property<int>("Rating")
                        .HasColumnType("int")
                        .HasColumnName("Rating");

                    b.Property<int?>("VoterID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("EventID");

                    b.HasIndex("VoterID");

                    b.ToTable("Vote");
                });

            modelBuilder.Entity("projekatWP_bar.Model.AttendingEvent", b =>
                {
                    b.HasOne("projekatWP_bar.Model.User", "Attendee")
                        .WithMany("Eventi")
                        .HasForeignKey("AttendeeID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("projekatWP_bar.Model.Event", "Event")
                        .WithMany("Gosti")
                        .HasForeignKey("EventID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Attendee");

                    b.Navigation("Event");
                });

            modelBuilder.Entity("projekatWP_bar.Model.Event", b =>
                {
                    b.HasOne("projekatWP_bar.Model.User", "Izvodjac")
                        .WithMany()
                        .HasForeignKey("IzvodjacID");

                    b.HasOne("projekatWP_bar.Model.Club", "Klub")
                        .WithMany("listaEventova")
                        .HasForeignKey("KlubID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Izvodjac");

                    b.Navigation("Klub");
                });

            modelBuilder.Entity("projekatWP_bar.Model.Vote", b =>
                {
                    b.HasOne("projekatWP_bar.Model.Event", "Event")
                        .WithMany("Glasovi")
                        .HasForeignKey("EventID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("projekatWP_bar.Model.User", "Voter")
                        .WithMany("Vote")
                        .HasForeignKey("VoterID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Event");

                    b.Navigation("Voter");
                });

            modelBuilder.Entity("projekatWP_bar.Model.Club", b =>
                {
                    b.Navigation("listaEventova");
                });

            modelBuilder.Entity("projekatWP_bar.Model.Event", b =>
                {
                    b.Navigation("Glasovi");

                    b.Navigation("Gosti");
                });

            modelBuilder.Entity("projekatWP_bar.Model.User", b =>
                {
                    b.Navigation("Eventi");

                    b.Navigation("Vote");
                });
#pragma warning restore 612, 618
        }
    }
}
