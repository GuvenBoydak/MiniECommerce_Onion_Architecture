﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MiniECommerce.Persistance;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MiniECommerce.Persistance.Migrations
{
    [DbContext(typeof(MiniECommerceDbContext))]
    [Migration("20221020185510_mig1")]
    partial class mig1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MiniECommerce.Domain.AppUserRole", b =>
                {
                    b.Property<int>("RoleID")
                        .HasColumnType("integer");

                    b.Property<int>("AppUserID")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("ID")
                        .HasColumnType("integer");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("RoleID", "AppUserID");

                    b.HasIndex("AppUserID");

                    b.ToTable("AppUserRoles");
                });

            modelBuilder.Entity("MiniECommerce.Domain.BaseEntity", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("ID");

                    b.ToTable("BaseEntity");

                    b.HasDiscriminator<string>("Discriminator").HasValue("BaseEntity");
                });

            modelBuilder.Entity("MiniECommerce.Domain.AppUser", b =>
                {
                    b.HasBaseType("MiniECommerce.Domain.BaseEntity");

                    b.Property<Guid>("ActivationCode")
                        .HasColumnType("uuid");

                    b.Property<bool>("Active")
                        .HasMaxLength(50)
                        .HasColumnType("boolean");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<short>("IncorrectEntry")
                        .HasColumnType("smallint");

                    b.Property<bool>("IsLock")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("LastActivty")
                        .HasMaxLength(50)
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasDiscriminator().HasValue("AppUser");
                });

            modelBuilder.Entity("MiniECommerce.Domain.Brand", b =>
                {
                    b.HasBaseType("MiniECommerce.Domain.BaseEntity");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasDiscriminator().HasValue("Brand");
                });

            modelBuilder.Entity("MiniECommerce.Domain.Category", b =>
                {
                    b.HasBaseType("MiniECommerce.Domain.BaseEntity");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("Category_Name");

                    b.HasDiscriminator().HasValue("Category");
                });

            modelBuilder.Entity("MiniECommerce.Domain.Color", b =>
                {
                    b.HasBaseType("MiniECommerce.Domain.BaseEntity");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("Color_Name");

                    b.HasDiscriminator().HasValue("Color");
                });

            modelBuilder.Entity("MiniECommerce.Domain.Offer", b =>
                {
                    b.HasBaseType("MiniECommerce.Domain.BaseEntity");

                    b.Property<int>("AppUserID")
                        .HasColumnType("integer");

                    b.Property<bool>("IsApproved")
                        .HasColumnType("boolean");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<int>("ProductID")
                        .HasColumnType("integer");

                    b.HasIndex("AppUserID");

                    b.HasIndex("ProductID");

                    b.HasDiscriminator().HasValue("Offer");
                });

            modelBuilder.Entity("MiniECommerce.Domain.Product", b =>
                {
                    b.HasBaseType("MiniECommerce.Domain.BaseEntity");

                    b.Property<int>("AppUserID")
                        .HasColumnType("integer")
                        .HasColumnName("Product_AppUserID");

                    b.Property<int?>("BrandID")
                        .HasColumnType("integer");

                    b.Property<int>("CategoryID")
                        .HasColumnType("integer");

                    b.Property<int?>("ColorID")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)")
                        .HasColumnName("Product_Description");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsOfferable")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsSold")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("Product_Name");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("numeric");

                    b.Property<int>("UsageStatus")
                        .HasColumnType("integer");

                    b.HasIndex("AppUserID");

                    b.HasIndex("BrandID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("ColorID");

                    b.HasDiscriminator().HasValue("Product");
                });

            modelBuilder.Entity("MiniECommerce.Domain.Role", b =>
                {
                    b.HasBaseType("MiniECommerce.Domain.BaseEntity");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("Role_Name");

                    b.HasDiscriminator().HasValue("Role");
                });

            modelBuilder.Entity("MiniECommerce.Domain.AppUserRole", b =>
                {
                    b.HasOne("MiniECommerce.Domain.AppUser", "AppUser")
                        .WithMany("AppUserRoles")
                        .HasForeignKey("AppUserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MiniECommerce.Domain.Role", "Role")
                        .WithMany("AppUserRoles")
                        .HasForeignKey("RoleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("MiniECommerce.Domain.Offer", b =>
                {
                    b.HasOne("MiniECommerce.Domain.AppUser", "AppUser")
                        .WithMany()
                        .HasForeignKey("AppUserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MiniECommerce.Domain.Product", "Product")
                        .WithMany("Offers")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("MiniECommerce.Domain.Product", b =>
                {
                    b.HasOne("MiniECommerce.Domain.AppUser", "AppUser")
                        .WithMany()
                        .HasForeignKey("AppUserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MiniECommerce.Domain.Brand", "Brand")
                        .WithMany("Products")
                        .HasForeignKey("BrandID");

                    b.HasOne("MiniECommerce.Domain.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MiniECommerce.Domain.Color", "Color")
                        .WithMany("Products")
                        .HasForeignKey("ColorID");

                    b.Navigation("AppUser");

                    b.Navigation("Brand");

                    b.Navigation("Category");

                    b.Navigation("Color");
                });

            modelBuilder.Entity("MiniECommerce.Domain.AppUser", b =>
                {
                    b.Navigation("AppUserRoles");
                });

            modelBuilder.Entity("MiniECommerce.Domain.Brand", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("MiniECommerce.Domain.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("MiniECommerce.Domain.Color", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("MiniECommerce.Domain.Product", b =>
                {
                    b.Navigation("Offers");
                });

            modelBuilder.Entity("MiniECommerce.Domain.Role", b =>
                {
                    b.Navigation("AppUserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}