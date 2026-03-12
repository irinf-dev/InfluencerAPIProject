using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Influencers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Platfrom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Niche = table.Column<int>(type: "int", nullable: false),
                    Market = table.Column<int>(type: "int", nullable: false),
                    PreviousCollaborations = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EngagementRate = table.Column<float>(type: "real", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    InstagramHandle = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    TwitterHandle = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    TikTokHandle = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    YouTubeHandle = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Influencers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Campaigns",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TargetPlatform = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AudienceAgeMini = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AudienceAgeMax = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AudienceGender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MinimumFollowers = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaximumFollowers = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: false),
                    InfluencerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campaigns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Campaigns_Influencers_InfluencerId",
                        column: x => x.InfluencerId,
                        principalTable: "Influencers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Campaigns_InfluencerId",
                table: "Campaigns",
                column: "InfluencerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Campaigns");

            migrationBuilder.DropTable(
                name: "Influencers");
        }
    }
}
