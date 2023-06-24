using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class MatchRankForeignKeyCorrection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SummonerRanks_Summoners_SummonerId",
                table: "SummonerRanks");

            migrationBuilder.UpdateData(
                table: "Summoners",
                keyColumn: "SummonerId",
                keyValue: null,
                column: "SummonerId",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "SummonerId",
                table: "Summoners",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Summoners_SummonerId",
                table: "Summoners",
                column: "SummonerId");

            migrationBuilder.AddForeignKey(
                name: "FK_SummonerRanks_Summoners_SummonerId",
                table: "SummonerRanks",
                column: "SummonerId",
                principalTable: "Summoners",
                principalColumn: "SummonerId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SummonerRanks_Summoners_SummonerId",
                table: "SummonerRanks");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Summoners_SummonerId",
                table: "Summoners");

            migrationBuilder.AlterColumn<string>(
                name: "SummonerId",
                table: "Summoners",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_SummonerRanks_Summoners_SummonerId",
                table: "SummonerRanks",
                column: "SummonerId",
                principalTable: "Summoners",
                principalColumn: "Puuid",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
