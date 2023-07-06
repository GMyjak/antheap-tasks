using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NIP_backend.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Entities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nip = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    StatusVat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Regon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pesel = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    Krs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResidenceAddress = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    WorkingAddress = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    RegistrationLegalDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RegistrationDenialDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RegistrationDenialBasis = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    RestorationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RestorationBasis = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    RemovalDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RemovalBasis = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AccountNumbers = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HasVirtualAccounts = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EntityPeople",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pesel = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    Nip = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    EntityAsRepresentativeId = table.Column<int>(type: "int", nullable: true),
                    EntityAsClerkId = table.Column<int>(type: "int", nullable: true),
                    EntityAsPartnerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityPeople", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EntityPeople_Entities_EntityAsClerkId",
                        column: x => x.EntityAsClerkId,
                        principalTable: "Entities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EntityPeople_Entities_EntityAsPartnerId",
                        column: x => x.EntityAsPartnerId,
                        principalTable: "Entities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EntityPeople_Entities_EntityAsRepresentativeId",
                        column: x => x.EntityAsRepresentativeId,
                        principalTable: "Entities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_EntityPeople_EntityAsClerkId",
                table: "EntityPeople",
                column: "EntityAsClerkId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityPeople_EntityAsPartnerId",
                table: "EntityPeople",
                column: "EntityAsPartnerId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityPeople_EntityAsRepresentativeId",
                table: "EntityPeople",
                column: "EntityAsRepresentativeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EntityPeople");

            migrationBuilder.DropTable(
                name: "Entities");
        }
    }
}
