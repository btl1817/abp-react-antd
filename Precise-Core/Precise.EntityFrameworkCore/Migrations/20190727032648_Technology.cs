using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Precise.Migrations
{
    public partial class Technology : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TechnologyInfos",
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
                    RubberCode = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechnologyInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TechnologyFeeds",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    Step = table.Column<int>(nullable: false),
                    MaterialsCode = table.Column<string>(nullable: true),
                    StandardWeight = table.Column<decimal>(nullable: false),
                    ErrorWeight = table.Column<decimal>(nullable: false),
                    MaterialsType = table.Column<int>(nullable: false),
                    TechnologyInfoId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechnologyFeeds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TechnologyFeeds_TechnologyInfos_TechnologyInfoId",
                        column: x => x.TechnologyInfoId,
                        principalTable: "TechnologyInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TechnologySteps",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    Step = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ControlTemp = table.Column<int>(nullable: false),
                    ControlTime = table.Column<int>(nullable: false),
                    ControlPower = table.Column<int>(nullable: false),
                    ControlType = table.Column<int>(nullable: false),
                    AStopTime = table.Column<int>(nullable: false),
                    BStopTime = table.Column<int>(nullable: false),
                    CStopTime = table.Column<int>(nullable: false),
                    ColdWaterTemp = table.Column<int>(nullable: false),
                    FeedMaxTemp = table.Column<int>(nullable: false),
                    FeedMinTemp = table.Column<int>(nullable: false),
                    Remark = table.Column<string>(nullable: true),
                    TechnologyId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechnologySteps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TechnologySteps_TechnologyInfos_TechnologyId",
                        column: x => x.TechnologyId,
                        principalTable: "TechnologyInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TechnologyFeeds_TechnologyInfoId",
                table: "TechnologyFeeds",
                column: "TechnologyInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_TechnologySteps_TechnologyId",
                table: "TechnologySteps",
                column: "TechnologyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
