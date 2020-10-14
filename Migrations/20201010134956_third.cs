using Microsoft.EntityFrameworkCore.Migrations;

namespace UserMicroservice.Migrations
{
    public partial class third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Marks",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Marks",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Marks");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Marks",
                newName: "ID");
        }
    }
}
