using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddNichesAndMarketsTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Niche",
                table: "Influencers",
                newName: "NicheId");

            migrationBuilder.RenameColumn(
                name: "Market",
                table: "Influencers",
                newName: "MarketId");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Campaigns",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "AudienceAgeMini",
                table: "Campaigns",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "AudienceAgeMax",
                table: "Campaigns",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Markets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MarketName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Markets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Niches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NicheName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Niches", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Influencers_MarketId",
                table: "Influencers",
                column: "MarketId");

            migrationBuilder.CreateIndex(
                name: "IX_Influencers_NicheId",
                table: "Influencers",
                column: "NicheId");

            migrationBuilder.CreateIndex(
                name: "IX_Campaigns_Title",
                table: "Campaigns",
                column: "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Markets_MarketName",
                table: "Markets",
                column: "MarketName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Niches_NicheName",
                table: "Niches",
                column: "NicheName",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Influencers_Markets_MarketId",
                table: "Influencers",
                column: "MarketId",
                principalTable: "Markets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Influencers_Niches_NicheId",
                table: "Influencers",
                column: "NicheId",
                principalTable: "Niches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Influencers_Markets_MarketId",
                table: "Influencers");

            migrationBuilder.DropForeignKey(
                name: "FK_Influencers_Niches_NicheId",
                table: "Influencers");

            migrationBuilder.DropTable(
                name: "Markets");

            migrationBuilder.DropTable(
                name: "Niches");

            migrationBuilder.DropIndex(
                name: "IX_Influencers_MarketId",
                table: "Influencers");

            migrationBuilder.DropIndex(
                name: "IX_Influencers_NicheId",
                table: "Influencers");

            migrationBuilder.DropIndex(
                name: "IX_Campaigns_Title",
                table: "Campaigns");

            migrationBuilder.RenameColumn(
                name: "NicheId",
                table: "Influencers",
                newName: "Niche");

            migrationBuilder.RenameColumn(
                name: "MarketId",
                table: "Influencers",
                newName: "Market");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Campaigns",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "AudienceAgeMini",
                table: "Campaigns",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "AudienceAgeMax",
                table: "Campaigns",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
