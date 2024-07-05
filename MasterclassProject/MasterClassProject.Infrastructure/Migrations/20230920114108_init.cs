using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MasterClassProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Masterclass");

            migrationBuilder.EnsureSchema(
                name: "MasterClass");

            migrationBuilder.CreateTable(
                name: "tblCompany",
                schema: "Masterclass",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCompany", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblUsers",
                schema: "MasterClass",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<long>(type: "bigint", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblUsers_tblCompany_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "Masterclass",
                        principalTable: "tblCompany",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblTimeRegistration",
                schema: "MasterClass",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    startTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    endTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblTimeRegistration", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblTimeRegistration_tblUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "MasterClass",
                        principalTable: "tblUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                schema: "Masterclass",
                table: "tblCompany",
                columns: new[] { "Id", "CompanyName" },
                values: new object[,]
                {
                    { 1L, "Disney" },
                    { 2L, "Looney Toons" }
                });

            migrationBuilder.InsertData(
                schema: "MasterClass",
                table: "tblUsers",
                columns: new[] { "Id", "CompanyId", "UserName" },
                values: new object[,]
                {
                    { 1L, 1L, "Mickey Mouse" },
                    { 2L, 1L, "Minnie Mouse" },
                    { 3L, 1L, "Donald Duck" },
                    { 4L, 1L, "Daisy Duck" },
                    { 5L, 1L, "Goofy" },
                    { 6L, 2L, "Bugs Bunny" },
                    { 7L, 2L, "Daffy Duck" },
                    { 8L, 2L, "Wile E. Coyote" },
                    { 9L, 2L, "Tweety Bird" },
                    { 10L, 2L, "Sylvester The Cat" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblTimeRegistration_UserId",
                schema: "MasterClass",
                table: "tblTimeRegistration",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tblUsers_CompanyId",
                schema: "MasterClass",
                table: "tblUsers",
                column: "CompanyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblTimeRegistration",
                schema: "MasterClass");

            migrationBuilder.DropTable(
                name: "tblUsers",
                schema: "MasterClass");

            migrationBuilder.DropTable(
                name: "tblCompany",
                schema: "Masterclass");
        }
    }
}