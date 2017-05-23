using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Predica.WebApp.Data.Context;
using Predica.WebApp.Enums;

namespace Predica.WebApp.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Predica.WebApp.Data.Entity.Journey", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreationDate");

                    b.Property<string>("CreatorUserObjectIdentifier")
                        .IsRequired();

                    b.Property<DateTime?>("DeleteDate");

                    b.Property<string>("Description");

                    b.Property<string>("Destination")
                        .IsRequired();

                    b.Property<DateTime>("EndDate");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("LastModificationDate");

                    b.Property<string>("LastModifierUserObjectIdentifier");

                    b.Property<DateTime>("StartDate");

                    b.Property<int>("TransportModeId");

                    b.Property<string>("TravelerObjectIdentifier")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("TransportModeId");

                    b.ToTable("Journey");
                });

            modelBuilder.Entity("Predica.WebApp.Data.Entity.TransportMode", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("TransportMode");
                });

            modelBuilder.Entity("Predica.WebApp.Data.Entity.Journey", b =>
                {
                    b.HasOne("Predica.WebApp.Data.Entity.TransportMode", "TransportMode")
                        .WithMany()
                        .HasForeignKey("TransportModeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
