﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IronHook.PostgreSql.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "iron-hook");

            migrationBuilder.CreateTable(
                name: "Hooks",
                schema: "iron-hook",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TenantId = table.Column<string>(type: "text", nullable: true),
                    Key = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hooks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HookRequests",
                schema: "iron-hook",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    HookId = table.Column<Guid>(type: "uuid", nullable: false),
                    Url = table.Column<string>(type: "text", nullable: false),
                    Method = table.Column<string>(type: "text", nullable: false),
                    Headers = table.Column<string>(type: "text", nullable: true),
                    MaxRetryCount = table.Column<int>(type: "integer", nullable: false),
                    NotifiyEmail = table.Column<string>(type: "text", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HookRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HookRequests_Hooks_HookId",
                        column: x => x.HookId,
                        principalSchema: "iron-hook",
                        principalTable: "Hooks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HookLogs",
                schema: "iron-hook",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RequestId = table.Column<Guid>(type: "uuid", nullable: false),
                    Request = table.Column<string>(type: "text", nullable: true),
                    Response = table.Column<string>(type: "text", nullable: true),
                    RequestDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ResponseDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HookLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HookLogs_HookRequests_RequestId",
                        column: x => x.RequestId,
                        principalSchema: "iron-hook",
                        principalTable: "HookRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HookLogs_RequestId",
                schema: "iron-hook",
                table: "HookLogs",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_HookRequests_HookId",
                schema: "iron-hook",
                table: "HookRequests",
                column: "HookId");

            migrationBuilder.CreateIndex(
                name: "IX_Hooks_TenantId_Name_Key",
                schema: "iron-hook",
                table: "Hooks",
                columns: new[] { "TenantId", "Name", "Key" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HookLogs",
                schema: "iron-hook");

            migrationBuilder.DropTable(
                name: "HookRequests",
                schema: "iron-hook");

            migrationBuilder.DropTable(
                name: "Hooks",
                schema: "iron-hook");
        }
    }
}
