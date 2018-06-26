using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace goalswithfriends.Migrations
{
    public partial class u2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_Groups_Groupsid",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_users_Groupsid",
                table: "users");

            migrationBuilder.DropColumn(
                name: "Groupsid",
                table: "users");

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    groupid = table.Column<int>(nullable: false),
                    memberid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.id);
                    table.ForeignKey(
                        name: "FK_Members_Groups_groupid",
                        column: x => x.groupid,
                        principalTable: "Groups",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Members_users_memberid",
                        column: x => x.memberid,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Members_groupid",
                table: "Members",
                column: "groupid");

            migrationBuilder.CreateIndex(
                name: "IX_Members_memberid",
                table: "Members",
                column: "memberid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.AddColumn<int>(
                name: "Groupsid",
                table: "users",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_users_Groupsid",
                table: "users",
                column: "Groupsid");

            migrationBuilder.AddForeignKey(
                name: "FK_users_Groups_Groupsid",
                table: "users",
                column: "Groupsid",
                principalTable: "Groups",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
