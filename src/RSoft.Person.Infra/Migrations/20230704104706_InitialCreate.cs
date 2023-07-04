using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RSoft.Person.Infra.Migrations
{
    public partial class InitialCreate : InitialSeed
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AddressType",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    Description = table.Column<int>(type: "int", unicode: false, maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressType", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    FirstName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsActive = table.Column<ulong>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    FirstName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Note = table.Column<string>(type: "varchar(2000)", unicode: false, maxLength: 2000, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsActive = table.Column<ulong>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ChangedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ChangedBy = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Person_ChangedBy",
                        column: x => x.ChangedBy,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_Person_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PersonAddress",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    PersonId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    AddressTypeId = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    Title = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StreetName = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AddressNumber = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SecondaryAddress = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    District = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    City = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    State = table.Column<string>(type: "varchar(2)", unicode: false, maxLength: 2, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ZipCode = table.Column<string>(type: "varchar(8)", unicode: false, maxLength: 8, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonAddress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AddressType_PersonAddress_AddressTypeId",
                        column: x => x.AddressTypeId,
                        principalTable: "AddressType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Person_PersonAddress_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PersonPhone",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    PersonId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    PhoneType = table.Column<int>(type: "int", nullable: false),
                    CountryCode = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CityCode = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumber = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDefault = table.Column<ulong>(type: "bit", nullable: false, defaultValue: 0ul)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonPhone", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Person_PersonPhone_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PersonType",
                columns: table => new
                {
                    PersonId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Type = table.Column<sbyte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonType", x => x.PersonId);
                    table.ForeignKey(
                        name: "FK_Person_PersonType_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "AK_AddressType_Description",
                table: "AddressType",
                column: "Description",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Person_ChangedBy",
                table: "Person",
                column: "ChangedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Person_ChangedOn",
                table: "Person",
                column: "ChangedOn");

            migrationBuilder.CreateIndex(
                name: "IX_Person_CreatedBy",
                table: "Person",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Person_CreatedOn",
                table: "Person",
                column: "CreatedOn");

            migrationBuilder.CreateIndex(
                name: "IX_Person_FullName",
                table: "Person",
                columns: new[] { "FirstName", "LastName" });

            migrationBuilder.CreateIndex(
                name: "AK_PersonAddress_Title",
                table: "PersonAddress",
                column: "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PersonAddress_AddressTypeId",
                table: "PersonAddress",
                column: "AddressTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonAddress_PersonId",
                table: "PersonAddress",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "AK_PersonPhone_Person_FullPhoneNumber",
                table: "PersonPhone",
                columns: new[] { "PersonId", "CountryCode", "CityCode", "PhoneNumber" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PersonType_PersonId",
                table: "PersonType",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_User_FullName",
                table: "User",
                columns: new[] { "FirstName", "LastName" });

            Seed(migrationBuilder);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonAddress");

            migrationBuilder.DropTable(
                name: "PersonPhone");

            migrationBuilder.DropTable(
                name: "PersonType");

            migrationBuilder.DropTable(
                name: "AddressType");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
