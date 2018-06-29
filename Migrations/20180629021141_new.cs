using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace goalswithfriends.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "goals");

            migrationBuilder.CreateTable(
                name: "goalsgroup",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    created_at = table.Column<DateTime>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    creator = table.Column<string>(nullable: true),
                    desc = table.Column<string>(nullable: true),
                    endDate = table.Column<DateTime>(nullable: false),
                    goal = table.Column<string>(nullable: false),
                    groupid = table.Column<int>(nullable: false),
                    startDate = table.Column<DateTime>(nullable: false),
                    status = table.Column<string>(nullable: true),
                    updated_at = table.Column<DateTime>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_goalsgroup", x => x.id);
                    table.ForeignKey(
                        name: "FK_goalsgroup_groups_groupid",
                        column: x => x.groupid,
                        principalTable: "groups",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "goalsuser",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    created_at = table.Column<DateTime>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    desc = table.Column<string>(nullable: true),
                    endDate = table.Column<DateTime>(nullable: false),
                    goal = table.Column<string>(nullable: false),
                    startDate = table.Column<DateTime>(nullable: false),
                    status = table.Column<string>(nullable: true),
                    updated_at = table.Column<DateTime>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    usersid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_goalsuser", x => x.id);
                    table.ForeignKey(
                        name: "FK_goalsuser_users_usersid",
                        column: x => x.usersid,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_goalsgroup_groupid",
                table: "goalsgroup",
                column: "groupid");

            migrationBuilder.CreateIndex(
                name: "IX_goalsuser_usersid",
                table: "goalsuser",
                column: "usersid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "goalsgroup");

            migrationBuilder.DropTable(
                name: "goalsuser");

            migrationBuilder.CreateTable(
                name: "goals",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    created_at = table.Column<DateTime>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    desc = table.Column<string>(nullable: true),
                    endDate = table.Column<DateTime>(nullable: false),
                    goal = table.Column<string>(nullable: false),
                    groupid = table.Column<int>(nullable: false),
                    startDate = table.Column<DateTime>(nullable: false),
                    status = table.Column<string>(nullable: true),
                    updated_at = table.Column<DateTime>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    usersid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_goals", x => x.id);
                    table.ForeignKey(
                        name: "FK_goals_groups_groupid",
                        column: x => x.groupid,
                        principalTable: "groups",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_goals_users_usersid",
                        column: x => x.usersid,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_goals_groupid",
                table: "goals",
                column: "groupid");

            migrationBuilder.CreateIndex(
                name: "IX_goals_usersid",
                table: "goals",
                column: "usersid");
        }
    }
}
