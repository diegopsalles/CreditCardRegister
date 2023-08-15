using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CreditCardRegister.API.Migrations.CreditCard
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RegisterBatchCreditCard",
                columns: table => new
                {
                    BatchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BatchName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BatchDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    BatchAmount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegisterBatchCreditCard", x => x.BatchId);
                });

            migrationBuilder.CreateTable(
                name: "CreditCard",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreditCardNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditCard", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CreditCard_RegisterBatchCreditCard_Id",
                        column: x => x.Id,
                        principalTable: "RegisterBatchCreditCard",
                        principalColumn: "BatchId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RegisterCreditCard",
                columns: table => new
                {
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreditCardNumberId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegisterCreditCard", x => x.Email);
                    table.ForeignKey(
                        name: "FK_RegisterCreditCard_CreditCard_CreditCardNumberId",
                        column: x => x.CreditCardNumberId,
                        principalTable: "CreditCard",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RegisterCreditCard_CreditCardNumberId",
                table: "RegisterCreditCard",
                column: "CreditCardNumberId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RegisterCreditCard");

            migrationBuilder.DropTable(
                name: "CreditCard");

            migrationBuilder.DropTable(
                name: "RegisterBatchCreditCard");
        }
    }
}
