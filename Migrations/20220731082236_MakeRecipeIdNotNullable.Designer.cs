﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using RecipesApp.Db;

#nullable disable

namespace RecipesApp.Migrations
{
    [DbContext(typeof(RecipesContext))]
    [Migration("20220731082236_MakeIngredientsAndStepsNullableRecipe")]
    partial class MakeIngredientsAndStepsNullableRecipe
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("RecipesApp.Domain.Ingredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<float>("Amount")
                        .HasColumnType("real");

                    b.Property<int>("ProductId")
                        .HasColumnType("integer");

                    b.Property<int?>("RecipeId")
                        .HasColumnType("integer");

                    b.Property<string>("UnitOfMeasurement")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("RecipeId");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("RecipesApp.Domain.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("RecipesApp.Domain.Recipe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Recipes");
                });

            modelBuilder.Entity("RecipesApp.Domain.RecipeStep", b =>
                {
                    b.Property<int>("StepNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("StepNumber"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("RecipeId")
                        .HasColumnType("integer");

                    b.HasKey("StepNumber");

                    b.HasIndex("RecipeId");

                    b.ToTable("RecipeStep");
                });

            modelBuilder.Entity("RecipesApp.Domain.Ingredient", b =>
                {
                    b.HasOne("RecipesApp.Domain.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RecipesApp.Domain.Recipe", null)
                        .WithMany("Ingredients")
                        .HasForeignKey("RecipeId");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("RecipesApp.Domain.RecipeStep", b =>
                {
                    b.HasOne("RecipesApp.Domain.Recipe", null)
                        .WithMany("Steps")
                        .HasForeignKey("RecipeId");
                });

            modelBuilder.Entity("RecipesApp.Domain.Recipe", b =>
                {
                    b.Navigation("Ingredients");

                    b.Navigation("Steps");
                });
#pragma warning restore 612, 618
        }
    }
}
