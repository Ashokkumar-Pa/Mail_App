using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mail_App.Migrations
{
    public partial class Draft : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OnetoOneMails_User_FromUserId",
                table: "OnetoOneMails");

            migrationBuilder.AlterColumn<int>(
                name: "FromUserId",
                table: "OnetoOneMails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "DraftMails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FromUserId = table.Column<int>(type: "int", nullable: false),
                    ToUserId = table.Column<int>(type: "int", nullable: true),
                    Subject = table.Column<string>(type: "nvarchar(280)", maxLength: 280, nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastSaveDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DraftMails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DraftMails_User_FromUserId",
                        column: x => x.FromUserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DraftMails_User_ToUserId",
                        column: x => x.ToUserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DraftMails_FromUserId",
                table: "DraftMails",
                column: "FromUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DraftMails_ToUserId",
                table: "DraftMails",
                column: "ToUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_OnetoOneMails_User_FromUserId",
                table: "OnetoOneMails",
                column: "FromUserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OnetoOneMails_User_FromUserId",
                table: "OnetoOneMails");

            migrationBuilder.DropTable(
                name: "DraftMails");

            migrationBuilder.AlterColumn<int>(
                name: "FromUserId",
                table: "OnetoOneMails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_OnetoOneMails_User_FromUserId",
                table: "OnetoOneMails",
                column: "FromUserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
