using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrescriptionGeneration.Migrations
{
    /// <inheritdoc />
    public partial class AVaccinationPres : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "medicalTestPrescribeds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TestId = table.Column<int>(type: "int", nullable: false),
                    PrescriptionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medicalTestPrescribeds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_medicalTestPrescribeds_Prescriptions_PrescriptionId",
                        column: x => x.PrescriptionId,
                        principalTable: "Prescriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "vacinationPrescribeds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VacinationId = table.Column<int>(type: "int", nullable: false),
                    Dose = table.Column<double>(type: "float", nullable: false),
                    PrescriptionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vacinationPrescribeds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_vacinationPrescribeds_Prescriptions_PrescriptionId",
                        column: x => x.PrescriptionId,
                        principalTable: "Prescriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_medicalTestPrescribeds_PrescriptionId",
                table: "medicalTestPrescribeds",
                column: "PrescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_vacinationPrescribeds_PrescriptionId",
                table: "vacinationPrescribeds",
                column: "PrescriptionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "medicalTestPrescribeds");

            migrationBuilder.DropTable(
                name: "vacinationPrescribeds");
        }
    }
}
