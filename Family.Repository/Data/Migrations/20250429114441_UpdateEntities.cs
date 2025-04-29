using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Family.Repository.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhotoUrl",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EstablishmentYear",
                table: "Clans",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LeaderName",
                table: "Clans",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhotoUrl",
                table: "Clans",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Region",
                table: "Clans",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SponsorName",
                table: "Clans",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EstablishmentYear",
                table: "Branches",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LeaderName",
                table: "Branches",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhotoUrl",
                table: "Branches",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Region",
                table: "Branches",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoUrl",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "EstablishmentYear",
                table: "Clans");

            migrationBuilder.DropColumn(
                name: "LeaderName",
                table: "Clans");

            migrationBuilder.DropColumn(
                name: "PhotoUrl",
                table: "Clans");

            migrationBuilder.DropColumn(
                name: "Region",
                table: "Clans");

            migrationBuilder.DropColumn(
                name: "SponsorName",
                table: "Clans");

            migrationBuilder.DropColumn(
                name: "EstablishmentYear",
                table: "Branches");

            migrationBuilder.DropColumn(
                name: "LeaderName",
                table: "Branches");

            migrationBuilder.DropColumn(
                name: "PhotoUrl",
                table: "Branches");

            migrationBuilder.DropColumn(
                name: "Region",
                table: "Branches");
        }
    }
}
