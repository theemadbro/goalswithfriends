using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace goalswithfriends.Migrations
{
    public partial class Migrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Goals",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EndDate = table.Column<DateTime>(nullable: false),
                    created_at = table.Column<DateTime>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    desc = table.Column<string>(nullable: true),
                    goal = table.Column<string>(nullable: true),
                    groupid = table.Column<int>(nullable: false),
                    startDate = table.Column<DateTime>(nullable: false),
                    status = table.Column<string>(nullable: true),
                    updated_at = table.Column<DateTime>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    usersid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Goals", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Groupsid = table.Column<int>(nullable: true),
                    bio = table.Column<string>(nullable: true),
                    birthday = table.Column<DateTime>(nullable: false),
                    created_at = table.Column<DateTime>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    email = table.Column<string>(nullable: false),
                    first_name = table.Column<string>(nullable: false),
                    last_name = table.Column<string>(nullable: false),
                    password = table.Column<string>(nullable: false),
                    updated_at = table.Column<DateTime>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    created_at = table.Column<DateTime>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    desc = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: false),
                    ownerid = table.Column<int>(nullable: false),
                    password = table.Column<string>(nullable: true),
                    updated_at = table.Column<DateTime>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.id);
                    table.ForeignKey(
                        name: "FK_Groups_users_ownerid",
                        column: x => x.ownerid,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Goals_groupid",
                table: "Goals",
                column: "groupid");

            migrationBuilder.CreateIndex(
                name: "IX_Goals_usersid",
                table: "Goals",
                column: "usersid");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_ownerid",
                table: "Groups",
                column: "ownerid");

            migrationBuilder.CreateIndex(
                name: "IX_users_Groupsid",
                table: "users",
                column: "Groupsid");

            migrationBuilder.AddForeignKey(
                name: "FK_Goals_Groups_groupid",
                table: "Goals",
                column: "groupid",
                principalTable: "Groups",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Goals_users_usersid",
                table: "Goals",
                column: "usersid",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_users_Groups_Groupsid",
                table: "users",
                column: "Groupsid",
                principalTable: "Groups",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_Groups_Groupsid",
                table: "users");

            migrationBuilder.DropTable(
                name: "Goals");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
