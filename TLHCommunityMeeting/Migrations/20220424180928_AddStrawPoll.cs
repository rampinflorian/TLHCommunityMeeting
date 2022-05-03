using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TLHCommunityMeeting.Migrations
{
    public partial class AddStrawPoll : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StrawPolls",
                columns: table => new
                {
                    StrawPollId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApiPath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StrawPolls", x => x.StrawPollId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StrawPolls");
        }
    }
}
