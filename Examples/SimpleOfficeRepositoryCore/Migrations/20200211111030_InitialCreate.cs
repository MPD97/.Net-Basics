using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpleOfficeRepositoryCore.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Offices",
                columns: table => new
                {
                    OfficeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offices", x => x.OfficeId);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    PersonId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    Surename = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false),
                    Sex = table.Column<int>(nullable: false),
                    HireDate = table.Column<DateTime>(nullable: false),
                    OfficeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.PersonId);
                    table.ForeignKey(
                        name: "FK_People_Offices_OfficeId",
                        column: x => x.OfficeId,
                        principalTable: "Offices",
                        principalColumn: "OfficeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    RoomId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomNumber = table.Column<int>(nullable: false),
                    NumberOfWindows = table.Column<int>(nullable: false),
                    OfficeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.RoomId);
                    table.ForeignKey(
                        name: "FK_Rooms_Offices_OfficeId",
                        column: x => x.OfficeId,
                        principalTable: "Offices",
                        principalColumn: "OfficeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Desks",
                columns: table => new
                {
                    DeskId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Length = table.Column<double>(nullable: false),
                    Width = table.Column<double>(nullable: false),
                    Height = table.Column<double>(nullable: false),
                    OwnerPersonId = table.Column<int>(nullable: true),
                    RoomId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Desks", x => x.DeskId);
                    table.ForeignKey(
                        name: "FK_Desks_People_OwnerPersonId",
                        column: x => x.OwnerPersonId,
                        principalTable: "People",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Desks_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "RoomId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Offices",
                columns: new[] { "OfficeId", "CompanyName", "Location" },
                values: new object[,]
                {
                    { 1, "Flying Cars Company", "Kornela Ujejskiego 75, 85-168 Bydgoszcz" },
                    { 2, "Hire Apprentice Only Company", "plac Politechniki 1, 00-661 Warszawa" }
                });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "PersonId", "Age", "FirstName", "HireDate", "OfficeId", "Sex", "Surename" },
                values: new object[,]
                {
                    { 1, 22, "Matthew", new DateTime(2017, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, "Coolman" },
                    { 2, 32, "Chris", new DateTime(2017, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, "Baldman" },
                    { 3, 38, "Kate", new DateTime(2008, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "Talklady" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "RoomId", "NumberOfWindows", "OfficeId", "RoomNumber" },
                values: new object[,]
                {
                    { 1, 3, null, 233 },
                    { 2, 2, null, 41 },
                    { 3, 6, null, 74 },
                    { 4, 0, null, 331 },
                    { 5, 5, null, 15 }
                });

            migrationBuilder.InsertData(
                table: "Desks",
                columns: new[] { "DeskId", "Height", "Length", "OwnerPersonId", "RoomId", "Width" },
                values: new object[,]
                {
                    { 2, 1.1499999999999999, 2.1099999999999999, null, 1, 1.3500000000000001 },
                    { 1, 1.05, 2.3300000000000001, null, 2, 1.1499999999999999 },
                    { 3, 0.94999999999999996, 1.8300000000000001, null, 2, 1.0700000000000001 },
                    { 4, 1.3500000000000001, 1.7, null, 4, 1.7 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Desks_OwnerPersonId",
                table: "Desks",
                column: "OwnerPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Desks_RoomId",
                table: "Desks",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_People_OfficeId",
                table: "People",
                column: "OfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_OfficeId",
                table: "Rooms",
                column: "OfficeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Desks");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Offices");
        }
    }
}
