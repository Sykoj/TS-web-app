using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TsWebApp.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppSolutionRequests",
                columns: table => new
                {
                    RequestId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SolutionId = table.Column<int>(nullable: false),
                    User = table.Column<string>(nullable: true),
                    ExpectedTableauType = table.Column<int>(nullable: false),
                    TableauType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppSolutionRequests", x => x.RequestId);
                });

            migrationBuilder.CreateTable(
                name: "TableauSolutions",
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
                    table.PrimaryKey("PK_TableauSolutions", x => x.SolutionId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppSolutionRequests");

            migrationBuilder.DropTable(
                name: "TableauSolutions");
        }
    }
}
