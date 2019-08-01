using Microsoft.EntityFrameworkCore.Migrations;

namespace Precise.Migrations
{
    public partial class plan_fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Shifts",
                table: "PlanInfos",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Shifts",
                table: "PlanInfos",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
