﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Textor.GRA.Infra.Data.Context;

namespace Textor.GRA.Infra.Data.Migrations
{
    [DbContext(typeof(GeneralContext))]
    [Migration("20220410173213_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.15");

            modelBuilder.Entity("Textor.GRA.Domain.Entities.Movie", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<bool>("Winner")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Year")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("Textor.GRA.Domain.Entities.MovieProducer", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("MovieID")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ProducerID")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("MovieID");

                    b.HasIndex("ProducerID");

                    b.ToTable("MovieProducers");
                });

            modelBuilder.Entity("Textor.GRA.Domain.Entities.MovieStudio", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("MovieID")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("StudioID")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("MovieID");

                    b.HasIndex("StudioID");

                    b.ToTable("MovieStudios");
                });

            modelBuilder.Entity("Textor.GRA.Domain.Entities.Producer", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Producers");
                });

            modelBuilder.Entity("Textor.GRA.Domain.Entities.Studio", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Studios");
                });

            modelBuilder.Entity("Textor.GRA.Domain.Entities.MovieProducer", b =>
                {
                    b.HasOne("Textor.GRA.Domain.Entities.Movie", "Movie")
                        .WithMany("Producers")
                        .HasForeignKey("MovieID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Textor.GRA.Domain.Entities.Producer", "Producer")
                        .WithMany("Movies")
                        .HasForeignKey("ProducerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");

                    b.Navigation("Producer");
                });

            modelBuilder.Entity("Textor.GRA.Domain.Entities.MovieStudio", b =>
                {
                    b.HasOne("Textor.GRA.Domain.Entities.Movie", "Movie")
                        .WithMany("Studios")
                        .HasForeignKey("MovieID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Textor.GRA.Domain.Entities.Studio", "Studio")
                        .WithMany("Movies")
                        .HasForeignKey("StudioID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");

                    b.Navigation("Studio");
                });

            modelBuilder.Entity("Textor.GRA.Domain.Entities.Movie", b =>
                {
                    b.Navigation("Producers");

                    b.Navigation("Studios");
                });

            modelBuilder.Entity("Textor.GRA.Domain.Entities.Producer", b =>
                {
                    b.Navigation("Movies");
                });

            modelBuilder.Entity("Textor.GRA.Domain.Entities.Studio", b =>
                {
                    b.Navigation("Movies");
                });
#pragma warning restore 612, 618
        }
    }
}