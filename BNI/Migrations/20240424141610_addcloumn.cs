using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BNI.Migrations
{
    public partial class addcloumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DurationOfParticipation",
                table: "Member",
                type: "nvarchar(max)",
                nullable: true);
        }

    }
}
