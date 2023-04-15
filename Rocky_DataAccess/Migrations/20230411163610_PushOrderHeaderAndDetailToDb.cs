using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rocky_DataAccess.Migrations
{
    public partial class PushOrderHeaderAndDetailToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_inquiryDetail_inquiryHeader_InquiryHeaderId",
                table: "inquiryDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_inquiryDetail_Product_ProductId",
                table: "inquiryDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_inquiryHeader_AspNetUsers_ApplicationUserId",
                table: "inquiryHeader");

            migrationBuilder.DropPrimaryKey(
                name: "PK_inquiryHeader",
                table: "inquiryHeader");

            migrationBuilder.DropPrimaryKey(
                name: "PK_inquiryDetail",
                table: "inquiryDetail");

            migrationBuilder.RenameTable(
                name: "inquiryHeader",
                newName: "InquiryHeader");

            migrationBuilder.RenameTable(
                name: "inquiryDetail",
                newName: "InquiryDetail");

            migrationBuilder.RenameIndex(
                name: "IX_inquiryHeader_ApplicationUserId",
                table: "InquiryHeader",
                newName: "IX_InquiryHeader_ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_inquiryDetail_ProductId",
                table: "InquiryDetail",
                newName: "IX_InquiryDetail_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_inquiryDetail_InquiryHeaderId",
                table: "InquiryDetail",
                newName: "IX_InquiryDetail_InquiryHeaderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InquiryHeader",
                table: "InquiryHeader",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InquiryDetail",
                table: "InquiryDetail",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "OrderHeader",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ShippingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinalOrderTotal = table.Column<double>(type: "float", nullable: false),
                    OrderStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TransactionId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StreetAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderHeader", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderHeader_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderHeaderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Sqft = table.Column<int>(type: "int", nullable: false),
                    PricePerSqFt = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetail_OrderHeader_OrderHeaderId",
                        column: x => x.OrderHeaderId,
                        principalTable: "OrderHeader",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetail_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_OrderHeaderId",
                table: "OrderDetail",
                column: "OrderHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_ProductId",
                table: "OrderDetail",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderHeader_CreatedByUserId",
                table: "OrderHeader",
                column: "CreatedByUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_InquiryDetail_InquiryHeader_InquiryHeaderId",
                table: "InquiryDetail",
                column: "InquiryHeaderId",
                principalTable: "InquiryHeader",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InquiryDetail_Product_ProductId",
                table: "InquiryDetail",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InquiryHeader_AspNetUsers_ApplicationUserId",
                table: "InquiryHeader",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InquiryDetail_InquiryHeader_InquiryHeaderId",
                table: "InquiryDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_InquiryDetail_Product_ProductId",
                table: "InquiryDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_InquiryHeader_AspNetUsers_ApplicationUserId",
                table: "InquiryHeader");

            migrationBuilder.DropTable(
                name: "OrderDetail");

            migrationBuilder.DropTable(
                name: "OrderHeader");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InquiryHeader",
                table: "InquiryHeader");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InquiryDetail",
                table: "InquiryDetail");

            migrationBuilder.RenameTable(
                name: "InquiryHeader",
                newName: "inquiryHeader");

            migrationBuilder.RenameTable(
                name: "InquiryDetail",
                newName: "inquiryDetail");

            migrationBuilder.RenameIndex(
                name: "IX_InquiryHeader_ApplicationUserId",
                table: "inquiryHeader",
                newName: "IX_inquiryHeader_ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_InquiryDetail_ProductId",
                table: "inquiryDetail",
                newName: "IX_inquiryDetail_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_InquiryDetail_InquiryHeaderId",
                table: "inquiryDetail",
                newName: "IX_inquiryDetail_InquiryHeaderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_inquiryHeader",
                table: "inquiryHeader",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_inquiryDetail",
                table: "inquiryDetail",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_inquiryDetail_inquiryHeader_InquiryHeaderId",
                table: "inquiryDetail",
                column: "InquiryHeaderId",
                principalTable: "inquiryHeader",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_inquiryDetail_Product_ProductId",
                table: "inquiryDetail",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_inquiryHeader_AspNetUsers_ApplicationUserId",
                table: "inquiryHeader",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
