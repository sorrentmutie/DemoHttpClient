using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoConcertsDB.Migrations
{
    /// <inheritdoc />
    public partial class Prova2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Prova",
                table: "Concerts",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Prova",
                table: "Concerts");
        }
    }
}
