// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VerifyMeIntegration.Data;

namespace VerifyMeIntegration.Migrations
{
    [DbContext(typeof(VerifyMeDataContext))]
    [Migration("20220203081925_UpdateToModels")]
    partial class UpdateToModels
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("VerifyMeIntegration.Models.AddressVerification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AddressVerificationId")
                        .HasColumnType("int");

                    b.Property<string>("ApplicationId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CompletedAt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2022, 2, 3, 9, 19, 24, 410, DateTimeKind.Local).AddTicks(5357));

                    b.Property<string>("Dob")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Firstname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdNumber")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IdType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InitiatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Landmark")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lastname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lga")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostBackJson")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RequestJson")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResponseJson")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2022, 2, 3, 9, 19, 24, 410, DateTimeKind.Local).AddTicks(5793));

                    b.HasKey("Id");

                    b.HasIndex("ApplicationId");

                    b.HasIndex("IdNumber");

                    b.ToTable("AddressVerification");
                });

            modelBuilder.Entity("VerifyMeIntegration.Models.EmploymentVerification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ApplicantDob")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ApplicantFirstname")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ApplicantIdNumber")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ApplicantIdType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ApplicantLastname")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ApplicantPhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ApplicationId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CompletedAt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactPersonName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2022, 2, 3, 9, 19, 24, 400, DateTimeKind.Local).AddTicks(9745));

                    b.Property<bool>("CurrentlyEmployed")
                        .HasColumnType("bit");

                    b.Property<string>("EmployerEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployerPhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EmploymentVerificationId")
                        .HasColumnType("int");

                    b.Property<string>("EndDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InitiatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JobTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostBackJson")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RequestJson")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResponseJson")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StartDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StatusState")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2022, 2, 3, 9, 19, 24, 408, DateTimeKind.Local).AddTicks(5222));

                    b.HasKey("Id");

                    b.HasIndex("ApplicantFirstname");

                    b.HasIndex("ApplicantIdNumber");

                    b.HasIndex("ApplicantLastname");

                    b.HasIndex("ApplicationId");

                    b.HasIndex("ApplicantFirstname", "ApplicantLastname", "ApplicantDob");

                    b.ToTable("EmploymentVerification");
                });

            modelBuilder.Entity("VerifyMeIntegration.Models.GuarantorVerification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AcceptableIdType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ApplicantDob")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ApplicantFirstname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ApplicantIdNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ApplicantIdType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ApplicantLastname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ApplicantPhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ApplicationId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CompletedAt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2022, 2, 3, 9, 19, 24, 409, DateTimeKind.Local).AddTicks(6853));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Firstname")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("GuarantorsVerificationId")
                        .HasColumnType("int");

                    b.Property<string>("InitiatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Landmark")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lastname")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Lga")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostBackJson")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RequestJson")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResponseJson")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StatusState")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2022, 2, 3, 9, 19, 24, 409, DateTimeKind.Local).AddTicks(7433));

                    b.HasKey("Id");

                    b.HasIndex("ApplicationId");

                    b.HasIndex("Email");

                    b.HasIndex("Firstname");

                    b.HasIndex("Lastname");

                    b.HasIndex("Firstname", "Lastname");

                    b.ToTable("GuarantorVerification");
                });

            modelBuilder.Entity("VerifyMeIntegration.Models.IdentityVerification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ApplicationId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2022, 2, 3, 9, 19, 24, 410, DateTimeKind.Local).AddTicks(3035));

                    b.Property<string>("Dob")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ExpiryDate")
                        .HasColumnType("date");

                    b.Property<string>("Firstname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdReference")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IdType")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("InitiatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lastname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RequestJson")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResponseJson")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2022, 2, 3, 9, 19, 24, 410, DateTimeKind.Local).AddTicks(3525));

                    b.HasKey("Id");

                    b.HasIndex("ApplicationId");

                    b.HasIndex("IdReference");

                    b.HasIndex("IdType");

                    b.ToTable("IdentityVerification");
                });
#pragma warning restore 612, 618
        }
    }
}
