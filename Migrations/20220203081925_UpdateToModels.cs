using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VerifyMeIntegration.Migrations
{
    public partial class UpdateToModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "IdentityVerification",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 2, 3, 9, 19, 24, 410, DateTimeKind.Local).AddTicks(3525),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 2, 2, 11, 13, 13, 692, DateTimeKind.Local).AddTicks(9933));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "IdentityVerification",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 2, 3, 9, 19, 24, 410, DateTimeKind.Local).AddTicks(3035),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 2, 2, 11, 13, 13, 687, DateTimeKind.Local).AddTicks(7770));

            migrationBuilder.AddColumn<string>(
                name: "ApplicationId",
                table: "IdentityVerification",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InitiatedBy",
                table: "IdentityVerification",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "AddressVerification",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 2, 3, 9, 19, 24, 410, DateTimeKind.Local).AddTicks(5793),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 2, 2, 11, 13, 13, 693, DateTimeKind.Local).AddTicks(1862));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "AddressVerification",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 2, 3, 9, 19, 24, 410, DateTimeKind.Local).AddTicks(5357),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 2, 2, 11, 13, 13, 693, DateTimeKind.Local).AddTicks(1584));

            migrationBuilder.AddColumn<string>(
                name: "InitiatedBy",
                table: "AddressVerification",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EmploymentVerification",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmploymentVerificationId = table.Column<int>(type: "int", nullable: true),
                    ApplicantIdType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicantIdNumber = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ApplicantFirstname = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ApplicantLastname = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ApplicantDob = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ApplicantPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployerEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployerPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EndDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentlyEmployed = table.Column<bool>(type: "bit", nullable: false),
                    StatusState = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompletedAt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostBackJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactPersonName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResponseJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicationId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InitiatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 2, 3, 9, 19, 24, 400, DateTimeKind.Local).AddTicks(9745)),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 2, 3, 9, 19, 24, 408, DateTimeKind.Local).AddTicks(5222))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmploymentVerification", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GuarantorVerification",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Firstname = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Lastname = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lga = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Landmark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AcceptableIdType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicantIdType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicantIdNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicantFirstname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicantLastname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicantDob = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicantPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusState = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GuarantorsVerificationId = table.Column<int>(type: "int", nullable: true),
                    CompletedAt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostBackJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResponseJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicationId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InitiatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 2, 3, 9, 19, 24, 409, DateTimeKind.Local).AddTicks(6853)),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 2, 3, 9, 19, 24, 409, DateTimeKind.Local).AddTicks(7433))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuarantorVerification", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IdentityVerification_ApplicationId",
                table: "IdentityVerification",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_EmploymentVerification_ApplicantFirstname",
                table: "EmploymentVerification",
                column: "ApplicantFirstname");

            migrationBuilder.CreateIndex(
                name: "IX_EmploymentVerification_ApplicantFirstname_ApplicantLastname_ApplicantDob",
                table: "EmploymentVerification",
                columns: new[] { "ApplicantFirstname", "ApplicantLastname", "ApplicantDob" });

            migrationBuilder.CreateIndex(
                name: "IX_EmploymentVerification_ApplicantIdNumber",
                table: "EmploymentVerification",
                column: "ApplicantIdNumber");

            migrationBuilder.CreateIndex(
                name: "IX_EmploymentVerification_ApplicantLastname",
                table: "EmploymentVerification",
                column: "ApplicantLastname");

            migrationBuilder.CreateIndex(
                name: "IX_EmploymentVerification_ApplicationId",
                table: "EmploymentVerification",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_GuarantorVerification_ApplicationId",
                table: "GuarantorVerification",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_GuarantorVerification_Email",
                table: "GuarantorVerification",
                column: "Email");

            migrationBuilder.CreateIndex(
                name: "IX_GuarantorVerification_Firstname",
                table: "GuarantorVerification",
                column: "Firstname");

            migrationBuilder.CreateIndex(
                name: "IX_GuarantorVerification_Firstname_Lastname",
                table: "GuarantorVerification",
                columns: new[] { "Firstname", "Lastname" });

            migrationBuilder.CreateIndex(
                name: "IX_GuarantorVerification_Lastname",
                table: "GuarantorVerification",
                column: "Lastname");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmploymentVerification");

            migrationBuilder.DropTable(
                name: "GuarantorVerification");

            migrationBuilder.DropIndex(
                name: "IX_IdentityVerification_ApplicationId",
                table: "IdentityVerification");

            migrationBuilder.DropColumn(
                name: "ApplicationId",
                table: "IdentityVerification");

            migrationBuilder.DropColumn(
                name: "InitiatedBy",
                table: "IdentityVerification");

            migrationBuilder.DropColumn(
                name: "InitiatedBy",
                table: "AddressVerification");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "IdentityVerification",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 2, 2, 11, 13, 13, 692, DateTimeKind.Local).AddTicks(9933),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 2, 3, 9, 19, 24, 410, DateTimeKind.Local).AddTicks(3525));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "IdentityVerification",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 2, 2, 11, 13, 13, 687, DateTimeKind.Local).AddTicks(7770),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 2, 3, 9, 19, 24, 410, DateTimeKind.Local).AddTicks(3035));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "AddressVerification",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 2, 2, 11, 13, 13, 693, DateTimeKind.Local).AddTicks(1862),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 2, 3, 9, 19, 24, 410, DateTimeKind.Local).AddTicks(5793));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "AddressVerification",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 2, 2, 11, 13, 13, 693, DateTimeKind.Local).AddTicks(1584),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 2, 3, 9, 19, 24, 410, DateTimeKind.Local).AddTicks(5357));
        }
    }
}
