﻿// <auto-generated />
using System;
using AttendenceManagementSystem.Attendence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AttendenceManagementSystem.Data.Migrations
{
    [DbContext(typeof(AttendenceDbContext))]
    [Migration("20210818151744_AddStudentAndAttendence")]
    partial class AddStudentAndAttendence
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AttendenceManagementSystem.Attendence.Entities.Attendance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.ToTable("Attendance");
                });

            modelBuilder.Entity("AttendenceManagementSystem.Attendence.Entities.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StudentRollNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("AttendenceManagementSystem.Attendence.Entities.Attendance", b =>
                {
                    b.HasOne("AttendenceManagementSystem.Attendence.Entities.Student", "Student")
                        .WithMany("Attendances")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("AttendenceManagementSystem.Attendence.Entities.Student", b =>
                {
                    b.Navigation("Attendances");
                });
#pragma warning restore 612, 618
        }
    }
}
