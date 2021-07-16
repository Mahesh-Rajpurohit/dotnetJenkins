using Microsoft.EntityFrameworkCore.Migrations;

namespace CarDataApi.Repository.Sql.Migrations
{
    public partial class CarDataMigrationAddTimeStampAndOtherColumns_16_1_2021 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "tbl_CarData",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "tbl_CarData");
        }
    }
}
