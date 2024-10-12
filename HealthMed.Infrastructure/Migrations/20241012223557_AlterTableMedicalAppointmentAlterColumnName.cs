using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthMed.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AlterTableMedicalAppointmentAlterColumnName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalAppointments_Persons_PacientId",
                table: "MedicalAppointments");

            migrationBuilder.RenameColumn(
                name: "PacientId",
                table: "MedicalAppointments",
                newName: "PatientId");

            migrationBuilder.RenameIndex(
                name: "IX_MedicalAppointments_PacientId",
                table: "MedicalAppointments",
                newName: "IX_MedicalAppointments_PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalAppointments_Persons_PatientId",
                table: "MedicalAppointments",
                column: "PatientId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalAppointments_Persons_PatientId",
                table: "MedicalAppointments");

            migrationBuilder.RenameColumn(
                name: "PatientId",
                table: "MedicalAppointments",
                newName: "PacientId");

            migrationBuilder.RenameIndex(
                name: "IX_MedicalAppointments_PatientId",
                table: "MedicalAppointments",
                newName: "IX_MedicalAppointments_PacientId");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalAppointments_Persons_PacientId",
                table: "MedicalAppointments",
                column: "PacientId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
