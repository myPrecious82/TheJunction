using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using TheJunction.Data;

namespace TheJunction.Migrations
{
    [DbContext(typeof(MyContext))]
    partial class MyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TheJunction.Models.CodeDesc", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<int>("CreatedBy");

                    b.Property<string>("Description");

                    b.Property<string>("GroupId");

                    b.Property<DateTime>("Modified");

                    b.Property<int>("ModifiedBy");

                    b.Property<int>("Order");

                    b.HasKey("Id");

                    b.ToTable("CodeDesc");
                });

            modelBuilder.Entity("TheJunction.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address1")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("Address2")
                        .HasMaxLength(200);

                    b.Property<int>("CellCarrierId");

                    b.Property<string>("CellNumber")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<DateTime>("Created");

                    b.Property<int>("CreatedBy");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<bool>("IsActive");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<DateTime>("Modified");

                    b.Property<int>("ModifiedBy");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Zip")
                        .IsRequired()
                        .HasMaxLength(5);

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("TheJunction.Models.EmployeeHandbook", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content");

                    b.Property<DateTime>("Created");

                    b.Property<int>("CreatedBy");

                    b.Property<DateTime>("Modified");

                    b.Property<int>("ModifiedBy");

                    b.Property<int>("Version");

                    b.HasKey("Id");

                    b.ToTable("EmployeeHandbooks");
                });

            modelBuilder.Entity("TheJunction.Models.EmployeeHandbookAcceptance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<int>("CreatedBy");

                    b.Property<int?>("EmployeeHandbookId");

                    b.Property<int?>("EmployeeId");

                    b.Property<bool>("IsAccepted");

                    b.Property<DateTime>("Modified");

                    b.Property<int>("ModifiedBy");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeHandbookId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("EmployeeHandbookAcceptances");
                });

            modelBuilder.Entity("TheJunction.Models.Schedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<int>("CreatedBy");

                    b.Property<DateTime>("Modified");

                    b.Property<int>("ModifiedBy");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("Id");

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("TheJunction.Models.Shift", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<int>("CreatedBy");

                    b.Property<DateTime>("Day");

                    b.Property<int?>("EmployeeId");

                    b.Property<DateTime>("EndTime");

                    b.Property<bool>("IsOnCall");

                    b.Property<DateTime>("Modified");

                    b.Property<int>("ModifiedBy");

                    b.Property<int>("ScheduleId");

                    b.Property<DateTime>("StartTime");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("ScheduleId");

                    b.ToTable("Shifts");
                });

            modelBuilder.Entity("TheJunction.Models.ShiftTradeRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<int>("CreatedBy");

                    b.Property<int>("Employee1ShiftId");

                    b.Property<int>("Employee2ShiftId");

                    b.Property<int?>("EmployeeId");

                    b.Property<string>("Explanation");

                    b.Property<bool>("IsApproved");

                    b.Property<bool>("IsDenied");

                    b.Property<bool>("IsEmployee2Approved");

                    b.Property<DateTime>("Modified");

                    b.Property<int>("ModifiedBy");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("ShiftTradeRequests");
                });

            modelBuilder.Entity("TheJunction.Models.TimeOffRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<int>("CreatedBy");

                    b.Property<int?>("EmployeeId");

                    b.Property<string>("Explanation");

                    b.Property<bool>("IsApproved");

                    b.Property<bool>("IsDenied");

                    b.Property<DateTime>("Modified");

                    b.Property<int>("ModifiedBy");

                    b.Property<int>("Reason");

                    b.Property<DateTime>("RequestedDate");

                    b.Property<int>("TimeNeeded");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("TimeOffRequests");
                });

            modelBuilder.Entity("TheJunction.Models.TimeSheet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<int>("CreatedBy");

                    b.Property<int?>("EmployeeId");

                    b.Property<DateTime>("EndTimestamp");

                    b.Property<bool>("IsOnCall");

                    b.Property<DateTime>("Modified");

                    b.Property<int>("ModifiedBy");

                    b.Property<DateTime>("StartTimestamp");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("TimeSheets");
                });

            modelBuilder.Entity("TheJunction.Models.EmployeeHandbookAcceptance", b =>
                {
                    b.HasOne("TheJunction.Models.EmployeeHandbook")
                        .WithMany("EmployeeHandbookAcceptances")
                        .HasForeignKey("EmployeeHandbookId");

                    b.HasOne("TheJunction.Models.Employee")
                        .WithMany("HandbookAcceptances")
                        .HasForeignKey("EmployeeId");
                });

            modelBuilder.Entity("TheJunction.Models.Shift", b =>
                {
                    b.HasOne("TheJunction.Models.Employee")
                        .WithMany("Shifts")
                        .HasForeignKey("EmployeeId");

                    b.HasOne("TheJunction.Models.Schedule")
                        .WithMany("Shifts")
                        .HasForeignKey("ScheduleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TheJunction.Models.ShiftTradeRequest", b =>
                {
                    b.HasOne("TheJunction.Models.Employee")
                        .WithMany("ShiftTradeRequests")
                        .HasForeignKey("EmployeeId");
                });

            modelBuilder.Entity("TheJunction.Models.TimeOffRequest", b =>
                {
                    b.HasOne("TheJunction.Models.Employee")
                        .WithMany("TimeOffRequests")
                        .HasForeignKey("EmployeeId");
                });

            modelBuilder.Entity("TheJunction.Models.TimeSheet", b =>
                {
                    b.HasOne("TheJunction.Models.Employee")
                        .WithMany("TimeSheets")
                        .HasForeignKey("EmployeeId");
                });
        }
    }
}
