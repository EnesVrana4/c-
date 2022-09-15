﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SocialApp.Models;

#nullable disable

namespace SocialApp.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20220915083752_SocialAppMigrations3")]
    partial class SocialAppMigrations3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("SocialApp.Models.Comment", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("CommentId");

                    b.HasIndex("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("SocialApp.Models.CommentLike", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("CommentId1")
                        .HasColumnType("int");

                    b.Property<int>("LikeId")
                        .HasColumnType("int");

                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("CommentId");

                    b.HasIndex("CommentId1");

                    b.HasIndex("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("CommentLikes");
                });

            modelBuilder.Entity("SocialApp.Models.Like", b =>
                {
                    b.Property<int>("LikeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LikeId");

                    b.HasIndex("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("Likes");
                });

            modelBuilder.Entity("SocialApp.Models.Post", b =>
                {
                    b.Property<int>("PostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("PostContent")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("SocialApp.Models.Request", b =>
                {
                    b.Property<int>("RequestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("Accepted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("ReciverId")
                        .HasColumnType("int");

                    b.Property<int>("SenderId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId1")
                        .HasColumnType("int");

                    b.HasKey("RequestId");

                    b.HasIndex("ReciverId");

                    b.HasIndex("SenderId");

                    b.HasIndex("UserId");

                    b.HasIndex("UserId1");

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("SocialApp.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("CreatedPostUserId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("UserId");

                    b.HasIndex("CreatedPostUserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SocialApp.Models.Comment", b =>
                {
                    b.HasOne("SocialApp.Models.Post", "PostiQePelqehet")
                        .WithMany("Comments")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SocialApp.Models.User", "UseriQePelqen")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PostiQePelqehet");

                    b.Navigation("UseriQePelqen");
                });

            modelBuilder.Entity("SocialApp.Models.CommentLike", b =>
                {
                    b.HasOne("SocialApp.Models.Comment", null)
                        .WithMany("CommentLikes")
                        .HasForeignKey("CommentId1");

                    b.HasOne("SocialApp.Models.Post", "PostiQePelqehet")
                        .WithMany()
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SocialApp.Models.User", "UseriQePelqen")
                        .WithMany("CommentLikes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PostiQePelqehet");

                    b.Navigation("UseriQePelqen");
                });

            modelBuilder.Entity("SocialApp.Models.Like", b =>
                {
                    b.HasOne("SocialApp.Models.Post", "UseriQePelqehet")
                        .WithMany("Likes")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SocialApp.Models.User", "UseriQePelqen")
                        .WithMany("Likes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UseriQePelqehet");

                    b.Navigation("UseriQePelqen");
                });

            modelBuilder.Entity("SocialApp.Models.Post", b =>
                {
                    b.HasOne("SocialApp.Models.User", "Creator")
                        .WithMany("Posts")
                        .HasForeignKey("UserId");

                    b.Navigation("Creator");
                });

            modelBuilder.Entity("SocialApp.Models.Request", b =>
                {
                    b.HasOne("SocialApp.Models.User", "Reciver")
                        .WithMany("Sender")
                        .HasForeignKey("ReciverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SocialApp.Models.User", "Sender")
                        .WithMany("SenderRequests")
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SocialApp.Models.User", null)
                        .WithMany("ReciverRequests")
                        .HasForeignKey("UserId");

                    b.HasOne("SocialApp.Models.User", null)
                        .WithMany("Requests")
                        .HasForeignKey("UserId1");

                    b.Navigation("Reciver");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("SocialApp.Models.User", b =>
                {
                    b.HasOne("SocialApp.Models.User", "CreatedPost")
                        .WithMany()
                        .HasForeignKey("CreatedPostUserId");

                    b.Navigation("CreatedPost");
                });

            modelBuilder.Entity("SocialApp.Models.Comment", b =>
                {
                    b.Navigation("CommentLikes");
                });

            modelBuilder.Entity("SocialApp.Models.Post", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Likes");
                });

            modelBuilder.Entity("SocialApp.Models.User", b =>
                {
                    b.Navigation("CommentLikes");

                    b.Navigation("Comments");

                    b.Navigation("Likes");

                    b.Navigation("Posts");

                    b.Navigation("ReciverRequests");

                    b.Navigation("Requests");

                    b.Navigation("Sender");

                    b.Navigation("SenderRequests");
                });
#pragma warning restore 612, 618
        }
    }
}
