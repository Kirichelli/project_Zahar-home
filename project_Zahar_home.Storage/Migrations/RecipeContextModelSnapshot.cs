﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using project_Zahar_home.Storage;

#nullable disable

namespace project_Zahar_home.Storage.Migrations
{
    [DbContext(typeof(RecipeContext))]
    partial class RecipeContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("project_Zahar_home.Storage.Entities.Dish", b =>
                {
                    b.Property<int>("Dish_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Dish_Id"), 1L, 1);

                    b.Property<int>("Calories")
                        .HasColumnType("int");

                    b.Property<int>("Category_id")
                        .HasColumnType("int");

                    b.Property<int>("Cook_Time")
                        .HasColumnType("int");

                    b.Property<string>("Discription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ingredients")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Level")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name_Dish")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type_id")
                        .HasColumnType("int");

                    b.HasKey("Dish_Id");

                    b.ToTable("Dishes");
                });

            modelBuilder.Entity("project_Zahar_home.Storage.Entities.Favourite", b =>
                {
                    b.Property<int>("Favourite_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Favourite_Id"), 1L, 1);

                    b.Property<int>("Dish_Id")
                        .HasColumnType("int");

                    b.HasKey("Favourite_Id");

                    b.HasIndex("Dish_Id");

                    b.ToTable("Favourites");
                });

            modelBuilder.Entity("project_Zahar_home.Storage.Entities.Rating", b =>
                {
                    b.Property<int>("Rating_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Rating_Id"), 1L, 1);

                    b.Property<int>("Dish_Id")
                        .HasColumnType("int");

                    b.Property<string>("Rating_Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("User_Id")
                        .HasColumnType("int");

                    b.HasKey("Rating_Id");

                    b.HasIndex("Dish_Id");

                    b.HasIndex("User_Id");

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("project_Zahar_home.Storage.Entities.User", b =>
                {
                    b.Property<int>("User_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("User_Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Favourite_Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Password")
                        .HasColumnType("int");

                    b.HasKey("User_Id");

                    b.HasIndex("Favourite_Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("project_Zahar_home.Storage.Entities.Favourite", b =>
                {
                    b.HasOne("project_Zahar_home.Storage.Entities.Dish", "Dish")
                        .WithMany()
                        .HasForeignKey("Dish_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dish");
                });

            modelBuilder.Entity("project_Zahar_home.Storage.Entities.Rating", b =>
                {
                    b.HasOne("project_Zahar_home.Storage.Entities.Dish", "Dish")
                        .WithMany()
                        .HasForeignKey("Dish_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("project_Zahar_home.Storage.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("User_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dish");

                    b.Navigation("User");
                });

            modelBuilder.Entity("project_Zahar_home.Storage.Entities.User", b =>
                {
                    b.HasOne("project_Zahar_home.Storage.Entities.Favourite", "Favourite")
                        .WithMany()
                        .HasForeignKey("Favourite_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Favourite");
                });
#pragma warning restore 612, 618
        }
    }
}
