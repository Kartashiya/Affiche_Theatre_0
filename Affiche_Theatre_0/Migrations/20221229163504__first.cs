using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Affiche_Theatre_0.Migrations
{
    public partial class _first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateAdded",
                table: "Actors");

            migrationBuilder.DropColumn(
                name: "MetaDescription",
                table: "Actors");

            migrationBuilder.DropColumn(
                name: "MetaKeywords",
                table: "Actors");

            migrationBuilder.DropColumn(
                name: "MetaTitle",
                table: "Actors");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Actors");

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Path = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9997B3DD-8A2F-460B-99FD-F280115BAA78",
                column: "ConcurrencyStamp",
                value: "15c8c2d4-762d-4ac8-b7fd-44c8275a8aa3");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3F3D1162-B3B6-4934-A37C-C416E28BF618",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4065e74a-6d05-4a62-96b7-d38866cab8ad", "AQAAAAEAACcQAAAAEGa6kWwr3YLV1ZB3q//uAvuXrZ58KqNoU/vxETYw9uohN1rs650ea088uh0Seckfqw==" });

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("7195309f-189e-4b60-914f-6e07b401120e"),
                column: "DateAdded",
                value: new DateTime(2022, 12, 29, 16, 35, 3, 787, DateTimeKind.Utc).AddTicks(1928));

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("90860496-cbf5-4fdb-a308-14f61f6af28b"),
                column: "DateAdded",
                value: new DateTime(2022, 12, 29, 16, 35, 3, 787, DateTimeKind.Utc).AddTicks(3255));

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("ed1b025d-6c0b-4a5d-b230-7babccbe85fa"),
                column: "DateAdded",
                value: new DateTime(2022, 12, 29, 16, 35, 3, 787, DateTimeKind.Utc).AddTicks(3304));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateAdded",
                table: "Actors",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "MetaDescription",
                table: "Actors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MetaKeywords",
                table: "Actors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MetaTitle",
                table: "Actors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Actors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9997B3DD-8A2F-460B-99FD-F280115BAA78",
                column: "ConcurrencyStamp",
                value: "4cc08de0-63b8-4f57-9909-1a54cdd38911");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3F3D1162-B3B6-4934-A37C-C416E28BF618",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "88dbc024-2057-4b65-8872-73d58ec5cb2e", "AQAAAAEAACcQAAAAEIZIcLpPBcYBaE5waPlG1S+xt1IvCFAn6Feqr3pMH7IEOzq+lVmAp5HRuPtsYEQv1w==" });

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("7195309f-189e-4b60-914f-6e07b401120e"),
                column: "DateAdded",
                value: new DateTime(2022, 12, 26, 19, 28, 9, 218, DateTimeKind.Utc).AddTicks(6926));

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("90860496-cbf5-4fdb-a308-14f61f6af28b"),
                column: "DateAdded",
                value: new DateTime(2022, 12, 26, 19, 28, 9, 218, DateTimeKind.Utc).AddTicks(7799));

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("ed1b025d-6c0b-4a5d-b230-7babccbe85fa"),
                column: "DateAdded",
                value: new DateTime(2022, 12, 26, 19, 28, 9, 218, DateTimeKind.Utc).AddTicks(7841));
        }
    }
}
