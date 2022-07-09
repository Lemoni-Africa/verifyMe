using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VerifyMeIntegration.Migrations
{
    public partial class ApiCalls : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "IdentityVerification",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 9, 10, 36, 11, 828, DateTimeKind.Local).AddTicks(7984),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 2, 3, 9, 19, 24, 410, DateTimeKind.Local).AddTicks(3525));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "IdentityVerification",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 9, 10, 36, 11, 828, DateTimeKind.Local).AddTicks(7386),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 2, 3, 9, 19, 24, 410, DateTimeKind.Local).AddTicks(3035));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "GuarantorVerification",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 9, 10, 36, 11, 828, DateTimeKind.Local).AddTicks(783),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 2, 3, 9, 19, 24, 409, DateTimeKind.Local).AddTicks(7433));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "GuarantorVerification",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 9, 10, 36, 11, 828, DateTimeKind.Local).AddTicks(181),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 2, 3, 9, 19, 24, 409, DateTimeKind.Local).AddTicks(6853));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "EmploymentVerification",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 9, 10, 36, 11, 827, DateTimeKind.Local).AddTicks(4168),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 2, 3, 9, 19, 24, 408, DateTimeKind.Local).AddTicks(5222));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "EmploymentVerification",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 9, 10, 36, 11, 815, DateTimeKind.Local).AddTicks(9741),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 2, 3, 9, 19, 24, 400, DateTimeKind.Local).AddTicks(9745));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "AddressVerification",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 9, 10, 36, 11, 829, DateTimeKind.Local).AddTicks(779),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 2, 3, 9, 19, 24, 410, DateTimeKind.Local).AddTicks(5793));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "AddressVerification",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 9, 10, 36, 11, 829, DateTimeKind.Local).AddTicks(234),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 2, 3, 9, 19, 24, 410, DateTimeKind.Local).AddTicks(5357));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "IdentityVerification",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 2, 3, 9, 19, 24, 410, DateTimeKind.Local).AddTicks(3525),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 9, 10, 36, 11, 828, DateTimeKind.Local).AddTicks(7984));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "IdentityVerification",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 2, 3, 9, 19, 24, 410, DateTimeKind.Local).AddTicks(3035),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 9, 10, 36, 11, 828, DateTimeKind.Local).AddTicks(7386));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "GuarantorVerification",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 2, 3, 9, 19, 24, 409, DateTimeKind.Local).AddTicks(7433),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 9, 10, 36, 11, 828, DateTimeKind.Local).AddTicks(783));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "GuarantorVerification",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 2, 3, 9, 19, 24, 409, DateTimeKind.Local).AddTicks(6853),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 9, 10, 36, 11, 828, DateTimeKind.Local).AddTicks(181));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "EmploymentVerification",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 2, 3, 9, 19, 24, 408, DateTimeKind.Local).AddTicks(5222),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 9, 10, 36, 11, 827, DateTimeKind.Local).AddTicks(4168));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "EmploymentVerification",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 2, 3, 9, 19, 24, 400, DateTimeKind.Local).AddTicks(9745),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 9, 10, 36, 11, 815, DateTimeKind.Local).AddTicks(9741));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "AddressVerification",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 2, 3, 9, 19, 24, 410, DateTimeKind.Local).AddTicks(5793),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 9, 10, 36, 11, 829, DateTimeKind.Local).AddTicks(779));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "AddressVerification",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 2, 3, 9, 19, 24, 410, DateTimeKind.Local).AddTicks(5357),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 9, 10, 36, 11, 829, DateTimeKind.Local).AddTicks(234));
        }
    }
}
