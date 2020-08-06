﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuickPicSurvey.API.Data;

namespace QuickPicSurvey.API.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20200805202022_MyFirstMigration")]
    partial class MyFirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6");

            modelBuilder.Entity("QuickPicSurvey.API.Models.Objective", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Expectation")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Question")
                        .HasColumnType("TEXT");

                    b.Property<int>("QuestionID")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Objectives");
                });

            modelBuilder.Entity("QuickPicSurvey.API.Models.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastChangedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastChangedDate")
                        .HasColumnType("TEXT");

                    b.Property<int?>("RespondentId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("RespondentResultId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("RespondentId");

                    b.HasIndex("RespondentResultId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("QuickPicSurvey.API.Models.Respondent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastChangedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastChangedDate")
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("BLOB");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("BLOB");

                    b.Property<int?>("RespondentResultId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Surname")
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RespondentResultId");

                    b.ToTable("Respondents");
                });

            modelBuilder.Entity("QuickPicSurvey.API.Models.RespondentResult", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("QuestionId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RespondentId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RespondentsWeight")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("RespondentResults");
                });

            modelBuilder.Entity("QuickPicSurvey.API.Models.Question", b =>
                {
                    b.HasOne("QuickPicSurvey.API.Models.Respondent", null)
                        .WithMany("Questions")
                        .HasForeignKey("RespondentId");

                    b.HasOne("QuickPicSurvey.API.Models.RespondentResult", null)
                        .WithMany("Question")
                        .HasForeignKey("RespondentResultId");
                });

            modelBuilder.Entity("QuickPicSurvey.API.Models.Respondent", b =>
                {
                    b.HasOne("QuickPicSurvey.API.Models.RespondentResult", null)
                        .WithMany("Respondent")
                        .HasForeignKey("RespondentResultId");
                });
#pragma warning restore 612, 618
        }
    }
}