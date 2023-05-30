using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace XmlParser.Migrations
{
    /// <inheritdoc />
    public partial class AddDocument_LN_1C : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Documents_LN_1C",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DB_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Problem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DbReplicaID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Server_name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents_LN_1C", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Documents_1C",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Form = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UNID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Schema = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DB_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DbReplicaID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Server_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Document_LN_1CId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents_1C", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Documents_1C_Documents_LN_1C_Document_LN_1CId",
                        column: x => x.Document_LN_1CId,
                        principalTable: "Documents_LN_1C",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Fields_1C",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Alias = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Item = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Document_1CId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fields_1C", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fields_1C_Documents_1C_Document_1CId",
                        column: x => x.Document_1CId,
                        principalTable: "Documents_1C",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Documents_1C_Document_LN_1CId",
                table: "Documents_1C",
                column: "Document_LN_1CId");

            migrationBuilder.CreateIndex(
                name: "IX_Fields_1C_Document_1CId",
                table: "Fields_1C",
                column: "Document_1CId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fields_1C");

            migrationBuilder.DropTable(
                name: "Documents_1C");

            migrationBuilder.DropTable(
                name: "Documents_LN_1C");
        }
    }
}
