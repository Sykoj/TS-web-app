using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ts.App.Data.Migrations
{
    public partial class RefactorChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TableauSolutions");

            migrationBuilder.CreateTable(
                name: "TableauSerializedSolutions",
                columns: table => new
                {
                    SolutionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TableauInputSerialized = table.Column<string>(nullable: true),
                    SolutionNodeSerialized = table.Column<string>(nullable: true),
                    RequestDateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableauSerializedSolutions", x => x.SolutionId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TableauSerializedSolutions");

            migrationBuilder.CreateTable(
                name: "TableauSolutions",
                columns: table => new
                {
                    SolutionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RequestDateTime = table.Column<DateTime>(nullable: false),
                    SolutionNodeSerialized = table.Column<string>(nullable: true),
                    TableauInputSerialized = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableauSolutions", x => x.SolutionId);
                });
        }
    }
}
