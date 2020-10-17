using Microsoft.EntityFrameworkCore.Migrations;

namespace P2_API.Migrations
{
    public partial class addedprefs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Aquarium",
                table: "Preferences");

            migrationBuilder.DropColumn(
                name: "Boxing",
                table: "Preferences");

            migrationBuilder.DropColumn(
                name: "Movies",
                table: "Preferences");

            migrationBuilder.AddColumn<bool>(
                name: "Animals",
                table: "Preferences",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Art",
                table: "Preferences",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Beauty",
                table: "Preferences",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Entertainment",
                table: "Preferences",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Fitness",
                table: "Preferences",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HomeDecour",
                table: "Preferences",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Learning",
                table: "Preferences",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Nightlife",
                table: "Preferences",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Religion",
                table: "Preferences",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Shopping",
                table: "Preferences",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Animals",
                table: "Preferences");

            migrationBuilder.DropColumn(
                name: "Art",
                table: "Preferences");

            migrationBuilder.DropColumn(
                name: "Beauty",
                table: "Preferences");

            migrationBuilder.DropColumn(
                name: "Entertainment",
                table: "Preferences");

            migrationBuilder.DropColumn(
                name: "Fitness",
                table: "Preferences");

            migrationBuilder.DropColumn(
                name: "HomeDecour",
                table: "Preferences");

            migrationBuilder.DropColumn(
                name: "Learning",
                table: "Preferences");

            migrationBuilder.DropColumn(
                name: "Nightlife",
                table: "Preferences");

            migrationBuilder.DropColumn(
                name: "Religion",
                table: "Preferences");

            migrationBuilder.DropColumn(
                name: "Shopping",
                table: "Preferences");

            migrationBuilder.AddColumn<bool>(
                name: "Aquarium",
                table: "Preferences",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Boxing",
                table: "Preferences",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Movies",
                table: "Preferences",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
