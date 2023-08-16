using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CreditCardRegister.API.Migrations
{
    public partial class Finally : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RegisterBatchCreditCard",
                columns: table => new
                {
                    BatchId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BatchName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BatchDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BatchAmount = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegisterBatchCreditCard", x => x.BatchId);
                });

            migrationBuilder.CreateTable(
                name: "CreditCard",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreditCardNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CreditCard");

            migrationBuilder.DropTable(
                name: "RegisterBatchCreditCard");
        }
    }
}
