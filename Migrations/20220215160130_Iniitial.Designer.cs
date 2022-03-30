﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MultipleImageUpload.Data;

#nullable disable

namespace MultipleImageUpload.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220215160130_Iniitial")]
    partial class Iniitial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.1");

            modelBuilder.Entity("MultipleImageUpload.Models.ImageGallery", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ImageName")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("ImageGalleries");
                });

            modelBuilder.Entity("MultipleImageUpload.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("coverImage")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MultipleImageUpload.Models.ImageGallery", b =>
                {
                    b.HasOne("MultipleImageUpload.Models.User", "User")
                        .WithMany("ImageGalleries")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("MultipleImageUpload.Models.User", b =>
                {
                    b.Navigation("ImageGalleries");
                });
#pragma warning restore 612, 618
        }
    }
}
