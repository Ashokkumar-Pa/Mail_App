using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mail_App.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrimaryAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TemporaryAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PinCode = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastChangesOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "OnetoOneMails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FromUserId = table.Column<int>(type: "int", nullable: true),
                    ToUserId = table.Column<int>(type: "int", nullable: true),
                    Subject = table.Column<string>(type: "nvarchar(280)", maxLength: 280, nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SendDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsReaded = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnetoOneMails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OnetoOneMails_User_FromUserId",
                        column: x => x.FromUserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OnetoOneMails_User_ToUserId",
                        column: x => x.ToUserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserPassword",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastChangesOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPassword", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserPassword_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OnetoOneMails_FromUserId",
                table: "OnetoOneMails",
                column: "FromUserId");

            migrationBuilder.CreateIndex(
                name: "IX_OnetoOneMails_ToUserId",
                table: "OnetoOneMails",
                column: "ToUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPassword_UserId",
                table: "UserPassword",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OnetoOneMails");

            migrationBuilder.DropTable(
                name: "UserPassword");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
