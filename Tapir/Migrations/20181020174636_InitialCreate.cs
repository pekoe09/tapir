using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tapir.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BusinessSectors",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(maxLength: 10, nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessSectors", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FullName = table.Column<string>(maxLength: 100, nullable: false),
                    ShortName = table.Column<string>(maxLength: 20, nullable: false),
                    BusinessId = table.Column<string>(maxLength: 20, nullable: false),
                    SectorID = table.Column<int>(nullable: true),
                    InsuranceNumber = table.Column<string>(maxLength: 30, nullable: true),
                    BankAccount = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Companies_BusinessSectors_SectorID",
                        column: x => x.SectorID,
                        principalTable: "BusinessSectors",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Street1 = table.Column<string>(maxLength: 100, nullable: true),
                    Street2 = table.Column<string>(maxLength: 100, nullable: true),
                    Zip = table.Column<string>(maxLength: 20, nullable: true),
                    City = table.Column<string>(maxLength: 50, nullable: true),
                    Country = table.Column<string>(maxLength: 50, nullable: true),
                    CompanyID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Addresses_Companies_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "Companies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    FirstNames = table.Column<string>(maxLength: 50, nullable: false),
                    SSN = table.Column<string>(nullable: true),
                    AddressID = table.Column<int>(nullable: false),
                    Email = table.Column<string>(maxLength: 100, nullable: true),
                    Phone = table.Column<string>(maxLength: 20, nullable: true),
                    Language = table.Column<string>(maxLength: 20, nullable: true),
                    Citizenship = table.Column<string>(maxLength: 50, nullable: false),
                    Profession = table.Column<string>(maxLength: 50, nullable: false),
                    IBAN = table.Column<string>(maxLength: 20, nullable: false),
                    IsOwner = table.Column<bool>(nullable: false),
                    OwnershipSelf = table.Column<double>(nullable: true),
                    VotesSelf = table.Column<double>(nullable: true),
                    OwnershipWithFamily = table.Column<double>(nullable: true),
                    VotesWithFamily = table.Column<double>(nullable: true),
                    PositionInCompany = table.Column<string>(maxLength: 100, nullable: true),
                    PlaceOfRegularEmployment = table.Column<string>(maxLength: 100, nullable: true),
                    CityOfRegularEmployment = table.Column<string>(maxLength: 100, nullable: true),
                    RegularEmploymentAddressID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Persons_Addresses_AddressID",
                        column: x => x.AddressID,
                        principalTable: "Addresses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Persons_Addresses_RegularEmploymentAddressID",
                        column: x => x.RegularEmploymentAddressID,
                        principalTable: "Addresses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Employments",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CompanyID = table.Column<int>(nullable: false),
                    PersonID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Employments_Companies_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "Companies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employments_Persons_PersonID",
                        column: x => x.PersonID,
                        principalTable: "Persons",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CompanyID",
                table: "Addresses",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_SectorID",
                table: "Companies",
                column: "SectorID");

            migrationBuilder.CreateIndex(
                name: "IX_Employments_CompanyID",
                table: "Employments",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_Employments_PersonID",
                table: "Employments",
                column: "PersonID");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_AddressID",
                table: "Persons",
                column: "AddressID");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_RegularEmploymentAddressID",
                table: "Persons",
                column: "RegularEmploymentAddressID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employments");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "BusinessSectors");
        }
    }
}
