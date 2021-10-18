﻿// <auto-generated />
using System;
using FleetManager.EFCore.Infrastructure;
using FleetManager.EFCore.Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FleetManager.EFCore.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20211018135609_ForeignKeyFix")]
    partial class ForeignKeyFix
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FleetManagement.Domain.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Postcode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("FleetManagement.Domain.Models.Administration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DriverId")
                        .HasColumnType("int");

                    b.Property<int?>("GarageId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("InvoiceDate")
                        .HasColumnType("datetime2");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("DriverId");

                    b.HasIndex("GarageId");

                    b.ToTable("Administration");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Administration");
                });

            modelBuilder.Entity("FleetManagement.Domain.Models.Appeal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AppealType")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DriverId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("FirstDatePlanning")
                        .HasColumnType("datetime2");

                    b.Property<int?>("MaintenanceId")
                        .HasColumnType("int");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RepareId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("SecondDatePlanning")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int?>("VehicleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DriverId");

                    b.HasIndex("MaintenanceId")
                        .IsUnique()
                        .HasFilter("[MaintenanceId] IS NOT NULL");

                    b.HasIndex("RepareId")
                        .IsUnique()
                        .HasFilter("[RepareId] IS NOT NULL");

                    b.HasIndex("VehicleId");

                    b.ToTable("Appeals");
                });

            modelBuilder.Entity("FleetManagement.Domain.Models.ContactInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AddressId")
                        .HasColumnType("int");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("ContactInfo");
                });

            modelBuilder.Entity("FleetManagement.Domain.Models.Driver", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ContactinfoId")
                        .HasColumnType("int");

                    b.Property<int>("DriversLicenseType")
                        .HasColumnType("int");

                    b.Property<int?>("IdentityId")
                        .HasColumnType("int");

                    b.Property<bool>("InService")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("ContactinfoId");

                    b.HasIndex("IdentityId");

                    b.ToTable("Drivers");
                });

            modelBuilder.Entity("FleetManagement.Domain.Models.DriverVehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ClosureDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DriverId")
                        .HasColumnType("int");

                    b.Property<int?>("VehicleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DriverId");

                    b.HasIndex("VehicleId");

                    b.ToTable("DriverVehicle");
                });

            modelBuilder.Entity("FleetManagement.Domain.Models.File", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("Content")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("ContentType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FileType")
                        .HasColumnType("int");

                    b.Property<int?>("administrationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("administrationId");

                    b.ToTable("File");
                });

            modelBuilder.Entity("FleetManagement.Domain.Models.FuelCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AuthenticationType")
                        .HasColumnType("int");

                    b.Property<bool>("Blocked")
                        .HasColumnType("bit");

                    b.Property<string>("CardNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("FuelCardOptionsId")
                        .HasColumnType("int");

                    b.Property<string>("Pincode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FuelCardOptionsId");

                    b.ToTable("FuelCards");
                });

            modelBuilder.Entity("FleetManagement.Domain.Models.FuelCardDriver", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ClosureDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DriverId")
                        .HasColumnType("int");

                    b.Property<int?>("FuelCardId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DriverId");

                    b.HasIndex("FuelCardId");

                    b.ToTable("FuelCardDriver");
                });

            modelBuilder.Entity("FleetManagement.Domain.Models.FuelCardOptions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ExtraServices")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Fueltype")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("FuelCardOptions");
                });

            modelBuilder.Entity("FleetManagement.Domain.Models.Garage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BankaccountNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ContactInfoId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ContactInfoId");

                    b.ToTable("Garage");
                });

            modelBuilder.Entity("FleetManagement.Domain.Models.IdentityPerson", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NationalInsuranceNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("IdentityPerson");
                });

            modelBuilder.Entity("FleetManagement.Domain.Models.IdentityVehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Brand")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CarType")
                        .HasColumnType("int");

                    b.Property<string>("Chassisnumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FuelType")
                        .HasColumnType("int");

                    b.Property<string>("LicensePlates")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("IdentityVehicle");
                });

            modelBuilder.Entity("FleetManagement.Domain.Models.ListInsuranceCompanies", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("InsuranceCompanies")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("InsuranceCompanies");
                });

            modelBuilder.Entity("FleetManagement.Domain.Models.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("IdentityId")
                        .HasColumnType("int");

                    b.Property<string>("Mileage")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdentityId");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("FleetManagement.Domain.Models.Maintenance", b =>
                {
                    b.HasBaseType("FleetManagement.Domain.Models.Administration");

                    b.Property<int?>("VehicleId")
                        .HasColumnType("int");

                    b.HasIndex("VehicleId");

                    b.HasDiscriminator().HasValue("Maintenance");
                });

            modelBuilder.Entity("FleetManagement.Domain.Models.Repare", b =>
                {
                    b.HasBaseType("FleetManagement.Domain.Models.Administration");

                    b.Property<string>("DamageDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("IncidentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("InsuranceCompany")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReferenceNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ReparationStatus")
                        .HasColumnType("int");

                    b.Property<int?>("VehicleId")
                        .HasColumnType("int")
                        .HasColumnName("Repare_VehicleId");

                    b.HasIndex("VehicleId");

                    b.HasDiscriminator().HasValue("Repare");
                });

            modelBuilder.Entity("FleetManagement.Domain.Models.Administration", b =>
                {
                    b.HasOne("FleetManagement.Domain.Models.Driver", "Driver")
                        .WithMany()
                        .HasForeignKey("DriverId");

                    b.HasOne("FleetManagement.Domain.Models.Garage", "Garage")
                        .WithMany()
                        .HasForeignKey("GarageId");

                    b.Navigation("Driver");

                    b.Navigation("Garage");
                });

            modelBuilder.Entity("FleetManagement.Domain.Models.Appeal", b =>
                {
                    b.HasOne("FleetManagement.Domain.Models.Driver", "Driver")
                        .WithMany("Appeals")
                        .HasForeignKey("DriverId");

                    b.HasOne("FleetManagement.Domain.Models.Maintenance", "Maintenance")
                        .WithOne("Appeal")
                        .HasForeignKey("FleetManagement.Domain.Models.Appeal", "MaintenanceId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("FleetManagement.Domain.Models.Repare", "Repare")
                        .WithOne("Appeal")
                        .HasForeignKey("FleetManagement.Domain.Models.Appeal", "RepareId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("FleetManagement.Domain.Models.Vehicle", "Vehicle")
                        .WithMany("Appeals")
                        .HasForeignKey("VehicleId");

                    b.Navigation("Driver");

                    b.Navigation("Maintenance");

                    b.Navigation("Repare");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("FleetManagement.Domain.Models.ContactInfo", b =>
                {
                    b.HasOne("FleetManagement.Domain.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");

                    b.Navigation("Address");
                });

            modelBuilder.Entity("FleetManagement.Domain.Models.Driver", b =>
                {
                    b.HasOne("FleetManagement.Domain.Models.ContactInfo", "Contactinfo")
                        .WithMany()
                        .HasForeignKey("ContactinfoId");

                    b.HasOne("FleetManagement.Domain.Models.IdentityPerson", "Identity")
                        .WithMany()
                        .HasForeignKey("IdentityId");

                    b.Navigation("Contactinfo");

                    b.Navigation("Identity");
                });

            modelBuilder.Entity("FleetManagement.Domain.Models.DriverVehicle", b =>
                {
                    b.HasOne("FleetManagement.Domain.Models.Driver", "Driver")
                        .WithMany("DriverVehicles")
                        .HasForeignKey("DriverId");

                    b.HasOne("FleetManagement.Domain.Models.Vehicle", "Vehicle")
                        .WithMany("DriverVehicles")
                        .HasForeignKey("VehicleId");

                    b.Navigation("Driver");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("FleetManagement.Domain.Models.File", b =>
                {
                    b.HasOne("FleetManagement.Domain.Models.Administration", "administration")
                        .WithMany("Documents")
                        .HasForeignKey("administrationId");

                    b.Navigation("administration");
                });

            modelBuilder.Entity("FleetManagement.Domain.Models.FuelCard", b =>
                {
                    b.HasOne("FleetManagement.Domain.Models.FuelCardOptions", "FuelCardOptions")
                        .WithMany()
                        .HasForeignKey("FuelCardOptionsId");

                    b.Navigation("FuelCardOptions");
                });

            modelBuilder.Entity("FleetManagement.Domain.Models.FuelCardDriver", b =>
                {
                    b.HasOne("FleetManagement.Domain.Models.Driver", "Driver")
                        .WithMany("FuelCards")
                        .HasForeignKey("DriverId");

                    b.HasOne("FleetManagement.Domain.Models.FuelCard", "FuelCard")
                        .WithMany("FuelCardDrivers")
                        .HasForeignKey("FuelCardId");

                    b.Navigation("Driver");

                    b.Navigation("FuelCard");
                });

            modelBuilder.Entity("FleetManagement.Domain.Models.Garage", b =>
                {
                    b.HasOne("FleetManagement.Domain.Models.ContactInfo", "ContactInfo")
                        .WithMany()
                        .HasForeignKey("ContactInfoId");

                    b.Navigation("ContactInfo");
                });

            modelBuilder.Entity("FleetManagement.Domain.Models.Vehicle", b =>
                {
                    b.HasOne("FleetManagement.Domain.Models.IdentityVehicle", "Identity")
                        .WithMany()
                        .HasForeignKey("IdentityId");

                    b.Navigation("Identity");
                });

            modelBuilder.Entity("FleetManagement.Domain.Models.Maintenance", b =>
                {
                    b.HasOne("FleetManagement.Domain.Models.Vehicle", "Vehicle")
                        .WithMany("Maintenances")
                        .HasForeignKey("VehicleId");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("FleetManagement.Domain.Models.Repare", b =>
                {
                    b.HasOne("FleetManagement.Domain.Models.Vehicle", "Vehicle")
                        .WithMany("Reparations")
                        .HasForeignKey("VehicleId");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("FleetManagement.Domain.Models.Administration", b =>
                {
                    b.Navigation("Documents");
                });

            modelBuilder.Entity("FleetManagement.Domain.Models.Driver", b =>
                {
                    b.Navigation("Appeals");

                    b.Navigation("DriverVehicles");

                    b.Navigation("FuelCards");
                });

            modelBuilder.Entity("FleetManagement.Domain.Models.FuelCard", b =>
                {
                    b.Navigation("FuelCardDrivers");
                });

            modelBuilder.Entity("FleetManagement.Domain.Models.Vehicle", b =>
                {
                    b.Navigation("Appeals");

                    b.Navigation("DriverVehicles");

                    b.Navigation("Maintenances");

                    b.Navigation("Reparations");
                });

            modelBuilder.Entity("FleetManagement.Domain.Models.Maintenance", b =>
                {
                    b.Navigation("Appeal");
                });

            modelBuilder.Entity("FleetManagement.Domain.Models.Repare", b =>
                {
                    b.Navigation("Appeal");
                });
#pragma warning restore 612, 618
        }
    }
}
