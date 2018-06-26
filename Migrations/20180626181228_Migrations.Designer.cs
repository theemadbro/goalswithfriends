﻿// <auto-generated />
using goalswithfriends.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace goalswithfriends.Migrations
{
    [DbContext(typeof(goalswithfriendsContext))]
    [Migration("20180626181228_Migrations")]
    partial class Migrations
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125");

            modelBuilder.Entity("goalswithfriends.Models.Goals", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("EndDate");

                    b.Property<DateTime>("created_at")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn);

                    b.Property<string>("desc");

                    b.Property<string>("goal");

                    b.Property<int>("groupid");

                    b.Property<DateTime>("startDate");

                    b.Property<string>("status");

                    b.Property<DateTime>("updated_at")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn);

                    b.Property<int>("usersid");

                    b.HasKey("id");

                    b.HasIndex("groupid");

                    b.HasIndex("usersid");

                    b.ToTable("Goals");
                });

            modelBuilder.Entity("goalswithfriends.Models.Groups", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("created_at")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn);

                    b.Property<string>("desc");

                    b.Property<string>("name")
                        .IsRequired();

                    b.Property<int>("ownerid");

                    b.Property<string>("password");

                    b.Property<DateTime>("updated_at")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn);

                    b.HasKey("id");

                    b.HasIndex("ownerid");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("goalswithfriends.Models.Users", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("Groupsid");

                    b.Property<string>("bio");

                    b.Property<DateTime>("birthday");

                    b.Property<DateTime>("created_at")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn);

                    b.Property<string>("email")
                        .IsRequired();

                    b.Property<string>("first_name")
                        .IsRequired();

                    b.Property<string>("last_name")
                        .IsRequired();

                    b.Property<string>("password")
                        .IsRequired();

                    b.Property<DateTime>("updated_at")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn);

                    b.HasKey("id");

                    b.HasIndex("Groupsid");

                    b.ToTable("users");
                });

            modelBuilder.Entity("goalswithfriends.Models.Goals", b =>
                {
                    b.HasOne("goalswithfriends.Models.Groups", "group")
                        .WithMany()
                        .HasForeignKey("groupid")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("goalswithfriends.Models.Users", "user")
                        .WithMany("goals")
                        .HasForeignKey("usersid")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("goalswithfriends.Models.Groups", b =>
                {
                    b.HasOne("goalswithfriends.Models.Users", "owner")
                        .WithMany()
                        .HasForeignKey("ownerid")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("goalswithfriends.Models.Users", b =>
                {
                    b.HasOne("goalswithfriends.Models.Groups")
                        .WithMany("members")
                        .HasForeignKey("Groupsid");
                });
#pragma warning restore 612, 618
        }
    }
}
