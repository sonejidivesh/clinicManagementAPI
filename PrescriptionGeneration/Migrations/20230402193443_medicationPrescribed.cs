using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrescriptionGeneration.Migrations
{
    /// <inheritdoc />
    public partial class medicationPrescribed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicationPrescribed_Prescriptions_PrescriptionId",
                table: "MedicationPrescribed");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MedicationPrescribed",
                table: "MedicationPrescribed");

            migrationBuilder.RenameTable(
                name: "MedicationPrescribed",
                newName: "MedicationPrescribeds");

            migrationBuilder.RenameIndex(
                name: "IX_MedicationPrescribed_PrescriptionId",
                table: "MedicationPrescribeds",
                newName: "IX_MedicationPrescribeds_PrescriptionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MedicationPrescribeds",
                table: "MedicationPrescribeds",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicationPrescribeds_Prescriptions_PrescriptionId",
                table: "MedicationPrescribeds",
                column: "PrescriptionId",
                principalTable: "Prescriptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicationPrescribeds_Prescriptions_PrescriptionId",
                table: "MedicationPrescribeds");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MedicationPrescribeds",
                table: "MedicationPrescribeds");

            migrationBuilder.RenameTable(
                name: "MedicationPrescribeds",
                newName: "MedicationPrescribed");

            migrationBuilder.RenameIndex(
                name: "IX_MedicationPrescribeds_PrescriptionId",
                table: "MedicationPrescribed",
                newName: "IX_MedicationPrescribed_PrescriptionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MedicationPrescribed",
                table: "MedicationPrescribed",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicationPrescribed_Prescriptions_PrescriptionId",
                table: "MedicationPrescribed",
                column: "PrescriptionId",
                principalTable: "Prescriptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
