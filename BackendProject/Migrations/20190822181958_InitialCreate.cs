using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BackendProject.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brigade",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BrigadeNumber = table.Column<string>(type: "varchar(16)", nullable: false),
                    BrigadeName = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brigade", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Claim",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ClaimNumber = table.Column<string>(type: "varchar(16)", nullable: false),
                    Customer = table.Column<string>(type: "varchar(100)", nullable: false),
                    CustomerRequisites = table.Column<string>(type: "text", nullable: false),
                    ListWorks = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Claim", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Task",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TaskDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    TaskNumber = table.Column<string>(type: "varchar(16)", nullable: false),
                    ClaimId = table.Column<int>(nullable: false),
                    BrigadeId = table.Column<int>(nullable: false),
                    TaskStaging = table.Column<string>(type: "text", nullable: false),
                    BrigadeConfirmation = table.Column<bool>(type: "bit", nullable: false),
                    BrigadeNote = table.Column<string>(type: "text", nullable: true),
                    BrigadeMark = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Task_Brigade_BrigadeId",
                        column: x => x.BrigadeId,
                        principalTable: "Brigade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Task_Claim_ClaimId",
                        column: x => x.ClaimId,
                        principalTable: "Claim",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Task_BrigadeId",
                table: "Task",
                column: "BrigadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Task_ClaimId",
                table: "Task",
                column: "ClaimId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Task");

            migrationBuilder.DropTable(
                name: "Brigade");

            migrationBuilder.DropTable(
                name: "Claim");
        }
    }
}
