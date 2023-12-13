using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BufaloCargo.Data.Migrations
{
    /// <inheritdoc />
    public partial class initialfase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Globals");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CampusIdSede",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CompanyIdCompany",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EditDate",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "IdCompany",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "IdSede",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "InsertDate",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Names",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NumberContact",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProfilePicture",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SurNames",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserCreate",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserEdit",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetRoles",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "AspNetRoles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "EditDate",
                table: "AspNetRoles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "InsertDate",
                table: "AspNetRoles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UserCreate",
                table: "AspNetRoles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserEdit",
                table: "AspNetRoles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Campus",
                schema: "Globals",
                columns: table => new
                {
                    IdSede = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GeneralEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserCreate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserEdit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campus", x => x.IdSede);
                });

            migrationBuilder.CreateTable(
                name: "Countrys",
                schema: "Globals",
                columns: table => new
                {
                    IdCountry = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserCreate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserEdit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countrys", x => x.IdCountry);
                });

            migrationBuilder.CreateTable(
                name: "DocumentType",
                schema: "Globals",
                columns: table => new
                {
                    IdDocumentType = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Abbreviation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserCreate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserEdit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentType", x => x.IdDocumentType);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                schema: "Globals",
                columns: table => new
                {
                    IdDepartment = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CountrysIdCountry = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserCreate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserEdit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.IdDepartment);
                    table.ForeignKey(
                        name: "FK_Departments_Countrys_CountrysIdCountry",
                        column: x => x.CountrysIdCountry,
                        principalSchema: "Globals",
                        principalTable: "Countrys",
                        principalColumn: "IdCountry");
                });

            migrationBuilder.CreateTable(
                name: "Empresa",
                columns: table => new
                {
                    IdCompany = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Document = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VerificationNit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BusinessName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnumLegalNature = table.Column<int>(type: "int", nullable: false),
                    MailAdmin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RepresentativeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RepresentativeSecondName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RepresentativeSurName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RepresentativeSecondSurName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RepresentativeDocument = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdDocumentTypeCompany = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DocumentTypeCompanyIdDocumentType = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserCreate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserEdit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresa", x => x.IdCompany);
                    table.ForeignKey(
                        name: "FK_Empresa_DocumentType_DocumentTypeCompanyIdDocumentType",
                        column: x => x.DocumentTypeCompanyIdDocumentType,
                        principalSchema: "Globals",
                        principalTable: "DocumentType",
                        principalColumn: "IdDocumentType");
                });

            migrationBuilder.CreateTable(
                name: "Municipalities",
                schema: "Globals",
                columns: table => new
                {
                    IdMunicipality = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdDepartments = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DepartmentsIdDepartment = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserCreate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserEdit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Municipalities", x => x.IdMunicipality);
                    table.ForeignKey(
                        name: "FK_Municipalities_Departments_DepartmentsIdDepartment",
                        column: x => x.DepartmentsIdDepartment,
                        principalSchema: "Globals",
                        principalTable: "Departments",
                        principalColumn: "IdDepartment");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CampusIdSede",
                table: "AspNetUsers",
                column: "CampusIdSede");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CompanyIdCompany",
                table: "AspNetUsers",
                column: "CompanyIdCompany");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_CountrysIdCountry",
                schema: "Globals",
                table: "Departments",
                column: "CountrysIdCountry");

            migrationBuilder.CreateIndex(
                name: "IX_Empresa_DocumentTypeCompanyIdDocumentType",
                table: "Empresa",
                column: "DocumentTypeCompanyIdDocumentType");

            migrationBuilder.CreateIndex(
                name: "IX_Municipalities_DepartmentsIdDepartment",
                schema: "Globals",
                table: "Municipalities",
                column: "DepartmentsIdDepartment");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Campus_CampusIdSede",
                table: "AspNetUsers",
                column: "CampusIdSede",
                principalSchema: "Globals",
                principalTable: "Campus",
                principalColumn: "IdSede");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Empresa_CompanyIdCompany",
                table: "AspNetUsers",
                column: "CompanyIdCompany",
                principalTable: "Empresa",
                principalColumn: "IdCompany");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Campus_CampusIdSede",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Empresa_CompanyIdCompany",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Campus",
                schema: "Globals");

            migrationBuilder.DropTable(
                name: "Empresa");

            migrationBuilder.DropTable(
                name: "Municipalities",
                schema: "Globals");

            migrationBuilder.DropTable(
                name: "DocumentType",
                schema: "Globals");

            migrationBuilder.DropTable(
                name: "Departments",
                schema: "Globals");

            migrationBuilder.DropTable(
                name: "Countrys",
                schema: "Globals");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CampusIdSede",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CompanyIdCompany",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CampusIdSede",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CompanyIdCompany",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "EditDate",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IdCompany",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IdSede",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "InsertDate",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Names",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "NumberContact",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ProfilePicture",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SurNames",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserCreate",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserEdit",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "EditDate",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "InsertDate",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "UserCreate",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "UserEdit",
                table: "AspNetRoles");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetRoles",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);
        }
    }
}
