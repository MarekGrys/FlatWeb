using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlatWeb.Migrations
{
    /// <inheritdoc />
    public partial class updated_time : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "WhenUpdated",
                table: "Flats",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WhenUpdated",
                table: "Flats");
        }
    }
}
