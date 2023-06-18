﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230618220838_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Core.Entities.Match", b =>
                {
                    b.Property<string>("MatchId")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("MatchDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("QueueId")
                        .HasColumnType("int");

                    b.HasKey("MatchId");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("Core.Entities.MatchParticipant", b =>
                {
                    b.Property<string>("MatchId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Puuid")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("Assists")
                        .HasColumnType("int");

                    b.Property<int>("ChampionId")
                        .HasColumnType("int");

                    b.Property<int>("ChampionLevel")
                        .HasColumnType("int");

                    b.Property<string>("ChampionName")
                        .HasColumnType("longtext");

                    b.Property<int>("ChampionTransform")
                        .HasColumnType("int");

                    b.Property<int>("CreepScore")
                        .HasColumnType("int");

                    b.Property<int>("Deaths")
                        .HasColumnType("int");

                    b.Property<int>("DoubleKills")
                        .HasColumnType("int");

                    b.Property<int>("GoldEarned")
                        .HasColumnType("int");

                    b.Property<string>("Items")
                        .HasColumnType("longtext");

                    b.Property<int>("Kills")
                        .HasColumnType("int");

                    b.Property<int>("PentaKills")
                        .HasColumnType("int");

                    b.Property<int>("PrimaryRuneId")
                        .HasColumnType("int");

                    b.Property<string>("PrimaryRunePerks")
                        .HasColumnType("longtext");

                    b.Property<int>("ProfileIcon")
                        .HasColumnType("int");

                    b.Property<int>("QuadraKills")
                        .HasColumnType("int");

                    b.Property<int>("SecondaryRuneId")
                        .HasColumnType("int");

                    b.Property<string>("SecondaryRunePerks")
                        .HasColumnType("longtext");

                    b.Property<string>("StatPerks")
                        .HasColumnType("longtext");

                    b.Property<int>("Summoner1Id")
                        .HasColumnType("int");

                    b.Property<int>("Summoner2Id")
                        .HasColumnType("int");

                    b.Property<string>("SummonerName")
                        .HasColumnType("longtext");

                    b.Property<string>("TeamPosition")
                        .HasColumnType("longtext");

                    b.Property<int>("TotalDamageDealtToChampions")
                        .HasColumnType("int");

                    b.Property<int>("TripleKills")
                        .HasColumnType("int");

                    b.Property<int>("VisionScore")
                        .HasColumnType("int");

                    b.Property<int>("WardsBought")
                        .HasColumnType("int");

                    b.Property<bool>("Win")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("MatchId", "Puuid");

                    b.ToTable("MatchParticipants");
                });

            modelBuilder.Entity("Core.Entities.Summoner", b =>
                {
                    b.Property<string>("Puuid")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<int>("ProfileIconId")
                        .HasColumnType("int");

                    b.Property<string>("SummonerId")
                        .HasColumnType("longtext");

                    b.Property<long>("SummonerLevel")
                        .HasColumnType("bigint");

                    b.HasKey("Puuid");

                    b.ToTable("Summoners");
                });

            modelBuilder.Entity("Core.Entities.SummonerRank", b =>
                {
                    b.Property<string>("QueueType")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("SummonerId")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("LeaguePoints")
                        .HasColumnType("int");

                    b.Property<int>("Losses")
                        .HasColumnType("int");

                    b.Property<string>("Rank")
                        .HasColumnType("longtext");

                    b.Property<string>("Tier")
                        .HasColumnType("longtext");

                    b.Property<int>("Wins")
                        .HasColumnType("int");

                    b.HasKey("QueueType", "SummonerId");

                    b.HasIndex("SummonerId");

                    b.ToTable("SummonerRanks");
                });

            modelBuilder.Entity("Core.Entities.MatchParticipant", b =>
                {
                    b.HasOne("Core.Entities.Match", "Match")
                        .WithMany("MatchParticipants")
                        .HasForeignKey("MatchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Match");
                });

            modelBuilder.Entity("Core.Entities.SummonerRank", b =>
                {
                    b.HasOne("Core.Entities.Summoner", "Summoner")
                        .WithMany("SummonerRanks")
                        .HasForeignKey("SummonerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Summoner");
                });

            modelBuilder.Entity("Core.Entities.Match", b =>
                {
                    b.Navigation("MatchParticipants");
                });

            modelBuilder.Entity("Core.Entities.Summoner", b =>
                {
                    b.Navigation("SummonerRanks");
                });
#pragma warning restore 612, 618
        }
    }
}