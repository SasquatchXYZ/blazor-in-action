﻿// <auto-generated />
using BlazingTrails.Api.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BlazingTrails.Api.Persistence.Data.Migrations
{
    [DbContext(typeof(BlazingTrailsContext))]
    partial class BlazingTrailsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.3");

            modelBuilder.Entity("BlazingTrails.Api.Persistence.Entities.RouteInstruction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Stage")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TrailId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("TrailId");

                    b.ToTable("RouteInstructions");
                });

            modelBuilder.Entity("BlazingTrails.Api.Persistence.Entities.Trail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Image")
                        .HasColumnType("TEXT");

                    b.Property<int>("Length")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("TimeInMinutes")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Trails");
                });

            modelBuilder.Entity("BlazingTrails.Api.Persistence.Entities.RouteInstruction", b =>
                {
                    b.HasOne("BlazingTrails.Api.Persistence.Entities.Trail", "Trail")
                        .WithMany("Route")
                        .HasForeignKey("TrailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Trail");
                });

            modelBuilder.Entity("BlazingTrails.Api.Persistence.Entities.Trail", b =>
                {
                    b.Navigation("Route");
                });
#pragma warning restore 612, 618
        }
    }
}
