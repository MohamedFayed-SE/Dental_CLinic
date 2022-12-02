using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dental_CLinic.BAl.Migrations
{
    public partial class AssignCLientToCOuntry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RegionId",
                table: "clients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_clients_RegionId",
                table: "clients",
                column: "RegionId");

            migrationBuilder.AddForeignKey(
                name: "FK_clients_regions_RegionId",
                table: "clients",
                column: "RegionId",
                principalTable: "regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_clients_regions_RegionId",
                table: "clients");

            migrationBuilder.DropIndex(
                name: "IX_clients_RegionId",
                table: "clients");

            migrationBuilder.DropColumn(
                name: "RegionId",
                table: "clients");
        }
    }
}
