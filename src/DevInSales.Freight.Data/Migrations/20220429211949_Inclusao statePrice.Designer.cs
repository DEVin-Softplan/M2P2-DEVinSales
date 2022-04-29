﻿// <auto-generated />
using DevInSales.Freight.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DevInSales.Freight.Data.Migrations
{
    [DbContext(typeof(FreightContext))]
    [Migration("20220429211949_Inclusao statePrice")]
    partial class InclusaostatePrice
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DevInSales.Freight.Data.Models.ShippingCompanyModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.ToTable("shipping_company", (string)null);
                });

            modelBuilder.Entity("DevInSales.Freight.Data.Models.StateModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Initial")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("state", (string)null);
                });

            modelBuilder.Entity("DevInSales.Freight.Data.Models.StatePriceModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("BasePreco")
                        .HasMaxLength(16)
                        .HasColumnType("decimal(16,2)");

                    b.Property<int>("ShippingCompanyId")
                        .HasColumnType("int");

                    b.Property<int>("StateId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ShippingCompanyId");

                    b.HasIndex("StateId");

                    b.ToTable("state_price", (string)null);
                });

            modelBuilder.Entity("DevInSales.Freight.Data.Models.StatePriceModel", b =>
                {
                    b.HasOne("DevInSales.Freight.Data.Models.ShippingCompanyModel", "ShippingCompany")
                        .WithMany("StatesPrices")
                        .HasForeignKey("ShippingCompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DevInSales.Freight.Data.Models.StateModel", "State")
                        .WithMany("StatesPrices")
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ShippingCompany");

                    b.Navigation("State");
                });

            modelBuilder.Entity("DevInSales.Freight.Data.Models.ShippingCompanyModel", b =>
                {
                    b.Navigation("StatesPrices");
                });

            modelBuilder.Entity("DevInSales.Freight.Data.Models.StateModel", b =>
                {
                    b.Navigation("StatesPrices");
                });
#pragma warning restore 612, 618
        }
    }
}
