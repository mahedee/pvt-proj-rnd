using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using HRMCore.Models;

namespace HRMCore.Migrations
{
    [DbContext(typeof(HRMContext))]
    [Migration("20160903033257_mig4")]
    partial class mig4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HRMCore.Models.Dept", b =>
                {
                    b.Property<int>("DeptId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("ActionDate");

                    b.Property<string>("Name");

                    b.HasKey("DeptId");

                    b.ToTable("Depts");
                });

            modelBuilder.Entity("HRMCore.Models.Designation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("ActionDate");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Designations");
                });

            modelBuilder.Entity("HRMCore.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("ActionDate");

                    b.Property<string>("Address");

                    b.Property<int>("DeptId");

                    b.Property<int>("DesignationId");

                    b.Property<string>("Email");

                    b.Property<string>("EmpCode");

                    b.Property<string>("FullName");

                    b.Property<string>("NickName");

                    b.Property<string>("Phone");

                    b.HasKey("Id");

                    b.HasIndex("DeptId");

                    b.HasIndex("DesignationId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("HRMCore.Models.Employee", b =>
                {
                    b.HasOne("HRMCore.Models.Dept", "Dept")
                        .WithMany("Employees")
                        .HasForeignKey("DeptId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HRMCore.Models.Designation", "Designation")
                        .WithMany("Employees")
                        .HasForeignKey("DesignationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
