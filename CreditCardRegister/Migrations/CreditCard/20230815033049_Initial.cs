using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CreditCardRegister.API.Migrations.CreditCard
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RegisterCreditCard");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "CreditCard",
                type: "bit",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "CreditCard");

            migrationBuilder.CreateTable(
                name: "RegisterCreditCard",
                columns: table => new
                {
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreditCardNumberId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
    }
}
