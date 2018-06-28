using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace goalswithfriends.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Goals_Groups_groupid",
                table: "Goals");

            migrationBuilder.DropForeignKey(
                name: "FK_Goals_users_usersid",
                table: "Goals");

            migrationBuilder.DropForeignKey(
                name: "FK_Groups_users_ownerid",
                table: "Groups");

            migrationBuilder.DropForeignKey(
                name: "FK_Members_Groups_groupid",
                table: "Members");

            migrationBuilder.DropForeignKey(
                name: "FK_Members_users_memberid",
                table: "Members");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Members",
                table: "Members");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Groups",
                table: "Groups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Goals",
                table: "Goals");

            migrationBuilder.RenameTable(
                name: "Members",
                newName: "members");

            migrationBuilder.RenameTable(
                name: "Groups",
                newName: "groups");

            migrationBuilder.RenameTable(
                name: "Goals",
                newName: "goals");

            migrationBuilder.RenameIndex(
                name: "IX_Members_memberid",
                table: "members",
                newName: "IX_members_memberid");

            migrationBuilder.RenameIndex(
                name: "IX_Members_groupid",
                table: "members",
                newName: "IX_members_groupid");

            migrationBuilder.RenameIndex(
                name: "IX_Groups_ownerid",
                table: "groups",
                newName: "IX_groups_ownerid");

            migrationBuilder.RenameIndex(
                name: "IX_Goals_usersid",
                table: "goals",
                newName: "IX_goals_usersid");

            migrationBuilder.RenameIndex(
                name: "IX_Goals_groupid",
                table: "goals",
                newName: "IX_goals_groupid");

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "members",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                table: "members",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn);

            migrationBuilder.AlterColumn<string>(
                name: "goal",
                table: "goals",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_members",
                table: "members",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_groups",
                table: "groups",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_goals",
                table: "goals",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_goals_groups_groupid",
                table: "goals",
                column: "groupid",
                principalTable: "groups",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_goals_users_usersid",
                table: "goals",
                column: "usersid",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_groups_users_ownerid",
                table: "groups",
                column: "ownerid",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_members_groups_groupid",
                table: "members",
                column: "groupid",
                principalTable: "groups",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_members_users_memberid",
                table: "members",
                column: "memberid",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_goals_groups_groupid",
                table: "goals");

            migrationBuilder.DropForeignKey(
                name: "FK_goals_users_usersid",
                table: "goals");

            migrationBuilder.DropForeignKey(
                name: "FK_groups_users_ownerid",
                table: "groups");

            migrationBuilder.DropForeignKey(
                name: "FK_members_groups_groupid",
                table: "members");

            migrationBuilder.DropForeignKey(
                name: "FK_members_users_memberid",
                table: "members");

            migrationBuilder.DropPrimaryKey(
                name: "PK_members",
                table: "members");

            migrationBuilder.DropPrimaryKey(
                name: "PK_groups",
                table: "groups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_goals",
                table: "goals");

            migrationBuilder.DropColumn(
                name: "created_at",
                table: "members");

            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "members");

            migrationBuilder.RenameTable(
                name: "members",
                newName: "Members");

            migrationBuilder.RenameTable(
                name: "groups",
                newName: "Groups");

            migrationBuilder.RenameTable(
                name: "goals",
                newName: "Goals");

            migrationBuilder.RenameIndex(
                name: "IX_members_memberid",
                table: "Members",
                newName: "IX_Members_memberid");

            migrationBuilder.RenameIndex(
                name: "IX_members_groupid",
                table: "Members",
                newName: "IX_Members_groupid");

            migrationBuilder.RenameIndex(
                name: "IX_groups_ownerid",
                table: "Groups",
                newName: "IX_Groups_ownerid");

            migrationBuilder.RenameIndex(
                name: "IX_goals_usersid",
                table: "Goals",
                newName: "IX_Goals_usersid");

            migrationBuilder.RenameIndex(
                name: "IX_goals_groupid",
                table: "Goals",
                newName: "IX_Goals_groupid");

            migrationBuilder.AlterColumn<string>(
                name: "goal",
                table: "Goals",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Members",
                table: "Members",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Groups",
                table: "Groups",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Goals",
                table: "Goals",
                column: "id");

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
                name: "FK_Groups_users_ownerid",
                table: "Groups",
                column: "ownerid",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Groups_groupid",
                table: "Members",
                column: "groupid",
                principalTable: "Groups",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Members_users_memberid",
                table: "Members",
                column: "memberid",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
