using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dental_CLinic.BAl.Migrations
{
    public partial class AddClientsFiles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClientPhoto",
                table: "clients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClientPhoto",
                table: "clients");
        }
    }
}
