using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SallesWebMvc.Migrations
{
    public partial class OtherEntitiescorrecao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SellesRecord_Sellet_SellerId",
                table: "SellesRecord");

            migrationBuilder.DropForeignKey(
                name: "FK_Sellet_Department_DepartmentId",
                table: "Sellet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sellet",
                table: "Sellet");

            migrationBuilder.RenameTable(
                name: "Sellet",
                newName: "Seller");

            migrationBuilder.RenameIndex(
                name: "IX_Sellet_DepartmentId",
                table: "Seller",
                newName: "IX_Seller_DepartmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Seller",
                table: "Seller",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Seller_Department_DepartmentId",
                table: "Seller",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SellesRecord_Seller_SellerId",
                table: "SellesRecord",
                column: "SellerId",
                principalTable: "Seller",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seller_Department_DepartmentId",
                table: "Seller");

            migrationBuilder.DropForeignKey(
                name: "FK_SellesRecord_Seller_SellerId",
                table: "SellesRecord");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Seller",
                table: "Seller");

            migrationBuilder.RenameTable(
                name: "Seller",
                newName: "Sellet");

            migrationBuilder.RenameIndex(
                name: "IX_Seller_DepartmentId",
                table: "Sellet",
                newName: "IX_Sellet_DepartmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sellet",
                table: "Sellet",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SellesRecord_Sellet_SellerId",
                table: "SellesRecord",
                column: "SellerId",
                principalTable: "Sellet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sellet_Department_DepartmentId",
                table: "Sellet",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
