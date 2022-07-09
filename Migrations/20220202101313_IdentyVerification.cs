using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VerifyMeIntegration.Migrations
{
    public partial class IdentyVerification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "AddressVerification",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 2, 2, 11, 13, 13, 693, DateTimeKind.Local).AddTicks(1862),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 2, 2, 9, 38, 32, 81, DateTimeKind.Local).AddTicks(3097));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "AddressVerification",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 2, 2, 11, 13, 13, 693, DateTimeKind.Local).AddTicks(1584),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 2, 2, 9, 38, 32, 76, DateTimeKind.Local).AddTicks(1945));

            migrationBuilder.CreateTable(
                name: "IdentityVerification",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdType = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dob = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdReference = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResponseJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpiryDate = table.Column<DateTime>(type: "date", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 2, 2, 11, 13, 13, 687, DateTimeKind.Local).AddTicks(7770)),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 2, 2, 11, 13, 13, 692, DateTimeKind.Local).AddTicks(9933))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityVerification", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IdentityVerification_IdReference",
                table: "IdentityVerification",
                column: "IdReference");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityVerification_IdType",
                table: "IdentityVerification",
                column: "IdType");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IdentityVerification");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "AddressVerification",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 2, 2, 9, 38, 32, 81, DateTimeKind.Local).AddTicks(3097),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 2, 2, 11, 13, 13, 693, DateTimeKind.Local).AddTicks(1862));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "AddressVerification",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 2, 2, 9, 38, 32, 76, DateTimeKind.Local).AddTicks(1945),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 2, 2, 11, 13, 13, 693, DateTimeKind.Local).AddTicks(1584));
        }
    }
}
