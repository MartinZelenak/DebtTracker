﻿// <auto-generated />
using System;
using DebtTracker.DAL.Factories.SqLite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DebtTracker.DAL.Migrations.SqLite
{
    [DbContext(typeof(SqLiteDbContext))]
    [Migration("20230704180132_Initial SqLite")]
    partial class InitialSqLite
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.7");

            modelBuilder.Entity("DebtTracker.DAL.Entities.DebtEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<uint>("Amount")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("CreditorId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("DebtorId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<Guid>("GroupId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("ResolvedDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CreditorId");

                    b.HasIndex("DebtorId");

                    b.HasIndex("GroupId");

                    b.ToTable("Debts");
                });

            modelBuilder.Entity("DebtTracker.DAL.Entities.GroupEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("PhotoUri")
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("DebtTracker.DAL.Entities.RegisteredGroupEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("GroupId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("UserId");

                    b.ToTable("RegisteredGroups");
                });

            modelBuilder.Entity("DebtTracker.DAL.Entities.UserEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("BankAccount")
                        .HasMaxLength(21)
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<string>("HashedPassword")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("PhotoUri")
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DebtTracker.DAL.Entities.DebtEntity", b =>
                {
                    b.HasOne("DebtTracker.DAL.Entities.UserEntity", "Creditor")
                        .WithMany("LentDebts")
                        .HasForeignKey("CreditorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DebtTracker.DAL.Entities.UserEntity", "Debtor")
                        .WithMany("OwesDebts")
                        .HasForeignKey("DebtorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DebtTracker.DAL.Entities.GroupEntity", "Group")
                        .WithMany("Debts")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Creditor");

                    b.Navigation("Debtor");

                    b.Navigation("Group");
                });

            modelBuilder.Entity("DebtTracker.DAL.Entities.RegisteredGroupEntity", b =>
                {
                    b.HasOne("DebtTracker.DAL.Entities.GroupEntity", "Group")
                        .WithMany("Users")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DebtTracker.DAL.Entities.UserEntity", "User")
                        .WithMany("Groups")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DebtTracker.DAL.Entities.GroupEntity", b =>
                {
                    b.Navigation("Debts");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("DebtTracker.DAL.Entities.UserEntity", b =>
                {
                    b.Navigation("Groups");

                    b.Navigation("LentDebts");

                    b.Navigation("OwesDebts");
                });
#pragma warning restore 612, 618
        }
    }
}
