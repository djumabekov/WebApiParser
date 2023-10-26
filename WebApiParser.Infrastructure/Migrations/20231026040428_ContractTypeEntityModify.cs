using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiParser.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ContractTypeEntityModify : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                schema: "public",
                table: "RefContractType");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Code",
                schema: "public",
                table: "RefContractType",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
