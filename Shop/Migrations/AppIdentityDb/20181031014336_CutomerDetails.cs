using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop.Migrations.AppIdentityDb
{
    public partial class CutomerDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                maxLength: 56,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                maxLength: 56,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SurName",
                table: "AspNetUsers",
                maxLength: 56,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Telefone",
                table: "AspNetUsers",
                maxLength: 56,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SurName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Telefone",
                table: "AspNetUsers");
        }
    }
}
