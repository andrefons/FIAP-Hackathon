using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthMed.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AlterTablePersonAddColumnPersonType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PersonType",
                table: "Persons",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PersonType",
                table: "Persons");
        }
    }
}
