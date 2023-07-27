﻿// <auto-generated />
using DadBot.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DadBot.Migrations
{
    [DbContext(typeof(DadBotDbContext))]
    partial class DadBotDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DadBot.Models.LOLModels.Champion", b =>
                {
                    b.Property<int>("ChampionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ChampionID"));

                    b.Property<string>("ChampionName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ChampionID");

                    b.ToTable("Champions");
                });

            modelBuilder.Entity("DadBot.Models.LOLModels.Summoner", b =>
                {
                    b.Property<string>("PUUID")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("PUUID");

                    b.ToTable("Summoners");
                });
#pragma warning restore 612, 618
        }
    }
}
