using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamOnline.Migrations
{
    /// <inheritdoc />
    public partial class AddResultUserRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "user_id",
                table: "results",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_results_user_id",
                table: "results",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_results_AspNetUsers_user_id",
                table: "results",
                column: "user_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_results_AspNetUsers_user_id",
                table: "results");

            migrationBuilder.DropIndex(
                name: "IX_results_user_id",
                table: "results");

            migrationBuilder.AlterColumn<string>(
                name: "user_id",
                table: "results",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true);
        }
    }
}
