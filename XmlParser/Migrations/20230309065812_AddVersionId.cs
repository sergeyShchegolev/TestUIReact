using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace XmlParser.Migrations
{
    /// <inheritdoc />
    public partial class AddVersionId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "VersionId",
                table: "Documents_LN",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VersionId",
                table: "Documents_LN");
        }
    }
}
