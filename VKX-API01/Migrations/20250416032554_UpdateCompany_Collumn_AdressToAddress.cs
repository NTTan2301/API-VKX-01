using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VKX_API01.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCompany_Collumn_AdressToAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Adress",
                table: "Company",
                newName: "Address");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Company",
                newName: "Adress");
        }
    }
}
