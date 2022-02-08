﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Rusell.TransportSheets.Shared.Infrastructure.Persistence.EntityFramework;

#nullable disable

namespace Rusell.TransportSheets.Migrations
{
    [DbContext(typeof(TransportSheetsDbContext))]
    [Migration("20220208155320_AddRouteId")]
    partial class AddRouteId
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Rusell.TransportSheets.Domain.TransportSheet", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("DispatcherId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("dispatcher_id");

                    b.HasKey("Id")
                        .HasName("pk_transport_sheets");

                    b.HasIndex("DispatcherId")
                        .HasDatabaseName("ix_transport_sheets_dispatcher_id");

                    b.ToTable("transport_sheets", (string)null);
                });

            modelBuilder.Entity("Rusell.TransportSheets.Employees.Domain.Employee", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text")
                        .HasColumnName("id");

                    b.HasKey("Id")
                        .HasName("pk_employees");

                    b.ToTable("employees", (string)null);
                });

            modelBuilder.Entity("Rusell.TransportSheets.Domain.TransportSheet", b =>
                {
                    b.HasOne("Rusell.TransportSheets.Employees.Domain.Employee", "Dispatcher")
                        .WithMany("TransportSheets")
                        .HasForeignKey("DispatcherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_transport_sheets_employees_dispatcher_temp_id");

                    b.OwnsOne("Rusell.TransportSheets.Domain.CompanyId", "CompanyId", b1 =>
                        {
                            b1.Property<Guid>("TransportSheetId")
                                .HasColumnType("uuid")
                                .HasColumnName("id");

                            b1.Property<Guid>("Value")
                                .HasColumnType("uuid")
                                .HasColumnName("company_id");

                            b1.HasKey("TransportSheetId");

                            b1.HasIndex("Value")
                                .HasDatabaseName("ix_transport_sheets_company_id");

                            b1.ToTable("transport_sheets");

                            b1.WithOwner()
                                .HasForeignKey("TransportSheetId")
                                .HasConstraintName("fk_transport_sheets_transport_sheets_id");
                        });

                    b.OwnsOne("Rusell.TransportSheets.Domain.RouteId", "RouteId", b1 =>
                        {
                            b1.Property<Guid>("TransportSheetId")
                                .HasColumnType("uuid")
                                .HasColumnName("id");

                            b1.Property<Guid>("Value")
                                .HasColumnType("uuid")
                                .HasColumnName("route_id");

                            b1.HasKey("TransportSheetId");

                            b1.HasIndex("Value")
                                .HasDatabaseName("ix_transport_sheets_route_id");

                            b1.ToTable("transport_sheets");

                            b1.WithOwner()
                                .HasForeignKey("TransportSheetId")
                                .HasConstraintName("fk_transport_sheets_transport_sheets_id");
                        });

                    b.OwnsOne("Rusell.TransportSheets.Domain.TransportSheetDate", "Date", b1 =>
                        {
                            b1.Property<Guid>("TransportSheetId")
                                .HasColumnType("uuid")
                                .HasColumnName("id");

                            b1.Property<DateTime>("Value")
                                .HasColumnType("timestamp with time zone")
                                .HasColumnName("date");

                            b1.HasKey("TransportSheetId");

                            b1.ToTable("transport_sheets");

                            b1.WithOwner()
                                .HasForeignKey("TransportSheetId")
                                .HasConstraintName("fk_transport_sheets_transport_sheets_id");
                        });

                    b.OwnsOne("Rusell.TransportSheets.Domain.TransportSheetDate", "DepartureTime", b1 =>
                        {
                            b1.Property<Guid>("TransportSheetId")
                                .HasColumnType("uuid")
                                .HasColumnName("id");

                            b1.Property<DateTime>("Value")
                                .HasColumnType("timestamp with time zone")
                                .HasColumnName("departure_time");

                            b1.HasKey("TransportSheetId");

                            b1.ToTable("transport_sheets");

                            b1.WithOwner()
                                .HasForeignKey("TransportSheetId")
                                .HasConstraintName("fk_transport_sheets_transport_sheets_id");
                        });

                    b.OwnsOne("Rusell.TransportSheets.Domain.TransportSheetQuota", "Quota", b1 =>
                        {
                            b1.Property<Guid>("TransportSheetId")
                                .HasColumnType("uuid")
                                .HasColumnName("id");

                            b1.Property<long>("Value")
                                .HasColumnType("bigint")
                                .HasColumnName("quota");

                            b1.HasKey("TransportSheetId");

                            b1.ToTable("transport_sheets");

                            b1.WithOwner()
                                .HasForeignKey("TransportSheetId")
                                .HasConstraintName("fk_transport_sheets_transport_sheets_id");
                        });

                    b.OwnsOne("Rusell.TransportSheets.Domain.VehicleLicensePlate", "VehicleLicensePlate", b1 =>
                        {
                            b1.Property<Guid>("TransportSheetId")
                                .HasColumnType("uuid")
                                .HasColumnName("id");

                            b1.Property<string>("Value")
                                .HasColumnType("text")
                                .HasColumnName("vehicle_license_plate");

                            b1.HasKey("TransportSheetId");

                            b1.HasIndex("Value")
                                .HasDatabaseName("ix_transport_sheets_vehicle_license_plate");

                            b1.ToTable("transport_sheets");

                            b1.WithOwner()
                                .HasForeignKey("TransportSheetId")
                                .HasConstraintName("fk_transport_sheets_transport_sheets_id");
                        });

                    b.Navigation("CompanyId")
                        .IsRequired();

                    b.Navigation("Date")
                        .IsRequired();

                    b.Navigation("DepartureTime");

                    b.Navigation("Dispatcher");

                    b.Navigation("Quota")
                        .IsRequired();

                    b.Navigation("RouteId")
                        .IsRequired();

                    b.Navigation("VehicleLicensePlate")
                        .IsRequired();
                });

            modelBuilder.Entity("Rusell.TransportSheets.Employees.Domain.Employee", b =>
                {
                    b.OwnsOne("Rusell.TransportSheets.Employees.Domain.EmployeeName", "FullName", b1 =>
                        {
                            b1.Property<string>("EmployeeId")
                                .HasColumnType("text")
                                .HasColumnName("id");

                            b1.Property<string>("Value")
                                .HasMaxLength(256)
                                .HasColumnType("character varying(256)")
                                .HasColumnName("full_name");

                            b1.HasKey("EmployeeId");

                            b1.ToTable("employees");

                            b1.WithOwner()
                                .HasForeignKey("EmployeeId")
                                .HasConstraintName("fk_employees_employees_id");
                        });

                    b.Navigation("FullName")
                        .IsRequired();
                });

            modelBuilder.Entity("Rusell.TransportSheets.Employees.Domain.Employee", b =>
                {
                    b.Navigation("TransportSheets");
                });
#pragma warning restore 612, 618
        }
    }
}
