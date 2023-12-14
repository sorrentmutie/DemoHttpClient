using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoConcertsDB.Migrations
{
    /// <inheritdoc />
    public partial class RemoveProva : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Prova",
                table: "Concerts");

            migrationBuilder.DropColumn(
                name: "Prova",
                table: "Artists");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Prova",
                table: "Concerts",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Prova",
                table: "Artists",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
