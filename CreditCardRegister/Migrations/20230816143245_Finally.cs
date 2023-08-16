using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CreditCardRegister.API.Migrations
{
    public partial class Finally : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BatchCreditCard",
                columns: table => new
                {
                    BatchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdArchive = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BatchName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BatchDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BatchAmount = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BatchCreditCard", x => x.BatchId);
                });

            migrationBuilder.CreateTable(
                name: "CreditCard",
                columns: table => new
                {
                    CreditCardId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdArchiveLine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreditCardNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    RegisterCreditCardId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditCard", x => x.CreditCardId);
                    table.ForeignKey(
                        name: "FK_CreditCard_BatchCreditCard_RegisterCreditCardId",
                        column: x => x.RegisterCreditCardId,
                        principalTable: "BatchCreditCard",
                        principalColumn: "BatchId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CreditCard_RegisterCreditCardId",
                table: "CreditCard",
                column: "RegisterCreditCardId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CreditCard");

            migrationBuilder.DropTable(
                name: "BatchCreditCard");
        }
    }
}
