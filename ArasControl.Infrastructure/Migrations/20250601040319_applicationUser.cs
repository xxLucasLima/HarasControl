using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArasControl.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class applicationUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "HarasId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HarasId",
                table: "AspNetUsers");
        }
    }
}
