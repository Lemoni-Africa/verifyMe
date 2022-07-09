using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VerifyMeIntegration.Migrations
{
    public partial class ApiCalls2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "IdentityVerification",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 9, 11, 17, 28, 710, DateTimeKind.Local).AddTicks(415),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 9, 10, 36, 11, 828, DateTimeKind.Local).AddTicks(7984));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "IdentityVerification",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 9, 11, 17, 28, 709, DateTimeKind.Local).AddTicks(9829),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 9, 10, 36, 11, 828, DateTimeKind.Local).AddTicks(7386));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "GuarantorVerification",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 9, 11, 17, 28, 709, DateTimeKind.Local).AddTicks(2659),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 9, 10, 36, 11, 828, DateTimeKind.Local).AddTicks(783));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "GuarantorVerification",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 9, 11, 17, 28, 709, DateTimeKind.Local).AddTicks(2030),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 9, 10, 36, 11, 828, DateTimeKind.Local).AddTicks(181));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "EmploymentVerification",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 9, 11, 17, 28, 708, DateTimeKind.Local).AddTicks(5702),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 9, 10, 36, 11, 827, DateTimeKind.Local).AddTicks(4168));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "EmploymentVerification",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 9, 11, 17, 28, 708, DateTimeKind.Local).AddTicks(2783),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 9, 10, 36, 11, 815, DateTimeKind.Local).AddTicks(9741));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "AddressVerification",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 9, 11, 17, 28, 710, DateTimeKind.Local).AddTicks(3285),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 9, 10, 36, 11, 829, DateTimeKind.Local).AddTicks(779));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "AddressVerification",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 9, 11, 17, 28, 710, DateTimeKind.Local).AddTicks(2647),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 9, 10, 36, 11, 829, DateTimeKind.Local).AddTicks(234));

            migrationBuilder.CreateTable(
                name: "ApiCalls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApiUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResourceName = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CallStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CallCost = table.Column<double>(type: "float", nullable: false),
                    CallTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 7, 9, 11, 17, 28, 691, DateTimeKind.Local).AddTicks(1497))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiCalls", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApiCalls_ResourceName",
                table: "ApiCalls",
                column: "ResourceName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApiCalls");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "IdentityVerification",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 9, 10, 36, 11, 828, DateTimeKind.Local).AddTicks(7984),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 9, 11, 17, 28, 710, DateTimeKind.Local).AddTicks(415));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "IdentityVerification",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 9, 10, 36, 11, 828, DateTimeKind.Local).AddTicks(7386),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 9, 11, 17, 28, 709, DateTimeKind.Local).AddTicks(9829));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "GuarantorVerification",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 9, 10, 36, 11, 828, DateTimeKind.Local).AddTicks(783),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 9, 11, 17, 28, 709, DateTimeKind.Local).AddTicks(2659));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "GuarantorVerification",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 9, 10, 36, 11, 828, DateTimeKind.Local).AddTicks(181),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 9, 11, 17, 28, 709, DateTimeKind.Local).AddTicks(2030));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "EmploymentVerification",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 9, 10, 36, 11, 827, DateTimeKind.Local).AddTicks(4168),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 9, 11, 17, 28, 708, DateTimeKind.Local).AddTicks(5702));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "EmploymentVerification",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 9, 10, 36, 11, 815, DateTimeKind.Local).AddTicks(9741),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 9, 11, 17, 28, 708, DateTimeKind.Local).AddTicks(2783));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "AddressVerification",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 9, 10, 36, 11, 829, DateTimeKind.Local).AddTicks(779),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 9, 11, 17, 28, 710, DateTimeKind.Local).AddTicks(3285));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "AddressVerification",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 9, 10, 36, 11, 829, DateTimeKind.Local).AddTicks(234),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 9, 11, 17, 28, 710, DateTimeKind.Local).AddTicks(2647));
        }
    }
}
