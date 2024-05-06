﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Models;

#nullable disable

namespace Models.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240506215828_fix")]
    partial class fix
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.4");

            modelBuilder.Entity("FormationUserApplier", b =>
                {
                    b.Property<int>("AppliersId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("FormationsId")
                        .HasColumnType("INTEGER");

                    b.HasKey("AppliersId", "FormationsId");

                    b.HasIndex("FormationsId");

                    b.ToTable("FormationUserApplier");
                });

            modelBuilder.Entity("Models.Apply", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("ApplyDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("JobOfferID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MotivationLetterID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("JobOfferID");

                    b.HasIndex("MotivationLetterID");

                    b.ToTable("Applies");
                });

            modelBuilder.Entity("Models.Entreprise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Infos")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Entreprises");
                });

            modelBuilder.Entity("Models.Formation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("BeginDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Diploma")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("SchoolName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Formations");
                });

            modelBuilder.Entity("Models.JobOffer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("City")
                        .HasColumnType("TEXT");

                    b.Property<string>("CompanyName")
                        .HasColumnType("TEXT");

                    b.Property<int?>("EntrepriseID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Text")
                        .HasColumnType("TEXT");

                    b.Property<string>("Url")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("addDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("sId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("EntrepriseID");

                    b.ToTable("JobOffers");
                });

            modelBuilder.Entity("Models.MotivationLetter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("SubmissionDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserApplierID")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserApplierID");

                    b.ToTable("MotivationLetters");
                });

            modelBuilder.Entity("Models.Skills", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("YearOfPractice")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("Models.UserApplier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Age")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("HomeLocation")
                        .HasColumnType("TEXT");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("UserAppliers");
                });

            modelBuilder.Entity("SkillsUserApplier", b =>
                {
                    b.Property<int>("SkillsId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserAppliersId")
                        .HasColumnType("INTEGER");

                    b.HasKey("SkillsId", "UserAppliersId");

                    b.HasIndex("UserAppliersId");

                    b.ToTable("SkillsUserApplier");
                });

            modelBuilder.Entity("FormationUserApplier", b =>
                {
                    b.HasOne("Models.UserApplier", null)
                        .WithMany()
                        .HasForeignKey("AppliersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Formation", null)
                        .WithMany()
                        .HasForeignKey("FormationsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Models.Apply", b =>
                {
                    b.HasOne("Models.JobOffer", "JobOffer")
                        .WithMany("Applies")
                        .HasForeignKey("JobOfferID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.MotivationLetter", "MotivationLetter")
                        .WithMany("Applies")
                        .HasForeignKey("MotivationLetterID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("JobOffer");

                    b.Navigation("MotivationLetter");
                });

            modelBuilder.Entity("Models.JobOffer", b =>
                {
                    b.HasOne("Models.Entreprise", "Entreprise")
                        .WithMany("JobOffers")
                        .HasForeignKey("EntrepriseID");

                    b.Navigation("Entreprise");
                });

            modelBuilder.Entity("Models.MotivationLetter", b =>
                {
                    b.HasOne("Models.UserApplier", "Applier")
                        .WithMany("Letters")
                        .HasForeignKey("UserApplierID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Applier");
                });

            modelBuilder.Entity("SkillsUserApplier", b =>
                {
                    b.HasOne("Models.Skills", null)
                        .WithMany()
                        .HasForeignKey("SkillsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.UserApplier", null)
                        .WithMany()
                        .HasForeignKey("UserAppliersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Models.Entreprise", b =>
                {
                    b.Navigation("JobOffers");
                });

            modelBuilder.Entity("Models.JobOffer", b =>
                {
                    b.Navigation("Applies");
                });

            modelBuilder.Entity("Models.MotivationLetter", b =>
                {
                    b.Navigation("Applies");
                });

            modelBuilder.Entity("Models.UserApplier", b =>
                {
                    b.Navigation("Letters");
                });
#pragma warning restore 612, 618
        }
    }
}