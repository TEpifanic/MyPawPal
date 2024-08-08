using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyPawPal.Migrations
{
    /// <inheritdoc />
    public partial class UserAndDogUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "User_Info",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Dog_Info",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "User_Info",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Dog_Info",
                type: "character varying(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
