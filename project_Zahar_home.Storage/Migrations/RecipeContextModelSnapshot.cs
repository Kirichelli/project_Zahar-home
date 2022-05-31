﻿// <auto-generated />
using System;
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

            modelBuilder.Entity("project_Zahar_home.Storage.Entities.Cooked", b =>
                {
                    b.Property<int>("Cooked_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Cooked_Id"), 1L, 1);

                    b.Property<int>("UserRating_Id")
                        .HasColumnType("int");

                    b.HasKey("Cooked_Id");

                    b.HasIndex("UserRating_Id");

                    b.ToTable("Cooked");
                });

            modelBuilder.Entity("project_Zahar_home.Storage.Entities.Dish", b =>
                {
                    b.Property<int>("Dish_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Dish_Id"), 1L, 1);

                    b.Property<int>("Callories")
                        .HasColumnType("int");

                    b.Property<int>("Carbohydrat")
                        .HasColumnType("int");

                    b.Property<int>("Cook_Time")
                        .HasColumnType("int");

                    b.Property<string>("Discription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Fat")
                        .HasColumnType("int");

                    b.Property<string>("Ingredients")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Level")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name_Dish")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Protein")
                        .HasColumnType("int");

                    b.Property<int>("Type_Id")
                        .HasColumnType("int");

                    b.HasKey("Dish_Id");

                    b.HasIndex("Type_Id");

                    b.ToTable("Dishes");
                });

            modelBuilder.Entity("project_Zahar_home.Storage.Entities.Img", b =>
                {
                    b.Property<int>("Img_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Img_Id"), 1L, 1);

                    b.Property<int>("Dish_Id")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Vid")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Img_Id");

                    b.HasIndex("Dish_Id");

                    b.ToTable("Imgs");
                });

            modelBuilder.Entity("project_Zahar_home.Storage.Entities.Ingridient", b =>
                {
                    b.Property<int>("Ingridient_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Ingridient_Id"), 1L, 1);

                    b.Property<string>("Ingridient_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Ingridient_Id");

                    b.ToTable("Ingridients");
                });

            modelBuilder.Entity("project_Zahar_home.Storage.Entities.Rating", b =>
                {
                    b.Property<int>("Rating_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Rating_Id"), 1L, 1);

                    b.Property<int>("Dish_Id")
                        .HasColumnType("int");

                    b.Property<double>("Rating_Value")
                        .HasColumnType("float");

                    b.HasKey("Rating_Id");

                    b.HasIndex("Dish_Id");

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("project_Zahar_home.Storage.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("project_Zahar_home.Storage.Entities.Type_Of_Kitchen", b =>
                {
                    b.Property<int>("Type_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Type_Id"), 1L, 1);

                    b.Property<int>("Ingridient_id")
                        .HasColumnType("int");

                    b.Property<string>("Type_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Type_Id");

                    b.HasIndex("Ingridient_id");

                    b.ToTable("Type_Of_Kitchens");
                });

            modelBuilder.Entity("project_Zahar_home.Storage.Entities.User", b =>
                {
                    b.Property<int>("User_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("User_Id"), 1L, 1);

                    b.Property<int?>("Cooked_Id")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Photo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RoleId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("User_Id");

                    b.HasIndex("Cooked_Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("project_Zahar_home.Storage.Entities.UserRating", b =>
                {
                    b.Property<int>("UserRating_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserRating_Id"), 1L, 1);

                    b.Property<int>("Rating_Id")
                        .HasColumnType("int");

                    b.Property<int>("Rating_Value")
                        .HasColumnType("int");

                    b.Property<int>("User_Id")
                        .HasColumnType("int");

                    b.HasKey("UserRating_Id");

                    b.HasIndex("Rating_Id");

                    b.HasIndex("User_Id");

                    b.ToTable("UserRatings");
                });

            modelBuilder.Entity("project_Zahar_home.Storage.Entities.Cooked", b =>
                {
                    b.HasOne("project_Zahar_home.Storage.Entities.UserRating", "UserRating")
                        .WithMany()
                        .HasForeignKey("UserRating_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserRating");
                });

            modelBuilder.Entity("project_Zahar_home.Storage.Entities.Dish", b =>
                {
                    b.HasOne("project_Zahar_home.Storage.Entities.Type_Of_Kitchen", "Type_Of_Kitchen")
                        .WithMany()
                        .HasForeignKey("Type_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Type_Of_Kitchen");
                });

            modelBuilder.Entity("project_Zahar_home.Storage.Entities.Img", b =>
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

                    b.Navigation("Dish");
                });

            modelBuilder.Entity("project_Zahar_home.Storage.Entities.Type_Of_Kitchen", b =>
                {
                    b.HasOne("project_Zahar_home.Storage.Entities.Ingridient", "Ingridient")
                        .WithMany()
                        .HasForeignKey("Ingridient_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ingridient");
                });

            modelBuilder.Entity("project_Zahar_home.Storage.Entities.User", b =>
                {
                    b.HasOne("project_Zahar_home.Storage.Entities.Cooked", "Cooked")
                        .WithMany()
                        .HasForeignKey("Cooked_Id");

                    b.HasOne("project_Zahar_home.Storage.Entities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cooked");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("project_Zahar_home.Storage.Entities.UserRating", b =>
                {
                    b.HasOne("project_Zahar_home.Storage.Entities.Rating", "Rating")
                        .WithMany()
                        .HasForeignKey("Rating_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("project_Zahar_home.Storage.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("User_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rating");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
