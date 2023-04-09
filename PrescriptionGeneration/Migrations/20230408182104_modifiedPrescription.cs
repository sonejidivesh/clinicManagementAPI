using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrescriptionGeneration.Migrations
{
    /// <inheritdoc />
    public partial class modifiedPrescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_DoctorLogins_DoctorId",
                table: "DoctorLogins");

            migrationBuilder.AddColumn<int>(
                name: "Frequency",
                table: "MedicationPrescribeds",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DoctorLogins_DoctorId",
                table: "DoctorLogins",
                column: "DoctorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_DoctorLogins_DoctorId",
                table: "DoctorLogins");

            migrationBuilder.DropColumn(
                name: "Frequency",
                table: "MedicationPrescribeds");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorLogins_DoctorId",
                table: "DoctorLogins",
                column: "DoctorId",
                unique: true,
                filter: "[DoctorId] IS NOT NULL");
        }
    }
}
