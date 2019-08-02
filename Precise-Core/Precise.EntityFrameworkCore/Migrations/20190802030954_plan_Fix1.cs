using Microsoft.EntityFrameworkCore.Migrations;

namespace Precise.Migrations
{
    public partial class plan_Fix1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "TechnologyInfos",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "ProductLineInfos",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TechnologyCode",
                table: "PlanInfos",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CardCode",
                table: "PlanInfos",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OutCode",
                table: "PlanInfos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Remark",
                table: "PlanInfos",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TechnologyInfos_Code",
                table: "TechnologyInfos",
                column: "Code",
                unique: true,
                filter: "[Code] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ProductLineInfos_Code",
                table: "ProductLineInfos",
                column: "Code",
                unique: true,
                filter: "[Code] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PlanInfos_CardCode",
                table: "PlanInfos",
                column: "CardCode",
                unique: true,
                filter: "[CardCode] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PlanInfos_TechnologyCode",
                table: "PlanInfos",
                column: "TechnologyCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TechnologyInfos_Code",
                table: "TechnologyInfos");

            migrationBuilder.DropIndex(
                name: "IX_ProductLineInfos_Code",
                table: "ProductLineInfos");

            migrationBuilder.DropIndex(
                name: "IX_PlanInfos_CardCode",
                table: "PlanInfos");

            migrationBuilder.DropIndex(
                name: "IX_PlanInfos_TechnologyCode",
                table: "PlanInfos");

            migrationBuilder.DropColumn(
                name: "OutCode",
                table: "PlanInfos");

            migrationBuilder.DropColumn(
                name: "Remark",
                table: "PlanInfos");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "TechnologyInfos",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "ProductLineInfos",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TechnologyCode",
                table: "PlanInfos",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CardCode",
                table: "PlanInfos",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
