using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Piro.FhirServer.Application.Repository.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ResourceType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FhirResource",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FhirId = table.Column<string>(type: "text", nullable: false),
                    ResourceTypeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FhirResource", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FhirResource_ResourceType_ResourceTypeId",
                        column: x => x.ResourceTypeId,
                        principalTable: "ResourceType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IndexResourceReference",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TargetFhirId = table.Column<string>(type: "text", nullable: false),
                    TargetVersionId = table.Column<string>(type: "text", nullable: false),
                    TargetResourceTypeId = table.Column<int>(type: "integer", nullable: false),
                    TargetResourceId = table.Column<int>(type: "integer", nullable: true),
                    SourceResourceId = table.Column<int>(type: "integer", nullable: false),
                    FhirResourceId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndexResourceReference", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IndexResourceReference_FhirResource_FhirResourceId",
                        column: x => x.FhirResourceId,
                        principalTable: "FhirResource",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_IndexResourceReference_FhirResource_SourceResourceId",
                        column: x => x.SourceResourceId,
                        principalTable: "FhirResource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IndexResourceReference_FhirResource_TargetResourceId",
                        column: x => x.TargetResourceId,
                        principalTable: "FhirResource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IndexResourceReference_ResourceType_TargetResourceTypeId",
                        column: x => x.TargetResourceTypeId,
                        principalTable: "ResourceType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IndexString",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Value = table.Column<string>(type: "text", nullable: false),
                    SourceResourceId = table.Column<int>(type: "integer", nullable: false),
                    FhirResourceId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndexString", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IndexString_FhirResource_FhirResourceId",
                        column: x => x.FhirResourceId,
                        principalTable: "FhirResource",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_IndexString_FhirResource_SourceResourceId",
                        column: x => x.SourceResourceId,
                        principalTable: "FhirResource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FhirResource_FhirId",
                table: "FhirResource",
                column: "FhirId");

            migrationBuilder.CreateIndex(
                name: "IX_FhirResource_ResourceTypeId",
                table: "FhirResource",
                column: "ResourceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_IndexResourceReference_FhirResourceId",
                table: "IndexResourceReference",
                column: "FhirResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_IndexResourceReference_SourceResourceId",
                table: "IndexResourceReference",
                column: "SourceResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_IndexResourceReference_TargetFhirId",
                table: "IndexResourceReference",
                column: "TargetFhirId");

            migrationBuilder.CreateIndex(
                name: "IX_IndexResourceReference_TargetResourceId",
                table: "IndexResourceReference",
                column: "TargetResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_IndexResourceReference_TargetResourceTypeId",
                table: "IndexResourceReference",
                column: "TargetResourceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_IndexString_FhirResourceId",
                table: "IndexString",
                column: "FhirResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_IndexString_SourceResourceId",
                table: "IndexString",
                column: "SourceResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_IndexString_Value",
                table: "IndexString",
                column: "Value");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceType_Name",
                table: "ResourceType",
                column: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IndexResourceReference");

            migrationBuilder.DropTable(
                name: "IndexString");

            migrationBuilder.DropTable(
                name: "FhirResource");

            migrationBuilder.DropTable(
                name: "ResourceType");
        }
    }
}
