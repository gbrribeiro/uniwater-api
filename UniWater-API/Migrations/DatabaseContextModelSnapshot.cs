﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UniWater_API.Data;

#nullable disable

namespace UniWater_API.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.20");

            modelBuilder.Entity("UniWater_API.Models.Recording", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Operation")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("OperationDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserFullName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Records");
                });

            modelBuilder.Entity("UniWater_API.Models.StreamingData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<float>("Humidity")
                        .HasColumnType("REAL");

                    b.Property<DateTime>("InternalClock")
                        .HasColumnType("TEXT");

                    b.Property<float>("Temperature")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("StreamData");
                });

            modelBuilder.Entity("UniWater_API.Models.SystemParameters", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<float>("DangerousTemperature")
                        .HasColumnType("REAL");

                    b.Property<int>("HumidityOffPercentage")
                        .HasColumnType("INTEGER");

                    b.Property<int>("HumidityOnPercentage")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("SystemParameters");
                });
#pragma warning restore 612, 618
        }
    }
}
