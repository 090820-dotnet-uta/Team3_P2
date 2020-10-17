﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using P2_API.Data;

namespace P2_API.Migrations
{
    [DbContext(typeof(P2Context))]
    partial class P2ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("P2_API.Models.Preferences", b =>
                {
                    b.Property<int>("PreferencesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Animals")
                        .HasColumnType("bit");

                    b.Property<bool>("Art")
                        .HasColumnType("bit");

                    b.Property<bool>("Beauty")
                        .HasColumnType("bit");

                    b.Property<bool>("Entertainment")
                        .HasColumnType("bit");

                    b.Property<bool>("Fitness")
                        .HasColumnType("bit");

                    b.Property<bool>("HomeDecour")
                        .HasColumnType("bit");

                    b.Property<bool>("Learning")
                        .HasColumnType("bit");

                    b.Property<bool>("Nightlife")
                        .HasColumnType("bit");

                    b.Property<bool>("Religion")
                        .HasColumnType("bit");

                    b.Property<bool>("Shopping")
                        .HasColumnType("bit");

                    b.HasKey("PreferencesId");

                    b.ToTable("Preferences");
                });

            modelBuilder.Entity("P2_API.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PreferencesId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.HasIndex("PreferencesId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("P2_API.Models.User", b =>
                {
                    b.HasOne("P2_API.Models.Preferences", "PreferencesModel")
                        .WithMany()
                        .HasForeignKey("PreferencesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
