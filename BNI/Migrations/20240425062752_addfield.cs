using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BNI.Migrations
{
    public partial class addfield : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            
            migrationBuilder.AddColumn<string>(
                name: "FieldOfRegistration",
                table: "Member",
                type: "nvarchar(max)",
                nullable: true);

        
        }
    }
}
