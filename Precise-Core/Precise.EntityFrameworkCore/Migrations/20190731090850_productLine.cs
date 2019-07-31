using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Precise.Migrations
{
    public partial class productLine : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "PlanInfos",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "AuditedTime",
                table: "PlanInfos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AuditedUser",
                table: "PlanInfos",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ComplatedTime",
                table: "PlanInfos",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ProductLineId",
                table: "PlanInfos",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "Shifts",
                table: "PlanInfos",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProductLineInfos",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductLineInfos", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlanInfos_ProductLineId",
                table: "PlanInfos",
                column: "ProductLineId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlanInfos_ProductLineInfos_ProductLineId",
                table: "PlanInfos",
                column: "ProductLineId",
                principalTable: "ProductLineInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlanInfos_ProductLineInfos_ProductLineId",
                table: "PlanInfos");

            migrationBuilder.DropTable(
                name: "ProductLineInfos");

            migrationBuilder.DropIndex(
                name: "IX_PlanInfos_ProductLineId",
                table: "PlanInfos");

            migrationBuilder.DropColumn(
                name: "AuditedTime",
                table: "PlanInfos");

            migrationBuilder.DropColumn(
                name: "AuditedUser",
                table: "PlanInfos");

            migrationBuilder.DropColumn(
                name: "ComplatedTime",
                table: "PlanInfos");

            migrationBuilder.DropColumn(
                name: "ProductLineId",
                table: "PlanInfos");

            migrationBuilder.DropColumn(
                name: "Shifts",
                table: "PlanInfos");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "PlanInfos",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
