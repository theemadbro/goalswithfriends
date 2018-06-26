using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace goalswithfriends.Migrations
{
    public partial class u1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EndDate",
                table: "Goals",
                newName: "endDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "endDate",
                table: "Goals",
                newName: "EndDate");
        }
    }
}
