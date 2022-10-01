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
                name: "ResourceStore",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FhirId = table.Column<string>(type: "text", nullable: false),
                    ResourceTypeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceStore", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResourceStore_ResourceType_ResourceTypeId",
                        column: x => x.ResourceTypeId,
                        principalTable: "ResourceType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IndexReference",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FhirId = table.Column<string>(type: "text", nullable: false),
                    VersionId = table.Column<string>(type: "text", nullable: true),
                    ResourceTypeId = table.Column<int>(type: "integer", nullable: false),
                    TargetResourceStoreId = table.Column<int>(type: "integer", nullable: true),
                    ResourceStoreId = table.Column<int>(type: "integer", nullable: false),
                    SearchParameterId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndexReference", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IndexReference_ResourceStore_ResourceStoreId",
                        column: x => x.ResourceStoreId,
                        principalTable: "ResourceStore",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IndexReference_ResourceStore_TargetResourceStoreId",
                        column: x => x.TargetResourceStoreId,
                        principalTable: "ResourceStore",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IndexReference_ResourceType_ResourceTypeId",
                        column: x => x.ResourceTypeId,
                        principalTable: "ResourceType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IndexString",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Value = table.Column<string>(type: "text", nullable: false),
                    ResourceStoreId = table.Column<int>(type: "integer", nullable: false),
                    SearchParameterId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndexString", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IndexString_ResourceStore_ResourceStoreId",
                        column: x => x.ResourceStoreId,
                        principalTable: "ResourceStore",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IndexReference_FhirId",
                table: "IndexReference",
                column: "FhirId");

            migrationBuilder.CreateIndex(
                name: "IX_IndexReference_ResourceStoreId",
                table: "IndexReference",
                column: "ResourceStoreId");

            migrationBuilder.CreateIndex(
                name: "IX_IndexReference_ResourceTypeId",
                table: "IndexReference",
                column: "ResourceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_IndexReference_TargetResourceStoreId",
                table: "IndexReference",
                column: "TargetResourceStoreId");

            migrationBuilder.CreateIndex(
                name: "IX_IndexString_ResourceStoreId",
                table: "IndexString",
                column: "ResourceStoreId");

            migrationBuilder.CreateIndex(
                name: "IX_IndexString_Value",
                table: "IndexString",
                column: "Value");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceStore_FhirId",
                table: "ResourceStore",
                column: "FhirId");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceStore_ResourceTypeId",
                table: "ResourceStore",
                column: "ResourceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceType_Name",
                table: "ResourceType",
                column: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IndexReference");

            migrationBuilder.DropTable(
                name: "IndexString");

            migrationBuilder.DropTable(
                name: "ResourceStore");

            migrationBuilder.DropTable(
                name: "ResourceType");
        }
    }
}
