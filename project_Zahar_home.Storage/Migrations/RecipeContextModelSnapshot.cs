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

                    b.Property<int>("Favourite_Id")
                        .HasColumnType("int");

                    b.HasKey("Cooked_Id");

                    b.HasIndex("Favourite_Id");

                    b.ToTable("Cooked");
                });

            modelBuilder.Entity("project_Zahar_home.Storage.Entities.Dish", b =>
                {
                    b.Property<int>("Dish_Id")
                        .HasColumnType("int");

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

                    b.Property<int>("Rating_id")
                        .HasColumnType("int");

                    b.Property<int>("Type_Id")
                        .HasColumnType("int");

                    b.HasKey("Dish_Id");

                    b.HasIndex("Type_Id");

                    b.ToTable("Dishes");
                });

            modelBuilder.Entity("project_Zahar_home.Storage.Entities.Favourite", b =>
                {
                    b.Property<int>("Favourite_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Favourite_Id"), 1L, 1);

                    b.HasKey("Favourite_Id");

                    b.ToTable("Favourites");
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

                    b.ToTable("Ingridient");
                });

            modelBuilder.Entity("project_Zahar_home.Storage.Entities.Rating", b =>
                {
                    b.Property<int>("Rating_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Rating_Id"), 1L, 1);

                    b.Property<int>("Rating_Value")
                        .HasColumnType("int");

                    b.Property<int>("User_Id")
                        .HasColumnType("int");

                    b.HasKey("Rating_Id");

                    b.HasIndex("User_Id");

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

                    b.Property<string>("Ingridient_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Ingridient_id")
                        .HasColumnType("int");

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

                    b.Property<int?>("RoleId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("User_Id");

                    b.HasIndex("Cooked_Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("project_Zahar_home.Storage.Entities.Cooked", b =>
                {
                    b.HasOne("project_Zahar_home.Storage.Entities.Favourite", "Favourite")
                        .WithMany()
                        .HasForeignKey("Favourite_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Favourite");
                });

            modelBuilder.Entity("project_Zahar_home.Storage.Entities.Dish", b =>
                {
                    b.HasOne("project_Zahar_home.Storage.Entities.Rating", "Rating")
                        .WithMany()
                        .HasForeignKey("Dish_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("project_Zahar_home.Storage.Entities.Type_Of_Kitchen", "Type_Of_Kitchen")
                        .WithMany()
                        .HasForeignKey("Type_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rating");

                    b.Navigation("Type_Of_Kitchen");
                });

            modelBuilder.Entity("project_Zahar_home.Storage.Entities.Rating", b =>
                {
                    b.HasOne("project_Zahar_home.Storage.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("User_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
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
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cooked");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("project_Zahar_home.Storage.Entities.Role", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
