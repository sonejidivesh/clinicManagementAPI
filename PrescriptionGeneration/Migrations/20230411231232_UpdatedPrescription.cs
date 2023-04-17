using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrescriptionGeneration.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedPrescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsCreated",
                table: "Prescriptions",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCreated",
                table: "Prescriptions");
        }
    }
}
