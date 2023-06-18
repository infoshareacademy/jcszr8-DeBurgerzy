using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParcelDistributionCenter.Web.Migrations
{
    /// <inheritdoc />
    public partial class ReportPackageEntityAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReportPackages",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AddingDurationInSeconds = table.Column<double>(type: "float", nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false),
                    TimeCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportPackages", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReportPackages");
        }
    }
}
