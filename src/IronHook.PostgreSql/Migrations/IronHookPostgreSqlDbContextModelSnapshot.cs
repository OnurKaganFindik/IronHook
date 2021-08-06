﻿// <auto-generated />
using System;
using IronHook.PostgreSql.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace IronHook.PostgreSql.Migrations
{
    [DbContext(typeof(IronHookPostgreSqlDbContext))]
    partial class IronHookPostgreSqlDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("IronHook.Core.Entities.Hook", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("TenantId")
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdateDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("TenantId", "Name", "Key");

                    b.ToTable("Hooks", "iron-hook");
                });

            modelBuilder.Entity("IronHook.Core.Entities.HookLog", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Request")
                        .HasColumnType("text");

                    b.Property<DateTime>("RequestDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("RequestId")
                        .HasColumnType("uuid");

                    b.Property<string>("Response")
                        .HasColumnType("text");

                    b.Property<DateTime>("ResponseDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("RequestId");

                    b.ToTable("HookLogs", "iron-hook");
                });

            modelBuilder.Entity("IronHook.Core.Entities.HookRequest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Headers")
                        .HasColumnType("text");

                    b.Property<Guid>("HookId")
                        .HasColumnType("uuid");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<int>("MaxRetryCount")
                        .HasColumnType("integer");

                    b.Property<string>("Method")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NotifiyEmail")
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdateDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("HookId");

                    b.ToTable("HookRequests", "iron-hook");
                });

            modelBuilder.Entity("IronHook.Core.Entities.HookLog", b =>
                {
                    b.HasOne("IronHook.Core.Entities.HookRequest", "HookRequest")
                        .WithMany("HookLogs")
                        .HasForeignKey("RequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HookRequest");
                });

            modelBuilder.Entity("IronHook.Core.Entities.HookRequest", b =>
                {
                    b.HasOne("IronHook.Core.Entities.Hook", "Hook")
                        .WithMany("HookRequests")
                        .HasForeignKey("HookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hook");
                });

            modelBuilder.Entity("IronHook.Core.Entities.Hook", b =>
                {
                    b.Navigation("HookRequests");
                });

            modelBuilder.Entity("IronHook.Core.Entities.HookRequest", b =>
                {
                    b.Navigation("HookLogs");
                });
#pragma warning restore 612, 618
        }
    }
}
