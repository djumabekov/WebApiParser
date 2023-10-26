using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiParser.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.CreateTable(
                name: "RefContractStatus",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SystemId = table.Column<long>(type: "bigint", nullable: false),
                    Name_Ru = table.Column<string>(type: "text", nullable: true),
                    Name_Kk = table.Column<string>(type: "text", nullable: true),
                    Code = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefContractStatus", x => x.Id);
                    table.UniqueConstraint("AK_RefContractStatus_SystemId", x => x.SystemId);
                });

            migrationBuilder.CreateTable(
                name: "RefContractType",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SystemId = table.Column<long>(type: "bigint", nullable: false),
                    Name_Ru = table.Column<string>(type: "text", nullable: true),
                    Name_Kk = table.Column<string>(type: "text", nullable: true),
                    Code = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefContractType", x => x.Id);
                    table.UniqueConstraint("AK_RefContractType_SystemId", x => x.SystemId);
                });

            migrationBuilder.CreateTable(
                name: "Contracts",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ContractId = table.Column<long>(type: "bigint", nullable: false),
                    ContractNumber = table.Column<long>(type: "bigint", nullable: false),
                    ContractNumberSys = table.Column<string>(type: "text", nullable: true),
                    TrdBuyId = table.Column<long>(type: "bigint", nullable: true),
                    TrdBuyNumberAnno = table.Column<string>(type: "text", nullable: true),
                    RefContractTypeId = table.Column<long>(type: "bigint", nullable: false),
                    RefContractStatusId = table.Column<long>(type: "bigint", nullable: false),
                    CrDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ContractSum = table.Column<double>(type: "double precision", nullable: true),
                    ContractSumWnds = table.Column<double>(type: "double precision", nullable: true),
                    SupplierId = table.Column<long>(type: "bigint", nullable: true),
                    SupplierBin = table.Column<string>(type: "text", nullable: true),
                    CustomerId = table.Column<long>(type: "bigint", nullable: true),
                    CustomerBin = table.Column<string>(type: "text", nullable: true),
                    IndexDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    SystemId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contracts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contracts_RefContractStatus_RefContractStatusId",
                        column: x => x.RefContractStatusId,
                        principalSchema: "public",
                        principalTable: "RefContractStatus",
                        principalColumn: "SystemId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contracts_RefContractType_RefContractTypeId",
                        column: x => x.RefContractTypeId,
                        principalSchema: "public",
                        principalTable: "RefContractType",
                        principalColumn: "SystemId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_RefContractStatusId",
                schema: "public",
                table: "Contracts",
                column: "RefContractStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_RefContractTypeId",
                schema: "public",
                table: "Contracts",
                column: "RefContractTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contracts",
                schema: "public");

            migrationBuilder.DropTable(
                name: "RefContractStatus",
                schema: "public");

            migrationBuilder.DropTable(
                name: "RefContractType",
                schema: "public");
        }
    }
}
