﻿// <auto-generated />
using System;
using BabyTracker.Models.RepositoryModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BabyTracker.Migrations
{
    [DbContext(typeof(BabyTrackerContext))]
    partial class BabyTrackerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("BabyTracker.Models.Diaper", b =>
                {
                    b.Property<long>("DiaperId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("Comments")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("Description")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<int>("DiaperType")
                        .HasColumnType("int");

                    b.Property<long>("InfantId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.HasKey("DiaperId");

                    b.HasIndex("InfantId");

                    b.ToTable("Diapers");
                });

            modelBuilder.Entity("BabyTracker.Models.Feeding", b =>
                {
                    b.Property<long>("FeedingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<decimal?>("Amount")
                        .HasColumnType("decimal(8,2)");

                    b.Property<string>("Comments")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("Description")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<decimal?>("Duration")
                        .HasColumnType("decimal(8,2)");

                    b.Property<int>("FeedType")
                        .HasColumnType("int");

                    b.Property<long>("InfantId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.HasKey("FeedingId");

                    b.HasIndex("InfantId");

                    b.ToTable("Feedings");
                });

            modelBuilder.Entity("BabyTracker.Models.Growth", b =>
                {
                    b.Property<long>("GrowthId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(8,2)");

                    b.Property<string>("Comments")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<int>("GrowthType")
                        .HasColumnType("int");

                    b.Property<long>("InfantId")
                        .HasColumnType("bigint");

                    b.HasKey("GrowthId");

                    b.HasIndex("InfantId");

                    b.ToTable("Growths");
                });

            modelBuilder.Entity("BabyTracker.Models.Infant", b =>
                {
                    b.Property<long>("InfantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<DateTime>("Dob")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<string>("LastName")
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.HasKey("InfantId");

                    b.ToTable("Infants");
                });

            modelBuilder.Entity("BabyTracker.Models.Medication", b =>
                {
                    b.Property<long>("MedicationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("Comments")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("InfantId")
                        .HasColumnType("bigint");

                    b.Property<int>("MedicationType")
                        .HasColumnType("int");

                    b.HasKey("MedicationId");

                    b.HasIndex("InfantId");

                    b.ToTable("Medications");
                });

            modelBuilder.Entity("BabyTracker.Models.Sleep", b =>
                {
                    b.Property<long>("SleepId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("Comments")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("Description")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<long>("InfantId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.HasKey("SleepId");

                    b.HasIndex("InfantId");

                    b.ToTable("Sleeps");
                });

            modelBuilder.Entity("BabyTracker.Models.Diaper", b =>
                {
                    b.HasOne("BabyTracker.Models.Infant", "Infant")
                        .WithMany("Diapers")
                        .HasForeignKey("InfantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Infant");
                });

            modelBuilder.Entity("BabyTracker.Models.Feeding", b =>
                {
                    b.HasOne("BabyTracker.Models.Infant", "Infant")
                        .WithMany("Feedings")
                        .HasForeignKey("InfantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Infant");
                });

            modelBuilder.Entity("BabyTracker.Models.Growth", b =>
                {
                    b.HasOne("BabyTracker.Models.Infant", "Infant")
                        .WithMany("Growths")
                        .HasForeignKey("InfantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Infant");
                });

            modelBuilder.Entity("BabyTracker.Models.Medication", b =>
                {
                    b.HasOne("BabyTracker.Models.Infant", "Infant")
                        .WithMany("Medications")
                        .HasForeignKey("InfantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Infant");
                });

            modelBuilder.Entity("BabyTracker.Models.Sleep", b =>
                {
                    b.HasOne("BabyTracker.Models.Infant", "Infant")
                        .WithMany("Sleeps")
                        .HasForeignKey("InfantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Infant");
                });

            modelBuilder.Entity("BabyTracker.Models.Infant", b =>
                {
                    b.Navigation("Diapers");

                    b.Navigation("Feedings");

                    b.Navigation("Growths");

                    b.Navigation("Medications");

                    b.Navigation("Sleeps");
                });
#pragma warning restore 612, 618
        }
    }
}
