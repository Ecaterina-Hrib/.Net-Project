﻿// <auto-generated />
using System;
using System.Collections.Generic;
using HousePricePrediction.API.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HousePricePrediction.API.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("HousePricePrediction.API.Models.House", b =>
                {
                    b.Property<Guid>("_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("_id");

                    b.Property<string>("_address")
                        .HasColumnType("text")
                        .HasColumnName("_address");

                    b.Property<string>("_area")
                        .HasColumnType("text")
                        .HasColumnName("_area");

                    b.Property<string>("_city")
                        .HasColumnType("text")
                        .HasColumnName("_city");

                    b.Property<float?>("_condition")
                        .HasColumnType("real")
                        .HasColumnName("_condition");

                    b.Property<float?>("_constructionYear")
                        .HasColumnType("real")
                        .HasColumnName("_construction_year");

                    b.Property<string>("_country")
                        .HasColumnType("text")
                        .HasColumnName("_country");

                    b.Property<DateTime>("_creationDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("_creation_date");

                    b.Property<double?>("_currentPrice")
                        .HasColumnType("double precision")
                        .HasColumnName("_current_price");

                    b.Property<string>("_description")
                        .HasColumnType("text")
                        .HasColumnName("_description");

                    b.Property<float?>("_floor")
                        .HasColumnType("real")
                        .HasColumnName("_floor");

                    b.Property<float?>("_grade")
                        .HasColumnType("real")
                        .HasColumnName("_grade");

                    b.Property<float?>("_landSurface")
                        .HasColumnType("real")
                        .HasColumnName("_land_surface");

                    b.Property<double?>("_latitude")
                        .HasColumnType("double precision")
                        .HasColumnName("_latitude");

                    b.Property<double?>("_longitude")
                        .HasColumnType("double precision")
                        .HasColumnName("_longitude");

                    b.Property<float?>("_noOfBathrooms")
                        .HasColumnType("real")
                        .HasColumnName("_no_of_bathrooms");

                    b.Property<float?>("_noOfRooms")
                        .HasColumnType("real")
                        .HasColumnName("_no_of_rooms");

                    b.Property<List<string>>("_pictures")
                        .IsRequired()
                        .HasColumnType("text[]")
                        .HasColumnName("_pictures");

                    b.Property<double?>("_recommendedPrice")
                        .HasColumnType("double precision")
                        .HasColumnName("_recommended_price");

                    b.Property<float?>("_sqft_basement")
                        .HasColumnType("real")
                        .HasColumnName("_sqft_basement");

                    b.Property<float?>("_surface")
                        .HasColumnType("real")
                        .HasColumnName("_surface");

                    b.Property<string>("_title")
                        .HasColumnType("text")
                        .HasColumnName("_title");

                    b.Property<Guid?>("_user_id")
                        .HasColumnType("uuid")
                        .HasColumnName("_user_id");

                    b.Property<float?>("_view")
                        .HasColumnType("real")
                        .HasColumnName("_view");

                    b.Property<int>("_views")
                        .HasColumnType("integer")
                        .HasColumnName("_views");

                    b.Property<float?>("_yr_renovated")
                        .HasColumnType("real")
                        .HasColumnName("_yr_renovated");

                    b.Property<float?>("_zipcode")
                        .HasColumnType("real")
                        .HasColumnName("_zipcode");

                    b.HasKey("_id")
                        .HasName("pk_houses");

                    b.HasIndex("_user_id")
                        .HasDatabaseName("ix_houses__user_id");

                    b.ToTable("houses", (string)null);
                });

            modelBuilder.Entity("HousePricePrediction.API.Models.User", b =>
                {
                    b.Property<Guid>("_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("_id");

                    b.Property<DateTime>("_creationDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("_creation_date");

                    b.Property<string>("_email")
                        .HasColumnType("text")
                        .HasColumnName("_email");

                    b.Property<string>("_name")
                        .HasColumnType("text")
                        .HasColumnName("_name");

                    b.Property<string>("_password")
                        .HasColumnType("text")
                        .HasColumnName("_password");

                    b.Property<string>("_phoneNumber")
                        .HasColumnType("text")
                        .HasColumnName("_phone_number");

                    b.Property<string>("_username")
                        .HasColumnType("text")
                        .HasColumnName("_username");

                    b.HasKey("_id")
                        .HasName("pk_users");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("HousePricePrediction.API.Models.House", b =>
                {
                    b.HasOne("HousePricePrediction.API.Models.User", "_user")
                        .WithMany("_forSell")
                        .HasForeignKey("_user_id")
                        .HasConstraintName("fk_houses_users__user_temp_id");

                    b.Navigation("_user");
                });

            modelBuilder.Entity("HousePricePrediction.API.Models.User", b =>
                {
                    b.Navigation("_forSell");
                });
#pragma warning restore 612, 618
        }
    }
}
