using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace multi_tenants.Migrations
{
    /// <inheritdoc />
    public partial class addpermalink : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Buildings_ProjectId",
                table: "Buildings");

            migrationBuilder.AddColumn<string>(
                name: "Permalink",
                table: "Projects",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Permalink",
                table: "Buildings",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_Permalink",
                table: "Projects",
                column: "Permalink",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Buildings_ProjectId_Permalink",
                table: "Buildings",
                columns: new[] { "ProjectId", "Permalink" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Projects_Permalink",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Buildings_ProjectId_Permalink",
                table: "Buildings");

            migrationBuilder.DropColumn(
                name: "Permalink",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Permalink",
                table: "Buildings");

            migrationBuilder.CreateIndex(
                name: "IX_Buildings_ProjectId",
                table: "Buildings",
                column: "ProjectId");
        }
    }
}
