using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SS15Laundry.Migrations
{
    /// <inheritdoc />
    public partial class AddPick : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PickUp",
                columns: table => new
                {
                    PickUpId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IssueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Noted = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Total = table.Column<double>(type: "float", nullable: false),
                    Discount = table.Column<int>(type: "int", nullable: false),
                    GrandTotal = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PickUp", x => x.PickUpId);
                    table.ForeignKey(
                        name: "FK_PickUp_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PickUp_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PickUpDetail",
                columns: table => new
                {
                    PickUpDetailId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PickUpId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Qty = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PickUpDetail", x => x.PickUpDetailId);
                    table.ForeignKey(
                        name: "FK_PickUpDetail_Item_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Item",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PickUpDetail_PickUp_PickUpId",
                        column: x => x.PickUpId,
                        principalTable: "PickUp",
                        principalColumn: "PickUpId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PickUp_CustomerId",
                table: "PickUp",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_PickUp_EmployeeId",
                table: "PickUp",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_PickUpDetail_ItemId",
                table: "PickUpDetail",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_PickUpDetail_PickUpId",
                table: "PickUpDetail",
                column: "PickUpId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PickUpDetail");

            migrationBuilder.DropTable(
                name: "PickUp");
        }
    }
}
