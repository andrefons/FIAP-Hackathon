using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthMed.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AlterTableScheduleAddColumnAvailable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Available",
                table: "Schedules",
                type: "boolean",
                nullable: false,
                defaultValue: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Available",
                table: "Schedules");
        }
    }
}
