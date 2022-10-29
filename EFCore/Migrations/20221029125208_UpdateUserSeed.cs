using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore.Migrations
{
    public partial class UpdateUserSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: new Guid("fcb33d6a-177e-4f41-9855-7975c7b77950"),
                column: "Password",
                value: "$2a$11$2yetTvA.CA3opcE1Ixr1I.WBqBEZsrl0vI2MWPhAYT6tt0/rf5XWa");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: new Guid("fcb33d6a-177e-4f41-9855-7975c7b77950"),
                column: "Password",
                value: "123456");
        }
    }
}
