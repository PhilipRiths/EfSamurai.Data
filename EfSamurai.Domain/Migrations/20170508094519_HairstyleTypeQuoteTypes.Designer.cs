using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using EfSamurai.Data;

namespace EfSamurai.Data.Migrations
{
    [DbContext(typeof(SamuraiContextModelSnapshot))]
    [Migration("20170508094519_HairstyleTypeQuoteTypes")]
    partial class HairstyleTypeQuoteTypes
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EfSamurai.Domain.HairStyle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.HasKey("Id");

                    b.ToTable("HairStyle");
                });

            modelBuilder.Entity("EfSamurai.Domain.Quotes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("QuouteTypesId");

                    b.Property<int>("SamuraiId");

                    b.Property<string>("SamuraiQuotes");

                    b.HasKey("Id");

                    b.HasIndex("QuouteTypesId");

                    b.HasIndex("SamuraiId");

                    b.ToTable("Quotes");
                });

            modelBuilder.Entity("EfSamurai.Domain.QuoteTypes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.HasKey("Id");

                    b.ToTable("QuoteTypes");
                });

            modelBuilder.Entity("EfSamurai.Domain.Samurai", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("HairStyleTypesId");

                    b.Property<int>("Healthpoints");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("HairStyleTypesId");

                    b.ToTable("Samurais");
                });

            modelBuilder.Entity("EfSamurai.Domain.Quotes", b =>
                {
                    b.HasOne("EfSamurai.Domain.QuoteTypes", "QuouteTypes")
                        .WithMany()
                        .HasForeignKey("QuouteTypesId");

                    b.HasOne("EfSamurai.Domain.Samurai", "Samurai")
                        .WithMany("Quote")
                        .HasForeignKey("SamuraiId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EfSamurai.Domain.Samurai", b =>
                {
                    b.HasOne("EfSamurai.Domain.HairStyle", "HairStyleTypes")
                        .WithMany()
                        .HasForeignKey("HairStyleTypesId");
                });
        }
    }
}
