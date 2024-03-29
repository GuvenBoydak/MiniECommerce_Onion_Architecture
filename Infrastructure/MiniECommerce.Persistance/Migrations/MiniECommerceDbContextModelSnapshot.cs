﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MiniECommerce.Persistance;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MiniECommerce.Persistance.Migrations
{
    [DbContext(typeof(MiniECommerceDbContext))]
    partial class MiniECommerceDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MiniECommerce.Domain.AppUser", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ActivationCode")
                        .HasColumnType("uuid");

                    b.Property<bool>("Active")
                        .HasMaxLength(50)
                        .HasColumnType("boolean");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<short>("IncorrectEntry")
                        .HasColumnType("smallint");

                    b.Property<bool>("IsLock")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("LastActivty")
                        .HasMaxLength(50)
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("bytea");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("bytea");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("ID");

                    b.ToTable("AppUsers");
                });

            modelBuilder.Entity("MiniECommerce.Domain.AppUserRole", b =>
                {
                    b.Property<Guid>("RoleID")
                        .HasColumnType("uuid");

                    b.Property<Guid>("AppUserID")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("ID")
                        .HasColumnType("uuid");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("RoleID", "AppUserID");

                    b.HasIndex("AppUserID");

                    b.ToTable("AppUserRoles");
                });

            modelBuilder.Entity("MiniECommerce.Domain.Brand", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("ID");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("MiniECommerce.Domain.Category", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("ID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("MiniECommerce.Domain.Color", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("ID");

                    b.ToTable("Colors");
                });

            modelBuilder.Entity("MiniECommerce.Domain.Offer", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AppUserID")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsApproved")
                        .HasColumnType("boolean");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<Guid>("ProductID")
                        .HasColumnType("uuid");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("ID");

                    b.HasIndex("AppUserID");

                    b.HasIndex("ProductID");

                    b.ToTable("Offers");
                });

            modelBuilder.Entity("MiniECommerce.Domain.Product", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AppUserID")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("BrandID")
                        .HasColumnType("uuid");

                    b.Property<Guid>("CategoryID")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("ColorID")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

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
                        .HasColumnType("character varying(100)");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("numeric");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("UsageStatus")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.HasIndex("AppUserID");

                    b.HasIndex("BrandID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("ColorID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("MiniECommerce.Domain.Role", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("ID");

                    b.ToTable("Roles");
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
                        .WithMany("Offers")
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
                        .WithMany("Products")
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

                    b.Navigation("Offers");

                    b.Navigation("Products");
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
