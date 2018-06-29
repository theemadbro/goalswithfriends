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
    [Migration("20180629021141_new")]
    partial class @new
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125");

            modelBuilder.Entity("goalswithfriends.Models.GoalsG", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("created_at")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn);

                    b.Property<string>("creator");

                    b.Property<string>("desc");

                    b.Property<DateTime>("endDate");

                    b.Property<string>("goal")
                        .IsRequired();

                    b.Property<int>("groupid");

                    b.Property<DateTime>("startDate");

                    b.Property<string>("status");

                    b.Property<DateTime>("updated_at")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn);

                    b.HasKey("id");

                    b.HasIndex("groupid");

                    b.ToTable("goalsgroup");
                });

            modelBuilder.Entity("goalswithfriends.Models.GoalsU", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("created_at")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn);

                    b.Property<string>("desc");

                    b.Property<DateTime>("endDate");

                    b.Property<string>("goal")
                        .IsRequired();

                    b.Property<DateTime>("startDate");

                    b.Property<string>("status");

                    b.Property<DateTime>("updated_at")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn);

                    b.Property<int>("usersid");

                    b.HasKey("id");

                    b.HasIndex("usersid");

                    b.ToTable("goalsuser");
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

                    b.ToTable("groups");
                });

            modelBuilder.Entity("goalswithfriends.Models.Members", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("created_at")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn);

                    b.Property<int>("groupid");

                    b.Property<int>("memberid");

                    b.Property<DateTime>("updated_at")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn);

                    b.HasKey("id");

                    b.HasIndex("groupid");

                    b.HasIndex("memberid");

                    b.ToTable("members");
                });

            modelBuilder.Entity("goalswithfriends.Models.Users", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

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

                    b.Property<bool>("privacy");

                    b.Property<DateTime>("updated_at")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn);

                    b.Property<string>("username")
                        .IsRequired();

                    b.HasKey("id");

                    b.ToTable("users");
                });

            modelBuilder.Entity("goalswithfriends.Models.GoalsG", b =>
                {
                    b.HasOne("goalswithfriends.Models.Groups", "group")
                        .WithMany("goals")
                        .HasForeignKey("groupid")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("goalswithfriends.Models.GoalsU", b =>
                {
                    b.HasOne("goalswithfriends.Models.Users", "user")
                        .WithMany("goals")
                        .HasForeignKey("usersid")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("goalswithfriends.Models.Groups", b =>
                {
                    b.HasOne("goalswithfriends.Models.Users", "owner")
                        .WithMany("groups")
                        .HasForeignKey("ownerid")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("goalswithfriends.Models.Members", b =>
                {
                    b.HasOne("goalswithfriends.Models.Groups", "group")
                        .WithMany("members")
                        .HasForeignKey("groupid")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("goalswithfriends.Models.Users", "member")
                        .WithMany()
                        .HasForeignKey("memberid")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
