using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using HRMCore.Models;

namespace HRMCore.Migrations
{
    [DbContext(typeof(HRMContext))]
    [Migration("20160903000815_initmig2")]
    partial class initmig2
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

                    b.Property<string>("Name");

                    b.HasKey("DeptId");

                    b.ToTable("Depts");
                });
        }
    }
}
