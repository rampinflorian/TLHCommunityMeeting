using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TLHCommunityMeeting.Migrations
{
    public partial class meetingDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "MeetingAt",
                table: "Questions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MeetingAt",
                table: "Questions");
        }
    }
}
