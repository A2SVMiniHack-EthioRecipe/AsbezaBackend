﻿// <auto-generated />
using System;
using EquipPayBackend.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EquipPayBackend.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240717232806_OrderandOrderItem")]
    partial class OrderandOrderItem
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EquipPayBackend.Models.Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Cart");
                });

            modelBuilder.Entity("EquipPayBackend.Models.CartItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CartId")
                        .HasColumnType("int");

                    b.Property<int?>("IngredientId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int?>("RecipeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.HasIndex("IngredientId");

                    b.HasIndex("RecipeId");

                    b.ToTable("CartItem");
                });

            modelBuilder.Entity("EquipPayBackend.Models.Ingredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("EquipPayBackend.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ReceiptNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("EquipPayBackend.Models.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("IngredientId")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int?>("RecipeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IngredientId");

                    b.HasIndex("OrderId");

                    b.HasIndex("RecipeId");

                    b.ToTable("OrderItem");
                });

            modelBuilder.Entity("EquipPayBackend.Models.Recipe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<string>("TotalPrepTime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Recipes");
                });

            modelBuilder.Entity("EquipPayBackend.Models.RecipeIngredient", b =>
                {
                    b.Property<int>("RecipeId")
                        .HasColumnType("int");

                    b.Property<int>("IngredientId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("RecipeId", "IngredientId");

                    b.HasIndex("IngredientId");

                    b.ToTable("RecipeIngredients");
                });

            modelBuilder.Entity("EquipPayBackend.Models.Role", b =>
                {
                    b.Property<int>("RoleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleID"));

                    b.Property<bool>("CanControlPayment")
                        .HasColumnType("bit");

                    b.Property<bool>("CanGenerateReport")
                        .HasColumnType("bit");

                    b.Property<bool>("CanMagnageUser")
                        .HasColumnType("bit");

                    b.Property<bool>("CanManageSetting")
                        .HasColumnType("bit");

                    b.Property<bool>("CanManageUserPrivalage")
                        .HasColumnType("bit");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleID");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("EquipPayBackend.Models.UserAccount", b =>
                {
                    b.Property<int>("UserAccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserAccountId"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserAccountId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserAccounts");
                });

            modelBuilder.Entity("EquipPayBackend.Models.UserInfo", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateOfTermination")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsCurrentlyActive")
                        .HasColumnType("bit");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserAccountId")
                        .HasColumnType("int");

                    b.Property<string>("UserFullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserGender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.HasIndex("UserAccountId")
                        .IsUnique();

                    b.ToTable("UserInfos");
                });

            modelBuilder.Entity("EquipPayBackend.Models.Cart", b =>
                {
                    b.HasOne("EquipPayBackend.Models.UserAccount", "User")
                        .WithOne("Cart")
                        .HasForeignKey("EquipPayBackend.Models.Cart", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("EquipPayBackend.Models.CartItem", b =>
                {
                    b.HasOne("EquipPayBackend.Models.Cart", "Cart")
                        .WithMany("CartItems")
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EquipPayBackend.Models.Ingredient", "Ingredient")
                        .WithMany()
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("EquipPayBackend.Models.Recipe", "Recipe")
                        .WithMany()
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Cart");

                    b.Navigation("Ingredient");

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("EquipPayBackend.Models.Order", b =>
                {
                    b.HasOne("EquipPayBackend.Models.UserAccount", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("EquipPayBackend.Models.OrderItem", b =>
                {
                    b.HasOne("EquipPayBackend.Models.Ingredient", "Ingredient")
                        .WithMany()
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("EquipPayBackend.Models.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EquipPayBackend.Models.Recipe", "Recipe")
                        .WithMany()
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Ingredient");

                    b.Navigation("Order");

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("EquipPayBackend.Models.RecipeIngredient", b =>
                {
                    b.HasOne("EquipPayBackend.Models.Ingredient", "Ingredient")
                        .WithMany()
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EquipPayBackend.Models.Recipe", "Recipe")
                        .WithMany("Ingredients")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ingredient");

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("EquipPayBackend.Models.UserAccount", b =>
                {
                    b.HasOne("EquipPayBackend.Models.Role", "Role")
                        .WithMany("UserAccounts")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("EquipPayBackend.Models.UserInfo", b =>
                {
                    b.HasOne("EquipPayBackend.Models.UserAccount", "UserAccount")
                        .WithOne("UserInfo")
                        .HasForeignKey("EquipPayBackend.Models.UserInfo", "UserAccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserAccount");
                });

            modelBuilder.Entity("EquipPayBackend.Models.Cart", b =>
                {
                    b.Navigation("CartItems");
                });

            modelBuilder.Entity("EquipPayBackend.Models.Order", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("EquipPayBackend.Models.Recipe", b =>
                {
                    b.Navigation("Ingredients");
                });

            modelBuilder.Entity("EquipPayBackend.Models.Role", b =>
                {
                    b.Navigation("UserAccounts");
                });

            modelBuilder.Entity("EquipPayBackend.Models.UserAccount", b =>
                {
                    b.Navigation("Cart")
                        .IsRequired();

                    b.Navigation("Orders");

                    b.Navigation("UserInfo");
                });
#pragma warning restore 612, 618
        }
    }
}
